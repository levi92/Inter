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
        ScriptManager1.RegisterAsyncPostBackControl(lkbBuscar);
        if (!IsPostBack)
        {
            CarregaGridEx();
            CarregaGrid();
            DataSet dsSem = Semestre_Ano_DB.SelectSemestreAno();

            ddlSemestreAno.DataSource = dsSem;
            ddlSemestreAno.DataTextField = "concat(SAN_ANO,'-',SAN_SEMESTRE)";
            ddlSemestreAno.DataValueField = "SAN_CODIGO";
            ddlSemestreAno.DataBind();
            ddlSemestreAno.Items.Insert(0, new ListItem("Selecione", "0"));

            ddlStatus.Items.Insert(0, new ListItem("Selecione", "0"));
            ddlStatus.Items.Insert(1, new ListItem("Finalizado", "1"));
            ddlStatus.Items.Insert(2, new ListItem("Em andamento", "2"));
            //ddlStatus.Items.Insert(3, new ListItem("Solicitado", "3"));

            DataSet dsPIsFatec = (DataSet)Session["DS_AllPIsbyCalendarioAtual"];
            int qtdPIs = dsPIsFatec.Tables[0].Rows.Count; //pega a quantidade total de linhas na tabela do dataset e armazena na variável qtdPIs
            string[] cursos = new string[0]; //instancia um novo array cursos com tamanho indefinido
            cursos = Funcoes.tratarDadosCursosComPI(dsPIsFatec, qtdPIs); //usa um método para tratar o nome dos cursos e trazer somente um de cada
            ddlCurso.DataSource = cursos;
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, new ListItem("Selecione", "0"));
        }
    }

    private void CarregaGridEx()
    {
        Calendario cal = Calendario.SelectbyAtual();
        DataSet dsPIsFatec = Professor.SelectAllPIsbyCalendario(cal.Codigo, cal.AnoSemestreAtual);
        gdvExemplo.DataSource = dsPIsFatec.Tables[0].DefaultView;
        gdvExemplo.DataBind();
        

    }
    private void CarregaGrid()
    {
        DataSet dsPIsFatec = (DataSet)Session["DS_AllPIsbyCalendarioAtual"]; //instancia um dataset usando um dataset existente em uma varíavel de sessão(que é instanciada no login como null)
        if (Session["DS_AllPIsbyCalendarioAtual"] == null) //se a variável de sessão estiver null(sem dataset nenhum), irá colocar um dataset dentro da varíavel de sessão
        {
            Calendario cal = Calendario.SelectbyAtual();
            dsPIsFatec = Professor.SelectAllPIsbyCalendario(cal.Codigo, cal.AnoSemestreAtual);
            Session["DS_AllPIsbyCalendarioAtual"] = dsPIsFatec;

        }

        DataSet ds = Funcoes_DB.SelectAllPIs();

        int qtd = ds.Tables[0].Rows.Count;


        if (qtd > 0)
        {
            gdvProjetos.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvProjetos.DataBind(); //preenche o grid view com os dados

            foreach (GridViewRow linha in gdvProjetos.Rows)//percorre cada linha da grid (obs: isso existe pelo campo de nome estar em outra tabela no BD da Fatec)
            {
                //Professor prof = new Professor(); //instancia um novo professor
                Label lblStatus = (Label)linha.FindControl("lblStatus");//acha o label de matrícula da grid e liga a outro label

                bool valor = false;

                if (lblStatus.Text == "False") //verifica se o valor da coluna GRU_FINALIZADO é "false"
                {
                    lblStatus.Text = "Em andamento"; //se for, troca o "false" por "em andamento"
                }
                else
                {
                    lblStatus.Text = "Finalizado"; //se não for "false", troca por "finalizado"
                }

                if (lblStatus.Text == "Em andamento")
                {
                    valor = true;
                }
                if (valor == true)
                {
                    LinkButton botao = (LinkButton)linha.FindControl("lkbHabilitar");
                    botao.Visible = false;
                }

            }
        }

    }


    public void CarregaPesquisaAvançada()
    {
        string pesquisa;

        pesquisa = txtPesquisa.Text;

        if (pesquisa == "")
        {
            gdvProjetos.Visible = false;
            lblQtdRegistro.Text = "Preencha o campo pesquisa avançada!";
        }
        else
        {
            DataSet dsPesquisa = Funcoes_DB.SelectFiltroPI(pesquisa);

            int qtd = dsPesquisa.Tables[0].Rows.Count;
            if (qtd > 0)
            {
                gdvProjetos.Visible = true;
                gdvProjetos.DataSource = dsPesquisa.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvProjetos.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";

                foreach (GridViewRow linha in gdvProjetos.Rows)//percorre cada linha da grid (obs: isso existe pelo campo de nome estar em outra tabela no BD da Fatec)
                {
                    Professor prof = new Professor(); //instancia um novo professor
                    Label lblNome = (Label)linha.FindControl("lblNome");//acha o label de matrícula da grid e liga a outro label
                    Label lblAno = (Label)linha.FindControl("lblAno"); //acha o label de Nome e liga a outro label
                    Label lblStatus = (Label)linha.FindControl("lblStatus");

                    /*if (lblStatus.Text == "True")
                    {
                        lblStatus.Text = "Finalizado";
                    }
                    else
                    {
                        lblStatus.Text = "Em andamento";
                    }*/
                    /*prof = Professor.SelectByCodigo(lblMatricula.Text); //o número de matrícula do label é usado para preencher o objeto professor usando o método de selecionar por código
                    lblNome.Text = prof.Nome; //o label NomeAdmin da grid é preenchido utilizando o nome que está no objeto do professor (método get encapsulado)
                    */
                }
            }
            else
            {
                gdvProjetos.Visible = false;
                lblQtdRegistro.Text = "Nenhum Registro foi encontrado";
            }
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
            e.Row.Cells[2].Text = vetorReturnFunction[0]; //pega o nome do curso e coloca na célula da coluna correspondente ao curso daquela linha

            i++;

        }
        LinkButton hab = (LinkButton)e.Row.FindControl("lkbHabilitar"); //acha o botão download e coloca no controle lb
        if (hab != null)
        {
            ScriptManager1.RegisterPostBackControl(hab); //usando o ScriptManager, registra todos os botões de download para fazer postback (o padrão é PostBack parcial por causa do UpdatePanel, o que não deixava fazer o download!)
        }

        LinkButton grupo = (LinkButton)e.Row.FindControl("lblNome"); //acha o botão download e coloca no controle lb
        if (grupo != null)
        {
            ScriptManager1.RegisterPostBackControl(grupo); //usando o ScriptManager, registra todos os botões de download para fazer postback (o padrão é PostBack parcial por causa do UpdatePanel, o que não deixava fazer o download!)
        }

    }

    protected void gdvProjetos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvProjetos.PageIndex = e.NewPageIndex;

        if (txtPesquisa.Text == "")
        {
            CarregaPesquisaAvançada();
            UpdatePanelAtivados.Update();
        }
        else
        {
            CarregaGrid();
        }

    }

    protected void gdvProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "verDetalhes")
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string cod_grupo = gdvProjetos.Rows[gvr.RowIndex].Cells[0].Text; //pega o codigo do grupo daquela linha do gridview
            int codigo_grupo = Convert.ToInt32(e.CommandArgument);
            Session["linha"] = gvr.RowIndex;

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



    protected void lblNome_Command(object sender, CommandEventArgs e)
    {
        int linha = Convert.ToInt32(Session["linha"]);
        int gru_codigo = Convert.ToInt32(e.CommandArgument);
        Grupo gru = Grupo_DB.Select(gru_codigo);
        string[] disciplina = new string[0];
        string[] aluno = new string[0];

        lblNomeGrupo.Text = gru.Gru_nome_projeto;
        /*lblCursoModal.Text =;
        lblSemestre.Text=;*/

        DataSet ds = (DataSet)Session["DS_AllPIsbyCalendarioAtual"];
        string[] vetorReturnFunction = new string[3];

        vetorReturnFunction = Funcoes.tratarDadosProfessor(ds.Tables[0].Rows[linha]["disciplina"].ToString()); //pega o dado da linha [i] da coluna "disciplina" e joga dentro do método tratarDados
        lblCursoModal.Text = vetorReturnFunction[0]; //pega o nome do curso e coloca na célula da coluna correspondente ao curso daquela linha
        lblSemestre.Text = vetorReturnFunction[1] + "º Semestre";

        int qtdPIs = ds.Tables[0].Rows.Count; //pega a quantidade total de linhas na tabela do dataset e armazena na variável qtdPIs
        //instancia um novo array cursos com tamanho indefinido
        disciplina = Funcoes.tratarDadosCursosComPI(ds, qtdPIs); //usa um método para tratar o nome dos cursos e trazer somente um de cada
        //aluno = Funcoes.NomeAlunosByMatricula();
        for (int i = 0; i < qtdPIs; i++)
        {
            lstDisciplinas.DataSource = disciplina;
            lstDisciplinas.DataBind();
        }
    }

    protected void gdvProjetos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        /*Label lblCodigo = (Label)gdvProjetos.Rows[e.RowIndex].FindControl("lblCodigo");
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
        }*/
    }

    protected void gdvProjetos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        /*Label lblCodigo = (Label)gdvProjetos.Rows[e.RowIndex].FindControl("lblCodigo");
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
        }*/
    }




}