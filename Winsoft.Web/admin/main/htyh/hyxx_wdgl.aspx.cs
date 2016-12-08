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

namespace Winsoft.Web.admin.main.htyh
{
    public partial class hyxx_wdgl : System.Web.UI.Page
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
            //string fldOrder = " WebsiteID desc";//排序字段名
            //string strWhere = "";//查询条件
            //this.AspNetPager1.PageSize = 15;//页尺寸
            //int StartNum = this.AspNetPager1.PageSize*(this.AspNetPager1.CurrentPageIndex - 1);
            //int EndNum = this.AspNetPager1.PageSize * this.AspNetPager1.CurrentPageIndex;
            //strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            //DataTable dtLsit = WebsiteManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
            //    //this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            ////DataTable dtCount = PrizeInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            ////this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());
            //this.rtManager.DataSource = dtLsit;
            //this.rtManager.DataBind();

            string fldOrder = " WebsiteID desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = int.MaxValue;//页尺寸
            int StartNum = 0;
            int EndNum = int.MaxValue;
            strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            DataTable dtLsit = WebsiteManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
            //this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            //DataTable dtCount = PrizeInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            //this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());
            this.rtManager.DataSource = dtLsit;
            this.rtManager.DataBind();
        }
        /// <summary>
        /// 删除网点号
        /// </summary>
        /// <param name="id"></param>
        public void DeleteData(string id)
        {

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