using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //VidoHistoryInfo
    public partial class ProvinceInfoManage
    {

        private readonly ProvinceInfoService dal = new ProvinceInfoService();
        private ProvinceInfoManage()
        { }

        public static ProvinceInfoManage GetInstance()
        {
            return new ProvinceInfoManage();
        }

        #region 自定义方法

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public ProvinceInfo GetModel(string V_ID, string VH_IP)
        //{
        //    return dal.GetModel(V_ID, VH_IP);
        //}

        #endregion

        #region  Method

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
        public bool Exists(string PV_ProvinceID)
        {
            return dal.Exists(PV_ProvinceID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ProvinceInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProvinceInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PV_ProvinceID)
        {

            return dal.Delete(PV_ProvinceID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProvinceInfo GetModel(string PV_ProvinceID)
        {

            return dal.GetModel(PV_ProvinceID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ProvinceInfo GetModelByCache(string PV_ProvinceID)
        {

            string CacheKey = "ProvinceModel-" + PV_ProvinceID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PV_ProvinceID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ProvinceInfo)objModel;
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
        public List<ProvinceInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ProvinceInfo> DataTableToList(DataTable dt)
        {
            List<ProvinceInfo> modelList = new List<ProvinceInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ProvinceInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ProvinceInfo();
                    model.PV_ProvinceID = dt.Rows[n]["PV_ProvinceID"].ToString();
                    model.PV_ProvinceName = dt.Rows[n]["PV_ProvinceID"].ToString();

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