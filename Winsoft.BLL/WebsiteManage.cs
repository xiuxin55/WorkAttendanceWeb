using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winsoft.DAL;
using Winsoft.Model;
using System.Data;

namespace Winsoft.BLL
{
    public class WebsiteManage
    {
    private readonly WebsiteServer dal=new WebsiteServer();
    private WebsiteManage()
		{}

    public static WebsiteManage GetInstance()
		{
            return new WebsiteManage();
		}
		
		#region 自定义方法

      
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public WebSiteModel GetModelByWebsiteID(string WebsiteID)
        {
            return dal.GetModelByWebsite(WebsiteID);
        }
       /// <summary>
       /// 网点名一个对象实体
       /// </summary>
       public WebSiteModel GetModelByWebsiteName(string WebsiteName)
       {
           return dal.GetModelByWebsiteName(WebsiteName);
       }
		
		#endregion
		
		#region  Method

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">每页输出的记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="TableName">表名</param>
        /// <param name="PrimaryKey">单一主键或唯一值键</param>
        /// <param name="FieldList">显示列名，如果是全部字段则为*</param>
        /// <param name="strWhere">查询条件 不含'where'字符，如id>10 and len(userid)>9   </param>
        /// <param name="fdlOrder">排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc</param>
        /// <param name="isCount">记返回总记录</param>
        /// <param name="isPageCount">返回总页数</param>
        /// <returns></returns>
        public DataTable GetPageList(int pageSize, int pageIndex, string TableName, string PrimaryKey, string FieldList, string strWhere, string fdlOrder, int isCount, int isPageCount)
        {
            return dal.GetPageList( pageSize,  pageIndex,  TableName,  PrimaryKey,  FieldList,  strWhere,  fdlOrder,  isCount,  isPageCount);
        }
		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsByWebSiteID(string WebsiteID)
		{
            return dal.ExistsByWebSiteID(WebsiteID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(WebSiteModel model)
		{
            return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(WebSiteModel model, string id, string oldwebsitename)
		{
            return dal.Update(model, id, oldwebsitename);
		}

		
        /// <summary>
        /// 删除网点一条数据
        /// </summary>
        public bool Delete(string WebsiteID)
        {

            return dal.Delete(WebsiteID);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public WebSiteModel GetModel(string WebsiteID)
		{

            return dal.GetModel(WebsiteID);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public WebSiteModel GetModelByCache(string WebsiteID)
        //{

        //    string CacheKey = "User-" + WebsiteID;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(WebsiteID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (WebSiteModel)objModel;
        //}

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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<WebSiteModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<WebSiteModel> DataTableToList(DataTable dt)
		{
            List<WebSiteModel> modelList = new List<WebSiteModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                WebSiteModel model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new WebSiteModel();
                    model.WebsiteID = dt.Rows[0]["WebsiteID"].ToString();
                    model.WebsiteName = dt.Rows[0]["WebsiteName"].ToString();
                    model.WebsiteFlag = dt.Rows[0]["WebsiteFlag"].ToString();

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
