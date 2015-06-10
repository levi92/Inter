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

        if (Session["GruposFinalizar"] != null)
        {
            if (!IsPostBack)
            {
                ddlFinalizarGrupos.DataSource = Session["GruposFinalizar"];
                ddlFinalizarGrupos.DataTextField = "GRU_NOME_PROJETO";
                ddlFinalizarGrupos.DataValueField = "GRU_CODIGO";
                ddlFinalizarGrupos.DataBind();
                ddlFinalizarGrupos.Items.Insert(0, "Selecione");
            }
            else
            {
                if (ddlFinalizarGrupos.SelectedIndex != 0)
                {
                    Session["MediaGrupo"] = null;
                    CarregarGruposFinalizar(Convert.ToInt32(ddlFinalizarGrupos.SelectedValue));
                    CriarTabelaMediasDisciplinas();
                    

                }
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalNaoPossuiGrupo", "msgNaoPossuiGrupos();", true);
        }
    }

    protected void ddlFinalizarGrupos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public static string[] nomesDisciplinas;
    public static string[] atribuicaoEnvolvidas;

    public void CarregarGruposFinalizar(int codGrupo)
    {
        string[] codAlunos = Grupo_Aluno_DB.SelectAllMatriculaByGrupo(codGrupo);
        string[] nomesAlunos = Funcoes.NomeAlunosByMatricula(codAlunos);
        string[] codEnvolvidas = (string[])Session["codEnvolvidas"];
        string[] nomesMaterias = Funcoes.MateriasByCodigo(codEnvolvidas);
        nomesDisciplinas = nomesMaterias;
        string[] atrEnvolvidas = (string[])Session["atrEnvolvidas"];
        atribuicaoEnvolvidas = atrEnvolvidas;

        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();

        dt.Columns.Add("Integrantes", typeof(string)); //ADICIONA A PRIMEIRA COLUNA DO CABEÇALHO (INTEGRANTES)

        //ADICIONA AS COLUNAS DO CABEÇALHO COM OS "IDs" DE ACORDO COM O NOME DO ALUNO 
        for (int i = 0; i < codEnvolvidas.Length; i++)
        {
            dt.Columns.Add(nomesMaterias[i], typeof(string));
        }


        for (int j = 0; j < nomesAlunos.Length; j++)
        {
            dr = dt.NewRow();
            for (int i = 0; i < codEnvolvidas.Length; i++)
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
        table.CssClass = "tableAlunosNotas";
        PanelFinalizarGrupo.Controls.Add(table);

        int rowsCount = dt.Rows.Count;
        int colsCount = dt.Columns.Count;
        Session["rowsCountFinalizar"] = rowsCount;
        Session["colsCountFinalizar"] = colsCount;

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell th = new TableHeaderCell();
        Label lblCabecalho = new Label();
        th.Text = "INTEGRANTES";
        th.Style.Add("background-color", "#FFF");
        th.Style.Add("border", "transparent");
        thr.Cells.Add(th);
        
       
        

        for (int i = 0; i < codEnvolvidas.Length; i++)
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
                    lblAlunos.Style.Add("font-weight", "bold");
                    lblAlunos.Text = Funcoes.SplitNomes(dt.Rows[rowIndex][colIndex].ToString());
                    lblAlunos.ToolTip = dt.Rows[rowIndex][colIndex].ToString();
                    lblAlunos.Attributes["data-toggle"] = "tooltip";
                    cell.Controls.Add(lblAlunos);
                }
                else
                {
                    lblNotas = new Label();
                    lblNotas.ID = "lblNotasRow_" + (rowIndex) + "_Col_" + colIndex;
                    lblNotas.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    cell.Style.Add("text-align", "center");
                    lblNotas.Text = Funcoes.CalcularMediaPonderadaAlunoDisciplinas(Convert.ToInt32(Session["codPIAtivo"]), codAlunos[rowIndex], Convert.ToInt32(atrEnvolvidas[colIndex - 1])).ToString();
                    cell.Controls.Add(lblNotas);
                }
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ZebradoGridAvaliar", "ZebradoGridAvaliar();", true);


    }


    private void CriarTabelaMediasDisciplinas()
    {
        int cont = 0;
        double somaMedia = 0;
        DataSet dsGruposFinalizar = (DataSet)Session["GruposFinalizar"];
        string[] codEnvolvidas = (string[])Session["codEnvolvidas"];
        int CodGrupo = Convert.ToInt32(ddlFinalizarGrupos.SelectedValue);
        lblMediaGrupos.Style.Add("font-size", "15px");
        lblMediaGrupos.Style.Add("margin-top", "8px");

        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();
        

        dt.Columns.Add("Disciplinas", typeof(string)); //ADICIONA A PRIMEIRA COLUNA DO CABEÇALHO (DISCIPLINAS)        
        dt.Columns.Add("Media", typeof(string));
        

        for (int j = 0; j < nomesDisciplinas.Length; j++)
        {
            dr = dt.NewRow();
            for (int i = 0; i < 2; i++)
            {
                int atr = Convert.ToInt32(atribuicaoEnvolvidas[j]);
                if (i == 0) //COLUNA FOR IGUAL A 0
                {
                    dr["Disciplinas"] = nomesDisciplinas[j].ToString();
                }
                else
                {
                    dr["Media"] = Funcoes.SelectMediabyDisciplina(atr, CodGrupo, Convert.ToInt32(Session["codPIAtivo"])).ToString();
                    if (dr["Media"] != "-")
                    {
                        cont++;
                        somaMedia += Convert.ToDouble(dr["Media"]);
                    }
                }
            }
            dt.Rows.Add(dr);
        }
        cont++;
        if (cont == codEnvolvidas.Length)
        {
            Session["MediaGrupo"] = (somaMedia / cont); 
            lblMediaGrupos.Text = Session["MediaGrupo"].ToString();
            lblMediaGrupos.Style.Add("color", "#960d10");
            lblMediaGrupos.Style.Add("font-size", "18px");
            lblMediaGrupos.Style.Add("font-weight", "bold");
        }
        else
        {
            lblMediaGrupos.Text = "Existem disciplinas sem avaliação";
            lblMediaGrupos.Style.Add("color", "#000");
        }

        gdvMediasDisciplinas.DataSource = dt;
        gdvMediasDisciplinas.DataBind();

        if (Session["MediaGrupo"] != null)
        {
            btnFinalizarGrupos.Enabled = true;
            //btnFinalizarGrupos.Style.Add("opacity", "1");
            //btnFinalizarGrupos.Style.Add("pointer-events", "focus");
        }
        else
        {
            btnFinalizarGrupos.Enabled = false;
            btnFinalizarGrupos.Style.Add("opacity", "0.4");            
            btnFinalizarGrupos.Style.Add("pointer-events", "none");
        }
 
    }


    protected void btnVoltarHome2_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }

    protected void btnFinalizarGrupos_Click(object sender, EventArgs e)
    {
        if (Session["MediaGrupo"] != null)
        {            
            Grupo gru = new Grupo();
            gru.Gru_codigo = Convert.ToInt32(ddlFinalizarGrupos.SelectedValue);
            gru.Gru_media = Convert.ToDouble(Session["MediaGrupo"]);
            Grupo_DB.UpdateGrupoAvaliado(gru);

            DataSet dsGruposFinalizar = new DataSet();
            dsGruposFinalizar = Grupo_DB.SelectAllGruposFinalizar(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));
            Session["GruposFinalizar"] = dsGruposFinalizar;

            Response.Redirect("finalizarGrupo.aspx");
        }
        
    }

}