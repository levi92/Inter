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
//using System.Runtime.Serialization.Json;


public partial class paginas_Usuario_cadastrarPi : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }
        // CHAMAR A MASTER PAGE - OBS: MASTERPAGEFILE É O CAMINHO DO ARQUIVO MASTERPAGE QUE VOCÊ DESEJA CHAMAR        
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

        if (Session["mae"] == "False")
        {
            Response.Redirect("home.aspx");
        }     


        //SE NÃO FOR POSTBACK VAI CARREGAR OS MÉTODOS ABAIXO DESCRITOS
        if (!IsPostBack)
        {
            CarregaCriGerais();
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

        PanelCriterios.Controls.Clear();
        updPanelPeso.Update();
        CriarCriterio();
        updPanelPeso.Update();

    }

    // ******************  ETAPA 1 - CADASTRO PI, CADASTRO DE DATAS ******************
    // *******************************************************************************
    private void PegarUltimoCodPI()
    {
        // PEGAR ULTIMO CODIGO DE PI E ACRESCENTAR 1
        int cod = Projeto_Inter_DB.SelectUltimoCod();
        int codMais = cod + 1;
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

    [System.Web.Services.WebMethod]
    public static string GetEventos(string dadosEventos)
    {

        string[] eventos = dadosEventos.Split('|'); //divide quando achar o pipe('|') 

        List<string> descricao = new List<string>(); //cria uma List, porque não tem um tamanho definido
        List<string> data = new List<string>();


        for (int i = 0; i < eventos.Length - 1; i++)
        {
            if (i % 2 == 0) //se for par
            {
                descricao.Add(eventos[i]);
            }
            else //se for impar
            {
                data.Add(eventos[i]);
            }

        }

        string[] desc = descricao.ToArray(); //toArray converte a List em Array
        string[] dat = data.ToArray();


        for (int i = 0; i < desc.Length; i++)
        {
            //Response.Write(desc[i] + " - " + dat[i] + "<br/>");
        }

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
                }
            }

        }
    }

    public static List<string> liCritTip = new List<string>();
    public static List<string> liCritCod = new List<string>();
    public static int UltCodCrit = 0;

    //MÉTODO PARA CARREGAR OS CRITÉRIOS GERAIS DO BANCO NO COMPONENTE LISTBOX
    private void CarregaCriGerais()
    {
        //DATASET VAI RECEBER TODOS OS CRITÉRIOS DO BANCO DE DADOS PELO SELECTALL
        DataSet ds = Criterios_Gerais_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;
        UltCodCrit = Criterios_Gerais_DB.SelectUltimoCod();
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

        if (!String.IsNullOrEmpty(txtNomeCriterio.Text) && !String.IsNullOrEmpty(txtDescricaoCriterio.Text))
        {
            //ADICIONA OS NOVOS CRITÉRIOS NAS LISTAS
            ListItem li = new ListItem();
            li.Value = (UltCodCrit + 1).ToString();
            li.Text = txtNomeCriterio.Text;
            li.Attributes.Add("title", txtDescricaoCriterio.Text);
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
        else if (String.IsNullOrEmpty(txtNomeCriterio.Text) && String.IsNullOrEmpty(txtDescricaoCriterio.Text))
        {
            lblMsgCriterio.Text = "<span class='glyphicon glyphicon-remove-circle'></span>&nbsp Campo obrigatório.";
            lblMsgCriterio.Style.Add("color", "red");

            txtNomeCriterio.Style.Add("border", "solid 1px red");
            txtDescricaoCriterio.Style.Add("border", "solid 1px red");
        }
        else if (String.IsNullOrEmpty(txtNomeCriterio.Text))
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
        if (verificarPesoVazio() == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
            //CHAMA A MODAL PESO VAZIO
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostraModalPesoUm", "MostraModalPesoUm();", true);
        }
        else if (verificarPesoVazio() == 2)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
        }
        else
        {
            lblMsgPesosCriterios.Visible = false;
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
    

    //EVENTO QUE MOVE OS ALUNOS DA LISTA GERAL PARA A LISTA ESPECÍFICA DE ALUNOS DAQUELE GRUPO 
    protected void listaAlunoGeral_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunosGrupo.Items.Add(listaAlunoGeral.SelectedItem);
        listaAlunoGeral.Items.RemoveAt(listaAlunoGeral.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }


    //EVENTO QUE MOVE OS ALUNOS DA LISTA ESPECÍFICA PARA A LISTA GERAL DE ALUNOS  
    protected void listaAlunosGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaAlunoGeral.Items.Add(listaAlunosGrupo.SelectedItem);
        listaAlunosGrupo.Items.RemoveAt(listaAlunosGrupo.SelectedIndex);
        listaAlunoGeral.ClearSelection();
        listaAlunosGrupo.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }  

    //EVENTO DO BOTÃO VOLTAR: REDIRECIONA PARA A ETAPA ANTERIOR
    protected void LkbVoltarEtapa3_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
    }

    //REDIRECIONA PARA A PÁGINA AVALIAR GRUPO
    protected void btnVoltarAvaliar_Click(object sender, EventArgs e)
    {
        Response.Redirect("avaliarGrupo.aspx");
    }

    //REDIRECIONA PARA A PÁGINA HOME
    protected void btnVoltarHome2_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    

    //EVENTO DO BOTÃO CONFIRMAR GRUPO: GUARDA O GRUPO ATUAL(COM OS ALUNOS QUE FORAM ESCOLHIDOS) E SUCESSIVAMENTE CRIA NOVO GRUPO
    public static int index = 1; //É UMA CONTROLADORA DO VIEWSTATE (EX: VIEWSTATE["ALUNOS1"]) OBS: PELO INDEX COMEÇAR NO VALOR "1" NÃO HAVERÁ "GRUPO0"
    protected void btnConfirmarGrupo_Click(object sender, EventArgs e)
    {
        if (! String.IsNullOrEmpty(txtNomeGrupo.Text))
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
            //"Clique para Editar o grupo" -> vamos inserir um texto de ajuda fixo na lateral!
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

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }

    //CONFIRMAR EDIÇÃO
    protected void btnConfirmarEdicao_Click(object sender, EventArgs e)
    {
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

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa4", "etapa4();", true);
    }














}