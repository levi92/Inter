using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using Interdisciplinar;
using System.Data;

public partial class Paginas_Login_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void enviar_Click(object sender, EventArgs e) //Botão Login ADM COORD e PROF 
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

            Professor prof = new Professor(); //instancia um novo professor
            prof = Professor.Validar(user, senha); //valida o professor e retorna para o obj professor

            if (prof != null)
            {
                Session["curso"] = "";
                Session["semestre"] = "";
                Session["disciplina"] = "";
                Session["mae"] = "";
                Session["Professor"] = prof;
                Session["matricula"] = prof.Matricula;
                Session["nome"] = prof.Nome;
                Session["menu"] = "coordenador";
                Session["perfil"] = null;
                Session["login"] = user;
                Session["DataSetCalendarioAndProfessor"] = null;
                Session["DS_AllPIsbyCalendarioAtual"] = null;

                if (Funcoes_DB.ValidarAdmCoord(prof) == 2)
                {
                    //Coordenador e professor
                    //chama a página de escolher o perfil
                    Response.Redirect("~/Paginas/Administrador/alterar_perfil.aspx");

                }
                else
                {
                    Response.Redirect("~/EscolherDisciplina");
                }

            }

            else
            {
                lblMsgErro.Text = "E-mail e/ou Senha incorretos.";
            }

        }
        else
        {
            // Campos estão vazios
            lblMsgErro.Text = "Preencha os campos.";
        }
    }

    protected void btnEnviarM_Click(object sender, EventArgs e) //BOTÃO LOGIN MASTER
    {
        lblMsgErroM.Text = "";

        // pegar valor dos textbox do login
        string user = txtLoginM.Text; //.ToString() não precisa, o .Text já converte pra String
        //string senha = Funcoes.Criptografar(txtSenha.Text.ToString(), "SHA1"); ->>> não lê a senha correta do banco por algum motivo
        string senha = txtSenhaM.Text;



        //Verificar se os campos não estão vazios
        if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(senha))
        {
            //verifica se é master e armazena um número que indica sucesso ou falha 

            if (Funcoes_DB.ValidarAdmMaster(user, senha) == 1)
            {
                Perfil perfil = new Perfil("master");
                //Administrador master                 
                Session["login"] = user;
                Session["menu"] = "master";
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