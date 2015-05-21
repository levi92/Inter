using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using Interdisciplinar;

public partial class Paginas_Login_login : System.Web.UI.Page
{
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
        //string senha = Funcoes.Criptografar(txtSenha.Text.ToString(), "SHA1"); ->>> não lê a senha correta do banco por algum motivo
        string senha = txtSenha.Text.ToString();

        Perfil perfil = new Perfil();

        //Verificar se os campos não estão vazios
        if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(senha))
        {
            //verifica se é master e armazena um número que indica sucesso ou falha 
            
            if (Funcoes_DB.ValidarAdmMaster(user, senha) == 1)
            {
                //Administrador master                 
                Session["login"] = user;
                Session["coord"] = "False";
                Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
            }

            Professor prof = new Professor(); //instancia um novo professor
            prof = Professor.Validar(user, senha); //valida o professor e retorna para o obj professor

            if (prof != null)
            {
                if (Funcoes_DB.ValidarAdmCoord(prof) == 2)
                {
                    //Administrador Coordenador e professor
                    //chama a página de escolher o perfil
                    Session["coord"] = "True";
                    Session["perfil"] = null;
                    Session["login"] = user;
                    Session["Professor"] = prof;
                    Session["matricula"] = prof.Matricula;
                    Session["nome"] = prof.Nome;
                    Response.Redirect("~/Paginas/Administrador/alterar_perfil.aspx");

                }
                else
                {
                    Session["Professor"] = prof;
                    Session["matricula"] = prof.Matricula;
                    Session["nome"] = prof.Nome;
                    Session["DataSetCalendarioAndProfessor"] = null;
                    Session["curso"] = "";
                    Session["semestre"] = "";
                    Session["disciplina"] = "";
                    Session["mae"] = "";
                    Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
                }

            }

            else
            {
                lblMsgErro.Text = "E-mail e/ou Senha incorretos.";
            }

            // Verifica os parametros na função ValidarLogin

            //switch (Funcoes_DB.ValidarLogi(user, senha))
            //{

            //    case 0:
            //        // Professor
            //        Session["login"] = user;
            //        Session["curso"] = "";
            //        Session["semestre"] = "";
            //        Session["disciplina"] = "";
            //        Session["mae"] = "";
            //        Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
            //        break;




            //    case 2:
            //        //Administrador Coordenador e professor
            //        //chama a página de escolher o perfil
            //        Session["coord"] = "True";
            //        Session["perfil"] = "";
            //        Session["login"] = user;
            //        Response.Redirect("~/Paginas/Administrador/alterar_perfil.aspx");
            //        break;




            //    case -2:
            //        // Erro
            //        lblMsgErro.Text = "E-mail ou Senha incorretos.";
            //        break;
            //}

        }
        else
        {
            // Campos estão vazios
            lblMsgErro.Text = "Preencha os campos.";
        }
    }

    protected void btnEnviarM_Click(object sender, EventArgs e)
    {
        lblMsgErroM.Text = "";

        // pegar valor dos textbox do login
        string user = txtLoginM.Text.ToString();
        //string senha = Funcoes.Criptografar(txtSenha.Text.ToString(), "SHA1"); ->>> não lê a senha correta do banco por algum motivo
        string senha = txtSenhaM.Text.ToString();

        

        //Verificar se os campos não estão vazios
        if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(senha))
        {
            //verifica se é master e armazena um número que indica sucesso ou falha 

            if (Funcoes_DB.ValidarAdmMaster(user, senha) == 1)
            {
                Perfil perfil = new Perfil("master");
                //Administrador master                 
                Session["login"] = user;
                Session["coord"] = "False";
                Session["matricula"] = perfil.Matricula;
                Session["nome"] = "Master";
                Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
            }
            else
            {
                lblMsgErroM.Text = "Login inválido";
            }
            

        }
        else
        {
            lblMsgErroM.Text = "Os campos devem ser preenchidos!";
        }
    }

}