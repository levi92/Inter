using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Login_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                // Professor
                case 0:
                    Session["login"] = user;
                    Session["curso"] = "";
                    Session["semestre"] = "";
                    Session["disciplina"] = "";
                    Session["mae"] = "";
                    Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
                    break;

                // Administrador
                case 1:
                    Session["login"] = user;
                    Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
                    break;

                // Erro
                case -2:
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


}