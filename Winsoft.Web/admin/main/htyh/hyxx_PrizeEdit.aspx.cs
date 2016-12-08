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
    public partial class hyxx_PrizeEdit : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public static bool AddAndUpdate = true;
        public System.Web.UI.Page pageparam;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                        M_Url = "htyh/hyxx_PrizeEdit.aspx";
                    //    }
                        
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
               
                this.lblMenu1.Text = "菜单管理";
                this.lblMenu2.Text = "奖品编辑";
                this.lblMenu2.NavigateUrl = Request.RawUrl;
                Session["奖品编辑"] = Request.RawUrl; 
                PrizeInfo model = new PrizeInfo();
                model = PrizeInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    AddAndUpdate = false;
                    //this.Password_tr.
                    this.PrizeName.Value = model.PrizeName;
                    //this.US_Password.Value = model.US_PassWord;
                    this.PrizeAmount.Value = model.PrizeAmount;
                    this.PrizeScore.Value = model.PrizeScore;
                    ViewState["amount"] = model.PrizeAmount;
                }
            }
            else
            {
                this.lblMenu1.Text = "菜单管理";
                this.lblMenu2.Text = "奖品添加";
                this.lblMenu2.NavigateUrl = Request.RawUrl;
                Session["奖品编辑"] = Request.RawUrl; 
               
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
            
            string id = Request["id"];
      
            string PrizeName =   this.PrizeName.Value;
            string PrizeScore= this.PrizeScore.Value;
            string PrizeAmount = this.PrizeAmount.Value;   
            int Amountresult;
            if (!int.TryParse(PrizeAmount, out Amountresult))
            {
                Response.Write("<script>alert('奖品数量必须为整数!');</script>");
                return;
            }
            PrizeInfo model = new PrizeInfo();
            if (id != null && id != string.Empty)
            {
                model = PrizeInfoManage.GetInstance().GetModel(id);

                if (model.PrizeID == null)
                {
                    MessageBox.Show(this, "该奖品已不存在！");
                }
                else if(int.Parse(PrizeAmount) < int.Parse(model.PrizeLeftAmount))
                {
                    MessageBox.Show(this, "当前分配总量不能小于已兑换数量！");
                }
                else if (int.Parse(PrizeAmount) < int.Parse(model.PrizeAmount))
                {
                    MessageBox.Show(this, "当前分配总量不能小于已经分配的总量！");
                }
                else
                {
                    //if (WebsiteManage.GetInstance().ExistsByWebSiteID(WebsiteID))
                    //{
                    //    MessageBox.Show(pageparam, "该网点已存在");
                    //    return;
                    //}
                    model.PrizeName = PrizeName;
                    model.PrizeScore = PrizeScore;

                 
                 
                    model.PrizeAmount = PrizeAmount;
                    model.PrizeLeftAmount = (int.Parse(PrizeAmount) - int.Parse(model.PrizeUsedAmount)).ToString();
                    bool result = PrizeInfoManage.GetInstance().Update(model);

                    //if (result)
                    //{
                    //    Response.Write("<script>alert('操作成功!');</script>");
                    //}
                    //else
                    //{
                    //    MessageBox.Show(pageparam, "操作失败！");
                    //}

                    List<WebSiteModel> WebsiteList = PrizeInfoManage.GetInstance().GetWebsiteList(PrizeInfoManage.GetInstance().GetListNotAllocateWebsite(id));
                    try
                    {
                        List<PrizeAllocateModel> list = new List<PrizeAllocateModel>();
                        foreach (WebSiteModel item in WebsiteList)
                        {
                            PrizeAllocateModel itemmodel = new PrizeAllocateModel();
                            itemmodel.PrizeID = model.PrizeID;
                            itemmodel.PrizeName = model.PrizeName;
                            itemmodel.PrizeScore = model.PrizeScore;
                            itemmodel.PrizeCount = 0;
                            itemmodel.PrizeAmount = 0;
                            itemmodel.WebsiteID = item.WebsiteID;
                            itemmodel.WebsiteName = item.WebsiteName;
                            list.Add(itemmodel);
                        }
                        PrizeInfo prize2 = new PrizeInfo();
                        prize2.PrizeID = model.PrizeID;
                        prize2.PrizeName = model.PrizeName;
                        prize2.PrizeScore = model.PrizeScore;
                        prize2.PrizeAmount = PrizeAmount;
                        PrizeInfoManage.GetInstance().Add(list, null);
                       
                        Response.Write("<script>alert('操作成功!');</script>");

                    }
                    catch
                    {
                        MessageBox.Show(pageparam, "操作失败！");
                    }
                }
            }
            else
            {
             
                    model.PrizeID = Guid.NewGuid().ToString();
                     
                    model.PrizeName = PrizeName;
                    model.PrizeScore = PrizeScore;


                    List<WebSiteModel> WebsiteList = PrizeInfoManage.GetInstance().GetWebsiteList(WebsiteManage.GetInstance().GetAllList());
                    try
                    {
                        List<PrizeAllocateModel> list = new List<PrizeAllocateModel>();
                        foreach (WebSiteModel item in WebsiteList)
                        {
                            PrizeAllocateModel itemmodel = new PrizeAllocateModel();
                            itemmodel.PrizeID  = model.PrizeID;
                            itemmodel.PrizeName = model.PrizeName;
                            itemmodel.PrizeScore = model.PrizeScore;
                            itemmodel.PrizeCount = 0;
                            itemmodel.WebsiteID = item.WebsiteID;
                            itemmodel.WebsiteName = item.WebsiteName;
                            list.Add(itemmodel);
                        }
                        PrizeInfo prize = new PrizeInfo();
                        prize.PrizeID = model.PrizeID;
                        prize.PrizeName = model.PrizeName;
                        prize.PrizeScore = model.PrizeScore;
                        prize.PrizeAmount = PrizeAmount;
                        PrizeInfoManage.GetInstance().Add(list, prize);
                        ViewState["prizeid"] = model.PrizeID;
                        ViewState["amount"] = PrizeAmount;
                        Response.Write("<script>alert('操作成功!');</script>");

                    }
                    catch
                    {
                        MessageBox.Show(pageparam, "操作失败！");
                    }
                
                
            }
            //回转列表页
            
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
        /// <summary>
        /// 奖品分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnAllocate_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && id != "")
            {
                
//                string str = @"<script>
//        var iWidth = 500;                          //弹出窗口的宽度;
//        var iHeight = 500;                        //弹出窗口的高度;
//        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
//        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
//        var agent = navigator.userAgent.toLowerCase();
//         window.open('hyxx_allocate.aspx?id="+  "\""+ id  +"\""+ @"'  ,'newwindow', 'width=500,height=400,top=' + iTop + ' ,left=' + iLeft + '');
//                    </script>";
//                Response.Write(str);

                Response.Redirect("hyxx_allocate.aspx?id=" + id + "&amount=" + ViewState["amount"]);
            }
            else
            {
    
//                    string str = @"<script>
//        var iWidth = 500;                          //弹出窗口的宽度;
//        var iHeight = 500;                        //弹出窗口的高度;
//        var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
//        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
//        var agent = navigator.userAgent.toLowerCase();
//         window.open('hyxx_allocate.aspx?id=" + "\"" + prizeid + "\"" + @"'  ,'newwindow', 'width=500,height=400,top=' + iTop + ' ,left=' + iLeft + '');
//                    </script>";
//                Response.Write(str);
                Response.Redirect("hyxx_allocate.aspx?id=" + ViewState["prizeid"].ToString()+ "&amount=" + ViewState["amount"]);
            }
        }
    }
}