using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;


//Se usar um namespace aqui ele não reconhece o Funcoes por algum motivo...

    public partial class paginas_Admin_solicitacoes : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Se sessão estiver nula redireciona para o bloqueio Url
            if (Session["login"] == null)
            {
                Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
            }

            // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
            this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["coord"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGridAtivos();
            }
        }


        public void CarregarGridAtivos()
        {
            DataSet ds = Criterios_Gerais_DB.SelectAll(); //criando um data set com todos as soliciacoes
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvCriteriosAtivos.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvCriteriosAtivos.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontradas " + qtd + " solicitações";
            }
            else
            {
                lblQtdRegistro.Text = "Nenhuma Solicitação foi cadastrada.";
            }

        }



        //Método para salvar as alterações feitas em uma Solicitação
        protected void gdvCriterios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblCodigo = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblCodigo");
            Label lblNome = (Label)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("lblNome");
            TextBox txtDescricao = (TextBox)gdvCriteriosAtivos.Rows[e.RowIndex].FindControl("txtDescricao");
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = Convert.ToInt32(lblCodigo.Text);
            cri.Cge_nome = lblNome.Text;
            cri.Cge_descricao = txtDescricao.Text;
            if (Criterios_Gerais_DB.Update(cri) == 0)
            {
                lblMsg.Text = "Solicitação " + lblNome.Text + " atualizada com sucesso!";
                gdvCriteriosAtivos.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();

            }
            else
            {
                lblMsg.Text = "Erro ao atualizar " + lblNome.Text + "!";
            }
        }

        //Método para cancelar a edição de uma Solicitação
        protected void gdvCriterios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvCriteriosAtivos.EditIndex = -1;
            CarregarGridAtivos();
        }

        //Método para editar uma Solicitação (transforma o Label em Textbox)
        protected void gdvCriterios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvCriteriosAtivos.EditIndex = e.NewEditIndex;
            CarregarGridAtivos();
        }


        //Método para confirmar a inserção de uma nova Solicitação
        protected void btnCriarNovoTicket_Click(object sender, EventArgs e)
        {
            txtAssunto.Style.Clear();
            txtDescricaoNovoCriterio.Style.Clear();

            if (!String.IsNullOrEmpty(txtAssunto.Text) && !String.IsNullOrEmpty(txtDescricaoNovoCriterio.Text))
            {

                Requerimento req = new Requerimento();
                req.CodigoReq = 0;
                req.Assunto = txtAssunto.Text;
                req.Categoria = txtDescricaoNovoCriterio.Text;


                if (Requerimento_DB.Insert(req) == 0)
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


        protected void btnCancelarNovoCriterio_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModalCriacaoCriterio", "FechaModalCriacaoCriterio();", true);
            lblMsg.Text = "";
            txtAssunto.Text = "";
            txtDescricaoNovoCriterio.Text = "";

        }


    }

