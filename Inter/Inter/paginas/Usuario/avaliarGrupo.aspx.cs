using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;

public partial class paginas_Usuario_avaliarGrupo : System.Web.UI.Page
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
        if (Session["disciplina"].ToString() == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }

        if (!Page.IsPostBack)
        {

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "funcaoAtualizarMediaAll", "funcaoAtualizarMediaAll();", true);
        }



        //DataSet dsAluno = new DataSet();
        //DataSet dsCriterios = new DataSet();
        //dsAluno = Aluno_DB.SelectAllAlunos();
        //dsCriterios = Criterios_Gerais_DB.SelectAll();
        //DataTable dt = new DataTable();
        //DataRow dr = dt.NewRow();


        //dt.Columns.Add(" ", typeof(string)); //ADICIONA UMA COLUNA DO CABEÇALHO VAZIA

        ////ADICIONA AS COLUNAS DO CABEÇALHO COM OS "IDs" DE ACORDO COM O NOME DO ALUNO 
        //for (int i = 0; i < dsAluno.Tables[0].Rows.Count; i++)
        //{
        //    dt.Columns.Add(dsAluno.Tables[0].Rows[i]["pes_nome"].ToString(), typeof(string));
        //}


        //for (int j = 0; j < dsCriterios.Tables[0].Rows.Count; j++)
        //{
        //    dr = dt.NewRow();
        //    for (int i = 0; i < dsAluno.Tables[0].Rows.Count + 1; i++)
        //    {
        //        if (i == 0) //COLUNA FOR IGUAL A 0
        //        {
        //            dr[" "] = dsCriterios.Tables[0].Rows[j]["cge_nome"].ToString();
        //        }
        //    }
        //    dt.Rows.Add(dr);
        //}

        //Table table = new Table();
        //TextBox txbNotas;
        //Label lblCriterios;

        //table.ID = "tableAvaliar";
        //table.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //table.CssClass = "gridViewAvaliar";
        //panelAvaliar.Controls.Add(table);

        //int rowsCount = dt.Rows.Count;
        //int colsCount = dt.Columns.Count;
        //Session["rowsCount"] = rowsCount;

        //TableHeaderRow thr = new TableHeaderRow();
        //TableHeaderCell th = new TableHeaderCell();
        //Label lblCabecalho = new Label();
        //th.Text = " ";
        //th.Style.Add("background-color", "#FFF");
        //th.Style.Add("border", "transparent");
        //thr.Cells.Add(th);

        //for (int i = 0; i < dsAluno.Tables[0].Rows.Count; i++)
        //{
        //    th = new TableHeaderCell();
        //    lblCabecalho = new Label();
        //    lblCabecalho.Text = Funcoes.SplitNomes(dsAluno.Tables[0].Rows[i]["pes_nome"].ToString());
        //    lblCabecalho.ToolTip = dsAluno.Tables[0].Rows[i]["pes_nome"].ToString();
        //    th.Style.Add("text-align", "center");
        //    th.Controls.Add(lblCabecalho);
        //    thr.Cells.Add(th);
        //}

        //table.Rows.Add(thr);

        //for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        //{
        //    TableRow row = new TableRow();
        //    row.ID = rowIndex.ToString();

        //    for (int colIndex = 0; colIndex < colsCount; colIndex++)
        //    {
        //        TableCell cell = new TableCell();

        //        if (colIndex == 0)
        //        {
        //            lblCriterios = new Label();
        //            lblCriterios.ID = "lblCriteriosRow_" + rowIndex + "_Col_" + colIndex;
        //            lblCriterios.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //            lblCriterios.Text = dt.Rows[rowIndex][colIndex].ToString() + " (" + 2 + ")";
        //            cell.Controls.Add(lblCriterios);
        //        }
        //        else
        //        {
        //            int peso = 10;
        //            valorPeso.Value = peso.ToString();
        //            txbNotas = new TextBox();
        //            txbNotas.ID = "txtNotasRow_" + (rowIndex) + "_Col_" + colIndex;
        //            txbNotas.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //            txbNotas.CssClass = "text";
        //            txbNotas.Attributes["type"] = "Number";
        //            txbNotas.Attributes["min"] = "0";
        //            txbNotas.Attributes["max"] = "10";
        //            txbNotas.Attributes["onkeyup"] = "funcaoImpedirValorAvaliar(this.id);";
        //            txbNotas.Attributes["onblur"] = "funcaoAtualizarMedia(this.id);";
        //            cell.Style.Add("text-align", "center");

        //            txbNotas.Text = dt.Rows[rowIndex][colIndex].ToString();
        //            //txbNotas.Text = "";

        //            cell.Controls.Add(txbNotas);
        //        }
        //        row.Cells.Add(cell);
        //    }
        //    table.Rows.Add(row);
        //}

        //TableRow rowMedia = new TableRow();
        //Label lblMedia = new Label();

        //for (int colIndex = 0; colIndex < colsCount; colIndex++)
        //{
        //    TableCell cell = new TableCell();
        //    cell.CssClass = "mediaAvaliar";
        //    lblMedia = new Label();
        //    lblMedia.ID = "lblMediaRow_" + table.Rows.Count + "_Col_" + colIndex;
        //    lblMedia.ClientIDMode = System.Web.UI.ClientIDMode.Static;

        //    if (colIndex == 0)
        //    {
        //        lblMedia.Text = "Média Ponderada Individual: ";
        //    }
        //    else
        //    {
        //        lblMedia.Text = "0.0";
        //    }
        //    cell.Controls.Add(lblMedia);
        //    rowMedia.Cells.Add(cell);
        //}
        //table.Rows.Add(rowMedia);

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ZebradoGridAvaliar", "ZebradoGridAvaliar();", true);

    }



    //private void txbNotasTextChanged(object sender, EventArgs e)
    //{
    //    TextBox txtChanged = ((TextBox)sender);

    //    string[] valoresLinCol = txtChanged.ID.Split('_');
    //    double valorMultiplicacao = 0, valor = 0;
    //    int rowsCount = Convert.ToInt32(Session["rowsCount"]);
    //    int col = Convert.ToInt32(valoresLinCol[3]);

    //    for (int i = 0; i < rowsCount; i++)
    //    {
    //        //txtNotasRow_1_Col_1 = [0] = txtNotasRow - [1] = 1 - [2] = Col - [3] = 1
    //        TextBox txt = (TextBox)Page.FindControl("ctl00$ctl00$cphConteudo$cphConteudoCentral$txtNotasRow_" + i.ToString() + "_Col_" + col);
    //        if (!String.IsNullOrEmpty(txt.Text))
    //        {
    //            valor = Convert.ToDouble(txt.Text);
    //            valorMultiplicacao += valor * 2;
    //        }

    //    }
    //    Label lblMedia = new Label();
    //    lblMedia = (Label)Page.FindControl("ctl00$ctl00$cphConteudo$cphConteudoCentral$lblMediaRow_" + (rowsCount + 1).ToString() + "_Col_" + col.ToString());
    //    lblMedia.Text = (valorMultiplicacao / 10).ToString();



    //}





}
