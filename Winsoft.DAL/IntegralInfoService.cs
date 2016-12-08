using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //VidoLiveInfo
    public partial class IntegralInfoService
    {

        #region 自定义方法



        #endregion

        #region method

        /// <summary>
        ///  分页查询
        /// </summary>
        public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@pageSize",pageSize),
                    new SqlParameter("@pageIndex",pageIndex),
                    new SqlParameter("@strWhere",strWhere),
                    new SqlParameter("@fdlOrder",fdlOrder),
                    new SqlParameter("@isCount",isCount)
                };
                return DbHelperSQL.RunProcedure("VidoLiveInfo_Page", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string IN_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Integral");
            strSql.Append(" where ");
            strSql.Append(" IN_Id = @IN_Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@IN_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = IN_Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(IntegralInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Integral(");
            strSql.Append("IN_SDID,IN_UserID,IN_Sores,IN_Time,IN_Count,IN_ModelScoerID,IN_Authentication");
            strSql.Append(") values (");
            strSql.Append("@IN_SDID,@IN_UserID,@IN_Sores,@IN_Time,@IN_Count,@IN_ModelScoerID,@IN_Authentication");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@IN_SDID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@IN_UserID", SqlDbType.Int) ,            
                        new SqlParameter("@IN_Sores", SqlDbType.Int) ,            
                        new SqlParameter("@IN_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@IN_Count", SqlDbType.Int) ,            
                        new SqlParameter("@IN_ModelScoerID", SqlDbType.VarChar,255) ,
                        new SqlParameter("@IN_Authentication", SqlDbType.VarChar,255)
              
            };

            parameters[0].Value = model.IN_SDID;
            parameters[1].Value = model.IN_UserID;
            parameters[2].Value = model.IN_Sores;
            parameters[3].Value = model.IN_Time;
            parameters[4].Value = model.IN_Count;
            parameters[5].Value = model.IN_ModelScoerID;
            parameters[6].Value = model.IN_Authentication;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IntegralInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Integral set ");

            strSql.Append(" IN_SDID = @IN_SDID , ");
            strSql.Append(" IN_UserID = @IN_UserID , ");
            strSql.Append(" IN_Sores = @IN_Sores , ");
            strSql.Append(" IN_Time = @IN_Time , ");
            strSql.Append(" IN_Count = @IN_Count , ");
            strSql.Append(" IN_ModelScoerID = @IN_ModelScoerID  ");
            strSql.Append(" IN_Authentication = @IN_Authentication  ");
            strSql.Append(" where IN_Id=@IN_Id  ");

            SqlParameter[] parameters = {
			           new SqlParameter("@IN_SDID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@IN_UserID", SqlDbType.Int) ,            
                        new SqlParameter("@IN_Sores", SqlDbType.Int) ,            
                        new SqlParameter("@IN_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@IN_Count", SqlDbType.Int) ,            
                        new SqlParameter("@IN_ModelScoerID", SqlDbType.VarChar,255) ,
                        new SqlParameter("@IN_Authentication", SqlDbType.VarChar,255),
                        new SqlParameter("@IN_Id", SqlDbType.Int)             
            };

            parameters[0].Value = model.IN_SDID;
            parameters[1].Value = model.IN_UserID;
            parameters[2].Value = model.IN_Sores;
            parameters[3].Value = model.IN_Time;
            parameters[4].Value = model.IN_Count;
            parameters[5].Value = model.IN_ModelScoerID;
            parameters[6].Value = model.IN_Authentication;
            parameters[7].Value = model.IN_Id;
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
        public bool Delete(string IN_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Integral ");
            strSql.Append(" where IN_Id=@IN_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@IN_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = IN_Id;


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
        public IntegralInfo GetModel(string IN_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from Integral ");
            strSql.Append(" where IN_Id=@IN_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@IN_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = IN_Id;


            IntegralInfo model = new IntegralInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.IN_Id =Convert.ToInt32(ds.Tables[0].Rows[0]["IN_Id"].ToString());
                model.IN_SDID = ds.Tables[0].Rows[0]["IN_SDID"].ToString();
                model.IN_UserID = ds.Tables[0].Rows[0]["IN_UserID"].ToString();
                model.IN_Sores = Convert.ToInt32(ds.Tables[0].Rows[0]["IN_Sores"].ToString());
                if (ds.Tables[0].Rows[0]["IN_Time"].ToString() != "")
                {
                    model.IN_Time = DateTime.Parse(ds.Tables[0].Rows[0]["IN_Time"].ToString());
                }
                model.IN_Count = Convert.ToInt32(ds.Tables[0].Rows[0]["IN_Count"].ToString());
                model.IN_ModelScoerID = ds.Tables[0].Rows[0]["IN_ModelScoerID"].ToString();
                model.IN_Authentication = ds.Tables[0].Rows[0]["IN_Authentication"].ToString();
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
            strSql.Append(" FROM Integral ");
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
            strSql.Append(" FROM Integral ");
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

