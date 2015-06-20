using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{
    //semestre ano
    public class Semestre_Ano_DB
    {
        //insert 
        public static int Insert(Semestre_Ano semAno)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO san_semestre_ano(san_ano, san_semestre, san_ativo) VALUES(?san_ano, ?san_semestre, ?san_ativo)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?san_ano", semAno.San_ano));
                objCommand.Parameters.Add(Mapped.Parameter("?san_semestre", semAno.San_semestre));
                objCommand.Parameters.Add(Mapped.Parameter("?san_ativo", semAno.San_ativo));
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

        //UPDATE
        public static int Update(Semestre_Ano semAno)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "UPDATE san_semestre_ano SET san_ano = ?san_ano, san_semestre = ?san_semestre, san_ativo = ?san_ativo " +
                " WHERE san_codigo = ?san_codigo";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?san_codigo", semAno.San_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?san_ano", semAno.San_ano));
                objCommand.Parameters.Add(Mapped.Parameter("?san_semestre", semAno.San_semestre));
                objCommand.Parameters.Add(Mapped.Parameter("?san_ativo", semAno.San_ativo));
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

        //DELETE   
        public static int Delete(int codigo)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objComando;
                string sql = "DELETE FROM san_semestre_ano WHERE san_codigo = ?san_codigo ";
                conexao = Mapped.Connection();
                objComando = Mapped.Command(sql, conexao);
                objComando.Parameters.Add(Mapped.Parameter("?san_codigo", codigo));
                objComando.ExecuteNonQuery();
                conexao.Close();
                objComando.Dispose();
                conexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        //SELECT
        public static Semestre_Ano Select(int codigo)
        {
            try
            {
                Semestre_Ano objSemAno = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM san_semestre_ano WHERE san_codigo = ?san_codigo", objConnection);
                objCommnad.Parameters.Add(Mapped.Parameter("?san_codigo", codigo));
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    objSemAno = new Semestre_Ano();
                    objSemAno.San_codigo = Convert.ToInt32(objDataReader["san_codigo"]);
                    objSemAno.San_ano = Convert.ToInt32(objDataReader["san_ano"]);
                    objSemAno.San_semestre = Convert.ToInt32(objDataReader["san_semestre"]);
                    objSemAno.San_ativo = Convert.ToBoolean(objDataReader["san_ativo"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objSemAno;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //SELECT SEMESTRE ATIVO
        public static Semestre_Ano Select()
        {
            try
            {
                Semestre_Ano objSemAno = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM san_semestre_ano WHERE san_ativo = 1", objConnection);
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    objSemAno = new Semestre_Ano();
                    objSemAno.San_codigo = Convert.ToInt32(objDataReader["san_codigo"]);
                    objSemAno.San_ano = Convert.ToInt32(objDataReader["san_ano"]);
                    objSemAno.San_semestre = Convert.ToInt32(objDataReader["san_semestre"]);
                    objSemAno.San_ativo = Convert.ToBoolean(objDataReader["san_ativo"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objSemAno;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //SELECT ALL
        public static DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM san_semestre_ano ORDER BY san_ano", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }

        public static DataSet SelectSemestreAno()
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("select SAN_CODIGO, concat(SAN_ANO,'-',SAN_SEMESTRE) from san_semestre_ano ORDER BY SAN_ANO, SAN_SEMESTRE;", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }

        /*public static DataTable Sem_Ano()
        {
            using (OleDbConnection con = new OleDbConnection("Database=inter;Data Source=localhost;User id=root; Password=123;pooling=false;"))
            {
                using (OleDbDataAdapter da = new
            OleDbDataAdapter("select concat(s.SAN_ANO,'-',s.SAN_SEMESTRE) from san_semestre_ano s ORDER BY s.SAN_ANO, s.SAN_SEMESTRE", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            } 
        }*/
    }
}
