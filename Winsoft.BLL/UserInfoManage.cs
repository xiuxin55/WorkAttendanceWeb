using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL {
	 	//AdminInfo
		public partial class UserInfoManage
	{
   		     
		private readonly UserInfoService dal=new UserInfoService();
		private UserInfoManage()
		{}
		
		public static UserInfoManage GetInstance()
		{
			return new UserInfoManage();
		}
		
		#region 自定义方法

        public bool Login(string Us_UserName, string US_Password)
        {
            return dal.Login(Us_UserName, US_Password);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo GetModelByUserName(string Us_UserName)
        {
            return dal.GetModelByUserName(Us_UserName);
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
        public bool ExistsByUserName(string Us_UserName)
		{
            return dal.ExistsByUserName(Us_UserName);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserInfo model)
		{
            return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string US_UserId)
		{

            return dal.Delete(US_UserId);
		}
       
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public UserInfo GetModel(string US_UserId)
		{

            return dal.GetModel(US_UserId);
		}
        /// <summary>
        /// 得到所有网点
        /// </summary>
        public DataTable GetWebsiteList()
        {
            DataSet ds = dal.GetWebsiteList();
            if(ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public UserInfo GetModelByCache(string US_UserId)
		{

            string CacheKey = "User-" + US_UserId;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(US_UserId);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserInfo)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserInfo> DataTableToList(DataTable dt)
		{
			List<UserInfo> modelList = new List<UserInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new UserInfo();					
                    model.US_UserId = Convert.ToInt32(dt.Rows[n]["US_UserId"].ToString());
                    model.US_UserName = dt.Rows[n]["US_UserName"].ToString();
                    model.US_PassWord = dt.Rows[n]["US_PassWord"].ToString();
                    model.US_Sex = dt.Rows[n]["US_Sex"].ToString();
                    model.US_Birthday = dt.Rows[n]["US_Birthday"].ToString();
                    model.US_Name = dt.Rows[n]["US_Name"].ToString();
                    model.US_TelPhone = dt.Rows[n]["US_TelPhone"].ToString();
                    model.US_Email = dt.Rows[n]["US_Email"].ToString();
                    model.US_QQ = dt.Rows[n]["US_QQ"].ToString();
                    model.US_UnitName = dt.Rows[n]["US_UnitName"].ToString();
                    model.US_Integral = Convert.ToInt32(dt.Rows[n]["US_Integral"].ToString());
                    model.US_ServiceDepartment = dt.Rows[n]["US_ServiceDepartment"].ToString();
                    model.US_RegisterTime = dt.Rows[n]["US_RegisterTime"].ToString();
                    model.US_Authentication = dt.Rows[n]["US_Authentication"].ToString();
                    model.US_Flag = Convert.ToInt32(dt.Rows[n]["US_Flag"].ToString());
                    model.US_LastLoginTime = dt.Rows[n]["US_LastLoginTime"].ToString();
                    model.US_LastQuitTime = dt.Rows[n]["US_LastQuitTime"].ToString();
                    model.US_ProvinceId = dt.Rows[n]["US_ProvinceId"].ToString();
                    model.US_CityId = dt.Rows[n]["US_CityId"].ToString();

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