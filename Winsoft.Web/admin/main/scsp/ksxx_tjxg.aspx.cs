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
    public partial class ksxx_tjxg : System.Web.UI.Page
    {
        public static string M_Url = "#";
        public string f_img2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string vid = Request.QueryString["vid"];
                if (Session["sysAdmin"] == null)
                {
                    Response.Redirect("~/admin/login.aspx");
                }
                else if (vid == null || vid == string.Empty)
                {
                    Response.Redirect("~/admin/main/right.aspx");
                }
                else
                {
                    string f_menu = CityInfoManage.GetInstance().GetAdminMenuStr(Request["code"]);
                    if (f_menu != string.Empty)
                    {
                        CityInfo model = CityInfoManage.GetInstance().GetModel(Request["code"]);
                        VidoInfo modelv = VidoInfoManage.GetInstance().GetModel(vid);
                        if (model != null)
                        {
                            M_Url = model.M_Url;
                        }

                        if (modelv != null)
                        {
                            f_menu = f_menu + "》视频名称：" + modelv.V_Name;
                        }
                        else
                        {
                            Response.Redirect("~/admin/main/right.aspx");
                        }
                        this.lblMenu.Text = f_menu;
                        Bind();
                    }
                }
            }
        }

        #region 数据加载

        private void Bind()
        {
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoLessonInfo model = VidoLessonInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    this.VL_Name.Value = model.VL_Name;
                    this.VL_Vido.Value = model.VL_Vido;
                    this.VL_Order.Value = model.VL_Order.ToString();
                    this.VL_Length.Value = model.VL_Length;

                    if (model.VL_SmallImg != string.Empty)
                    {
                        this.VL_SmallImg.ImageUrl = model.VL_SmallImg;
                    }

                    if (model.VL_BigImg != string.Empty)
                    {
                        this.VL_BigImg.ImageUrl = model.VL_BigImg;
                    }
                }
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
            bool result = true;
            string vid = Request["vid"];
            string id = Request["id"];
            string VL_Order = this.VL_Order.Value.Trim();
            string VL_Name = this.VL_Name.Value.Trim();
            string VL_Length = this.VL_Length.Value.Trim();
            string VL_SmallImg = this.VL_SmallImg.ImageUrl;
            string VL_BigImg = this.VL_BigImg.ImageUrl;
            string VL_Vido = this.VL_Vido.Value.Trim();

            VidoInfo modelVidoInfo = null;

            if (vid != null && vid != string.Empty)
            {
                modelVidoInfo = VidoInfoManage.GetInstance().GetModel(vid);
            }

            if (modelVidoInfo == null)
            {
                MessageBox.Show(this, "请选择视频信息！");
            }
            else if (VL_Order == string.Empty)
            {
                MessageBox.Show(this, "请输入排序号码！");
            }
            else if (VL_Name == string.Empty)
            {
                MessageBox.Show(this, "请输入课时名称！");
            }
            else if (VL_Length == string.Empty)
            {
                MessageBox.Show(this, "请输入时间长度！");
            }
            else if (VL_Vido == string.Empty)
            {
                MessageBox.Show(this, "请输入视频地址！");
            }
            else
            {

                #region 上传小图

                bool b = true;
                string path_small = "";
                string name_small = "";
                if (fileUploadSmall.PostedFile.FileName != string.Empty)
                {
                    string fileName = fileUploadSmall.PostedFile.FileName;  //获取路径
                    string hou = fileName.Substring(fileName.LastIndexOf(".") + 1); //获得后缀名
                    string newName = DateTime.Now.ToString("yyyyMMddHHmmssfff"); //给文件重命名
                    int length = fileUploadSmall.PostedFile.ContentLength;  //字节大小

                    if (hou.ToLower() == "jpg" || hou.ToLower() == "png")
                    {
                        path_small = "~/file/images/small/";
                        name_small = newName + "." + hou;
                        VL_SmallImg = "~/file/images/small/" + newName + "." + hou;
                    }
                    else
                    {
                        b = false;
                        MessageBox.Show(this, "上传的文件格式必需为JPG格式或PNG格式！");
                    }
                }

                #endregion

                #region 上传大图

                bool c = true;
                string path_big = "";
                string name_big = "";
                if (fileUploadBig.PostedFile.FileName != string.Empty)
                {
                    string fileName = fileUploadBig.PostedFile.FileName;  //获取路径
                    string hou = fileName.Substring(fileName.LastIndexOf(".") + 1); //获得后缀名
                    string newName = DateTime.Now.ToString("yyyyMMddHHmmssfff"); //给文件重命名
                    int length = fileUploadBig.PostedFile.ContentLength;  //字节大小

                    if (hou.ToLower() == "jpg" || hou.ToLower() == "png")
                    {
                        path_big = "~/file/images/big/";
                        name_big = newName + "." + hou;
                        VL_BigImg = "~/file/images/big/" + newName + "." + hou;
                    }
                    else
                    {
                        c = false;
                        MessageBox.Show(this, "上传的文件格式必需为JPG格式或PNG格式！");
                    }
                }

                #endregion

                if (b && c)
                {

                    #region 初始化信息

                    VidoLessonInfo model = null;

                    if (id != null && id != string.Empty)
                    {
                        model = VidoLessonInfoManage.GetInstance().GetModel(id);
                    }
                    else
                    {
                        model = new VidoLessonInfo();
                    }

                    #endregion

                    model.V_ID = modelVidoInfo.V_ID;
                    model.VL_Order = Convert.ToInt32(VL_Order);
                    model.VL_Name = VL_Name;
                    model.VL_Length = VL_Length;
                    model.VL_Vido = VL_Vido;
                    model.VL_SmallImg = VL_SmallImg;
                    model.VL_BigImg = VL_BigImg;
                    model.VL_Time = DateTime.Now;

                    if (id != null && id != string.Empty)
                    {
                        result = VidoLessonInfoManage.GetInstance().Update(model);
                    }
                    else
                    {
                        model.VL_ID = Guid.NewGuid().ToString();
                        VidoLessonInfoManage.GetInstance().Add(model);
                    }

                    if (result)
                    {
                        if (path_small != string.Empty && name_small != string.Empty)
                        {
                            this.VL_SmallImg.ImageUrl = VL_SmallImg;
                            fileUploadSmall.PostedFile.SaveAs(Server.MapPath(path_small) + name_small);
                        }
                        if (path_big != string.Empty && name_big != string.Empty)
                        {
                            this.VL_BigImg.ImageUrl = VL_BigImg;
                            fileUploadBig.PostedFile.SaveAs(Server.MapPath(path_big) + name_big);
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
            Response.Redirect("ksxx.aspx?code=" + Request["code"] + "&vid=" + Request["vid"]);
        }

        #endregion
    }
}