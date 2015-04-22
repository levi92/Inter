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
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            DataSet ds = Criterios_Gerais_DB.SelectAll(); //criando um data set com todos os critérios gerais
            int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

            //se qtd for maior que zero, ou seja, se tiver dados no data set
            if (qtd > 0)
            {
                gdv.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
                gdv.DataBind(); //preenche o grid view com os dados
                lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
            }

        }



        protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdv_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
