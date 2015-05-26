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
                string sql = "INSERT INTO gru_grupo(gru_codigo, pri_codigo, gru_nome_projeto, gru_media, gru_finalizado) VALUES(?gru_codigo, ?pri_codigo, ?gru_nome_projeto, null, 0)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", gru.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", gru.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_nome_projeto", gru.Gru_nome_projeto));
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

        //SELECT ULTIMO CODIGO
        public static int SelectUltimoCod()
        {
            try
            {
                int ultimoCod = 0;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT MAX(GRU_CODIGO) FROM GRU_GRUPO", objConnection);
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    ultimoCod = Convert.ToInt32(objDataReader["Max(gru_codigo)"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return ultimoCod;
            }
            catch (Exception e)
            {
                return -2;
            }
        }


    }
}
