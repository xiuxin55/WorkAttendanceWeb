using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;
using Winsoft.Common;

namespace Winsoft.Web
{
    public partial class jhyx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            string yzm = Request["yzm"];
            string id = Request["id"];
            bool result = false;
            if (yzm != null && yzm != string.Empty && id != null && id != string.Empty)
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModelByVerificationCode(yzm);
                if (model != null && MD5.MDString(model.M_Username) == id && model.M_IsVerify != "是")
                {
                    model.M_IsVerify = "是";
                    result = PrizeInfoManage.GetInstance().Update(model);

                    if (result)
                    {
                        this.M_Username.Text = model.M_Username;
                        Session["myuser"] = model;
                    }
                    else
                    {
                        MessageBox.ShowAndRedirect(this, "激活失败！", "index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}