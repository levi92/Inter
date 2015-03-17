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
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }

        professorLogado.Text = Session["nomeProf"].ToString();


        cursoLogado.Text = Session["curso"].ToString();
        semestreLogado.Text = Session["semestre"].ToString();
        disciplinaLogado.Text = Session["disciplina"].ToString();

        if (Session["mae"] == "True")
            maeLogado.Text = "<span class='glyphicon glyphicon-star'></span>";
        else if (Session["mae"] == "False")
            maeLogado.Text = "<span class='glyphicon glyphicon-minus'></span>";
    }

    protected void btnEscolherDisciplina_Click(object sender, EventArgs e)
    {
        Session["curso"] = "";
        Session["semestre"] = "";
        Session["disciplina"] = "";
        Session["mae"] = "";

        Response.Redirect("escolherDisciplina.aspx");


    }
}
