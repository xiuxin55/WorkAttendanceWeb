using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.Common;
using Winsoft.BLL;

namespace Winsoft.Web
{
    public partial class hyzx_grzl_sctx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrizeInfo model = (PrizeInfo)Session["myuser"];

                if (model == null)
                {
                    Response.Redirect("hydl.aspx");
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Picurl"]))
                {
                    ImageIcon.ImageUrl = Request.QueryString["Picurl"];
                    Page.ClientScript.RegisterStartupScript(typeof(hyzx_grzl_sctx), "step2", "<script type='text/javascript'>Step2();</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(hyzx_grzl_sctx), "step1", "<script type='text/javascript'>Step1();</script>");
                }

                imgphoto.ImageUrl = model.M_Img;
                return;
            }

        }
        //点击上传按钮
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuPhoto.PostedFile != null && fuPhoto.PostedFile.ContentLength > 0)
            {

                string ext = System.IO.Path.GetExtension(fuPhoto.PostedFile.FileName).ToLower();
                if (ext != ".jpg" && ext != ".jepg" && ext != ".bmp" && ext != ".gif")
                {
                    return; //notice user change file type
                }
                string filename =  DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string path = "~/file/images/head/" + filename;
                fuPhoto.PostedFile.SaveAs(Server.MapPath(path));
                Response.Redirect("hyzx_grzl_sctx.aspx?Picurl=" + Server.UrlEncode(path));

            }
            else
            {

            }
        }
        //点击保存头像按钮
        protected void btn_Image_Click(object sender, EventArgs e)
        {
            PrizeInfo modelMemberInfo = (PrizeInfo)Session["myuser"];
            if (modelMemberInfo == null)
            {
                Response.Redirect("hydl.aspx");
            }
            //头像存储路径
            string savepath = "file/images/head/";
            int imageWidth = Int32.Parse(txt_width.Text);
            int imageHeight = Int32.Parse(txt_height.Text);
            int cutTop = Int32.Parse(txt_top.Text);
            int cutLeft = Int32.Parse(txt_left.Text);
            int dropWidth = Int32.Parse(txt_DropWidth.Text);
            int dropHeight = Int32.Parse(txt_DropHeight.Text);
            string filename = CutPhotoHelp.SaveCutPic(Server.MapPath(ImageIcon.ImageUrl), Server.MapPath(savepath), 0, 0, dropWidth,
                                    dropHeight, cutLeft, cutTop, imageWidth, imageHeight);

            PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(modelMemberInfo.M_ID);
            model.M_Img = "~/" + savepath + filename; ;
            bool result = PrizeInfoManage.GetInstance().Update(model);


            this.imgphoto.ImageUrl = "~/" + savepath + filename;
            Page.ClientScript.RegisterStartupScript(typeof(hyzx_grzl_sctx), "step3", "<script type='text/javascript'>Step3();</script>");
            if (result)
            {
                Session["myuser"] = model;
                MessageBox.ShowAndRedirect(this, "修改成功！", "hyzx_grzl.aspx");
            }
            else
            {
                MessageBox.Show(this, "修改失败！");
            }
        }
    }
}