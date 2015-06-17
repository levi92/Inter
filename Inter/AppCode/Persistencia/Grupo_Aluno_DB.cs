using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{
    public class Grupo_Aluno_DB
    {
        public static int Insert(Grupo_Aluno gal)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO gal_grupo_aluno(alu_matricula, gru_codigo, gal_usuario) VALUES(?alu_matricula, ?gru_codigo, ?gal_usuario)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", gal.Alu_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo",gal.Gru_codigo.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gal_usuario", gal.Gal_usuario));
                objCommand.ExecuteNonQuery();
                conexao.Close();
                objCommand.Dispose();
                conexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        //SELECIONANDO TODAS AS MATRICULAS DOS ALUNOS CONTIDOS EM DETERMINADO GRUPO
        public static string[] SelectAllMatriculaByGrupo(int codGrupo)
        {
            try
            {
                string[] codAlunos;
                string codAlunosTemp = "";
                IDbConnection objConnection;
                IDbCommand objCommand;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommand = Mapped.Command("SELECT GA.ALU_MATRICULA FROM GAL_GRUPO_ALUNO GA INNER JOIN GRU_GRUPO GR USING(GRU_CODIGO) WHERE GRU_CODIGO = ?gru_codigo;", objConnection);
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", codGrupo));
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {
                    codAlunosTemp += objDataReader["ALU_MATRICULA"].ToString()+"|";
                }
                codAlunos = codAlunosTemp.Split('|');
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommand.Dispose();
                objDataReader.Dispose();
                return codAlunos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
