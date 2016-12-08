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
    public partial class pjxx_hf : System.Web.UI.Page
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
            UserInfo modelAdminInfo = (UserInfo)Session["sysAdmin"];
            if (modelAdminInfo == null)
            {
                Response.Redirect("~/admin/login.aspx");
            }

            string id = Request["id"];
            string C_ReplyContent = this.C_ReplyContent.Value.Trim();

            if (id != null && id != string.Empty)
            {
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该评价不存在！");
                }
                else if (model.A_ID != string.Empty)
                {
                    MessageBox.Show(this, "该评价已回复！");
                }
                else if (C_ReplyContent == string.Empty)
                {
                    MessageBox.Show(this, "请输入回复内容！");
                }
                else
                {
                    model.A_ID = modelAdminInfo.A_ID;
                    model.C_ReplyContent = C_ReplyContent;
                    model.C_ReplyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    bool result = ServiceDepartmentInfoManage.GetInstance().Update(model);

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
                MessageBox.Show(this, "请选择评价信息！");
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