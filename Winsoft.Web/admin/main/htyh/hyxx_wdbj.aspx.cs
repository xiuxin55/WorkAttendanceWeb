using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class hyxx_wdbj : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public static bool AddAndUpdate = true;
        public System.Web.UI.Page pageparam;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        this.lblMenu.Text = "管理员管理》网点添加/编辑";
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                        M_Url = "htyh/hyxx_wdbj.aspx";
                    //    }
                        Bind();
                    //}
                }
            }
        }

        #region 数据加载

        private void Bind()
        {
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                WebSiteModel model = WebsiteManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    AddAndUpdate = false;
                    //this.Password_tr.
                    this.WebsiteID.Value = model.WebsiteID;
                    //this.US_Password.Value = model.US_PassWord;
                    this.WebsiteName.Value = model.WebsiteName;
                    this.WebsiteType.Text = model.WebsiteType;
                    this.WebsiteFlag.Text = model.WebsiteFlag;
                }
            }
            else
            {
                AddAndUpdate = true;
            }
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string id = Request["id"];
            string WebsiteID =   this.WebsiteID.Value;
            string WebsiteName = this.WebsiteName.Value;
            string WebsiteType = this.WebsiteType.Text;
            string WebsiteFlag = this.WebsiteFlag.Text;
            
            WebSiteModel model = new WebSiteModel();
            if (id != null && id != string.Empty)
            {
                model = WebsiteManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该网点已不存在！");
                }
                else
                {
                    //if (WebsiteManage.GetInstance().ExistsByWebSiteID(WebsiteID))
                    //{
                    //    MessageBox.Show(pageparam, "该网点已存在");
                    //    return;
                    //}
                    string oldwebsitename = model.WebsiteName;
                    model.WebsiteID = WebsiteID;
                    model.WebsiteName = WebsiteName;
                    model.WebsiteType = WebsiteType;
                    model.WebsiteFlag = WebsiteFlag;
                    bool result = WebsiteManage.GetInstance().Update(model, id, oldwebsitename);
                    if (result)
                    {
                        Response.Write("<script>alert('操作成功！');</script>");
                    }
                    else
                    {
                        MessageBox.Show(pageparam, "操作失败！");
                    }
                }
            }
            else
            {
                if (!WebsiteManage.GetInstance().ExistsByWebSiteID(WebsiteID))
                {
                    model.WebsiteID = WebsiteID;
                    model.WebsiteName = WebsiteName;
                    model.WebsiteType = WebsiteType;
                    model.WebsiteFlag = WebsiteFlag;
                    if (WebsiteID.Trim() == "" || WebsiteID == null || WebsiteID == string.Empty || WebsiteName.Trim() == "" || WebsiteName == null || WebsiteName == string.Empty)
                    {
                        MessageBox.Show(pageparam, "网点号、网点名称都不能为空！");
                        return;
                    }
                    bool result = WebsiteManage.GetInstance().Add(model);

                    if (result)
                    {
                        MessageBox.Show(pageparam, "操作成功！");
                        this.WebsiteID.Value = "";
                        this.WebsiteName.Value="";
                   
                    }
                    else
                    {
                        MessageBox.Show(pageparam, "操作失败！");
                    }
                }
                else
                {
                    MessageBox.Show(pageparam, "该网点已存在");
                }
            }
            //回转列表页
            
           
        }

        #endregion

        #region 数据跳转

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("../" + M_Url);
        }

        #endregion
    }
}