using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class paginas_Admin_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/BloqueioUrl");
            }
            if (!IsPostBack)
            {
                string perfil = Session["menu"].ToString().ToUpper();
                if (perfil.Equals("COORDENADOR"))
                {
                    perfil = "COORD.";
                }
                lblPerfilLogado.Text = "Entrou como " + perfil + "&nbsp" + Inter.Funcoes.Funcoes.SplitNomes(Session["nome"].ToString().ToUpper())+".";
            }
        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect("~/Login");
        }
        
    }
