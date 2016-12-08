using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Common;
using Winsoft.BLL;
using Winsoft.Model;
using System.Data;

namespace Winsoft.Web.admin.main.scsp
{
    public partial class spzb_tjxg : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public string f_img2;
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
                    string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    if (f_menu != string.Empty)
                    {
                        this.lblMenu.Text = f_menu;
                        CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                        if (model != null)
                        {
                            M_Url = model.M_Url;
                        }
                        Bind();
                    }
                }
            }
        }

        #region 数据加载

        private void Bind(string pid)
        {
            VidoLessonInfo model = VidoLessonInfoManage.GetInstance().GetModel(pid);

            this.VL_Name.Value = model.VL_Name;

            if (model.VL_SmallImg != string.Empty)
            {
                this.VL_SmallImg.ImageUrl = model.VL_SmallImg;
            }

            if (model.VL_BigImg != string.Empty)
            {
                this.VL_BigImg.ImageUrl = model.VL_BigImg;
            }

            //加载视频信息
            VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(model.V_ID);
            if (modelVidoInfo != null)
            {
                this.V_Name.Value = modelVidoInfo.V_Name;
                this.V_Content.Value = modelVidoInfo.V_Content;

                //加载视频类型信息
                PrizeExchangeInfo modelVidoTypeInfo = PrizeExchangeInfoManage.GetInstance().GetModel(modelVidoInfo.VT_ID);

                this.VT_Name.Value = modelVidoTypeInfo.VT_Name;
            }
        }

        private void Bind()
        {
            string id = Request["id"];
            string sj = Request["sj"];
            if (id != null && id != string.Empty)
            {
                IntegralInfo model = IntegralInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    BindWeek(model.VL_LiveSTime);
                    this.VL_STime.Value = model.VL_LiveSTime.ToString("HH:mm:ss");
                    this.VL_LiveETime.Value = model.VL_LiveETime.ToString("yyyy-MM-dd HH:mm:ss");
                    this.VL_Vido.Value = model.VL_Vido;
                    this.VL_PID.Value = model.VL_PID;
                    BindWeek(model.VL_LiveSTime);
                    Bind(model.VL_PID);
                }
            }
            else if (sj != null && sj != string.Empty)
            {
                BindWeek(Convert.ToDateTime(sj));
            }
            else
            {
                BindWeek(DateTime.Now);
            }
        }

        /// <summary>
        /// 加载时间信息
        /// </summary>
        private void BindWeek(DateTime date)
        {
            #region 星期

            string week = date.DayOfWeek.ToString();

            string weekday = "";
            switch (week)
            {
                case "Monday":
                    weekday = "星期一";
                    break;
                case "Tuesday":
                    weekday = "星期二";
                    break;
                case "Wednesday":
                    weekday = "星期三";
                    break;
                case "Thursday":
                    weekday = "星期四";
                    break;
                case "Friday":
                    weekday = "星期五";
                    break;
                case "Saturday":
                    weekday = "星期六";
                    break;
                case "Sunday":
                    weekday = "星期日";
                    break;
            }

            this.lblTitle.Text = date.ToString("yyyy年MM月dd日") + " " + weekday;
            this.H_Time.Value = date.ToString("yyyy-MM-dd");

            #endregion
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool result = true;
            string id = Request["id"];
            string VL_PID = this.VL_PID.Value.Trim();
            string VL_Vido = this.VL_Vido.Value.Trim();
            string VL_LiveETime = this.VL_LiveETime.Value.Trim();
            string H_Time = this.H_Time.Value.Trim();
            string VL_LiveSTime = "";
            string VL_STime = this.VL_STime.Value.Trim();

            //获取课时信息
            VidoLessonInfo modelVidoLessonInfo = VidoLessonInfoManage.GetInstance().GetModel(VL_PID);

            if (H_Time == string.Empty)
            {
                MessageBox.Show(this, "请选择播放日期！");
            }
            else if (VL_PID == string.Empty || modelVidoLessonInfo == null)
            {
                MessageBox.Show(this, "请选择课程信息！");
            }
            else if (VL_STime == string.Empty)
            {
                MessageBox.Show(this, "请输入开始时间！");
            }
            else if (VL_Vido == string.Empty)
            {
                MessageBox.Show(this, "请输入视频地址！");
            }
            else
            {
                //判断开始时间有没有被其它直播时间占用
                VL_LiveSTime = H_Time + " " + VL_STime;
                string strSTimeWhere = " '" + VL_LiveSTime + "' between VL_LiveSTime and VL_LiveETime ";
                if (id != null && id != string.Empty)
                {
                    strSTimeWhere += " and VL_ID != '" + id + "'";
                }

                DataTable dtSTimeList = IntegralInfoManage.GetInstance().GetList(strSTimeWhere).Tables[0];

                if (dtSTimeList != null && dtSTimeList.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该播放时间段已被其它视频占用，请另选播放时间！");
                }
                else
                {
                    #region 获取视频时长

                    DateTime dateLength = Convert.ToDateTime(modelVidoLessonInfo.VL_Length);
                    DateTime dateSTime = Convert.ToDateTime(VL_LiveSTime);
                    //计算视频结算时间
                    VL_LiveETime = dateSTime.AddHours(dateLength.Hour).AddMinutes(dateLength.Minute).AddSeconds(dateLength.Second).ToString("yyyy-MM-dd HH:mm:ss");

                    #endregion

                    string strETimeWhere = " '" + VL_LiveETime + "' between VL_LiveSTime and VL_LiveETime ";
                    if (id != null && id != string.Empty)
                    {
                        strETimeWhere += " and VL_ID != '" + id + "'";
                    }
                    DataTable dtETimeList = IntegralInfoManage.GetInstance().GetList(strETimeWhere).Tables[0];
                    if (dtETimeList != null && dtETimeList.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "该播放时间段已被其它视频占用，请另选播放时间！");
                    }
                    else
                    {
                        #region 初始化信息

                        IntegralInfo model = null;

                        if (id != null && id != string.Empty)
                        {
                            model = IntegralInfoManage.GetInstance().GetModel(id);
                        }
                        else
                        {
                            model = new IntegralInfo();
                        }

                        #endregion

                        model.VL_PID = modelVidoLessonInfo.VL_ID;
                        model.VL_LiveSTime = Convert.ToDateTime(VL_LiveSTime);
                        model.VL_LiveETime = Convert.ToDateTime(VL_LiveETime);
                        model.VL_Vido = VL_Vido;

                        if (id != null && id != string.Empty)
                        {
                            result = IntegralInfoManage.GetInstance().Update(model);
                        }
                        else
                        {
                            model.VL_ID = Guid.NewGuid().ToString();
                            model.VL_Time = DateTime.Now;
                            IntegralInfoManage.GetInstance().Add(model);
                        }

                        if (result)
                        {
                            this.VL_LiveETime.Value = model.VL_LiveETime.ToString("yyyy-MM-dd HH:mm:ss");
                            MessageBox.Show(this, "操作成功！");
                        }
                        else
                        {
                            MessageBox.Show(this, "操作失败！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMem_Click(object sender, EventArgs e)
        {
            string VL_PID = this.VL_PID.Value.Trim();
            if (VL_PID == string.Empty)
            {
                MessageBox.ResponseScript(this, "showBox();");
            }
            else
            {
                Bind(VL_PID);
            }
        }

        #endregion

        #region 数据跳转

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("../" + M_Url);
        }

        #endregion
    }
}