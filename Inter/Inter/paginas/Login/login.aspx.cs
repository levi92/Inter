using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Login_login : System.Web.UI.Page
{
    static bool controleModal = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }
    }

    protected void enviar_Click(object sender, EventArgs e)
    {

        lblMsgErro.Text = "";

        // pegar valor dos textbox do login
        string user = txtLogin.Text.ToString();
        string senha = txtSenha.Text.ToString();

        //Verificar se os campos não estão vazios
        if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(senha))
        {

            // Verifica os parametros na função ValidarLogin
           
            switch (Funcoes_DB.ValidarLogin(user, senha))
            {
                
                case 0:
                    // Professor
                    Session["login"] = user;
                    Session["curso"] = "";
                    Session["semestre"] = "";
                    Session["disciplina"] = "";
                    Session["mae"] = "";
                    Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
                    break;

                
                //case 1:
                //    //Administrador
                //    Session["coord"] = "True";
                //    Session["login"] = user;
                //    Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
                //    break;

                case 2:
                    //Administrador Coordenador e professor
                    //chama a página de escolher o perfil

                    Session["login"] = user;
                    Response.Redirect("~/Paginas/Administrador/alterar_perfil.aspx");
                    break;

                case 3:
                    //Administrador master                 
                    Session["login"] = user;
                    Session["coord"] = "False";
                    Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
                    break;

                
                case -2:
                    // Erro
                    lblMsgErro.Text = "E-mail ou Senha incorretos.";
                    break;
            }

        }
        else
        {
            // Campos estão vazios
            lblMsgErro.Text = "Preencha os campos.";
        }
    }

    protected void btnProfessor_Click1(object sender, EventArgs e)
    {
        if (controleModal == true)
        {
            string user = txtLogin.Text.ToString();
            string senha = txtSenha.Text.ToString();

            Session["login"] = user;
            Session["curso"] = "";
            Session["semestre"] = "";
            Session["disciplina"] = "";
            Session["mae"] = "";
            controleModal = false;
            //this.Page.Response.Redirect(this.Page.Request.Url.AbsoluteUri);
            Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
        }
        
        
    }

    protected void btnAdministrador_Click(object sender, EventArgs e)
    {
        
        if (controleModal == true)
        {
            Session["login"] = "";
            controleModal = false;
            Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
            
            
        }
        
  
    }


}