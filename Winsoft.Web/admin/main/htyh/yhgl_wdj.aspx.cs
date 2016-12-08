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

namespace Winsoft.Web.admin.main.htyh
{
    public partial class yhgl_wdj : System.Web.UI.Page
    {
        public static string M_EUrl = "#";
        public static bool IsVisible;
        public System.Web.UI.Page pageparam;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageparam = sender as System.Web.UI.Page;
            IsVisible = false;
            if (!Page.IsPostBack)
            {
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                else
                {
                    //string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    //if (f_menu != string.Empty)
                    //{
                       this.lblMenu.Text = "兑奖管理>>未兑奖";
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                    //        M_EUrl = model.M_EUrl;
                    //    }
                       UserInfo ui = Session["sysAdmin"] as UserInfo;
                       WebSiteModel website = new WebSiteModel();
                       website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
                       if (website == null || website.WebsiteType == "0")
                       {
                           IsVisible = true;
                       }
                       this.rtManager.DataSource = null;
                       this.rtManager.DataBind();
                    //Bind();
                    //}
                }
            }
        }
        /// <summary>
        /// 数据查询，如果已经兑奖则提示已经兑奖
        /// </summary>
        private List<string> Bind2()
        {
            string fldOrder = "Prize_user  desc";//排序字段名
            string strWhere = "";//查询条件
            //this.AspNetPager1.PageSize = int.MaxValue;//页尺寸

            //string M_Username = this.M_Username.Value.Trim();
            //string M_EMail = this.M_EMail.Value.Trim();
            //string M_Address = this.M_Address.Value.Trim();


            strWhere += "   Prize_Flag ='0' ";

            if (this.Prize_CardNum.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_CardNum = '{0}'", this.Prize_CardNum.Value);
            }
            if (this.Prize_IdentifyCard.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_IdentifyCard = '{0}'", this.Prize_IdentifyCard.Value);
            }
            //if (this.Prize_user.Value != string.Empty)
            //{
            //    strWhere += string.Format(" and Prize_user = '{0}'", this.Prize_user.Value);
            //}
            //Prize_user
            //Prize_CardNum
            //Prize_IdentifyCard
            //Prize_Name
            //Pize_PushCom
            //Pize_PushComNum
            //Pize_PushPerson
            //Pize_PushPersonNum
            int StartNum = 0;
            int EndNum = int.MaxValue;

            //int StartNum = this.AspNetPager1.PageSize * (this.AspNetPager1.CurrentPageIndex - 1);
            //int EndNum = this.AspNetPager1.PageSize * this.AspNetPager1.CurrentPageIndex;
            strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            DataTable dtLsit = PrizeExchangeInfoManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
            List<string> IDList = new List<string>();
            foreach (DataRow item in dtLsit.Rows)
            {
                IDList.Add(item["Prize_Guid"].ToString());
            }
            return IDList;
           
        }
        #region 数据查询

        private void Bind()
        {
            string fldOrder = "Prize_user  desc";//排序字段名
            string strWhere = "";//查询条件
            //this.AspNetPager1.PageSize = int.MaxValue;//页尺寸
       
            //string M_Username = this.M_Username.Value.Trim();
            //string M_EMail = this.M_EMail.Value.Trim();
            //string M_Address = this.M_Address.Value.Trim();

  
            strWhere += "   Prize_Flag ='1' ";
            bool issearch = false;
            if (this.Prize_CardNum.Value != string.Empty && this.Prize_CardNum.Value.Trim()!="")
            {
                strWhere += string.Format(" and Prize_CardNum = '{0}'", this.Prize_CardNum.Value);
                issearch = true;
            }
            if (this.Prize_IdentifyCard.Value != string.Empty && this.Prize_IdentifyCard.Value.Trim()!="")
            {
                strWhere += string.Format(" and Prize_IdentifyCard = '{0}'", this.Prize_IdentifyCard.Value);
                issearch = true;
            }
            if (this.Prize_user.Value != string.Empty && this.Prize_user.Value.Trim()!="")
            {
                strWhere += string.Format(" and Prize_user = '{0}'", this.Prize_user.Value);
                issearch = true;
            }
            //Prize_user
            //Prize_CardNum
            //Prize_IdentifyCard
            //Prize_Name
            //Pize_PushCom
            //Pize_PushComNum
            //Pize_PushPerson
            //Pize_PushPersonNum

            int StartNum = 0;
            int EndNum = int.MaxValue;
            if (issearch)
            {
                //int StartNum = this.AspNetPager1.PageSize * (this.AspNetPager1.CurrentPageIndex - 1);
                //int EndNum = this.AspNetPager1.PageSize * this.AspNetPager1.CurrentPageIndex;
                strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
                DataTable dtLsit = PrizeExchangeInfoManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];

                this.rtManager.DataSource = dtLsit;
                this.rtManager.DataBind();
                if (dtLsit == null || dtLsit.Rows.Count == 0)
                {
                    Response.Write("<script>alert('你不符合兑奖条件！');</script>");
                }
            }
            else
            {
                this.rtManager.DataSource = null;
                this.rtManager.DataBind();
            }
        }

        /// <summary>
        /// 查询信息
        /// </summary>
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            List<string> IDList = Bind2();
            if (IDList != null && IDList.Count > 0)
            {
                Response.Write("<script>alert('该客户已兑换奖品');</script>");
                string str = @"<script>
        var iWidth = 500;                          //弹出窗口的宽度;
        var iHeight = 500;                        //弹出窗口的高度;
        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
        var agent = navigator.userAgent.toLowerCase();
        if (agent.indexOf('chrome') > 0)
        { window.open('hyxx_ywdjinfo.aspx?id="+IDList[0]+@"'  ,'newwindow', 'width=500,height=400,top=' + iTop + ' ,left=' + iLeft + ''); }
        else {
            showModalDialog('hyxx_ywdjinfo.aspx?id=" + IDList[0] + @"' , 'newwindow', 'dialogwidth=500,dialogheight=400,dialogtop=' + iTop + ' ,dialogleft=' + iLeft + '');
}
                    </script>";
                Response.Write(str);
            }
            else
            {
                Bind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        #endregion
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string fldOrder = "Prize_user  desc";//排序字段名
            string strWhere = "";//查询条件
            //this.AspNetPager1.PageSize = 15;//页尺寸

            //string M_Username = this.M_Username.Value.Trim();
            //string M_EMail = this.M_EMail.Value.Trim();
            //string M_Address = this.M_Address.Value.Trim();


            UserInfo ui = Session["sysAdmin"] as UserInfo;

            WebSiteModel website = new WebSiteModel();
            website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
            if (website.WebsiteType == "0")
            {

                strWhere += "  Prize_Flag ='1' ";
            }
            else
            {
                strWhere = string.Format(" Pize_WebsiteNum ='{0}' ", website.WebsiteID);
                strWhere += " and  Prize_Flag ='1' ";
            }
            DataSet ds = PrizeExchangeInfoManage.GetInstance().GetListWDJ(strWhere);
            if (ds.Tables.Count > 0)
            {
                DataTable dtLsit = ds.Tables[0];

                //string filename=AppDomain.CurrentDomain.BaseDirectory+ "Files\\"+Guid.NewGuid().ToString().Replace("-","")+".xls";
                //File.Create(filename);

                NPOIHelper.ExportByWeb(dtLsit, "活动未兑奖客户名单", "未兑奖" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls");
                //DownloadFile(filename);
                //File.Delete(filename);
            }
        }
    }
}