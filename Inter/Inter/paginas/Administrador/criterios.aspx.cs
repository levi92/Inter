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
                Response.Redirect("~/BloqueioUrl");
            }

            // CHAMA A MASTER PAGE CORRESPONDENTE MasterPage_MenuMaster ou MasterPage_MenuCoord através da função chamarMasterPage
            this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
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
            gdvCriteriosAtivos.Visible = true;
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
                gdvCriteriosAtivos.Visible = false;
                lblQtdRegistro.Text = "Nenhum critério foi cadastrado.";
            }

        }

        public void CarregarGridDesativados()
        {
            gdvCriteriosDesativados.Visible = true;
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
                gdvCriteriosDesativados.Visible = false;
                lblQtdRegistro2.Text = "Nenhum critério foi desativado.";
            }

        }

        //Método para salvar as alterações feitas em um critério ativo
        protected void gdvCriterios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            Label lblCodigo = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblCodigo");
            Label lblNome = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblNome");
            TextBox txtDescricao = (TextBox)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("txtDescricao");
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = Convert.ToInt32(lblCodigo.Text);
            cri.Cge_nome = lblNome.Text;
            cri.Cge_descricao = txtDescricao.Text;
            cri.Cge_usuario = Session["nome"].ToString();

            if (Criterios_Gerais_DB.Update(cri) == 0)
            {
                lblMsg.Text = "Critério "+lblNome.Text+" atualizado com sucesso!";
                gdvCriteriosAtivos.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();
                 
            }
            else
            {
                lblMsg.Text = "Erro ao atualizar "+lblNome.Text+"!";
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
            txtNomeNovoCriterio.Style.Clear();
            txtDescricaoNovoCriterio.Style.Clear();

            if (!String.IsNullOrEmpty(txtNomeNovoCriterio.Text) && !String.IsNullOrEmpty(txtDescricaoNovoCriterio.Text))
            {

                Criterios_Gerais cri = new Criterios_Gerais();
                cri.Cge_codigo = 0;
                cri.Cge_nome = txtNomeNovoCriterio.Text;
                cri.Cge_descricao = txtDescricaoNovoCriterio.Text;
                cri.Cge_usuario = Session["nome"].ToString();
               

                if (Criterios_Gerais_DB.Insert(cri) == 0)
                {
                    lblMsg.Text = "<span class='glyphicon glyphicon-ok-circle'></span> &nbsp Cadastrado com sucesso.";
                    lblMsg.Style.Add("color", "green");
                    gdvCriteriosAtivos.EditIndex = -1;
                    CarregarGridAtivos();
                    UpdatePanelAtivados.Update();


                }
                else
                {
                    lblMsg.Text = "Erro ao inserir critério!";
                }
            }
        }

        //Método para desativar um critério
        protected void gdvCriterios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            Label lblCodigo = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblCodigo");
            Criterios_Gerais criterio = new Criterios_Gerais();
            criterio.Cge_usuario = Session["nome"].ToString();

            if (Criterios_Gerais_DB.Desativar(Convert.ToInt32(lblCodigo.Text), criterio) == 0)
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
            Criterios_Gerais criterio = new Criterios_Gerais();
            criterio.Cge_usuario = Session["nome"].ToString();

                if (Criterios_Gerais_DB.Ativar(Convert.ToInt32(lblCodigo.Text), criterio) == 0)
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


        protected void btnCancelarNovoCriterio_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModal()", "FechaModal();", true);
            lblMsg.Text = "";
            txtNomeNovoCriterio.Text = "";
            txtDescricaoNovoCriterio.Text = "";
            
        }

       
    }
