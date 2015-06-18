using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Globalization;

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

            if (data != "")
            {
                string[] converter = data.Split('/');
                string formatada = "";
            
                for (int c = 2; c >= 0; c--)
                {
                    if (c == 0)
                    {
                        formatada = formatada + converter[c];
                    }
                    else
                    {
                        formatada = formatada + converter[c] + "-";
                    }           
                }
             
                if (campo == 0)
                {
                    filtro = "aud_data between '" + formatada + " 00:00:00' and '" + formatada + " 23:59:59'";
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_data between '" + formatada + " 00:00:00' and '" + formatada + " 23:59:59'";
                }
            }

            if (usuario != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_usuario = '" + usuario + "'";
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_usuario = '" + usuario + "'";
                }
            }

            if (acao != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_acao = '" + acao + "'";
                    campo = campo + 1;
                }
                else
                {                  
                    filtro = filtro + "and aud_acao = '" + acao + "'";
                }
            }

            if (tabela != "")
            {
                if (campo == 0)
                {
                    filtro = "aud_tabela = '" + tabela + "'";
                    campo = campo + 1;
                }
                else
                {
                    filtro = filtro + "and aud_tabela = '" + tabela + "'";
                }
            }

            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            string sql = "select a.aud_data, a.aud_usuario, a.aud_acao, a.aud_tabela, a.aud_dados_antes, a.aud_dados_depois from aud_auditoria a where " + filtro + ";";
            objCommand = Mapped.Command(sql, objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            
            return ds;
        }
    }
}
