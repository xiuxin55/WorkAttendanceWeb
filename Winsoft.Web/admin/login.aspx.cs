using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Common;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["sysAdmin"] = null;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string A_Uid = this.A_Uid.Value.Trim();
            string A_Pwd = this.A_Pwd.Value.Trim();
            string A_Yzm = this.A_Yzm.Value.Trim();

            if (A_Uid == string.Empty)
            {
                MessageBox.Show(this, "请输入帐号！");
            }
            else if (A_Pwd == string.Empty)
            {
                MessageBox.Show(this, "请输入密码！");
            }
            else if (A_Yzm == string.Empty)
            {
                MessageBox.Show(this, "请输入验证码！");
            }
            else if (Session["Code"] == null)
            {
                MessageBox.Show(this, "验证码已失效，请刷新验证码！");
            }
            else if (Session["Code"].ToString().ToLower() != A_Yzm.ToLower())
            {
                MessageBox.Show(this, "验证码不正确或已失效！");
            }
            else
            {
                bool result = UserInfoManage.GetInstance().Login(A_Uid, MD5.MDString(A_Pwd));

                if (result)
                {
                    UserInfo model = UserInfoManage.GetInstance().GetModelByUserName(A_Uid);
                    Session["sysAdmin"] = model;
                    Response.Redirect("main/main.aspx");
                }
                else
                {
                    MessageBox.Show(this, "用户名或密码错误！");
                }
            }
        }
    }
}