using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Interdisciplinar;
using Inter.Funcoes;

public partial class paginas_Admin_projetos : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["coord"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaGrid();
        }
    }

    private void CarregaGrid()

    {    
        string busca = txtBusca.Text;
        DataSet dsPIFatec = (DataSet)Session["DS_AllPIsbyCalendarioAtual"];
        if (Session["DS_AllPIsbyCalendarioAtual"] == null)
        {
            Calendario cal = Calendario.SelectbyAtual();           
            dsPIFatec = Professor.SelectAllPIsbyCalendario(cal.Codigo, cal.AnoSemestreAtual);
            Session["DS_AllPIsbyCalendarioAtual"] = dsPIFatec;
        }
        string[] vetorReturnFunction = new string[3];

        //foreach(row in (DataSet)Session["DS_AllPIsbyCalendarioAtual"])
        //vetorReturnFunction = Funcoes.tratarDadosProfessor((DataSet)Session["DS_AllPIsbyCalendarioAtual"].Tables[0].Rows[i]["disciplina"].ToString());

        DataSet ds = Funcoes_DB.SelectAllPIs();
        ds.Tables.Add();
        //if (!String.IsNullOrEmpty(busca))
        //{
        //    ds.Tables[0].Select("where GRU_NOME_PROJETO like '%" + busca + "%'");
        //}
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd > 0)
        {
            gdvProjetos.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvProjetos.DataBind(); //preenche o grid view com os dados
        }

    }
    int i;
    protected void gdvProjetos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = (DataSet)Session["DS_AllPIsbyCalendarioAtual"];
        string[] vetorReturnFunction = new string[3];

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            vetorReturnFunction = Funcoes.tratarDadosProfessor(ds.Tables[0].Rows[i]["disciplina"].ToString()); //pega o dado da linha [i] da coluna "disciplina" e joga dentro do método tratarDados
            e.Row.Cells[1].Text = vetorReturnFunction[0]; //pega o nome do curso e coloca na célula da coluna correspondente ao curso daquela linha

            i++;

            if (e.Row.Cells[3].Text == "False") //verifica se o valor da coluna GRU_FINALIZADO 
            {
                e.Row.Cells[3].Text = "Aberto";
            }
            else
            {
                e.Row.Cells[3].Text = "Finalizado";
            }
        }
    }
    

   

}