using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inter.paginas.Usuario
{
    public partial class MasterPageMenuMae : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect("~/paginas/Login/login.aspx");
        }

    }
}