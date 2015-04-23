using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;

namespace Inter.paginas.Administrador
{
    public partial class AlterarPerfil : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Se sessão estiver nula redireciona para o bloqueio Url
            if (Session["login"] == null)
            {
                Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
            }

            // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD SE ELE JÁ ESCOLHEU O PERFIL
            if (Session["perfil"] != "")
            {
                this.Page.MasterPageFile = Funcoes.Funcoes.chamarMasterPage_Admin(Session["coord"].ToString());
            }
        }

        protected void Btn_Admin(object sender, EventArgs e)
        {
            Session["perfil"] = "escolheu";   
            Response.Redirect("~/paginas/Administrador/solicitacoes.aspx");
        }

        protected void Btn_Prof(object sender, EventArgs e)
        {
            Session["perfil"] = "escolheu";
            Session["curso"] = "";
            Session["semestre"] = "";
            Session["disciplina"] = "";
            Session["mae"] = "";
            Response.Redirect("../Usuario/escolherDisciplina.aspx");
        }

       
    }
}