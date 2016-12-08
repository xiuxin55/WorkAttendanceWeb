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
    public partial class hyzx_grzl : System.Web.UI.Page
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public string ClientIP
        {
            get
            {
                string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["myuser"] == null)
                {
                    Response.Redirect("hydl.aspx");
                }
                Bind();
            }
        }

        #region 数据加载

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            PrizeInfo model = (PrizeInfo)Session["myuser"];

            if (model == null)
            {
                Response.Redirect("hydl.aspx");
            }

            this.M_Username.Text = model.M_Username;
            this.M_Img.Src = model.M_Img;
            this.M_EMail.Text = model.M_EMail;
            this.M_Nickname.Value = model.M_Nickname;
            this.M_Name.Value = model.M_Name;
            this.M_Tel.Value = model.M_Tel;
            this.M_Sex.Text = model.M_Sex;
            this.M_About.Value = model.M_About;
            this.M_Like.Value = model.M_Like;

            if (model.M_Address == string.Empty)
            {
                this.M_Address.Value = IPAddress.GetNetwork2(ClientIP)[1] + IPAddress.GetNetwork2(ClientIP)[2];
            }
            else
            {
                this.M_Address.Value = model.M_Address;
            }
        }

        #endregion

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

            string M_Nickname = this.M_Nickname.Value.Trim();
            string M_Name = this.M_Name.Value.Trim();
            string M_Tel = this.M_Tel.Value.Trim();
            string M_Address = this.M_Address.Value.Trim();
            string M_Sex = this.M_Sex.Text.Trim();
            string M_About = this.M_About.Value.Trim();
            string M_Like = this.M_Like.Value.Trim();

            PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(modelMemberInfo.M_ID);

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
                Session["myuser"] = model;
            }
            else
            {
                MessageBox.Show(this, "操作失败！");
            }
        }

        #endregion
    }
}