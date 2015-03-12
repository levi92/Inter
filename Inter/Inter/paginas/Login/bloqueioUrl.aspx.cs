using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Login_bloqueioUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Paginas/Login/login.aspx");
    }
}