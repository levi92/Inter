using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{
    public class Eventos_DB
    {

        public static int Insert(Eventos eve)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO eve_eventos(eve_codigo, pri_codigo, eve_data, eve_tipo, eve_usuario) VALUES(0, ?pri_codigo, ?eve_data, ?eve_tipo, ?eve_usuario)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", eve.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_data", eve.Eve_data));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_tipo", eve.Eve_tipo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_usuario", eve.Eve_usuario));
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
