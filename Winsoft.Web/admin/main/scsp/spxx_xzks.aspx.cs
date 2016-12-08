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
    public partial class spxx_xzks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                BindType();
                Bind();
            }
        }

        #region 菜单加载

        /// <summary>
        /// 加载视频类型
        /// </summary>
        private void BindType()
        {
            DataTable dtList = PrizeExchangeInfoManage.GetInstance().GetList("1=1 order by VT_Order").Tables[0];

            if (dtList != null || dtList.Rows.Count > 0)
            {
                this.VT_ID.DataSource = dtList;
                this.VT_ID.DataTextField = "VT_Name";
                this.VT_ID.DataValueField = "VT_ID";
                this.VT_ID.DataBind();
            }
            this.VT_ID.Items.Insert(0, new ListItem("全部", "0"));
        }

        #endregion

        #region 数据查询

        private void Bind()
        {
            string fldOrder = " p2.V_Time desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = 10;//页尺寸
            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string VT_ID = this.VT_ID.Text.Trim();
            string V_Name = this.V_Name.Value.Trim();
            string VL_Name = this.VL_Name.Value.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and p2.V_Time between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (VT_ID != "0")
            {
                strWhere += " and p3.VT_ID='" + VT_ID + "'";
            }

            if (V_Name != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(V_Name, "p2.V_Name") + ")";
            }

            if (VL_Name != string.Empty)
            {
                strWhere += " and p1.VL_Name like '%" + VL_Name + "%'";
            }

            DataTable dtLsit = VidoLessonInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = VidoLessonInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPager1.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtManager.DataSource = dtLsit;
            this.rtManager.DataBind();
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        #endregion
    }
}