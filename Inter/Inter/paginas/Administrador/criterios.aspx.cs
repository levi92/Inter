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
                CarregarGrid();
            }
        }

        public void CarregarGrid()
        {
            //DataSet ds = Criterios_Gerais_DB.SelectAtivos(); //criando um data set com todos os critérios gerais
            //int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            ////se qtd for maior que zero, ou seja, se tiver dados no data set
            //if (qtd > 0)
            //{
            //    gdvCriterios.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            //    gdvCriterios.DataBind(); //preenche o grid view com os dados
            //    lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
            //}
            //else
            //{
            //    lblQtdRegistro.Text = "Nenhum critério foi cadastrado.";
            //}

        }



       

        protected void gdvCriterios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblCodigo = (Label)gdvCriterios.Rows[e.RowIndex].FindControl("lblCodigo");
            TextBox txtNome = (TextBox)gdvCriterios.Rows[e.RowIndex].FindControl("txtNome");
            TextBox txtDescricao = (TextBox)gdvCriterios.Rows[e.RowIndex].FindControl("txtDescricao");
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = Convert.ToInt32(lblCodigo.Text);
            cri.Cge_nome = txtNome.Text;
            cri.Cge_descricao = txtDescricao.Text;
            if (Criterios_Gerais_DB.Update(cri) == 0)
            {
                lblMsg.Text = "Critério atualizado com sucesso!";
                gdvCriterios.EditIndex = -1;
                CarregarGrid();
            }
            else
            {
                lblMsg.Text = "Erro ao atualizar!";
            }
        }

        protected void gdvCriterios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvCriterios.EditIndex = -1;
            CarregarGrid();
        }

        protected void gdvCriterios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvCriterios.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void btnCriarNovoCriterio_Click(object sender, EventArgs e)
        {
            Criterios_Gerais cri = new Criterios_Gerais();
            cri.Cge_codigo = 0;
            cri.Cge_nome = txtNomeNovoCriterio.Text;
            cri.Cge_descricao = txtDescricaoNovoCriterio.Text;
            if (Criterios_Gerais_DB.Insert(cri) == 0)
            {

                lblMsg.Text = "Critério inserido com sucesso!";
                gdvCriterios.EditIndex = -1;
                CarregarGrid();
            }
            else
            {
                lblMsg.Text = "Erro ao inserir critério!";
            }
        }

        protected void gdvCriterios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Label lblCodigo = (Label)gdvCriterios.Rows[e.RowIndex].FindControl("lblCodigo");
            //if (Criterios_Gerais_DB.Desativar(Convert.ToInt32(lblCodigo.Text)) == 0)
            //{
            //    lblMsg.Text = "Critério desativado com sucesso!";
            //    gdvCriterios.EditIndex = -1;
            //    CarregarGrid();
            //}
        }

       
    }
