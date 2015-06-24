using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Interdisciplinar;
using Inter.Funcoes;
using AppCode.Persistencia;

public partial class paginas_Admin_projetos : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["login"] == null)
        {
            Response.Redirect("~/BloqueioUrlx");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager1.RegisterAsyncPostBackControl(lkbBuscar); // Da um postback asyc ao clicar no botao pesquisar para nao atualizar a pagina inteira
        if (!IsPostBack) //Se nao for postback, ou seja, se estiver carregando a pagina pela primeira vez
        {
            CarregaGrid(); //chama o método carregaGrid();

            DataSet dsSem = Semestre_Ano_DB.SelectSemestreAno(); //preenche o dataset com o retorno do método pegando todos semestre ano
            DataSet dsPIsFatec = Curso.SelecionarTodos(); //preenche o dataset com o retorno do método pegando todos os cursos que vem do banco da FATEC

            //preenche a dropdown curso com o dataset criado anteriormente dsPIsFatec
            ddlCurso.DataSource = dsPIsFatec.Tables[0];
            ddlCurso.DataTextField = "Sigla";
            ddlCurso.DataValueField = "Codigo";
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, new ListItem("Selecione", "0"));

            //preenche a dropdown semestre/ano com o dataset criado anteriormente dsSem
            ddlSemestreAno.DataSource = dsSem;
            ddlSemestreAno.DataTextField = "concat(SAN_ANO,'-',SAN_SEMESTRE)";
            ddlSemestreAno.DataValueField = "SAN_CODIGO";
            ddlSemestreAno.DataBind();
            ddlSemestreAno.Items.Insert(0, new ListItem("Selecione", "0"));

            //preenche a dropdown status manualmente por serem valores fixos
            ddlStatus.Items.Insert(0, new ListItem("Selecione", "0"));
            ddlStatus.Items.Insert(1, new ListItem("Finalizado", "1"));
            ddlStatus.Items.Insert(2, new ListItem("Em andamento", "2"));
        }
    }

    private void CarregaGrid() //Carrega grid com todos os PIs
    {
        DataSet ds = Funcoes_DB.SelectAllPIs(); //dataset que recebe todos os PIs através desse método

        int qtd = ds.Tables[0].Rows.Count; //conta quantas linhas retornou o dataset

        if (qtd > 0) //se a quantidade de linhas retornadas pelo dataset for > 0 vai preencher a grid
        {
            gdvProjetos.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvProjetos.DataBind(); //preenche o grid view com os dados

            //percorre cada linha da grid que vai servir para substituir o nome dos status e curso para melhor visualização 
            foreach (GridViewRow linha in gdvProjetos.Rows)
            {
                Label lblStatus = (Label)linha.FindControl("lblStatus");//acha o label status da grid e liga a outro label
                Label lblSemestreCurso = (Label)linha.FindControl("lblSemestreCurso");//acha o label semestre da grid e liga a outro label

                lblSemestreCurso.Text = lblSemestreCurso.Text + "º Semestre"; //acrestenta na label Curso ºSemestre

                bool valor = false; //variavel criada para verificar se o status do PI esta em andamento ou finalizado e habilitar o linkbutton

                if (lblStatus.Text == "False") //verifica se o status na grid está retornando false
                {
                    lblStatus.Text = "Em andamento"; //se for, troca o "false" por "em andamento"
                }
                else //senao estiver retornando false, ou seja, true
                {
                    lblStatus.Text = "Finalizado"; //se não for "false", troca por "finalizado"
                }

                if (lblStatus.Text == "Em andamento")// verifica se o status do PI está em andamento
                {
                    valor = true; //se sim a variavel recebe true
                }
                if (valor == true) //se o PI estiver em andamento o botao habilitar pra edição fica invisivel
                {
                    LinkButton botao = (LinkButton)linha.FindControl("lkbHabilitar");//acha o label semestre da grid e liga a outro label
                    botao.Visible = false; //deixa o botao invisivel
                }

            }
        }
    }


    public void CarregaPesquisaAvançada() //Carrega a grid com todos os PIs relacionados a pesquisa
    {
        string pesquisa; //cria uma variavel para receber o valor digitado no campo pesquisa
        pesquisa = txtPesquisa.Text; //recebe o valor digitado no campo pesquisa 

        if (pesquisa == "") //se o campo pesquisa estiver vazio
        {
            gdvProjetos.Visible = false; //grid fica invisivel
            lblQtdRegistro.Text = "Preencha o campo pesquisa avançada!"; //exibe uma mensagem para que ele preencha o campo pesquisa
        }
        else //se o campo pesquisa nao estiver vazio
        {
            DataSet dsPesquisa = Funcoes_DB.SelectFiltroPI(pesquisa); //dataset recebe o retorno do método que faz a pesquisa pelo filtro q o usuario digitou

            int qtd = dsPesquisa.Tables[0].Rows.Count;// conta quantas linhas o dataset retornou
            if (qtd > 0)// verifica se a quantidade de linhas form maior que 0
            {
                gdvProjetos.Visible = true; //a grid fica visivel
                gdvProjetos.DataSource = dsPesquisa.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvProjetos.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros"; //exibe mensagem de quantos registros foram retornados

                foreach (GridViewRow linha in gdvProjetos.Rows)//percorre cada linha da grid 
                {
                    Label lblStatus = (Label)linha.FindControl("lblStatus"); //acha o label de Nome e liga a outro label
                    Label lblSemestreCurso = (Label)linha.FindControl("lblSemestreCurso"); //acha o label de Nome e liga a outro label

                    lblSemestreCurso.Text = lblSemestreCurso.Text + "º Semestre"; //acrestenta na label Curso ºSemestre

                    bool valor = false; //variavel criada para verificar se o status do PI esta em andamento ou finalizado e habilitar o linkbutton

                    if (lblStatus.Text == "False") //verifica se o status na grid está retornando false
                    {
                        lblStatus.Text = "Em andamento"; //se for, troca o "false" por "em andamento"
                    }
                    else //senao estiver retornando false, ou seja, true
                    {
                        lblStatus.Text = "Finalizado"; //se não for "false", troca por "finalizado"
                    }

                    if (lblStatus.Text == "Em andamento")// verifica se o status do PI está em andamento
                    {
                        valor = true; //se sim a variavel recebe true
                    }
                    if (valor == true) //se o PI estiver em andamento o botao habilitar pra edição fica invisivel
                    {
                        LinkButton botao = (LinkButton)linha.FindControl("lkbHabilitar");//acha o label semestre da grid e liga a outro label
                        botao.Visible = false; //deixa o botao invisivel
                    }
                }
            }
            else
            {
                gdvProjetos.Visible = false; //grid fica invisivel, pois o dataset nao retronou dados
                lblQtdRegistro.Text = "Nenhum Registro foi encontrado"; //informa ao usuario que nao foi encontrado nenhum registro
            }
        }
    }
    int i;
    protected void gdvProjetos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton hab = (LinkButton)e.Row.FindControl("lkbHabilitar"); //acha o linkbutton habilitar e coloca no controle lb
        if (hab != null)
        {
            ScriptManager1.RegisterPostBackControl(hab); //usando o ScriptManager, registra todos os botões habilitar para fazer postback)
        }

        LinkButton grupo = (LinkButton)e.Row.FindControl("lblNome"); //acha o botão download e coloca no controle lb
        if (grupo != null)
        {
            ScriptManager1.RegisterPostBackControl(grupo); //usando o ScriptManager, registra todos os linkbutton de ver detalhes para fazer postback)
        }
    }

    protected void gdvProjetos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvProjetos.PageIndex = e.NewPageIndex;

        /*if (txtPesquisa.Text == "")
        {
            CarregaPesquisaAvançada();
            UpdatePanelAtivados.Update();
        }
        else
        {
            CarregaGrid();
        }*/
    }

    protected void gdvProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "verDetalhes")
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
           
            Label lblCodigoGrupo = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblCodigo");
            int gru_codigo = Convert.ToInt32(lblCodigoGrupo.Text);

            LinkButton lblNome = (LinkButton)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblNome");
            string gru_nome = lblNome.Text;
            //Grupo gru = Grupo_DB.Select(gru_codigo);

            Label lblCodigoPI = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblCodigoPI");
            int CodigoPI = Convert.ToInt32(lblCodigoPI.Text);

            Label lblCurso = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblCurso");
            string nome_curso = lblCurso.Text;

            Label lblSemestreCurso = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblSemestreCurso");
            string semestre_curso = lblSemestreCurso.Text;

            Label lblStatus = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblStatus");
            string status = lblStatus.Text;

            lblNomeGrupoModal.Text = gru_nome;
            lblCursoModal.Text = nome_curso; //pega o nome do curso e coloca na célula da coluna correspondente ao curso daquela linha
            lblSemestreModal.Text = semestre_curso;
            lblStatusModal.Text = status;
            
            
            /*DataSet cod_disciplina = Atribuicao_PI_DB.SelectDisciplinaByCod(CodigoPI);

            string[] matriculas_alunos = Grupo_Aluno_DB.SelectAllMatriculaByGrupo(gru_codigo);
            string[] nome_alunos = Funcoes.NomeAlunosByMatricula(matriculas_alunos);
            string[] nome_disciplina = Funcoes.DisciplinasByCodigo(cod_disciplina);
            string[] aluno = new string[0];
            string[] professor = new string[0];

            lblNomeGrupoModal.Text = gru_nome;

            DataSet ds = (DataSet)Session["DS_AllPIsbyCalendarioAtual"];
            string[] vetorReturnFunction = new string[3];
            vetorReturnFunction = Funcoes.tratarDadosProfessor(ds.Tables[0].Rows[gvr.RowIndex]["disciplina"].ToString()); //pega o dado da linha [i] da coluna "disciplina" e joga dentro do método tratarDados
            


            int qtdPIs = ds.Tables[0].Rows.Count; //pega a quantidade total de linhas na tabela do dataset e armazena na variável qtdPIs
            string[] cursos = new string[0]; //instancia um novo array cursos com tamanho indefinido
            cursos = Funcoes.tratarDadosCursosComPI(ds, qtdPIs);

            //instancia um novo array cursos com tamanho indefinido
            //disciplina = Funcoes.tratarDadosCursosComPI(ds, qtdPIs); //usa um método para tratar o nome dos cursos e trazer somente um de cada
            //professor = Funcoes.tratarDadosNomeProfessores(ds, qtdPIs);
            //aluno = Funcoes.NomeAlunosByMatricula();
            for (int i = 0; i < matriculas_alunos.Length; i++)
            {
                lstAlunos.DataSource = nome_alunos;
                lstAlunos.DataBind();
                lstDisciplinas.DataSource = disciplina;
                lstDisciplinas.DataBind();

                lstProfessores.DataSource = professor;
                lstProfessores.DataBind();
            }

            for (int i = 0; i < nome_disciplina.Length; i++)
            {
                lstDisciplinas.DataSource = nome_disciplina;
                lstDisciplinas.DataBind();
                lstDisciplinas.DataSource = disciplina;
                lstDisciplinas.DataBind();

                lstProfessores.DataSource = professor;
                lstProfessores.DataBind();
            }*/
            UpdatePanelModalNovoCriterio.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        if (e.CommandName == "projHabilitar")
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            Label lblCodigo = (Label)gdvProjetos.Rows[gvr.RowIndex].FindControl("lblCodigo");

            //string lblCodigo = gdvProjetos.Rows[gvr.RowIndex].Cells[0].Text;
            int cod = Convert.ToInt32(lblCodigo.Text);

            if (Grupo_DB.Update(cod) == 0)
            {
                CarregaGrid();
                UpdatePanelAtivados.Update();
                lblMsg.Text = "Projeto habilitado com Sucesso!";
            }
            else
            {
                CarregaGrid();
                UpdatePanelAtivados.Update();
                lblMsg.Text = "Erro ao habilitar projeto!";
            }

        }
    }

    protected void lkbBuscar_Click(object sender, EventArgs e)
    {

        CarregaPesquisaAvançada();
        UpdatePanelAtivados.Update();


    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlSemestreAno_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancelarNovoCriterio_Click(object sender, EventArgs e)
    {

    }

    protected void btnCriarNovoCriterio_Click(object sender, EventArgs e)
    {

    }
}