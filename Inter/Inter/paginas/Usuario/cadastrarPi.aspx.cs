using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;

public partial class paginas_Usuario_cadastrarPi : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            CarregaCriGerais();
            PegarAnoeSemestreAno();
            criterios = "";
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        lblCursoAut.Text = Session["curso"].ToString();
        lblSemestreAut.Text = Session["semestre"].ToString();
    }


    private void PegarAnoeSemestreAno()
    {
        // PEGAR ANO E SEMESTRE DO ANO
        string ano = DateTime.Now.Year.ToString();
        int mes = DateTime.Now.Month;

        if (mes <= 6)
        {
            lblSemestreAnoAut.Text = "1";
        }
        else
        {
            lblSemestreAnoAut.Text = "2";
        }

        lblAnoAut.Text = ano;
    }

    

    private void CarregaCriGerais()
    {
        DataSet ds = Criterios_Gerais_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            lblCriGerais.Text = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                lblCriGerais.Text += "<li class=\"ui-state-default\">" + dr["cge_nome"].ToString() + "</li>";

            }
        }
    }

    public static string criterios;

    public void CriarCriterio()
    {
        criterios = Request.Form[hidden.UniqueID];

        string[] dadosCrit = criterios.Split('|');

        Label[] lblCriterios = new Label[dadosCrit.Length];
        TextBox[] txtCriterios = new TextBox[dadosCrit.Length];
        Label[] lblLinha = new Label[dadosCrit.Length];

        for (int i = 1; i < dadosCrit.Length; i++)
        {
            lblCriterios[i] = new Label();
            lblCriterios[i].ID = "lblCriterio" + (i);
            lblCriterios[i].CssClass = "label";
            lblCriterios[i].Text = dadosCrit[i] + ": ";

            txtCriterios[i] = new TextBox();
            txtCriterios[i].ID = "txtCriterio" + (i);
            txtCriterios[i].CssClass = "text";

            lblLinha[i] = new Label();
            lblLinha[i].ID = "lblL" + (i);
            lblLinha[i].Text = String.Format("<br/><br/>");


            Panel1.Controls.Add(lblCriterios[i]);
            Panel1.Controls.Add(txtCriterios[i]);
            Panel1.Controls.Add(lblLinha[i]);

        }

    }

    protected void btnContinuarEtapa3_Click(object sender, EventArgs e)
    {
        //NO BUTTON ONCLIENTCLICK ESTÁ PEGANDO OS VALORES DO HIDDEN 
        CriarCriterio();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
    }


    protected void listaAlunoGeral_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunosGrupo.Items.Add(listaAlunoGeral.SelectedItem);
        listaAlunoGeral.Items.RemoveAt(listaAlunoGeral.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }



    protected void listaAlunosGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunoGeral.Items.Add(listaAlunosGrupo.SelectedItem);
        listaAlunosGrupo.Items.RemoveAt(listaAlunosGrupo.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }





}