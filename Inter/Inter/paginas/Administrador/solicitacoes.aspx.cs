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
            Response.Redirect("~/BloqueioUrl");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGridAtivos();
        }
    }

    public void Teste()
    {
        lblMsgAssunto.Text = "mudar";
    }

    public void CarregarGridAtivos()
    {
        //ABERTO
        DataSet ds = Requerimento_DB.SelectS(1); //criando um data set com as solicitações abertas
        int qtd = ds.Tables[0].Rows.Count;      //qtd de linhas do ds

        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            lblMsgAssunto.Text = "teste";

            gdvRequerimentoAberto.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvRequerimentoAberto.DataBind(); //preenche o grid view com os dados
            lblQtdRegistro.Text = "Foram encontrados " + qtd + " Solicitações";
        }
        else
        {
            lblQtdRegistro.Text = "Nenhuma Solicitação foi encontrada.";
        }


        //EM ANDAMENTO
        ds = Requerimento_DB.SelectS(2); //criando um data set com as solicitações abertas
        qtd = ds.Tables[0].Rows.Count;      //qtd de linhas do ds

        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            gdvRequerimentoAndamento.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvRequerimentoAndamento.DataBind(); //preenche o grid view com os dados
            lblQtdRegistroAnd.Text = "Foram encontrados " + qtd + " Solicitações";
        }
        else
        {
            lblQtdRegistroAnd.Text = "Nenhuma Solicitação foi encontrada.";
        }


        //FINALIZADO
        ds = Requerimento_DB.SelectS(3); //criando um data set com as solicitações abertas
        qtd = ds.Tables[0].Rows.Count;      //qtd de linhas do ds

        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            gdvRequerimentoFinalizado.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdvRequerimentoFinalizado.DataBind(); //preenche o grid view com os dados
            lblQtdRegistroFin.Text = "Foram encontrados " + qtd + " Solicitações";
        }
        else
        {
            lblQtdRegistroFin.Text = "Nenhuma Solicitação foi encontrada.";
        }


    }


    //Método para confirmar a inserção de uma nova Requerimento
    protected void btnCriarNovoTicket_Click(object sender, EventArgs e)
    {
        txtAssunto.Style.Clear();
        txtCategoria.Style.Clear();

        if (!String.IsNullOrEmpty(txtAssunto.Text) && !String.IsNullOrEmpty(txtCategoria.Text))
        {

            string usuario = Session["nome"].ToString();
            string assunto = txtAssunto.Text;
            string categoria = txtCategoria.Text;

            Requerimento req = new Requerimento(usuario, assunto, categoria, usuario);

            if (Requerimento_DB.Insert(req) == 0)
            {
                lblMsg.Text = "<span class='glyphicon glyphicon-ok-circle'></span> &nbsp Cadastrado com sucesso.";
                lblMsg.Style.Add("color", "green");
                gdvRequerimentoAberto.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();


            }
            else
            {
                lblMsg.Text = "Erro ao inserir solicitação!";
            }
        }
    }


    protected void btnCancelarNovoCriterio_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModalCriacaoCriterio", "FechaModalCriacaoCriterio();", true);
        lblMsg.Text = "";
        txtAssunto.Text = "";
        txtCategoria.Text = "";

    }

    protected void gdvRequerimentoAberto_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnModal_Command(object sender, CommandEventArgs e)
    {
        int ID=Convert.ToInt32(e.CommandArgument);
        Requerimento req = Requerimento_DB.Select(ID);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        Teste();

        
    }


}


