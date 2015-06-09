using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AppCode.Persistencia
{
    public class Atribuicao_PI_DB{


        public static int Insert(Atribuicao_PI atr)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO api_atribuicao_pi(pri_codigo, adi_codigo) VALUES(?pri_codigo, ?adi_codigo)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", atr.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", atr.Adi_codigo));
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
