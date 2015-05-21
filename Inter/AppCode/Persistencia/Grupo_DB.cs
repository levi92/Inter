using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{
    public class Grupo_DB
    {

        public static int Insert(Grupo gru)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO gru_grupo(gru_codigo, pri_codigo, gru_nome_projeto, gru_media, gru_finalizado) VALUES(?gru_codigo, ?pri_codigo, ?gru_nome_projeto, ?gru_media, ?gru_finalizado)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo",gru.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", gru.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_nome_projeto", gru.Gru_nome_projeto));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_media", gru.Gru_media));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_finalizado", gru.Gru_finalizado));
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
