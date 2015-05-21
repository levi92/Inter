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
                string sql = "INSERT INTO gal_grupo_aluno(alu_matricula, gru_codigo) VALUES(?alu_matricula, ?gru_codigo)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", gal.Alu_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo",gal.Gru_codigo.Gru_codigo));              
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
