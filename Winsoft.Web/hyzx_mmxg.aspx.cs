using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.Common;
using Winsoft.BLL;

namespace Winsoft.Web
{
    public partial class hyzx_mmxg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["myuser"] == null)
                {
                    Response.Redirect("hydl.aspx");
                }
            }
        }

        #region 数据处理

        /// <summary>
        /// 提交数据
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string M_OPassword = this.M_OPassword.Value.Trim();
            string M_Password = this.M_Password.Value.Trim();
            string M_RPassword = this.M_RPassword.Value.Trim();

            if (M_OPassword == string.Empty)
            {
                MessageBox.Show(this, "请输入原密码！");
            }
            else if (M_Password == string.Empty)
            {
                MessageBox.Show(this, "请输入新密码！");
            }
            else if (M_RPassword == string.Empty)
            {
                MessageBox.Show(this, "请输入确认密码！");
            }
            else if (M_Password != M_RPassword)
            {
                MessageBox.Show(this, "两次输入的密码不一致！");
            }
            else if (modelMemberInfo.M_Password != MD5.MDString(M_OPassword))
            {
                MessageBox.Show(this, "您输入的原密码不正确！");
            }
            else
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(modelMemberInfo.M_ID);
                model.M_Password = MD5.MDString(M_Password);

                bool result = PrizeInfoManage.GetInstance().Update(model);

                if (result)
                {
                    MessageBox.Show(this, "操作成功！");
                    Session["myuser"] = model;
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