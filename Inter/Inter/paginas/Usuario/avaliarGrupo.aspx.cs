using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;
using AppCode.Persistencia;

public partial class paginas_Usuario_avaliarGrupo : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }
        // CHAMAR A MASTER PAGE             
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["disciplina"].ToString() == "")
        {
            Response.Redirect("~/EscolherDisciplina");
        }

        if (Session["GruposAvaliar"] != null)
        {
            if (!IsPostBack)
            {
                btnSalvar.Enabled = false;
                btnFinalizar.Enabled = false;
                btnFinalizar.CssClass = "btn btn-default disabled";
                btnSalvar.CssClass = "btn btn-default disabled";

                //CARREGA DDL DOS GRUPOS DEPENDENDO DO PI ATIVO DA MATERIA SELECIONADA            
                ddlGrupos.DataSource = Session["GruposAvaliar"];
                ddlGrupos.DataTextField = "GRU_NOME_PROJETO";
                ddlGrupos.DataValueField = "GRU_CODIGO";
                ddlGrupos.DataBind();
                ddlGrupos.Items.Insert(0, "Selecione");

                DataSet dsCriteriosPesos = new DataSet();
                dsCriteriosPesos = Criterio_PI_DB.SelectCriteriosPesosByPI(Convert.ToInt32(Session["CodigoPIAtivoMateria"]), Convert.ToInt32(Session["codAtr"]));
                Session["dsCriteriosPesos"] = dsCriteriosPesos;
            }
            else //SE FOR POSTBACK
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "funcaoAtualizarMediaAll", "funcaoAtualizarMediaAll();", true);                

                if (ddlGrupos.SelectedIndex != 0)
                {
                    DataSet dsCriteriosPesos = (DataSet)Session["dsCriteriosPesos"];
                    CarregaTableAvaliar(Convert.ToInt32(ddlGrupos.SelectedValue), dsCriteriosPesos);
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalNaoPossuiGrupo", "msgNaoPossuiGrupos();", true);
        }


    }

    protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrupos.SelectedIndex != 0)
        {
            int rowsCount = Convert.ToInt32(Session["rowsCount"]);
            int colsCount = Convert.ToInt32(Session["colsCount"]);

            //LIMPAR TEXTBOX NOTAS
            for (int j = 1; j < colsCount; j++) //ALUNOS
            {

                for (int i = 0; i < rowsCount; i++) //CRITÉRIOS
                {
                    //EX: txtNotasRow_1_Col_1 = [0] = txtNotasRow - [1] = 1 - [2] = Col - [3] = 1
                    TextBox txtNota = (TextBox)Page.FindControl("ctl00$ctl00$cphConteudo$cphConteudoCentral$txtNotasRow_" + i.ToString() + "_Col_" + j.ToString());
                    txtNota.Text = string.Empty;
                }
            }

            btnSalvar.Enabled = true;
            btnFinalizar.Enabled = true;
            btnFinalizar.CssClass = "btn btn-default";
            btnSalvar.CssClass = "btn btn-default";
        }
        else
        {
            btnSalvar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnFinalizar.CssClass = "btn btn-default disabled";
            btnSalvar.CssClass = "btn btn-default disabled";
        }

    }


    private void CarregaTableAvaliar(int codGrupo, DataSet dsCriteriosPesos)
    {
        string[] codAlunos = Grupo_Aluno_DB.SelectAllMatriculaByGrupo(codGrupo);
        string[] nomeAlunos = Funcoes.NomeAlunosByMatricula(codAlunos);
        Session["matriculasAlunos"] = codAlunos;

        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();


        dt.Columns.Add(" ", typeof(string)); //ADICIONA UMA COLUNA DO CABEÇALHO VAZIA

        //ADICIONA AS COLUNAS DO CABEÇALHO COM OS "IDs" DE ACORDO COM O NOME DO ALUNO 
        for (int i = 0; i < nomeAlunos.Length; i++)
        {
            dt.Columns.Add(Funcoes.SplitNomes((i + 1) + nomeAlunos[i].ToString()), typeof(string));
        }

        string pesos = "";

        for (int j = 0; j < dsCriteriosPesos.Tables[0].Rows.Count; j++)
        {
            dr = dt.NewRow();
            for (int i = 0; i < nomeAlunos.Length + 1; i++)
            {
                if (i == 0) //COLUNA FOR IGUAL A 0
                {
                    pesos += dsCriteriosPesos.Tables[0].Rows[j]["cpi_peso"].ToString() + "|";
                    dr[" "] = dsCriteriosPesos.Tables[0].Rows[j]["cge_nome"].ToString() + " (" + dsCriteriosPesos.Tables[0].Rows[j]["cpi_peso"].ToString() + ")";
                }
            }
            dt.Rows.Add(dr);
        }

        valorPeso.Value = pesos.ToString();

        Table table = new Table();
        TextBox txbNotas;
        Label lblCriterios;

        table.ID = "tableAvaliar";
        table.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        table.CssClass = "gridViewAvaliar";
        panelAvaliar.Controls.Add(table);

        int rowsCount = dt.Rows.Count;
        int colsCount = dt.Columns.Count;
        Session["rowsCount"] = rowsCount;
        Session["colsCount"] = colsCount;

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell th = new TableHeaderCell();
        Label lblCabecalho = new Label();
        th.Text = " ";
        th.Style.Add("background-color", "#FFF");
        th.Style.Add("border", "transparent");
        thr.Cells.Add(th);

        for (int i = 0; i < nomeAlunos.Length; i++)
        {
            th = new TableHeaderCell();
            lblCabecalho = new Label();
            lblCabecalho.Text = Funcoes.SplitNomes(nomeAlunos[i].ToString());
            lblCabecalho.ToolTip = nomeAlunos[i].ToString();
            lblCabecalho.Attributes["data-toggle"] = "tooltip";

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
                    lblCriterios = new Label();
                    lblCriterios.ID = "lblCriteriosRow_" + rowIndex + "_Col_" + colIndex;
                    lblCriterios.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lblCriterios.Text = dt.Rows[rowIndex][colIndex].ToString();
                    cell.Controls.Add(lblCriterios);
                }
                else
                {
                    txbNotas = new TextBox();
                    txbNotas.ID = "txtNotasRow_" + (rowIndex) + "_Col_" + colIndex;
                    txbNotas.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    txbNotas.CssClass = "text";
                    txbNotas.MaxLength = 3;
                    //txbNotas.Attributes["type"] = "Number";
                    txbNotas.Attributes["min"] = "0";
                    txbNotas.Attributes["max"] = "10";
                    txbNotas.Attributes["onkeyup"] = "funcaoImpedirValorAvaliar(this.id);";
                    txbNotas.Attributes["onblur"] = "funcaoAtualizarMedia(this.id);";
                    cell.Style.Add("text-align", "center");
                    txbNotas.Text = dt.Rows[rowIndex][colIndex].ToString();

                    RequiredFieldValidator rfvTxb = new RequiredFieldValidator();
                    rfvTxb.ID = "rfvTxb" + rowIndex + "_Col_" + colIndex;
                    rfvTxb.ControlToValidate = "txtNotasRow_" + rowIndex + "_Col_" + colIndex;
                    rfvTxb.EnableClientScript = true;
                    rfvTxb.ErrorMessage = " *";
                    rfvTxb.ForeColor = System.Drawing.Color.Red;

                    RangeValidator ranTxb = new RangeValidator();
                    ranTxb.ID = "ranTxb" + rowIndex + "_Col_" + colIndex;
                    ranTxb.ControlToValidate = "txtNotasRow_" + rowIndex + "_Col_" + colIndex;
                    ranTxb.MinimumValue = "0";
                    ranTxb.MaximumValue = "10";
                    ranTxb.Type = ValidationDataType.Double;
                    ranTxb.EnableClientScript = true;
                    ranTxb.ErrorMessage = " *";
                    ranTxb.ForeColor = System.Drawing.Color.Red;

                    cell.Controls.Add(txbNotas);
                    cell.Controls.Add(rfvTxb);
                    cell.Controls.Add(ranTxb);

                }
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }

        TableRow rowMedia = new TableRow();
        Label lblMedia = new Label();

        for (int colIndex = 0; colIndex < colsCount; colIndex++)
        {
            TableCell cell = new TableCell();
            cell.CssClass = "mediaAvaliar";
            lblMedia = new Label();
            lblMedia.ID = "lblMediaRow_" + table.Rows.Count + "_Col_" + colIndex;
            lblMedia.ClientIDMode = System.Web.UI.ClientIDMode.Static;

            if (colIndex == 0)
            {
                lblMedia.Text = "Média Ponderada Individual: ";
            }
            else
            {
                lblMedia.Text = " ";
            }
            cell.Controls.Add(lblMedia);
            rowMedia.Cells.Add(cell);
        }
        table.Rows.Add(rowMedia);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ZebradoGridAvaliar", "ZebradoGridAvaliar();", true);
    }


    private void PegarValoresNotas()
    {
        double valorMultiplicacao = 0, valor = 0, mediaDisciplina = 0, mediaPonderada = 0, somaMediaPonderada = 0;
        int rowsCount = Convert.ToInt32(Session["rowsCount"]);
        int colsCount = Convert.ToInt32(Session["colsCount"]);
        int somaPeso = 0; 
        string[] todosPesos = valorPeso.Value.Split('|');

        DataSet dsCriteriosPesos = (DataSet)Session["dsCriteriosPesos"];
        int cpiCodigo = 0;
        string[] codAlunos = (string[])Session["matriculasAlunos"];

        string sqlInsertHistoricoAluDisc = "";        

        for (int j = 1; j < colsCount; j++) //ALUNOS
        {
            Historico_Aluno_Disciplina his = new Historico_Aluno_Disciplina();
            Grupo_Aluno gal = new Grupo_Aluno();            

            gal.Alu_matricula = codAlunos[j - 1];
            his.Alu_matricula = gal;

            for (int i = 0; i < rowsCount; i++) //CRITÉRIOS
            {
                //txtNotasRow_1_Col_1 = [0] = txtNotasRow - [1] = 1 - [2] = Col - [3] = 1
                TextBox txtNota = (TextBox)Page.FindControl("ctl00$ctl00$cphConteudo$cphConteudoCentral$txtNotasRow_" + i.ToString() + "_Col_" + j.ToString());
                                
                valor = Convert.ToDouble(txtNota.Text);                    
                valorMultiplicacao += valor * Convert.ToInt32(todosPesos[i]);
                //ESTÁ COM ERRO QUADO USA NUMERO DECIMAL PESQUISAR valor.ToString("D", cultureInfo);
               
                somaPeso += Convert.ToInt32(todosPesos[i]);

                cpiCodigo = Convert.ToInt32(dsCriteriosPesos.Tables[0].Rows[i]["CPI_CODIGO"]); //CÓDIGO DO CRITÉRIO PI
                Criterio_PI cpi = new Criterio_PI();
                cpi.Cpi_codigo = cpiCodigo;
                his.Cpi_codigo = cpi;
                his.His_nota = valor;
                his.His_usuario = Session["nome"].ToString();

                sqlInsertHistoricoAluDisc += "(0,'" + his.Alu_matricula.Alu_matricula + "'," + his.Cpi_codigo.Cpi_codigo + "," + his.His_nota + ",'" + his.His_usuario + "'),";
            }
            mediaPonderada = valorMultiplicacao / somaPeso;
            somaMediaPonderada += mediaPonderada;
            somaPeso = 0;
            valorMultiplicacao = 0;
        }
        Historico_Aluno_Disciplina_DB.Insert(sqlInsertHistoricoAluDisc.Substring(0, sqlInsertHistoricoAluDisc.Length - 1));

        int qtdAlunos = colsCount - 1;
        mediaDisciplina = Math.Round((somaMediaPonderada / qtdAlunos),2);

        Grupo gru = new Grupo();
        gru.Gru_codigo = Convert.ToInt32(ddlGrupos.SelectedValue);
        //Grupo_DB.UpdateGrupoAvaliado(gru);

        Projeto_Inter pri = new Projeto_Inter();
        pri.Pri_codigo = Convert.ToInt32(Session["CodigoPIAtivoMateria"]);

        Atribuicao_PI api = new Atribuicao_PI();
        api.Adi_codigo = Convert.ToInt32(Session["codAtr"]);

        Media_Disciplina mdd = new Media_Disciplina();
        mdd.Pri_codigo = pri;
        mdd.Adi_codigo = api;
        mdd.Gru_codigo = gru;
        mdd.Mdd_media = mediaDisciplina;

        Media_Disciplina_DB.Insert(mdd);

        ddlGrupos.Items.RemoveAt(ddlGrupos.SelectedIndex);

        DataSet dsGruposFinalizar = new DataSet();
        dsGruposFinalizar = Grupo_DB.SelectAllGruposFinalizar(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));
        if (dsGruposFinalizar == null)
        {
            Session["GruposFinalizar"] = null;
        }
        else
        {
            Session["GruposFinalizar"] = dsGruposFinalizar;
        }

        DataSet dsGruposAvaliar = new DataSet();
        dsGruposAvaliar = Grupo_DB.SelectAllGruposAvaliar(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));
        if (dsGruposAvaliar == null)
        {
            Session["GruposAvaliar"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalTodosAvaliados", "msgTodosAvaliados();", true);
        }
        else
        {
            Session["GruposAvaliar"] = dsGruposAvaliar;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalGrupoAvaliado", "msgGrupoAvaliado();", true);
        }
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        PegarValoresNotas();
    }

    protected void btnVoltarHome2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home");
    }

    protected void btnGrupoAvaliado_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AvaliarGrupo");
    }







}
