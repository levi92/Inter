using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Inter.Funcoes;
using AppCode.Persistencia;

public partial class paginas_Usuario_finalizarGrupo : System.Web.UI.Page
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
        //BLOQUEIO URL SE NÃO TIVER ESCOLHIDO ALGUMA DISCIPLINA 
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }

        //BLOQUEIO SE NÃO FOR DISCIPLINA-MÃE

        if (Session["mae"] == "FILHA")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {   
            ddlFinalizarGrupos.DataSource = Session["Grupos"];
            ddlFinalizarGrupos.DataTextField = "GRU_NOME_PROJETO";
            ddlFinalizarGrupos.DataValueField = "GRU_CODIGO";
            ddlFinalizarGrupos.DataBind();
            ddlFinalizarGrupos.Items.Insert(0, "Selecione");

        }
        else
        {
            if (ddlFinalizarGrupos.SelectedIndex != 0)
            {
                CarregarGruposFinalizar(Convert.ToInt32(ddlFinalizarGrupos.SelectedValue));
            }
        }        
    }

    protected void ddlFinalizarGrupos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void CarregarGruposFinalizar(int codGrupo)
    {
        string[] codAlunos = Grupo_Aluno_DB.SelectAllMatriculaByGrupo(codGrupo);
        string[] nomesAlunos = Funcoes.NomeAlunosByMatricula(codAlunos);
        string[] atrDisciplinas = (string[])Session["atrDisciplinas"];
        string[] nomesMaterias = Funcoes.MateriasByCodigo(atrDisciplinas);

        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();        

        dt.Columns.Add("Integrantes", typeof(string)); //ADICIONA A PRIMEIRA COLUNA DO CABEÇALHO (INTEGRANTES)

        //ADICIONA AS COLUNAS DO CABEÇALHO COM OS "IDs" DE ACORDO COM O NOME DO ALUNO 
        for (int i = 0; i < atrDisciplinas.Length-1; i++)
        {           
            dt.Columns.Add(nomesMaterias[i], typeof(string));
        }


        for (int j = 0; j < nomesAlunos.Length; j++)
        {
            dr = dt.NewRow();
            for (int i = 0; i < atrDisciplinas.Length - 1; i++)
            {
                if (i == 0) //COLUNA FOR IGUAL A 0
                {
                    dr["Integrantes"] = nomesAlunos[j].ToString();
                }
                //else
                //{
                //    dr[nomesMaterias[i]] = Funcoes.CalcularMediaPonderadaAlunoDisciplinas(Convert.ToInt32(Session["codPIAtivo"]), codAlunos[j], Convert.ToInt32(atrDisciplinas[i]));
                //}
            }
            dt.Rows.Add(dr);
        }



        Table table = new Table();        
        Label lblNotas, lblAlunos;

        table.ID = "tableFinalizarGrupos";
        table.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        table.CssClass = "gridViewAvaliar";
        PanelFinalizarGrupo.Controls.Add(table);

        int rowsCount = dt.Rows.Count;
        int colsCount = dt.Columns.Count;
        Session["rowsCountFinalizar"] = rowsCount;
        Session["colsCountFinalizar"] = colsCount;
        
        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell th = new TableHeaderCell();
        Label lblCabecalho = new Label();
        th.Text = "INTEGRANTES";
        th.Style.Add("background-color", "#3A3638");
        th.Style.Add("border", "transparent");
        thr.Cells.Add(th);


        for (int i = 0; i < atrDisciplinas.Length - 1; i++)
        {
            th = new TableHeaderCell();
            lblCabecalho = new Label();
                           
            lblCabecalho.Text = nomesMaterias[i];            
            th.Style.Add("text-align", "center");
            th.Controls.Add(lblCabecalho);
            thr.Cells.Add(th);
        }
        table.Rows.Add(thr);

        for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        {
            TableRow row = new TableRow();
            row.ID = rowIndex.ToString(); //PARA O ZEBRADO

            for (int colIndex = 0; colIndex < colsCount; colIndex++)
            {
                TableCell cell = new TableCell();

                if (colIndex == 0)
                {
                    lblAlunos = new Label();
                    lblAlunos.ID = "lblAlunosRow_" + rowIndex + "_Col_" + colIndex;
                    lblAlunos.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lblAlunos.Text = Funcoes.SplitNomes(dt.Rows[rowIndex][colIndex].ToString());
                    lblAlunos.ToolTip = dt.Rows[rowIndex][colIndex].ToString();
                    cell.Controls.Add(lblAlunos);
                }
                else
                {
                    lblNotas = new Label();
                    lblNotas.ID = "lblNotasRow_" + (rowIndex) + "_Col_" + colIndex;
                    lblNotas.ClientIDMode = System.Web.UI.ClientIDMode.Static;                                      
                    cell.Style.Add("text-align", "center");
                    lblNotas.Text = Funcoes.CalcularMediaPonderadaAlunoDisciplinas(Convert.ToInt32(Session["codPIAtivo"]), codAlunos[rowIndex], Convert.ToInt32(atrDisciplinas[colIndex-1])).ToString(); 
                    cell.Controls.Add(lblNotas);
                }
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }



        

    }
}