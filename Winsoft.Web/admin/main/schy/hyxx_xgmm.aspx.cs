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
    public partial class hyxx_xgmm : System.Web.UI.Page
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
            string M_Pwd = this.M_Pwd.Value.Trim();
            string M_RPwd = this.M_RPwd.Value.Trim();

            if (id != null && id != string.Empty)
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该会员不存在！");
                }
                else if (M_Pwd == string.Empty)
                {
                    MessageBox.Show(this, "请输入密码！");
                }
                else if (M_RPwd == string.Empty)
                {
                    MessageBox.Show(this, "请输入确认密码！");
                }
                else if (M_Pwd != M_RPwd)
                {
                    MessageBox.Show(this, "两次输入的密码不一致！");
                }
                else
                {
                    model.M_Password = MD5.MDString(M_Pwd);

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