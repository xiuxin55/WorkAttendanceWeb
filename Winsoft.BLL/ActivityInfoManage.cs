using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //CollectionInfo
    public partial class ActivityInfoManage
    {

        private readonly ActivityInfoService dal = new ActivityInfoService();
        private ActivityInfoManage()
        { }

        public static ActivityInfoManage GetInstance()
        {
            return new ActivityInfoManage();
        }

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ActivityInfo GetModel(string AC_Id, string AC_UserName)
        {
            return dal.GetModel(AC_Id, AC_UserName);
        }

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
        public bool Exists(string AC_Id)
        {
            return dal.Exists(AC_Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ActivityInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ActivityInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string AC_Id)
        {

            return dal.Delete(AC_Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ActivityInfo GetModel(string AC_Id)
        {

            return dal.GetModel(AC_Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ActivityInfo GetModelByCache(string AC_Id)
        {

            string CacheKey = "Activity-" + AC_Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(AC_Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ActivityInfo)objModel;
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
        public List<ActivityInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ActivityInfo> DataTableToList(DataTable dt)
        {
            List<ActivityInfo> modelList = new List<ActivityInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ActivityInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ActivityInfo();
                    model.AC_Id = Convert.ToInt32(dt.Rows[n]["AC_Id"].ToString());
                    model.AC_Name = dt.Rows[n]["AC_Name"].ToString();
                    model.AC_CityId = dt.Rows[n]["AC_CityId"].ToString();
                    model.AC_ProvinceId = dt.Rows[n]["AC_ProvinceId"].ToString();
                    model.AC_SDID = dt.Rows[n]["AC_SDID"].ToString();
                    model.AC_Authentication = dt.Rows[n]["AC_Authentication"].ToString();
                    model.AC_StartTime = Convert.ToDateTime(dt.Rows[n]["AC_StartTime"].ToString());
                    model.AC_LastTime = Convert.ToDateTime(dt.Rows[n]["AC_LastTime"].ToString());
                    model.AC_Time = dt.Rows[n]["AC_Time"].ToString();
                    model.AC_flag = Convert.ToInt32(dt.Rows[n]["AC_flag"].ToString());
                    model.AC_UserName = dt.Rows[n]["AC_UserName"].ToString();


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