using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Inter.paginas.Administrador
{
    public partial class AlterarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
            }
        }

        protected void Btn_Admin(object sender, EventArgs e)
        {
            Session["coord"] = "True";
            Response.Redirect("~/paginas/Administrador/solicitacoes.aspx");
        }

        protected void Btn_Prof(object sender, EventArgs e)
        {

            Session["curso"] = "";
            Session["semestre"] = "";
            Session["disciplina"] = "";
            Session["mae"] = "";
            Response.Redirect("../Usuario/escolherDisciplina.aspx");
        }

       
    }
}