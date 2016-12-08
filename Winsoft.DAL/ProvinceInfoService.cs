using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //ProvinceInfo
    public partial class ProvinceInfoService
    {

        #region 自定义方法

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public ProvinceInfo GetModel(string PV_ProvinceID)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select VH_ID, V_ID, VH_IP, VH_Time  ");
        //    strSql.Append("  from ProvinceInfo ");
        //    strSql.Append(" where V_ID=@V_ID and VH_IP=@VH_IP ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@V_ID", SqlDbType.VarChar,255),
        //            new SqlParameter("@VH_IP", SqlDbType.VarChar,255)};
        //    parameters[0].Value = V_ID;
        //    parameters[1].Value = VH_IP;


        //    ProvinceInfo model = new ProvinceInfo();
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        model.VH_ID = ds.Tables[0].Rows[0]["VH_ID"].ToString();
        //        model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
        //        model.VH_IP = ds.Tables[0].Rows[0]["VH_IP"].ToString();
        //        if (ds.Tables[0].Rows[0]["VH_Time"].ToString() != "")
        //        {
        //            model.VH_Time = DateTime.Parse(ds.Tables[0].Rows[0]["VH_Time"].ToString());
        //        }

        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

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
        //        return DbHelperSQL.RunProcedure("VidoHistoryInfo_Page", para).Tables[0];
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Exists(string PV_ProvinceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProvinceInfo");
            strSql.Append(" where ");
            strSql.Append(" PV_ProvinceID = @PV_ProvinceID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@PV_ProvinceID", SqlDbType.VarChar,255)			};
            parameters[0].Value = PV_ProvinceID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ProvinceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProvinceInfo(");
            strSql.Append("PV_ProvinceID,PV_ProvinceName");
            strSql.Append(") values (");
            strSql.Append("@PV_ProvinceID,@PV_ProvinceName");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PV_ProvinceID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PV_ProvinceName", SqlDbType.VarChar,255)
              
            };

            parameters[0].Value = model.PV_ProvinceID;
            parameters[1].Value = model.PV_ProvinceName;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProvinceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProvinceInfo set ");

            strSql.Append(" PV_ProvinceID = @PV_ProvinceID , ");
            strSql.Append(" PV_ProvinceName = @PV_ProvinceName  ");
            strSql.Append(" where PV_ProvinceID=@PV_ProvinceID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PV_ProvinceID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PV_ProvinceName", SqlDbType.VarChar,255)  
              
            };

            parameters[0].Value = model.PV_ProvinceID;
            parameters[1].Value = model.PV_ProvinceName;
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
        public bool Delete(string PV_ProvinceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProvinceInfo ");
            strSql.Append(" where PV_ProvinceID=@PV_ProvinceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PV_ProvinceID", SqlDbType.VarChar,255)			};
            parameters[0].Value = PV_ProvinceID;


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
        public ProvinceInfo GetModel(string PV_ProvinceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from ProvinceInfo ");
            strSql.Append(" where PV_ProvinceID=@PV_ProvinceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PV_ProvinceID", SqlDbType.VarChar,255)			};
            parameters[0].Value = PV_ProvinceID;


            ProvinceInfo model = new ProvinceInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PV_ProvinceID = ds.Tables[0].Rows[0]["PV_ProvinceID"].ToString();
                model.PV_ProvinceName = ds.Tables[0].Rows[0]["PV_ProvinceID"].ToString();
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
            strSql.Append(" FROM ProvinceInfo ");
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
            strSql.Append(" FROM ProvinceInfo ");
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

