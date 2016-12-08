using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.Common;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web
{
    public partial class hydl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 数据处理

        /// <summary>
        /// 会员登录
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            string M_Username = this.M_Uid.Value.Trim();
            string M_Password = this.M_Pwd.Value.Trim();

            if (M_Username == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入会员帐号！')", true);
            }
            else if (M_Password == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入会员密码！')", true);
            }
            else
            {
                bool result = PrizeInfoManage.GetInstance().Login(M_Username, MD5.MDString(M_Password));

                if (result)
                {
                    PrizeInfo model = PrizeInfoManage.GetInstance().GetModelByUserName(M_Username);
                    if (model.M_IsVerify != "是")
                    {
                        string M_VerificationCode = DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString();
                        model.M_VerificationCode = MD5.MDString(M_VerificationCode);

                        if (PrizeInfoManage.GetInstance().Update(model))
                        {
                            if (JmailTo(model.M_EMail, model.M_Username, model.M_Password, "3", "", "", model))
                            {
                                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "window.location.href='cxyz.aspx?id=" + model.M_ID + "';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('邮件发送失败！')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('验证码更新失败！')", true);
                        } 
                    }
                    else
                    {
                        Session["myuser"] = model;
                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('帐号或密码错误！')", true);
                }
            }
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