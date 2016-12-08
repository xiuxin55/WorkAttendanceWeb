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
using System.Web.UI.HtmlControls;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class PrizeLeftAmount : System.Web.UI.Page
    {
        public static string M_EUrl = "#";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ViewState["retu"] = Request.UrlReferrer.ToString();  
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
                    this.lblMenu1.Text = "菜单管理";
                    this.lblMenu2.Text = "奖品管理";
                    this.lblMenu3.Text = "奖品管理详细";
                    this.lblMenu2.NavigateUrl = Request.UrlReferrer.ToString(); 
                    this.lblMenu3.NavigateUrl=Request.RawUrl;
                    Session["奖品管理详细"] = Request.RawUrl; 
                    Bind();
                    //}
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string id = Request["id"];
            //id = id.Remove(0, 1).Remove(id.Length - 2, 1);
            List<PrizeAllocateModel> list = PrizeInfoManage.GetInstance().GetAllPrize(id);

            this.rtManager.DataSource = list;
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


        protected void btnResult_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>history.back(2);</script>");
            //Response.Redirect(ViewState["retu"].ToString());  
        }
    }
}