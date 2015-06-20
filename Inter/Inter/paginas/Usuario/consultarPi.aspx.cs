using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using AppCode.Persistencia;
using System.Data;
public partial class paginas_Usuario_consultarPi : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Professor"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }
        // CHAMAR A MASTER PAGE             
        this.Page.MasterPageFile = Funcoes.chamarMasterPage(Session["mae"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["disciplina"] == "")
        {
            Response.Redirect("~/EscolherDisciplina");
        }

        if (!IsPostBack)
        {

            lblCodigoPI.Text = Session["CodPIAtivo"].ToString();
            lblCursoValor.Text = Session["curso"].ToString();
            lblSemestreValor.Text = Session["semestre"].ToString();

            Semestre_Ano san = new Semestre_Ano();
            san = Semestre_Ano_DB.Select();

            lblAnoValor.Text = san.San_ano.ToString();
            lblSemestreAnoValor.Text = san.San_semestre.ToString();

            CarregarEventos();
          
        }
        
    }

    public void CarregarEventos()
    {
        DataSet ds = Eventos_DB.SelectEventosPI(Convert.ToInt32(Session["codPIAtivo"]));
        gdvEventosConsultarPI.DataSource = ds;
        gdvEventosConsultarPI.DataBind();

    }


}