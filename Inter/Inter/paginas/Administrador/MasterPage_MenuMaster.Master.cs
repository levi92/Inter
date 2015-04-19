using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inter.paginas.Administrador
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
            }                     
        
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();

            Response.Redirect("~/Paginas/Login/login.aspx");
        }
    }
}