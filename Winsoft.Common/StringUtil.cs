using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Winsoft.Common
{
    public static class StringUtil
    {
        public static readonly string HttpPathStr = ConfigurationManager.AppSettings["httpPathStr"];
        //public static readonly string Wbsserviceadd = ConfigurationManager.AppSettings["Wbsserviceadd"];
        public static string StrIn(string str)
        {
            if (str == "")
            {
                return "";
            }
            string[] strs = str.Split(',');
            string newstr = "'0',";

            for (int i = 0; i < strs.Length; i++)
            {
                newstr += "'" + strs[i] + "',";
            }
            return newstr.TrimEnd(',');
        }

        /// <summary>
        /// 带域名的文件链接
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStrUrl(string str)
        {
            string httpPathStr = System.Configuration.ConfigurationManager.AppSettings["httpPathStr"];
            return httpPathStr + str.Replace("~", "");
        }

        public static string Wbsserviceadd(string str)
        {
            string httpPathStr = System.Configuration.ConfigurationManager.AppSettings["Wbsserviceadd"];
            return httpPathStr + str.Replace("~", "");
        }

        /// <summary>
        /// 根据空格分隔字符串
        /// </summary>
        public static string GetStrs(string str, string fdlName)
        {
            string s = "";
            int j = 0;
            if (str != null && str != string.Empty)
            {
                string[] strs = str.Split(' ');
                if (strs != null && strs.Length > 0)
                {
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] != "")
                        {
                            if (j != 0)
                            {
                                s += " or ";
                            }
                            s += fdlName + " like '%" + strs[i] + "%'";
                            j++;
                        }
                    }
                }
            }
            if (s == "")
            {
                s += fdlName + " like '%%'";
            }
            return s;
        }

        ///   <summary>   
        ///   去除HTML标记   
        ///   </summary>   
        ///   <param   name="NoHTML">包括HTML的源码   </param>   
        ///   <returns>已经去除后的文字</returns>   
        public static string GetNoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return System.Text.RegularExpressions.Regex.Replace(Htmlstring, "<[^>]*>", "");
        }

        /// <summary>
        /// 获取视频时长
        /// </summary>
        /// <param name="fileName">视频路径</param>
        /// <returns>时间长度</returns>
        public static string GetVidoLength(string fileName)
        {
            string duration = "";
            using (System.Diagnostics.Process pro = new System.Diagnostics.Process())
            {
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.ErrorDialog = false;
                pro.StartInfo.RedirectStandardError = true;

                pro.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg/ffmpeg.exe";
                pro.StartInfo.Arguments = " -i " + fileName;

                pro.Start();
                System.IO.StreamReader errorreader = pro.StandardError;
                pro.WaitForExit(1000);

                string result = errorreader.ReadToEnd();
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
                    duration = result;
                }

            }
            return duration;
        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="strFileName">视频路径</param>
        /// <param name="strOldFileName">服务器旧视频路径</param>
        /// <param name="strNewFileName">服务器新视频路径</param>
        public static void UploadVido(string strFileName, string strOldFileName,string strNewFileName)
        {
            FTPClientService fs = new FTPClientService();
            fs.RemoteHost = "127.0.0.1";
            fs.RemoteUser = "mydlw";
            fs.RemotePass = "dlw123!@#qaz";
            fs.RemotePath = "";
            fs.Put(strFileName);
            fs.Rename(strOldFileName, strNewFileName);
            fs.DisConnect();
        }

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="strFileName">视频路劲</param>
        public static void DeleteVido(string strFileName)
        {
            FTPClientService fs = new FTPClientService();
            fs.RemoteHost = "127.0.0.1";
            fs.RemoteUser = "mydlw";
            fs.RemotePass = "dlw123!@#qaz";
            fs.RemotePath = "";
            fs.Delete(strFileName);
            fs.DisConnect();
        }

        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public static string StrRandom(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
    }
}
