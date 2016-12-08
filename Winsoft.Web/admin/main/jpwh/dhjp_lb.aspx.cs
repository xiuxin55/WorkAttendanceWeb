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

namespace Winsoft.Web.admin.main.jpwh
{
    public partial class dhjp_lb : System.Web.UI.Page
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
                    //string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    //if (f_menu != string.Empty)
                    //{
                    //    this.lblMenu.Text = f_menu;
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                    //        M_EUrl = model.M_EUrl;
                    //    }
                    Bind();
                    //}
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string fldOrder = " P_Id desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = 15;//页尺寸
            //string start = this.start.Text.Trim();
            //string end = this.end.Text.Trim();
            string P_Name = this.P_Name.Value.Trim();
            string P_ActivityName = this.P_ActivityName.Value.Trim();
            string P_Authentication = this.P_Authentication.Value.Trim();
            string P_ServiceDepartment = this.P_ServiceDepartment.Value.Trim();

            //if (start != string.Empty && end != string.Empty)
            //{
            //    strWhere += " and US_RegisterTime between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            //}

            if (P_Name != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(P_Name, "P_Name") + ")";
            }

            if (P_ActivityName != string.Empty)
            {
                strWhere += " and (P_ActivityName ='" + P_ActivityName  + "')";
            }

            if (P_Authentication != string.Empty)
            {
                strWhere += " and (P_Authentication ='" + P_Authentication + "')";
            }
            if (P_ServiceDepartment != string.Empty)
            {
                strWhere += " and (P_ServiceDepartment ='" + P_ServiceDepartment + "')";
            }
            
            int StartNum = this.AspNetPager1.PageSize*(this.AspNetPager1.CurrentPageIndex - 1);
            int EndNum = this.AspNetPager1.PageSize * this.AspNetPager1.CurrentPageIndex;
            strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            DataTable dtLsit = PrizeInfoManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
                //this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            //DataTable dtCount = PrizeInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            //this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

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