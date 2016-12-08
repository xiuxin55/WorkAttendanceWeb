using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //VidoLiveInfo
    public partial class IntegralInfoManage
    {

        private readonly IntegralInfoService dal = new IntegralInfoService();
        private IntegralInfoManage()
        { }

        public static IntegralInfoManage GetInstance()
        {
            return new IntegralInfoManage();
        }

        #region 自定义方法



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
        public bool Exists(string IN_Id)
        {
            return dal.Exists(IN_Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(IntegralInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IntegralInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IN_Id)
        {

            return dal.Delete(IN_Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IntegralInfo GetModel(string IN_Id)
        {

            return dal.GetModel(IN_Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public IntegralInfo GetModelByCache(string IN_Id)
        {

            string CacheKey = "IntegralModel-" + IN_Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IN_Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (IntegralInfo)objModel;
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
        public List<IntegralInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<IntegralInfo> DataTableToList(DataTable dt)
        {
            List<IntegralInfo> modelList = new List<IntegralInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                IntegralInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new IntegralInfo();
                    model.IN_Id = Convert.ToInt32(dt.Rows[n]["IN_Id"].ToString());
                    model.IN_SDID = dt.Rows[n]["IN_SDID"].ToString();
                    model.IN_UserID = dt.Rows[n]["IN_UserID"].ToString();
                    model.IN_Sores = Convert.ToInt32(dt.Rows[n]["IN_Sores"].ToString());
                    if (dt.Rows[n]["IN_Time"].ToString() != "")
                    {
                        model.IN_Time = DateTime.Parse(dt.Rows[n]["IN_Time"].ToString());
                    }
                    model.IN_Count = Convert.ToInt32(dt.Rows[n]["IN_Count"].ToString());
                    model.IN_ModelScoerID = dt.Rows[n]["IN_ModelScoerID"].ToString();
                    model.IN_Authentication = dt.Rows[n]["IN_Authentication"].ToString();


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