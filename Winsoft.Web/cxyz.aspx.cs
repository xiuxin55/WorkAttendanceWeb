using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winsoft.Model;
using Winsoft.BLL;

namespace Winsoft.Web
{
    public partial class cxyz : System.Web.UI.Page
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
            string M_ID = Request["id"];
            if (M_ID != null && M_ID != string.Empty)
            {
                PrizeInfo model = PrizeInfoManage.GetInstance().GetModel(M_ID);
                if (model != null && model.M_IsVerify != "是")
                {
                    this.M_Username.Text = model.M_Username;
                    this.M_EMail.Text = model.M_EMail;
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