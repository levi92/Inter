﻿using System;
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

        int verificacao = Funcoes_DB.ValidarAdm(user, senha);


        Professor prof = new Professor();
        prof = Professor.Validar(user, senha);

        //Verificar se os campos não estão vazios
        if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(senha))
        {

            if (verificacao == 3)
            {
                //Administrador master                 
                Session["login"] = user;
                Session["coord"] = "False";
                Response.Redirect("~/Paginas/Administrador/solicitacoes.aspx");
            }
            else if (prof != null)
            {
                if (verificacao == 2)
                {
                    Session["login"] = user;
                    Session["coord"] = "True";
                    Response.Redirect("~/Paginas/Administrador/alterar_perfil.aspx");
                }
                else
                {
                    Session["Professor"] = prof;
                    Response.Redirect("~/Paginas/Usuario/escolherDisciplina.aspx");
                }

            }

            else
            {
                lblMsgErro.Text = "E-mail ou Senha incorretos.";
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

    protected void btnProfessor_Click1(object sender, EventArgs e)
    {



    }

    protected void btnAdministrador_Click(object sender, EventArgs e)
    {


    }


}