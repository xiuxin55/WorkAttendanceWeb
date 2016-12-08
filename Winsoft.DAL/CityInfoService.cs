using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //MenuInfo
    public partial class CityInfoService
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
        //        return DbHelperSQL.RunProcedure("MenuInfo_Page", para).Tables[0];
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Exists(string CT_CityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from City");
            strSql.Append(" where ");
            strSql.Append(" CT_CityID = @CT_CityID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CT_CityID", SqlDbType.VarChar,255)			};
            parameters[0].Value = CT_CityID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public void Add(CityInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into City(")
        //    strSql.Append("M_ID,M_Time,M_PID,M_Name,M_Type,M_Level,M_Url,M_EUrl,M_Order,M_Remark");
        //    strSql.Append(") values (");
        //    strSql.Append("@M_ID,@M_Time,@M_PID,@M_Name,@M_Type,@M_Level,@M_Url,@M_EUrl,@M_Order,@M_Remark");
        //    strSql.Append(") ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Time", SqlDbType.DateTime) ,            
        //                new SqlParameter("@M_PID", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Name", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Type", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Level", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Url", SqlDbType.VarChar,-1) ,            
        //                new SqlParameter("@M_EUrl", SqlDbType.VarChar,-1) ,            
        //                new SqlParameter("@M_Order", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Remark", SqlDbType.VarChar,-1)             
              
        //    };

        //    parameters[0].Value = model.M_ID;
        //    parameters[1].Value = model.M_Time;
        //    parameters[2].Value = model.M_PID;
        //    parameters[3].Value = model.M_Name;
        //    parameters[4].Value = model.M_Type;
        //    parameters[5].Value = model.M_Level;
        //    parameters[6].Value = model.M_Url;
        //    parameters[7].Value = model.M_EUrl;
        //    parameters[8].Value = model.M_Order;
        //    parameters[9].Value = model.M_Remark;
        //    DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        //}


        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool Update(CityInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update MenuInfo set ");

        //    strSql.Append(" M_ID = @M_ID , ");
        //    strSql.Append(" M_Time = @M_Time , ");
        //    strSql.Append(" M_PID = @M_PID , ");
        //    strSql.Append(" M_Name = @M_Name , ");
        //    strSql.Append(" M_Type = @M_Type , ");
        //    strSql.Append(" M_Level = @M_Level , ");
        //    strSql.Append(" M_Url = @M_Url , ");
        //    strSql.Append(" M_EUrl = @M_EUrl , ");
        //    strSql.Append(" M_Order = @M_Order , ");
        //    strSql.Append(" M_Remark = @M_Remark  ");
        //    strSql.Append(" where M_ID=@M_ID  ");

        //    SqlParameter[] parameters = {
        //                new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Time", SqlDbType.DateTime) ,            
        //                new SqlParameter("@M_PID", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Name", SqlDbType.VarChar,255) ,            
        //                new SqlParameter("@M_Type", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Level", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Url", SqlDbType.VarChar,-1) ,            
        //                new SqlParameter("@M_EUrl", SqlDbType.VarChar,-1) ,            
        //                new SqlParameter("@M_Order", SqlDbType.Int,4) ,            
        //                new SqlParameter("@M_Remark", SqlDbType.VarChar,-1)             
              
        //    };

        //    parameters[0].Value = model.M_ID;
        //    parameters[1].Value = model.M_Time;
        //    parameters[2].Value = model.M_PID;
        //    parameters[3].Value = model.M_Name;
        //    parameters[4].Value = model.M_Type;
        //    parameters[5].Value = model.M_Level;
        //    parameters[6].Value = model.M_Url;
        //    parameters[7].Value = model.M_EUrl;
        //    parameters[8].Value = model.M_Order;
        //    parameters[9].Value = model.M_Remark;
        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 删除一条数据
        /// </summary>
        //public bool Delete(string M_ID)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("delete from MenuInfo ");
        //    strSql.Append(" where M_ID=@M_ID ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@M_ID", SqlDbType.VarChar,255)			};
        //    parameters[0].Value = M_ID;


        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CityInfo GetModel(string CT_CityID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from City ");
            strSql.Append(" where CT_CityID=@CT_CityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CT_CityID", SqlDbType.VarChar,255)			};
            parameters[0].Value = CT_CityID;


            CityInfo model = new CityInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CT_CityID = ds.Tables[0].Rows[0]["CT_CityID"].ToString();
                model.CT_CityName = ds.Tables[0].Rows[0]["[CT_CityName]"].ToString();
                model.CT_ProvinceID = ds.Tables[0].Rows[0]["CT_ProvinceID"].ToString();

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
            strSql.Append(" FROM City ");
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
            strSql.Append(" FROM City ");
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

