using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL
{
    //OrderInfo
    public partial class OrderInfoService
    {

        #region 自定义方法

        /// <summary>
        ///  视频销售统计
        /// </summary>
        public DataTable GetPageGroupVCount(string strWhere)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@strWhere",strWhere)
                };
                return DbHelperSQL.RunProcedure("OrderInfo_PageGroupVCount", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  会员销售统计
        /// </summary>
        public DataTable GetPageGroupMCount(string strWhere)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@strWhere",strWhere)
                };
                return DbHelperSQL.RunProcedure("OrderInfo_PageGroupMCount", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModel(string V_ID,string M_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_ID, O_Time, V_ID, M_ID, O_Serial, O_Order, O_Price, O_Status, O_NextTime, O_PaymentTime  ");
            strSql.Append("  from OrderInfo ");
            strSql.Append(" where O_Status!='已取消' and V_ID=@V_ID and M_ID=@M_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@V_ID", SqlDbType.VarChar,255),
                    new SqlParameter("@M_ID", SqlDbType.VarChar,255)};
            parameters[0].Value = V_ID;
            parameters[1].Value = M_ID;


            OrderInfo model = new OrderInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.O_ID = ds.Tables[0].Rows[0]["O_ID"].ToString();
                if (ds.Tables[0].Rows[0]["O_Time"].ToString() != "")
                {
                    model.O_Time = DateTime.Parse(ds.Tables[0].Rows[0]["O_Time"].ToString());
                }
                model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                model.O_Serial = ds.Tables[0].Rows[0]["O_Serial"].ToString();
                model.O_Order = ds.Tables[0].Rows[0]["O_Order"].ToString();
                if (ds.Tables[0].Rows[0]["O_Price"].ToString() != "")
                {
                    model.O_Price = decimal.Parse(ds.Tables[0].Rows[0]["O_Price"].ToString());
                }
                model.O_Status = ds.Tables[0].Rows[0]["O_Status"].ToString();
                model.O_NextTime = ds.Tables[0].Rows[0]["O_NextTime"].ToString();
                model.O_PaymentTime = ds.Tables[0].Rows[0]["O_PaymentTime"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderInfo GetModelByOrder(string O_Order)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_ID, O_Time, V_ID, M_ID, O_Serial, O_Order, O_Price, O_Status, O_NextTime, O_PaymentTime  ");
            strSql.Append("  from OrderInfo ");
            strSql.Append(" where O_Order=@O_Order ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_Order", SqlDbType.VarChar,255)};
            parameters[0].Value = O_Order;


            OrderInfo model = new OrderInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.O_ID = ds.Tables[0].Rows[0]["O_ID"].ToString();
                if (ds.Tables[0].Rows[0]["O_Time"].ToString() != "")
                {
                    model.O_Time = DateTime.Parse(ds.Tables[0].Rows[0]["O_Time"].ToString());
                }
                model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                model.O_Serial = ds.Tables[0].Rows[0]["O_Serial"].ToString();
                model.O_Order = ds.Tables[0].Rows[0]["O_Order"].ToString();
                if (ds.Tables[0].Rows[0]["O_Price"].ToString() != "")
                {
                    model.O_Price = decimal.Parse(ds.Tables[0].Rows[0]["O_Price"].ToString());
                }
                model.O_Status = ds.Tables[0].Rows[0]["O_Status"].ToString();
                model.O_NextTime = ds.Tables[0].Rows[0]["O_NextTime"].ToString();
                model.O_PaymentTime = ds.Tables[0].Rows[0]["O_PaymentTime"].ToString();

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
                return DbHelperSQL.RunProcedure("OrderInfo_Page", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(string O_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrderInfo");
            strSql.Append(" where ");
            strSql.Append(" O_ID = @O_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = O_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderInfo(");
            strSql.Append("O_ID,O_Time,V_ID,M_ID,O_Serial,O_Order,O_Price,O_Status,O_NextTime,O_PaymentTime");
            strSql.Append(") values (");
            strSql.Append("@O_ID,@O_Time,@V_ID,@M_ID,@O_Serial,@O_Order,@O_Price,@O_Status,@O_NextTime,@O_PaymentTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@O_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Serial", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Order", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@O_Status", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_NextTime", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_PaymentTime", SqlDbType.VarChar,255)             
              
            };

            parameters[0].Value = model.O_ID;
            parameters[1].Value = model.O_Time;
            parameters[2].Value = model.V_ID;
            parameters[3].Value = model.M_ID;
            parameters[4].Value = model.O_Serial;
            parameters[5].Value = model.O_Order;
            parameters[6].Value = model.O_Price;
            parameters[7].Value = model.O_Status;
            parameters[8].Value = model.O_NextTime;
            parameters[9].Value = model.O_PaymentTime;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderInfo set ");

            strSql.Append(" O_ID = @O_ID , ");
            strSql.Append(" O_Time = @O_Time , ");
            strSql.Append(" V_ID = @V_ID , ");
            strSql.Append(" M_ID = @M_ID , ");
            strSql.Append(" O_Serial = @O_Serial , ");
            strSql.Append(" O_Order = @O_Order , ");
            strSql.Append(" O_Price = @O_Price , ");
            strSql.Append(" O_Status = @O_Status , ");
            strSql.Append(" O_NextTime = @O_NextTime , ");
            strSql.Append(" O_PaymentTime = @O_PaymentTime  ");
            strSql.Append(" where O_ID=@O_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@O_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Time", SqlDbType.DateTime) ,            
                        new SqlParameter("@V_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@M_ID", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Serial", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Order", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@O_Status", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_NextTime", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@O_PaymentTime", SqlDbType.VarChar,255)             
              
            };

            parameters[0].Value = model.O_ID;
            parameters[1].Value = model.O_Time;
            parameters[2].Value = model.V_ID;
            parameters[3].Value = model.M_ID;
            parameters[4].Value = model.O_Serial;
            parameters[5].Value = model.O_Order;
            parameters[6].Value = model.O_Price;
            parameters[7].Value = model.O_Status;
            parameters[8].Value = model.O_NextTime;
            parameters[9].Value = model.O_PaymentTime;
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
        public bool Delete(string O_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderInfo ");
            strSql.Append(" where O_ID=@O_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = O_ID;


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
        public OrderInfo GetModel(string O_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select O_ID, O_Time, V_ID, M_ID, O_Serial, O_Order, O_Price, O_Status, O_NextTime, O_PaymentTime  ");
            strSql.Append("  from OrderInfo ");
            strSql.Append(" where O_ID=@O_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@O_ID", SqlDbType.VarChar,255)			};
            parameters[0].Value = O_ID;


            OrderInfo model = new OrderInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.O_ID = ds.Tables[0].Rows[0]["O_ID"].ToString();
                if (ds.Tables[0].Rows[0]["O_Time"].ToString() != "")
                {
                    model.O_Time = DateTime.Parse(ds.Tables[0].Rows[0]["O_Time"].ToString());
                }
                model.V_ID = ds.Tables[0].Rows[0]["V_ID"].ToString();
                model.M_ID = ds.Tables[0].Rows[0]["M_ID"].ToString();
                model.O_Serial = ds.Tables[0].Rows[0]["O_Serial"].ToString();
                model.O_Order = ds.Tables[0].Rows[0]["O_Order"].ToString();
                if (ds.Tables[0].Rows[0]["O_Price"].ToString() != "")
                {
                    model.O_Price = decimal.Parse(ds.Tables[0].Rows[0]["O_Price"].ToString());
                }
                model.O_Status = ds.Tables[0].Rows[0]["O_Status"].ToString();
                model.O_NextTime = ds.Tables[0].Rows[0]["O_NextTime"].ToString();
                model.O_PaymentTime = ds.Tables[0].Rows[0]["O_PaymentTime"].ToString();

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
            strSql.Append(" FROM OrderInfo ");
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
            strSql.Append(" FROM OrderInfo ");
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

