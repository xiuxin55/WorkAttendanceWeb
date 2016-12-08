using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    /// <summary>
    /// 活动表
    /// </summary>
    public class ActivityInfo
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int AC_Id { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string AC_Name { get; set; }
        /// <summary>
        /// 活动所在市
        /// </summary>
        public string AC_CityId { get; set; }
        /// <summary>
        /// 活动所在省
        /// </summary>
        public string AC_ProvinceId { get; set; }
        /// <summary>
        /// 活动的区域权限id
        /// </summary>
        public string AC_SDID { get; set; }
        /// <summary>
        /// 活动的权限
        /// </summary>
        public string AC_Authentication { get; set; }
        /// <summary>
        /// 活动的开始时间
        /// </summary>
        public DateTime AC_StartTime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime AC_LastTime { get; set; }
        /// <summary>
        /// 活动时长
        /// </summary>
        public string AC_Time { get; set; }
        /// <summary>
        /// 活动当前是否可用或显示
        /// </summary>
        public int AC_flag { get; set; }
        /// <summary>
        /// 活动发起人
        /// </summary>
        public string AC_UserName { get; set; }

    }
}