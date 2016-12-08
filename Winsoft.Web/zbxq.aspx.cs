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
    public partial class zbxq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindNextPlay();
                BindPlay();
                BindInit();
            }
        }

        #region 数据加载

        /// <summary>
        /// 即将播放
        /// </summary>
        private void BindNextPlay()
        {
            string VL_LiveTime = this.H_Time.Value.Trim();
            string fldOrder = " p1.VL_LiveSTime";//排序字段名
            string strWhere = " and p1.VL_LiveSTime > '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";//查询条件

            DataTable dtList = IntegralInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            if (dtList != null && dtList.Rows.Count > 0)
            {
                string VL_LiveSTime = dtList.Rows[0]["VL_LiveSTime"].ToString();
                this.VL_LiveSTime.Value = VL_LiveSTime;
            }
        }

        /// <summary>
        /// 正在播放
        /// </summary>
        private void BindPlay()
        {
            string VL_LiveTime = this.H_Time.Value.Trim();
            string fldOrder = " p1.VL_LiveSTime";//排序字段名
            string strWhere = " and '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' between p1.VL_LiveSTime and p1.VL_LiveETime";//查询条件

            DataTable dtList = IntegralInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            if (dtList != null && dtList.Rows.Count > 0)
            {
                string VL_PID = dtList.Rows[0]["VL_PID"].ToString();
                string VL_Vido = dtList.Rows[0]["VL_Vido"].ToString();
                string VL_LiveSTime = dtList.Rows[0]["VL_LiveSTime"].ToString();
                string VL_LiveETime = dtList.Rows[0]["VL_LiveETime"].ToString();

                //课程信息
                VidoLessonInfo model = VidoLessonInfoManage.GetInstance().GetModel(VL_PID);
                if (model != null)
                {
                    this.divPlay.Visible = true;

                    this.VL_BigImg.Value = StringUtil.GetStrUrl(model.VL_BigImg);
                    this.VL_Vido.Value = VL_Vido;

                    //视频信息
                    VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(model.V_ID);

                    if (modelVidoInfo != null)
                    {
                        this.V_Content.Text = modelVidoInfo.V_Content;
                    }
                }
                else
                {
                    this.divPlay.Visible = false;
                }
            }
            else
            {
                this.divPlay.Visible = false;
            }
        }

        private void BindInit()
        {
            DateTime nowDate = DateTime.Now;
            BindWeek(nowDate);
        }

        /// <summary>
        /// 加载按钮样式
        /// </summary>
        private void BindWeek(DateTime date)
        {
            this.H_Time.Value = date.ToString("yyyy-MM-dd");

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
        /// 加载数据
        /// </summary>
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

            this.rtManage.DataSource = dtLsit;
            this.rtManage.DataBind();
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

        #region 数据处理

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string VL_LiveSTime = this.VL_LiveSTime.Value.Trim();

            if (VL_LiveSTime != string.Empty)
            {
                if (DateTime.Now >= Convert.ToDateTime(VL_LiveSTime))
                {
                    Response.Redirect("zbxq.aspx");
                }
            }
        }

        #endregion

        #region 周、星期切换

        /// <summary>
        /// 上一周
        /// </summary>
        protected void btnPre_Click(object sender, EventArgs e)
        {
            this.btnPre.CssClass = "dzlt_l2";
            this.btnNext.CssClass = "dzlt_r1";
            string date = this.H_Time.Value.Trim();
            BindWeek(Convert.ToDateTime(date).AddDays(-7));
        }

        /// <summary>
        /// 下一周
        /// </summary>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            this.btnPre.CssClass = "dzlt_l1";
            this.btnNext.CssClass = "dzlt_r2";
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