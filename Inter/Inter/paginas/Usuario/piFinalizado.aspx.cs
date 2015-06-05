using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;

public partial class paginas_Usuario_piFinalizado : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["Professor"] == null)
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

    protected void lbPesquisar_Click(object sender, EventArgs e)
    {
        PiFinalizados();
    }

    public void PiFinalizados()
    {
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();   

            dt.Columns.Add("Projeto", typeof(string));
            dt.Columns.Add("Data Finalização", typeof(string));
            dt.Columns.Add("Disciplina mãe", typeof(string));
            dt.Columns.Add("Semestre", typeof(string));
            dt.Columns.Add("Solicitar alteração", typeof(string));

            dt.Rows.Add(dr);

        Table table = new Table();        
        Label lblProjeto, lblData, lblDisciplina, lblSemestre;

        table.ID = "tablePIsFinalizados";
        table.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        table.CssClass = "gridViewAvaliar";
        PanelPIsFinalizados.Controls.Add(table);

        string nomeGrupos = Funcoes.PesquisarByNomeGrupo(txtPesquisar.Text);
        string[] projetos = nomeGrupos.Split('|');
        

        int rowsCount = projetos.Length-1;
        int colsCount = 5;
        
        
        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell th = new TableHeaderCell();
        Label lblCabecalho = new Label();       


        for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        {
            TableRow row = new TableRow();
            row.ID = rowIndex.ToString(); 

            for (int colIndex = 0; colIndex < colsCount; colIndex++)
            {
                TableCell cell = new TableCell();    
                switch(colIndex){
                    case 0:
                        lblProjeto = new Label();
                        lblProjeto.Text = projetos[rowIndex].ToString();
                        cell.Controls.Add(lblProjeto);
                    break;
                    case 1:
                        lblData = new Label();
                        lblData.Text = " ";
                        cell.Controls.Add(lblData);
                    break;
                    case 2:
                        lblDisciplina = new Label();
                        lblDisciplina.Text = " ";
                        cell.Controls.Add(lblDisciplina);
                    break;
                    case 3:
                        lblSemestre = new Label();
                        lblSemestre.Text = " ";
                        cell.Controls.Add(lblSemestre);
                    break;
                    case 4:

                    break;
                }                                        
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }      

    }

    


}