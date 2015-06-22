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

        if (Session["CodPIAtivo"] == null)
        {
            Response.Redirect("~/Home");
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
            CarregarDisciplinas();
            CarregarCriterios();
            CarregarGrupos();
        }
        
    }

    public void CarregarEventos()
    {
        DataSet ds = Eventos_DB.SelectEventosPI(Convert.ToInt32(Session["codPIAtivo"]));
        int qtd = ds.Tables[0].Rows.Count;
        string descricaoDatas = "", data = "";

        gdvEventosConsultarPI.DataSource = ds;
        gdvEventosConsultarPI.DataBind();

        //GUARDANDO DATAS DE EVENTOS PARA PODER JOGAR NA PAGINA DE EDITAR DATAS 
        for (int i = 0; i < qtd; i++)
        {
            descricaoDatas += ds.Tables[0].Rows[i]["eve_tipo"].ToString() + "|";
            data += ds.Tables[0].Rows[i]["eve_data"].ToString().Substring(0, 10) + "|"; //FORMATO ORIGINAL DA DATA: 00/00/00 00:00:00
        }
      
        hdfDescricao.Value = descricaoDatas;
        hdfDatas.Value = data;

    }

    public void CarregarDisciplinas()
    {
        string[] codigosDisc = (string[])Session["codEnvolvidas"];
        string[] nomeDisc;
        string nomeDisFormatada = ""; //PARA DEIXAR A PRIMEIRA LETRA MAIÚSCULA
        nomeDisc = Funcoes.MateriasByCodigo(codigosDisc);

        DataTable dt = new DataTable();
        dt.Columns.Add("Disciplinas", typeof(string));
        
        for (int i = 0; i < nomeDisc.Length; i++)
        {
            DataRow dr = dt.NewRow();

            nomeDisFormatada += nomeDisc[i].Substring(0, 1).ToUpper();
            nomeDisFormatada += nomeDisc[i].Substring(1, nomeDisc[i].Length - 1).ToLower();

            dr["Disciplinas"] = nomeDisFormatada;
            dt.Rows.Add(dr);

            nomeDisFormatada = "";
        }

        gdvDisciplinasEnvolvidas.DataSource = dt;
        gdvDisciplinasEnvolvidas.DataBind();

    }

    public void CarregarCriterios()
    {
        DataSet ds = Criterio_PI_DB.SelectCriteriosPesosByPI(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));
        gdvCriterios.DataSource = ds;
        gdvCriterios.DataBind();
    }

    public void CarregarGrupos()
    {
        DataSet dsGruposAtual = new DataSet();
        dsGruposAtual = Grupo_DB.SelectAllGruposAtual(Convert.ToInt32(Session["codPIAtivo"]), Convert.ToInt32(Session["codAtr"]));

        int qtdGrupos = dsGruposAtual.Tables[0].Rows.Count;

        int qtdGrids = 0;

        if (qtdGrupos <= 4)
        {
            qtdGrids = 1;
        }
        else
        {
            qtdGrids = qtdGrupos % 4;
        }


        
        for (int i = 0; i < qtdGrids; i++)
        {
            GridView gdv = new GridView();
            gdv.ID = "gdvGrupos"+i;
            gdv.AutoGenerateColumns = false;
            gdv.CssClass = "tableEventos";

            for (int j = 0; j < qtdGrupos; j++)
            {
                TemplateField temp = new TemplateField();
                temp.HeaderText = dsGruposAtual.Tables[0].Rows[j]["GRU_NOME_PROJETO"].ToString();
                gdv.Columns.Add(temp);
            }


            this.pnlGrupos.Controls.Add(gdv);
            this.pnlGrupos.DataBind();
        }

    }

}