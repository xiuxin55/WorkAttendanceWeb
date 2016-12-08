using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //CollectionInfo
    public partial class ActivityInfoService
    {

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ActivityInfo GetModel(string AC_Id, string AC_UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select AC_Name,AC_CityId,AC_ProvinceId,AC_SDID,AC_Authentication,AC_StartTime,AC_LastTime,AC_Time,AC_flag,AC_UserName  ");
            strSql.Append("  from Activity ");
            strSql.Append(" where AC_Id=@AC_Id and AC_UserName=@AC_UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@AC_Id", SqlDbType.VarChar,255),
                    new SqlParameter("@AC_UserName", SqlDbType.VarChar,255)};
            parameters[0].Value = AC_Id;
            parameters[1].Value = AC_UserName;


            ActivityInfo model = new ActivityInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AC_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["AC_Id"].ToString());
                model.AC_Name = ds.Tables[0].Rows[0]["AC_Name"].ToString();
                model.AC_CityId = ds.Tables[0].Rows[0]["AC_CityId"].ToString();
                model.AC_ProvinceId = ds.Tables[0].Rows[0]["AC_ProvinceId"].ToString();
                model.AC_SDID = ds.Tables[0].Rows[0]["AC_SDID"].ToString();
                model.AC_Authentication = ds.Tables[0].Rows[0]["AC_Authentication"].ToString();
                model.AC_StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AC_StartTime"].ToString());
                model.AC_LastTime = Convert.ToDateTime( ds.Tables[0].Rows[0]["AC_LastTime"].ToString());
                model.AC_Time = ds.Tables[0].Rows[0]["AC_Time"].ToString();
                model.AC_flag = Convert.ToInt32( ds.Tables[0].Rows[0]["AC_flag"].ToString());
                model.AC_UserName = ds.Tables[0].Rows[0]["AC_UserName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region method

        ///// <summary>
        /////  分页查询
        ///// </summary>
        //public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        //{
        //    try
        //    {
        //        SqlParameter[] para = new SqlParameter[] {
        //            new SqlParameter("@pageSize",pageSize),
        //            new SqlParameter("@pageIndex",pageIndex),
        //            new SqlParameter("@strWhere",strWhere),
        //            new SqlParameter("@fdlOrder",fdlOrder),
        //            new SqlParameter("@isCount",isCount)
        //        };
        //        return DbHelperSQL.RunProcedure("CollectionInfo_Page", para).Tables[0];
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
            return DBHelpService.GetPageList(pageSize, pageIndex, TableName, PrimaryKey, FieldList, strWhere, fdlOrder, isCount, isPageCount);
        }

        public bool Exists(string AC_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Activity");
            strSql.Append(" where ");
            strSql.Append(" AC_Id = @AC_Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@AC_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = AC_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ActivityInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Activity(");
            strSql.Append("AC_Name,AC_CityId,AC_ProvinceId,AC_SDID,AC_Authentication,AC_StartTime,AC_LastTime,AC_Time,AC_flag,AC_UserName");
            strSql.Append(") values (");
            strSql.Append("@AC_Name,@AC_CityId,@AC_ProvinceId,@AC_SDID,@AC_Authentication,@AC_StartTime,@AC_LastTime,@AC_Time,@AC_flag,@AC_UserName");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@AC_Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_CityId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_ProvinceId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_SDID", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_Authentication", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_StartTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AC_LastTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AC_Time", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_flag", SqlDbType.Int) ,
                        new SqlParameter("@AC_UserName", SqlDbType.VarChar,255) 
            };

            //parameters[0].Value = model.AC_Id;
            parameters[0].Value = model.AC_Name;
            parameters[1].Value = model.AC_CityId;
            parameters[2].Value = model.AC_ProvinceId;
            parameters[3].Value = model.AC_SDID;
            parameters[4].Value = model.AC_Authentication;
            parameters[5].Value = model.AC_StartTime;
            parameters[6].Value = model.AC_LastTime;
            parameters[7].Value = model.AC_Time;
            parameters[8].Value = model.AC_flag;
            parameters[9].Value = model.AC_UserName;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ActivityInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Activity set ");
            strSql.Append(" AC_Name = @AC_Name, ");
            strSql.Append(" AC_CityId = @AC_CityId, ");
            strSql.Append(" AC_ProvinceId = @AC_ProvinceId, ");
            strSql.Append(" AC_SDID = @AC_SDID, ");
            strSql.Append(" AC_Authentication = @AC_Authentication, ");
            strSql.Append(" AC_StartTime = @AC_StartTime, ");
            strSql.Append(" AC_LastTime = @AC_LastTime, ");
            strSql.Append(" AC_Time = @AC_Time, ");
            strSql.Append(" AC_flag = @AC_flag, ");
            strSql.Append(" AC_UserName = @AC_UserName ");
            strSql.Append(" where AC_Id=@AC_Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@AC_Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_CityId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_ProvinceId", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_SDID", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_Authentication", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_StartTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AC_LastTime", SqlDbType.DateTime) ,
                        new SqlParameter("@AC_Time", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_flag", SqlDbType.Int) ,
                        new SqlParameter("@AC_UserName", SqlDbType.VarChar,255) ,
                        new SqlParameter("@AC_Id", SqlDbType.Int) 
              
            };

            parameters[0].Value = model.AC_Name;
            parameters[1].Value = model.AC_CityId;
            parameters[2].Value = model.AC_ProvinceId;
            parameters[3].Value = model.AC_SDID;
            parameters[4].Value = model.AC_Authentication;
            parameters[5].Value = model.AC_StartTime;
            parameters[6].Value = model.AC_LastTime;
            parameters[7].Value = model.AC_Time;
            parameters[8].Value = model.AC_flag;
            parameters[9].Value = model.AC_UserName;
            parameters[10].Value = model.AC_Id;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string AC_Id)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Activity set ");//将数据修改为禁用  考虑到扩展
            //strSql.Append(" AC_flag = 1, ");
            //strSql.Append(" where AC_Id=@AC_Id  ");
            strSql.Append("delete from Activity ");
            strSql.Append(" where AC_Id=@AC_Id ");
            SqlParameter[] parameters = {
			            new SqlParameter("@AC_Id", SqlDbType.VarChar,255) };
            parameters[0].Value = AC_Id;
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
        /// 得到一个对象实体
        /// </summary>
        public ActivityInfo GetModel(string AC_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from Activity ");
            strSql.Append(" where AC_Id=@AC_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@AC_Id", SqlDbType.VarChar,255)			
            };
            parameters[0].Value = AC_Id;


            ActivityInfo model = new ActivityInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AC_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["AC_Id"].ToString());
                model.AC_Name = ds.Tables[0].Rows[0]["AC_Name"].ToString();
                model.AC_CityId = ds.Tables[0].Rows[0]["AC_CityId"].ToString();
                model.AC_ProvinceId = ds.Tables[0].Rows[0]["AC_ProvinceId"].ToString();
                model.AC_SDID = ds.Tables[0].Rows[0]["AC_SDID"].ToString();
                model.AC_Authentication = ds.Tables[0].Rows[0]["AC_Authentication"].ToString();
                model.AC_StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AC_StartTime"].ToString());
                model.AC_LastTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AC_LastTime"].ToString());
                model.AC_Time = ds.Tables[0].Rows[0]["AC_Time"].ToString();
                model.AC_flag = Convert.ToInt32(ds.Tables[0].Rows[0]["AC_flag"].ToString());
                model.AC_UserName = ds.Tables[0].Rows[0]["AC_UserName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Activity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Activity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

    }
}

