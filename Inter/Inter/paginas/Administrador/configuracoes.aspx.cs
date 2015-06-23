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
using System.Security.Principal;
using System.Security.AccessControl;
using System.Configuration;

public partial class paginas_Admin_configuracoes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Se sessão estiver nula redireciona para o bloqueio Url
        if ((Session["login"] == null) || (Session["menu"].ToString() != "master"))
        {
            Response.Redirect("~/BloqueioUrl");
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString());
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        

        //ScriptManager1.RegisterPostBackControl(lkbConfirmaSenha);
        //ScriptManager1.RegisterAsyncPostBackControl(lkbConfirmaSenha);
        CarregaGrid();
        //lblMsgModal.Text = "";
        //lblMsgModal2.Text = "";
        //lblMsgModal2.Style.Remove("color");
        //lblMsgModal.Style.Remove("color");

    }

    protected void CarregaGrid()
    {
        lblQtdRegistros.Style.Remove("color");
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
            lblQtdRegistros.Style.Add("color", "red");
            lblQtdRegistros.Text = "<span class='glyphicon glyphicon-warning-sign'></span>&nbsp" + "Nenhum backup foi encontrado! Seu sistema está em risco! Crie um backup AGORA!";
        }

    }

    protected void gdvBkp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBkp.PageIndex = e.NewPageIndex;
        CarregaGrid();
    }

    private string pegaDirBackup()
    {
        string directory = (Request.PhysicalApplicationPath + "Backup"); //armazena em uma string o caminho da aplicação + a pasta Backup (não cria ainda)

        if (!Directory.Exists(directory)) //se o diretório não existe
        {
            Directory.CreateDirectory(directory); //cria o diretório
            // Pega a segurança atual da pasta

           /* DirectorySecurity oDirSec = Directory.GetAccessControl(sTmpPath);

            // Define o usuário Everyone (Todos)
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            //SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
            NTAccount oAccount = sid.Translate(typeof(NTAccount)) as NTAccount;

            oDirSec.PurgeAccessRules(oAccount);

            FileSystemAccessRule fsAR = new FileSystemAccessRule(oAccount,
                                                                 FileSystemRights.Modify,
                                                                 InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                                                 PropagationFlags.None,
                                                                 AccessControlType.Allow);

            // Atribui a regra de acesso alterada
            oDirSec.SetAccessRule(fsAR);
            Directory.SetAccessControl(sTmpPath, oDirSec);*/
        }

        string caminho = (Request.PhysicalApplicationPath + "Backup\\"); //pega o caminho do diretório (com \\ pois estamos pegando o diretório "aberto") ->>>> tirar dúvida sobre isso, é isso mesmo?
        return caminho;

    }

    protected void btnCriarBackup_Click(object sender, EventArgs e)
    {

        //string database = "inter";
        string constring = ConfigurationManager.AppSettings["strConexao"]; //pega os dados do banco do Web.config
        string database = constring.Substring(9, 5); //corta a string dos dados do banco e pega somente o nome do banco (posicao 9, inter = 5 letras)
        string nome_arquivo = "bkp_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql"; //faz o nome do arquivo baseado no nome do banco e data local
        string directory = (Request.PhysicalApplicationPath + "Backup");
        string file = (directory + "\\" + nome_arquivo);


        using (MySqlConnection conn = new MySqlConnection(constring))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {
                    mb.ExportToFile(file);

                        lblBackup.Text = "Backup efetuado com sucesso!";
                    }
                    catch (Exception ex)
                    {
                        lblBackup.Text = "Erro ao criar Backup!";
                    }
                    conn.Close();

                }
            }
        }


        CarregaGrid();
        UpdatePanelBkp.Update();

        string caminho = pegaDirBackup();
        string[] arquivos = Funcoes.tratarArquivosBackup(caminho);

        if (arquivos[0] == nome_arquivo.Replace(".sql", "")) // Verifica se o Backup foi realmente criado
        {
            //lblBackup.Text = "Backup efetuado com sucesso!";
        }
        else
        {
            //lblBackup.Text = "Erro ao criar Backup!";
        }


        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


    }

    protected void gdvBkp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "bkpDownload")
        {
            string caminho = pegaDirBackup();
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string arquivo = gdvBkp.Rows[gvr.RowIndex].Cells[0].Text; //pega nome do arquivo daquela linha do gridview
            string caminhoDoArquivo = caminho + arquivo + ".sql"; //junta o diretório + nome do arquivo         
            Session["caminhoArquivo"] = caminhoDoArquivo;
            Session["acaoBackup"] = "Download";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);



        }

        if (e.CommandName == "bkpRestaurar")
        {

            string caminho = pegaDirBackup();
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string arquivo = gdvBkp.Rows[gvr.RowIndex].Cells[0].Text; //pega nome do arquivo daquela linha do gridview
            string caminhoDoArquivo = caminho + arquivo + ".sql"; //junta o diretório + nome do arquivo
            Session["caminhoArquivo"] = caminhoDoArquivo;
            Session["acaoBackup"] = "Restauracao";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    static int c = 1;
    protected void lkbConfirmaSenha_Click(object sender, EventArgs e)
    {
        string senha = txtSenha.Text.ToString();

        if (!String.IsNullOrEmpty(senha))
        {
            if (Funcoes_DB.ValidaSenha(senha) == 1)
            {
                string caminhoArquivo = Session["caminhoArquivo"].ToString();
                string acao = Session["acaoBackup"].ToString();
                if (acao == "Download")
                {
                    FileInfo file = new FileInfo(caminhoArquivo);
                    HttpResponse response = HttpContext.Current.Response;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "text/plain";
                    Response.Flush();
                    Response.TransmitFile(file.FullName);
                    Response.End();
                }
                else if (acao == "Restauracao")
                {
                    string constring = ConfigurationManager.AppSettings["strConexao"]; //pega os dados do banco do Web.config
                    string database = constring.Substring(9, 5);
                    string nome_arquivo = "bkpSec_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql";
                    string directory = (Request.PhysicalApplicationPath + "Backup");

                    string file = (directory + "\\" + nome_arquivo);
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                try
                                {
                                mb.ExportToFile(file);
                                    lblMsgModal.Style.Add("color", "green");
                                    lblMsgModal.Text = "Backup de segurança efetuado com sucesso!";
                                }
                                catch (Exception ex)
                                {
                                    lblMsgModal.Style.Add("color", "#960d10");
                                    lblMsgModal.Text = "Erro ao criar Backup de Segurança! Cancelando a Restauração;";
                                conn.Close();
                                    System.Threading.Thread.Sleep(1000);
                                    Response.Redirect("~/Configuracoes");
                            }
                                conn.Close();
                        }
                    }
                    }
                    CarregaGrid();
                    UpdatePanelBkp.Update();

                    string caminho = pegaDirBackup();
                    string[] arquivos = Funcoes.tratarArquivosBackup(caminho);

                    if (arquivos[0] == nome_arquivo.Replace(".sql", "")) // Verifica se o Backup foi realmente criado
                    {


                        lblMsg.Text = "Backup de segurança efetuado com sucesso!";


                    using (MySqlConnection conn = new MySqlConnection(constring))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                using (MySqlBackup mb = new MySqlBackup(cmd))
                                {
                                    cmd.Connection = conn;
                                    conn.Open();
                                try
                                {

                                    mb.ImportFromFile(caminhoArquivo);
                                    lblMsgModal2.Style.Add("color", "green");
                                    lblMsgModal2.Text = "Sistema Restaurado com sucesso!";
                                }
                                catch (Exception ex)
                                {
                                    lblMsgModal2.Style.Add("color", "#960d10");
                                    lblMsgModal2.Text = "Erro ao restaurar Backup";
                                }
                                    conn.Close();
                                }
                            }
                    }

                    }
                }

            else
            {
                if (c == 3)
                {
                    c = 1;
                    //lblMsgModal2.Style.Add("color", "#960d10");
                    //lblMsgModal2.Text = "Você errou a senha muitas vezes. Faça login novamente!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert()", true);
                    Session.RemoveAll();
                    Response.Redirect("~/Login");
                }
                else
                {
                    lblMsgModal.Style.Add("color", "#960d10");
                    lblMsgModal.Text = "Senha incorreta!";
                    c++;
                }
            }


        }
        else
        {
            lblMsgModal.Style.Add("color", "#960d10");
            lblMsgModal.Text = "O campo senha deve ser preenchido!";
        }


    }
    protected void btnCancelarConfirmaSenha_Click(object sender, EventArgs e)
    {
        txtSenha.Text = "";
        lblMsgModal.Text = "";
        lblMsgModal2.Text = "";
        lblMsgModal2.Style.Remove("color");
        lblMsgModal.Style.Remove("color");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "fechaModalClick()", true);
    }
}