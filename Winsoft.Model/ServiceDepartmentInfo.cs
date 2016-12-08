using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    /// <summary>
    /// 区域权限表
    /// </summary>
    public class ServiceDepartmentInfo
    {

        public int SD_Id { get; set; }
        public string SD_Name { get; set; }
        public int SD_SDID { get; set; }
        public DateTime SD_Time { get; set; }
        public string SD_UserID { get; set; }
        public string SD_CityID { get; set; }
        public string SD_ProvinceId { get; set; }
        public int SD_Flag { get; set; }
        public int SD_Mark { get; set; }
    }
}