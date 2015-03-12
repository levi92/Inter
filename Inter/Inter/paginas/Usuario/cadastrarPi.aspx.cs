using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Usuario_cadastrarPi : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
            CarregaCriGerais();
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
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        
        Label lblMCurso = (Label)Master.FindControl("cursoLogado");
        lblCursoAut.Text = lblMCurso.Text;
        lblSemestreAut.Text = ((Label)Master.FindControl("semestreLogado")).Text;
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





}