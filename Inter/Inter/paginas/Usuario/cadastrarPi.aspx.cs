using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using AppCode.Persistencia;
using System.Web.Services;
using System.Web.Script.Serialization;
using Interdisciplinar;
//using System.Runtime.Serialization.Json;


public partial class paginas_Usuario_cadastrarPi : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }
        // CHAMAR A MASTER PAGE - OBS: MASTERPAGEFILE É O CAMINHO DO ARQUIVO MASTERPAGE QUE VOCÊ DESEJA CHAMAR        
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //BLOQUEIO URL SE NÃO TIVER ESCOLHIDO ALGUMA DISCIPLINA 
        if (Session["disciplina"] == "")
        {
            Response.Redirect("~/EscolherDisciplina");
        }

        //BLOQUEIO SE NÃO FOR DISCIPLINA-MÃE

        if (Session["mae"] == "FILHA")
        {
            Response.Redirect("~/Home");
        }

        if (Session["codPIAtivo"] == null)
        {

            //SE NÃO FOR POSTBACK VAI CARREGAR OS MÉTODOS ABAIXO DESCRITOS
            if (!IsPostBack)
            {
                CarregaCriGerais();
                CarregaAlunosCadastrarPi();
                CarregarDisciplinasEnvolvidas();
                updPanelGrupos.Update();
                PegarAnoeSemestreAno();
                PegarUltimoCodPI();
                lblCursoAut.Text = Session["curso"].ToString();
                lblSemestreAut.Text = Session["semestre"].ToString();
                index = 1;
                btnConfirmarEdicao.Style.Add("opacity", "0.4");
                btnExcluirGrupo.Style.Add("opacity", "0.4");
                btnCancelarEdicao.Style.Add("opacity", "0.4");
                btnConfirmarEdicao.Style.Add("pointer-events", "none");
                btnCancelarEdicao.Style.Add("pointer-events", "none");
                btnExcluirGrupo.Style.Add("pointer-events", "none");

            }

            CriarCriterio();
            updPanelPeso.Update();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalPossuiPI", "msgPossuiPI();", true);
        }

    }

    // ******************  ETAPA 1 - CADASTRO PI, CADASTRO DE DATAS ******************
    // *******************************************************************************
    public static List<int> listAtrDisciplinas = new List<int>();
    public static List<int> listCodDisciplinas = new List<int>();
    private void CarregarDisciplinasEnvolvidas(){    

        string[] nomeEnvolvidas = (string[])Session["nomeEnvolvidas"];
        string[] maeEnvolvidas = (string[])Session["maeEnvolvidas"];
        string[] atrEnvolvidas = (string[])Session["atrEnvolvidas"];
        string[] codEnvolvidas = (string[])Session["codEnvolvidas"];


        Table tableDisciplina = new Table();
        tableDisciplina.CssClass = "tableDisciplinasEnvolvidas";
        PainelDisciplinas.Controls.Add(tableDisciplina);
        int row = nomeEnvolvidas.Length;

        TableHeaderCell th = new TableHeaderCell();
        TableHeaderRow thr = new TableHeaderRow();

        //ADICIONANDO CABEÇALHO  DISCIPLINAS / MÃE-FILHAS
        th = new TableHeaderCell();
        th.Text = "Código";        
        thr.Cells.Add(th);
        tableDisciplina.Rows.Add(thr);

        th = new TableHeaderCell();
        th.Text = "Disciplinas";
        thr.Cells.Add(th);
        tableDisciplina.Rows.Add(thr);

        th = new TableHeaderCell();
        th.Text = "Mãe/Filha";
        thr.Cells.Add(th);
        tableDisciplina.Rows.Add(thr);

        Label lblDisciplinas = new Label();
        Label lblCodigoDisciplina = new Label();

        for (int i = 0; i < row; i++)
        {
            TableRow rows = new TableRow();
            for (int j = 0; j < 3; j++)
            {
                TableCell cell = new TableCell();
                    if (j == 1)
                    {
                        lblDisciplinas = new Label();
                        lblDisciplinas.Text = nomeEnvolvidas[i];
                        cell.Controls.Add(lblDisciplinas);
                    }
                    else if(j == 2)
                    {
                        lblDisciplinas = new Label();
                        if (maeEnvolvidas[i] == "MAE")
                        {
                            //ÍCONE DA ESTRELINHA
                            lblDisciplinas.Text = "<span class='glyphicon glyphicon-star'></span>";
                        }
                        else
                        {
                            //ÍCONE DE TRACINHO
                            lblDisciplinas.Text = "<span class='glyphicon glyphicon-minus'></span>";
                        }
                        cell.Controls.Add(lblDisciplinas);
                    }
                    else
                    {
                        lblCodigoDisciplina = new Label();
                        lblCodigoDisciplina.Text = atrEnvolvidas[i];
                        lblCodigoDisciplina.ID = "codDisciplina" + i;
                        cell.Controls.Add(lblCodigoDisciplina);
                        listAtrDisciplinas.Add(Convert.ToInt32(lblCodigoDisciplina.Text));
                        listCodDisciplinas.Add(Convert.ToInt32(codEnvolvidas[i]));
                    }
                    rows.Cells.Add(cell);                
            }
            tableDisciplina.Rows.Add(rows);
        }  
    }

    private void PegarUltimoCodPI()
    {
        // PEGAR ULTIMO CODIGO DE PI E ACRESCENTAR 1
        int cod = Projeto_Inter_DB.SelectUltimoCod();
        int codMais = cod + 1;
        if (codMais < 0) {
            codMais = 1;
        }
        lblCodigoPiAut.Text = codMais.ToString();
    }

    private void PegarAnoeSemestreAno()
    {
        // PEGAR ANO E SEMESTRE DO ANO DO BANCO DE DADOS
        Semestre_Ano objSemAno = new Semestre_Ano();
        objSemAno = Semestre_Ano_DB.Select();
        lblSemestreAnoAut.Text = objSemAno.San_semestre.ToString();
        lblAnoAut.Text = objSemAno.San_ano.ToString();
    }

    public static string[] desc;
    public static string[] dat;

    [System.Web.Services.WebMethod]
    public static string GetEventos(string dadosEventos)
    {

        string[] eventos = dadosEventos.Split('|'); //DIVIDE QUANDO ACHAR O PIPE('|') 

        List<string> descricao = new List<string>(); //CRIA UMA LIST, PORQUE NÃO TEM UM TAMANHO DEFINIDO
        List<string> data = new List<string>();


        for (int i = 0; i < eventos.Length - 1; i++)
        {
            if (i % 2 == 0) //SE FOR PAR
            {
                descricao.Add(eventos[i]);
            }
            else //SE FOR IMPAR
            {
                data.Add(eventos[i]);
            }

        }

        desc = descricao.ToArray(); //TOARRAY CONVERTE A LIST EM ARRAY
        dat = data.ToArray();


        return dadosEventos;

    }



    // ****************** ETAPA 2 - CADASTRO DE CRITÉRIOS ******************
    //**********************************************************************

    //EVENTO QUE MOVE OS CRITÉRIOS GERAIS PARA A LISTBOX DE CRITÉRIOS ESCOLHIDOS PARA O PI
    protected void listaCritGeral_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaCritPi.Items.Add(listaCritGeral.SelectedItem);
        listaCritGeral.Items.RemoveAt(listaCritGeral.SelectedIndex);
        listaCritGeral.ClearSelection();
        listaCritPi.ClearSelection();
        CarregaTip();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }

    //EVENTO QUE MOVE OS CRITÉRIOS ESCOLHIDOS PARA O PI PARA A LISTBOX DE CRITÉRIOS GERAIS
    protected void listaCritPi_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaCritGeral.Items.Add(listaCritPi.SelectedItem);
        listaCritPi.Items.RemoveAt(listaCritPi.SelectedIndex);
        listaCritGeral.ClearSelection();
        listaCritPi.ClearSelection();
        CarregaTip();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }

    private void CarregaTip()
    {
        string[] vetTip = liCritTip.ToArray();
        string[] vetCod = liCritCod.ToArray();
        foreach (ListItem li in listaCritGeral.Items)
        {
            for (int j = 0; j < vetCod.Length; j++)
            {
                if (li.Value == vetCod[j])
                {
                    li.Attributes.Add("title", vetTip[j]);
                    li.Attributes["data-toggle"] = "tooltip";
                }
            }

        }

        foreach (ListItem li in listaCritPi.Items)
        {
            for (int j = 0; j < vetCod.Length; j++)
            {
                if (li.Value == vetCod[j])
                {
                    li.Attributes.Add("title", vetTip[j]);
                    li.Attributes["data-toggle"] = "tooltip";
                }
            }

        }
    }

    public static List<string> liCritTip = new List<string>(); //PARA ARMAZENAR O QUE VAI APARECER NO TIP
    public static List<string> liCritCod = new List<string>(); //PARA ARMAZENAR O CÓDIGO E COMPARAR COM O VALUE PARA JOGAR NO LISTITEM CERTO O TIP
    
    public static int UltCodCrit = 0;

    //MÉTODO PARA CARREGAR OS CRITÉRIOS GERAIS DO BANCO NO COMPONENTE LISTBOX
    private void CarregaCriGerais()
    {
        //DATASET VAI RECEBER TODOS OS CRITÉRIOS DO BANCO DE DADOS PELO SELECTALL
        DataSet ds = Criterios_Gerais_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;
        UltCodCrit = Criterios_Gerais_DB.SelectUltimoCod();

        if (UltCodCrit == -2)
        {
            UltCodCrit = 0;
        }

        //SE HOUVER CRITÉRIOS 
        if (qtd > 0)
        {
            //VAI RODAR TODAS AS LINHAS DO DATASET E JOGAR OS DADOS NA LISTBOX 
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem li = new ListItem();
                li.Value = dr["cge_codigo"].ToString();
                li.Text = dr["cge_nome"].ToString();
                li.Attributes.Add("title", dr["cge_descricao"].ToString());
                li.Attributes["data-toggle"] = "tooltip";
                liCritTip.Add(dr["cge_descricao"].ToString());
                liCritCod.Add(dr["cge_codigo"].ToString());
                //ADICIONANDO CÓDIGO E NOME DO CRITÉRIO AOS CRITÉRIOS ENCONTRADOS NO DATASET
                listaCritGeral.Items.Add(li);

            }

        }
    }

    //EVENTO DO BOTÃO CRIAR NOVO CRITERIO: CRIA UM NOVO CRITÉRIO E MOVE PARA O LISTBOX CRITÉRIOS DO PI
    protected void btnCriarNovoCriterio_Click(object sender, EventArgs e)
    {
        txtNomeCriterio.Style.Clear();
        txtDescricaoCriterio.Style.Clear();

        if (!String.IsNullOrEmpty(txtNomeCriterio.Text.Trim()) && !String.IsNullOrEmpty(txtDescricaoCriterio.Text.Trim()))
        {            
            Criterios_Gerais cge = new Criterios_Gerais();
            cge.Cge_codigo = (UltCodCrit + 1);
            cge.Cge_nome = txtNomeCriterio.Text;
            cge.Cge_descricao = txtDescricaoCriterio.Text;
            cge.Cge_usuario = Session["nome"].ToString();
            if (Criterios_Gerais_DB.Insert(cge) != -2)
            {
                //ADICIONA OS NOVOS CRITÉRIOS NAS LISTAS
                ListItem li = new ListItem();

                li.Value = (UltCodCrit + 1).ToString();
                li.Text = txtNomeCriterio.Text;
                li.Attributes.Add("title", txtDescricaoCriterio.Text);
                li.Attributes["data-toggle"] = "tooltip";
                liCritTip.Add(txtDescricaoCriterio.Text);
                liCritCod.Add(li.Value);
                //ADICIONANDO CÓDIGO E NOME DO CRITÉRIO AOS CRITÉRIOS ENCONTRADOS NO DATASET
                listaCritPi.Items.Add(li);
                updPanelCriterio.Update();
                UltCodCrit += 1;
                CarregaTip();
                
                lblMsgCriterio.Text = "<span class='glyphicon glyphicon-ok-circle'></span> &nbsp Cadastrado com sucesso.";
                lblMsgCriterio.Style.Add("color", "green");
                txtNomeCriterio.Text = "";
                txtDescricaoCriterio.Text = "";
            }
            else
            {
                lblMsgCriterio.Text = "<span class='glyphicon glyphicon-remove-circle'></span> &nbsp Falha ao cadastrar critério, tente novamente.";
                lblMsgCriterio.Style.Add("color", "red");
            }
            
        }
        else if (String.IsNullOrEmpty(txtNomeCriterio.Text.Trim()) && String.IsNullOrEmpty(txtDescricaoCriterio.Text.Trim()))
        {
            lblMsgCriterio.Text = "<span class='glyphicon glyphicon-remove-circle'></span>&nbsp Campo obrigatório.";
            lblMsgCriterio.Style.Add("color", "red");

            txtNomeCriterio.Style.Add("border", "solid 1px red");
            txtDescricaoCriterio.Style.Add("border", "solid 1px red");
        }
        else if (String.IsNullOrEmpty(txtNomeCriterio.Text.Trim()))
        {
            lblMsgCriterio.Text = "<span class='glyphicon glyphicon-remove-circle'></span>&nbsp Campo obrigatório.";
            lblMsgCriterio.Style.Add("color", "red");

            txtNomeCriterio.Style.Add("border", "solid 1px red");
        }
        else
        {
            lblMsgCriterio.Text = "<span class='glyphicon glyphicon-remove-circle'></span>&nbsp Campo obrigatório.";
            lblMsgCriterio.Style.Add("color", "red");

            txtDescricaoCriterio.Style.Add("border", "solid 1px red");
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }

    //EVENTO DO BOTÃO CONTINUAR(ETAPA 3 CRITÉRIOS(PESOS)) : CRIA OS CRITÉRIOS, ATUALIZA O PAINEL E REDIRECIONA PARA PRÓXIMA ETAPA
    protected void btnContinuarEtapa3_Click(object sender, EventArgs e)
    {
        CarregaTip();
        if (listaCritPi.Items.Count >= 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
            lblMsgErroAdicionarCriterio.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
            lblMsgErroAdicionarCriterio.Visible = true;
        }
    }

    protected void btnCancelarCriterio_Click(object sender, EventArgs e)
    {
        txtNomeCriterio.Text = "";
        txtDescricaoCriterio.Text = "";
        txtNomeCriterio.Style.Clear();
        txtDescricaoCriterio.Style.Clear();
        lblMsgCriterio.Text = "";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModalCriacaoCriterio", "FechaModalCriacaoCriterio();", true);
    }

    // ******************* ETAPA 3 - ADICIONAR PESO AOS CRITÉRIOS ********************
    // *******************************************************************************

    //MÉTODO PARA CRIAR OS COMPONENTES LABELS E TEXTBOX PARA COLOCAR OS PESOS NOS CRITÉRIOS
    public void CriarCriterio()
    {
        //QUANTIDADE DE CRITÉRIOS SELECIONADOS PARA O PI
        int tamanho = (Int32)listaCritPi.Items.Count;

        //CRIA VETORES DE COMPONENTES
        Label[] lblCriterios = new Label[tamanho];
        TextBox[] txtCriterios = new TextBox[tamanho];
        Label[] lblLinha = new Label[tamanho];


        for (int i = 0; i < tamanho; i++)
        {
            //CRIANDO ATRIBUTOS PARA OS COMPONENTES
            lblCriterios[i] = new Label();
            lblCriterios[i].ID = "lblCriterio" + (i);
            lblCriterios[i].CssClass = "label";
            lblCriterios[i].Text = listaCritPi.Items[i].ToString() + ": ";

            txtCriterios[i] = new TextBox();
            txtCriterios[i].ID = "txtCriterio" + (i);
            txtCriterios[i].CssClass = "text";
            txtCriterios[i].Attributes["type"] = "Number";
            txtCriterios[i].Attributes["min"] = "1";
            txtCriterios[i].Attributes["max"] = "10";
            txtCriterios[i].ClientIDMode = System.Web.UI.ClientIDMode.Static;
            txtCriterios[i].Attributes["onkeyup"] = "funcaoImpedirValor(this.id);";

            lblLinha[i] = new Label();
            lblLinha[i].ID = "lblL" + (i);
            lblLinha[i].Text = String.Format("<br/><br/>");

            //ADICIONANDO OS COMPONENTES PARA O PAINEL 
            PanelCriterios.Controls.Add(lblCriterios[i]);
            PanelCriterios.Controls.Add(txtCriterios[i]);
            PanelCriterios.Controls.Add(lblLinha[i]);


        }

    }


    //VERIFICAR SE OS TEXTBOXS DOS PESOS ESTÃO EM BRANCO OU INVÁLIDOS
    protected int verificarPesoVazio()
    {
        int peso = 0;
        int ret = 0;
        foreach (Control txt in PanelCriterios.Controls)
        {
            if (txt is TextBox)
            {
                TextBox txtCri = (TextBox)txt;
                txtCri.Style.Clear();
                if (String.IsNullOrEmpty(txtCri.Text))
                {
                    return 1;
                }

                peso = Convert.ToInt32(txtCri.Text);
                if ((peso < 1) || (peso > 10))
                {
                    txtCri.Style.Add("border", "1px solid red");
                    ret = 2;
                    lblMsgPesosCriterios.Visible = true;
                }

            }
        }
        return ret;

    }

    //VERIFICAR SE OS TEXTBOXS DOS PESOS ESTÃO EM BRANCO E ACRESCENTA 1 AO PESO
    protected void PreencherPesoVazio()
    {

        foreach (Control txt in PanelCriterios.Controls)
        {
            if (txt is TextBox)
            {
                TextBox txtCri = (TextBox)txt;

                if (String.IsNullOrEmpty(txtCri.Text))
                {
                    txtCri.Text = "1";
                }

            }
        }

    }

    protected void ContinuarEtapa4_Click(object sender, EventArgs e)
    {
        if (verificarPesoVazio() == 1) // QUANDO TEXTBOX ESTÁ VAZIO
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
            //CHAMA A MODAL PESO VAZIO
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostraModalPesoUm", "MostraModalPesoUm();", true);
        }
        else if (verificarPesoVazio() == 2) // VALOR DE PESO INVÁLIDO
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
        }
        else // SECESSO 
        {
            lblMsgPesosCriterios.Visible = false;
            CarregaTipAluno();
            updPanelGrupos.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "Modaletapa4('p13');", true);

        }
    }

    //ADICIONA PESO 1 AS TEXTBOXS VAZIAS  
    protected void btnAdicionarPesoUm_Click(object sender, EventArgs e)
    {
        PreencherPesoVazio();
        updPanelPeso.Update();
        CarregaTip();
        lblMsgPesosCriterios.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "fechaModalPeso1", "fechaModalPeso1();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
    }


    // ******************** ETAPA 4 - CRIAR GRUPO ******************
    // *************************************************************
    public static List<string> liNomeAlunoTip = new List<string>(); //PARA ARMAZENAR O QUE VAI APARECER NO TIP
    public static List<string> liMatriculaAluno = new List<string>(); //PARA ARMAZENAR O CÓDIGO E COMPARAR COM O VALUE PARA JOGAR NO LISTITEM CERTO O TIP

    private void CarregaTipAluno()
    {
        string[] vetTip = liNomeAlunoTip.ToArray();
        string[] vetCod = liMatriculaAluno.ToArray();
        foreach (ListItem li in listaAlunoGeral.Items)
        {
            for (int j = 0; j < vetCod.Length; j++)
            {
                if (li.Value == vetCod[j])
                {
                    li.Attributes.Add("title", vetTip[j]);
                    li.Attributes["data-toggle"] = "tooltip";

                }
            }

        }

        foreach (ListItem li in listaAlunosGrupo.Items)
        {
            for (int j = 0; j < vetCod.Length; j++)
            {
                if (li.Value == vetCod[j])
                {
                    li.Attributes.Add("title", vetTip[j]);
                    li.Attributes["data-toggle"] = "tooltip";

                }
            }

        }
    }

    //MÉTODO PARA CARREGAR OS ALUNOS GERAIS DO BANCO NO COMPONENTE LISTBOX
    private void CarregaAlunosCadastrarPi()
    {
        //DATASET VAI RECEBER TODOS OS CRITÉRIOS DO BANCO DE DADOS PELO SELECTALL        

        DataSet dsAluno = new DataSet();
        int codAtr = (int)Session["codAtr"];
        dsAluno = Matricula.ListaPresenca(codAtr);      
        int qtd = dsAluno.Tables[0].Rows.Count;

        //SE HOUVER ALUNOS 
        if (qtd > 0)
        {
            //VAI RODAR TODAS AS LINHAS DO DATASET E JOGAR OS DADOS NA LISTBOX 
            foreach (DataRow dr in dsAluno.Tables[0].Rows)
            {
                ListItem li = new ListItem();
                li.Value = dr["Matricula"].ToString();
                li.Text = Funcoes.SplitNomes(dr["Nome"].ToString());
                li.Attributes.Add("title", dr["Nome"].ToString());
                li.Attributes["data-toggle"] = "tooltip";
                liNomeAlunoTip.Add(dr["Nome"].ToString());
                liMatriculaAluno.Add(dr["Matricula"].ToString());
                //ADICIONANDO CÓDIGO E NOME DO CRITÉRIO AOS CRITÉRIOS ENCONTRADOS NO DATASET
                listaAlunoGeral.Items.Add(li);

            }
            
        }
    }

    //EVENTO QUE MOVE OS ALUNOS DA LISTA GERAL PARA A LISTA ESPECÍFICA DE ALUNOS DAQUELE GRUPO 
    protected void listaAlunoGeral_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunosGrupo.Items.Add(listaAlunoGeral.SelectedItem);
        listaAlunoGeral.Items.RemoveAt(listaAlunoGeral.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();
        CarregaTipAluno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }


    //EVENTO QUE MOVE OS ALUNOS DA LISTA ESPECÍFICA PARA A LISTA GERAL DE ALUNOS  
    protected void listaAlunosGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunoGeral.Items.Add(listaAlunosGrupo.SelectedItem);
        listaAlunosGrupo.Items.RemoveAt(listaAlunosGrupo.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();
        CarregaTipAluno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //EVENTO DO BOTÃO VOLTAR: REDIRECIONA PARA A ETAPA ANTERIOR
    protected void LkbVoltarEtapa3_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
    }    

    //REDIRECIONA PARA A PÁGINA HOME
    protected void btnVoltarHome2_Click(object sender, EventArgs e)
    {
        Session.Remove("alunosGerais");
        Session.Remove("CodAlunosGerais");
        Response.Redirect("~/Home");
    }


    //EVENTO DO BOTÃO CONFIRMAR GRUPO: GUARDA O GRUPO ATUAL(COM OS ALUNOS QUE FORAM ESCOLHIDOS) E SUCESSIVAMENTE CRIA NOVO GRUPO
    public static int index = 1; //É UMA CONTROLADORA DO VIEWSTATE (EX: VIEWSTATE["ALUNOS1"]) OBS: PELO INDEX COMEÇAR NO VALOR "1" NÃO HAVERÁ "GRUPO0"
    protected void btnConfirmarGrupo_Click(object sender, EventArgs e)
    {
        CarregaTipAluno();

        if (!String.IsNullOrEmpty(txtNomeGrupo.Text))
        {
            txtNomeGrupo.Style.Clear();

            string listItem = ""; //GUARDA OS ALUNOS ESCOLHIDOS EM UM GRUPO 
            string listItemValue = ""; // GUARDA OS CÓDIGOS DOS ALUNOS

            foreach (ListItem item in listaAlunosGrupo.Items)
            {
                listItem += item.Text + "|"; //GUARDANDO TODOS OS ALUNOS NA MESMA VARIÁVEL E DETERMINANDO UM CARACTER DE "QUEBRA"("|") PARA SEPARAR OS NOMES
                listItemValue += item.Value + "|"; // GUARDANDO TODOS OS CÓDIGOS DOS ALUNOS
            }

            ViewState["NomeGrupo" + index.ToString()] = txtNomeGrupo.Text;
            ViewState["Alunos" + index.ToString()] = listItem;
            ViewState["CodAlunos" + index.ToString()] = listItemValue;

            //ADICIONANDO AO LISTBOX DE GRUPOS, ADICIONA O NOME DO GRUPO AO LISITEM E NO VALUE RECEBE UM INDEX ÚNICO PARA CADA LISTITEM
            listaGrupos.Items.Add(new ListItem("Grupo: " + txtNomeGrupo.Text, index.ToString()));
            index++;
            listaAlunosGrupo.Items.Clear();
            txtNomeGrupo.Text = "";

            // ** CASO VENHA A CANCELAR OU EXCLUIR, IRÁ RETORNAR AO ESTADO ANTERIOR
            string listItemGeral = "", listItemValueGeral = "";
            foreach (ListItem item in listaAlunoGeral.Items)
            {
                listItemGeral += item.Text + "|"; //ATRIBUINDO TODOS OS ALUNOS DA LISTA ALUNO GERAL
                listItemValueGeral += item.Value + "|";
            }
            Session["alunosGerais"] = listItemGeral; // ** CASO CANCELAR OU EXCLUIR
            Session["CodAlunosGerais"] = listItemValueGeral;
        }
        else
        {
            txtNomeGrupo.Style.Add("border", "1px solid red");

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //EDIÇÃO: QUANDO CLICAR NO LISTBOX DOS GRUPOS CRIADOS(AO CLICAR EM UM DOS GRUPOS INSERIDOS ELE JÁ VAI PARA O MODO DE EDIÇÃO)
    protected void listaGrupos_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunosGrupo.Items.Clear();
        listaAlunoGeral.Items.Clear();

        string listItemGeral = Session["alunosGerais"].ToString();
        string listItemCodGeral = Session["CodAlunosGerais"].ToString();

        string[] arrayAlunosGerais = listItemGeral.Split('|');
        string[] arrayCodAlunosGerais = listItemCodGeral.Split('|');

        //COLOCANDO DE VOLTA OS VALORES NO LISTA DE ALUNO GERAL
        for (int i = 0; i < arrayAlunosGerais.Length - 1; i++)
        {
            listaAlunoGeral.Items.Add(new ListItem(arrayAlunosGerais[i], arrayCodAlunosGerais[i]));
        }

        int indice = Convert.ToInt32(listaGrupos.SelectedValue); //PEGA O VALUE(INDICE DA VIEW) DA LISTBOX QUE IRÁ EDITAR
        string listItem = ViewState["Alunos" + indice.ToString()].ToString();
        string listItemValue = ViewState["CodAlunos" + indice.ToString()].ToString();
        string[] arrayCodAlunos = listItemValue.Split('|');
        string[] arrayAlunos = listItem.Split('|');

        //COLOCAR TODOS OS ALUNOS NA LISTBOX ALUNOS GRUPO
        for (int i = 0; i < arrayAlunos.Length - 1; i++)
        {
            listaAlunosGrupo.Items.Add(new ListItem(arrayAlunos[i], arrayCodAlunos[i])); /*ESTÁ DANDO ERRO AQUI*/
        }

        txtNomeGrupo.Text = ViewState["NomeGrupo" + indice.ToString()].ToString();

        //HABILITANDO OS BOTÕES E RETIRANDO O CSS DE OPACITY 	
        btnConfirmarGrupo.Enabled = false;
        btnConfirmarEdicao.Enabled = true;
        btnExcluirGrupo.Enabled = true;
        btnCancelarEdicao.Enabled = true;
        listaGrupos.Enabled = false;

        btnConfirmarGrupo.Style.Add("opacity", "0.4");
        btnConfirmarGrupo.Style.Add("pointer-events", "none");

        btnConfirmarEdicao.Style.Clear();
        btnExcluirGrupo.Style.Clear();
        btnCancelarEdicao.Style.Clear();

        CarregaTipAluno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //CONFIRMAR EDIÇÃO
    protected void btnConfirmarEdicao_Click(object sender, EventArgs e)
    {
        CarregaTipAluno();
        int indice = Convert.ToInt32(listaGrupos.SelectedValue); //PEGA O INDICE DO GRUPO QUE IRÁ SER EDITADO 

        string listItem = "";
        string listItemCod = "";

        foreach (ListItem item in listaAlunosGrupo.Items) //GUARDA OS ALUNOS DE UM GRUPO EM UM PI
        {
            listItem += item.Text + "|";
            listItemCod += item.Value + "|";
        }

        //RECOLOCANDO OS VALORES EM SEUS DEVIDOS INDICES 	
        ViewState["Alunos" + indice.ToString()] = listItem;
        ViewState["CodAlunos" + indice.ToString()] = listItemCod;
        ViewState["NomeGrupo" + indice.ToString()] = txtNomeGrupo.Text;
        listaGrupos.SelectedItem.Text = "Grupo: " + txtNomeGrupo.Text;

        listaAlunosGrupo.Items.Clear();
        listaGrupos.SelectedIndex = -1;
        txtNomeGrupo.Text = "";

        // ** CASO VENHA A CANCELAR OU EXCLUIR, IRÁ RETORNAR AO ESTADO ANTERIOR
        string listItemGeral = "";
        string listItemCodGeral = "";
        foreach (ListItem item in listaAlunoGeral.Items)
        {
            listItemGeral += item.Text + "|"; //ATRIBUINDO TODOS OS ALUNOS DA LISTA ALUNO GERAL
            listItemCodGeral += item.Value + "|";
        }
        Session["alunosGerais"] = listItemGeral; // ** CASO CANCELAR OU EXCLUIR
        Session["CodAlunosGerais"] = listItemCodGeral;

        btnConfirmarEdicao.Enabled = false;
        btnExcluirGrupo.Enabled = false;
        btnCancelarEdicao.Enabled = false;
        btnConfirmarGrupo.Enabled = true;
        listaGrupos.Enabled = true;
        btnConfirmarGrupo.Style.Clear();

        btnConfirmarEdicao.Style.Add("opacity", "0.4");
        btnExcluirGrupo.Style.Add("opacity", "0.4");
        btnCancelarEdicao.Style.Add("opacity", "0.4");
        btnConfirmarEdicao.Style.Add("pointer-events", "none");
        btnCancelarEdicao.Style.Add("pointer-events", "none");
        btnExcluirGrupo.Style.Add("pointer-events", "none");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //EXCLUIR
    protected void btnExcluirGrupo_Click(object sender, EventArgs e)
    {
        int indice = Convert.ToInt32(listaGrupos.SelectedIndex); //INDICE QUE CLICOU
        int indice2 = Convert.ToInt32(listaGrupos.SelectedValue); //INDICE DO VIEWSTATE

        listaAlunoGeral.Items.Clear();

        string listItem = ViewState["Alunos" + indice2.ToString()].ToString(); //TODOS ALUNOS DESSE GRUPO
        string[] arrayAlunos = listItem.Split('|');
        string listItemValue = ViewState["CodAlunos" + indice2.ToString()].ToString();
        string[] arrayCodAlunos = listItemValue.Split('|');

        //RETORNANDO OS ALUNOS QUE NÃO TINHAM UM GRUPO PARA A LISTBOX DE ALUNOS GERAIS
        string listItem2 = Session["alunosGerais"].ToString(); //PARA RETORNAR AO ESTADO ORIGINAL
        string[] arrayAlunosGerais = listItem2.Split('|');
        string listItemCodGeral = Session["CodAlunosGerais"].ToString(); //PARA RETORNAR AO ESTADO ORIGINAL
        string[] arrayCodAlunosGerais = listItemCodGeral.Split('|');

        //COLOCANDO DE VOLTA OS VALORES NO LISTA DE ALUNO GERAL
        for (int i = 0; i < arrayAlunosGerais.Length - 1; i++)
        {
            listaAlunoGeral.Items.Add(new ListItem(arrayAlunosGerais[i], arrayCodAlunosGerais[i]));
        }

        //RETORNANDO OS ALUNOS QUE TINHAM UM GRUPO PARA A LISTBOX DE ALUNOS GERAIS
        for (int i = 0; i < arrayAlunos.Length - 1; i++)
        {
            listaAlunoGeral.Items.Add(new ListItem(arrayAlunos[i], arrayCodAlunos[i]));
        }

        ViewState["Alunos" + indice2.ToString()] = null;
        ViewState["CodAlunos" + indice2.ToString()] = null;
        ViewState["NomeGrupo" + indice2.ToString()] = null;

        txtNomeGrupo.Text = null;
        listaGrupos.Items.RemoveAt(indice);
        listaAlunosGrupo.Items.Clear();

        // ** CASO VENHA A CANCELAR, IRÁ RETORNAR AO ESTADO ANTERIOR
        string listItemGeral = "";
        string listItemCodigoGeral = "";
        foreach (ListItem item in listaAlunoGeral.Items)
        {
            listItemGeral += item.Text + "|"; //ATRIBUINDO TODOS OS ALUNOS DA LISTA ALUNO GERAL
            listItemCodigoGeral += item.Value + "|";
        }
        Session["alunosGerais"] = listItemGeral; // ** CASO CANCELAR
        Session["CodAlunosGerais"] = listItemCodigoGeral;

        btnConfirmarEdicao.Enabled = false;
        btnExcluirGrupo.Enabled = false;
        btnCancelarEdicao.Enabled = false;
        btnConfirmarGrupo.Enabled = true;
        listaGrupos.Enabled = true;

        btnConfirmarGrupo.Style.Clear();
        btnConfirmarEdicao.Style.Add("opacity", "0.4");
        btnExcluirGrupo.Style.Add("opacity", "0.4");
        btnCancelarEdicao.Style.Add("opacity", "0.4");
        btnConfirmarEdicao.Style.Add("pointer-events", "none");
        btnCancelarEdicao.Style.Add("pointer-events", "none");
        btnExcluirGrupo.Style.Add("pointer-events", "none");
        CarregaTipAluno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //CANCELAR
    protected void btnCancelarEdicao_Click(object sender, EventArgs e)
    {
        listaAlunosGrupo.Items.Clear();
        listaAlunoGeral.Items.Clear();

        string listItem = Session["alunosGerais"].ToString(); //PARA RETORNAR AO ESTADO ORIGINAL
        string[] arrayAlunosGerais = listItem.Split('|');

        string listItemCod = Session["CodAlunosGerais"].ToString(); //PARA RETORNAR AO ESTADO ORIGINAL
        string[] arrayCodAlunosGerais = listItemCod.Split('|');

        //COLOCANDO DE VOLTA OS VALORES NO LISTA DE ALUNO GERAL
        for (int i = 0; i < arrayAlunosGerais.Length - 1; i++)
        {
            listaAlunoGeral.Items.Add(new ListItem(arrayAlunosGerais[i], arrayCodAlunosGerais[i]));
        }

        txtNomeGrupo.Text = null;
        listaGrupos.SelectedIndex = -1;

        // ** CASO VENHA A CANCELAR, IRÁ RETORNAR AO ESTADO ANTERIOR
        string listItemGeral = "";
        string listItemCodGeral = "";

        foreach (ListItem item in listaAlunoGeral.Items)
        {
            listItemGeral += item.Text + "|"; //ATRIBUINDO TODOS OS ALUNOS DA LISTA ALUNO GERAL
            listItemCodGeral += item.Value + "|";
        }
        Session["alunosGerais"] = listItemGeral; // ** CASO CANCELAR
        Session["CodAlunosGerais"] = listItemCodGeral;


        btnConfirmarEdicao.Enabled = false;
        btnExcluirGrupo.Enabled = false;
        btnCancelarEdicao.Enabled = false;
        btnConfirmarGrupo.Enabled = true;
        listaGrupos.Enabled = true;

        btnConfirmarEdicao.Style.Add("opacity", "0.4");
        btnExcluirGrupo.Style.Add("opacity", "0.4");
        btnCancelarEdicao.Style.Add("opacity", "0.4");
        btnConfirmarEdicao.Style.Add("pointer-events", "none");

        btnCancelarEdicao.Style.Add("pointer-events", "none");
        btnExcluirGrupo.Style.Add("pointer-events", "none");
        btnConfirmarGrupo.Style.Clear();
        CarregaTipAluno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    protected void btnFinalizarCriarPi_Click(object sender, EventArgs e)
    {
        //INSERINDO NA TABELA PROJETO_INTER
        Projeto_Inter pi = new Projeto_Inter();
        pi.Pri_codigo = Convert.ToInt32(lblCodigoPiAut.Text);
        pi.Pri_semestre = Convert.ToInt32(Session["semestre"]);
        Semestre_Ano san = new Semestre_Ano();
        san = Semestre_Ano_DB.Select();
        pi.San_codigo = san;
        Projeto_Inter_DB.Insert(pi);

        string sqlInsertEventos = "";
        //INSERINDO NA TABELA EVENTOS
        if (desc[0] != "")
        {
            for (int i = 0; i < desc.Length; i++)
            {
                Eventos eve = new Eventos();
                eve.Pri_codigo = pi;
                eve.Eve_tipo = desc[i];
                eve.Eve_usuario = Session["nome"].ToString();
                sqlInsertEventos += "(0," + eve.Pri_codigo.Pri_codigo + ",'" + dat[i] + "','" + eve.Eve_tipo + "','"+eve.Eve_usuario+"'),";
               
            }
            
            Eventos_DB.Insert(sqlInsertEventos.Substring(0,sqlInsertEventos.Length-1));
        }

        //INSERINDO NA TABELA ATRIBUICAO_PI

        int[] atrDisciplina = listAtrDisciplinas.ToArray();
        int[] codDisciplina = listCodDisciplinas.ToArray();
        string sqlInsertAtribuicaoPI = "";
        for (int i = 0; i < atrDisciplina.Length; i++)
        {
            Atribuicao_PI atr = new Atribuicao_PI();
            atr.Adi_codigo = atrDisciplina[i];
            atr.Pri_codigo = pi;
            atr.Dis_codigo = codDisciplina[i];
            sqlInsertAtribuicaoPI += "("+atr.Pri_codigo.Pri_codigo+","+atr.Adi_codigo+","+atr.Dis_codigo+"),";
        }
        Atribuicao_PI_DB.Insert(sqlInsertAtribuicaoPI.Substring(0,sqlInsertAtribuicaoPI.Length-1));

            
        //INSERINDO NA TABELA CRITERIO_PI
        string sqlInsertCriterioPI = "";
        int indiceCrit = 0;
        foreach(ListItem li in listaCritPi.Items){            
            TextBox txtPeso = (TextBox) PanelCriterios.FindControl("txtCriterio"+(indiceCrit));
            for (int i = 0; i < atrDisciplina.Length; i++)
            {
                Criterio_PI critPi = new Criterio_PI();
                Criterios_Gerais crit = new Criterios_Gerais();
                Atribuicao_PI atr = new Atribuicao_PI();
                atr.Adi_codigo = atrDisciplina[i];
                crit.Cge_codigo = Convert.ToInt32(li.Value);
                critPi.Cge_codigo = crit;
                critPi.Adi_codigo = atr;
                critPi.Pri_codigo = pi;
                critPi.Cpi_peso = Convert.ToInt32(txtPeso.Text);
                critPi.Cpi_usuario = Session["nome"].ToString();
                sqlInsertCriterioPI += "(0," + critPi.Cge_codigo.Cge_codigo + "," + critPi.Pri_codigo.Pri_codigo + "," + critPi.Adi_codigo.Adi_codigo + "," + critPi.Cpi_peso + ",'" + critPi.Cpi_usuario + "'),";
            }
            indiceCrit++;
        }
        Criterio_PI_DB.Insert(sqlInsertCriterioPI.Substring(0, sqlInsertCriterioPI.Length - 1));

        //INSERINDO NA TABELA GRUPO
        int ultCodGrupo = Grupo_DB.SelectUltimoCod();
        if (ultCodGrupo == -2)
        {
            ultCodGrupo = 1;
        }
        else
        {
            ultCodGrupo++;
        }
        string sqlInsertGrupo = "";
        string sqlInsertGrupoAluno = "";
        for (int i = 1; i < index; i++)
        {
            if (ViewState["NomeGrupo" + i.ToString()] != null)
            {
                string nomeGrupo = ViewState["NomeGrupo" + i.ToString()].ToString();       
                Grupo gru = new Grupo();
                gru.Gru_codigo = ultCodGrupo;
                gru.Gru_nome_projeto = nomeGrupo;
                gru.Pri_codigo = pi;
                gru.Gru_usuario = Session["nome"].ToString();
                sqlInsertGrupo += "(" + gru.Gru_codigo + "," + gru.Pri_codigo.Pri_codigo + ",'" + gru.Gru_nome_projeto + "',null,0,'" + gru.Gru_usuario + "'),";
                
                Grupo_Aluno gal = new Grupo_Aluno();
                gal.Gru_codigo = gru;
                gal.Gal_usuario = Session["nome"].ToString();

                string[] codAlunos = ViewState["CodAlunos"+i.ToString()].ToString().Split('|');
                for (int j = 0; j < codAlunos.Length-1; j++)
                {
                    if (codAlunos[j] != null)
                    {
                        gal.Alu_matricula = codAlunos[j];
                        sqlInsertGrupoAluno += "('" + gal.Alu_matricula + "'," + gal.Gru_codigo.Gru_codigo + ",'" + gal.Gal_usuario + "'),";
                    }
                }
            }
            ultCodGrupo++;
        }
        Grupo_DB.Insert(sqlInsertGrupo.Substring(0, sqlInsertGrupo.Length - 1));
        Grupo_Aluno_DB.Insert(sqlInsertGrupoAluno.Substring(0, sqlInsertGrupoAluno.Length - 1));

        Session["codPIAtivo"] = Funcoes.SelectCodPIAtivoByAtr(Convert.ToInt32(Session["codAtr"]));
        DataSet dsGruposAvaliar = new DataSet();
        dsGruposAvaliar = Grupo_DB.SelectAllGruposAvaliar(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));
        Session["GruposAvaliar"] = dsGruposAvaliar;

       ScriptManager.RegisterStartupScript(this, this.GetType(), "myModalPiCadastrado", "msgFinalizarCadastroPi();", true);
    }



}