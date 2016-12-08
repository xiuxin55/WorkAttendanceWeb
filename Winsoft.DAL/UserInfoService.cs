using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL  
{
    //UserInfoService
    public partial class UserInfoService
	{
	
		#region 自定义方法

        public bool Login(string US_UserName, string US_PassWord)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from [User]");
                strSql.Append(" where ");
                strSql.Append(" US_UserName = @US_UserName and US_Password = @US_PassWord ");
                SqlParameter[] parameters = {
					new SqlParameter("@US_UserName", SqlDbType.VarChar,255),
                    new SqlParameter("@US_PassWord", SqlDbType.VarChar,255)};
                parameters[0].Value = US_UserName;
                parameters[1].Value = US_PassWord;

                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }

            /// <summary>
            /// 得到一个对象实体
            /// </summary>
            public UserInfo GetModelByUserName(string US_UserName)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from [User] ");
                strSql.Append(" where US_UserName=@US_UserName ");
                SqlParameter[] parameters = {
					new SqlParameter("@US_UserName", SqlDbType.VarChar,255)			};
                parameters[0].Value = US_UserName;


                UserInfo model = new UserInfo();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.US_UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["US_UserId"].ToString());
                    model.US_UserName = ds.Tables[0].Rows[0]["US_UserName"].ToString();
                    model.US_PassWord = ds.Tables[0].Rows[0]["US_PassWord"].ToString();
                    model.US_Sex = ds.Tables[0].Rows[0]["US_Sex"].ToString();
                
                    model.US_Name = ds.Tables[0].Rows[0]["US_Name"].ToString();
                    model.US_TelPhone = ds.Tables[0].Rows[0]["US_TelPhone"].ToString();
                    model.US_Email = ds.Tables[0].Rows[0]["US_Email"].ToString();
                    model.US_QQ = ds.Tables[0].Rows[0]["US_QQ"].ToString();
                    model.US_UnitName = ds.Tables[0].Rows[0]["US_UnitName"].ToString();
                    //model.US_Integral = Convert.ToInt32(ds.Tables[0].Rows[0]["US_Integral"].ToString());
                    model.US_ServiceDepartment = ds.Tables[0].Rows[0]["US_ServiceDepartment"].ToString();
                    if (ds.Tables[0].Rows[0]["US_RegisterTime"].ToString() == null)
                    {
                        model.US_RegisterTime = ds.Tables[0].Rows[0]["US_RegisterTime"].ToString();
                    }
                    model.US_Authentication = ds.Tables[0].Rows[0]["US_Authentication"].ToString();
                    model.US_Flag = Convert.ToInt32(ds.Tables[0].Rows[0]["US_Flag"].ToString());
                    if (ds.Tables[0].Rows[0]["US_LastLoginTime"].ToString()==null)
                    {
                        model.US_LastLoginTime = ds.Tables[0].Rows[0]["US_LastLoginTime"].ToString();                        
                    }
                    if (ds.Tables[0].Rows[0]["US_LastQuitTime"].ToString() == null)
                    {
                        model.US_LastQuitTime = ds.Tables[0].Rows[0]["US_LastQuitTime"].ToString();                        
                    }
                    model.US_ProvinceId = ds.Tables[0].Rows[0]["US_ProvinceId"].ToString();
                    model.US_CityId = ds.Tables[0].Rows[0]["US_CityId"].ToString();
                    model.US_WebsiteName = ds.Tables[0].Rows[0]["US_WebsiteName"].ToString();
                    
                    return model;
                }
                else
                {
                    return null;
                }
            }
		
		#endregion
	
		#region method
   		     
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
   		public DataTable GetPageList(int pageSize, int pageIndex,string TableName,string PrimaryKey, string FieldList, string strWhere, string fdlOrder, int isCount,int isPageCount)
   		{
            //try
            //{
            //    SqlParameter[] para = new SqlParameter[] {
            //        new SqlParameter("@TableName",TableName),
            //        new SqlParameter("@FieldList",FieldList),
            //        new SqlParameter("@PrimaryKey",PrimaryKey),
            //        new SqlParameter("@Where",strWhere),
            //        new SqlParameter("@Order",fdlOrder),
            //        new SqlParameter("@SortType",3),
            //        new SqlParameter("@RecorderCount",0),
            //        new SqlParameter("@pageSize",pageSize),
            //        new SqlParameter("@pageIndex",pageIndex),
            //        new SqlParameter("@TotalCount",isCount),
            //        new SqlParameter("@TotalPageCount",isPageCount)
            //    };
            //    return DbHelperSQL.RunProcedure("P_viewPage", para).Tables[0];
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return DBHelpService.GetPageList(pageSize, pageIndex, TableName, PrimaryKey, FieldList, strWhere, fdlOrder, isCount, isPageCount);
   		}

        public bool ExistsByUserName(string US_UserName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [User]");
			strSql.Append(" where ");
            strSql.Append(" US_UserName = @US_UserName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@US_UserName", SqlDbType.VarChar,255)
                                        };
            parameters[0].Value = US_UserName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into [User](");
            strSql.Append(@"US_UserName,US_PassWord,US_Sex,US_Name,US_TelPhone,US_Email,US_QQ,US_UnitName,US_Integral,US_ServiceDepartment,US_RegisterTime,US_Authentication,US_Flag,US_LastLoginTime,US_LastQuitTime,US_ProvinceId,US_CityId,US_CardId,US_WebsiteName");
			strSql.Append(") values (");
            strSql.Append(@"@US_UserName,@US_PassWord,@US_Sex,@US_Name,@US_TelPhone,@US_Email,@US_QQ,@US_UnitName,@US_Integral,@US_ServiceDepartment,@US_RegisterTime,@US_Authentication,@US_Flag,@US_LastLoginTime,@US_LastQuitTime,@US_ProvinceId,@US_CityId,@US_CardId,@US_WebsiteName");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
                        new SqlParameter("@US_UserName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_PassWord", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Sex", SqlDbType.VarChar,255) , 
                    
                        new SqlParameter("@US_Name", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_TelPhone", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Email", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_QQ", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_UnitName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Integral", SqlDbType.Int) , 
                        new SqlParameter("@US_ServiceDepartment", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_RegisterTime", SqlDbType.DateTime) , 
                        new SqlParameter("@US_Authentication", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Flag", SqlDbType.Int) , 
                        new SqlParameter("@US_LastLoginTime", SqlDbType.DateTime) , 
                        new SqlParameter("@US_LastQuitTime", SqlDbType.DateTime) , 
                        new SqlParameter("@US_ProvinceId", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_CityId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@US_CardId", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@US_WebsiteName", SqlDbType.VarChar,255) 
              
            };
            parameters[0].Value = model.US_UserName;
            parameters[1].Value = model.US_PassWord;
            parameters[2].Value = model.US_Sex;
         
            parameters[3].Value = model.US_Name;
            parameters[4].Value = model.US_TelPhone;
            parameters[5].Value = model.US_Email; 
            parameters[6].Value = model.US_QQ;
            parameters[7].Value = model.US_UnitName;
            parameters[8].Value = model.US_Integral;
            parameters[9].Value = model.US_ServiceDepartment; 
            parameters[10].Value = model.US_RegisterTime;
            parameters[11].Value = model.US_Authentication; 
            parameters[12].Value = model.US_Flag;
            parameters[13].Value = model.US_LastLoginTime; 
            parameters[14].Value = model.US_LastQuitTime;
            parameters[15].Value = model.US_ProvinceId; 
            parameters[16].Value = model.US_CityId;
            parameters[17].Value = model.US_CardId;
            parameters[18].Value = model.US_WebsiteName;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }                        
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [User] set ");
            strSql.Append(" US_UserName = @US_UserName , ");                                    
        	strSql.Append(" US_PassWord = @US_PassWord , ");
            strSql.Append(" US_Sex = @US_Sex , ");
     
            strSql.Append(" US_Name = @US_Name , ");
            strSql.Append(" US_TelPhone = @US_TelPhone , ");
            strSql.Append(" US_Email = @US_Email , ");
            strSql.Append(" US_QQ = @US_QQ , ");
            strSql.Append(" US_UnitName = @US_UnitName , ");
            strSql.Append(" US_Integral = @US_Integral , ");
            strSql.Append(" US_ServiceDepartment = @US_ServiceDepartment , ");
            strSql.Append(" US_RegisterTime = @US_RegisterTime , ");
            strSql.Append(" US_Authentication = @US_Authentication , ");
            strSql.Append(" US_Flag = @US_Flag , ");
            strSql.Append(" US_LastLoginTime = @US_LastLoginTime , ");
            strSql.Append(" US_LastQuitTime = @US_LastQuitTime , ");
            strSql.Append(" US_ProvinceId = @US_ProvinceId , ");
            strSql.Append(" US_CardId = @US_CardId , ");
            strSql.Append(" US_CityId = @US_CityId,");
            strSql.Append(" US_WebsiteName = @US_WebsiteName ");
            strSql.Append(" where US_UserId=@US_UserId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@US_UserName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_PassWord", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Sex", SqlDbType.VarChar,255) , 
                       
                        new SqlParameter("@US_Name", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_TelPhone", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Email", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_QQ", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_UnitName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Integral", SqlDbType.Int) , 
                        new SqlParameter("@US_ServiceDepartment", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_RegisterTime", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Authentication", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_Flag", SqlDbType.Int) , 
                        new SqlParameter("@US_LastLoginTime", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_LastQuitTime", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_ProvinceId", SqlDbType.VarChar,255) , 
                        new SqlParameter("@US_CityId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@US_UserId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@US_CardId", SqlDbType.VarChar,255) ,
                           new SqlParameter("@US_WebsiteName", SqlDbType.VarChar,255) 
              
            };
            parameters[0].Value = model.US_UserName;
            parameters[1].Value = model.US_PassWord;
            parameters[2].Value = model.US_Sex;

            parameters[3].Value = model.US_Name;
            parameters[4].Value = model.US_TelPhone;
            parameters[5].Value = model.US_Email;
            parameters[6].Value = model.US_QQ;
            parameters[7].Value = model.US_UnitName;
            parameters[8].Value = model.US_Integral;
            parameters[9].Value = model.US_ServiceDepartment;
            parameters[10].Value = model.US_RegisterTime;
            parameters[11].Value = model.US_Authentication;
            parameters[12].Value = model.US_Flag;
            parameters[13].Value = model.US_LastLoginTime;
            parameters[14].Value = model.US_LastQuitTime;
            parameters[15].Value = model.US_ProvinceId;
            parameters[16].Value = model.US_CityId;
            parameters[17].Value = model.US_UserId;
            parameters[18].Value = model.US_CardId;
            parameters[19].Value = model.US_WebsiteName;
          //  strSql.Append(" US_WebsiteName = @US_WebsiteName ");
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string US_UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [User] ");
            strSql.Append(" where US_UserId=@US_UserId ");
						SqlParameter[] parameters = {
					new SqlParameter("@US_UserId", SqlDbType.VarChar,255)			};
                        parameters[0].Value = US_UserId;
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public UserInfo GetModel(string US_UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select US_UserId, US_UserName,US_PassWord,US_Sex,US_Birthday,US_Name,US_TelPhone,US_Email,US_QQ,US_UnitName,US_Integral,US_ServiceDepartment,US_RegisterTime,US_Authentication,US_Flag,US_LastLoginTime,US_LastQuitTime,US_ProvinceId,US_CityId,US_CardId ,US_WebsiteName ");			
			strSql.Append("  from [User] ");
            strSql.Append(" where US_UserId=@US_UserId ");
						SqlParameter[] parameters = {
					new SqlParameter("@US_UserId", SqlDbType.VarChar,255)			};
                        parameters[0].Value = US_UserId;

			
			UserInfo model=new UserInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
                model.US_UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["US_UserId"].ToString());
                model.US_UserName = ds.Tables[0].Rows[0]["US_UserName"].ToString();
                model.US_PassWord = ds.Tables[0].Rows[0]["US_PassWord"].ToString();
                model.US_Sex = ds.Tables[0].Rows[0]["US_Sex"].ToString();
                model.US_Birthday = ds.Tables[0].Rows[0]["US_Birthday"].ToString();
                model.US_Name = ds.Tables[0].Rows[0]["US_Name"].ToString();
                model.US_TelPhone = ds.Tables[0].Rows[0]["US_TelPhone"].ToString();
                model.US_Email = ds.Tables[0].Rows[0]["US_Email"].ToString();
                model.US_QQ = ds.Tables[0].Rows[0]["US_QQ"].ToString();
                model.US_UnitName = ds.Tables[0].Rows[0]["US_UnitName"].ToString();
                //model.US_Integral = Convert.ToInt32(ds.Tables[0].Rows[0]["US_Integral"].ToString());
                model.US_ServiceDepartment = ds.Tables[0].Rows[0]["US_ServiceDepartment"].ToString();
                model.US_RegisterTime = ds.Tables[0].Rows[0]["US_RegisterTime"].ToString();
                model.US_Authentication = ds.Tables[0].Rows[0]["US_Authentication"].ToString();
                model.US_Flag = Convert.ToInt32(ds.Tables[0].Rows[0]["US_Flag"].ToString());
                //if (ds.Tables[0].Rows[0]["US_LastLoginTime"].ToString() != null && ds.Tables[0].Rows[0]["US_LastLoginTime"].ToString() != "")
                //{
                    model.US_LastLoginTime = ds.Tables[0].Rows[0]["US_LastLoginTime"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["US_LastQuitTime"].ToString()!=null&&ds.Tables[0].Rows[0]["US_LastQuitTime"].ToString()!="")
                //{
                    model.US_LastQuitTime = ds.Tables[0].Rows[0]["US_LastQuitTime"].ToString();
                //}
                model.US_ProvinceId = ds.Tables[0].Rows[0]["US_ProvinceId"].ToString();
                model.US_CityId = ds.Tables[0].Rows[0]["US_CityId"].ToString();
                model.US_CardId = ds.Tables[0].Rows[0]["US_CardId"].ToString();
                model.US_WebsiteName = ds.Tables[0].Rows[0]["US_WebsiteName"].ToString();																	
				return model;
			}
			else
			{
				return null;
			}
		}

        public DataSet GetWebsiteList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [Website] where WebsiteFlag='0' ");
          
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
            //StringBuilder strSql=new StringBuilder();
            //strSql.Append("select ");
            //if(Top>0)
            //{
            //    strSql.Append(" top "+Top.ToString());
            //}
            //strSql.Append(" * ");
            //strSql.Append(" FROM [User] ");
            //if(strWhere.Trim()!="")
            //{
            //    strSql.Append(" where "+strWhere);
            //}
            //strSql.Append(" order by " + filedOrder);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select ");
            //if(Top>0)
            //{
            //    strSql.Append(" top "+Top.ToString());
            //}
            strSql.Append(" row_number()over(order by " + filedOrder + ") as Number, * ");
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		#endregion
   
	}
}

