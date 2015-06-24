using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;
using Interdisciplinar;

//Se usar um namespace aqui ele não reconhece o Funcoes por algum motivo...

public partial class paginas_Usuario_notificacoes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MÃE OU FILHA         
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // VERIFICAR SE O PROFESSOR NÃO ESCOLHEU UMA DISCIPLINA E REDIRECIONA PARA A PÁGINA ESCOLHER DISCIPLINA
        if (Session["disciplina"] == "")
        {
            Response.Redirect("~/EscolherDisciplina");

        }
        if (!IsPostBack)
        {
            CarregarGridAtivos();
        }
    }



    public void CarregarGridAtivos()
    {
        //ABERTO
        DataSet ds = Requerimento_DB.SelectS(1); //criando um data set com as solicitações abertas
        int qtd = ds.Tables[0].Rows.Count;      //qtd de linhas do ds
        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {

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

            Professor prof = new Professor();
            prof = (Professor)Session["Professor"];
            string[] nomeProf = prof.Nome.Split(' ');            
            string usuario1 = nomeProf[0] + " " + nomeProf[nomeProf.Length-1];
            string usuario = Session["nome"].ToString();

            
            string assunto = txtAssunto.Text;
            string categoria = txtCategoria.Text;

            Requerimento req = new Requerimento(usuario1, assunto, categoria, usuario);

            if (Requerimento_DB.Insert(req) == 0)
            {
                lblMsg.Text = "<span class='glyphicon glyphicon-ok-circle'></span> &nbsp Cadastrado com sucesso.";
                lblMsg.Style.Add("color", "green");
                gdvRequerimentoAberto.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();

                req = Requerimento_DB.SelectLast();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModalCriacaoCriterio", "FechaModalCriacaoCriterio();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                lblMsgAssunto.Text = req.Assunto;
                lblMsgProfessor.Text = req.MatriculaPro;
                lblMsgCategoria.Text = req.Categoria;
                lblMsgId.Text = req.CodigoReq.ToString();
                abrirMensagens(req.CodigoReq);
                lblMsgStatus.Text = "Aberto";
                mdlHeader.Attributes["style"] = "background-color: #960d10;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                UpdatePanel3.Update();
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

    
    protected void btnModal_Command(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument);
        Requerimento req = Requerimento_DB.Select(ID);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        lblMsgAssunto.Text = req.Assunto;
        lblMsgProfessor.Text = req.MatriculaPro;
        lblMsgCategoria.Text = req.Categoria;
        lblMsgId.Text = req.CodigoReq.ToString();
        
        switch (req.Status)
        {
            case 1:
                lblMsgStatus.Text = "Aberto";
                mdlHeader.Attributes["style"] = "background-color: #960d10;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                break;
            case 2:
                lblMsgStatus.Text = "Em Andamento";
                mdlHeader.Attributes["style"] = "background-color: #f9ae0e;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                break;
            case 3:
                lblMsgStatus.Text = "Finalizado";
                mdlHeader.Attributes["style"] = "background-color: #0D9643;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);;";
                break;

        }
        abrirMensagens(req.CodigoReq);

        UpdatePanel3.Update();



    }

    public void abrirMensagens(int cod)
    {
        DataSet msgDt = Mensagem_DB.SelectAll(cod);

        int qtd = msgDt.Tables[0].Rows.Count;

        Professor prof = new Professor();
        prof = (Professor)Session["Professor"];
        string[] nomeProf = prof.Nome.Split(' ');
        string usuario = nomeProf[0] + " " + nomeProf[nomeProf.Length - 1];

        string msgBox = " ";
        int b = 0;
        for (int i = 0; i < qtd; i++)
        {
            b = i + 1;
            if (usuario == msgDt.Tables[0].Rows[i][2].ToString())
            {
                msgBox = msgBox + "<div class='allMsg' style='float: right'><div class='txtCard' style='background-color: rgb(247, 247, 228);' onclick='mostraInfo(" + b + ")'>" + msgDt.Tables[0].Rows[i][5].ToString() + "</div><div id='info" + b + "' class='infoMsg'>Enviado as " + msgDt.Tables[0].Rows[i][4].ToString() + "</div></div>";
            }
            else
            {
                msgBox = msgBox + "<div class='allMsg' style='float: left'> <div class='txtCard' onclick='mostraInfo(" + b + ")'>" + msgDt.Tables[0].Rows[i][5].ToString() + "</div><div id='info" + b + "' class='infoMsg'>Enviado por " + msgDt.Tables[0].Rows[i][2].ToString() + " - " + msgDt.Tables[0].Rows[i][4].ToString() + "</div></div>";
            }

        }

        msgInsideBox.InnerHtml = msgBox;
    }

    protected void btnNovaMsg_Click(object sender, EventArgs e)
    {
        
        if (!String.IsNullOrEmpty(txtResponder.Text))
        {

            Professor prof = new Professor();
            prof = (Professor)Session["Professor"];
            string[] nomeProf = prof.Nome.Split(' ');
            string usuario = nomeProf[0] + " " + nomeProf[nomeProf.Length - 1]; 

            string msg = txtResponder.Text;
            int cod = Convert.ToInt32(lblMsgId.Text);

            Mensagem men = new Mensagem(cod, usuario, msg);

            if (Mensagem_DB.Insert(men) == 0)
            {
                Requerimento_DB.UpdateTime(cod);
                abrirMensagens(cod);
            }


            txtResponder.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            UpdatePanel3.Update();

            CarregarGridAtivos();
            UpdatePanelAtivados.Update();

        }
    }


}


