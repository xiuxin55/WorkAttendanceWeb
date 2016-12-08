using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //VidoInfo
    public partial class VidoInfoService
    {

        #region 自定义方法

        /// <summary>
        ///  关键词查询
        /// </summary>
        public DataTable GetPageKeyword(int topcount, string keyword, string strWhere)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@topcount",topcount),
                    new SqlParameter("@keyword",keyword),
                    new SqlParameter("@strWhere",strWhere)
                };
                return DbHelperSQL.RunProcedure("VidoInfo_PageKeyword", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
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
                return DbHelperSQL.RunProcedure("VidoInfo_Page", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string V_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VidoInfo");
            strSql.Append(" where ");
            strSql.Append(" V_ID = @V_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@V_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = V_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(VidoInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VidoInfo(");
            strSql.Append("V_ID,V_SmallImg,V_BigImg,V_LessonCount,V_BuyCount,V_BuyCountReal,V_PlayCount,V_PlayCountReal,V_BrowseCount,V_BrowseCountReal,V_CollectionCount,M_ID,V_CollectionCountReal,V_Time,VT_ID,V_Code,V_Name,V_Keyword,V_Content,V_Price,V_NewPrice");
            strSql.Append(") values (");
            strSql.Append("@V_ID,@V_SmallImg,@V_BigImg,@V_LessonCount,@V_BuyCount,@V_BuyCountReal,@V_PlayCount,@V_PlayCountReal,@V_BrowseCount,@V_BrowseCountReal,@V_CollectionCount,@M_ID,@V_CollectionCountReal,@V_Time,@VT_ID,@V_Code,@V_Name,@V_Keyword,@V_Content,@V_Price,@V_NewPrice");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_SmallImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_BigImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_LessonCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BuyCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BuyCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_PlayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_PlayCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BrowseCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BrowseCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_CollectionCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_CollectionCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@VT_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Code", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Keyword", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_Content", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@V_NewPrice", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.V_ID;
            parameters[1].Value = model.V_SmallImg;
            parameters[2].Value = model.V_BigImg;
            parameters[3].Value = model.V_LessonCount;
            parameters[4].Value = model.V_BuyCount;
            parameters[5].Value = model.V_BuyCountReal;
            parameters[6].Value = model.V_PlayCount;
            parameters[7].Value = model.V_PlayCountReal;
            parameters[8].Value = model.V_BrowseCount;
            parameters[9].Value = model.V_BrowseCountReal;
            parameters[10].Value = model.V_CollectionCount;
            parameters[11].Value = model.M_ID;
            parameters[12].Value = model.V_CollectionCountReal;
            parameters[13].Value = model.V_Time;
            parameters[14].Value = model.VT_ID;
            parameters[15].Value = model.V_Code;
            parameters[16].Value = model.V_Name;
            parameters[17].Value = model.V_Keyword;
            parameters[18].Value = model.V_Content;
            parameters[19].Value = model.V_Price;
            parameters[20].Value = model.V_NewPrice;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(VidoInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VidoInfo set ");

            strSql.Append(" V_ID = @V_ID , ");
            strSql.Append(" V_SmallImg = @V_SmallImg , ");
            strSql.Append(" V_BigImg = @V_BigImg , ");
            strSql.Append(" V_LessonCount = @V_LessonCount , ");
            strSql.Append(" V_BuyCount = @V_BuyCount , ");
            strSql.Append(" V_BuyCountReal = @V_BuyCountReal , ");
            strSql.Append(" V_PlayCount = @V_PlayCount , ");
            strSql.Append(" V_PlayCountReal = @V_PlayCountReal , ");
            strSql.Append(" V_BrowseCount = @V_BrowseCount , ");
            strSql.Append(" V_BrowseCountReal = @V_BrowseCountReal , ");
            strSql.Append(" V_CollectionCount = @V_CollectionCount , ");
            strSql.Append(" M_ID = @M_ID , ");
            strSql.Append(" V_CollectionCountReal = @V_CollectionCountReal , ");
            strSql.Append(" V_Time = @V_Time , ");
            strSql.Append(" VT_ID = @VT_ID , ");
            strSql.Append(" V_Code = @V_Code , ");
            strSql.Append(" V_Name = @V_Name , ");
            strSql.Append(" V_Keyword = @V_Keyword , ");
            strSql.Append(" V_Content = @V_Content , ");
            strSql.Append(" V_Price = @V_Price , ");
            strSql.Append(" V_NewPrice = @V_NewPrice  ");
            strSql.Append(" where V_ID=@V_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_SmallImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_BigImg", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_LessonCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BuyCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BuyCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_PlayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_PlayCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BrowseCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_BrowseCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_CollectionCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_CollectionCountReal", SqlDbType.Int,4) ,            
                        new SqlParameter("@V_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@VT_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Code", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Name", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@V_Keyword", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_Content", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@V_Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@V_NewPrice", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.V_ID;
            parameters[1].Value = model.V_SmallImg;
            parameters[2].Value = model.V_BigImg;
            parameters[3].Value = model.V_LessonCount;
            parameters[4].Value = model.V_BuyCount;
            parameters[5].Value = model.V_BuyCountReal;
            parameters[6].Value = model.V_PlayCount;
            parameters[7].Value = model.V_PlayCountReal;
            parameters[8].Value = model.V_BrowseCount;
            parameters[9].Value = model.V_BrowseCountReal;
            parameters[10].Value = model.V_CollectionCount;
            parameters[11].Value = model.M_ID;
            parameters[12].Value = model.V_CollectionCountReal;
            parameters[13].Value = model.V_Time;
            parameters[14].Value = model.VT_ID;
            parameters[15].Value = model.V_Code;
            parameters[16].Value = model.V_Name;
            parameters[17].Value = model.V_Keyword;
            parameters[18].Value = model.V_Content;
            parameters[19].Value = model.V_Price;
            parameters[20].Value = model.V_NewPrice;
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
        public bool Delete(string V_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VidoInfo ");
            strSql.Append(" where V_ID=@V_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@V_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = V_ID;


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
        public VidoInfo GetModel(string V_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select V_ID, V_SmallImg, V_BigImg, V_LessonCount, V_BuyCount, V_BuyCountReal, V_PlayCount, V_PlayCountReal, V_BrowseCount, V_BrowseCountReal, V_CollectionCount, M_ID, V_CollectionCountReal, V_Time, VT_ID, V_Code, V_Name, V_Keyword, V_Content, V_Price, V_NewPrice  ");
            strSql.Append("  from VidoInfo ");
            strSql.Append(" where V_ID=@V_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@V_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = V_ID;


            VidoInfo model = new VidoInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
                model.V_SmallImg = ds.Tables[0].Rows[0]["V_SmallImg"].ToString();
                model.V_BigImg = ds.Tables[0].Rows[0]["V_BigImg"].ToString();
                if (ds.Tables[0].Rows[0]["V_LessonCount"].ToString() != "")
                {
                    model.V_LessonCount = int.Parse(ds.Tables[0].Rows[0]["V_LessonCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_BuyCount"].ToString() != "")
                {
                    model.V_BuyCount = int.Parse(ds.Tables[0].Rows[0]["V_BuyCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_BuyCountReal"].ToString() != "")
                {
                    model.V_BuyCountReal = int.Parse(ds.Tables[0].Rows[0]["V_BuyCountReal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_PlayCount"].ToString() != "")
                {
                    model.V_PlayCount = int.Parse(ds.Tables[0].Rows[0]["V_PlayCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_PlayCountReal"].ToString() != "")
                {
                    model.V_PlayCountReal = int.Parse(ds.Tables[0].Rows[0]["V_PlayCountReal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_BrowseCount"].ToString() != "")
                {
                    model.V_BrowseCount = int.Parse(ds.Tables[0].Rows[0]["V_BrowseCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_BrowseCountReal"].ToString() != "")
                {
                    model.V_BrowseCountReal = int.Parse(ds.Tables[0].Rows[0]["V_BrowseCountReal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_CollectionCount"].ToString() != "")
                {
                    model.V_CollectionCount = int.Parse(ds.Tables[0].Rows[0]["V_CollectionCount"].ToString());
                }
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                if (ds.Tables[0].Rows[0]["V_CollectionCountReal"].ToString() != "")
                {
                    model.V_CollectionCountReal = int.Parse(ds.Tables[0].Rows[0]["V_CollectionCountReal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_Time"].ToString() != "")
                {
                    model.V_Time = DateTime.Parse(ds.Tables[0].Rows[0]["V_Time"].ToString());
                }
                model.VT_ID = ds.Tables[0].Rows[0]["VT_ID"].ToString();
                model.V_Code = ds.Tables[0].Rows[0]["V_Code"].ToString();
                model.V_Name = ds.Tables[0].Rows[0]["V_Name"].ToString();
                model.V_Keyword = ds.Tables[0].Rows[0]["V_Keyword"].ToString();
                model.V_Content = ds.Tables[0].Rows[0]["V_Content"].ToString();
                if (ds.Tables[0].Rows[0]["V_Price"].ToString() != "")
                {
                    model.V_Price = decimal.Parse(ds.Tables[0].Rows[0]["V_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["V_NewPrice"].ToString() != "")
                {
                    model.V_NewPrice = decimal.Parse(ds.Tables[0].Rows[0]["V_NewPrice"].ToString());
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
            strSql.Append(" FROM VidoInfo ");
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
            strSql.Append(" FROM VidoInfo ");
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

