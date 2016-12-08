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
    public partial class bzzx_xx : System.Web.UI.Page
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
            if (id != null && id != string.Empty)
            {
                NewsInfo model = NewsInfoManage.GetInstance().GetModel(id);

                if (model == null || model.M_ID != "002002002")
                {
                    Response.Redirect("404.htm");
                }

                NewsInfo modelMenu = NewsInfoManage.GetInstance().GetModel(model.N_Str1);

                if (modelMenu == null && modelMenu.M_ID == "002002001")
                {
                    Response.Redirect("404.htm");
                }

                this.N_Str1.Text = modelMenu.N_Str1;
                this.N_Title.Text = model.N_Title;
                this.N_Content.Text = model.N_Content;

            }
            else
            {
                Response.Redirect("404.htm");
            }
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        private void BindMenu()
        {
            string fldOrder = " p1.N_Order";//排序字段名
            string strWhere = " and p1.M_ID='002002001'";//查询条件

            DataTable dtList = NewsInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            this.rtMenu.DataSource = dtList;
            this.rtMenu.DataBind();
        }

        #endregion
    }
}