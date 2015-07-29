using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{

    public class Historico_Aluno_Disciplina_DB
    {
        public static int Insert(Historico_Aluno_Disciplina his)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO his_historico_aluno_disciplina(his_codigo, alu_matricula, cpi_codigo, his_nota, his_usuario) VALUES(0, ?alu_matricula, ?cpi_codigo, ?his_nota, ?his_usuario)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", his.Alu_matricula.Alu_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?cpi_codigo", his.Cpi_codigo.Cpi_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?his_nota", his.His_nota));
                objCommand.Parameters.Add(Mapped.Parameter("?his_usuario", his.His_usuario));
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

        public static int Insert(string sqlInsert)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO his_historico_aluno_disciplina(his_codigo, alu_matricula, cpi_codigo, his_nota, his_usuario) VALUES" + sqlInsert;
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);

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
    }

}