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
    public partial class spxx_tjxg : System.Web.UI.Page
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
                        BindType();
                        Bind();
                    }
                }
            }
        }

        #region 菜单加载

        /// <summary>
        /// 加载视频类型
        /// </summary>
        private void BindType()
        {
            DataTable dtList = PrizeExchangeInfoManage.GetInstance().GetList("1=1 order by VT_Order").Tables[0];

            if (dtList != null || dtList.Rows.Count > 0)
            {
                this.VT_ID.DataSource = dtList;
                this.VT_ID.DataTextField = "VT_Name";
                this.VT_ID.DataValueField = "VT_ID";
                this.VT_ID.DataBind();
            }
            this.VT_ID.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        #endregion

        #region 数据加载

        private void Bind()
        {
            string id = Request["id"];
            if (id != null && id != string.Empty)
            {
                VidoInfo model = VidoInfoManage.GetInstance().GetModel(id);
                if (model != null)
                {
                    this.VT_ID.Text = model.VT_ID;
                    this.V_Name.Value = model.V_Name;
                    this.V_Keyword.Value = model.V_Keyword;
                    this.V_Content.Value = model.V_Content;
                    this.V_Price.Value = model.V_Price.ToString("f2");
                    this.V_NewPrice.Value = model.V_NewPrice.ToString("f2");
                    this.V_LessonCount.Value = model.V_LessonCount.ToString();
                    this.V_BuyCount.Value = model.V_BuyCount.ToString();
                    this.V_PlayCount.Value = model.V_PlayCount.ToString();
                    this.V_BrowseCount.Value = model.V_BrowseCount.ToString();
                    this.V_CollectionCount.Value = model.V_CollectionCount.ToString();
                    this.V_BuyCountReal.Text = model.V_BuyCountReal.ToString();
                    this.V_PlayCountReal.Text = model.V_PlayCountReal.ToString();
                    this.V_BrowseCountReal.Text = model.V_BrowseCountReal.ToString();
                    this.V_CollectionCountReal.Text = model.V_CollectionCountReal.ToString();

                    if (model.V_SmallImg != string.Empty)
                    {
                        this.V_SmallImg.ImageUrl = model.V_SmallImg;
                    }

                    if (model.V_BigImg != string.Empty)
                    {
                        this.V_BigImg.ImageUrl = model.V_BigImg;
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
            string id = Request["id"];
            string VT_ID = this.VT_ID.Text.Trim();
            string V_Name = this.V_Name.Value.Trim();
            string V_Price = this.V_Price.Value.Trim();
            string V_NewPrice = this.V_NewPrice.Value.Trim();
            string V_LessonCount = this.V_LessonCount.Value.Trim();
            string V_BuyCount = this.V_BuyCount.Value.Trim();
            string V_PlayCount = this.V_PlayCount.Value.Trim();
            string V_BrowseCount = this.V_BrowseCount.Value.Trim();
            string V_CollectionCount = this.V_CollectionCount.Value.Trim();
            string V_Content = this.V_Content.Value.Trim();
            string V_Keyword = this.V_Keyword.Value.Trim();
            string V_SmallImg = this.V_SmallImg.ImageUrl;
            string V_BigImg = this.V_BigImg.ImageUrl;

            if (VT_ID == "0")
            {
                MessageBox.Show(this, "请选择视频类型！");
            }
            else if (V_Name == string.Empty)
            {
                MessageBox.Show(this, "请输入视频类型！");
            }
            else if (V_Price == string.Empty)
            {
                MessageBox.Show(this, "请输入视频原价！");
            }
            else if (V_NewPrice == string.Empty)
            {
                MessageBox.Show(this, "请输入视频现价！");
            }
            else if (V_LessonCount == string.Empty)
            {
                MessageBox.Show(this, "请输入课时数！");
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
                        V_SmallImg = "~/file/images/small/" + newName + "." + hou;
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
                        V_BigImg = "~/file/images/big/" + newName + "." + hou;
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

                    if (V_BuyCount == string.Empty)
                    {
                        V_BuyCount = "0";
                    }

                    if (V_PlayCount == string.Empty)
                    {
                        V_PlayCount = "0";
                    }

                    if (V_BrowseCount == string.Empty)
                    {
                        V_BrowseCount = "0";
                    }

                    if (V_CollectionCount == string.Empty)
                    {
                        V_CollectionCount = "0";
                    }

                    VidoInfo model = null;

                    if (id != null && id != string.Empty)
                    {
                        model = VidoInfoManage.GetInstance().GetModel(id);
                    }
                    else
                    {
                        model = new VidoInfo();
                    }

                    #endregion

                    model.M_ID = "";
                    model.VT_ID = VT_ID;
                    model.V_Code = "";
                    model.V_Name = V_Name;
                    model.V_Keyword = V_Keyword;
                    model.V_Content = V_Content;
                    model.V_Price = Convert.ToDecimal(V_Price);
                    model.V_NewPrice = Convert.ToDecimal(V_NewPrice);
                    model.V_SmallImg = V_SmallImg;
                    model.V_BigImg = V_BigImg;
                    model.V_LessonCount = Convert.ToInt32(V_LessonCount);
                    model.V_BuyCount = Convert.ToInt32(V_BuyCount);
                    model.V_PlayCount = Convert.ToInt32(V_PlayCount);
                    model.V_BrowseCount = Convert.ToInt32(V_BrowseCount);
                    model.V_CollectionCount = Convert.ToInt32(V_CollectionCount);
                    model.V_Time = DateTime.Now;

                    if (id != null && id != string.Empty)
                    {
                        result = VidoInfoManage.GetInstance().Update(model);
                    }
                    else
                    {
                        model.V_ID = Guid.NewGuid().ToString();
                        model.V_BuyCountReal = 0;
                        model.V_PlayCountReal = 0;
                        model.V_BrowseCountReal = 0;
                        model.V_CollectionCountReal = 0;
                        VidoInfoManage.GetInstance().Add(model);
                    }

                    if (result)
                    {
                        if (path_small != string.Empty && name_small != string.Empty)
                        {
                            this.V_SmallImg.ImageUrl = V_SmallImg;
                            fileUploadSmall.PostedFile.SaveAs(Server.MapPath(path_small) + name_small);
                        }
                        if (path_big != string.Empty && name_big != string.Empty)
                        {
                            this.V_BigImg.ImageUrl = V_BigImg;
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
            Response.Redirect("../" + M_Url);
        }

        #endregion
    }
}