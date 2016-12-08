using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsoft.Model
{
   public  class WebSiteModel
    {
       /// <summary>
       /// 网点号
       /// </summary>
       public string WebsiteID { get; set; }
       /// <summary>
       /// 网点名
       /// </summary>
       public string WebsiteName { get; set; }
       /// <summary>
       /// 状态
       /// </summary>
       public string WebsiteFlag { get; set; }
       /// <summary>
       /// 状态 0市行 1网点
       /// </summary>
       public string WebsiteType{ get; set; }
    }
}
