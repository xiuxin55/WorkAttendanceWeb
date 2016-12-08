using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Winsoft.BLL;
using Winsoft.Common;
using System.Data;
using Winsoft.Model;
using System.Web.UI.WebControls;

namespace Winsoft.Web.Ajax
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AjaxService
    {
        // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
        // 要创建返回 XML 的操作，
        //     请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        //     并在操作正文中包括以下行:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ID"></param>
        [OperationContract]
        public string  DeleteUserTableDataRow(string ID)
        {
            // 在此处添加操作实现
            if (UserInfoManage.GetInstance().Delete(ID))
            {
                return "用户删除成功！";
            }
            else
            {
                return "用户删除失败！";
            }
        }
        /// <summary>
        /// 删除网点
        /// </summary>
        /// <param name="ID"></param>
        [OperationContract]
        public string DeleteWebsiteTableDataRow(string ID)
        {
            // 在此处添加操作实现
            if (WebsiteManage.GetInstance().Delete(ID))
            {
                return "网点删除成功";
            }


            return "网点删除失败";
        }

        
        /// <summary>
        /// 删除兑奖记录
        /// </summary>
        /// <param name="ID"></param>
        [OperationContract]
        public string  DeleteDJDataRow(string ID)
        {
            // 在此处添加操作实现
            if (PrizeExchangeInfoManage.GetInstance().Delete(ID))
            {
                return "未兑奖记录删除成功";
            }

            return "未兑奖记录删除失败";
        }

        /// <summary>
        /// 已兑奖记录作废还原
        /// </summary>
        /// <param name="ID"></param>
        [OperationContract]
        public string RefundDJDataRow(string ID)
        {
            // 在此处添加操作实现
            if (PrizeExchangeInfoManage.GetInstance().Update(ID))
            {
                return "作废成功";
            }

            return "作废失败";
        }
        // 在此处添加更多操作并使用 [OperationContract] 标记它们
        [OperationContract]
        public string DeletePrizeTableDataRow(string ID)
        {
            // 在此处添加操作实现
            if (PrizeInfoManage.GetInstance().Delete(ID))
            {
                return "删除成功";
            }

            return "删除失败";
        }
        
        
    }
}
