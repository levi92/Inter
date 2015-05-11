using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;
using Interdisciplinar;

    public partial class paginas_Admin_usuarios : System.Web.UI.Page
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
                CarregaGridAdmin();
                CarregaGridProf();
            }
        }

        public void CarregaGridProf()
        {
            DataSet ds = Professor.SelectAll();

            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvProf.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvProf.DataBind(); //preenche o grid view com os dados
            }
            lblQtdRegistroProf.Text = "Foram encontrados " + qtd + " registros";
        }

        public void CarregaGridAdmin()
        {
            DataSet ds = Perfil_DB.SelectAll();
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds


            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdvAdmin.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdvAdmin.DataBind(); //preenche o grid view com os dados
                foreach (GridViewRow linha in gdvAdmin.Rows)//percorre cada linha da grid (obs: isso existe pelo campo de nome estar em outra tabela no BD da Fatec)
                {
                    Professor prof = new Professor(); //instancia um novo professor
                    Label lblMatricula = (Label)linha.FindControl("lblMatriculaAdmin");//acha o label de matrícula da grid e liga a outro label
                    Label lblNome = (Label)linha.FindControl("lblNomeAdmin"); //acha o label de Nome e liga a outro label
                    prof = Professor.SelectByCodigo(lblMatricula.Text); //o número de matrícula do label é usado para preencher o objeto professor usando o método de selecionar por código
                    lblNome.Text = prof.Nome; //o label NomeAdmin da grid é preenchido utilizando o nome que está no objeto do professor (método get encapsulado)
                    
                }
            }
            lblQtdRegistroAdm.Text = "Foram encontrados " + qtd + " registros";

        }


        protected void gdvAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e) //Desfazer perfil de Admin Coordenador
        {
            String matricula = gdvAdmin.DataKeys[e.RowIndex]["per_matricula"].ToString();

            if (Perfil_DB.DeleteAdminCoord(matricula) == "0")
            {
                CarregaGridAdmin();
                UpdatePanelAdmin.Update();
                lblMsgAdmin.Text = "Administrador Coordenador desativado com sucesso!";
            }
            else
            {
                UpdatePanelAdmin.Update();
                lblMsgAdmin.Text = "Erro ao desativar Administrador Coordenador!";
            }
        }

        protected void gdvProf_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String matricula = gdvProf.DataKeys[e.RowIndex]["pro_matricula"].ToString();
            Perfil perf = new Perfil();
            perf.Matricula = matricula;


            if (Perfil_DB.InsertAdmCoord(perf) == 0)
            {
                CarregaGridProf();
                CarregaGridAdmin();
                UpdatePanelProf.Update();
                UpdatePanelAdmin.Update();
                lblMsgProf.Text = "Administrador Coordenador definido com sucesso!";
            }
            else
            {
                UpdatePanelProf.Update();
                UpdatePanelAdmin.Update();
                lblMsgProf.Text = "Erro ao definir Administrador Coordenador!";
            }
        }


        protected void gdvProf_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProf.PageIndex = e.NewPageIndex;
            CarregaGridProf();
          
        }

       
    }
