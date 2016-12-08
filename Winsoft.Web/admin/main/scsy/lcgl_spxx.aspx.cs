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

namespace Winsoft.Web.admin.main.scsy
{
    public partial class lcgl_spxx : System.Web.UI.Page
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
                    btnAllDelete.Attributes.Add("onclick", "return confirm('你确认要删除选中的信息吗？');");
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
            string fldOrder = " N_Order";//排序字段名
            string strWhere = " and M_ID='" + Request["code"] + "'";//查询条件
            this.AspNetPager1.PageSize = 15;//页尺寸
            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string N_Type = this.N_Type.Text.Trim();
            string N_Title = this.N_Title.Value.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and N_Time between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (N_Type != "0")
            {
                strWhere += " and N_Type = " + N_Type;
            }

            if (N_Title != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(N_Title, "N_Title") + ")";
            }

            DataTable dtLsit = NewsInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = NewsInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
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

        #region 数据处理

        protected void rtManager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            //删除
            if (e.CommandName == "delete")
            {
                bool result = NewsInfoManage.GetInstance().Delete(id);

                switch (result)
                {
                    case true:
                        MessageBox.Show(this, "删除成功！");
                        break;
                    default:
                        MessageBox.Show(this, "删除失败！");
                        break;
                }
            }
            Bind();
        }
        /// <summary>
        /// 添加弹出确认框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rtManager_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("btnDelete");
                btn.Attributes.Add("onclick", "return confirm('你确认要删除该条信息吗？');");
            }
        }
        
        /// <summary>
        /// 批量删除
        /// </summary>
        protected void btnAllDelete_Click(object sender, EventArgs e)
        {
            string code = Request.Form["Item"];
            if (code != null && code != string.Empty)
            {
                MessageBox.Show(this, DeleteAll(code));
                Bind();
            }
            else
            {
                MessageBox.Show(this, "请先选择项！");
            }
        }

        /// <summary>
        /// 批量删除初始化
        /// </summary>
        public string DeleteAll(string code)
        {
            string s = "操作失败！";
            string[] codes = code.Split(',');
            if (codes.Length > 0)
            {
                bool result = false;
                for (int i = 0; i < codes.Length; i++)
                {
                    result = NewsInfoManage.GetInstance().Delete(codes[i]);
                }
                switch (result)
                {
                    case true:
                        s = "操作成功！";
                        break;
                    default:
                        s = "操作失败！";
                        break;
                }
            }
            return s;
        }

        #endregion

        #region 数据跳转

        /// <summary>
        /// 添加
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(M_EUrl);
        }

        #endregion
    }
}