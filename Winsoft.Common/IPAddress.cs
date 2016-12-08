using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Winsoft.Common
{
    public class IPAddress
    {
        #region 方法一，经测试有问题

        /// <summary>          
        /// 得到真实IP以及所在地详细信息（Porschev）          
        /// </summary>          
        /// <returns></returns>          
        public static string GetIpDetails()
        {
            string url = "http://www.ip138.com/ips8.asp";   //设置获取IP地址和国家源码的网址           
            string regStr = "(?<=<td\\s*align=\\\"center\\\">)[^<]*?(?=<br/><br/></td>)";
            string ipRegStr = "((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)";    //IP正则                     
            string ip = string.Empty;   //IP地址              
            string country = string.Empty;  //国家              
            string adr = string.Empty;   //省市              
            string html = GetHtml(url);       //得到网页源码              
            Regex reg = new Regex(regStr, RegexOptions.None);
            Match ma = reg.Match(html); html = ma.Value;
            Regex ipReg = new Regex(ipRegStr, RegexOptions.None);
            ma = ipReg.Match(html);
            ip = ma.Value;     //得到IP              
            int index = html.LastIndexOf("：") + 1;
            country = html.Substring(index);                   //得到国家              
            adr = GetAdrByIp(ip);
            return "IP：" + ip + "  国家：" + country + "  省市：" + adr;
        }
        /// <summary>          
        /// 通过IP得到IP所在地省市（Porschev）          
        /// </summary>          
        /// <param name="ip"></param>          
        /// <returns></returns>          
        public static string GetAdrByIp(string ip)
        {
            string url = "http://www.cz88.net/ip/?ip=" + ip;
            string regStr = "(?<=<span\\s*id=\\\"cz_addr\\\">).*?(?=</span>)";
            string html = GetHtml(url);       //得到网页源码              
            Regex reg = new Regex(regStr, RegexOptions.None);
            Match ma = reg.Match(html);
            html = ma.Value;
            string[] arr = html.Split(' ');
            return arr[0];
        }


        /// <summary>          
        /// 获取HTML源码信息(Porschev)          
        /// </summary>          
        /// <param name="url">获取地址</param>          
        /// <returns>HTML源码</returns>          
        public static string GetHtml(string url)
        {
            string str = "";
            try
            {
                Uri uri = new Uri(url);
                WebRequest wr = WebRequest.Create(uri);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                str = sr.ReadToEnd();
            }
            catch (Exception e)
            {
            }
            return str;
        }

        #endregion

        #region 方法二


        /// <summary>
        /// 根据IP地址获取城市信息。（返回一个数组，0为ip，1为省份，2为市，3为县,4为所在地区以及网络）
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        public static string[] GetNetwork2(string ip)
        {
            string url = "http://whois.pconline.com.cn/ipJson.jsp";
            //string url = "http://counter.sina.com.cn/ip";
            string query = "ip=" + ip;
            url += "?ip=" + ip;
            string text = GetResponseText(url, query);
            text = text.Replace("\"", string.Empty);
            string wenben = text.Replace("ip:", string.Empty).Replace("pro:", string.Empty).Replace("city:", string.Empty).Replace("region:", string.Empty).Replace("addr:", string.Empty).Replace("\n", string.Empty);
            wenben = wenben.Replace("if(window.IPCallBack) {IPCallBack({", string.Empty).Replace(",regionNames:});}", string.Empty);
            string[] address = wenben.Split(',');
            return address;

        }

        /// <summary>
        /// 获取响应的数据流。
        /// </summary>
        /// <returns></returns>
        public static Stream GetResponseStream(string API_URL, string query)
        {

            var data = Encoding.UTF8.GetBytes(query);

            var request = (HttpWebRequest)WebRequest.Create(API_URL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
                stream.Write(data, 0, data.Length);

            return request.GetResponse().GetResponseStream();
        }

        /// <summary>
        /// 获取响应的文本。
        /// </summary>
        /// <returns></returns>
        public static string GetResponseText(string API_URL, string query)
        {
            var text = string.Empty;

            using (var reader = new StreamReader(GetResponseStream(API_URL, query), Encoding.Default))
                text = reader.ReadToEnd();

            return text;
        }

        #endregion

    }
}
