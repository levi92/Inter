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
            if ((String)Session["perfil"] == "coordenador")
            {
                
                this.Page.MasterPageFile = Funcoes.Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
            }
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((String)Session["perfil"] == "coordenador")
            {

                btnCoord.Enabled = false;
            }

         
        }

        protected void Btn_Admin(object sender, EventArgs e)
        {
            Session["perfil"] = "coordenador";   
            Response.Redirect("~/paginas/Administrador/solicitacoes.aspx");
        }

        protected void Btn_Prof(object sender, EventArgs e)
        {
            Session["perfil"] = "professor";
            Response.Redirect("~/paginas/Usuario/escolherDisciplina.aspx");           
        }

       
    }
}