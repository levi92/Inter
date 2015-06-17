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
            }


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
        }
    }
