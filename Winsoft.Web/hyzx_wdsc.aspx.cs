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

namespace Winsoft.Web
{
    public partial class hyzx_wdsc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["myuser"] == null)
            {
                Response.Redirect("hydl.aspx");
            }
            Bind();
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

            string fldOrder = " p1.C_Time desc";//排序字段名
            string strWhere = " and p1.M_ID='" + modelMemberInfo.M_ID + "'";//查询条件
            this.AspNetPager1.PageSize = 5;//页尺寸
            string V_Name = this.V_Name.Value.Trim();

            if (V_Name != string.Empty)
            {
                strWhere += " and p2.V_Name like '%" + V_Name + "%'";
            }

            DataTable dtLsit = ActivityInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = ActivityInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtManage.DataSource = dtLsit;
            this.rtManage.DataBind();
        }

        #endregion

        #region 数据查询

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

        protected void rtManage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            //删除
            if (e.CommandName == "delete")
            {
                bool result = ActivityInfoManage.GetInstance().Delete(id);

                switch (result)
                {
                    case true:
                        MessageBox.Show(this, "删除成功！");
                        break;
                    default:
                        MessageBox.Show(this, "删除失败！");
                        break;
                }
            }
            Bind();
        }
        /// <summary>
        /// 添加弹出确认框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rtManage_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("btnDelete");
                btn.Attributes.Add("onclick", "return confirm('你确认要删除该条信息吗？');");
            }
        }

        #endregion
    }
}