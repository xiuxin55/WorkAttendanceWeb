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
    public partial class pjxx_tjxg : System.Web.UI.Page
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
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    this.C_Time.Text = model.C_Time.ToString("yyyy-MM-dd HH:mm:ss");
                    this.C_Content.Value = model.C_Content;
                    this.C_Status.Text = model.C_Status;
                    this.C_ReplyContent.Value = model.C_ReplyContent;
                    this.C_ReplyTime.Text = model.C_ReplyTime;

                    //视频信息
                    VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(model.V_ID);
                    if (modelVidoInfo != null)
                    {
                        this.V_Name.Text = modelVidoInfo.V_Name;
                    }

                    //会员信息
                    PrizeInfo modelMemberInfo = PrizeInfoManage.GetInstance().GetModel(model.M_ID);
                    if (modelMemberInfo != null)
                    {
                        this.M_Username.Text = modelMemberInfo.M_Username;
                        this.M_Img.ImageUrl = modelMemberInfo.M_Img;
                    }

                    //管理员信息
                    UserInfo modelAdminInfo = UserInfoManage.GetInstance().GetModel(model.A_ID);
                    if (modelAdminInfo != null)
                    {
                        this.A_Username.Text = modelAdminInfo.A_UserName;
                    }
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