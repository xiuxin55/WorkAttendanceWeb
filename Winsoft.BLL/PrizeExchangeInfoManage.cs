using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //VidoTypeInfo
    public partial class PrizeExchangeInfoManage
    {

        private readonly PrizeExchangeInfoService dal = new PrizeExchangeInfoService();
        private PrizeExchangeInfoManage()
        { }

        public static PrizeExchangeInfoManage GetInstance()
        {
            return new PrizeExchangeInfoManage();
        }

        #region 自定义方法



        #endregion

        #region  Method
        public DataTable GetPrizeNameList(string WebsiteID)
        {
            return dal.GetPrizeNameList(WebsiteID);
        }
        public bool UpdatePrizeCount(PrizeAllocateModel p, PrizeExchangeInfo ModelData, int i)
        {
            return dal.UpdatePrizeCount(p, ModelData,i);
        }
        ///// <summary>
        ///// 分页查询
        ///// </summary>
        //public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        //{
        //    return dal.GetPageList(pageSize, pageIndex, strWhere, fdlOrder, isCount);
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string guid)
        {
            return dal.Exists(guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(PrizeExchangeInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PrizeExchangeInfo model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 根据id更新一条数据
        /// </summary>
        public bool Update(string  id)
        {
            return dal.UpdateRow(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string guid)
        {

            return dal.Delete(guid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PrizeExchangeInfo GetModel(string guid)
        {

            return dal.GetModel(guid);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public PrizeExchangeInfo GetModelByCache(string PZ_Id)
        //{

        //    string CacheKey = "PrizeExchangeInfoModel-" + PZ_Id;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(PZ_Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (PrizeExchangeInfo)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得已兑奖数据列表
        /// </summary>
        public DataSet GetListYDJ(string strWhere)
        {
            return dal.GetListYDJ(strWhere);
        }
        /// <summary>
        /// 获得未兑奖数据列表
        /// </summary>
        public DataSet GetListWDJ(string strWhere)
        {
            return dal.GetListWDJ(strWhere);
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
        public List<PrizeExchangeInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PrizeExchangeInfo> DataTableToList(DataTable dt)
        {
            List<PrizeExchangeInfo> modelList = new List<PrizeExchangeInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PrizeExchangeInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PrizeExchangeInfo();
                    model.Prize_Guid = dt.Rows[n]["Prize_Guid"].ToString();

                    model.Prize_user = dt.Rows[n]["Prize_user"].ToString();
                    model.Prize_CardNum =dt.Rows[n]["Prize_CardNum"].ToString();
                    model.Prize_IdentifyCard =dt.Rows[n]["Prize_IdentifyCard"].ToString();
                    model.Prize_Name = dt.Rows[n]["Prize_Name"].ToString();
                    model.Prize_Flag =dt.Rows[n]["Prize_Flag"].ToString();
                    model.Prize_GetUserName = dt.Rows[n]["Prize_GetUserName"].ToString();
                    model.Prize_GetUserContact = dt.Rows[n]["Prize_GetUserContact"].ToString();
                    model.Prize_GetUserIdentifyCard = dt.Rows[n]["Prize_GetUserIdentifyCard"].ToString();
                    model.Prize_GetPrizeName = dt.Rows[n]["Prize_GetPrizeName"].ToString();
                    model.Pize_GetPrizeDateTime =dt.Rows[n]["Pize_GetPrizeDateTime"].ToString();

                    model.Pize_GetPrizeTime = dt.Rows[n]["Pize_GetPrizeTime"].ToString();
                    model.Pize_PushCom = dt.Rows[n]["Pize_PushCom"].ToString();
                    model.Pize_PushComNum = dt.Rows[n]["Pize_PushComNum"].ToString();
                    model.Pize_PushPerson = dt.Rows[n]["Pize_PushPerson"].ToString();
                    model.Pize_PushPersonNum = dt.Rows[n]["Pize_PushPersonNum"].ToString();
                    model.Pize_PrizeID = dt.Rows[n]["Pize_PrizeID"].ToString();
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