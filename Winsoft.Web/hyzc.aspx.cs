using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Common;
using System.Text.RegularExpressions;
using System.Data;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web
{
    public partial class hyzc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
                IsRead();
            }
        }

        #region 数据加载

        /// <summary>
        /// 是否允许注册
        /// </summary>
        private void IsRead()
        {
            bool isRead = this.M_Read.Checked;

            if (isRead)
            {
                this.btnCommit.Enabled = true;
            }
            else
            {
                this.btnCommit.Enabled = false;
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            DataTable dtList = null;
            string fldOrder = "";//排序字段名
            string strWhere = "";//查询条件

            #region 注册协议

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='002003002'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rtZcxy.DataSource = dtList;
            this.rtZcxy.DataBind();

            #endregion
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 会员注册
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            string regex_email = @"^\w+@\w+(\.\w+)+(\,\w+@\w+(\.\w+)+)*$";

            string M_EMail = this.M_EMail.Value.Trim();
            string M_Username = this.M_Username.Value.Trim();
            string M_Password = this.M_Password.Value.Trim();
            string M_RPassword = this.M_RPassword.Value.Trim();
            string M_VerificationCode = DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString();

            if (M_EMail == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入电子邮箱！')", true);
            }
            else if (M_Username == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入会员帐号！')", true);
            }
            else if (M_Password == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入会员密码！')", true);
            }
            else if (M_RPassword == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入确认密码！')", true);
            }
            else if (!Regex.IsMatch(M_EMail, regex_email))
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('电子邮箱格式不正确！')", true);
            }
            else if (M_Password != M_RPassword)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('两次输入的密码不一致！')", true);
            }
            else
            {
                DataTable dtEMail = PrizeInfoManage.GetInstance().GetList(" M_EMail='" + M_EMail + "'").Tables[0];
                DataTable dtUsername = PrizeInfoManage.GetInstance().GetList(" M_Username='" + M_Username + "'").Tables[0];

                if (dtEMail != null && dtEMail.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('该电子邮箱已存在！')", true);
                }
                else if (dtUsername != null && dtUsername.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('该会员帐号已存在！')", true);
                }
                else
                {
                    PrizeInfo model = new PrizeInfo();
                    model.M_ID = Guid.NewGuid().ToString();
                    model.M_EMail = M_EMail;
                    model.M_Username = M_Username;
                    model.M_Password = MD5.MDString(M_Password);
                    model.M_Name = "";
                    model.M_Nickname = M_Username;
                    model.M_Img = "~/images/5546.png";
                    model.M_Sex = "保密";
                    model.M_Tel = "";
                    model.M_Address = "";
                    model.M_Like = "";
                    model.M_About = "";
                    model.M_Points = 0;
                    model.M_Time = DateTime.Now;
                    model.M_IsVerify = "否";
                    model.M_VerificationCode = MD5.MDString(M_VerificationCode);

                    PrizeInfoManage.GetInstance().Add(model);

                    if (JmailTo(model.M_EMail, model.M_Username, model.M_Password, "3", "", "", model))
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "window.location.href='zccg.aspx?id=" + model.M_ID + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('邮件发送失败！')", true);
                    }
                }
            }
        }

        /// <summary>
        /// 不同意逗留网相关条款禁止注册
        /// </summary>
        protected void M_Read_CheckedChanged(object sender, EventArgs e)
        {
            IsRead();
        }

        #endregion

        #region 邮件发送

        public static bool JmailTo(string tomail, string name, string pass, string type, string filepass, string contents, PrizeInfo model)
        {
            string httpPathStr = System.Configuration.ConfigurationManager.AppSettings["httpPathStr"];
            string bodystr = "您好：</br>" + contents + "";//
            bodystr = "亲爱的" + name + ":<br />您好！感谢您注册逗留网账号，点击下面的链接即可绑定邮箱：<br/>" + httpPathStr + "/jhyx.aspx?id=" + MD5.MDString(model.M_Username) + "&yzm=" + model.M_VerificationCode + "<br />如果以上链接无法点击，请将上面的地址复制到你的浏览器(如IE)的地址栏进入逗留网。<br />此邮件由系统发出，请勿未回复。<br />";
            jmail.Message jmail = new jmail.Message();

            //DateTime t = DateTime.Now;
            string subject = "逗留网提醒您！";
            string fromemail = "dlw888666@163.com";
            string toEmail = tomail;
            //silent属性：如果设置为true,jmail不会抛出例外错误. jmail. send( () 会根据操作结果返回true或false
            jmail.Silent = true;
            //jmail创建的日志，前提loging属性设置为true
            jmail.Logging = true;
            //字符集，缺省为"us-ascii"
            jmail.Charset = "gb2312";
            //信件的contentype. 缺省是"text/plain"） : 字符串如果你以html格式发送邮件, 改为"text/html"即可。
            jmail.Encoding = "Base64"; //设置附件默认编码 
            jmail.ISOEncodeHeaders = false; //邮件头是否使用iso-8859-1编码 
            //添加收件人
            jmail.AddRecipient(toEmail, "", "");
            jmail.From = fromemail;
            //发件人邮件用户名
            jmail.MailServerUserName = "dlw888666";
            //发件人邮件密码
            jmail.MailServerPassWord = "dlw888^^^";
            //设置邮件标题
            jmail.Subject = subject;
            jmail.ContentType = "text/html";
            if (type == "2")
            {
                //邮件添加附件,(多附件的话，可以再加一条jmail.addattachment( "c:\\test.jpg",true,null);)就可以搞定了。［注］：加了附件，讲把上面的jmail.contenttype="text/html";删掉。否则会在邮件里出现乱码。
                jmail.AddAttachment(filepass, true, null);
            }
            //邮件内容
            jmail.Body = bodystr;
            //jmail发送的方法
            if (jmail.Send("smtp.163.com", false))
            {
                jmail.Close();
                return true;
            }
            else
            {
                jmail.Close();
                return false;
            }
        }

        #endregion
    }
}