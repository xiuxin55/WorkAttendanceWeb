using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //VidoInfo
    public partial class VidoInfoManage
    {

        private readonly VidoInfoService dal = new VidoInfoService();
        private VidoInfoManage()
        { }

        public static VidoInfoManage GetInstance()
        {
            return new VidoInfoManage();
        }

        #region 自定义方法

        /// <summary>
        ///  关键词查询
        /// </summary>
        public DataTable GetPageKeyword(int topcount, string keyword, string strWhere)
        {
            return dal.GetPageKeyword(topcount, keyword, strWhere);
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
        public bool Exists(string V_ID)
        {
            return dal.Exists(V_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(VidoInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(VidoInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string V_ID)
        {

            return dal.Delete(V_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public VidoInfo GetModel(string V_ID)
        {

            return dal.GetModel(V_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public VidoInfo GetModelByCache(string V_ID)
        {

            string CacheKey = "VidoInfoModel-" + V_ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(V_ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (VidoInfo)objModel;
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
        public List<VidoInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<VidoInfo> DataTableToList(DataTable dt)
        {
            List<VidoInfo> modelList = new List<VidoInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                VidoInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new VidoInfo();
                    model.V_ID = dt.Rows[n]["V_ID"].ToString();
                    model.V_SmallImg = dt.Rows[n]["V_SmallImg"].ToString();
                    model.V_BigImg = dt.Rows[n]["V_BigImg"].ToString();
                    if (dt.Rows[n]["V_LessonCount"].ToString() != "")
                    {
                        model.V_LessonCount = int.Parse(dt.Rows[n]["V_LessonCount"].ToString());
                    }
                    if (dt.Rows[n]["V_BuyCount"].ToString() != "")
                    {
                        model.V_BuyCount = int.Parse(dt.Rows[n]["V_BuyCount"].ToString());
                    }
                    if (dt.Rows[n]["V_BuyCountReal"].ToString() != "")
                    {
                        model.V_BuyCountReal = int.Parse(dt.Rows[n]["V_BuyCountReal"].ToString());
                    }
                    if (dt.Rows[n]["V_PlayCount"].ToString() != "")
                    {
                        model.V_PlayCount = int.Parse(dt.Rows[n]["V_PlayCount"].ToString());
                    }
                    if (dt.Rows[n]["V_PlayCountReal"].ToString() != "")
                    {
                        model.V_PlayCountReal = int.Parse(dt.Rows[n]["V_PlayCountReal"].ToString());
                    }
                    if (dt.Rows[n]["V_BrowseCount"].ToString() != "")
                    {
                        model.V_BrowseCount = int.Parse(dt.Rows[n]["V_BrowseCount"].ToString());
                    }
                    if (dt.Rows[n]["V_BrowseCountReal"].ToString() != "")
                    {
                        model.V_BrowseCountReal = int.Parse(dt.Rows[n]["V_BrowseCountReal"].ToString());
                    }
                    if (dt.Rows[n]["V_CollectionCount"].ToString() != "")
                    {
                        model.V_CollectionCount = int.Parse(dt.Rows[n]["V_CollectionCount"].ToString());
                    }
                    model.M_ID = dt.Rows[n]["M_ID"].ToString();
                    if (dt.Rows[n]["V_CollectionCountReal"].ToString() != "")
                    {
                        model.V_CollectionCountReal = int.Parse(dt.Rows[n]["V_CollectionCountReal"].ToString());
                    }
                    if (dt.Rows[n]["V_Time"].ToString() != "")
                    {
                        model.V_Time = DateTime.Parse(dt.Rows[n]["V_Time"].ToString());
                    }
                    model.VT_ID = dt.Rows[n]["VT_ID"].ToString();
                    model.V_Code = dt.Rows[n]["V_Code"].ToString();
                    model.V_Name = dt.Rows[n]["V_Name"].ToString();
                    model.V_Keyword = dt.Rows[n]["V_Keyword"].ToString();
                    model.V_Content = dt.Rows[n]["V_Content"].ToString();
                    if (dt.Rows[n]["V_Price"].ToString() != "")
                    {
                        model.V_Price = decimal.Parse(dt.Rows[n]["V_Price"].ToString());
                    }
                    if (dt.Rows[n]["V_NewPrice"].ToString() != "")
                    {
                        model.V_NewPrice = decimal.Parse(dt.Rows[n]["V_NewPrice"].ToString());
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