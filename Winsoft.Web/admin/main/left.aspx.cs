using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;

namespace Winsoft.Web.admin.main
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.h0.Visible = false;
            this.t0.Visible = false;
            if (!Page.IsPostBack)
            {
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                
                    UserInfo ui = Session["sysAdmin"] as UserInfo;
                    WebSiteModel website = new WebSiteModel();
                    website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
                    if (website==null || website.WebsiteType == "0")
                    {
                        this.h0.Visible = true;
                        this.t0.Visible = true;
                    }
                    
            }
        }

        /// <summary>
        /// 获取菜单ID
        /// </summary>
        protected string GetID()
        {
            string id = Request["code"];
            if (Request["code"] == null)
            {
                string strWhere = " M_Type=0 and M_Level=0 order by M_Order";
                List<CityInfo> list = CityInfoManage.GetInstance().GetModelList(strWhere);
                if (list != null && list.Count > 0)
                {
                    //id = list[0].M_ID;
                }
            }
            return id;
        }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        protected List<CityInfo> GetLevel(int M_Level, string M_ID)
        {
            string strWhere = " M_Type=0 and M_Level=" + M_Level + " and M_PID='" + M_ID + "' order by M_Order";
            return CityInfoManage.GetInstance().GetModelList(strWhere);
        }
    }
}