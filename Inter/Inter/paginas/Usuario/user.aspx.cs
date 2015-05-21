using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

public partial class Paginas_Usuario_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["login"] == null)
        //{
        //    Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        //}
        CarregaCriGerais();
        CarregarGrid();
        
        //Pessoas pes = new Pessoas();
        //Professor prof = new Professor();
        //string NomeUser = Session["login"].ToString();
        //pes = Pessoas_DB.Select(NomeUser);
        //Session["nomeProf"] = pes.Pes_nome;
        //professorLogado.Text = Session["nomeProf"].ToString();

        //prof = Professor_DB.SelectPes(pes.Pes_codigo);       
    }


    private void CarregaCriGerais()
    {
        DataSet ds = Criterios_Gerais_DB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            lblCriGerais.Text = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                lblCriGerais.Text += "<li class=\"ui-state-default\">" + dr["cge_nome"].ToString() + "</li>";

            }
        }
    }


    public void CriarCriterio(int i, string text)
    {
        Label lblCriterios = new Label();
        lblCriterios.ID = "lblCriterio" + i;
        lblCriterios.Text = text;
        //Panel1.Controls.Add(lblCriterios);

    }

    [System.Web.Services.WebMethod]
    public static string GetUsuario(string usuario)
    {
        string[] dados = usuario.Split('|');
        for (int i = 0; i < dados.Length; i++)
        {
            //dados[i];
        }
        return usuario;
    }

    [System.Web.Services.WebMethod]
    public static string GetCriterio(string criterio)
    {
        string[] dadosCrit = criterio.Split('|');
        Label[] lblCriterios = new Label[dadosCrit.Length];
        

        for (int i = 0; i < dadosCrit.Length; i++)
        {
            //lblCriterios[i] = new Label();
            //lblCriterios[i].ID = "lblCriterio" + (i + 1);
            //lblCriterios[i].Text = dadosCrit[i];

            //Panel1.Controls.Add(lblCriterios[i]);
            //CriarCriterio(int i, string text);
            //dadosCrit[i];
            //CriarCriterio(i, dadosCrit[i]);
        }
        return criterio;
        
    }

    public void LimpaSession()
    {
        Session.Abandon();
    }

    public void CarregarGrid()
    {
        //DataSet ds = new DataSet();
        //DataSet ds = Professor_DB.SelectAll();
        //int qtd = ds.Tables[0].Rows.Count;
        //if (qtd > 0)
        //{
        //    gdv.DataSource = ds.Tables[0].DefaultView;
        //    gdv.DataBind();
        //    gdv.Visible = true;
        //    //lbl.Text = "Foram encontrados " + qtd + " de registros";
        //}
        //else
        //{
        //    gdv.Visible = false;
        //    //lbl.Text = "Não foram encontrado registros...";
        //}
    }

    //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "LoginFail", "LoginFail();", true);
    //<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    //Response.Redirect("myModalDesejaSair");


    //protected void ContinuarEtapa4_Click(object sender, EventArgs e)
    //{
    //    ///ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none","<script>$('#myModalPesoUm').modal('show');</script>", false);
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //}

    protected void gdv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal Literal1 = (Literal)e.Row.FindControl("Literal1");

            Literal1.Text = string.Format(
            "<input type='radio' name='Grupo' " +
            "id='RowID{0}' value='{0}' />", e.Row.RowIndex);

        }
    }
    protected void btnRandom_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in gdv.Rows)
        //{
            //if ((Boolean)row.Cells[1]. == true)
            //{
            string texto = gdv.Rows[1].Cells[2].Text;
            lbl.Text = texto;
            //}
        //}
    }
}