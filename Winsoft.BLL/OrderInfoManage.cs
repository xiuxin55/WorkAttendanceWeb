using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //OrderInfo
    public partial class OrderInfoManage
    {

        private readonly OrderInfoService dal = new OrderInfoService();
        private OrderInfoManage()
        { }

        public static OrderInfoManage GetInstance()
        {
            return new OrderInfoManage();
        }

        #region 自定义方法

        /// <summary>
        ///  视频销售统计
        /// </summary>
        public DataTable GetPageGroupVCount(string strWhere)
        {
            return dal.GetPageGroupVCount(strWhere);
        }

        /// <summary>
        ///  会员销售统计
        /// </summary>
        public DataTable GetPageGroupMCount(string strWhere)
        {
            return dal.GetPageGroupMCount(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModel(string V_ID, string M_ID)
        {
            return dal.GetModel(V_ID, M_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModelByOrder(string O_Order)
        {
            return dal.GetModelByOrder(O_Order);
        }

        #endregion

        #region  Method

        /// <summary>
        /// 分页查询
        /// </summary>
        public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        {
            return dal.GetPageList(pageSize, pageIndex, strWhere, fdlOrder, isCount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string O_ID)
        {
            return dal.Exists(O_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(OrderInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OrderInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string O_ID)
        {

            return dal.Delete(O_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModel(string O_ID)
        {

            return dal.GetModel(O_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public OrderInfo GetModelByCache(string O_ID)
        {

            string CacheKey = "OrderInfoModel-" + O_ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(O_ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (OrderInfo)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OrderInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OrderInfo> DataTableToList(DataTable dt)
        {
            List<OrderInfo> modelList = new List<OrderInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OrderInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OrderInfo();
                    model.O_ID = dt.Rows[n]["O_ID"].ToString();
                    if (dt.Rows[n]["O_Time"].ToString() != "")
                    {
                        model.O_Time = DateTime.Parse(dt.Rows[n]["O_Time"].ToString());
                    }
                    model.V_ID = dt.Rows[n]["V_ID"].ToString();
                    model.M_ID = dt.Rows[n]["M_ID"].ToString();
                    model.O_Serial = dt.Rows[n]["O_Serial"].ToString();
                    model.O_Order = dt.Rows[n]["O_Order"].ToString();
                    if (dt.Rows[n]["O_Price"].ToString() != "")
                    {
                        model.O_Price = decimal.Parse(dt.Rows[n]["O_Price"].ToString());
                    }
                    model.O_Status = dt.Rows[n]["O_Status"].ToString();
                    model.O_NextTime = dt.Rows[n]["O_NextTime"].ToString();
                    model.O_PaymentTime = dt.Rows[n]["O_PaymentTime"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}