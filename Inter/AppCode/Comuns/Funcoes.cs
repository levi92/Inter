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
            if (mae == "True")
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
            if(algoritmo == null)
            {
                //return "Erro ao criptografar";
                throw new ArgumentException("Nome da hash informada não é válida");

            }
            else {
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

    }
}