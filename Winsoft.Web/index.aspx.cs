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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            DataTable dtList = null;
            string fldOrder = "";//排序字段名
            string strWhere = "";//查询条件

            #region 大厅管理

            #region 视频直播

            BindLive(); 

            #endregion

            #region 最新视频

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001002002'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(20, 1, strWhere, fldOrder, 0);
            this.rtZxsp.DataSource = dtList;
            this.rtZxsp.DataBind();

            #endregion

            #endregion

            #region 一楼管理

            #region 视频标题

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001003001'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt1FA.DataSource = dtList;
            this.rt1FA.DataBind();

            #endregion

            #region 视频信息 495 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001003002' and N_Type=1";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt1FB.DataSource = dtList;
            this.rt1FB.DataBind();

            #endregion

            #region 视频信息 245 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001003002' and N_Type=2";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(5, 1, strWhere, fldOrder, 0);
            this.rt1FC.DataSource = dtList;
            this.rt1FC.DataBind();

            #endregion

            #endregion

            #region 二楼管理

            #region 视频标题

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001004001'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt2FA.DataSource = dtList;
            this.rt2FA.DataBind();

            #endregion

            #region 视频信息 495 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001004002' and N_Type=1";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt2FB.DataSource = dtList;
            this.rt2FB.DataBind();

            #endregion

            #region 视频信息 245 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001004002' and N_Type=2";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(5, 1, strWhere, fldOrder, 0);
            this.rt2FC.DataSource = dtList;
            this.rt2FC.DataBind();

            #endregion

            #endregion

            #region 三楼管理

            #region 视频标题

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001005001'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt3FA.DataSource = dtList;
            this.rt3FA.DataBind();

            #endregion

            #region 视频信息 495 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001005002' and N_Type=1";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt3FB.DataSource = dtList;
            this.rt3FB.DataBind();

            #endregion

            #region 视频信息 245 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001005002' and N_Type=2";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(5, 1, strWhere, fldOrder, 0);
            this.rt3FC.DataSource = dtList;
            this.rt3FC.DataBind();

            #endregion

            #endregion

            #region 四楼管理

            #region 视频标题

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001006001'";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt4FA.DataSource = dtList;
            this.rt4FA.DataBind();

            #endregion

            #region 视频信息 495 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001006002' and N_Type=1";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(1, 1, strWhere, fldOrder, 0);
            this.rt4FB.DataSource = dtList;
            this.rt4FB.DataBind();

            #endregion

            #region 视频信息 245 x 190

            fldOrder = " N_Order";//排序字段名
            strWhere = " and M_ID='001006002' and N_Type=2";//查询条件
            dtList = NewsInfoManage.GetInstance().GetPageList(5, 1, strWhere, fldOrder, 0);
            this.rt4FC.DataSource = dtList;
            this.rt4FC.DataBind();

            #endregion

            #endregion
        }

        /// <summary>
        /// 视频直播
        /// </summary>
        private void BindLive()
        {
            string fldOrder = " p1.VL_LiveSTime";//排序字段名
            string strWhere = " and p1.VL_LiveSTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' or ('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' between p1.VL_LiveSTime and p1.VL_LiveETime)";//查询条件

            DataTable dtLsit = IntegralInfoManage.GetInstance().GetPageList(4, 1, strWhere, fldOrder, 0);

            this.rtSpzb.DataSource = dtLsit;
            this.rtSpzb.DataBind();
        }
    }
}