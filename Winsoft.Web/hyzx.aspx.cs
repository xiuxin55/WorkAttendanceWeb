using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using System.Data;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web
{
    public partial class hyzx : System.Web.UI.Page
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public string ClientIP
        {
            get
            {
                string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["myuser"] == null)
                {
                    Response.Redirect("hydl.aspx");
                }
                Bind();
            }
        }

        #region 数据加载

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            #region 加载会员信息

            this.M_Img.Src = modelMemberInfo.M_Img;
            this.M_Username.Text = modelMemberInfo.M_Username;

            #endregion

            #region 我的收藏

            BindWdsc(modelMemberInfo);

            #endregion

            #region 最近浏览

            BindZjll();

            #endregion

            #region 我的订单

            BindWfk();
            BindYgm();
            BindYqx();

            #endregion
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        private void BindWdsc(PrizeInfo modelMemberInfo)
        {
            string fldOrder = " p1.C_Time desc";//排序字段名
            string strWhere = " and p1.M_ID='" + modelMemberInfo.M_ID + "'";//查询条件

            DataTable dtLsit = ActivityInfoManage.GetInstance().GetPageList(3, 1, strWhere, fldOrder, 0);
            DataTable dtCount = ActivityInfoManage.GetInstance().GetPageList(3, 1, strWhere, fldOrder, 1);
            int dateCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.btnWdscCount.Text = "已收藏课程（" + dateCount + "）";

            this.rtWdsc.DataSource = dtLsit;
            this.rtWdsc.DataBind();
        }

        /// <summary>
        /// 最近浏览
        /// </summary>
        private void BindZjll()
        {
            string fldOrder = " p1.VH_Time desc";//排序字段名
            string strWhere = " and p1.VH_IP='" + ClientIP + "'";//查询条件

            DataTable dtList = ProvinceInfoManage.GetInstance().GetPageList(3, 1, strWhere, fldOrder, 0);

            this.rtZjll.DataSource = dtList;
            this.rtZjll.DataBind();
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 未付款课程
        /// </summary>
        protected void btnWfkCount_Click(object sender, EventArgs e)
        {
            Response.Redirect("hyzx_wddd.aspx");
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        protected void btnWdscCount_Click(object sender, EventArgs e)
        {
            Response.Redirect("hyzx_wdsc.aspx");
        }

        #endregion

        #region 未付款课程

        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindWfk()
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string fldOrder = " p1.O_NextTime desc";//排序字段名
            string strWhere = " and p1.M_ID='" + modelMemberInfo.M_ID + "' and p1.O_Status='已下单'";//查询条件
            this.AspNetPagerWfk.PageSize = 5;

            DataTable dtList = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerWfk.PageSize, this.AspNetPagerWfk.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerWfk.PageSize, this.AspNetPagerWfk.CurrentPageIndex, strWhere, fldOrder, 1);
            int dateCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.AspNetPagerWfk.RecordCount = dateCount;
            this.btnWfkCount.Text = "待支付课程（" + dateCount + "）";

            this.rtWfk.DataSource = dtList;
            this.rtWfk.DataBind();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        protected void AspNetPagerWfk_PageChanged(object sender, EventArgs e)
        {
            BindWfk();
        }

        /// <summary>
        /// 处理数据
        /// </summary>
        protected void rtWfk_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];
            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            //去付款
            if (e.CommandName == "qfk")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('暂未开通！')", true);
            }
            //取消订单
            if (e.CommandName == "qxdd")
            {
                OrderInfo model = OrderInfoManage.GetInstance().GetModel(id);

                if (model != null && model.O_Status == "已下单" && modelMemberInfo.M_ID == model.M_ID)
                {
                    model.O_Status = "已取消";
                    bool result = OrderInfoManage.GetInstance().Update(model);
                    if (result)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('取消成功！')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('取消失败！')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('取消失败！')", true);
                }
            }
            BindWfk();
        }
        /// <summary>
        /// 添加确认弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rtWfk_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnQxdd = (LinkButton)e.Item.FindControl("btnQxdd");
                btnQxdd.Attributes.Add("onclick", "return confirm('您确认要取消该订单吗？');");
            }
        }

        #endregion

        #region 已购买课程

        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindYgm()
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string fldOrder = " p1.O_PaymentTime desc";//排序字段名
            string strWhere = " and p1.M_ID='" + modelMemberInfo.M_ID + "' and p1.O_Status='已付款'";//查询条件
            this.AspNetPagerYgm.PageSize = 5;

            DataTable dtList = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerYgm.PageSize, this.AspNetPagerYgm.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerYgm.PageSize, this.AspNetPagerYgm.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPagerYgm.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtYgm.DataSource = dtList;
            this.rtYgm.DataBind();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        protected void AspNetPagerYgm_PageChanged(object sender, EventArgs e)
        {
            BindYgm();
        }

        #endregion

        #region 已取消课程

        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindYqx()
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string fldOrder = " p1.O_NextTime desc";//排序字段名
            string strWhere = " and p1.M_ID='" + modelMemberInfo.M_ID + "' and p1.O_Status='已取消'";//查询条件
            this.AspNetPagerYqx.PageSize = 5;

            DataTable dtList = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerYqx.PageSize, this.AspNetPagerYqx.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = OrderInfoManage.GetInstance().GetPageList(this.AspNetPagerYqx.PageSize, this.AspNetPagerYqx.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPagerYqx.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtYqx.DataSource = dtList;
            this.rtYqx.DataBind();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        protected void AspNetPagerYqx_PageChanged(object sender, EventArgs e)
        {
            BindYqx();
        }

        #endregion

        #region 切换选项卡

        /// <summary>
        /// 未付款课程
        /// </summary>
        protected void btnWfk_Click(object sender, EventArgs e)
        {
            this.divWfk.Visible = true;
            this.divYgm.Visible = false;
            this.divYqx.Visible = false;

            this.btnWfk.CssClass = "dct_a1";
            this.btnYgm.CssClass = "dct_a2";
            this.btnYqx.CssClass = "dct_a2";
        }

        /// <summary>
        /// 已购买课程
        /// </summary>
        protected void btnYgm_Click(object sender, EventArgs e)
        {
            this.divWfk.Visible = false;
            this.divYgm.Visible = true;
            this.divYqx.Visible = false;

            this.btnWfk.CssClass = "dct_a2";
            this.btnYgm.CssClass = "dct_a1";
            this.btnYqx.CssClass = "dct_a2";
        }

        /// <summary>
        /// 已取消课程
        /// </summary>
        protected void btnYqx_Click(object sender, EventArgs e)
        {
            this.divWfk.Visible = false;
            this.divYgm.Visible = false;
            this.divYqx.Visible = true;

            this.btnWfk.CssClass = "dct_a2";
            this.btnYgm.CssClass = "dct_a2";
            this.btnYqx.CssClass = "dct_a1";
        }

        #endregion
    }
}