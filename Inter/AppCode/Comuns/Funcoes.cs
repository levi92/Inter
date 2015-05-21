using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for funcoes
/// </summary>

namespace Inter.Funcoes
{
    public class Funcoes
    {

        /// <summary>
        /// Função para verificar e retornar o caminho da master page correspondent a mãe ou filha.
        /// </summary>
        /// <param name="mae"> Recebe o que está na sessão mãe (True/False) </param>
        /// <returns> Retorna o caminho da masterpage</returns>
        public static string chamarMasterPage(string mae)
        {
            if (mae == "MAE")
            {
                return "~/paginas/Usuario/MasterPageMenuMae.master";
            }
            else
                return "~/paginas/Usuario/MasterPageMenuFilha.master";

        }

        public static string chamarMasterPage_Admin(string coord)
        {

            if (coord == "True")
            {
                return "~/paginas/Administrador/MasterPage_MenuCoord.master";
            }
            else
            {
                return "~/paginas/Administrador/MasterPage_MenuMaster.master";
            }
        }

        public static string Criptografar(string texto, string nomeHash)
        {
            //instancia a hash conforme indicado pelo método
            HashAlgorithm algoritmo = HashAlgorithm.Create(nomeHash);

            //se a hash não for inicializada, crio a excessao e retorno a msg para o usuario (throw retorn automatico)
            if (algoritmo == null)
            {
                //return "Erro ao criptografar";
                throw new ArgumentException("Nome da hash informada não é válida");

            }
            else
            {
                //divisão da hash em partes para a cirptografia
                //alocação, buffer
                //computehash... geração da criptografia
                byte[] hash = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(texto));

                //conversão da hash(byte[]) para base64, texto legível para o usuário(soft)...
                return Convert.ToBase64String(hash);
            }
        }

        //public static string Base64Codifica(string texto)
        //{
        //    byte[] stringBase64 = new byte[texto.Length];
        //    stringBase64 = Encoding.UTF8.GetBytes(texto);
        //    string codificacao = Convert.ToBase64String(stringBase64);
        //    return codificacao;
        //}

        //public static string Base64Descodifica(string texto)
        //{
        //    var encode = new UTF8Encoding();
        //    var utf8Decode = encode.GetDecoder();
        //    byte[] stringValor = Convert.FromBase64String(texto);
        //    int contador = utf8Decode.GetCharCount(stringValor, 0, stringValor.Length);
        //    char[] decodeChar = new char[contador];
        //    utf8Decode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);
        //    string descodificacao = new String(decodeChar);
        //    return descodificacao;
        //}



        //public static MandarEmail(){
        //    MailAdress para = ne MailAdress(emailDestinatario);
        //    MailMessage mensagem = new MailMessage(de, para);
        //    mensagem.IsBodyHtml = true;
        //    mensagem.Subject = assunto;
        //    mensagem.Body = corpomsg;
        //    mensagem.Priority = MailPriority.Normal;

        //    //Cria o objeto que envia o e-mail
        //    SmtpClient cliente = new SmtpClient();

        //}

        //public static string AESCodifica(string texto)

        //{
        //    //tratar a key / definir a key
        //    String FraseSeguranca = "marry";
        //    byte[] VetorTexto = Encoding.Unicode.GetBytes(texto);
        //    //vetor que recebe a variavel do metodo para a conversão futura...

        //    //AES... Atraves do using chamar a classe AES
        //    using (Aes encrypt = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes
        //        (FraseSeguranca, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65,
        //        0x64, 0x65, 0x76 });

        //        encrypt.Key = rdb.GetBytes(32);
        //        //alocar os blocs com as informacoes de chave encrypt.Key
        //        encrypt.IV = rdb.GetBytes(16);


        //    }
        //}


        public static string[] tratarDadosProfessor(string dados)
        {
            string[] cursoTurnoSemestre = dados.Split('-');
            string[] cursoTurno = cursoTurnoSemestre[0].Split(')');
            string curso_turno = cursoTurno[0] + ")";
            string semestre = cursoTurno[1].Substring(1, 1);
            string[] disciplinaGrande = cursoTurnoSemestre[2].Split('(');
            string disciplina = disciplinaGrande[0];
            string[] vetReturn = new string[3];

            vetReturn[0] = curso_turno;
            vetReturn[1] = semestre;
            vetReturn[2] = disciplina;

            return vetReturn;
        }

        public static string SplitNomes(string nome)
        {
            string[] nomes = nome.Split(' ');
            return nomes[0];
        }



    }
}