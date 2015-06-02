using AppCode.Persistencia;
using Inter.Funcoes;
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
        i = 0;
        // SE NÃO FOR POSTBACK 
        if (!IsPostBack)
        {

            Professor prof = new Professor();
            prof = (Professor) Session["Professor"];

            CarregarGrid(); //CARREGA A GRID
            auxRb = -1; //SELECIONAR QUAL LINHA TA SELECIONADA DO RB
        }
    }



    public void CarregarGrid()
    {
        Professor prof = new Professor();
        prof = (Professor)Session["Professor"];
        DataSet ds = (DataSet)Session["DataSetCalendarioAndProfessor"];        
        if (Session["DataSetCalendarioAndProfessor"] == null)
        {
            Calendario cal = new Calendario();
            cal = Calendario.SelectbyAtual();
            ds = Professor.SelectAllPIsbyCalendarioAndProfessor(cal.AnoSemestreAtual, cal.Codigo, prof.Matricula);
            Session["DataSetCalendarioAndProfessor"] = ds;
        }
       
        int qtd = ds.Tables[0].Rows.Count; //qtd de linhas do ds
        //se qtd for maior que zero, ou seja, se tiver dados no data set
        if (qtd > 0)
        {
            gdv.DataSource = ds.Tables[0].DefaultView; //fonte de dados do grid view recebe o ds criado anteriormente
            gdv.DataBind(); //preenche o grid view com os dados
        }       
        lblQtdRegistro.Text = "Foram encontrados " + qtd + " registros";
    }

    int i = 0;
    // CRIAR ÍCONE DISCIPLINA MÃE
    protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)Session["DataSetCalendarioAndProfessor"];
        string[] vetorReturnFunction = new string[3];

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            vetorReturnFunction = Funcoes.tratarDadosProfessor(ds.Tables[0].Rows[i]["disciplina"].ToString());
            e.Row.Cells[1].Text = vetorReturnFunction[0];
            e.Row.Cells[2].Text = vetorReturnFunction[1];
            e.Row.Cells[3].Text = vetorReturnFunction[2];
            i++;
        }

        //e = tdos eventos relacionados a um componente, pega a linha e verifica se é do tipo dados
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //se for mãe
            if (e.Row.Cells[4].Text.Equals("MAE"))
            {
                //ícone da estrelinha
                e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-star'></span>";
            }
            else
            {
                //ícone de tracinho
                e.Row.Cells[4].Text = "<span class='glyphicon glyphicon-minus'></span>";
            }

        }
    }

    //evento do botão confirmar: pega linha selecionada e armazena os dados da mesma
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        //linha não selecionada
        int linhaSelecionada = -1;
        int codAtr = 0;

        foreach (GridViewRow grid in gdv.Rows)//percorrer toda a grid
        {
            RadioButton rb = (RadioButton)grid.FindControl("rb");//procurando um rb


            if (rb.Checked)
            {
                linhaSelecionada = grid.RowIndex;//recebe a linha selecionada                
                break;
            }
        }

        if (linhaSelecionada != -1)//CASO TENHA RB SELECIONADO
        {
            string curso = gdv.Rows[linhaSelecionada].Cells[1].Text;
            string semestre = gdv.Rows[linhaSelecionada].Cells[2].Text;
            string disciplina = gdv.Rows[linhaSelecionada].Cells[3].Text;
            string mae = gdv.Rows[linhaSelecionada].Cells[4].Text;
            codAtr = Convert.ToInt32(gdv.Rows[linhaSelecionada].Cells[5].Text);

            // SESSÕES COM OS DADOS DA LINHA SELECIONADA
            Session["curso"] = curso;
            Session["semestre"] = semestre;
            Session["disciplina"] = disciplina;            
            Session["codAtr"] = codAtr;

            // CARREGAR DISCIPLINAS ENVOLVIDAS EM SESSOES
            DataSet dsEnvolvidas = new DataSet();
            Calendario cal = new Calendario();
            cal = Calendario.SelectbyAtual();
            dsEnvolvidas = Professor.SelectAllPIsbyCalendario(cal.Codigo, cal.AnoSemestreAtual);

            string[] dadosDisc = new string[4];
            List<string> codEnvolvidas = new List<string>();
            List<string> atrEnvolvidas = new List<string>();
            List<string> nomeEnvolvidas = new List<string>();
            List<string> maeEnvolvidas = new List<string>();
            for (int i = 0; i < dsEnvolvidas.Tables[0].Rows.Count; i++)
            {
                dadosDisc = Funcoes.tratarDadosProfessor(dsEnvolvidas.Tables[0].Rows[i][1].ToString());
                if ((dadosDisc[0] == Session["Curso"].ToString()) && (dadosDisc[1] == Session["Semestre"].ToString()))
                {
                    codEnvolvidas.Add(dadosDisc[3]);
                    atrEnvolvidas.Add(dsEnvolvidas.Tables[0].Rows[i][0].ToString());
                    nomeEnvolvidas.Add(dadosDisc[2]);
                    maeEnvolvidas.Add(dsEnvolvidas.Tables[0].Rows[i][2].ToString());
                }
            }

            string[] vetCodEnvolvidas = codEnvolvidas.ToArray();
            Session["codEnvolvidas"] = vetCodEnvolvidas;
            string[] vetAtrEnvolvidas = atrEnvolvidas.ToArray();
            Session["atrEnvolvidas"] = vetAtrEnvolvidas;
            string[] vetNomeEnvolvidas = nomeEnvolvidas.ToArray();
            Session["nomeEnvolvidas"] = vetNomeEnvolvidas;
            string[] vetMaeEnvolvidas = maeEnvolvidas.ToArray();
            Session["maeEnvolvidas"] = vetMaeEnvolvidas;


                // CARREGAR SESSOES

            Session["codPIAtivo"] = Funcoes.SelectCodPIAtivoByAtr(codAtr);
            if (Convert.ToInt32(Session["codPIAtivo"]) != -2 && Convert.ToInt32(Session["codPIAtivo"]) != 0)
            { 
                DataSet dsGruposAvaliar = new DataSet();
                DataSet dsGruposFinalizar = new DataSet();
                dsGruposAvaliar = Grupo_DB.SelectAllGruposAvaliar(Convert.ToInt32(Session["codPIAtivo"]));
                dsGruposFinalizar = Grupo_DB.SelectAllGruposFinalizar(Convert.ToInt32(Session["codPIAtivo"]));
                if (dsGruposFinalizar == null)
                {
                    Session["GruposFinalizar"] = null;
                }
                else
                {
                    Session["GruposFinalizar"] = dsGruposFinalizar;
                }
                Session["GruposAvaliar"] = dsGruposAvaliar;
            }else{
                Session["codPIAtivo"] = null;
                Session["GruposAvaliar"] = null;
                Session["GruposFinalizar"] = null;
                Session["Grupos"] = null;
                Session["codDisciplinas"] = null;
            }

            if (mae == "<span class='glyphicon glyphicon-star'></span>")
            {
                Session["mae"] = "MAE";                
            }
            else
            {
                Session["mae"] = "FILHA";
            }
            //REDIRECIONA PRA HOME
            Response.Redirect("home.aspx");
        }
        else
        {
            //SE NENHUM RB FOR SELECIONADO, UMA MODAL DE AVISO É EXIBIDA
            //SCRIPTMANAGER SERVE PARA CHAMAR UM JAVASCRIPT VIA C#
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