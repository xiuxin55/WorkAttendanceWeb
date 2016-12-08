using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web.admin.main.schy
{
    public partial class hyxx_tjxg : System.Web.UI.Page
    {
        public static string M_Url = "#";
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
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    this.M_Username.Text = model.M_Username;
                    this.M_Img.ImageUrl = model.M_Img;
                    this.M_EMail.Text = model.M_EMail;
                    this.M_Nickname.Value = model.M_Nickname;
                    this.M_Name.Value = model.M_Name;
                    this.M_Tel.Value = model.M_Tel;
                    this.M_Sex.Text = model.M_Sex;
                    this.M_About.Value = model.M_About;
                    this.M_Like.Value = model.M_Like;
                    this.M_Address.Value = model.M_Address;
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
            string M_Nickname = this.M_Nickname.Value.Trim();
            string M_Name = this.M_Name.Value.Trim();
            string M_Tel = this.M_Tel.Value.Trim();
            string M_Address = this.M_Address.Value.Trim();
            string M_Sex = this.M_Sex.Text.Trim();
            string M_About = this.M_About.Value.Trim();
            string M_Like = this.M_Like.Value.Trim();

            if (id != null && id != string.Empty)
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该会员不存在！");
                }
                else
                {
                    model.M_Nickname = M_Nickname;
                    model.M_Name = M_Name;
                    model.M_Tel = M_Tel;
                    model.M_Address = M_Address;
                    model.M_Sex = M_Sex;
                    model.M_About = M_About;
                    model.M_Like = M_Like;

                    bool result = PrizeInfoManage.GetInstance().Update(model);

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
            else
            {
                MessageBox.Show(this, "请选择会员！");
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