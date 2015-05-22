using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inter.Funcoes;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;


public partial class paginas_Admin_configuracoes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["login"] == null)
        {
            Response.Redirect("~/Paginas/Login/bloqueioUrl.aspx");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["coord"].ToString());
    }

    protected void btnCriarBackup_Click(object sender, EventArgs e)
    {

        string user = "root";
        string password = "123";
        string database = "inter";
        string server = "localhost";
        string nome_arquivo = "bkp_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql";
        string directory = (Request.PhysicalApplicationPath+"Backup");

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        
        Process.Start("C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin\\mysqldump.exe",("-u " + user + " -p" + password + " -x -e -B " + database + " > -r " + directory + "\\" + nome_arquivo));


        /*string constring = ("server=" + server + ";user=" + user + ";database=" + database + ";password=" + password);
        string file = (directory + "\\" + nome_arquivo);
        using (MySqlConnection conn = new MySqlConnection(constring))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    mb.ExportToFile(file);
                    conn.Close();
                }
            }
        }*/
    }
}