using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using System.Data;
using Winsoft.Common;

namespace Winsoft.Web
{
    public partial class spxq : System.Web.UI.Page
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public string ClientIP
        {
            get
            {
                string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindHistory();
                Bind();
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
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

                if (model != null)
                {
                    #region 加载评论信息

                    BindComment(model);

                    #endregion

                    #region 加载课程创建人信息

                    BindCreated(model);

                    #endregion

                    #region 加载相关视频信息

                    BindRelated(model);

                    #endregion

                    #region 加载菜单信息

                    PrizeExchangeInfo modelVidoTypeInfo = PrizeExchangeInfoManage.GetInstance().GetModel(model.VT_ID);

                    if (modelVidoTypeInfo != null)
                    {
                        this.V_Title.Text = modelVidoTypeInfo.VT_Name;
                        this.V_ETitle.Text = modelVidoTypeInfo.VT_EName;
                    }

                    #endregion

                    #region 加载课程信息

                    BindLesson(id);

                    #endregion

                    #region 加载视频信息

                    this.divPreview.Visible = false;
                    this.divWatch.Visible = false;

                    if (modelMemberInfo != null)
                    {
                        OrderInfo modelOrderInfo = OrderInfoManage.GetInstance().GetModel(id, modelMemberInfo.M_ID);
                        if (modelOrderInfo != null && modelOrderInfo.O_Status == "已付款")
                        {
                            this.divWatch.Visible = true;
                            BindWatch(model);
                        }
                        else
                        {
                            this.divPreview.Visible = true;
                            BindPreview(model);
                        }
                    }
                    else
                    {
                        this.divPreview.Visible = true;
                        BindPreview(model);
                    }

                    #endregion
                }
                else
                {
                    Response.Redirect("998.htm");
                }
            }
            else
            {
                Response.Redirect("998.htm");
            }
        }

        /// <summary>
        /// 预览视频
        /// </summary>
        private void BindPreview(VidoInfo model)
        {
            this.V_Name.Text = model.V_Name;
            this.V_BigImg.Src = model.V_BigImg;
            this.V_LessonCount.Text = model.V_LessonCount.ToString();
            this.V_BrowseCount.Text = model.V_BrowseCount.ToString();
            this.V_BuyCount.Text = model.V_BuyCount.ToString();
            this.V_Time.Text = model.V_Time.ToString("yyyy-MM-dd");
            this.V_Price.Text = "￥" + model.V_Price.ToString("f2");
            this.V_NewPrice.Text = "￥" + model.V_NewPrice.ToString("f2");
            this.V_Content.Text = model.V_Content;
        }

        /// <summary>
        /// 观看视频
        /// </summary>
        private void BindWatch(VidoInfo model)
        {
            this.V_Name.Text = model.V_Name;
            this.V_Content.Text = model.V_Content;

            string fldOrder = " p1.VL_Order desc";//排序字段名
            string strWhere = " and p1.V_ID='" + model.V_ID + "'";//查询条件

            DataTable dtList = VidoLessonInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);

            if (dtList != null && dtList.Rows.Count > 0)
            {
                this.VL_BigImg.Value = StringUtil.GetStrUrl(dtList.Rows[0]["VL_BigImg"].ToString());
                this.VL_Vido.Value = dtList.Rows[0]["VL_Vido"].ToString();
            }

