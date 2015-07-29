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
        if ((Session["login"] == null) || (Session["menu"].ToString() != "master")) //SE A SESSÃO FOR NULA OU SE A SESSÃO NÃO FOR DE UM MASTER
        {
            Response.Redirect("~/BloqueioUrl"); //VAI PARA A PAGINA DE BLOQUEIO URL
        }

        // CHAMAR A MASTER PAGE CORRESPONDENTE MASTER ou COORD   
        this.Page.MasterPageFile = Funcoes.chamarMasterPage_Admin(Session["menu"].ToString()); //CARREGA A MASTERPAGE DO MENU DE MASTER
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager1.RegisterAsyncPostBackControl(lkbConfirmaSenha);
        CarregaGrid();
        if (!IsPostBack)
        {
            if (Session["esperandoDownload"] != null) //verifica se a sessão não está nula
            {
                Session["esperandoDownload"] = null; //garante que o download não inicie quando entrar pela primeira vez na página
            }

            lblMsgModal.Text = ""; //limpa o texto da modal
            lblMsgModal.Style.Remove("color"); //remove a cor do texto da modal
            lblMsgModal2.Text = ""; //limpa o texto da modal
            lblMsgModal2.Style.Remove("color"); //remove a cor do texto da modal
            
    }

    }

    protected void CarregaGrid()
    {
        lblQtdRegistros.Style.Remove("color"); //remove a cor vermelha da label de Registros Encontrados
        string caminho = pegaDirBackup(); //usa o método para pegar o diretório dos backups ou criar caso não exista e coloca o caminho numa string
        string[] arquivos = Funcoes.tratarArquivosBackup(caminho); //usa uma função para pegar os arquivos no diretório e organizá-los na ordem certa dentro de um vetor de strings
        int qtd = arquivos.Length; //verifica o tamanho do vetor e armazena na varíavel qtd
        if (qtd > 0) //se qtd for maior que 0
        {
            gdvBkp.DataSource = arquivos; //define a fonte de dados da grid Backup como o vetor de arquivos
            gdvBkp.DataBind(); //vincula os dados do vetor ao Gridview
            lblQtdRegistros.Text = "Foram encontrados " + qtd + " registros"; //exibe quantos arquivos de backup existem
        }
        else
        {
            lblQtdRegistros.Style.Add("color", "red");
            lblQtdRegistros.Text = "<span class='glyphicon glyphicon-warning-sign'></span>&nbsp" + "Nenhum backup foi encontrado! Seu sistema está em risco! Faça um backup AGORA!"; //ícone de aviso para fazer backup
        }

    }

    protected void gdvBkp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBkp.PageIndex = e.NewPageIndex; //troca a página da Grid conforme onde o usuário clicou
        CarregaGrid(); //Carrega a grid novamente
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
        return caminho; //retorna o caminho

    }

    protected void btnCriarBackup_Click(object sender, EventArgs e)
    {

        //string database = "inter";
        string constring = ConfigurationManager.AppSettings["strConexao"]; //pega os dados do banco do Web.config
        string database = constring.Substring(9, 5); //corta a string dos dados do banco e pega somente o nome do banco (posicao 9, inter = 5 letras)
        string nome_arquivo = "bkp_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql"; //faz o nome do arquivo baseado no nome do banco e data local
        string directory = (Request.PhysicalApplicationPath + "Backup"); //solicita o caminho da aplicação e coloca numa string juntando com Backup
        string file = (directory + "\\" + nome_arquivo); //coloca o caminho completo do arquivo + nome do arquivo separando com \\


        using (MySqlConnection conn = new MySqlConnection(constring)) //instancia um novo objeto MySqlConnection usando os dados do banco contidos em constring
        {
            using (MySqlCommand cmd = new MySqlCommand()) //instancia um novo MySqlCommand
            {
                using (MySqlBackup mb = new MySqlBackup(cmd)) //instancia um novo MySqlBackup e usa o command de antes como parâmetro
                {
                    cmd.Connection = conn; //define o comando Conection
                    conn.Open(); //abre a conexão com o banco
                    try //tenta
                    {
                        mb.ExportToFile(file); //CRIAR O BACKUP

                        lblBackup.Text = "Backup efetuado com sucesso!";
                    }
                    catch (Exception ex) //caso algo dê errado
                    {
                        lblBackup.Text = "Erro ao criar Backup!";
                    }
                    conn.Close();  //FECHA A CONEXÃO COM O BANCO, NÃO É NECESSÁRIO O DISPOSE(LIMPAR DA MEMÓRIA) POR USAR USING LÁ EM CIMA

                }
            }
        }


        CarregaGrid(); //Carrega a grid novamente
        UpdatePanelBkp.Update(); //atualiza o UpdatePanel;

        string caminho = pegaDirBackup(); //PEGA O DIRETORIO DOS BACKUPS
        string[] arquivos = Funcoes.tratarArquivosBackup(caminho); //TRATA O NOME DOS BACKUPS

        //if (arquivos[0] == nome_arquivo.Replace(".sql", "")) // Verifica se o Backup foi realmente criado
        //{
        //    //lblBackup.Text = "Backup efetuado com sucesso!";
        //}
        //else
        //{
        //    //lblBackup.Text = "Erro ao criar Backup!";
        //}


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
            Session["caminhoArquivo"] = caminhoDoArquivo; //armazena o caminhoDoArquivo numa sesão para facilitar o uso nessa página
            Session["acaoBackup"] = "Download"; //armazena uma sessão com a ação do usuário para ser usada no método de confirmar a senha

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); //ABRE A MODAL DE CONFIRMAR A SENHA (VER MÉTODO lkbConfirmaSenha_Click abaixo)



        }

        if (e.CommandName == "bkpRestaurar")
        {

            string caminho = pegaDirBackup(); //PEGA O DIRETORIO DOS BACKUPS
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //pega a linha da grid pela fonte do comando
            string arquivo = gdvBkp.Rows[gvr.RowIndex].Cells[0].Text; //pega nome do arquivo daquela linha do gridview
            string caminhoDoArquivo = caminho + arquivo + ".sql"; //junta o diretório + nome do arquivo
            Session["caminhoArquivo"] = caminhoDoArquivo;
            Session["acaoBackup"] = "Restauracao";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected static int c = 1; //instancia uma varíavel c para contar quantas vezes o usuário errou a senha
    protected void lkbConfirmaSenha_Click(object sender, EventArgs e) //EVENTO QUE VALIDA A SENHA DO MASTER AO CLICAR EM CONFIRMAR
    {

        string senha = txtSenha.Text; //pega o valor digita no campo senha e armazena na string senha

        if (!String.IsNullOrEmpty(senha)) //verifica se o campo de senha está fazio
        {
            if (Funcoes_DB.ValidaSenha(senha) == 1) //VERIFICA SE A FUNÇÃO DE VALIDAR RETORNOU 1
            {
                c = 1;
                string caminhoArquivo = Session["caminhoArquivo"].ToString(); //PEGA O CAMINHO DO ARQUIVO DA VARÍAVEL DE SESSÃO
                string acao = Session["acaoBackup"].ToString(); //PEGA A AÇÃO DO USUÁRIO (DOWNLOAD OU BACKUP) E COLOCA NUMA STRING acao
                if (acao == "Download") //SE A ACAO FOR DOWNLOAD (SE CLICOU NO BOTÃO DOWNLOAD)
                {
                    PostBackTrigger trigger = new PostBackTrigger(); //INSTANCIA UMA NOVA TRIGGER QUE RECARREGARÁ A PÁGINA (NECESSÁRIO PARA FAZER O DOWNLOAD)
                    trigger.ControlID = timerDownload.UniqueID; //DEFINE QUE O CONTROLE timerDownload IRÁ FAZER O POSTABACK(RECARREGAMENTO) DA PÁGINA
                    UpdatePanelModal.Triggers.Add(trigger); //ADICIONA A TRIGGER AO UPDATEPANEL DA MODAL
                    lblMsgModal.Style.Add("color", "green"); //DEIXA O TEXTO DA MODAL VERDE
                    lblMsgModal.Text = "Seu download iniciará em breve..."; //COLOCA A MENSAGEM DE INICANDO DOWNLAOD
                    timerDownload.Enabled = true; /*HABILITA O CONTADOR DO DOWNLOAD: QUANDO O TEMPO ESGOTAR, SERÁ DISPARADO O MÉTODO timerDownload_Tick 
                                                   * ESSE MÉTODO ESTÁ QUASE NO FIM DA PÁGINA
                                                  */
                    Session["esperandoDownload"] = "sim"; //DEFINE UMA VARÍAVEL DE SESSÃO PARA CONTROLAR SE UM DOWNLOAD É ESPERADO OU NÃO
                }
                else if (acao == "Restauracao") //SE A ACAO FOR RESTAURAÇÃO (SE CLICOU NO BOTÃO RESTAURAR)
                {
                    string constring = ConfigurationManager.AppSettings["strConexao"]; //pega os dados do banco do Web.config
                    string database = constring.Substring(9, 5); //corta a string dos dados do banco e pega somente o nome do banco (posicao 9, inter = 5 letras)
                    string nome_arquivo = "bkpSec_" + database + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql"; //faz o nome do arquivo baseado no nome do banco e data local
                    string directory = (Request.PhysicalApplicationPath + "Backup"); //solicita o caminho da aplicação e coloca numa string juntando com Backup

                    //COMEÇA O PROCESSO DE BACKUP DE SEGURANÇA ---------->
                    string file = (directory + "\\" + nome_arquivo);
                    using (MySqlConnection conn = new MySqlConnection(constring)) //instancia um novo objeto MySqlConnection usando os dados do banco contidos em constring
                    {
                        using (MySqlCommand cmd = new MySqlCommand()) //instancia um novo MySqlCommand
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd)) //instancia um novo MySqlBackup e usa o command de antes como parâmetro
                            {
                                cmd.Connection = conn; //define o comando Conection
                                conn.Open(); //abre a conexão com o banco
                                try //tenta
                                {
                                    mb.ExportToFile(file); //CRIAR O BACKUP
                                    lblMsgModal.Style.Add("color", "green");
                                    lblMsgModal.Text = "Backup de segurança efetuado com sucesso!";
                                }
                                catch (Exception ex) //CASO NÃO CONSIGA CRIAR O BACKUP DE SEGURANÇA
                                {
                                    UpdatePanelBkp.Update();
                                    lblMsgModal.Style.Add("color", "#960d10");
                                    lblMsgModal.Text = "Erro ao criar Backup de Segurança! Cancelando a Restauração;"; //MENSAGEM DE ERRO
                                    conn.Close();
                                    System.Threading.Thread.Sleep(1000);
                                    Response.Redirect("~/Configuracoes"); //RECARREGA A PÁGINA
                                }
                                conn.Close(); //FECHA A CONEXÃO COM O BANCO, NÃO É NECESSÁRIO O DISPOSE(LIMPAR DA MEMÓRIA) POR USAR USING LÁ EM CIMA
                            }
                        }
                    }
                    CarregaGrid();
                    UpdatePanelBkp.Update();

                    string caminho = pegaDirBackup();
                    string[] arquivos = Funcoes.tratarArquivosBackup(caminho);

                    //<---------------- TERMINA O BACKUP DE SEGURANÇA
                    if (arquivos[0] == nome_arquivo.Replace(".sql", "")) // Verifica se o Backup foi realmente criado
                    {


                        lblMsgModal2.Text = "Backup de segurança efetuado com sucesso!";

                        if (Funcoes_DB.DropDatabase() == 0)
                        {
                            using (MySqlConnection conn = new MySqlConnection(constring)) //instancia um novo objeto MySqlConnection usando os dados do banco contidos em constring
                            {
                                using (MySqlCommand cmd = new MySqlCommand()) //instancia um novo MySqlCommand
                                {
                                    using (MySqlBackup mb = new MySqlBackup(cmd)) //abre a conexão com o banco
                                    {
                                        cmd.Connection = conn; //define o comando Conection
                                        conn.Open(); //abre a conexão com o banco
                                        try //TENTA
                                        {

                                            mb.ImportFromFile(caminhoArquivo); //RESTAURA O SISTEMA USANDO O BACKUP CLICADO
                                            lblMsgModal2.Style.Add("color", "green");
                                            lblMsgModal2.Text = "Sistema Restaurado com sucesso!";
                                        }
                                        catch (Exception ex)
                                        {
                                            lblMsgModal2.Style.Add("color", "#960d10");
                                            lblMsgModal2.Text = "Erro ao restaurar Backup";
                                        }
                                        conn.Close();  //FECHA A CONEXÃO COM O BANCO, NÃO É NECESSÁRIO O DISPOSE(LIMPAR DA MEMÓRIA) POR USAR USING LÁ EM CIMA
                                    }
                                }
                            }
                        }



                    }
                }
            }
            else
            {
                if (c == 3) //SE HOUVE MAIS DE 3 TENTATIVAS DE CONFIRMAÇÃO DE SENHA
                {
                    c = 1; //RESETA A VARÍAVEL DE CONTROLE
                    Session.RemoveAll(); //REMOVE E LIMPA TODAS SESSÕES
                    Response.Redirect("~/Login"); //REDIRECIONA PARA A PÁGINA DE LOGIN
                }
                else //CASO AINDA NÃO ERROU 3 VEZES
                {
                    lblMsgModal.Style.Add("color", "#960d10");
                    lblMsgModal.Text = "Senha incorreta!";
                    c++; //AUMENTA O NÚMERO DE VEZES QUE A SENHA DIGITADA FOI INCORRETA EM 1
                }
            }


            
        }
        else
        {
            lblMsgModal.Style.Add("color", "#960d10");
            lblMsgModal.Text = "O campo senha deve ser preenchido!";
        }

        
    }

    protected void timerDownload_Tick(object sender, EventArgs e) //ESSE MÉTODO INICIA O DOWNLOAD E FAZ O RECARREGAMENTO DA PÁGINA NECESSÁRIO PARA O DOWNLOAD
    {
        if(Session["esperandoDownload"].ToString()=="sim"){ //VERIFICA PELA VARÍAVEL DE SESSÃO SE UM DOWNLOAD ESTÁ SENDO ESPERADO, SE SIM, CONTINUA
        Session["esperandoDownload"] = "nao"; //JÁ MUDA A VARÍAVEL PARA "NÃO", PARA NÃO ENTRAR EM LOOP INFINITO
        string caminhoArquivo = Session["caminhoArquivo"].ToString(); //PEGA O CAMINHO DO ARQUIVO DE BAKCUP PELA VARÍAVEL DE SESSÃO
        FileInfo file = new FileInfo(caminhoArquivo); //INSTANCIA UM NOVO FILEINFO(INFORMAÇÕES DO ARQUIVO) E USA COMO PARÂMETRO O CAMINHO COMPLETO DO NOSSO ARQUIVO DE BACKUP
        //PROCESSO DE COMEÇAR UMA NOVA RESPOSTA HTTP DO SERVIDOR PARA O CLIENTE ----->
        Response.Clear(); //LIMPA TODAS RESPOSTAS NA MÉMORIA 
        Response.ClearHeaders(); //LIMPA TODOS CABEÇALHOS DA MEMÓRIA
        Response.ClearContent(); //LIMPA TODO O CONTEÚDO DA MEMÓRIA
        Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name); //ADICIONA NO CABEÇALHO UM CAMPO DO TIPO CONTENT-DISPOSITION E USA COMO PARÂMETRO NOSSO ARQUIVO DE BACKUP
        Response.AddHeader("Content-Length", file.Length.ToString()); //PEGA O TAMANHO DO ARQUIVO E PASSA PARA O CAMPO TAMANHO DO CONTEÚDO DO CABEÇALHO
        Response.ContentType = "text/plain"; //DEFINE O TIPO DE ARQUIVO DAQUELE CONTEÚDO (.SQL É UM ARQUIVO TEXTO)
        Response.Flush(); //ENVIA O OUTPUT ARMAZENADO EM MEMÓRIA PARA O CLIENTE 
        Response.TransmitFile(file.FullName); //TRANSMITE O ARQUIVO DIRETAMENTE PARA O CLIENTE (O NAVEGADOR)
        Response.End(); //TERMINA O PROCESSO, PARANDO A EXECUÇÃO DA PÁGINA (É NESSE MOMENTO QUE APARECE A JANELA DE SALVAR ARQUIVO)
        
        }
        else
        {
            lblMsgModal.Text = "";
            lblMsgModal.Style.Remove("color");
            timerDownload.Enabled = false; //CASO NÃO HAJA NENHUM DOWNLOAD ESPERANDO, DESABILITA O CONTADOR - ASSIM SÓ SE FAZ UM DOWNLOAD
        }
        

    }
    protected void btnCancelarConfirmaSenha_Click(object sender, EventArgs e) //FECHA A MODAL
    {
        //LIMPANDO OS TEXTOS E REMOVENDO AS CORES 
        txtSenha.Text = "";
        lblMsgModal.Text = "";
        lblMsgModal2.Text = "";
        lblMsgModal2.Style.Remove("color");
        lblMsgModal.Style.Remove("color");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "fechaModalClick()", true); //ACIONA A FUNÇÃO javascript fechaModalClick() QUE FECHA A MODAL
    }
}