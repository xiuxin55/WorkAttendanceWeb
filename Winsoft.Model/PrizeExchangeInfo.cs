using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    /// <summary>
    /// 奖品兑换表
    /// </summary>
    public class PrizeExchangeInfo
    {
        /// <summary>
        /// guid
        /// </summary>
        public string Prize_Guid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Prize_user { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Prize_CardNum { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Prize_IdentifyCard { get; set; }
        /// <summary>
        /// 可兑换奖品名
        /// </summary>
        public string Prize_Name { get; set; }
        /// <summary>
        /// 是否兑奖 0已经兑奖 1未兑奖
        /// </summary>
        public string Prize_Flag { get; set; }
        /// <summary>
        /// 领取人姓名
        /// </summary>
        public string Prize_GetUserName { get; set; }
        /// <summary>
        /// 领取人联系方式
        /// </summary>
        public string Prize_GetUserContact { get; set; }
        /// <summary>
        /// 领取人身份证号
        /// </summary>
        public string Prize_GetUserIdentifyCard { get; set; }
        
        /// <summary>
        /// 已兑换奖品名称
        /// </summary>
        public string Prize_GetPrizeName { get; set; }
        /// <summary>
        /// 兑奖日期
        /// </summary>
        public string Pize_GetPrizeDateTime { get; set; }
        /// <summary>
        /// 兑奖时间
        /// </summary>
        public string Pize_GetPrizeTime { get; set; }
        public string Pize_PrizeID { get; set; }
        
        /// <summary>
        /// 操作网点号
        /// </summary>
        public string Pize_WebsiteNum { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string Pize_UserNum { get; set; }
        /// <summary>
        /// 推广机构名称
        /// </summary>
        public string Pize_PushCom { get; set; }
        /// <summary>
        /// 推广机构号
        /// </summary>
        public string Pize_PushComNum { get; set; }
        /// <summary>
        /// 推广人员姓名
        /// </summary>
        public string Pize_PushPerson { get; set; }
        /// <summary>
        /// 推广人编号
        /// </summary>
        public string Pize_PushPersonNum { get; set; }


    }
}