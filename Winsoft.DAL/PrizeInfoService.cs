using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //Prize
    public partial class PrizeInfoService
    {

        #region 自定义方法

        //public bool Login(string P_UserId, string M_Password)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from Prize");
        //    strSql.Append(" where ");
        //    strSql.Append(" M_Username = @M_Username and M_Password = @M_Password  ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@M_Username", SqlDbType.VarChar,255),
        //            new SqlParameter("@M_Password", SqlDbType.VarChar,255)};
        //    parameters[0].Value = M_Username;
        //    parameters[1].Value = M_Password;

        //    return DbHelperSQL.Exists(strSql.ToString(), parameters);
        //}
        public DataSet GetPrize()
        {
            string str = " select [PrizeID],[PrizeName] from [PrizeAllocateModel] group by [PrizeID],[PrizeName]";
            return DbHelperSQL.Query(str);
        }
             public bool UpdateAllocate(List<PrizeAllocateModel> list)
        {
            try
            {
                List<string> strlist = new List<string>();
                foreach (PrizeAllocateModel item in list)
                {
                    strlist.Add("update [PrizeAllocateModel] set [PrizeCount]=[PrizeCount]+" + item.PrizeAmount + "- convert(int,PrizeAmount)" + ", [PrizeAmount]=" + item.PrizeAmount + " where [PrizeID]='" + item.PrizeID + "' and [WebsiteID]='" + item.WebsiteID + "'");
                }
                DbHelperSQL.ExecuteSqlTran(strlist);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public bool UpdateAllocate(List<PrizeAllocateModel> list)
        //{
        //    try
        //    {
        //        List<string> strlist = new List<string>();
        //        foreach (PrizeAllocateModel item in list)
        //        {
        //            strlist.Add("update [PrizeAllocateModel] set [PrizeCount]=" + item.PrizeCount + " where [PrizeID]='" + item.PrizeID + "' and [WebsiteID]='" + item.WebsiteID + "'");
        //        }
        //        DbHelperSQL.ExecuteSqlTran(strlist);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 得到所有奖品
        /// </summary>
        public DataTable  GetAllPrize(string PrizeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [PrizeID],[PrizeName],PrizeAmount,w.[WebsiteID],w.[WebsiteName],[PrizeCount],PrizeScore ");
            strSql.Append("  from Website w left join PrizeAllocateModel p  on w.[WebsiteID]=p.[WebsiteID] where PrizeID='" + PrizeID + "' group by [PrizeID],[PrizeName],w.[WebsiteID],w.[WebsiteName],[PrizeCount],PrizeScore,PrizeAmount");
            //strSql.Append(" where PrizeID=@PrizeID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@PrizeID", SqlDbType.VarChar,255)			
            //                            };
            //parameters[0].Value = PrizeID;


            PrizeAllocateModel model = new PrizeAllocateModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null );

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
                //model.PrizeID = Convert.ToInt32(ds.Tables[0].Rows[0]["P_Id"].ToString());
                //model.PrizeName = Convert.ToInt32(ds.Tables[0].Rows[0]["P_UserId"].ToString());
                //model.WebsiteID  = ds.Tables[0].Rows[0]["P_CityId"].ToString();
                //model.WebsiteName = ds.Tables[0].Rows[0]["P_ProvinceId"].ToString();
                //model.Guid = ds.Tables[0].Rows[0]["P_Name"].ToString();
                //model.PrizeCount = Convert.ToInt32(ds.Tables[0].Rows[0]["P_Activity"].ToString());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除奖品
        /// </summary>
        /// <param name="PrizeID"></param>
        /// <returns></returns>
        public bool  DeletePrizeId(string PrizeID)
        {
          
            List<string> cmdtxts = new List<string>();
            string sql = string.Format(@"delete from PrizeAllocateModel  where PrizeID='{0}' ",  PrizeID);
            cmdtxts.Add(sql);
            string sql2 = string.Format(@" delete from PrizeInfo  where PrizeID='{0}' ", PrizeID);
            cmdtxts.Add(sql2);
            int rows = DbHelperSQL.ExecuteSqlTran(cmdtxts);
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
        public PrizeInfo GetModelByName(string P_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_Id,P_UserId,P_CityId,P_ProvinceId,P_Name,P_Activity,P_Integral,P_ServiceDepartment,P_Authentication  ");
            strSql.Append("  from Prize ");
            strSql.Append(" where P_Name=@P_Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Name", SqlDbType.VarChar,255)			};
            parameters[0].Value = P_Name;


            PrizeInfo model = new PrizeInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //model.P_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["P_Id"].ToString());
                //model.P_UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["P_UserId"].ToString());
                //model.P_CityId = ds.Tables[0].Rows[0]["P_CityId"].ToString();
                //model.P_ProvinceId = ds.Tables[0].Rows[0]["P_ProvinceId"].ToString();
                //model.P_Name = ds.Tables[0].Rows[0]["P_Name"].ToString();
                //model.P_Activity = Convert.ToInt32(ds.Tables[0].Rows[0]["P_Activity"].ToString());
                //model.P_Integral = Convert.ToInt32(ds.Tables[0].Rows[0]["P_Integral"].ToString());
                //model.P_ServiceDepartment = ds.Tables[0].Rows[0]["P_ServiceDepartment"].ToString();
                //model.P_Authentication = ds.Tables[0].Rows[0]["P_Authentication"].ToString();
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
            return DBHelpService.GetPageList(pageSize, pageIndex, TableName, PrimaryKey, FieldList, strWhere, fdlOrder, isCount, isPageCount);
        }

        public bool Exists(string P_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Prize");
            strSql.Append(" where ");
            strSql.Append(" P_Name = @P_Name  ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Name", SqlDbType.VarChar,255)			};
            parameters[0].Value = P_Name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PrizeAllocateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PrizeAllocateModel(");
            strSql.Append("[PrizeID] ,[PrizeName] ,[WebsiteID] ,[PrizeCount] ,[PrizeScore] ,WebsiteName");
            strSql.Append(") values (");
            strSql.Append("@PrizeID,@PrizeName,@WebsiteID,@PrizeCount,@PrizeScore,@WebsiteName ");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PrizeID", SqlDbType.VarChar,255) ,            
                                
                        new SqlParameter("@PrizeName", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@WebsiteID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PrizeCount", SqlDbType.Int) ,
                        new SqlParameter("@PrizeScore", SqlDbType.VarChar,255) ,
                        new SqlParameter("@WebsiteName", SqlDbType.VarChar,255) 
            };

            parameters[0].Value = model.PrizeID;
            parameters[1].Value = model.PrizeName;
            parameters[2].Value = model.WebsiteID;
            parameters[3].Value = model.PrizeCount;
            parameters[4].Value = model.PrizeScore;
            parameters[5].Value = model.WebsiteName;
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
        /// 增加多条数据
        /// </summary>
        public bool Add(List<PrizeAllocateModel> models,PrizeInfo prize)
        {
            List<string> cmdtxts = new List<string>();
            foreach (var item in models)
            {

                string sql = string.Format(@"insert into PrizeAllocateModel([PrizeID] ,[PrizeName] ,[WebsiteID] ,[PrizeCount] ,[PrizeScore] ,WebsiteName,PrizeAmount)
                values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", item.PrizeID, item.PrizeName, item.WebsiteID, item.PrizeCount, item.PrizeScore, item.WebsiteName, 0);
                cmdtxts.Add(sql);
            }
            if (prize != null)
            {
                cmdtxts.Add(string.Format(@"INSERT INTO [PrizeInfo] ([PrizeID],[PrizeName],[PrizeLeftAmount],[PrizeUsedAmount] ,[PrizeAmount],PrizeScore)
            VALUES('{0}','{1}','{2}','{3}','{4}',{5})", prize.PrizeID, prize.PrizeName, prize.PrizeAmount, 0, prize.PrizeAmount, prize.PrizeScore));
            }
            int rows = DbHelperSQL.ExecuteSqlTran(cmdtxts);
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
        public bool Update(PrizeAllocateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PrizeAllocateModel set ");

            strSql.Append(" PrizeName = @PrizeName , ");
            strSql.Append(" PrizeScore= @PrizeScore  ");

            strSql.Append(" where PrizeID=@PrizeID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PrizeID", SqlDbType.VarChar,255) ,            
                    
                        new SqlParameter("@PrizeName", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PrizeScore", SqlDbType.VarChar,255)
            };
            parameters[0].Value = model.PrizeID;
            parameters[1].Value = model.PrizeName;
            parameters[2].Value = model.PrizeScore;
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

        public bool Update(PrizeInfo prize)
        {
            List<string> cmdtxts = new List<string>();
            string sql = string.Format(@"update PrizeAllocateModel set  PrizeName ='{0}' , PrizeScore= '{1}'  where PrizeID='{2}' ", prize.PrizeName, prize.PrizeScore , prize.PrizeID);
            cmdtxts.Add(sql);
            string sql2 = string.Format(@"update PrizeInfo set PrizeName='{0}',PrizeLeftAmount=convert(int,'{2}')-convert(int,PrizeUsedAmount),PrizeAmount='{2}',PrizeScore='{3}'  where PrizeID='{4}' ", prize.PrizeName, prize.PrizeLeftAmount, prize.PrizeAmount, prize.PrizeScore, prize.PrizeID);
            cmdtxts.Add(sql2);
            int rows = DbHelperSQL.ExecuteSqlTran(cmdtxts);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<PrizeInfo> GetPrizeInfo(PrizeInfo prize)
        {
            List<PrizeInfo> list=new List<PrizeInfo>();
            string sql = @"select * from PrizeInfo where 1=1 ";
            if (!string.IsNullOrEmpty(prize.PrizeID))
            {
                sql = sql + " and PrizeID='" + prize.PrizeID + "'";
            }
            if (!string.IsNullOrEmpty(prize.PrizeName))
            {
                sql = sql + " and PrizeName='" + prize.PrizeName + "'";
            }
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PrizeInfo m = new PrizeInfo();
                    m.PrizeID = item["PrizeID"].ToString();
                    m.PrizeName = item["PrizeName"].ToString();
                    m.PrizeScore = item["PrizeScore"].ToString();
                    m.PrizeLeftAmount = item["PrizeLeftAmount"].ToString();
                    m.PrizeUsedAmount = item["PrizeUsedAmount"].ToString();
                    m.PrizeAmount = item["PrizeAmount"].ToString();
                    list.Add(m);
                }
            }
            return list;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string P_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Prize ");
            strSql.Append(" where P_Id=@P_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@P_Id", SqlDbType.VarChar,255)			};
            parameters[0].Value = P_Id;


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
        public PrizeInfo GetModel(string P_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  PrizeID,PrizeName,PrizeScore,PrizeLeftAmount,PrizeUsedAmount,PrizeAmount");
            strSql.Append("  from PrizeInfo ");
            strSql.Append(" where PrizeID=@PrizeID");
            SqlParameter[] parameters = {
					new SqlParameter("@PrizeID", SqlDbType.VarChar,255)			};
            parameters[0].Value = P_Id;


            PrizeInfo model = new PrizeInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PrizeID = ds.Tables[0].Rows[0]["PrizeID"].ToString();
                model.PrizeName = ds.Tables[0].Rows[0]["PrizeName"].ToString();
                model.PrizeScore = ds.Tables[0].Rows[0]["PrizeScore"].ToString();
                model.PrizeLeftAmount = ds.Tables[0].Rows[0]["PrizeLeftAmount"].ToString();
                model.PrizeUsedAmount = ds.Tables[0].Rows[0]["PrizeUsedAmount"].ToString();
                model.PrizeAmount = ds.Tables[0].Rows[0]["PrizeAmount"].ToString();
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
            strSql.Append(" FROM Prize ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListNotAllocateWebsite(string prizeid)
        {
            string sql = @"select * from Website where WebsiteID not in (select WebsiteID from PrizeInfo where PrizeID='" + prizeid+"')";
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select ");
            strSql.Append(" row_number()over(order by " + filedOrder + ") as Number, * ");
            strSql.Append(" FROM (select  PrizeID,PrizeName,PrizeScore,PrizeLeftAmount,PrizeUsedAmount,PrizeAmount from PrizeInfo) as Temp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

    }
}

