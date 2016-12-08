using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Winsoft.Model{
	 	
    /// <summary>
    /// 用户属性
    /// </summary>
    public class UserInfo
	{
        /// <summary>
        /// 用户id
        /// </summary>
        public int US_UserId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string US_UserName { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string US_PassWord { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string US_Sex { get; set; }
        /// <summary>
        /// 用户出生日期
        /// </summary>
        public string US_Birthday { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string US_Name { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string US_TelPhone { get; set; }
        /// <summary>
        /// 用户Email
        /// </summary>
        public string US_Email { get; set; }
        /// <summary>
        /// 用户qq
        /// </summary>
        public string US_QQ { get; set; }
        /// <summary>
        /// 用户单位名称
        /// </summary>
        public string US_UnitName { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        public int US_Integral { get; set; }
        /// <summary>
        /// 用户所属区域
        /// </summary>
        public string US_ServiceDepartment { get; set; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        public string US_RegisterTime { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public string US_Authentication { get; set; }
        /// <summary>
        /// 用户是否被禁用
        /// </summary>
        public int US_Flag { get; set; }
        /// <summary>
        /// 用户最后登录时间
        /// </summary>
        public string US_LastLoginTime { get; set; }
        /// <summary>
        /// 用户最后推出时间
        /// </summary>
        public string US_LastQuitTime { get; set; }
        /// <summary>
        /// 用户所属省
        /// </summary>
        public string US_ProvinceId { get; set; }
        /// <summary>
        /// 用户所属市
        /// </summary>
        public string US_CityId { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string US_CardId { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string US_str { get; set; }
        /// <summary>
        /// 网点名
        /// </summary>
        public string US_WebsiteName { get; set; }
        ///// <summary>
        ///// 是否市行
        ///// </summary>
        //public string US_WebsiteName { get; set; }
	}
}