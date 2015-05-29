using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using Interdisciplinar;

public partial class paginas_Usuario_home : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MÃE OU FILHA         
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // VERIFICAR SE O PROFESSOR NÃO ESCOLHEU UMA DISCIPLINA E REDIRECIONA PARA A PÁGINA ESCOLHER DISCIPLINA
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }

        // APARECER NOME DO PROFESSOR NA FRASE BEM-VINDO (PROFESSOR)!
        Professor prof = new Professor();
        prof = (Professor)Session["Professor"];
        string[] nomeProf = prof.Nome.Split(' ');
        lblNomeProf.Text = nomeProf[0];

        int codAtribuicao = Convert.ToInt32(Session["codAtr"]);
        int codPiAtivoMateria = Projeto_Inter_DB.SelectCodPiAtivoMateria(codAtribuicao);
        if (codPiAtivoMateria != -2)
        {
            Session["CodigoPIAtivoMateria"] = codPiAtivoMateria;
        }
    }
}