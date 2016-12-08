using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //NewsInfo
    public partial class NewsInfoService
    {

        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NewsInfo GetModelByMID(string M_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID, N_Type, N_Order, N_Str1, N_Str2, N_Str3, N_Str4, M_ID, N_Title, N_Url, N_Img, N_Source, N_Author, N_Content, N_Time  ");
            strSql.Append("  from NewsInfo ");
            strSql.Append(" where M_ID=@M_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@M_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = M_ID;


            NewsInfo model = new NewsInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.N_ID = ds.Tables[0].Rows[0]["N_ID"].ToString();
                if (ds.Tables[0].Rows[0]["N_Type"].ToString() != "")
                {
                    model.N_Type = int.Parse(ds.Tables[0].Rows[0]["N_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_Order"].ToString() != "")
                {
                    model.N_Order = int.Parse(ds.Tables[0].Rows[0]["N_Order"].ToString());
                }
                model.N_Str1 = ds.Tables[0].Rows[0]["N_Str1"].ToString();
                model.N_Str2 = ds.Tables[0].Rows[0]["N_Str2"].ToString();
                model.N_Str3 = ds.Tables[0].Rows[0]["N_Str3"].ToString();
                model.N_Str4 = ds.Tables[0].Rows[0]["N_Str4"].ToString();
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                model.N_Title = ds.Tables[0].Rows[0]["N_Title"].ToString();
                model.N_Url = ds.Tables[0].Rows[0]["N_Url"].ToString();
                model.N_Img = ds.Tables[0].Rows[0]["N_Img"].ToString();
                model.N_Source = ds.Tables[0].Rows[0]["N_Source"].ToString();
                model.N_Author = ds.Tables[0].Rows[0]["N_Author"].ToString();
                model.N_Content = ds.Tables[0].Rows[0]["N_Content"].ToString();
                if (ds.Tables[0].Rows[0]["N_Time"].ToString() != "")
                {
                    model.N_Time = DateTime.Parse(ds.Tables[0].Rows[0]["N_Time"].ToString());
                }

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
                return DbHelperSQL.RunProcedure("NewsInfo_Page", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string N_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsInfo");
            strSql.Append(" where ");
            strSql.Append(" N_ID = @N_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@N_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = N_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(NewsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsInfo(");
            strSql.Append("N_ID,N_Type,N_Order,N_Str1,N_Str2,N_Str3,N_Str4,M_ID,N_Title,N_Url,N_Img,N_Source,N_Author,N_Content,N_Time");
            strSql.Append(") values (");
            strSql.Append("@N_ID,@N_Type,@N_Order,@N_Str1,@N_Str2,@N_Str3,@N_Str4,@M_ID,@N_Title,@N_Url,@N_Img,@N_Source,@N_Author,@N_Content,@N_Time");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@N_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Type", SqlDbType.Int,4) ,            
                        new SqlParameter("@N_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@N_Str1", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str2", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str3", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str4", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Title", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Url", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Img", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Source", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Author", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Content", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.N_ID;
            parameters[1].Value = model.N_Type;
            parameters[2].Value = model.N_Order;
            parameters[3].Value = model.N_Str1;
            parameters[4].Value = model.N_Str2;
            parameters[5].Value = model.N_Str3;
            parameters[6].Value = model.N_Str4;
            parameters[7].Value = model.M_ID;
            parameters[8].Value = model.N_Title;
            parameters[9].Value = model.N_Url;
            parameters[10].Value = model.N_Img;
            parameters[11].Value = model.N_Source;
            parameters[12].Value = model.N_Author;
            parameters[13].Value = model.N_Content;
            parameters[14].Value = model.N_Time;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(NewsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsInfo set ");

            strSql.Append(" N_ID = @N_ID , ");
            strSql.Append(" N_Type = @N_Type , ");
            strSql.Append(" N_Order = @N_Order , ");
            strSql.Append(" N_Str1 = @N_Str1 , ");
            strSql.Append(" N_Str2 = @N_Str2 , ");
            strSql.Append(" N_Str3 = @N_Str3 , ");
            strSql.Append(" N_Str4 = @N_Str4 , ");
            strSql.Append(" M_ID = @M_ID , ");
            strSql.Append(" N_Title = @N_Title , ");
            strSql.Append(" N_Url = @N_Url , ");
            strSql.Append(" N_Img = @N_Img , ");
            strSql.Append(" N_Source = @N_Source , ");
            strSql.Append(" N_Author = @N_Author , ");
            strSql.Append(" N_Content = @N_Content , ");
            strSql.Append(" N_Time = @N_Time  ");
            strSql.Append(" where N_ID=@N_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@N_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Type", SqlDbType.Int,4) ,            
                        new SqlParameter("@N_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@N_Str1", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str2", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str3", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Str4", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Title", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Url", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Img", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Source", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Author", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@N_Content", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@N_Time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.N_ID;
            parameters[1].Value = model.N_Type;
            parameters[2].Value = model.N_Order;
            parameters[3].Value = model.N_Str1;
            parameters[4].Value = model.N_Str2;
            parameters[5].Value = model.N_Str3;
            parameters[6].Value = model.N_Str4;
            parameters[7].Value = model.M_ID;
            parameters[8].Value = model.N_Title;
            parameters[9].Value = model.N_Url;
            parameters[10].Value = model.N_Img;
            parameters[11].Value = model.N_Source;
            parameters[12].Value = model.N_Author;
            parameters[13].Value = model.N_Content;
            parameters[14].Value = model.N_Time;
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
        public bool Delete(string N_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsInfo ");
            strSql.Append(" where N_ID=@N_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@N_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = N_ID;


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
        public NewsInfo GetModel(string N_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N_ID, N_Type, N_Order, N_Str1, N_Str2, N_Str3, N_Str4, M_ID, N_Title, N_Url, N_Img, N_Source, N_Author, N_Content, N_Time  ");
            strSql.Append("  from NewsInfo ");
            strSql.Append(" where N_ID=@N_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@N_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = N_ID;


            NewsInfo model = new NewsInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.N_ID = ds.Tables[0].Rows[0]["N_ID"].ToString();
                if (ds.Tables[0].Rows[0]["N_Type"].ToString() != "")
                {
                    model.N_Type = int.Parse(ds.Tables[0].Rows[0]["N_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_Order"].ToString() != "")
                {
                    model.N_Order = int.Parse(ds.Tables[0].Rows[0]["N_Order"].ToString());
                }
                model.N_Str1 = ds.Tables[0].Rows[0]["N_Str1"].ToString();
                model.N_Str2 = ds.Tables[0].Rows[0]["N_Str2"].ToString();
                model.N_Str3 = ds.Tables[0].Rows[0]["N_Str3"].ToString();
                model.N_Str4 = ds.Tables[0].Rows[0]["N_Str4"].ToString();
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                model.N_Title = ds.Tables[0].Rows[0]["N_Title"].ToString();
                model.N_Url = ds.Tables[0].Rows[0]["N_Url"].ToString();
                model.N_Img = ds.Tables[0].Rows[0]["N_Img"].ToString();
                model.N_Source = ds.Tables[0].Rows[0]["N_Source"].ToString();
                model.N_Author = ds.Tables[0].Rows[0]["N_Author"].ToString();
                model.N_Content = ds.Tables[0].Rows[0]["N_Content"].ToString();
                if (ds.Tables[0].Rows[0]["N_Time"].ToString() != "")
                {
                    model.N_Time = DateTime.Parse(ds.Tables[0].Rows[0]["N_Time"].ToString());
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
            strSql.Append(" FROM NewsInfo ");
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
            strSql.Append(" FROM NewsInfo ");
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

