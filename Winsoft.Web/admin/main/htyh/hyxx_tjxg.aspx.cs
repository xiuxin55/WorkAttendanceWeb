using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;
using System.Data;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class hyxx_tjxg : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public static bool AddAndUpdate = true;
        public static string inputtype = "";
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
                    //string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    //if (f_menu != string.Empty)
                    //{
                        this.lblMenu.Text = "管理员管理》用户添加/编辑";
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                        M_Url = "htyh/hyxx_tjxg.aspx";
                    //    }
                        Bind();
                    //}
                }
            }
        }

        #region 数据加载

        private void Bind()
        {
            string id = Request["id"];
            this.WebsiteDropDownList.Items.Clear();
            this.WebsiteDropDownList.Items.Add("请选择");
            DataTable dt= UserInfoManage.GetInstance().GetWebsiteList();
            List<string> websitenames = new List<string>();
            if (dt != null)
            {
                foreach (DataRow  item in dt.Rows)
                {
                    this.WebsiteDropDownList.Items.Add(item["WebsiteName"].ToString());
                    websitenames.Add(item["WebsiteName"].ToString());
                }
            }
            if (id != null && id != string.Empty)
            {
              
                UserInfo model = UserInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    AddAndUpdate = false;
                    //this.Password_tr.
                    this.US_Name.Value = model.US_Name;
                    //this.US_Password.Value = model.US_PassWord;
                    this.US_UserName.Disabled = true;
          
                    this.US_UserName.Style.Add(HtmlTextWriterStyle.BackgroundColor,"#C0C0C0");
                    this.US_UserName.Value = model.US_UserName;
                    this.US_UserName.Disabled = true;

                    this.US_Password_qr.Value =MD5.DecodeString( model.US_PassWord);
                    this.US_Password.Attributes.Remove("Type");
                    this.US_Password.Attributes.Add("Type", "text");
                    this.US_Password.Value = MD5.DecodeString(model.US_PassWord);


                    this.US_Email.Value = model.US_Email;
                    this.US_TelPhone.Value = model.US_TelPhone;
                    this.US_CardId.Text = model.US_CardId;
                    this.US_Sex.Text = model.US_Sex;
                    //this.US_Authentication.Text = model.US_Authentication;
                    this.US_CardId.Text = model.US_CardId;
                    if (websitenames.Contains(model.US_WebsiteName))
                    {
                        this.WebsiteDropDownList.Text = model.US_WebsiteName;
                    }
                    else
                    {
                        this.WebsiteDropDownList.Text = "该网点已禁用或不存在";
                    }
                }
            }
            else
            {
                AddAndUpdate = true;
                this.US_Password.Attributes.Remove("Type");
                this.US_Password.Attributes.Add("Type", "password");
                this.US_UserName.Disabled = false;
                this.US_UserName.Style.Remove(HtmlTextWriterStyle.BackgroundColor);
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
            string US_Name = this.US_Name.Value;
            string US_Password = this.US_Password.Value;
            string US_ServiceDepartment = "";
            string US_QQ = "";
            string US_UnitName = "";
            string US_UserName = this.US_UserName.Value;
            string US_Password_qr = this.US_Password_qr.Value;
            string US_Email = this.US_Email.Value;
            string US_TelPhone = this.US_TelPhone.Value;
            string US_CardId = this.US_CardId.Text;
            string US_Sex = this.US_Sex.Text;
            //string US_Authentication = this.US_Authentication.Text;
            string US_Integral = "";
            string US_Birthday ="";
            string US_WebsiteName = this.WebsiteDropDownList.Text;
            UserInfo model = null;
            if (id != null && id != string.Empty)
            {
                model = UserInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该用户已不存在！");
                }
                else
                {
                    model.US_Name = US_Name;
                    
                    model.US_ServiceDepartment = US_ServiceDepartment;
                    model.US_QQ = US_QQ;
                    model.US_UnitName = US_UnitName;
                    model.US_UserName = US_UserName;
                    model.US_PassWord =MD5.MDString(US_Password);
                    model.US_Email = US_Email;
                    model.US_TelPhone = US_TelPhone;
                    model.US_CardId = US_CardId;
                    model.US_Sex = US_Sex;
                    model.US_Authentication = "";
                    //model.US_Integral = Convert.ToInt32(US_Integral);
                    model.US_Birthday = US_Birthday;
                    model.US_WebsiteName = US_WebsiteName;
                    if (US_Password_qr != US_Password)
                    {
                        MessageBox.Show(this, "两次密码输入不同！");
                        return;
                    }
                    bool result = UserInfoManage.GetInstance().Update(model);

                    if (result)
                    {
                        Response.Write("<script>alert('操作成功！');</script>");
                        this.US_Name.Value = "";
                        this.US_Password.Value = "";
                        this.US_UserName.Value = "";
                        this.US_Password_qr.Value = "";
                        this.US_Email.Value = "";
                        this.US_TelPhone.Value = "";
                        this.US_CardId.Text = "";
                        //Response.Redirect("../" + M_Url);
                       
                    }
                    else
                    {
                        MessageBox.Show(this, "操作失败！");
                    }
                }
            }
            else
            {
                model = new UserInfo();
                model.US_Name = US_Name;
                if (US_Password_qr != US_Password)
                {
                    MessageBox.Show(this, "两次密码输入不同！");
                    return;
                }
                model.US_PassWord = MD5.MDString(US_Password);
                model.US_ServiceDepartment = US_ServiceDepartment;
                model.US_QQ = US_QQ;
                model.US_UnitName = US_UnitName;
                model.US_UserName = US_UserName;
                model.US_Email = US_Email;
                model.US_TelPhone = US_TelPhone;
                model.US_CardId = US_CardId;
                model.US_Sex = US_Sex;
                model.US_Authentication = "";
                model.US_Integral = 0;
                model.US_Birthday = US_Birthday;
                model.US_RegisterTime = DateTime.Now.ToShortDateString();
                model.US_WebsiteName = US_WebsiteName;
                if (US_WebsiteName == "请选择")
                {
                    MessageBox.Show(this, "必须选择网点号");
                    return;
                }
                if (UserInfoManage.GetInstance().ExistsByUserName(US_UserName))
                {
                    MessageBox.Show(this, "该用户名已经存在");
                    return;
                }
                if (US_Name.Trim() == "")
                {
                    MessageBox.Show(this, "用名不能为空！");
                    return;
                }
                bool result = UserInfoManage.GetInstance().Add(model);

                if (result)
                {
                    Response.Write("<script>alert('操作成功！');</script>");
               
               
                    this.US_Name.Value = "";
                    this.US_Password.Value = "";
                    this.US_UserName.Value = "";
                    this.US_Password_qr.Value = "";
                    this.US_Email.Value = "";
                    this.US_TelPhone.Value = "";
                    this.US_CardId.Text = "";
                }
                else
                {
                    MessageBox.Show(this, "操作失败！");
                }
            }
          
            //
           
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