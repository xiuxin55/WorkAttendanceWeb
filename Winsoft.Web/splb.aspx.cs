using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winsoft.BLL;
using Winsoft.Model;
using Winsoft.Common;

namespace Winsoft.Web
{
    public partial class splb : System.Web.UI.Page
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
            string orderType = this.orderType.Value.Trim();
            string fldOrder = " p1.V_Time desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = this.AspNetPager2.PageSize = 8;//页尺寸

            #region 排序

            if (orderType == "0")
            {
                fldOrder = " p1.V_Time desc";
            }
            else if (orderType == "1")
            {
                fldOrder = " p1.V_BrowseCount desc";
            }
            else if (orderType == "2")
            {
                fldOrder = " p1.V_CollectionCount desc";
            }
            else if (orderType == "3")
            {
                fldOrder = " p1.V_BuyCount desc";
            }

            #endregion

            #region 条件

            string type = Request["type"];
            string id = Request["id"];

            if (type != null && id != string.Empty && id != null && id != string.Empty)
            {
                if (type == "0")
                {
                    PrizeExchangeInfo model = PrizeExchangeInfoManage.GetInstance().GetModel(id);
                    if (model != null)
                    {
                        this.V_Title.Text = model.VT_Name;
                        this.V_ETitle.Text = model.VT_EName;
                    }
                    strWhere += " and p1.VT_ID='" + id + "'";
                }
                else if (type == "1")
                {
                    id = id.Replace("#", "");
                    this.V_Title.Text = "搜索结果";
                    this.V_ETitle.Text = "Search Reults";
                    this.name.Text = id;
                    this.divSearch.Visible = true;
                    strWhere += " and (" + StringUtil.GetStrs(id, "p1.V_Name") + " or " + StringUtil.GetStrs(id, "p1.V_Keyword") + ")";
                }
            }

            #endregion

            DataTable dtList = VidoInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = VidoInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
            this.AspNetPager1.RecordCount = this.AspNetPager2.RecordCount = Convert.ToInt32(dtCount.Rows[0]["total"].ToString());

            this.rtManage.DataSource = dtList;
            this.rtManage.DataBind();

            #region 关键词

            if (type != null && id != string.Empty && id != null && id != string.Empty && type == "1")
            {
                id = id.Replace("#", "").Replace(" ", "#");
                string keyword = "";
                if (dtList != null && dtList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        keyword += dtList.Rows[i]["V_Keyword"].ToString() + "#";
                    }
                }

                BindKeyword(keyword, id);
            }

            #endregion
        }

        /// <summary>
        /// 加载关键词
        /// </summary>
        private void BindKeyword(string keyword,string name)
        {
            if (keyword != string.Empty)
            {
                string strWhere = " and value_str like '%" + name + "%'";
                DataTable dtList = VidoInfoManage.GetInstance().GetPageKeyword(10, keyword, strWhere);
                this.rtKeyword.DataSource = dtList;
                this.rtKeyword.DataBind();
            }
        }

        #endregion

        #region 数据查询

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            this.AspNetPager2.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex;
            Bind();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = this.AspNetPager2.CurrentPageIndex;
            Bind();
        }

        #endregion

        #region 数据排序

        /// <summary>
        /// 按发布时间
        /// </summary>
        protected void btnSelectTime_Click(object sender, EventArgs e)
        {
            this.orderType.Value = "0";
            Bind();
        }

        /// <summary>
        /// 按浏览排行
        /// </summary>
        protected void btnSelectBrowseCount_Click(object sender, EventArgs e)
        {
            this.orderType.Value = "1";
            Bind();
        }

        /// <summary>
        /// 按收藏排行
        /// </summary>
        protected void btnSelectCollectionCount_Click(object sender, EventArgs e)
        {
            this.orderType.Value = "2";
            Bind();
        }

        /// <summary>
        /// 按购买数量
        /// </summary>
        protected void btnSelectBuyCount_Click(object sender, EventArgs e)
        {
            this.orderType.Value = "3";
            Bind();
        }

        #endregion
    }
}