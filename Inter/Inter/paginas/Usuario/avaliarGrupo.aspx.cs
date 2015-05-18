using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using System.Data;

public partial class paginas_Usuario_avaliarGrupo : System.Web.UI.Page
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
        if (Session["disciplina"] == "")
        {
            Response.Redirect("escolherDisciplina.aspx");
        }


        
        DataSet dsAluno = new DataSet();
        DataSet dsCriterios = new DataSet();
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();
        //dsAluno = Aluno_DB.SelectAllAlunos(); não tem mais Aluno_DB -> resolver
        dsCriterios = Criterios_Gerais_DB.SelectAll();

        dt.Columns.Add(" ", typeof(string));

        for (int i = 0; i < dsAluno.Tables[0].Rows.Count; i++)
        {
            dt.Columns.Add(dsAluno.Tables[0].Rows[i]["pes_nome"].ToString(), typeof(string));
        }

        TextBox txbNotas;
        for (int j = 0; j < dsCriterios.Tables[0].Rows.Count; j++)
        {
            dr = dt.NewRow();
            for (int i = 0; i < dsAluno.Tables[0].Rows.Count + 1; i++)
            {
                if (i == 0)
                {
                    dr[" "] = dsCriterios.Tables[0].Rows[j]["cge_nome"].ToString();
                }else{
                    txbNotas = new TextBox();
                    txbNotas.ID = "txtNotas" + (i-1) + (j);
                    txbNotas.CssClass = "text";
                    txbNotas.Attributes["type"] = "Number";
                    txbNotas.Attributes["min"] = "1";
                    txbNotas.Attributes["max"] = "10";
                    txbNotas.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    txbNotas.Attributes["onkeyup"] = "funcaoImpedirValor(this.id);";
                    dr[dsAluno.Tables[0].Rows[i - 1]["pes_nome"].ToString()] = (TextBox)txbNotas;
                }
            }
            dt.Rows.Add(dr);
        }


        gdvAvaliarGrupo.DataSource = dt;
        gdvAvaliarGrupo.DataBind();

    }
}
