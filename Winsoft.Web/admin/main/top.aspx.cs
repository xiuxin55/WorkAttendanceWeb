using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using System.Data;
using Winsoft.Common;

namespace Winsoft.Web.admin.main
{
    public partial class top : System.Web.UI.Page
    {
        public static string username = "";
        public static int userid ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ImportHref.Visible = false;
                this.A1.Visible = false;
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                UserInfo myuser = (UserInfo)Session["sysAdmin"];
                username = myuser.US_UserName;
                userid = myuser.US_UserId;
                UserInfo ui = Session["sysAdmin"] as UserInfo;
                WebSiteModel website = new WebSiteModel();
                website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
                if (website==null || website.WebsiteType == "0")
                {
                    this.ImportHref.Visible = true;
                    this.A1.Visible = true;
                
                }
                Bind();
            }
        }

        public void Bind()
        {
            //string strWhere = " M_Type=0 and M_Level=0 order by M_Order";
            //this.rtMenu.DataSource = CityInfoManage.GetInstance().GetList(strWhere).Tables[0];
            //this.rtMenu.DataBind();
           
        }
        protected void test()
        {
            string hello = "";
        }

     
      
    }
}