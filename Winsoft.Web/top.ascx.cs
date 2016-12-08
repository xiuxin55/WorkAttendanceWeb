using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.BLL;
using System.Data;
using Winsoft.Model;

namespace Winsoft.Web
{
    public partial class top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnExit.Attributes.Add("onclick", "return confirm('你确认要注销吗？');");
                Bind();
            }
        }

        #region 数据加载

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            #region 加载视频菜单

            this.rtManage.DataSource = PrizeExchangeInfoManage.GetInstance().GetList("1=1 order by VT_Order").Tables[0];
            this.rtManage.DataBind();

            #endregion
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 搜索
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string name = this.name.Value.Trim();
            if (name != string.Empty && name != "请输入搜索关键词")
            {
                Response.Redirect("splb.aspx?type=1&id=" + name);
            }
            else
            {
                Response.Redirect("splb.aspx");
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Bind();
        }

        /// <summary>
        /// 购物车
        /// </summary>
        protected void btnCar_Click(object sender, EventArgs e)
        {
            if (Session["myuser"] == null)
            {
                Response.Redirect("hydl.aspx");
            }
            else
            {
                Response.Redirect("gwc.aspx");
            }
        }

        #endregion
    }
}