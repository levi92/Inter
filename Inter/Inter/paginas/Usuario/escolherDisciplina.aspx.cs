using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
//using System.Web.Script.Serialization;
//using System.Runtime.Serialization.Json;

public partial class paginas_Usuario_escolherDisciplina : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Pessoas pes = new Pessoas();
            
            string NomeUser = Session["login"].ToString(); //recebe email do professor logado
            pes = Pessoas_DB.Select(NomeUser); //cria um obj pessoa do professor, decorrente de um select utilizando seu email como parametro
            Session["nomeProf"] = pes.Pes_nome;

            int codProf = Professor_DB.SelectPes(pes.Pes_codigo);
            
            
            CarregarGrid(codProf); //carrega a grid utilizando o cod do Prof
            auxRb = -1;
        }

        
    }

    

    public void CarregarGrid(int proMatricula)
    {
        //DataSet ds = new DataSet();


        DataSet ds = Funcoes_DB.SelectDisciplina(proMatricula);
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            gdv.DataSource = ds.Tables[0].DefaultView;
            gdv.DataBind();
            lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
        }

    }


    protected void btnConfirmar_Click(object sender, EventArgs e)
    {

        int linhaSelecionada = -1;

        foreach (GridViewRow grid in gdv.Rows)
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");


            if (rb.Checked)
            {
                linhaSelecionada = grid.RowIndex;
                break;
            }
        }

        if (linhaSelecionada != -1)
        {
            string curso = gdv.Rows[linhaSelecionada].Cells[1].Text;
            string semestre = gdv.Rows[linhaSelecionada].Cells[2].Text;
            string disciplina = gdv.Rows[linhaSelecionada].Cells[3].Text;
            string mae = gdv.Rows[linhaSelecionada].Cells[4].Text;
            // SESSÕES
            Session["curso"] = curso;
            Session["semestre"] = semestre;
            Session["disciplina"] = disciplina;
            Session["mae"] = mae;

            //MANDANDO DADOS PARA A MASTER PAGE       
            //((paginas_Usuario_MasterPage)this.Master).dadosDisciplina(curso, semestre, disciplina, mae);
                   
                        
            Response.Redirect("home.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalEscolherDis", "modalEscolherDis();", true);  
        }
    }


    // CRIAR ÍCONE DISCIPLINA MÃE
    protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // SEMESTRE COMO ORDINAL
            string semestre = e.Row.Cells[2].Text;
            e.Row.Cells[2].Text = semestre + "º";


            if (e.Row.Cells[4].Text.ToLower().Equals("true"))
            {
                e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-star'></span>";
            }
            else
            {
                e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-minus'></span>";
            }

        }
    }

    


    //SELECIONAR APENAS UM RADIO
    public static int auxRb = -1;
    protected void rb_CheckedChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow grid in gdv.Rows)
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");

            if (grid.RowIndex == auxRb) //deselecionar radio que estava selecionado
            {
                rb.Checked = false;
                //gdv.Rows[auxRb].Style.Clear();
                break;
            }
        }


        foreach (GridViewRow grid in gdv.Rows)
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");

            if (rb.Checked)
            {
                auxRb = grid.RowIndex; //guarda radio atual selecionado
                //gdv.Rows[auxRb].Style.Add("border", "2px solid gray");
                break;
            }
        }

    }


//gdv.Style.Add("background-color", "#FCD85C;");
    //gdv.Rows[i].BackColor = System.Drawing.Color.FromArgb(123, 152, 121);

    //foreach (GridViewRow GVR in grifview.Rows)
    //{
    //    if (GVR.RowIndex == intSelectedRowIndex)
    //        GVR.Style.Add("background-color", "#FCD85C;");
    //    else
    //        GVR.Style.Clear();
    //}



}