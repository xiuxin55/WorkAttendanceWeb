using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;
using System.Text.RegularExpressions;
using System.Data;

namespace Winsoft.Web.admin.main.schy
{
    public partial class hyxx_xgyx : System.Web.UI.Page
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
                    this.M_EMail.Value = model.M_EMail;
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
            string regex_email = @"^\w+@\w+(\.\w+)+(\,\w+@\w+(\.\w+)+)*$";
            string M_EMail = this.M_EMail.Value.Trim();

            if (id != null && id != string.Empty)
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该会员不存在！");
                }
                else if (M_EMail == string.Empty)
                {
                    MessageBox.Show(this, "请输入电子邮箱！");
                }
                else if (!Regex.IsMatch(M_EMail, regex_email))
                {
                    MessageBox.Show(this, "电子邮箱格式不正确！");
                }
                else
                {
                    string strWhere = " M_EMail='" + M_EMail + "' and M_ID!='" + id + "'";
                    DataTable dtEmail = PrizeInfoManage.GetInstance().GetList(strWhere).Tables[0];
                    if (dtEmail != null && dtEmail.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "您输入的电子邮箱已被人使用！");
                    }
                    else
                    {
                        model.M_EMail = M_EMail;
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