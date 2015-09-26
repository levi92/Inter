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



    public void CarregarGridAtivos()
    {
        //ABERTO
        DataSet ds = Requerimento_DB.SelectS(1); //criando um data set com as solicitações abertas
        int qtd = ds.Tables[0].Rows.Count;      //qtd de linhas do ds
        //se qtd for maior que zero, ou seja, se tiver dados no data set

        gdvRequerimentoAberto.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
        gdvRequerimentoAberto.DataBind(); //preenche o grid view com os dados
        if (qtd > 0)
        {
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
        gdvRequerimentoAndamento.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
        gdvRequerimentoAndamento.DataBind(); //preenche o grid view com os dados
        if (qtd > 0)
        {
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
        gdvRequerimentoFinalizado.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
        gdvRequerimentoFinalizado.DataBind(); //preenche o grid view com os dados
        if (qtd > 0)
        {
            lblQtdRegistroFin.Text = "Foram encontrados " + qtd + " Solicitações";
        }
        else
        {
            lblQtdRegistroFin.Text = "Nenhuma Solicitação foi encontrada.";
        }


    }

    protected void btnModal_Command(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument);
        Requerimento req = Requerimento_DB.Select(ID);
        if (req != null)
        {
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
                    subMenu.Visible = true;
                    btnFinaliza.Visible = true;
                    break;
                case 2:
                    lblMsgStatus.Text = "Em Andamento";
                    mdlHeader.Attributes["style"] = "background-color: #f9ae0e;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                    subMenu.Visible = true;
                    btnFinaliza.Visible = true;
                    break;
                case 3:
                    lblMsgStatus.Text = "Finalizado";
                    mdlHeader.Attributes["style"] = "background-color: #0D9643;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);;";
                    txtResponder.Attributes["style"] = "background-color: #ccc";
                    txtResponder.ReadOnly = true;
                    subMenu.Visible = false;
                    btnNovaMsg.Visible = false;
                    btnFinaliza.Visible = false;
                    break;


            }

            if ((req.Categoria == "Alteração de notas") && (req.Status != 3))
            {
                subMenu.Attributes["style"] = "height: 84px";
                btnLibera.Visible = true;
            }
            else
            {
                subMenu.Attributes["style"] = "height: 42px";
                btnLibera.Visible = false;
            }

            if (req.Status == 3)
            {

            }
            else
            {
                //txtResponder.Attributes["style"] = "background-color: #fff";
                //txtResponder.ReadOnly = false;
                //btnNovaMsg.Visible = true;
            }

            abrirMensagens(req.CodigoReq);
            CarregarGridAtivos();
            UpdatePanel3.Update();
        }


    }

    public void abrirMensagens(int cod)
    {
        DataSet msgDt = Mensagem_DB.SelectAll(cod);

        int qtd = msgDt.Tables[0].Rows.Count;
        string usuario = Session["nome"].ToString();

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
            string usuario = Session["nome"].ToString();
            string matricula = Session["matricula"].ToString();
            string msg = txtResponder.Text;
            int cod = Convert.ToInt32(lblMsgId.Text);

            Mensagem men = new Mensagem(cod, matricula, msg, usuario);

            if (Mensagem_DB.Insert(men) == 0)
            {
                Requerimento_DB.UpdateTime(cod);
                Requerimento_DB.Update(cod, 2);
                lblMsgStatus.Text = "Em andamento";
                mdlHeader.Attributes["style"] = "background-color: #f9ae0e;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
                abrirMensagens(cod);

                CarregarGridAtivos();

            }
            else
            {
                
            }


            txtResponder.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            UpdatePanelAtivados.Update();
            UpdatePanel1.Update();
            UpdatePanel3.Update();

            UpdatePanelAtivados.Update();


        }
    }

    protected void btnFinaliza_Click(object sender, EventArgs e)
    {
        int cod = Convert.ToInt32(lblMsgId.Text);
        if (Requerimento_DB.Update(cod, 3) == 0)
        {
            Requerimento_DB.UpdateTime(cod);
            lblMsgStatus.Text = "Finalizado";
            mdlHeader.Attributes["style"] = "background-color: #0D9643;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
            txtResponder.Attributes["style"] = "background-color: #ccc";
            txtResponder.ReadOnly = true;
            btnNovaMsg.Visible = false;
            subMenu.Visible = false;
            btnNovaMsg.Visible = false;
            btnFinaliza.Visible = false;
            string usuario = Session["nome"].ToString();
            string matricula = Session["matricula"].ToString();
            string msg = "Esta solicitação foi finalizada por " + usuario;
            

            Mensagem men = new Mensagem(cod, matricula, msg, usuario);

            if (Mensagem_DB.Insert(men) == 0)
            {
            

            }
            abrirMensagens(cod);

            txtResponder.Text = "";
        }
        else
        {

        }
        CarregarGridAtivos();

        UpdatePanel3.Update();
        UpdatePanel1.Update();
        UpdatePanel2.Update();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    }

    protected void btnLibera_Click(object sender, EventArgs e)
    {
        string[] assuntoGrupo = lblMsgAssunto.Text.Split('-'); //separa a string de assunto automática
        int codReq = Convert.ToInt32(lblMsgId.Text);
        Requerimento req = Requerimento_DB.Select(codReq);
        int codGrupo = req.CodigoGrupo;
        if (Requerimento_DB.Update(codReq, 2, codGrupo) == 0)
        {
            Grupo_DB.Update(codGrupo);
            Requerimento_DB.UpdateTime(codReq);
            lblMsgStatus.Text = "Em Andamento";
            mdlHeader.Attributes["style"] = "background-color: #f9ae0e;color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);";
            
            txtResponder.Text = "";
            UpdatePanel3.Update();


            string usuario = Session["nome"].ToString();
            string matricula = Session["matricula"].ToString();
            string msg = "O grupo " + assuntoGrupo[2] + "foi liberado para edição de nota por " + usuario;


            Mensagem men = new Mensagem(codReq, matricula, msg, usuario);

            if (Mensagem_DB.Insert(men) == 0)
            {

               
            }
            else
            {

            }


        }
        else
        {

        }
        abrirMensagens(codReq);
        CarregarGridAtivos();

        UpdatePanel3.Update();
        UpdatePanel1.Update();
        UpdatePanel2.Update();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

    }


}


