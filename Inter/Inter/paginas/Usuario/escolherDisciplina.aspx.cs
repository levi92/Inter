using Interdisciplinar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Usuario_escolherDisciplina : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        // Se não for postback 
        if (!IsPostBack)
        {

            Professor prof = new Professor();
            prof = (Professor) Session["Professor"];
            //int codProf = Professor_DB.SelectPes(pes.Pes_codigo); //seleciona o código pessoa para verificar qual o cod do Prof

            CarregarGrid(); //carrega a grid
            auxRb = -1; //selecionar qual linha ta selecionada do rb
        }
    }



    public void CarregarGrid()
    {
        Professor prof = new Professor();
        prof = (Professor)Session["Professor"];

        Calendario cal = new Calendario();
        cal = Calendario.SelectbyAtual();
        DataSet ds = Professor.SelectAllPIsbyCalendarioAndProfessor(cal.AnoSemestreAtual, cal.Codigo, prof.Matricula);

        int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds

        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            gdv.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdv.DataBind(); //preenche o grid view com os dados
        }
        lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
    }

    // CRIAR ÍCONE DISCIPLINA MÃE
    protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ////e = tdos eventos relacionados a um componente, pega a linha e verifica se é do tipo dados
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{    
        //    //se for mãe
        //    if (e.Row.Cells[4].Text.ToLower().Equals("true"))
        //    {
        //        //ícone da estrelinha
        //        e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-star'></span>";
        //    }
        //    else
        //    {
        //        //ícone de tracinho
        //        e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-minus'></span>";
        //    }

        //}
    }

    //evento do botão confirmar: pega linha selecionada e armazena os dados da mesma
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        //linha não selecionada
        int linhaSelecionada = -1;

        foreach (GridViewRow grid in gdv.Rows)//percorrer toda a grid
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");//procurando um rb


            if (rb.Checked)
            {
                linhaSelecionada = grid.RowIndex;//recebe a linha selecionada
                break;
            }
        }

        if (linhaSelecionada != -1)//caso tenha rb selecionado
        {
            string curso = gdv.Rows[linhaSelecionada].Cells[1].Text;
            string semestre = gdv.Rows[linhaSelecionada].Cells[2].Text;
            string disciplina = gdv.Rows[linhaSelecionada].Cells[3].Text;
            string mae = gdv.Rows[linhaSelecionada].Cells[4].Text;
            // sessões com os dados da linha selecionada
            Session["curso"] = curso;
            Session["semestre"] = semestre;
            Session["disciplina"] = disciplina;
            if (mae == "<span class='glyphicon glyphicon-star'></span>")
            {
                Session["mae"] = "True";
            }
            else
            {
                Session["mae"] = "False";
            }
            //redireciona pra home
            Response.Redirect("home.aspx");
        }
        else
        {
            //se nenhum rb for selecionado, uma modal de aviso é exibida
            //ScriptManager serve para chamar um javascript via c#
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEscolherDis", "modalEscolherDis();", true);
        }
    }




    //SELECIONAR APENAS UM RADIO
    public static int auxRb = -1;
    protected void rb_CheckedChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow grid in gdv.Rows)//percorrer toda a grid
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");//procurando um rb

            if (grid.RowIndex == auxRb) //se a linha atual da grid for igual a linha que existe um radio selecionado
            {
                rb.Checked = false; //desseleciona radio que estava selecionado
                break;
            }
        }


        foreach (GridViewRow grid in gdv.Rows)//percorrer toda a grid
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");//procurando um rb

            if (rb.Checked)
            {
                auxRb = grid.RowIndex; //guarda radio atual selecionado                
                break;
            }
        }

    }


}