using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //PrizeExchange
    public partial class PrizeExchangeInfoService
    {

        #region 自定义方法



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
            return DBHelpService.GetPageList(pageSize, pageIndex, TableName, PrimaryKey, FieldList, strWhere, fdlOrder, isCount, isPageCount);
        }
        public DataTable GetPrizeNameList(string WebsiteID)
        {
            string strSql = @"select [PrizeID],[PrizeName],[WebsiteID] ,[PrizeCount] ,[PrizeScore],[WebsiteName] from dbo.PrizeAllocateModel where WebsiteID='" + WebsiteID + "' and PrizeCount>0";
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0)
            { return ds.Tables[0]; }
            return null;
        }
        public bool UpdatePrizeCount(PrizeAllocateModel p, PrizeExchangeInfo ModelData,int i)
        {
            string strsql = string.Format(@"update PrizeAllocateModel set  PrizeCount=PrizeCount+({2}) where WebsiteID='{0}' and PrizeID='{1}' ;
                             update PrizeInfo set PrizeLeftAmount=convert(int,PrizeLeftAmount)+({2}),PrizeUsedAmount=convert(int,PrizeUsedAmount)-({2}) where PrizeID='{1}'
                             ", p.WebsiteID, p.PrizeID,i);
            
            if (DbHelperSQL.ExecuteSql(strsql) > 0 && Update(ModelData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Exists(string Prize_Guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PrizeExchange");
            strSql.Append(" where ");
            strSql.Append(" Prize_Guid = @Prize_Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Prize_Guid", SqlDbType.VarChar,255)
                                        };
            parameters[0].Value = Prize_Guid;


            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(PrizeExchangeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PrizeExchange(");
            strSql.Append(@"[Prize_Guid] ,[Prize_CardNum] ,[Prize_IdentifyCard] ,[Prize_Name] ,[Prize_Flag] ,[Prize_GetUserName] ,[Prize_GetUserContact] ,[Prize_GetUserIdentifyCard]
            ,[Prize_GetPrizeName] ,[Pize_GetPrizeDateTime] ,[Pize_GetPrizeTime] ,[Pize_PushCom] ,[Pize_PushComNum] ,[Pize_PushPerson] ,[Pize_PushPersonNum],Pize_WebsiteNum,Pize_UserNum,Prize_user,Pize_PrizeID");
            strSql.Append(") values (");
            strSql.Append(@"@Prize_Guid,@Prize_CardNum,@Prize_IdentifyCard,@Prize_Name,@Prize_Flag,@Prize_GetUserName,@Prize_GetUserContact,@Prize_GetUserIdentifyCard
                ,@Prize_GetPrizeName,@Pize_GetPrizeDateTime,   @Pize_GetPrizeTime,@Pize_PushCom,@Pize_PushComNum,@Pize_PushPerson,@Pize_PushPersonNum,@Pize_WebsiteNum,@Pize_UserNum,@Prize_user,@Pize_PrizeID");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Prize_Guid", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_CardNum",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_IdentifyCard", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_Name",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_Flag",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_GetUserName",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_GetUserContact", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Prize_GetUserIdentifyCard", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Prize_GetPrizeName", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_GetPrizeDateTime", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_GetPrizeTime",  SqlDbType.VarChar,255),

                               new SqlParameter("@Pize_PushCom", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Pize_PushComNum", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_PushPerson", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_PushPersonNum", SqlDbType.VarChar,255),
                        new SqlParameter("@Pize_WebsiteNum", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_UserNum", SqlDbType.VarChar,255)   ,
                        new SqlParameter("@Prize_user", SqlDbType.VarChar,255)  ,
                         new SqlParameter("@Pize_PrizeID", SqlDbType.VarChar,255)
         
              
            };

            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = model.Prize_CardNum ;
            parameters[2].Value = model.Prize_IdentifyCard;
            parameters[3].Value = model.Prize_Name;
            parameters[4].Value = model.Prize_Flag;
            parameters[5].Value = model.Prize_GetUserName;
            parameters[6].Value = model.Prize_GetUserContact;
            parameters[7].Value = model.Prize_GetUserIdentifyCard;
            parameters[8].Value = model.Prize_GetPrizeName;
            parameters[9].Value = model.Pize_GetPrizeDateTime;
            parameters[10].Value = model.Pize_GetPrizeTime;
            parameters[11].Value = model.Pize_PushCom;
            parameters[12].Value = model.Pize_PushComNum;
            parameters[13].Value = model.Pize_PushPerson;
            parameters[14].Value = model.Pize_PushPersonNum;
            parameters[15].Value = model.Pize_WebsiteNum;
            parameters[16].Value = model.Pize_UserNum;
            parameters[17].Value = model.Prize_user;
            parameters[18].Value = model.Pize_PrizeID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        public bool UpdateRow(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PrizeExchange set ");
          
            strSql.Append(" Prize_Flag = @Prize_Flag ");
        
            strSql.Append(" where Prize_Guid=@Prize_Guid  ");
            SqlParameter[] parameters = {
			            new SqlParameter("@Prize_Guid", SqlDbType.VarChar,255) ,            
                         
                        new SqlParameter("@Prize_Flag",  SqlDbType.VarChar,255)           
                        
         
              
            };

            parameters[0].Value =id;
            parameters[1].Value = "2";
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
        public bool Update(PrizeExchangeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PrizeExchange set ");
            strSql.Append(" Prize_CardNum = @Prize_CardNum , ");
            strSql.Append(" Prize_IdentifyCard = @Prize_IdentifyCard , ");
            strSql.Append(" Prize_Name = @Prize_Name , ");
            strSql.Append(" Prize_Flag = @Prize_Flag , ");
            strSql.Append(" Prize_GetUserName = @Prize_GetUserName , ");
            strSql.Append(" Prize_GetUserContact = @Prize_GetUserContact , ");
            strSql.Append(" Prize_GetUserIdentifyCard = @Prize_GetUserIdentifyCard , ");
            strSql.Append(" Prize_GetPrizeName = @Prize_GetPrizeName , ");
            strSql.Append(" Pize_GetPrizeDateTime = @Pize_GetPrizeDateTime , ");
            strSql.Append(" Pize_GetPrizeTime = @Pize_GetPrizeTime , ");
       


            strSql.Append(" Pize_PushCom = @Pize_PushCom , ");
            strSql.Append(" Pize_PushComNum = @Pize_PushComNum , ");
            strSql.Append(" Pize_PushPerson = @Pize_PushPerson,  ");
            strSql.Append(" Pize_PushPersonNum = @Pize_PushPersonNum,  ");
            strSql.Append(" Pize_UserNum = @Pize_UserNum,  ");
            strSql.Append(" Pize_WebsiteNum = @Pize_WebsiteNum , ");
            strSql.Append(" Pize_PrizeID = @Pize_PrizeID  ");
            strSql.Append(" where Prize_Guid=@Prize_Guid  ");
            SqlParameter[] parameters = {
			            new SqlParameter("@Prize_Guid", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_CardNum",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_IdentifyCard", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_Name",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_Flag",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_GetUserName",  SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Prize_GetUserContact", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Prize_GetUserIdentifyCard", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Prize_GetPrizeName", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_GetPrizeDateTime",  SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_GetPrizeTime",  SqlDbType.VarChar,255),

                               new SqlParameter("@Pize_PushCom", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Pize_PushComNum", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_PushPerson", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_PushPersonNum", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_WebsiteNum", SqlDbType.VarChar,255)  ,
                        new SqlParameter("@Pize_UserNum", SqlDbType.VarChar,255)  ,
                          new SqlParameter("@Pize_PrizeID", SqlDbType.VarChar,255)  
         
              
            };

            parameters[0].Value = model.Prize_Guid;
            parameters[1].Value = model.Prize_CardNum;
            parameters[2].Value = model.Prize_IdentifyCard;
            parameters[3].Value = model.Prize_Name;
            parameters[4].Value = model.Prize_Flag;
            parameters[5].Value = model.Prize_GetUserName;
            parameters[6].Value = model.Prize_GetUserContact;
            parameters[7].Value = model.Prize_GetUserIdentifyCard;
            parameters[8].Value = model.Prize_GetPrizeName;
            parameters[9].Value = model.Pize_GetPrizeDateTime;
            parameters[10].Value = model.Pize_GetPrizeTime;
            parameters[11].Value = model.Pize_PushCom;
            parameters[12].Value = model.Pize_PushComNum;
            parameters[13].Value = model.Pize_PushPerson;
            parameters[14].Value = model.Pize_PushPersonNum;
            parameters[15].Value = model.Pize_WebsiteNum;
            parameters[16].Value = model.Pize_UserNum;
            parameters[17].Value = model.Pize_PrizeID;
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
        public bool Delete(string Prize_Guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PrizeExchange ");
            strSql.Append(" where Prize_Guid=@Prize_Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Prize_Guid", SqlDbType.VarChar ,255)			};
            parameters[0].Value = Prize_Guid;


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
        public PrizeExchangeInfo GetModel(string Prize_Guid)
        {

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select *  ");
            //strSql.Append("  from PrizeExchange ");
            //strSql.Append(" where Prize_Guid=@Prize_Guid ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@Prize_Guid", SqlDbType.VarChar ,255)			};
            //parameters[0].Value = Prize_Guid;


            PrizeExchangeInfo model = new PrizeExchangeInfo();
            string str = string.Format("select *  from PrizeExchange where Prize_Guid='{0}' ", Prize_Guid);
            DataSet ds = DbHelperSQL.Query(str, null);

            if (ds.Tables[0].Rows.Count > 0)
            {

                model.Prize_Guid = ds.Tables[0].Rows[0]["Prize_Guid"].ToString();
                model.Prize_user = ds.Tables[0].Rows[0]["Prize_user"].ToString();
                model.Prize_CardNum = ds.Tables[0].Rows[0]["Prize_CardNum"].ToString();
                model.Prize_IdentifyCard = ds.Tables[0].Rows[0]["Prize_IdentifyCard"].ToString();
                model.Prize_Name = ds.Tables[0].Rows[0]["Prize_Name"].ToString();
                model.Prize_Flag = ds.Tables[0].Rows[0]["Prize_Flag"].ToString();
                model.Prize_GetUserName = ds.Tables[0].Rows[0]["Prize_GetUserName"].ToString();
                model.Prize_GetUserContact = ds.Tables[0].Rows[0]["Prize_GetUserContact"].ToString();
                model.Prize_GetUserIdentifyCard = ds.Tables[0].Rows[0]["Prize_GetUserIdentifyCard"].ToString();
                model.Prize_GetPrizeName = ds.Tables[0].Rows[0]["Prize_GetPrizeName"].ToString();
                model.Pize_GetPrizeDateTime = ds.Tables[0].Rows[0]["Pize_GetPrizeDateTime"].ToString();
                model.Pize_GetPrizeTime = ds.Tables[0].Rows[0]["Pize_GetPrizeTime"].ToString();
                model.Pize_PushCom = ds.Tables[0].Rows[0]["Pize_PushCom"].ToString();
                model.Pize_PushComNum = ds.Tables[0].Rows[0]["Pize_PushComNum"].ToString();
                model.Pize_PushPerson = ds.Tables[0].Rows[0]["Pize_PushPerson"].ToString();
                model.Pize_PushPersonNum = ds.Tables[0].Rows[0]["Pize_PushPersonNum"].ToString();
                model.Pize_WebsiteNum = ds.Tables[0].Rows[0]["Pize_WebsiteNum"].ToString();
                model.Pize_UserNum = ds.Tables[0].Rows[0]["Pize_UserNum"].ToString();
                model.Pize_PrizeID = ds.Tables[0].Rows[0]["Pize_PrizeID"].ToString();
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
            strSql.Append(" FROM PrizeExchange ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListYDJ(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select Prize_user as 姓名,	Prize_CardNum as 卡号,	Prize_IdentifyCard as 身份证号,
            Prize_GetUserName as 领取人姓名, Prize_GetUserContact as 领取人联系方式, Prize_GetUserIdentifyCard as 领取人身份证号,Pize_PrizeID,
            pi.PrizeName	as 已兑奖品名称, Pize_GetPrizeDateTime as 兑奖日期,	Pize_GetPrizeTime as 兑奖时间 ,Pize_WebsiteNum as 操作网点号,
            	Pize_UserNum as 工号 ,Pize_PushCom as 推广机构名称	,Pize_PushComNum as 推广机构号, Pize_PushPerson as 推广人员姓名, Pize_PushPersonNum as 推广人编号,
            兑奖状态=( case when Prize_Flag= '2' then '已作废' else '已兑奖' end)

             ");


            strSql.Append(" FROM PrizeExchange pe left join PrizeInfo pi on pe.Pize_PrizeID=pi.PrizeID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListWDJ(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select Prize_user as 姓名,	Prize_CardNum as 卡号,	Prize_IdentifyCard as 身份证号,
            Prize_Name as 可兑换奖品,Pize_PushCom as 推广机构名称,Pize_PushComNum as 推广机构号, Pize_PushPerson as 推广人员姓名, Pize_PushPersonNum as 推广人编号
             ");


            strSql.Append(" FROM PrizeExchange ");
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
            strSql.Append("select * from (select ");
            //if(Top>0)
            //{
            //    strSql.Append(" top "+Top.ToString());
            //}
           
            //strSql.Append("select ");
            //if (Top > 0)
            //{
            //    strSql.Append(" top " + Top.ToString());
            //}
            strSql.Append(" row_number()over(order by " + filedOrder + ") as Number, * ");

            //strSql.Append("select *");
            strSql.Append(" FROM PrizeExchange ");
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

