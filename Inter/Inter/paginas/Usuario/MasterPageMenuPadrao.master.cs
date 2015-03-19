using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inter.paginas.Usuario
{
    public partial class MasterPageMenuPadrao : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento do botão sair: Remove todas sessões e redireciona para a página login
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect("~/paginas/Login/login.aspx");
        }

    }
}