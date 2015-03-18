using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;

public partial class paginas_Usuario_notificacoes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }
        // CHAMAR A MASTER PAGE             
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //BLOQUEIO URL
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }
    }

}