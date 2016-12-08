using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    /// <summary>
    /// 积分表
    /// </summary>
    public class IntegralInfo
    {

        public int IN_Id { get; set; }
        public string IN_SDID { get; set; }
        public string IN_UserID { get; set; }
        public int IN_Sores { get; set; }
        public DateTime IN_Time { get; set; }
        public int IN_Count { get; set; }
        public string IN_ModelScoerID { get; set; }
        public string IN_Authentication { get; set; }
    }
}