using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //CommentInfo
    public partial class ServiceDepartmentInfoManage
    {

        private readonly ServiceDepartmentInfoService dal = new ServiceDepartmentInfoService();
        private ServiceDepartmentInfoManage()
        { }

        public static ServiceDepartmentInfoManage GetInstance()
        {
            return new ServiceDepartmentInfoManage();
        }

        #region 自定义方法



        #endregion

        #region  Method

        /// <summary>
        /// 分页查询
        /// </summary>
        //public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        //{
        //    return dal.GetPageList(pageSize, pageIndex, strWhere, fdlOrder, isCount);
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SD_Id)
        {
            return dal.Exists(SD_Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ServiceDepartmentInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ServiceDepartmentInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SD_Id)
        {

            return dal.Delete(SD_Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ServiceDepartmentInfo GetModel(string SD_Id)
        {

            return dal.GetModel(SD_Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ServiceDepartmentInfo GetModelByCache(string SD_Id)
        {

            string CacheKey = "ServiceDepartment-" + SD_Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SD_Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ServiceDepartmentInfo)objModel;
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
        public List<ServiceDepartmentInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ServiceDepartmentInfo> DataTableToList(DataTable dt)
        {
            List<ServiceDepartmentInfo> modelList = new List<ServiceDepartmentInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ServiceDepartmentInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ServiceDepartmentInfo();
                    model.SD_Id = Convert.ToInt32(dt.Rows[n]["SD_Id"].ToString());
                    model.SD_Name = dt.Rows[n]["SD_Name"].ToString();
                    model.SD_SDID = Convert.ToInt32(dt.Rows[n]["SD_SDID"].ToString());
                    if (dt.Rows[n]["SD_Time"].ToString() != "")
                    {
                        model.SD_Time = Convert.ToDateTime(dt.Rows[n]["SD_Time"].ToString());                    
                    }
                    model.SD_UserID = dt.Rows[n]["SD_UserID"].ToString();
                    model.SD_CityID = dt.Rows[n]["SD_CityID"].ToString();
                    model.SD_ProvinceId = dt.Rows[n]["SD_ProvinceId"].ToString();
                    model.SD_Flag = Convert.ToInt32(dt.Rows[n]["SD_Flag"].ToString());
                    model.SD_Mark = Convert.ToInt32(dt.Rows[n]["SD_Mark"].ToString());

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