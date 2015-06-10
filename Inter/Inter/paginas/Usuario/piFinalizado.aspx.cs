using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;
using AppCode.Persistencia;

public partial class paginas_Usuario_piFinalizado : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //VERIFICAR SESSAO LOGIN
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }
        // CHAMAR A MASTER PAGE             
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //BLOQUEIO URL
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dsSan = new DataSet();
            dsSan = Semestre_Ano_DB.SelectAll();          
            for(int i=0; i<dsSan.Tables[0].Rows.Count;i++){             
                ddlSemestreAno.Items.Add(new ListItem(dsSan.Tables[0].Rows[i]["san_ano"].ToString() + "/" + dsSan.Tables[0].Rows[i]["san_semestre"].ToString(), dsSan.Tables[0].Rows[i]["san_codigo"].ToString()));
            }
            ddlSemestreAno.Items.Insert(0, "Selecione");

            DataSet ds = new DataSet();
            ds = Funcoes.SelectAllPIsFinalizados(Convert.ToInt32(Session["codAtr"]));
            PiFinalizados(ds);

        }

    }

    protected void lbPesquisar_Click(object sender, EventArgs e)
    {
        DataSet dsNomeProjeto = new DataSet();
        dsNomeProjeto = Funcoes.SelectByNomeProjeto(Convert.ToInt32(Session["codAtr"]), txtPesquisar.Text);
        PiFinalizados(dsNomeProjeto);
    }

    public void PiFinalizados(DataSet ds)
    {
        gdvPisFinalizados.DataSource = ds;
        gdvPisFinalizados.DataBind();
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            lblQtdRegistro.Text = "Foram encontados " + qtd + " registros";
        }
        else
        {
            lblQtdRegistro.Text = "Nenhum registro encontrado";

        }
    }

    protected void ddlSemestreAno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemestreAno.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();
            ds = Funcoes.SelectBySemestreAno(Convert.ToInt32(Session["codAtr"]), Convert.ToInt32(ddlSemestreAno.SelectedValue));
            PiFinalizados(ds);
        }
    }

    protected void lbDetalhesProjeto_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MostraVizualizar()", "Mostra('p2');", true);

    }

    


}