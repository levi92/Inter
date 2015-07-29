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

        public static int Insert(string sqlInsert)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO eve_eventos(eve_codigo, pri_codigo, eve_data, eve_tipo, eve_usuario) VALUES" + sqlInsert;
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

        public static DataSet SelectEventosPI(int codPIAtivo)
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM EVE_EVENTOS WHERE pri_codigo = ?pri_codigo ", objConnection);
            objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", codPIAtivo));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }



    }
}
