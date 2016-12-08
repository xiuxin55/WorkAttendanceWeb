using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;
using System.Data;
using System.IO;

namespace Winsoft.Web.admin.main
{
    public partial class UploadFile : System.Web.UI.Page
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
                    
                        M_Url = "UploadFile.aspx";
             
                }
            }
        }

        #region 数据加载
  
       

        #endregion

        #region 数据处理

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

          
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
        /// <summary>
        /// 导入数据
        /// </summary>
        public bool ImportData(string filename)
        {
            // 在此处添加操作实现

            try
            {
                //filename = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename;

                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "Files\\test.xls";
                DataTable dt = NPOIHelper.Import(filename);
                foreach (DataRow item in dt.Rows)
                {



                    PrizeExchangeInfo model = new PrizeExchangeInfo();
                    model.Prize_Guid = Guid.NewGuid().ToString();
                    model.Prize_user = item["姓名"].ToString();
                    model.Prize_CardNum = item["卡号"].ToString();
                    model.Prize_IdentifyCard = item["身份证号"].ToString();
                    model.Prize_Name = item["可兑换奖品"].ToString();
                    if (item["是否兑奖"].ToString() == "0" || item["是否兑奖"].ToString() == System.Configuration.ConfigurationManager.AppSettings["Prize_Yes"].ToString())
                    {
                        model.Prize_Flag = "0";
                    }
                    else
                    {
                        model.Prize_Flag = "1";
                    }
                    model.Prize_GetUserName = item["领取人姓名"].ToString();
                    model.Prize_GetUserContact = item["领取人联系方式"].ToString();
                    model.Prize_GetUserIdentifyCard = item["领取人身份证号"].ToString();
                    model.Prize_GetPrizeName = item["已兑奖品名称"].ToString();
                    model.Pize_GetPrizeDateTime = item["兑奖日期"].ToString();
                    model.Pize_GetPrizeTime = item["兑奖时间"].ToString();
                    model.Pize_PushCom = item["推广机构名称"].ToString();
                    model.Pize_PushComNum = item["推广机构号"].ToString();
                    model.Pize_PushPerson = item["推广人员姓名"].ToString();
                    model.Pize_PushPersonNum = item["推广人编号"].ToString();
                    model.Pize_WebsiteNum = item["操作网点号"].ToString();
                    model.Pize_UserNum = item["工号"].ToString();
                  
                        PrizeExchangeInfoManage.GetInstance().Add(model);
                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// 上传并导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submmit_Click(object sender, EventArgs e)
        {


            if (this.FileUpLoad.HasFile)
            {
                string filename = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + this.FileUpLoad.FileName;

                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "Files\\test.xls";
                this.FileUpLoad.SaveAs(filename);
                if (!ImportData(filename))
                {
                    Response.Write("导入失败！！");
                    Response.Write("<script>alert('导入失败');</script>");
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    return;
                }
                else
                {
                    Response.Write("导入成功！！");
                    Response.Write("<script>alert('导入成功');window.close();</script>");
                }
            }
            else
            {
                Response.Write("请选择文件！！");
                Response.Write("<script>alert('请选择文件');</script>");
            }
        }
    }
}