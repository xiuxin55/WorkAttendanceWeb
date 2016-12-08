using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //VidoLessonInfo
    public partial class VidoLessonInfoService
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
                return DbHelperSQL.RunProcedure("VidoLessonInfo_Page", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string VL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VidoLessonInfo");
            strSql.Append(" where ");
            strSql.Append(" VL_ID = @VL_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@VL_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = VL_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(VidoLessonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VidoLessonInfo(");
            strSql.Append("VL_ID,V_ID,VL_Name,VL_Vido,VL_SmallImg,VL_BigImg,VL_Length,VL_Order,VL_Time");
            strSql.Append(") values (");
            strSql.Append("@VL_ID,@V_ID,@VL_Name,@VL_Vido,@VL_SmallImg,@VL_BigImg,@VL_Length,@VL_Order,@VL_Time");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@VL_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Vido", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_SmallImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_BigImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_Length", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@VL_Time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.VL_ID;
            parameters[1].Value = model.V_ID;
            parameters[2].Value = model.VL_Name;
            parameters[3].Value = model.VL_Vido;
            parameters[4].Value = model.VL_SmallImg;
            parameters[5].Value = model.VL_BigImg;
            parameters[6].Value = model.VL_Length;
            parameters[7].Value = model.VL_Order;
            parameters[8].Value = model.VL_Time;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(VidoLessonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VidoLessonInfo set ");

            strSql.Append(" VL_ID = @VL_ID , ");
            strSql.Append(" V_ID = @V_ID , ");
            strSql.Append(" VL_Name = @VL_Name , ");
            strSql.Append(" VL_Vido = @VL_Vido , ");
            strSql.Append(" VL_SmallImg = @VL_SmallImg , ");
            strSql.Append(" VL_BigImg = @VL_BigImg , ");
            strSql.Append(" VL_Length = @VL_Length , ");
            strSql.Append(" VL_Order = @VL_Order , ");
            strSql.Append(" VL_Time = @VL_Time  ");
            strSql.Append(" where VL_ID=@VL_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@VL_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Vido", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_SmallImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_BigImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@VL_Length", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@VL_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@VL_Time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.VL_ID;
            parameters[1].Value = model.V_ID;
            parameters[2].Value = model.VL_Name;
            parameters[3].Value = model.VL_Vido;
            parameters[4].Value = model.VL_SmallImg;
            parameters[5].Value = model.VL_BigImg;
            parameters[6].Value = model.VL_Length;
            parameters[7].Value = model.VL_Order;
            parameters[8].Value = model.VL_Time;
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
        public bool Delete(string VL_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VidoLessonInfo ");
            strSql.Append(" where VL_ID=@VL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@VL_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = VL_ID;


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
        public VidoLessonInfo GetModel(string VL_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VL_ID, V_ID, VL_Name, VL_Vido, VL_SmallImg, VL_BigImg, VL_Length, VL_Order, VL_Time  ");
            strSql.Append("  from VidoLessonInfo ");
            strSql.Append(" where VL_ID=@VL_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@VL_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = VL_ID;


            VidoLessonInfo model = new VidoLessonInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.VL_ID = ds.Tables[0].Rows[0]["VL_ID"].ToString();
                model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
                model.VL_Name = ds.Tables[0].Rows[0]["VL_Name"].ToString();
                model.VL_Vido = ds.Tables[0].Rows[0]["VL_Vido"].ToString();
                model.VL_SmallImg = ds.Tables[0].Rows[0]["VL_SmallImg"].ToString();
                model.VL_BigImg = ds.Tables[0].Rows[0]["VL_BigImg"].ToString();
                model.VL_Length = ds.Tables[0].Rows[0]["VL_Length"].ToString();
                if (ds.Tables[0].Rows[0]["VL_Order"].ToString() != "")
                {
                    model.VL_Order = int.Parse(ds.Tables[0].Rows[0]["VL_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VL_Time"].ToString() != "")
                {
                    model.VL_Time = DateTime.Parse(ds.Tables[0].Rows[0]["VL_Time"].ToString());
                }

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
            strSql.Append(" FROM VidoLessonInfo ");
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
            strSql.Append(" FROM VidoLessonInfo ");
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

