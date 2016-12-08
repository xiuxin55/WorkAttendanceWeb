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
using System.Text;

namespace Winsoft.Web.admin.main.scsp
{
    public partial class spzb : System.Web.UI.Page
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
                    }
                    BindInit();
                }
            }
        }

        #region 数据加载

        private void BindInit()
        {
            this.btnPre.CssClass = "dzlc_ttl_a1";
            this.btnNow.CssClass = "dzlc_ttl_a2";
            this.btnNext.CssClass = "dzlc_ttl_a1";

            DateTime nowDate = DateTime.Now;
            BindWeek(nowDate);
        }

        /// <summary>
        /// 加载按钮样式
        /// </summary>
        private void BindWeek(DateTime date)
        {
            this.H_Time.Value = date.ToString("yyyy-MM-dd");
            this.VL_LiveTime.Text = date.ToString("yyyy-MM-dd");

            #region 星期

            string week = date.DayOfWeek.ToString();
            //定义样式
            this.btnDay1.CssClass = "dzlc_ttl_a1";
            this.btnDay2.CssClass = "dzlc_ttl_a1";
            this.btnDay3.CssClass = "dzlc_ttl_a1";
            this.btnDay4.CssClass = "dzlc_ttl_a1";
            this.btnDay5.CssClass = "dzlc_ttl_a1";
            this.btnDay6.CssClass = "dzlc_ttl_a1";
            this.btnDay7.CssClass = "dzlc_ttl_a1";

            string weekday = "";
            switch (week)
            {
                case "Monday":
                    weekday = "星期一";
                    this.btnDay1.CssClass = "dzlc_ttl_a2";
                    break;
                case "Tuesday":
                    weekday = "星期二";
                    this.btnDay2.CssClass = "dzlc_ttl_a2";
                    break;
                case "Wednesday":
                    weekday = "星期三";
                    this.btnDay3.CssClass = "dzlc_ttl_a2";
                    break;
                case "Thursday":
                    weekday = "星期四";
                    this.btnDay4.CssClass = "dzlc_ttl_a2";
                    break;
                case "Friday":
                    weekday = "星期五";
                    this.btnDay5.CssClass = "dzlc_ttl_a2";
                    break;
                case "Saturday":
                    weekday = "星期六";
                    this.btnDay6.CssClass = "dzlc_ttl_a2";
                    break;
                case "Sunday":
                    weekday = "星期日";
                    this.btnDay7.CssClass = "dzlc_ttl_a2";
                    break;
            }

            this.lblTitle.Text = date.ToString("yyyy年MM月dd日") + " " + weekday + " 播放列表";

            #endregion

            Bind();
        }

        /// <summary>
        /// 获取星期
        /// </summary>
        private int GetWeekDay(DateTime date)
        {
            string week = date.DayOfWeek.ToString();

            int weekday = 0;
            switch (week)
            {
                case "Monday":
                    weekday = 1;
                    break;
                case "Tuesday":
                    weekday = 2;
                    break;
                case "Wednesday":
                    weekday = 3;
                    break;
                case "Thursday":
                    weekday = 4;
                    break;
                case "Friday":
                    weekday = 5;
                    break;
                case "Saturday":
                    weekday = 6;
                    break;
                case "Sunday":
                    weekday = 7;
                    break;
            }

            return weekday;
        }

        #endregion

        #region 数据查询

        private void Bind()
        {
            string VL_LiveTime = this.H_Time.Value.Trim();
            string fldOrder = " p1.VL_LiveSTime";//排序字段名
            string strWhere = "";//查询条件

            if (VL_LiveTime != string.Empty)
            {
                strWhere += " and p1.VL_LiveSTime between '" + VL_LiveTime + " 00:00:00' and '" + VL_LiveTime + " 23:59:59'";
            }

            DataTable dtLsit = IntegralInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            this.rtManager.DataSource = dtLsit;
            this.rtManager.DataBind();
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            string date = this.VL_LiveTime.Text.Trim();
            if (date == string.Empty)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }

            BindWeek(Convert.ToDateTime(date));
        }

        #endregion

        #region 数据处理

        protected void rtManager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            //删除
            if (e.CommandName == "delete")
            {
                bool result = IntegralInfoManage.GetInstance().Delete(id);

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
                    result = IntegralInfoManage.GetInstance().Delete(codes[i]);
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
            string sj = this.H_Time.Value.Trim();
            if (sj == string.Empty)
            {
                MessageBox.Show(this, "请选择直播时间！");
            }
            else
            {
                Response.Redirect(M_EUrl + "&sj=" + sj);
            }
        }

        #endregion

        #region 周、星期切换

        /// <summary>
        /// 上一周
        /// </summary>
        protected void btnPre_Click(object sender, EventArgs e)
        {
            this.btnPre.CssClass = "dzlc_ttl_a2";
            this.btnNow.CssClass = "dzlc_ttl_a1";
            this.btnNext.CssClass = "dzlc_ttl_a1";
            string date = this.H_Time.Value.Trim();
            BindWeek(Convert.ToDateTime(date).AddDays(-7));
        }

        /// <summary>
        /// 本周
        /// </summary>
        protected void btnNow_Click(object sender, EventArgs e)
        {
            this.btnPre.CssClass = "dzlc_ttl_a1";
            this.btnNow.CssClass = "dzlc_ttl_a2";
            this.btnNext.CssClass = "dzlc_ttl_a1";
            BindWeek(DateTime.Now);
        }

        /// <summary>
        /// 下一周
        /// </summary>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            this.btnPre.CssClass = "dzlc_ttl_a1";
            this.btnNow.CssClass = "dzlc_ttl_a1";
            this.btnNext.CssClass = "dzlc_ttl_a2";
            string date = this.H_Time.Value.Trim();
            BindWeek(Convert.ToDateTime(date).AddDays(7));
        }

        /// <summary>
        /// 星期一
        /// </summary>
        protected void btnDay1_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(1 - weekDay));
        }

        /// <summary>
        /// 星期二
        /// </summary>
        protected void btnDay2_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(2 - weekDay));
        }

        /// <summary>
        /// 星期三
        /// </summary>
        protected void btnDay3_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(3 - weekDay));
        }

        /// <summary>
        /// 星期四
        /// </summary>
        protected void btnDay4_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(4 - weekDay));
        }

        /// <summary>
        /// 星期五
        /// </summary>
        protected void btnDay5_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(5 - weekDay));
        }

        /// <summary>
        /// 星期六
        /// </summary>
        protected void btnDay6_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(6 - weekDay));
        }

        /// <summary>
        /// 星期日
        /// </summary>
        protected void btnDay7_Click(object sender, EventArgs e)
        {
            string date = this.H_Time.Value.Trim();
            int weekDay = GetWeekDay(Convert.ToDateTime(date));
            BindWeek(Convert.ToDateTime(date).AddDays(7 - weekDay));
        }

        #endregion
    }
}