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

namespace Winsoft.Web.admin.main.schy
{
    public partial class pjxx : System.Web.UI.Page
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
            string fldOrder = " p1.C_Time desc";//排序字段名
            string strWhere = "";//查询条件
            this.AspNetPager1.PageSize = 15;//页尺寸
            string start = this.start.Text.Trim();
            string end = this.end.Text.Trim();
            string startr = this.startr.Text.Trim();
            string endr = this.endr.Text.Trim();
            string A_UserName = this.A_UserName.Value.Trim();
            string M_Username = this.M_Username.Value.Trim();
            string V_Name = this.V_Name.Value.Trim();
            string C_Status = this.C_Status.Text.Trim();

            if (start != string.Empty && end != string.Empty)
            {
                strWhere += " and p1.C_Time between '" + start + " 00:00:00' and '" + end + " 23:59:59'";
            }

            if (startr != string.Empty && endr != string.Empty)
            {
                strWhere += " and p1.C_ReplyTime between '" + startr + " 00:00:00' and '" + endr + " 23:59:59'";
            }

            if (A_UserName != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(A_UserName, "p2.A_UserName") + ")";
            }

            if (M_Username != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(M_Username, "p4.M_Username") + ")";
            }

            if (V_Name != string.Empty)
            {
                strWhere += " and (" + StringUtil.GetStrs(V_Name, "p3.V_Name") + ")";
            }

            if (C_Status != "全部")
            {
                strWhere += " and p1.C_Status = '" + C_Status + "'";
            }

            DataTable dtLsit = ServiceDepartmentInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 0);
            DataTable dtCount = ServiceDepartmentInfoManage.GetInstance().GetPageList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, fldOrder, 1);
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
            //通过
            if (e.CommandName == "tg")
            {
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该评论不存在！");
                }
                else if (model.C_Status != "未审核")
                {
                    MessageBox.Show(this, "只有未审核的评价才能执行该操作！");
                }
                else
                {
                    model.C_Status = "已审核";
                    bool result = ServiceDepartmentInfoManage.GetInstance().Update(model);

                    switch (result)
                    {
                        case true:
                            MessageBox.Show(this, "操作成功！");
                            break;
                        default:
                            MessageBox.Show(this, "操作失败！");
                            break;
                    }
                }
            }

            //撤回
            if (e.CommandName == "ch")
            {
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该评论不存在！");
                }
                else if (model.C_Status != "未审核")
                {
                    MessageBox.Show(this, "只有未审核的评价才能执行该操作！");
                }
                else
                {
                    model.C_Status = "未通过";
                    bool result = ServiceDepartmentInfoManage.GetInstance().Update(model);

                    switch (result)
                    {
                        case true:
                            MessageBox.Show(this, "操作成功！");
                            break;
                        default:
                            MessageBox.Show(this, "操作失败！");
                            break;
                    }
                }
            }
            //回复
            if (e.CommandName == "hf")
            {
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(id);

                if (model == null)
                {
                    MessageBox.Show(this, "该评论不存在！");
                }
                else if (model.A_ID != string.Empty)
                {
                    MessageBox.Show(this, "只有未回复的评价才能执行该操作！");
                }
                else
                {
                    Response.Redirect("pjxx_hf.aspx?code=" + Request["code"] + "&id=" + id);
                }
            }

            //删除
            if (e.CommandName == "delete")
            {
                bool result = ServiceDepartmentInfoManage.GetInstance().Delete(id);

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
        /// 初始化数据
        /// </summary>
        protected void rtManager_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdfID");
                LinkButton btnTg = (LinkButton)e.Item.FindControl("btnTg");
                LinkButton btnCh = (LinkButton)e.Item.FindControl("btnCh");
                LinkButton btnHf = (LinkButton)e.Item.FindControl("btnHf");
                ServiceDepartmentInfo model = ServiceDepartmentInfoManage.GetInstance().GetModel(hdfID.Value.Trim());
                if (model != null)
                {
                    if (model.C_Status != "未审核")
                    {
                        btnTg.Enabled = false;
                        btnCh.Enabled = false;
                    }
                    else
                    {
                        btnTg.Attributes.Add("onclick", "return confirm('你确认该条信息要通过审核吗？');");
                        btnCh.Attributes.Add("onclick", "return confirm('你确认该条信息要撤回吗？');");
                    }
                    if (model.A_ID != string.Empty)
                    {
                        btnHf.Enabled = false;
                    }
                }
                else
                {
                    btnTg.Enabled = false;
                    btnCh.Enabled = false;
                    btnHf.Enabled = false;
                }
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
                    result = ServiceDepartmentInfoManage.GetInstance().Delete(codes[i]);
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
    }
}