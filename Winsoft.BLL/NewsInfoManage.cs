using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //NewsInfo
    public partial class NewsInfoManage
    {

        private readonly NewsInfoService dal = new NewsInfoService();
        private NewsInfoManage()
        { }

        public static NewsInfoManage GetInstance()
        {
            return new NewsInfoManage();
        }

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NewsInfo GetModelByMID(string M_ID)
        {
            return dal.GetModelByMID(M_ID);
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
        public bool Exists(string N_ID)
        {
            return dal.Exists(N_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(NewsInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(NewsInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string N_ID)
        {

            return dal.Delete(N_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NewsInfo GetModel(string N_ID)
        {

            return dal.GetModel(N_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public NewsInfo GetModelByCache(string N_ID)
        {

            string CacheKey = "NewsInfoModel-" + N_ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(N_ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NewsInfo)objModel;
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
        public List<NewsInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NewsInfo> DataTableToList(DataTable dt)
        {
            List<NewsInfo> modelList = new List<NewsInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NewsInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NewsInfo();
                    model.N_ID = dt.Rows[n]["N_ID"].ToString();
                    if (dt.Rows[n]["N_Type"].ToString() != "")
                    {
                        model.N_Type = int.Parse(dt.Rows[n]["N_Type"].ToString());
                    }
                    if (dt.Rows[n]["N_Order"].ToString() != "")
                    {
                        model.N_Order = int.Parse(dt.Rows[n]["N_Order"].ToString());
                    }
                    model.N_Str1 = dt.Rows[n]["N_Str1"].ToString();
                    model.N_Str2 = dt.Rows[n]["N_Str2"].ToString();
                    model.N_Str3 = dt.Rows[n]["N_Str3"].ToString();
                    model.N_Str4 = dt.Rows[n]["N_Str4"].ToString();
                    model.M_ID = dt.Rows[n]["M_ID"].ToString();
                    model.N_Title = dt.Rows[n]["N_Title"].ToString();
                    model.N_Url = dt.Rows[n]["N_Url"].ToString();
                    model.N_Img = dt.Rows[n]["N_Img"].ToString();
                    model.N_Source = dt.Rows[n]["N_Source"].ToString();
                    model.N_Author = dt.Rows[n]["N_Author"].ToString();
                    model.N_Content = dt.Rows[n]["N_Content"].ToString();
                    if (dt.Rows[n]["N_Time"].ToString() != "")
                    {
                        model.N_Time = DateTime.Parse(dt.Rows[n]["N_Time"].ToString());
                    }


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