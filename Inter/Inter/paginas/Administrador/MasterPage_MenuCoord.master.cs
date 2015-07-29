using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class paginas_Admin_MenuCoord : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/BloqueioUrl");
            }
        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect("~/Login");
        }
    }
