using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web.admin.main.htyh
{
    public partial class hyxx_ywdjinfo : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public static bool AddAndUpdate = true;
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
                        this.lblMenu.Text = "兑奖管理》已兑奖》兑奖信息";
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                        M_Url = "hyxx_wdjinfo.aspx";
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

        #region 数据加载
  
        private void Bind()
        {
            string id = Request["id"];

            if (id != null && id != string.Empty)
            {
                PrizeExchangeInfo ModelData = PrizeExchangeInfoManage.GetInstance().GetModel(id);
                if (ModelData != null)
                {
                    AddAndUpdate = false;
                    this.Prize_user.Value = ModelData.Prize_user;
                    this.Prize_GetPrizeName.Value = ModelData.Prize_GetPrizeName;
                    this.Prize_CardNum.Value = ModelData.Prize_CardNum;
                    this.Prize_IdentifyCard.Value = ModelData.Prize_IdentifyCard;
                    this.Pize_PushCom.Value = ModelData.Pize_PushCom;
                    this.Pize_PushPerson.Value = ModelData.Pize_PushPerson;

                          this.Pize_GetPrizeDateTime.Value = ModelData.Pize_GetPrizeDateTime;
                          this.Pize_GetPrizeTime.Value = ModelData.Pize_GetPrizeTime;
                           this.Prize_GetUserName.Value= ModelData.Prize_GetUserName;
                            this.Prize_GetUserContact.Value=ModelData.Prize_GetUserContact;
                          this.Prize_GetUserIdentifyCard.Value = ModelData.Prize_GetUserIdentifyCard;

                          this.PrizeID.Value = ModelData.Pize_PrizeID;
                         
                }
            }
            else
            {
                AddAndUpdate = true;
            }
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
            
            //string id = Request["id"];
            //string WebsiteID = this.WebsiteID.Value;
            //string WebsiteName = this.WebsiteName.Value;
            //string WebsiteType = this.WebsiteType.Text;
            //string WebsiteFlag = this.WebsiteFlag.Text;

            if (this.Prize_GetUserName.Value.Trim() == "" && this.Prize_GetUserContact.Value.Trim() == "" && this.Prize_GetUserIdentifyCard.Value.Trim() == "")
            {
                MessageBox.Show(pageparam, "领取人姓名、联系方式、身份证号均不能为空！");
                return;
            }
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                PrizeExchangeInfo ModelData = PrizeExchangeInfoManage.GetInstance().GetModel(id);

                ModelData.Prize_GetUserName = this.Prize_GetUserName.Value;
                ModelData.Prize_GetUserContact = this.Prize_GetUserContact.Value;
                ModelData.Prize_GetUserIdentifyCard = this.Prize_GetUserIdentifyCard.Value;
                ModelData.Pize_PrizeID = this.PrizeID.Value;
                ModelData.Prize_Flag = "0";
                DateTime dtime = DateTime.Now;
                ModelData.Pize_GetPrizeDateTime = dtime.ToShortDateString();
                ModelData.Pize_GetPrizeTime = dtime.ToString();
                UserInfo ui = Session["sysAdmin"] as UserInfo;
                ModelData.Pize_UserNum = ui.US_Name;
                WebSiteModel website = new WebSiteModel();
                website = WebsiteManage.GetInstance().GetModelByWebsiteName(ui.US_WebsiteName);
                ModelData.Pize_WebsiteNum = website.WebsiteID;
                if (website.WebsiteFlag == null || website.WebsiteFlag == "1")
                {
                    MessageBox.Show(pageparam, "该网点不存在或已经禁用！");
                    return;
                }
                //bool result = PrizeExchangeInfoManage.GetInstance().Update(ModelData);
                PrizeAllocateModel pam = new PrizeAllocateModel();
                pam.PrizeName = this.Prize_GetPrizeName.Value ;
                pam.WebsiteID = website.WebsiteID;
                bool result = PrizeExchangeInfoManage.GetInstance().UpdatePrizeCount(pam, ModelData,1);
                if (result)
                {
                    MessageBox.Show(pageparam, "操作成功！");
                    Response.Write("<script language='javascript'> window.opener.document.location.reload();</script>");
                    Response.Write("<script>window.opener=null;window.close();</script>");

                }
                else
                {
                    MessageBox.Show(pageparam, "操作失败！");
                }


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
            Response.Write("<script>window.close();</script>");
            
        }

        #endregion

        protected void btnResultRefund_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                PrizeExchangeInfo ModelData = PrizeExchangeInfoManage.GetInstance().GetModel(id);
                ModelData.Prize_Flag = "2";
                PrizeAllocateModel pam = new PrizeAllocateModel();
                pam.PrizeName = ModelData.Prize_Name;
                pam.PrizeID = ModelData.Pize_PrizeID;
                pam.WebsiteID = ModelData.Pize_WebsiteNum;
                bool result = PrizeExchangeInfoManage.GetInstance().UpdatePrizeCount(pam, ModelData, 1);
                if (result)
                {
                    Response.Write("<script>alert('作废成功');</script>");
                    Response.Write("<script language='javascript'> window.opener.document.location.reload();</script>");
                    Response.Write("<script>window.opener=null;window.returnValue=2;window.close();</script>");


                }
                else
                {
                    Response.Write("<script>alert('作废失败');</script>");
                }
            }
        }
    }
}