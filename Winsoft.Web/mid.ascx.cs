using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;

namespace Winsoft.Web
{
    public partial class mid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        #region 数据加载

        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bind()
        {
            DataTable dtList = null;
            string fldOrder = "";//排序字段名
            string strWhere = "";//查询条件

            #region 入口管理

            #region 图片广告

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001001001'";//查询条件
            //dtList = NewsInfoManage.GetInstance().GetPageList(4, 1, strWhere, fldOrder, 0);
            this.rtTpggA.DataSource = dtList;
            this.rtTpggA.DataBind();
            this.rtTpggB.DataSource = dtList;
            this.rtTpggB.DataBind();

            #endregion

            #endregion
        }

        #endregion
    }
}