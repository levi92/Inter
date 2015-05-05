using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;



    public partial class paginas_Admin_criterios : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Se sessão estiver nula redireciona para o bloqueio Url
            if (Session["login"] == null)
            {
                Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
            }

            // CHAMA A MASTER PAGE CORRESPONDENTE MasterPage_MenuMaster ou MasterPage_MenuCoord
            this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["coord"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGridAtivos();
                CarregarGridDesativados();
            }
        }

        public void CarregarGridAtivos()
        {
            DataSet ds = Criterios_Gerais_DB.SelectAtivos(); //criando um data set com todos os critérios gerais
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvCriteriosAtivos.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvCriteriosAtivos.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " critérios ativos";
            }
            else
            {
                lblQtdRegistro.Text = "Nenhum critério foi cadastrado.";
            }

        }

        public void CarregarGridDesativados()
        {
            DataSet ds = Criterios_Gerais_DB.SelectDesativados(); //criando um data set com todos os critérios gerais
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvCriteriosDesativados.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvCriteriosDesativados.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro2.Text = "Foram encontrados " + qtd + " critérios desativados";
            }
            else
            {
                lblQtdRegistro2.Text = "Nenhum critério foi desativado.";
            }

        }

        //Método para salvar as alterações feitas em um critério ativo
        protected void gdvCriterios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblCodigo = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblCodigo");
            TextBox txtNome = (TextBox)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("txtNome");
            TextBox txtDescricao = (TextBox)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("txtDescricao");
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = Convert.ToInt32(lblCodigo.Text);
            cri.Cge_nome = txtNome.Text;
            cri.Cge_descricao = txtDescricao.Text;
            if (Criterios_Gerais_DB.Update(cri) == 0)
            {
                lblMsg.Text = "Critério atualizado com sucesso!";
                gdvCriteriosAtivos.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();
                 
            }
            else
            {
                lblMsg.Text = "Erro ao atualizar!";
            }
        }

        //Método para cancelar a edição de um critério
        protected void gdvCriterios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvCriteriosAtivos.EditIndex = -1;
            CarregarGridAtivos();
        }

        //Método para editar um critério (transforma o Label em Textbox)
        protected void gdvCriterios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvCriteriosAtivos.EditIndex = e.NewEditIndex;
            CarregarGridAtivos();
        }

        //Método para confirmar a inserção de um novo critério
        protected void btnCriarNovoCriterio_Click(object sender, EventArgs e)
        {
            
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = 0;
            cri.Cge_nome = txtNomeNovoCriterio.Text;
            cri.Cge_descricao = txtDescricaoNovoCriterio.Text;
            
            if (Criterios_Gerais_DB.Insert(cri) == 0)
            {

                lblMsg.Text = "Critério inserido com sucesso!";
                gdvCriteriosAtivos.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();
        
            }
            else
            {
                lblMsg.Text = "Erro ao inserir critério!";
            }
        }

        //Método para desativar um critério
        protected void gdvCriterios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblCodigo = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblCodigo");
            if (Criterios_Gerais_DB.Desativar(Convert.ToInt32(lblCodigo.Text)) == 0)
            {
                lblMsg.Text = "Critério desativado com sucesso!";
                gdvCriteriosAtivos.EditIndex = -1;
                gdvCriteriosDesativados.EditIndex = -1;
                CarregarGridAtivos();
                CarregarGridDesativados();
                UpdatePanelDesativados.Update();
                UpdatePanelAtivados.Update();
            
            }
        }

  
        //Método para ativar um critério
        protected void gdvCriteriosDesativados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblCodigo = (Label)gdvCriteriosDesativados.Rows[e.RowIndex].FindControl("lblCodigo");
                if (Criterios_Gerais_DB.Ativar(Convert.ToInt32(lblCodigo.Text)) == 0)
                {
                    lblMsg2.Text = "Critério ativado com sucesso!";                 
                    CarregarGridAtivos();
                    CarregarGridDesativados();
                    UpdatePanelDesativados.Update();
                    UpdatePanelAtivados.Update();
                    
                }
                else
                {
                    lblMsg2.Text = "Erro ao ativar critério!";
                }
        }

       
    }
