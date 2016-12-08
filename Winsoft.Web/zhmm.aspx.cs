using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web
{
    public partial class zhmm : System.Web.UI.Page
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

            if (M_Username == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入会员帐号！')", true);
            }
            else
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModelByUserName(M_Username);

                if (model != null)
                {
                    if (model.M_EMail == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('您的邮箱不存在！')", true);
                    }
                    else
                    {
                        string M_Password = StringUtil.StrRandom(10, false);
                        model.M_Password = MD5.MDString(M_Password);
                        bool result = PrizeInfoManage.GetInstance().Update(model);

                        if (result)
                        {
                            this.M_Uid.Value = "";
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('" + JmailTo(model.M_EMail, model.M_Username, M_Password, "3", "", "") + "')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('邮件发送失败！')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('该会员不存在！')", true);
                }
            }
        }

        #endregion

        #region 邮件发送

        public static string JmailTo(string tomail, string name, string pass, string type, string filepass, string contents)
        {
            string bodystr = "您好：</br>" + contents + "";//
            bodystr = "您好：" + name + "<br />您的动态密码是：" + pass + "<br />请不要把密码发给别人！<br />此邮件由系统发出，请勿未回复。<br />邮件只用于发送动态密码，如有邮件声称官方人员，请勿相信！<br />";
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
                return "邮件发送成功请查收！";
            }
            else
            {
                jmail.Close();
                return "邮件发送失败！";
            }
        }

        #endregion
    }
}