using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;
using Interdisciplinar;
using AppCode.Persistencia;
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
            txtCategoria.Items.Insert(0, new ListItem("Selecione", "Selecione"));
            txtCategoria.Items.Insert(1, new ListItem("Alteração de notas", "1"));
            txtCategoria.Items.Insert(2, new ListItem("Problema com cadastros", "2"));
            txtCategoria.Items.Insert(3, new ListItem("Problema com avaliações", "3"));
            txtCategoria.Items.Insert(4, new ListItem("Sugestão", "4"));

            int codAtr = Convert.ToInt32(Session["codAtr"]);
            DataSet dsGrupos = Grupo_DB.SelectAllGruposFinalizadosAtual(codAtr);
            int qtd = dsGrupos.Tables[0].Rows.Count;

            string[] alunos_matricula1;
            string[][] alunos_matricula2 = new string [qtd][];
            string[] alunos_nome;
            string[] alunos_primeiro_nome;
            string[] grupos = new string[qtd];
            string[] codigo_grupo = new string[qtd];

            for (int i = 0; i < qtd; i++)
            {
                alunos_matricula1 = dsGrupos.Tables[0].Rows[i]["Alunos"].ToString().Split('-');
                alunos_nome = Funcoes.NomeAlunosByMatricula(alunos_matricula1);
                alunos_primeiro_nome = Funcoes.SplitNomes(alunos_nome);
                alunos_matricula2[i] = new string [alunos_matricula1.Length + 1];
                codigo_grupo[i] = dsGrupos.Tables[0].Rows[i]["gru_codigo"].ToString();

                for (int j = 0; j < alunos_matricula1.Length + 1; j++)
                {
                    if(j == 0)
                    {
                        alunos_matricula2[i][j] = dsGrupos.Tables[0].Rows[i]["gru_nome_projeto"].ToString();
                    }
                    else
                    {
                        alunos_matricula2[i][j] = alunos_primeiro_nome[j - 1];
                    }

                    if(j == alunos_matricula1.Length)
                    {
                        grupos[i] = grupos[i] + "" + alunos_matricula2[i][j];
                    }
                    else
                    {
                        grupos[i] = grupos[i] + "" + alunos_matricula2[i][j] + " - ";
                    }   
                }
            }

            if (qtd > 0)
            {
                for(int i = 0; i < qtd; i++)
                {
                    ddlGrupo.Items.Insert(i, new ListItem(grupos[i], codigo_grupo[i]));
                }    
            }
            else
            {
                ddlGrupo.Enabled = false;
                ddlGrupo.Items.Insert(0, new ListItem("Nenhum grupo finalizado encontrado.", "Selecione"));
            }
        }
    }

    public void CarregarGridAtivos()
    {
        //ABERTO
        string matricula = Session["matricula"].ToString();
        DataSet ds = Requerimento_DB.SelectS(1, matricula); //criando um data set com as solicitações abertas
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
        ds = Requerimento_DB.SelectS(2, matricula); //criando um data set com as solicitações abertas
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
        ds = Requerimento_DB.SelectS(3, matricula); //criando um data set com as solicitações abertas
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

        if (!String.IsNullOrEmpty(txtAssunto.Text) && !String.IsNullOrEmpty(txtCategoria.Text) && !String.IsNullOrEmpty(txtaMsg.Value) && !txtCategoria.SelectedValue.Equals("Selecione") && !ddlGrupo.SelectedValue.Equals("Selecione"))  
        {

            string prof = Session["nome"].ToString();
            string[] nomeProf = prof.Split(' ');
            string usuario = nomeProf[0] + " " + nomeProf[nomeProf.Length - 1];
            string matricula = Session["matricula"].ToString();
            string conteudo = txtaMsg.Value;
            int grupo = Convert.ToInt32(ddlGrupo.SelectedValue);


            txtResponder.Text = "";
            string assunto = txtAssunto.Text;
            string categoria = txtCategoria.SelectedItem.Text;
            Requerimento req = new Requerimento(matricula, assunto, categoria, usuario);
            if (txtCategoria.SelectedValue.Equals("1"))
            { // se o requerimento for para alteração de nota{
                req = new Requerimento(matricula, grupo, assunto, categoria, usuario);
            }

            if (Requerimento_DB.Insert(req) == 0)
            {

                lblMsg.Text = "<span class='glyphicon glyphicon-ok-circle'></span> &nbsp Solicitação enviada com sucesso.";
                lblMsg.Style.Add("color", "green");
                gdvRequerimentoAberto.EditIndex = -1;
                CarregarGridAtivos();
                UpdatePanelAtivados.Update();
                req = Requerimento_DB.SelectLast();
                int cod = req.CodigoReq;
                Mensagem men = new Mensagem(cod, matricula, conteudo, usuario);

                if (Mensagem_DB.Insert(men) == 0)
                {
                    Requerimento_DB.UpdateTime(cod);
                    abrirMensagens(cod);
                }
                else
                {
                    lblMsg.Text = "Erro ao enviar mensagem";
                }
                txtaMsg.Value = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FechaModalDepoisdeCriar", "fechaModalClick();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                lblMsgAssunto.Text = req.Assunto;
                lblMsgProfessor.Text = req.Usuario;
                lblMsgCategoria.Text = req.Categoria;
                lblMsgId.Text = req.CodigoReq.ToString();
                abrirMensagens(req.CodigoReq);
                lblMsgStatus.Text = "Aberto";
                mdlHeader.Attributes["style"] = "background-color: #960d10;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                UpdatePanel3.Update();
            }
            else
            {
                lblMsg.Text = "Erro ao enviar solicitação!";

            }

        }
        txtCategoria.SelectedIndex = 0;
        ddlGrupo.SelectedIndex = 0;


    }
        
    protected void btnCancelarNovaSolicitacao_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        txtAssunto.Text = "";
        txtCategoria.SelectedValue = "Selecione";
        txtaMsg.Value = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "fechaModalClick();", true);


    }


    protected void btnModal_Command(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument);
        Requerimento req = Requerimento_DB.Select(ID);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        lblMsgAssunto.Text = req.Assunto;
        lblMsgProfessor.Text = req.Usuario;
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
            if (usuario == msgDt.Tables[0].Rows[i][6].ToString())
            {
                msgBox = msgBox + "<div class='allMsg' style='float: right'><div class='txtCard' style='background-color: rgb(220, 248, 198);' onclick='mostraInfo(" + b + ")'>" + msgDt.Tables[0].Rows[i][5].ToString() + "</div><div id='info" + b + "' class='infoMsg'>Enviado por você as " + msgDt.Tables[0].Rows[i][4].ToString() + "</div></div>";
            }
            else
            {
                msgBox = msgBox + "<div class='allMsg' style='float: left'> <div class='txtCard' onclick='mostraInfo(" + b + ")'>" + msgDt.Tables[0].Rows[i][5].ToString() + "</div><div id='info" + b + "' class='infoMsg'>Enviado por " + msgDt.Tables[0].Rows[i][6].ToString() + " - " + msgDt.Tables[0].Rows[i][4].ToString() + "</div></div>";
            }

        }

        msgInsideBox.InnerHtml = msgBox;
    }

    protected void btnNovaMsg_Click(object sender, EventArgs e)
    {

        if (!String.IsNullOrEmpty(txtResponder.Text))
        {
            string prof = Session["nome"].ToString();
            string[] nomeProf = prof.Split(' ');
            string usuario = nomeProf[0] + " " + nomeProf[nomeProf.Length - 1];
            string matricula = Session["matricula"].ToString();
            string msg = txtResponder.Text;
            int cod = Convert.ToInt32(lblMsgId.Text);

            Mensagem men = new Mensagem(cod, matricula, msg, usuario);

            if (Mensagem_DB.Insert(men) == 0)
            {
                Requerimento_DB.UpdateTime(cod);
                abrirMensagens(cod);
            }
        }

        txtResponder.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        UpdatePanel3.Update();

        CarregarGridAtivos();
        UpdatePanelAtivados.Update();

    }

    protected void txtCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtCategoria.SelectedValue.Equals("1"))
        {
            txtAssunto.Enabled = false;
            txtAssunto.Text = "Alteração de notas - " + ddlGrupo.SelectedValue + " - " + ddlGrupo.SelectedItem;
            lblGrupo.Visible = true;
            ddlGrupo.Visible = true;
            UpdatePanelModalNovoRequerimento.Update();
            UpdatePanelGrupos.Update();
        }
        else
        {
            txtAssunto.Text = "";
            txtAssunto.Enabled = true;
            lblGrupo.Visible = false;
            ddlGrupo.Visible = false;
        }

    }

    protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!ddlGrupo.SelectedValue.Equals("Selecione")){
        txtAssunto.Text = "Alteração de notas - " + ddlGrupo.SelectedValue + " - " + ddlGrupo.SelectedItem;
        UpdatePanelModalNovoRequerimento.Update();
        UpdatePanelGrupos.Update();
        }
    }

}





