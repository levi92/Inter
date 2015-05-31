using Interdisciplinar;
using System;
using System.Collections.Generic;
using System.Data;
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


        //JOGA O NOMES DOS ALUNOS EM UM VETOR DEPENDENDO DE SUA MATRICULA
        public static string[] NomeAlunosByMatricula(string[] codAlunos)
        {
            string[] nomeAlunos = new string[codAlunos.Length - 1];
            for (int i = 0; i < codAlunos.Length - 1; i++)
            {
                Aluno alu = new Aluno();
                alu = Aluno.SelecionarAluno(codAlunos[i]);
                nomeAlunos[i] = alu.Nome;
            }

            return nomeAlunos;
        }

        public static string[] MateriasByCodigo(string[] adiMatricula)
        {
            string[] materias = new string[adiMatricula.Length - 1];
            for (int i = 0; i < adiMatricula.Length - 1; i++)
            {
                Disciplina dis = new Disciplina();
                dis = Disciplina.SelectByCodigo(adiMatricula[i]);
                materias[i] = dis.Nome + i;
            }
            return materias;
        }

        public static string[] tratarDadosCursosComPI(DataSet ds, int qtdPIs)
        {
            string[] vetorReturnFunction = new string[3];
            string[] cursosRepetidos = new string[qtdPIs];
            string[] cursos = new string[5];

            for (int j = 0; j < qtdPIs; j++)
            {
                vetorReturnFunction = Funcoes.tratarDadosProfessor(ds.Tables[0].Rows[j]["disciplina"].ToString());
                cursosRepetidos[j] = vetorReturnFunction[0];

            }
            int i = 0;
            foreach (string nome in cursosRepetidos)
            {
                if (!cursos.Contains(nome))
                {
                    cursos[i] = nome;
                    i++;
                }
            }


            return cursos;
        }

        public static int SelectCodPIAtivoByAtr(int codAtr)
        {
            try
            {
                int codPIAtivo = 0;
                IDbConnection objConnection;
                IDbCommand objCommand;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommand = Mapped.Command("SELECT PI.PRI_CODIGO FROM API_ATRIBUICAO_PI AP INNER JOIN PRI_PROJETO_INTER PI USING(PRI_CODIGO) INNER JOIN SAN_SEMESTRE_ANO SA USING(SAN_CODIGO) WHERE SA.SAN_CODIGO = 1 AND AP.ADI_CODIGO = ?codAtr;", objConnection);
                objCommand.Parameters.Add(Mapped.Parameter("?codAtr", codAtr));
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {
                    codPIAtivo = Convert.ToInt32(objDataReader["pri_codigo"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommand.Dispose();
                objDataReader.Dispose();
                return codPIAtivo;
            }
            catch (Exception e)
            {
                return -2;
            }
        }

        public static string[] SelectAtrDisciplinasEnvolvidas(int codPIAtivo)
        {
               try
                {
                    string codAtrPipe = "";
                    string[] codAtr;
                    IDbConnection objConnection;
                    IDbCommand objCommand;
                    IDataReader objDataReader;
                    objConnection = Mapped.Connection();
                    objCommand = Mapped.Command("SELECT AP.ADI_CODIGO FROM API_ATRIBUICAO_PI AP LEFT JOIN PRI_PROJETO_INTER PI USING(PRI_CODIGO) WHERE PI.PRI_CODIGO = ?codPIAtivo;", objConnection);
                    objCommand.Parameters.Add(Mapped.Parameter("?codPIAtivo", codPIAtivo));
                    objDataReader = objCommand.ExecuteReader();
                    while (objDataReader.Read())
                    {
                        codAtrPipe += objDataReader["adi_codigo"].ToString() + "|";
                    }
                    codAtr = codAtrPipe.Split('|');
                    objDataReader.Close();
                    objConnection.Close();
                    objConnection.Dispose();
                    objCommand.Dispose();
                    objDataReader.Dispose();
                    return codAtr;
                }
                catch (Exception e)
                {
                    return null;
                }
            }           
        

        public static double CalcularMediaPonderadaAlunoDisciplinas(int codPIAtivo, string codAluno, int codDisc)
        {
            try
            {
                double NotasXPesos = 0;
                int somaPesos = 0;
                double media = 0;
                double nota = 0;
                int peso = 0;
                IDbConnection objConnection;
                IDbCommand objCommand;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommand = Mapped.Command("SELECT HI.HIS_NOTA, CP.CPI_PESO FROM HIS_HISTORICO_ALUNO_DISCIPLINA HI INNER JOIN CPI_CRITERIO_PI CP USING(CPI_CODIGO) WHERE CP.PRI_CODIGO = ?codPIAtivo AND CP.ADI_CODIGO = ?codDisc AND HI.ALU_MATRICULA = ?codAluno;", objConnection);
                objCommand.Parameters.Add(Mapped.Parameter("?codPIAtivo", codPIAtivo));
                objCommand.Parameters.Add(Mapped.Parameter("?codAluno", codAluno));
                objCommand.Parameters.Add(Mapped.Parameter("?codDisc", codDisc));
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {
                    nota = Convert.ToDouble(objDataReader["his_nota"]);
                    peso = Convert.ToInt32(objDataReader["cpi_peso"]);                    
                    NotasXPesos += nota * peso;
                    somaPesos += peso;
                }
                media = NotasXPesos / somaPesos;
                if (media>=0 && media<=10)
                {
                    media = media;
                }
                else
                {
                    media = 0;
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommand.Dispose();
                objDataReader.Dispose();
                return Math.Round(media,2);
            }
            catch (Exception e)
            {
                return -2;
            }
        }




    }
}