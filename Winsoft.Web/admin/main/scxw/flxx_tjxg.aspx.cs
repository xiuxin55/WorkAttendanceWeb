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
    public partial class flxx_tjxg : System.Web.UI.Page
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
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                NewsInfo model = NewsInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    this.N_Order.Value = model.N_Order.ToString();
                    this.N_Str1.Value = model.N_Str1;
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
            string id = Request["id"];
            string code = Request["code"];
            string N_Order = this.N_Order.Value.Trim();
            string N_Str1 = this.N_Str1.Value.Trim();
            bool result = true;

            if (N_Order == string.Empty)
            {
                MessageBox.Show(this, "请输入排序号码！");
            }
            else if (N_Str1 == string.Empty)
            {
                MessageBox.Show(this, "请输入菜单标题！");
            }
            else
            {
                #region 初始化对象

                NewsInfo model = null;

                if (id != null && id != string.Empty)
                {
                    model = NewsInfoManage.GetInstance().GetModel(id);
                }
                else
                {
                    model = new NewsInfo();
                }

                #endregion

                model.N_Title = "";
                model.N_Url = "";
                model.N_Img = "";
                model.N_Time = DateTime.Now;
                model.N_Author = "";
                model.N_Content = "";
                model.N_Order = Convert.ToInt32(N_Order);
                model.N_Type = 0;
                model.N_Source = "";
                model.N_Str1 = N_Str1;
                model.N_Str2 = "";
                model.N_Str3 = "";
                model.N_Str4 = "";

                if (id != null && id != string.Empty)
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