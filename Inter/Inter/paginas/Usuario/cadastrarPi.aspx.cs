using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using AppCode.Persistencia;

public partial class paginas_Usuario_cadastrarPi : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }
        // CHAMAR A MASTER PAGE  -      OBS: MASTERPAGEFILE É O CAMINHO DO ARQUIVO MASTERPAGE QUE VOCÊ DESEJA CHAMAR        
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //BLOQUEIO URL
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }
        //SE NÃO FOR POSTBACK VAI CARREGAR OS MÉTODOS ABAIXO DESCRITOS
        if (!IsPostBack)
        {
            CarregaCriGerais();
            PegarAnoeSemestreAno();
            PegarUltimoCodPI();
            lblCursoAut.Text = Session["curso"].ToString();
            lblSemestreAut.Text = Session["semestre"].ToString();
        }
        
    }

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


        //MÉTODO PARA CARREGAR OS CRITÉRIOS GERAIS DO BANCO NO COMPONENTE LISTBOX
    private void CarregaCriGerais()
    { 
        //DATASET VAI RECEBER TODOS OS CRITÉRIOS DO BANCO DE DADOS PELO SELECTALL
        DataSet ds = Criterios_Gerais_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;
        //SE HOUVER CRITÉRIOS 
        if (qtd > 0){
            //VAI RODAR TODAS AS LINHAS DO DATASET E JOGAR OS DADOS NA LISTBOX 
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //ADICIONANDO CÓDIGO E NOME DO CRITÉRIO AOS CRITÉRIOS ENCONTRADOS NO DATASET
                listaCritGeral.Items.Add(new ListItem(dr["cge_nome"].ToString(), dr["cge_codigo"].ToString()));                
            }
        }
    }

    //MÉTODO PARA CRIAR OS COMPONENTES LABELS E TEXTBOX PARA COLOCAR OS PESOS NOS CRITÉRIOS
    public void CriarCriterio(){
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

    //EVENTO DO BOTÃO CONTINUAR(ETAPA 3 CRITÉRIOS(PESOS)) : CRIA OS CRITÉRIOS, ATUALIZA O PAINEL E REDIRECIONA PARA PRÓXIMA ETAPA
    protected void btnContinuarEtapa3_Click(object sender, EventArgs e)
    {
        CriarCriterio();
        updPanelPeso.Update();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);
    }

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

    //EVENTO QUE MOVE OS CRITÉRIOS GERAIS PARA A LISTBOX DE CRITÉRIOS ESCOLHIDOS PARA O PI
    protected void listaCritGeral_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaCritPi.Items.Add(listaCritGeral.SelectedItem);
        listaCritGeral.Items.RemoveAt(listaCritGeral.SelectedIndex);
        listaCritGeral.ClearSelection();
        listaCritPi.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }

    //EVENTO QUE MOVE OS CRITÉRIOS ESCOLHIDOS PARA O PI PARA A LISTBOX DE CRITÉRIOS GERAIS
    protected void listaCritPi_SelectedIndexChanged(object sender, EventArgs e)
    {
        listaCritGeral.Items.Add(listaCritPi.SelectedItem);
        listaCritPi.Items.RemoveAt(listaCritPi.SelectedIndex);
        listaCritGeral.ClearSelection();
        listaCritPi.ClearSelection();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }

    //EVENTO DO BOTÃO VOLTAR: REDIRECIONA PARA A ETAPA ANTERIOR
    protected void LkbVoltarEtapa3_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa3", "etapa3();", true);        
    }

    //REDIRECIONA PARA A PÁGINA AVALIAR GRUPO
    protected void btnVoltarAvaliar_Click(object sender, EventArgs e){
        Response.Redirect("avaliarGrupo.aspx");
    }

    //REDIRECIONA PARA A PÁGINA HOME
    protected void btnVoltarHome2_Click(object sender, EventArgs e){
        Response.Redirect("home.aspx");
    }

    //EVENTO DO BOTÃO CRIAR NOVO CRITERIO: CRIA UM NOVO CRITÉRIO E MOVE PARA O LISTBOX CRITÉRIOS DO PI
    protected void btnCriarNovoCriterio_Click(object sender, EventArgs e)
    {
        //VALUE = -1
        listaCritPi.Items.Add(txtNomeCriterio.Text);  
        updPanelCriterio.Update();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEtapa2", "etapa2();", true);
    }





}