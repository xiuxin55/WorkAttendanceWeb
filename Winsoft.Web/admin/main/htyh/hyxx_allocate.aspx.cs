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
    public partial class hyxx_allocate : System.Web.UI.Page
    {
        public static string M_EUrl = "#";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();  
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
                    this.lblMenu2.Text = "奖品编辑";
                    this.lblMenu3.Text = "奖品分配";
                    this.lblMenu2.NavigateUrl = Request.UrlReferrer.ToString();
                    this.lblMenu3.NavigateUrl = Request.RawUrl;
                    Session["奖品分配"] = Request.RawUrl; 
                    Bind();
                    //}
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string id = Request["id"];
            //ViewState["amount"] = Request["amount"];
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

        protected void btnAllocate_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            string amount = Request["amount"];
          
            List<PrizeAllocateModel> list = new List<PrizeAllocateModel>();
            int sum = 0;
            foreach (RepeaterItem rs in rtManager.Items)
            {
                PrizeAllocateModel temp = new PrizeAllocateModel();
                temp.PrizeID = id;
                temp.WebsiteID = ((Label)rs.FindControl("WebsiteID")).Text;
                temp.WebsiteName = ((Label)rs.FindControl("WebsiteName")).Text;
                int result;
                if (int.TryParse(((HtmlInputText)(rs.FindControl("PrizeCount"))).Value, out result))
                {
                    temp.PrizeAmount=temp.PrizeCount = result;
                    sum=sum +result ;
                    list.Add(temp);
                }
                else
                {
                    Response.Write("<script>alert('数量必须为数字');</script>");
                    return;
                }
            }
            if (sum > int.Parse(amount))
            {
                Response.Write("<script>alert('分配总数不能大于奖品总数');</script>");
                return;
            }
            if (list.Count > 0)
            {
                if (PrizeInfoManage.GetInstance().UpdateAllocate(list))
                {
                    Response.Write("<script>alert('操作成功');</script>");
                    //Response.Redirect(ViewState["retu"].ToString());  
                }
                else { Response.Write("<script>alert('操作失败');</script>"); }

            }
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>history.back(2);</script>");
            Response.Redirect(ViewState["retu"].ToString());  
        }
    }
}