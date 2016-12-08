using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Common;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web.admin.main.scxw
{
    public partial class single : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public string f_img2;
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
                            M_Url = model.M_Url;
                        }
                        Bind();
                    }
                }
            }
        }

        #region 数据加载

        private void Bind()
        {
            string code = Request["code"];
            if (code != null && code != string.Empty)
            {
                NewsInfo model = NewsInfoManage.GetInstance().GetModelByMID(code);
                if (model != null)
                {
                    this.N_Title.Value = model.N_Title;
                    this.N_Url.Value = model.N_Url;
                }
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
            string code = Request["code"];
            string N_Title = this.N_Title.Value.Trim();
            string N_Url = this.N_Url.Value.Trim();
            bool isType = true;
            bool result = true;

            if (code == null || code == string.Empty)
            {
                MessageBox.Show(this, "操作失败！");
            }
            else if (N_Title == string.Empty)
            {
                MessageBox.Show(this, "请输入标题名称！");
            }
            else if (N_Url == string.Empty)
            {
                MessageBox.Show(this, "请输入链接地址！");
            }
            else
            {
                #region 初始化对象

                NewsInfo model = NewsInfoManage.GetInstance().GetModelByMID(code);

                if (model == null)
                {
                    isType = false;
                    model = new NewsInfo();
                }

                #endregion

                model.N_Title = N_Title;
                model.N_Url = N_Url;
                model.N_Img = "";
                model.N_Time = DateTime.Now;
                model.N_Author = "";
                model.N_Content = "";
                model.N_Order = 0;
                model.N_Type = 0;
                model.N_Source = "";
                model.N_Str1 = "";
                model.N_Str2 = "";
                model.N_Str3 = "";
                model.N_Str4 = "";

                if (isType)
                {
                    result = NewsInfoManage.GetInstance().Update(model);
                }
                else
                {
                    model.N_ID = Guid.NewGuid().ToString();
                    model.M_ID = code;
                    NewsInfoManage.GetInstance().Add(model);
                }

                if (result)
                {
                    MessageBox.Show(this, "操作成功！");
                }
                else
                {
                    MessageBox.Show(this, "操作失败！");
                }
            }
        }

        #endregion
    }
}