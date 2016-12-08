using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;

namespace Winsoft.DAL
{
   public class WebsiteServer
    {
        #region 自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public WebSiteModel GetModelByWebsite(string WebsiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from Website ");
            strSql.Append(" where WebsiteID=@WebsiteID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebsiteID", SqlDbType.VarChar,255)			};
            parameters[0].Value = WebsiteID;
            WebSiteModel model = new WebSiteModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WebsiteID = ds.Tables[0].Rows[0]["WebsiteID"].ToString();
                model.WebsiteName = ds.Tables[0].Rows[0]["WebsiteName"].ToString();

                model.WebsiteFlag = ds.Tables[0].Rows[0]["WebsiteFlag"].ToString();
                model.WebsiteFlag = ds.Tables[0].Rows[0]["WebsiteType"].ToString();
                
                return model;
            }
            else
            {
                return null;
            }
        }

       public WebSiteModel GetModelByWebsiteName(string WebsiteName)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select *  ");
           strSql.Append("  from Website ");
           strSql.Append(" where WebsiteName=@WebsiteName ");
           SqlParameter[] parameters = {
					new SqlParameter("@WebsiteName", SqlDbType.VarChar,255)			};
           parameters[0].Value = WebsiteName;
           WebSiteModel model = new WebSiteModel();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

           if (ds.Tables[0].Rows.Count > 0)
           {
               model.WebsiteID = ds.Tables[0].Rows[0]["WebsiteID"].ToString();
               model.WebsiteName = ds.Tables[0].Rows[0]["WebsiteName"].ToString();

               model.WebsiteFlag = ds.Tables[0].Rows[0]["WebsiteFlag"].ToString();
               model.WebsiteType = ds.Tables[0].Rows[0]["WebsiteType"].ToString();

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
        public DataTable GetPageList(int pageSize, int pageIndex, string TableName, string PrimaryKey, string FieldList, string strWhere, string fdlOrder, int isCount, int isPageCount)
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

        public bool ExistsByWebSiteID(string WebSiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [WebSite]");
            strSql.Append(" where ");
            strSql.Append(" WebSiteID = @WebSiteID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebSiteID", SqlDbType.VarChar,255)
                                        };
            parameters[0].Value = WebSiteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebSiteModel model)
        {
            PrizeInfoService ps = new PrizeInfoService();
            DataSet ds = ps.GetPrize();
            if (ds.Tables.Count > 0)
            {
                PrizeAllocateModel pam = new PrizeAllocateModel();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    pam.PrizeID = item["PrizeID"].ToString();
                    pam.PrizeName = item["PrizeName"].ToString();
                    pam.WebsiteID = model.WebsiteID;
                    pam.WebsiteName = model.WebsiteName;
                    pam.PrizeCount = 0;
                    pam.PrizeScore = "0";
                    ps.Add(pam);
                }
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Website](");
            strSql.Append(@"WebsiteID,WebsiteName,WebsiteFlag,WebsiteType");
            strSql.Append(") values (");
            strSql.Append(@"@WebsiteID,@WebsiteName,@WebsiteFlag,@WebsiteType");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@WebsiteID", SqlDbType.VarChar,255) , 
                        new SqlParameter("@WebsiteName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@WebsiteFlag", SqlDbType.VarChar,255) ,
                         new SqlParameter("@WebsiteType", SqlDbType.VarChar,255) 
            };
            parameters[0].Value = model.WebsiteID;
            parameters[1].Value = model.WebsiteName;
            parameters[2].Value = model.WebsiteFlag;
            parameters[3].Value = model.WebsiteType;
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
        public bool Update(WebSiteModel model, string id, string oldwebsitename)
        {
          
          
            string str = @"update [dbo].[User] set [US_WebsiteName]='" + model.WebsiteName + "' where US_WebsiteName='" + oldwebsitename + "'";
            string str2 = @"update [dbo].[PrizeAllocateModel] set [WebsiteID]='" + model.WebsiteID + "',[WebsiteName]='" + model.WebsiteName + "' where [WebsiteID]='"+id+"'";
            DbHelperSQL.ExecuteSql(str);
            DbHelperSQL.ExecuteSql(str2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [WebSite] set ");
            strSql.Append(" WebsiteID = @WebsiteID , ");
            strSql.Append(" WebsiteName = @WebsiteName , ");
            strSql.Append(" WebsiteFlag = @WebsiteFlag , ");
            strSql.Append(" WebsiteType = @WebsiteType  ");
            strSql.Append("where WebsiteID = @id ");
            SqlParameter[] parameters = {
                        new SqlParameter("@WebsiteID", SqlDbType.VarChar,255) , 
                        new SqlParameter("@WebsiteName", SqlDbType.VarChar,255) , 
                        new SqlParameter("@WebsiteFlag", SqlDbType.VarChar,255) , 
                        new SqlParameter("@WebsiteType", SqlDbType.VarChar,255),
               new SqlParameter("@id", SqlDbType.VarChar,255)
            };
            parameters[0].Value = model.WebsiteID;
            parameters[1].Value = model.WebsiteName;
            parameters[2].Value = model.WebsiteFlag;
            parameters[3].Value = model.WebsiteType;
            parameters[4].Value = id;
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
        public bool Delete(string WebsiteID)
        {
            string str = @"delete from [PrizeAllocateModel] where [WebsiteID]='" + WebsiteID + "'";
            DbHelperSQL.ExecuteSql(str);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Website] ");
            strSql.Append(" where WebsiteID=@WebsiteID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebsiteID", SqlDbType.VarChar,255)			};
            parameters[0].Value = WebsiteID;


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
        public WebSiteModel GetModel(string WebsiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebsiteID, WebsiteName,WebsiteFlag,WebsiteType");
            strSql.Append("  from [Website] ");
            strSql.Append(" where WebsiteID=@WebsiteID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebsiteID", SqlDbType.VarChar,255)			};
            parameters[0].Value = WebsiteID;


            WebSiteModel model = new WebSiteModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WebsiteID = ds.Tables[0].Rows[0]["WebsiteID"].ToString();
                model.WebsiteName = ds.Tables[0].Rows[0]["WebsiteName"].ToString();
                model.WebsiteFlag = ds.Tables[0].Rows[0]["WebsiteFlag"].ToString();
                model.WebsiteType = ds.Tables[0].Rows[0]["WebsiteType"].ToString();
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
            strSql.Append(" FROM [Website] ");
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
            strSql.Append(" FROM [Website] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
