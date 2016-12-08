using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //MenuInfo
    public partial class CityInfoManage
    {

        private readonly CityInfoService dal = new CityInfoService();
        private CityInfoManage()
        { }

        public static CityInfoManage GetInstance()
        {
            return new CityInfoManage();
        }

        #region 自定义方法

        /// <summary>
        /// 获取菜单导航
        /// </summary>
        //public string GetAdminMenuStr(string M_ID)
        //{
        //    string M_Menu1 = "";
        //    string M_Menu2 = "";
        //    string M_Menu3 = "";
        //    string M_PID = "";
        //    string M_Name = "";
        //    if (M_ID != null && M_ID != string.Empty)
        //    {
        //        //获得三级分类名称
        //        CityInfo model = GetModel(M_ID);
        //        if (model != null)
        //        {
        //            M_Name = model.M_Name;
        //            M_PID = model.M_PID;
        //            M_Menu3 = M_Name;
        //            //获得二级分类名称
        //            model = GetModel(M_PID);
        //            if (model != null)
        //            {
        //                M_Name = model.M_Name;
        //                M_PID = model.M_PID;
        //                M_Menu2 = M_Name + "》";

        //                //获得一级分类名称
        //                model = GetModel(M_PID);
        //                if (model != null)
        //                {
        //                    M_Name = model.M_Name;
        //                    M_Menu1 = M_Name + "》";
        //                }
        //            }
        //        }
        //    }
        //    return M_Menu1 + M_Menu2 + M_Menu3;
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
        public bool Exists(string CT_CityID)
        {
            return dal.Exists(CT_CityID);
        }

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public void Add(CityInfo model)
        //{
        //    dal.Add(model);

        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(CityInfo model)
        //{
        //    return dal.Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(string M_ID)
        //{

        //    return dal.Delete(M_ID);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CityInfo GetModel(string CT_CityID)
        {

            return dal.GetModel(CT_CityID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CityInfo GetModelByCache(string CT_CityID)
        {

            string CacheKey = "City-" + CT_CityID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CT_CityID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CityInfo)objModel;
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
        public List<CityInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CityInfo> DataTableToList(DataTable dt)
        {
            List<CityInfo> modelList = new List<CityInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CityInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CityInfo();
                    //model.M_ID = dt.Rows[n]["M_ID"].ToString();
                    //if (dt.Rows[n]["M_Time"].ToString() != "")
                    //{
                    //    model.M_Time = DateTime.Parse(dt.Rows[n]["M_Time"].ToString());
                    //}
                    //model.M_PID = dt.Rows[n]["M_PID"].ToString();
                    //model.M_Name = dt.Rows[n]["M_Name"].ToString();
                    //if (dt.Rows[n]["M_Type"].ToString() != "")
                    //{
                    //    model.M_Type = int.Parse(dt.Rows[n]["M_Type"].ToString());
                    //}
                    //if (dt.Rows[n]["M_Level"].ToString() != "")
                    //{
                    //    model.M_Level = int.Parse(dt.Rows[n]["M_Level"].ToString());
                    //}
                    //model.M_Url = dt.Rows[n]["M_Url"].ToString();
                    //model.M_EUrl = dt.Rows[n]["M_EUrl"].ToString();
                    //if (dt.Rows[n]["M_Order"].ToString() != "")
                    //{
                    //    model.M_Order = int.Parse(dt.Rows[n]["M_Order"].ToString());
                    //}
                    //model.M_Remark = dt.Rows[n]["M_Remark"].ToString();
                    model.CT_CityID = dt.Rows[n]["CT_CityID"].ToString();
                    model.CT_CityName = dt.Rows[n]["[CT_CityName]"].ToString();
                    model.CT_ProvinceID = dt.Rows[n]["CT_ProvinceID"].ToString();

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