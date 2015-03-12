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
        maeLogado.Text = Session["mae"].ToString();



        if (disciplinaLogado.Text == "") //DESABILITAR MENU LATERAL
        {
            icone2.Enabled = false;
            icone3.Enabled = false;
            icone4.Enabled = false;
            icone5.Enabled = false;
            icone6.Enabled = false;
            icone8.Enabled = false;
            icone9.Enabled = false;
        }
        else
        {
            icone2.Enabled = true;
            icone3.Enabled = true;
            icone4.Enabled = true;
            icone5.Enabled = true;
            icone6.Enabled = true;
            icone8.Enabled = true;
            icone9.Enabled = true;
        }
        
    }   

    protected void btnEscolherDisciplina_Click(object sender, EventArgs e)
    {        
        Session["curso"] = "";
        Session["semestre"] = "";
        Session["disciplina"] = "";
        Session["mae"] = "";

        Response.Redirect("escolherDisciplina.aspx");

        
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        
        Response.Redirect("~/paginas/Login/login.aspx");
    }
}
