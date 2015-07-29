using Interdisciplinar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Usuario_MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // Verificar se a sessão está vazia e redirecionar para o bloqueio Url
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }

        Professor prof = new Professor();
        prof = (Professor)Session["Professor"];
        string[] nomeProf = prof.Nome.Split(' ');

        // Colocando os conteudos da sessão atual (criada no login) na tabela do topo
        professorLogado.Text = nomeProf[0]+" "+nomeProf[nomeProf.Length-1];
        cursoLogado.Text = Session["curso"].ToString();
        semestreLogado.Text = Session["semestre"].ToString();
        disciplinaLogado.Text = Session["disciplina"].ToString();

        // Colocar ícones específicos para mãe e para filha
        if (Session["mae"] == "MAE")
            maeLogado.Text = "<span class='glyphicon glyphicon-star'></span>";
        else if (Session["mae"] == "FILHA")
            maeLogado.Text = "<span class='glyphicon glyphicon-minus'></span>";
    }

    // Evento do botão Alterar disciplina: limpa as sessões e redireciona para a página escolherDisciplina
    protected void btnEscolherDisciplina_Click(object sender, EventArgs e)
    {
        Session["curso"] = "";
        Session["semestre"] = "";
        Session["disciplina"] = "";
        Session["mae"] = "";
        Session["codAtr"] = "";
        Session["DataSetPIsbyCalendario"] = "";
       
        Session["codEnvolvidas"] = "";
        Session["atrEnvolvidas"] = "";
        Session["nomeEnvolvidas"] = "";
        Session["maeEnvolvidas"] = "";
        Session["nomeProfEnvolvidos"] = "";

        Response.Redirect("~/EscolherDisciplina");


    }
}
