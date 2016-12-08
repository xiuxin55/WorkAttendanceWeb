using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Common;
using Winsoft.BLL;
using Winsoft.Model;

namespace Winsoft.Web.admin.main.scsy
{
    public partial class dtgl_zxsp_tjxg : System.Web.UI.Page
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
                    //string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    //if (f_menu != string.Empty)
                    //{
                    //    this.lblMenu.Text = f_menu;
                    //    CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                    //    if (model != null)
                    //    {
                    //        M_Url = model.M_Url;
                    //    }
                    //    Bind();
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
                //NewsInfo model = NewsInfoManage.GetInstance().GetModel(id);
                //if (model != null)
                //{
                //    this.N_Order.Value = model.N_Order.ToString();
                //    this.N_Title.Value = model.N_Title;
                //    this.N_Url.Value = model.N_Url;

                //    if (model.N_Img != string.Empty)
                //    {
                //        this.N_Img.ImageUrl = model.N_Img;
                //    }
                //}
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
            string code = Request["code"];
            string N_Order = this.N_Order.Value.Trim();
            string N_Title = this.N_Title.Value.Trim();
            string N_Url = this.N_Url.Value.Trim();
            string N_Img = this.N_Img.ImageUrl;
            bool result = true;

            if (N_Order == string.Empty)
            {
                MessageBox.Show(this, "请输入排序号码！");
            }
            else if (N_Title == string.Empty)
            {
                MessageBox.Show(this, "请输入视频名称！");
            }
            else if (N_Url == string.Empty)
            {
                MessageBox.Show(this, "请输入链接地址！");
            }
            else
            {

                #region 上传图片

                bool b = true;
                string path = "";
                string name = "";
                if (fileUploadUser.PostedFile.FileName != string.Empty)
                {
                    string fileName = fileUploadUser.PostedFile.FileName;  //获取路径
                    string hou = fileName.Substring(fileName.LastIndexOf(".") + 1); //获得后缀名
                    string newName = DateTime.Now.ToString("yyyyMMddHHmmssfff"); //给文件重命名
                    int length = fileUploadUser.PostedFile.ContentLength;  //字节大小

                    if (hou.ToLower() == "jpg" || hou.ToLower() == "gif" || hou.ToLower() == "png")
                    {
                        path = "~/file/images/news/";
                        name = newName + "." + hou;
                        N_Img = "~/file/images/news/" + newName + "." + hou;
                    }
                    else
                    {
                        b = false;
                        MessageBox.Show(this, "上传的文件格式必需为JPG格式、GIF格式或PNG格式！");
                    }
                }

                #endregion

                if (b)
                {

                    #region 初始化对象

                    //NewsInfo model = null;

                    //if (id != null && id != string.Empty)
                    //{
                    //    model = NewsInfoManage.GetInstance().GetModel(id);
                    //}
                    //else
                    //{
                    //    model = new NewsInfo();
                    //}

                    #endregion

                    //model.N_Title = N_Title;
                    //model.N_Url = N_Url;
                    //model.N_Img = N_Img;
                    //model.N_Time = DateTime.Now;
                    //model.N_Author = "";
                    //model.N_Content = "";
                    //model.N_Order = Convert.ToInt32(N_Order);
                    //model.N_Type = 0;
                    //model.N_Source = "";
                    //model.N_Str1 = "";
                    //model.N_Str2 = "";
                    //model.N_Str3 = "";
                    //model.N_Str4 = "";

                    //if (id != null && id != string.Empty)
                    //{
                    //    result = NewsInfoManage.GetInstance().Update(model);
                    //}
                    //else
                    //{
                    //    model.N_ID = Guid.NewGuid().ToString();
                    //    model.M_ID = code;
                    //    NewsInfoManage.GetInstance().Add(model);
                    //}

                    if (result)
                    {
                        if (path != string.Empty && name != string.Empty)
                        {
                            this.N_Img.ImageUrl = N_Img;
                            fileUploadUser.PostedFile.SaveAs(Server.MapPath(path) + name);
                        }
                        MessageBox.Show(this, "操作成功！");
                    }
                    else
                    {
                        MessageBox.Show(this, "操作失败！");
                    }
                }
                else
                {
                    MessageBox.Show(this, "操作失败！");
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
            Response.Redirect("../" + M_Url);
        }

        #endregion
    }
}