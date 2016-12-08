using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;
using Winsoft.Common;
using Winsoft.Model;

namespace Winsoft.Web.admin.main.scsp
{
    public partial class spxstj : System.Web.UI.Page
    {
        public static string M_EUrl = "#";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                else
                {
                    string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    if (f_menu != string.Empty)
                    {
                        this.lblMenu.Text = f_menu;
                        CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                        if (model != null)
                        {
                            M_EUrl = model.M_EUrl;
                        }
                        Bind();
                    }
                }
            }
        }

        #region 数据查询

        private void Bind()
        {
            string strWhere = "";//查询条件

            string M_Username = this.M_Username.Value.Trim();

            if (M_Username != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Username, "p2.M_Username") + ")";
            }

            DataTable dtList = OrderInfoManage.GetInstance().GetPageGroupVCount(strWhere);

            this.rtManager.DataSource = dtList;
            this.rtManager.DataBind();

            //合计
            decimal lblPrice = 0;
            int lblCount = 0;

            if (dtList != null && dtList.Rows.Count > 0)
            {
                for (int i = 0; i < dtList.Rows.Count; i++)
                {
                    decimal O_Price = Convert.ToDecimal(dtList.Rows[i]["O_Price"]);
                    int V_Count = Convert.ToInt32(dtList.Rows[i]["V_Count"]);
                    lblPrice += O_Price;
                    lblCount += V_Count;
                }
            }
            this.lblPrice.Text = "￥" + lblPrice.ToString("f2");
            this.lblCount.Text = lblCount.ToString();
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            Bind();
        }

        #endregion
    }
}