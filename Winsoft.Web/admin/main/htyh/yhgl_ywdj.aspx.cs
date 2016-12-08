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
using System.IO;
//using System.Windows.Forms;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class yhgl_ywdj : System.Web.UI.Page
    {
        public static bool IsVisible;
        public static string M_EUrl = "#";
        public System.Web.UI.Page pageparam;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsVisible = false;
            pageparam = sender as System.Web.UI.Page;
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
                    this.lblMenu.Text = "兑奖管理>>已兑奖";
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
                    Bind();
                    //}
                }
            }
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


            UserInfo ui = Session["sysAdmin"] as UserInfo;

            WebSiteModel website = new WebSiteModel();
            website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
            if (website==null || website.WebsiteType == "0")
            {
               
                strWhere += "  Prize_Flag ='0' ";
            }
            else
            {
                strWhere = string.Format(" Pize_WebsiteNum ='{0}' ", website.WebsiteID);
                strWhere += " and  Prize_Flag ='0' ";
            }
            if (website != null)
            {
                if (website.WebsiteFlag == null || website.WebsiteFlag == "1")
                {
                    MessageBox.Show(pageparam, "该网点不存在或已经禁用！");
                    return;
                }
            }

            if (this.Prize_CardNum.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_CardNum like '%{0}%'", this.Prize_CardNum.Value);
            }
            if (this.Prize_IdentifyCard.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_IdentifyCard like '%{0}%'", this.Prize_IdentifyCard.Value);
            }
            if (this.Prize_user.Value != string.Empty)
            {
                strWhere += string.Format(" and Prize_user like '%{0}%'", this.Prize_user.Value);
            }
            int StartNum = 0;
            int EndNum = int.MaxValue;
            //int StartNum = this.AspNetPager1.PageSize * (this.AspNetPager1.CurrentPageIndex - 1);
            //int EndNum = this.AspNetPager1.PageSize * this.AspNetPager1.CurrentPageIndex;
            strWhere += " ) A where Number between " + StartNum + " and " + EndNum;
            DataTable dtLsit = PrizeExchangeInfoManage.GetInstance().GetList(0, strWhere, fldOrder).Tables[0];
            this.rtManager.DataSource = dtLsit;
            this.rtManager.DataBind();
            //if (dtLsit == null || dtLsit.Rows.Count > 0)
            //{
            //    Response.Write("<script>alert('未找到该兑奖记录！');</script>");
            //}
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

                strWhere += "  Prize_Flag !='1' ";
            }
            else
            {
                strWhere = string.Format(" Pize_WebsiteNum ='{0}' ", website.WebsiteID);
                strWhere += " and  Prize_Flag !='1' ";
            }
            DataSet ds=PrizeExchangeInfoManage.GetInstance().GetListYDJ(strWhere);
            if (ds.Tables.Count > 0)
            {
                DataTable dtLsit = ds.Tables[0];
                
                //string filename=AppDomain.CurrentDomain.BaseDirectory+ "Files\\"+Guid.NewGuid().ToString().Replace("-","")+".xls";
                //File.Create(filename);
                NPOIHelper.ExportByWeb(dtLsit, "活动已兑奖客户名单", "已兑奖" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls");
                //DownloadFile(filename);
                //File.Delete(filename);
            }
        }
        private void DownloadFile(string Serverfilename)
        {
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename=CodeShark.zip");
            string filename = Server.MapPath(Serverfilename);
            Response.TransmitFile(filename);
        }
    }
}