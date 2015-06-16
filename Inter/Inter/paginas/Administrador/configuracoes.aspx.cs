using System;
using System.Collections.Generic;
using Inter.Funcoes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Net;


public partial class paginas_Admin_configuracoes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if (Session["login"] == null)
        {
            Response.Redirect("~/BloqueioUrl");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
        CarregaGrid();

    }

    private void CarregaGrid()
    {
        string caminho = pegaDirBackup();
        string[] arquivos = Funcoes.tratarArquivosBackup(caminho);
        int qtd = arquivos.Length;
        if (qtd > 0)
        {
            gdvBkp.DataSource = arquivos;
            gdvBkp.DataBind();
            lblQtdRegistros.Text = "Foram encontrados " + qtd + " registros";
        }
        else
        {
            lblQtdRegistros.Text = "Nenhum backup foi encontrado! Seu sistema está em risco! Crie um backup AGORA!";
        }
        
    }

    private string pegaDirBackup()
    {
        string directory = (Request.PhysicalApplicationPath + "Backup"); //armazena em uma string o caminho da aplicação + a pasta Backup

        if (!Directory.Exists(directory)) //se o diretório não existe
        {
            Directory.CreateDirectory(directory); //cria o diretório
        }
        
        string caminho = (Request.PhysicalApplicationPath + "Backup\\"); //pega o caminho do diretório (com \\ pois estamos pegando o diretório "aberto") ->>>> tirar dúvida sobre isso, é isso mesmo?
        //DirectoryInfo pasta = new DirectoryInfo(caminho); //não está usando o DirectoryInfo pasta, então pra que criar?
        return caminho;

    }
   
    protected void btnCriarBackup_Click(object sender, EventArgs e)
    {

        string user = "root";
        string password = "123";
        string database = "inter";
        string server = "localhost";
        string nome_arquivo = "bkp_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql";
        string directory = (Request.PhysicalApplicationPath + "Backup");
        string caminhoDump = ("C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin\\mysqldump.exe");

        
        Process.Start(caminhoDump, ("-u " + user + " -p" + password + " -x -e -B " + database + " > -r " + directory + "\\" + nome_arquivo));
        System.Threading.Thread.Sleep(800);

        CarregaGrid();
        UpdatePanelBkp.Update();

        string caminho = pegaDirBackup();
        string[] arquivos = Funcoes.tratarArquivosBackup(caminho);

        if (arquivos[0] == nome_arquivo.Replace(".sql","")) // Verifica se o Backup foi realmente criado
        {
            lblBackup.Text = "Backup efetuado com sucesso!";
        }
        else
        {
            lblBackup.Text = "Erro ao criar Backup!";
        }

        

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

    protected void gdvBkp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "bkpDownload")
        {
            HttpResponse response = HttpContext.Current.Response;
            string caminho = pegaDirBackup();
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string arquivo = gdvBkp.Rows[gvr.RowIndex].Cells[0].Text; //pega nome do arquivo daquela linha do gridview
            string caminhoDoArquivo = caminho + arquivo + ".sql"; //junta o diretório + nome do arquivo
            FileInfo file = new FileInfo(caminhoDoArquivo);
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment;filename="+file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "text/plain";
            Response.Flush();
            Response.TransmitFile(file.FullName);
            Response.End();         
        }
    }

    protected void gdvBkp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lb = (LinkButton)e.Row.FindControl("lkbDownload"); //acha o botão download e coloca no controle lb
        if (lb != null)
        {
            ScriptManager2.RegisterPostBackControl(lb); //usando o ScriptManager, registra todos os botões de download para fazer postback (o padrão é PostBack parcial por causa do UpdatePanel, o que não deixava fazer o download!)
        }

    }

    protected void gdvBkp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBkp.PageIndex = e.NewPageIndex;
        CarregaGrid();
    }
}