            //更新播放次数
            model.V_PlayCount = model.V_PlayCount + 1;
            model.V_PlayCountReal = model.V_PlayCountReal + 1;
            VidoInfoManage.GetInstance().Update(model);
        }

        /// <summary>
        /// 课程信息
        /// </summary>
        private void BindLesson(string V_ID)
        {
            string fldOrder = " p1.VL_Order desc";//排序字段名
            string strWhere = " and p1.V_ID='" + V_ID + "'";//查询条件

            DataTable dtList = VidoLessonInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            this.rtManage.DataSource = dtList;
            this.rtManage.DataBind();
        }

        /// <summary>
        /// 相关视频
        /// </summary>
        private void BindRelated(VidoInfo model)
        {
            if (model.V_Keyword != string.Empty)
            {
                string strWhere = "";
                string fldOrder = " p1.V_Time desc";//排序字段名
                DataTable dtList = VidoInfoManage.GetInstance().GetPageKeyword(10, model.V_Keyword, "");

                if (dtList != null && dtList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            strWhere = " p1.V_Keyword like '%" + dtList.Rows[i]["value_str"].ToString() + "%'";
                        }
                        else
                        {
                            strWhere += " or p1.V_Keyword like '%" + dtList.Rows[i]["value_str"].ToString() + "%'";
                        }
                    }
                }

                if (strWhere != string.Empty)
                {
                    strWhere = " and V_ID!='" + model.V_ID + "' and (" + strWhere + ")";
                    this.rtRelated.DataSource = VidoInfoManage.GetInstance().GetPageList(10, 1, strWhere, fldOrder, 0);
                    this.rtRelated.DataBind();
                }
            }
        }

        /// <summary>
        /// 课程创建人
        /// </summary>
        private void BindCreated(VidoInfo model)
        {
            PrizeInfo modelMemberInfo = PrizeInfoManage.GetInstance().GetModel(model.M_ID);
            if (modelMemberInfo != null)
            {
                this.M_Img.Src = modelMemberInfo.M_Img;
                this.M_Name.Text = modelMemberInfo.M_Name;
                this.M_About.Text = modelMemberInfo.M_About;
            }
        }

        /// <summary>
        /// 评论信息
        /// </summary>
        private void BindComment(VidoInfo model)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            string fldOrder = " p1.C_Time";//排序字段名
            string strWhere = " and p1.C_Status ='已审核' and p1.V_ID='" + model.V_ID + "'";//查询条件

            if (modelMemberInfo != null)
            {
                strWhere += " or p1.M_ID='" + modelMemberInfo.M_ID + "'";
            }

            DataTable dtList = ServiceDepartmentInfoManage.GetInstance().GetPageList(0, 0, strWhere, fldOrder, 2);

            this.rtComment.DataSource = dtList;
            this.rtComment.DataBind();
        }

        /// <summary>
        /// 添加浏览记录
        /// </summary>
        private void BindHistory()
        {
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    //更新浏览次数
                    model.V_BrowseCount = model.V_BrowseCount + 1;
                    model.V_BrowseCountReal = model.V_BrowseCountReal + 1;
                    VidoInfoManage.GetInstance().Update(model);

                    //更新浏览记录
                    ProvinceInfo modelVidoHistoryInfo = ProvinceInfoManage.GetInstance().GetModel(id, ClientIP);
                    if (modelVidoHistoryInfo != null)
                    {
                        modelVidoHistoryInfo.VH_Time = DateTime.Now;
                        ProvinceInfoManage.GetInstance().Update(modelVidoHistoryInfo);
                    }
                    else
                    {
                        modelVidoHistoryInfo = new ProvinceInfo();
                        modelVidoHistoryInfo.VH_ID = Guid.NewGuid().ToString();
                        modelVidoHistoryInfo.V_ID = id;
                        modelVidoHistoryInfo.VH_IP = ClientIP;
                        modelVidoHistoryInfo.VH_Time = DateTime.Now;
                        ProvinceInfoManage.GetInstance().Add(modelVidoHistoryInfo);
                    }
                }
                else
                {
                    Response.Redirect("998.htm");
                }
            }
            else
            {
                Response.Redirect("998.htm");
            }
        }

        #endregion

        #region 数据处理

        /// <summary>
        /// 购买课程
        /// </summary>
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    OrderInfo modelOrderInfo = OrderInfoManage.GetInstance().GetModel(id, modelMemberInfo.M_ID);
                    if (modelOrderInfo == null)
                    {
                        modelOrderInfo = new OrderInfo();
                        modelOrderInfo.O_ID = Guid.NewGuid().ToString();
                        modelOrderInfo.V_ID = id;
                        modelOrderInfo.M_ID = modelMemberInfo.M_ID;
                        modelOrderInfo.O_Serial = "";
                        modelOrderInfo.O_Order = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        modelOrderInfo.O_Price = model.V_NewPrice;
                        modelOrderInfo.O_Status = "已下单";
                        modelOrderInfo.O_NextTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        modelOrderInfo.O_PaymentTime = "";
                        modelOrderInfo.O_Time = DateTime.Now;

                        OrderInfoManage.GetInstance().Add(modelOrderInfo);

                        MessageBox.ShowAndRedirect(this, "下单成功！", "#aVido");
                        
                    }
                    else if (modelOrderInfo.O_Status == "已下单")
                    {
                        //测试付款

                        if (BindTest(modelOrderInfo.O_Order))
                        {
                            MessageBox.ShowAndRedirect(this, "付款成功！", "#aVido");
                        }
                        else
                        {
                            MessageBox.ShowAndRedirect(this, "付款失败！", "#aVido");
                        }
                        //MessageBox.ShowAndRedirect(this, "您已购买该视频，还未付款！！");
                    }
                    else if (modelOrderInfo.O_Status == "已付款")
                    {
                        MessageBox.ShowAndRedirect(this, "您已购买该视频，不需要重复购买！", "#aVido");
                    }
                    else
                    {
                        MessageBox.ShowAndRedirect(this, "购买失败！", "#aVido");
                    }
                }
                else
                {
                    Response.Redirect("998.htm");
                }
            }
            else
            {
                Response.Redirect("998.htm");
            }
        }

        /// <summary>
        /// 收藏
        /// </summary>
        protected void btnCollection_Click(object sender, EventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    ActivityInfo modelCollectionInfo = ActivityInfoManage.GetInstance().GetModel(id, modelMemberInfo.M_ID);
                    if (modelCollectionInfo != null)
                    {
                        MessageBox.ShowAndRedirect(this, "您已经加入收藏！", "#aVido");
                    }
                    else
                    {
                        modelCollectionInfo = new ActivityInfo();
                        modelCollectionInfo.C_ID = Guid.NewGuid().ToString();
                        modelCollectionInfo.V_ID = id;
                        modelCollectionInfo.M_ID = modelMemberInfo.M_ID;
                        modelCollectionInfo.C_Time = DateTime.Now;

                        //加入收藏
                        ActivityInfoManage.GetInstance().Add(modelCollectionInfo);

                        //更新收藏次数
                        model.V_CollectionCount = model.V_CollectionCount + 1;
                        model.V_CollectionCountReal = model.V_CollectionCountReal + 1;
                        VidoInfoManage.GetInstance().Update(model);

                        MessageBox.ShowAndRedirect(this, "收藏成功！", "#aVido");
                    }
                }
                else
                {
                    Response.Redirect("998.htm");
                }
            }
            else
            {
                Response.Redirect("998.htm");
            }
        }

        /// <summary>
        /// 没有购买视频无法观看
        /// </summary>
        protected void rtManage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string VL_ID = e.CommandArgument.ToString();
            if (e.CommandName == "VLSmallImg" || e.CommandName == "VLName")
            {
                HiddenField hdfVID = (HiddenField)e.Item.FindControl("hdfVID");
                ImageButton btnVLSmallImg = (ImageButton)e.Item.FindControl("btnVLSmallImg");
                LinkButton btnVLName = (LinkButton)e.Item.FindControl("btnVLName");

                OrderInfo modelOrderInfo = OrderInfoManage.GetInstance().GetModel(hdfVID.Value.Trim(), modelMemberInfo.M_ID);

                if (modelMemberInfo != null && modelOrderInfo != null && modelOrderInfo.O_Status == "已付款")
                {
                    VidoLessonInfo modelVidoLessonInfo = VidoLessonInfoManage.GetInstance().GetModel(VL_ID);
                    if (modelVidoLessonInfo != null)
                    {
                        this.VL_Vido.Value = modelVidoLessonInfo.VL_Vido;
                        this.VL_BigImg.Value = StringUtil.GetStrUrl(modelVidoLessonInfo.VL_BigImg);

                        //更新播放次数
                        VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(modelVidoLessonInfo.V_ID);
                        if (modelVidoInfo != null)
                        {
                            modelVidoInfo.V_PlayCount = modelVidoInfo.V_PlayCount + 1;
                            modelVidoInfo.V_PlayCountReal = modelVidoInfo.V_PlayCountReal + 1;
                            VidoInfoManage.GetInstance().Update(modelVidoInfo);
                        }
                        this.divWatch.Visible = true;
                        this.divPreview.Visible = false;
                    }
                }
                else
                {
                    MessageBox.ShowAndRedirect(this, "请先购买在进行观看！", "#aVido");
                }
            }
        }

        /// <summary>
        /// 评价
        /// </summary>
        protected void btnComment_Click(object sender, EventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];

            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }

            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    string C_Content = this.C_Content.Value.Trim();

                    if (C_Content == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('请输入评论内容！')", true);
                    }
                    else
                    {
                        ServiceDepartmentInfo modelCommentInfo = new ServiceDepartmentInfo();
                        modelCommentInfo.C_ID = Guid.NewGuid().ToString();
                        modelCommentInfo.V_ID = model.V_ID;
                        modelCommentInfo.M_ID = modelMemberInfo.M_ID;
                        modelCommentInfo.A_ID = "";
                        modelCommentInfo.C_Status = "未审核";
                        modelCommentInfo.C_Content = C_Content;
                        modelCommentInfo.C_Time = DateTime.Now;
                        modelCommentInfo.C_ReplyContent = "";
                        modelCommentInfo.C_ReplyTime = "";

                        ServiceDepartmentInfoManage.GetInstance().Add(modelCommentInfo);

                        this.C_Content.Value = "";

                        VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(id);
                        BindComment(modelVidoInfo);
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "UpdateSucceed", "alert('评价成功，等待后台审核！')", true);
                    }
                }
                else
                {
                    Response.Redirect("998.htm");
                }
            }
            else
            {
                Response.Redirect("998.htm");
            }
        }

        #endregion

        #region 测试付款

        private bool BindTest(string O_Order)
        {
            if (O_Order != null && O_Order != string.Empty)
            {
                OrderInfo model = OrderInfoManage.GetInstance().GetModelByOrder(O_Order);

                if (model != null)
                {
                    model.O_Status = "已付款";
                    model.O_PaymentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    OrderInfoManage.GetInstance().Update(model);

                    //更新购买次数
                    VidoInfo modelVidoInfo = VidoInfoManage.GetInstance().GetModel(model.V_ID);
                    modelVidoInfo.V_BuyCount = modelVidoInfo.V_BuyCount + 1;
                    modelVidoInfo.V_BuyCountReal = modelVidoInfo.V_BuyCountReal + 1;
                    VidoInfoManage.GetInstance().Update(modelVidoInfo);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}