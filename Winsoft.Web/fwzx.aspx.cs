using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web
{
    public partial class fwzx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
                BindMenu();
            }
        }

        #region 数据加载

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            string id = Request["id"];
            if (id == null || id == string.Empty)
            {
                string fldOrder = " p1.N_Order";//排序字段名
                string strWhere = " and p1.M_ID='002001001'";//查询条件

                DataTable dtList = NewsInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

                if (dtList != null && dtList.Rows.Count > 0)
                {
                    id = dtList.Rows[0]["N_ID"].ToString();
                }
            }

            NewsInfo model = NewsInfoManage.GetInstance().GetModel(id);

            if (model == null || model.M_ID != "002001001")
            {
                Response.Redirect("404.htm");
            }

            this.N_Str1.Text = model.N_Str1;
            this.N_Title.Text = model.N_Title;
            this.N_Content.Text = model.N_Content;
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        private void BindMenu()
        {
            string fldOrder = " p1.N_Order";//排序字段名
            string strWhere = " and p1.M_ID='002001001'";//查询条件

            DataTable dtList = NewsInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            this.rtMenu.DataSource = dtList;
            this.rtMenu.DataBind();
        }

        #endregion
    }
}