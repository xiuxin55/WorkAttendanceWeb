using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;
using System.Xml;
using System.Text;

namespace Winsoft.Web
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetVidoLiveByXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement nodempeglist = doc.CreateElement("mpeglist"); //创建一个mpeglist节点
            doc.AppendChild(nodempeglist);

            try
            {
                DateTime date = DateTime.Today;

                string strWhere = " VL_LiveSTime between '" + date.ToString("yyyy-MM-dd") + " 00:00:00' and '" + date.ToString("yyyy-MM-dd") + " 23:59:59' order by VL_LiveSTime";
                List<IntegralInfo> list = IntegralInfoManage.GetInstance().GetModelList(strWhere);

                if (list != null && list.Count > 0)
                {
                    foreach (IntegralInfo item in list)
                    {
                        XmlElement nodedata = doc.CreateElement("data");//创建节点mpeglist子节点data
                        nodempeglist.AppendChild(nodedata);

                        XmlElement nodefilepath = doc.CreateElement("filepath");//创建节点data子节点filepath
                        //nodefilepath.InnerText = StringUtil.Wbsserviceadd(item.VL_Vido);
                        nodedata.AppendChild(nodefilepath);

                        XmlElement nodeplaytime = doc.CreateElement("playtime");//创建节点data子节点playtime
                        //nodeplaytime.InnerText = item.VL_LiveSTime.ToString("HH:mm:ss");
                        nodedata.AppendChild(nodeplaytime);
                    }

                    return doc.InnerXml;
                }
            }
            catch (Exception)
            {
                return doc.InnerXml;
            }
            return doc.InnerXml;
        }

    }
}
