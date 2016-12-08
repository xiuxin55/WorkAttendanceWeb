using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;
using Winsoft.Model;
using Winsoft.Common;

namespace Winsoft.Web.admin.main.schy
{
    public partial class hyxx : System.Web.UI.Page
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
            string fldOrder = " p1.M_Time desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = 15;//页尺寸
            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string M_Username = this.M_Username.Value.Trim();
            string M_EMail = this.M_EMail.Value.Trim();
            string M_Address = this.M_Address.Value.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and p1.M_Time between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (M_Username != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Username, "p1.M_Username") + ")";
            }

            if (M_EMail != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_EMail, "p1.M_EMail") + ")";
            }

            if (M_Address != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Address, "p1.M_Address") + ")";
            }

            DataTable dtLsit = PrizeInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = PrizeInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtManager.DataSource = dtLsit;
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
    }
}