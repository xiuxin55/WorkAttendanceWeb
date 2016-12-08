using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //CommentInfo
    public partial class ServiceDepartmentInfoService
    {

        #region 自定义方法



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
        //        return DbHelperSQL.RunProcedure("CommentInfo_Page", para).Tables[0];
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

        public bool Exists(string SD_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServiceDepartment");
            strSql.Append(" where ");
            strSql.Append(" SD_Id = @SD_Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@SD_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = SD_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ServiceDepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServiceDepartment(");
            strSql.Append("SD_Name,SD_SDID,SD_Time,SD_UserID,SD_CityID,SD_ProvinceId,SD_Flag,SD_Mark");
            strSql.Append(") values (");
            strSql.Append("@SD_Name,@SD_SDID,@SD_Time,@SD_UserID,@SD_CityID,@SD_ProvinceId,@SD_Flag,@SD_Mark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@SD_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_SDID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_Time", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_UserID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_CityID", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@SD_ProvinceId", SqlDbType.DateTime) ,            
                        new SqlParameter("@SD_Flag", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@SD_Mark", SqlDbType.VarChar,255)             
            };
            parameters[0].Value = model.SD_Name;
            parameters[1].Value = model.SD_SDID;
            parameters[2].Value = model.SD_Time;
            parameters[3].Value = model.SD_UserID;
            parameters[4].Value = model.SD_CityID;
            parameters[5].Value = model.SD_ProvinceId;
            parameters[6].Value = model.SD_Flag;
            parameters[7].Value = model.SD_Mark;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ServiceDepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServiceDepartment set ");

            strSql.Append(" SD_Name = @SD_Name , ");
            strSql.Append(" SD_SDID = @SD_SDID , ");
            strSql.Append(" SD_Time = @SD_Time , ");
            strSql.Append(" SD_UserID = @SD_UserID , ");
            strSql.Append(" SD_CityID = @SD_CityID , ");
            strSql.Append(" SD_ProvinceId = @SD_ProvinceId , ");
            strSql.Append(" SD_Flag = @SD_Flag , ");
            strSql.Append(" SD_Mark = @SD_Mark  ");
            strSql.Append(" where SD_Id=@SD_Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@SD_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_SDID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_Time", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_UserID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SD_CityID", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@SD_ProvinceId", SqlDbType.DateTime) ,            
                        new SqlParameter("@SD_Flag", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@SD_Mark", SqlDbType.VarChar,255) ,
                        new SqlParameter("@SD_Id", SqlDbType.VarChar,255)   
              
            };

            parameters[0].Value = model.SD_Name;
            parameters[1].Value = model.SD_SDID;
            parameters[2].Value = model.SD_Time;
            parameters[3].Value = model.SD_UserID;
            parameters[4].Value = model.SD_CityID;
            parameters[5].Value = model.SD_ProvinceId;
            parameters[6].Value = model.SD_Flag;
            parameters[7].Value = model.SD_Mark;
            parameters[8].Value = model.SD_Id;
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
        public bool Delete(string SD_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ServiceDepartment ");
            strSql.Append(" where SD_Id=@SD_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@SD_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = SD_Id;


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
        public ServiceDepartmentInfo GetModel(string SD_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from ServiceDepartment ");
            strSql.Append(" where SD_Id=@SD_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@SD_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = SD_Id;


            ServiceDepartmentInfo model = new ServiceDepartmentInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SD_Id = Convert.ToInt32( ds.Tables[0].Rows[0]["SD_Id"].ToString());
                model.SD_Name = ds.Tables[0].Rows[0]["SD_Name"].ToString();
                model.SD_SDID = Convert.ToInt32(ds.Tables[0].Rows[0]["SD_SDID"].ToString());
                model.SD_Time = Convert.ToDateTime(ds.Tables[0].Rows[0]["SD_Time"].ToString());
                model.SD_UserID = ds.Tables[0].Rows[0]["SD_UserID"].ToString();
                model.SD_CityID = ds.Tables[0].Rows[0]["SD_CityID"].ToString();
                model.SD_ProvinceId = ds.Tables[0].Rows[0]["SD_ProvinceId"].ToString();
                model.SD_Flag = Convert.ToInt32(ds.Tables[0].Rows[0]["SD_Flag"].ToString());
                model.SD_Mark = Convert.ToInt32(ds.Tables[0].Rows[0]["SD_Mark"].ToString());

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
            strSql.Append(" FROM ServiceDepartment ");
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
            strSql.Append(" FROM ServiceDepartment ");
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

