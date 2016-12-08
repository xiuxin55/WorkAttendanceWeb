using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winsoft.Web.admin.ImageCode
{
    public class MenuInfo
    {
        public MenuInfo() { }
        public int M_ID { get; set; }
        public string M_Name { get; set; }
        public string M_Url { get; set; }
        public int M_PID { get; set; }
    }
}