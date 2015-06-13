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
            Response.Redirect("~/BloqueioUrl");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaGridAdmin();
            CarregaGridProf();

        }


    }

    //protected void UpdatePanelAdmin_Update(object sender, EventArgs e)
    //{
    //    CarregaGridProf();
    //    UpdatePanelProf.Update();
    //}

    public void CarregaGridProf() //Carrega a grid que mostra os Professores.
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

    public void CarregaGridAdmin() //Carrega a grid que mostra os Admin Coordenadores.
    {
        DataSet ds = Perfil_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds


        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            gdvAdmin.Visible = true; //Parte 2: caso a grid esteja vazia no carregamento e após inserir algum Coordenador, 
            //a grid precisa ficar visível de novo por causa da Parte1(o else debaixo)(Continua parte 3 - último método)
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
        else
        {
            //Parte 1: se não achar nenhum registro no dataset, a grid tem que ficar invisível, pois ela não fica por padrão ao desativar o único adm coordenador restante
            //(mesmo atualizando a grid e updatepanel)
            gdvAdmin.Visible = false; 
        }
        lblQtdRegistroAdm.Text = "Foram encontrados " + qtd + " registros";

    }


    protected void gdvAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e) //DESATIVA O PERFIL DE ADMINISTRADOR COORDENADOR DE UM PROFESSOR
    {
        String matricula = gdvAdmin.DataKeys[e.RowIndex]["per_matricula"].ToString(); //pega a matricula do Admin Coordenador da linha específica

        if (Perfil_DB.DeleteAdminCoord(matricula) == 0)
        {
            CarregaGridAdmin();
            UpdatePanelAdmin.Update();
            lblMsgAdmin.Text = "Administrador Coordenador desativado com sucesso!";
            CarregaGridProf(); //Também carrega a grid e update do Prof para que o ícone de "Definir como Admin" volte a ficar visível para o prof clicado
            UpdatePanelProf.Update();

        }
        else
        {
            UpdatePanelAdmin.Update();
            lblMsgAdmin.Text = "Erro ao desativar Administrador Coordenador!";
        }
    }

    //DESATIVA PELO ONROWCOMMAND MAS NÃO ATUALIZA POR ALGUM MOTIVO
    //protected void gdvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "DesativarAdm")
    //    {
    //        GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
    //        string matricula = gdvAdmin.Rows[gvr.RowIndex].Cells[0].Text; //pega a matricula daquela linha do gridview

    //        if (Perfil_DB.DeleteAdminCoord(matricula) == "0")
    //        {
    //            CarregaGridAdmin();
    //            UpdatePanelAdmin.Update();
    //            lblMsgAdmin.Text = "Administrador Coordenador desativado com sucesso!";
    //            CarregaGridProf();
    //            UpdatePanelProf.Update();

    //        }
    //    }
    //}

    protected void gdvProf_RowCommand(object sender, GridViewCommandEventArgs e) //DEFINE UM PROFESSOR COMO ADMINISTRADOR COORDENADOR
    {
        if (e.CommandName == "DefinirAdm")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string matricula = gdvProf.Rows[gvr.RowIndex].Cells[0].Text; //pega a matricula daquela linha do gridview
            Perfil perf = new Perfil();
            perf.Matricula = matricula;

            if (Perfil_DB.InsertAdmCoord(perf) == 0)
            {
                CarregaGridAdmin();
                CarregaGridProf();
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
    }

    //protected void gdvProf_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    String matricula = gdvProf.DataKeys[e.RowIndex]["pro_matricula"].ToString();
    //    Perfil perf = new Perfil();
    //    perf.Matricula = matricula;


    //    if (Perfil_DB.InsertAdmCoord(perf) == 0)
    //    {
    //        CarregaGridAdmin();
    //        CarregaGridProf();              
    //        UpdatePanelProf.Update();
    //        UpdatePanelAdmin.Update();
    //        lblMsgProf.Text = "Administrador Coordenador definido com sucesso!";
    //    }
    //    else
    //    {
    //        UpdatePanelProf.Update();
    //        UpdatePanelAdmin.Update();
    //        lblMsgProf.Text = "Erro ao definir Administrador Coordenador!";
    //    }
    //}


    protected void gdvProf_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvProf.PageIndex = e.NewPageIndex;
        CarregaGridProf();
        //UpdatePanelProf.Update();

    }

    protected void gdvProf_RowDataBound(object sender, GridViewRowEventArgs e) //ESCONDE O ÍCONE DE DEFINIR ADMIN QUANDO COLOCAR AS LINHAS DA GRID E O PROF JÁ É ADMIN
    {
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool valor = false;
                foreach (GridViewRow linha in gdvAdmin.Rows)
                {
                    Label matriculaAdmin = (Label)linha.FindControl("lblMatriculaAdmin");
                    String matriculaProf = e.Row.Cells[0].Text;//gdvProf.DataKeys[linha.RowIndex]["pro_matricula"].ToString();

                    if (matriculaAdmin.Text == matriculaProf)
                    {
                        valor = true;

                    }
                    if (valor)
                    {
                        if (gdvAdmin.Visible==true) { //Parte 3: somente caso a grid esteja visível ele vai comparar para tirar o ícone
                        LinkButton botao = (LinkButton)e.Row.Cells[2].FindControl("lkbDefAdm");
                        botao.Visible = false;
                        }
                    }


                }

            }
        

    }

}
