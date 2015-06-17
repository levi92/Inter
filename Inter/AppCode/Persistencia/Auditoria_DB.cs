using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;

namespace AppCode.Persistencia
{
    public class Auditoria_DB
    {
        public static DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("select * from aud_auditoria order by AUD_DATA desc;", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }

        public static DataSet SelectFiltro(string data, string usuario, string acao, string tabela)
        {

            string filtro = "";
            int campo = 0;
            // monta o filtro...
            if (data != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_data = " + data;
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_data = " + data;
                }
            }

            if (usuario != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_usuario = " + usuario;
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_usuario = " + usuario;
                }
            }

            if (acao != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_acao = " + acao;
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_acao = " + acao;
                }
            }

            if (tabela != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_tabela = " + tabela;
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_tabela = " + tabela;
                }
            }

            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();

            
            /*AppendFilter(filter, objCommand, "aud_data", data);
            AppendFilter(filter, objCommand, "aud_usuario", usuario);
            AppendFilter(filter, objCommand, "aud_acao", acao);
            AppendFilter(filter, objCommand, "aud_tabel", tabela);*/

            objCommand = Mapped.Command("select * from aud_auditoria where '" + filtro + "';", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }



        /*private static void AppendFilter(StringBuilder filter, System.Data.SqlClient.SqlCommand command,
        string fieldName, object paramValue)
        {
            // verifica se preencheu o valor...
            if (!string.IsNullOrEmpty(Convert.ToString(paramValue)))
            {
                // adiciona o filtro...
                if (filter.Length > 0)
                    filter.Append(" AND ");
                filter.Append(string.Format("{0} = @{0}", fieldName));
                // adiciona o parâmetro...
                command.Parameters.AddWithValue(string.Format("@{0}", fieldName), paramValue);
            }
        }*/

    }
}
