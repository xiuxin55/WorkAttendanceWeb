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
using System.IO;
//using System.Windows.Forms;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class yhgl_UsedPrize : System.Web.UI.Page
    {
        public static bool IsVisible;
        public static string M_EUrl = "#";
        public System.Web.UI.Page pageparam;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsVisible = false;
            pageparam = sender as System.Web.UI.Page;
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
                  
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                    //        M_EUrl = model.M_EUrl;
                    //    }
                    UserInfo ui = Session["sysAdmin"] as UserInfo;
                    WebSiteModel website = new WebSiteModel();
                    website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
                    if (website == null || website.WebsiteType == "0")
                    {
                        IsVisible = true;
                    }
                    this.lblMenu1.Text = "菜单管理";
                    this.lblMenu2.Text = "奖品管理";
                    this.lblMenu3.Text = "奖品管理详细";
                    this.lblMenu4.Text = "已兑换奖品列表";
                    this.lblMenu2.NavigateUrl = Session["奖品管理"].ToString();
                    this.lblMenu3.NavigateUrl = Request.UrlReferrer.ToString();
                    this.lblMenu4.NavigateUrl = Request.RawUrl;
                    Session["已兑换奖品列表"] = Request.RawUrl; 
                    Bind();
                    //}
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string fldOrder = "Prize_user  desc";//排序字段名
            string strWhere = "";//查询条件

            string prizeid = Request["prizeid"];
            string websiteid = Request["websiteid"];
            //string M_Username = this.M_Username.Value.Trim();
            //string M_EMail = this.M_EMail.Value.Trim();
            //string M_Address = this.M_Address.Value.Trim();


            UserInfo ui = Session["sysAdmin"] as UserInfo;


            strWhere += "  Prize_Flag ='0' and Pize_PrizeID='" + prizeid + "' and Pize_WebsiteNum='" + websiteid + "'";
            

            if (this.Prize_CardNum.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_CardNum like '%{0}%'", this.Prize_CardNum.Value);
            }
            if (this.Prize_IdentifyCard.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_IdentifyCard like '%{0}%'", this.Prize_IdentifyCard.Value);
            }
            if (this.Prize_user.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_user like '%{0}%'", this.Prize_user.Value);
            }
            int StartNum = 0;
            int EndNum = int.MaxValue;
       
            strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            DataTable dtLsit = PrizeExchangeInfoManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
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