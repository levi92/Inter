using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using AppCode.Persistencia;
using System.Data;


public partial class paginas_Admin_auditoria : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Se sessão estiver nula redireciona para o bloqueio Url
            if (Session["login"] == null)
            {
                Response.Redirect("~/BloqueioUrl");
            }

            // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
            this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGridAuditoria();
                //UpdatePanelAuditoria.Update();

                ddlAcao.Items.Insert(0, new ListItem("Selecione", "SELECIONE"));
                ddlAcao.Items.Insert(1, new ListItem("Inserção", "INSERCAO"));
                ddlAcao.Items.Insert(2, new ListItem("Alteração", "ALTERACAO"));
                ddlAcao.Items.Insert(3, new ListItem("Exclusão", "EXCLUSAO"));

                ddlTabela.Items.Insert(0, new ListItem("Selecione", "SELECIONE"));
                ddlTabela.Items.Insert(1, new ListItem("Critérios Gerais", "CGE_CRITERIOS_GERAIS"));
                ddlTabela.Items.Insert(2, new ListItem("Criterios do PI", "CPI_CRITERIO_PI"));
                ddlTabela.Items.Insert(3, new ListItem("Eventos", "EVE_EVENTOS"));
                ddlTabela.Items.Insert(4, new ListItem("Alunos do grupo", "GAL_GRUPO_ALUNO"));
                ddlTabela.Items.Insert(5, new ListItem("Grupo", "GRU_GRUPO"));
                ddlTabela.Items.Insert(6, new ListItem("Histórico do Aluno", "HIS_HISTORICO_ALUNO_DISCIPLINA"));
                ddlTabela.Items.Insert(7, new ListItem("Mensagens", "MSG_MENSAGEM"));
                ddlTabela.Items.Insert(8, new ListItem("Coordenadores", "PER_PERFIL"));
                ddlTabela.Items.Insert(9, new ListItem("Requerimento", "REQ_REQUERIMENTO"));
            }

            ddlAcao.AutoPostBack = false;
            ddlTabela.AutoPostBack = false;

        }

        public void CarregarGridAuditoria()
        {
           gdvAud.Visible = true;
           DataSet ds = Auditoria_DB.SelectAll(); //criando um DataSet com todos registros de Auditoria
            
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvAud.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvAud.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
            }
            else
            {
                gdvAud.Visible = false;
                lblQtdRegistro.Text = "Nenhum registro foi encontrado";
            }

        }

        public void CarregaFiltro()
        {
            string usuario = txtUsuario.Text;
            string data = txtData.Text;
            string acao;
            string tabela;

            if (ddlAcao.SelectedValue == "SELECIONE")
            {
                acao = "";
            }
            else
            {
                acao = ddlAcao.SelectedValue.ToString();
            }

            if (ddlTabela.SelectedValue == "SELECIONE")
            {
                tabela = "";
            }
            else
            {
                tabela = ddlTabela.SelectedValue.ToString();
            }

            DataSet ds = Auditoria_DB.SelectFiltro(data, usuario, acao, tabela);

            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvAud.Visible = true;
                gdvAud.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvAud.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
            }
            else
            {
                gdvAud.Visible = false;
                lblQtdRegistro.Text = "Nenhum registro foi encontrado";
            }
        }

        protected void gdvAud_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gdvAud_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvAud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAud.PageIndex = e.NewPageIndex;
            CarregarGridAuditoria();
            //UpdatePanelAuditoria.Update();
        }

        protected void ddlAcao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTabela_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lkbPesquisar_Click(object sender, EventArgs e)
        {
            CarregaFiltro();
            //UpdatePanelAuditoria.Update();
        }

    }
