using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;
using Winsoft.Common;
using Winsoft.Model;
using System.Collections;

namespace Winsoft.Web.admin.main.scsp
{
    public partial class yqxkc : System.Web.UI.Page
    {
        public static string M_EUrl = "#";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                else
                {
                    string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    if (f_menu != string.Empty)
                    {
                        this.lblMenu.Text = f_menu;
                        CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                        if (model != null)
                        {
                            M_EUrl = model.M_EUrl;
                        }
                        Bind();
                    }
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string fldOrder = " p1.O_NextTime desc";//排序字段名
            string strWhere = " and p1.O_Status='已取消'";//查询条件
            this.AspNetPager1.PageSize = 15;

            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string O_Order = this.O_Order.Value.Trim();
            string M_Username = this.M_Username.Value.Trim();
            string V_Name = this.V_Name.Value.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and p1.O_NextTime between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (O_Order != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(O_Order, "p1.O_Order") + ")";
            }

            if (M_Username != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Username, "p3.M_Username") + ")";
            }

            if (V_Name != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(V_Name, "p2.V_Name") + ")";
            }

            //DataTable dtList = OrderInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            //DataTable dtCount = OrderInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            //this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            //this.rtManager.DataSource = dtList;
            this.rtManager.DataBind();
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 导出当前页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDcnow_Click(object sender, EventArgs e)
        {
            string fldOrder = " p1.O_NextTime desc";//排序字段名
            string strWhere = " and p1.O_Status='已取消'";//查询条件
            this.AspNetPager1.PageSize = 15;

            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string O_Order = this.O_Order.Value.Trim();
            string M_Username = this.M_Username.Value.Trim();
            string V_Name = this.V_Name.Value.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and p1.O_NextTime between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (O_Order != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(O_Order, "p1.O_Order") + ")";
            }

            if (M_Username != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Username, "p3.M_Username") + ")";
            }

            if (V_Name != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(V_Name, "p2.V_Name") + ")";
            }

            DataTable dtList = OrderInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 3);

            ExcelToDc(dtList);
        }
        //全部导出
        protected void btnDcAll_Click(object sender, EventArgs e)
        {
            string fldOrder = " p1.O_NextTime desc";//排序字段名
            string strWhere = " and p1.O_Status='已取消'";//查询条件

            DataTable dtList = OrderInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 4);

            ExcelToDc(dtList);
        }

        #endregion

        #region Excel导出

        private void ExcelToDc(DataTable dtList)
        {
            //用来存放替换表头的hashtable
            Hashtable htTitle = new Hashtable();
            htTitle.Add("abcd", "序号");
            htTitle.Add("O_Order", "订单号");
            htTitle.Add("O_Price", "订单金额");
            htTitle.Add("O_Status", "订单状态");
            htTitle.Add("O_NextTime", "下单时间");
            htTitle.Add("O_PaymentTime", "付款时间");
            htTitle.Add("VT_Name", "类型名称");
            htTitle.Add("VT_EName", "英文名称");
            htTitle.Add("V_Name", "视频名称");
            htTitle.Add("V_Keyword", "关键词");
            htTitle.Add("V_Price", "视频原价");
            htTitle.Add("V_NewPrice", "视频现价");
            htTitle.Add("V_Content", "视频介绍");
            htTitle.Add("V_LessonCount", "课时数");
            htTitle.Add("V_BuyCount", "购买次数");
            htTitle.Add("V_PlayCount", "播放次数");
            htTitle.Add("V_BrowseCount", "浏览次数");
            htTitle.Add("V_CollectionCount", "收藏次数");
            htTitle.Add("V_BuyCountReal", "真实购买次数");
            htTitle.Add("V_PlayCountReal", "真实播放次数");
            htTitle.Add("V_BrowseCountReal", "真实浏览次数");
            htTitle.Add("V_CollectionCountReal", "真实收藏次数");
            htTitle.Add("M_Username", "会员帐号");
            htTitle.Add("M_EMail", "电子邮箱");
            htTitle.Add("M_Name", "会员姓名");
            htTitle.Add("M_Nickname", "会员昵称");
            htTitle.Add("M_Sex", "会员性别");
            htTitle.Add("M_Tel", "联系电话");
            htTitle.Add("M_Address", "联系地址");
            htTitle.Add("M_Like", "兴趣爱好");
            htTitle.Add("M_About", "个人简介");
            htTitle.Add("M_Time", "注册时间");

            DataToExcel de = new DataToExcel();
            //参数说明：第一个放查询的datatable，第二个放标题名称，第三个不用改为路径，第四个为hashtable
            string filename = de.OutputExcelTitle(dtList, "已购买课程信息", this.MapPath("\\ExcelReport\\"), htTitle);
            this.ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "window.open('../../../ExcelReport/" + filename + "');", true);
        }

        #endregion
    }
}