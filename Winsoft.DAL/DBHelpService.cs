using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Winsoft.DBUtility;
using Winsoft.Model;
namespace Winsoft.DAL  
{
    //DBHelpService
    public partial class DBHelpService
	{
	
	
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
   		public static DataTable GetPageList(int pageSize, int pageIndex,string TableName,string PrimaryKey, string FieldList, string strWhere, string fdlOrder, int isCount,int isPageCount)
   		{
   			try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@TableName",TableName),
                    new SqlParameter("@FieldList",FieldList),
                    new SqlParameter("@PrimaryKey",PrimaryKey),
                    new SqlParameter("@Where",strWhere),
                    new SqlParameter("@Order",fdlOrder),
                    new SqlParameter("@SortType",3),
                    new SqlParameter("@RecorderCount",0),
                    new SqlParameter("@pageSize",pageSize),
                    new SqlParameter("@pageIndex",pageIndex),
                    new SqlParameter("@TotalCount",isCount),
                    new SqlParameter("@TotalPageCount",isPageCount)
                };
                return DbHelperSQL.RunProcedure("P_viewPage", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
   		}

        
		
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM [User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		#endregion
   
	}
}

