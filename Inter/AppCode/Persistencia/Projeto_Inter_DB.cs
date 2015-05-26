using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//projeto inter
    public class Projeto_Inter_DB
    {
        //INSERT
        public static int Insert(Projeto_Inter proInt)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO pri_projeto_inter(pri_codigo, san_codigo) VALUES(?pri_codigo, ?san_codigo)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", proInt.Pri_codigo));  
                objCommand.Parameters.Add(Mapped.Parameter("?san_codigo", proInt.San_codigo.San_codigo));
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
        public static int Update(Projeto_Inter proInt)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "UPDATE pri_projeto_inter SET san_semestre_ano = ?san_semestre_ano, pri_descricao = ?pri_descricao,  pri_ementa = ?pri_ementa, adi_codigo = ?adi_codigo" +
                " WHERE pri_codigo = ?pri_codigo";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?san_semestre_ano", proInt.San_codigo));
                //objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", proInt.Adi_codigo));
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
                string sql = "DELETE FROM pri_projeto_inter WHERE pri_codigo = ?pri_codigo ";
                conexao = Mapped.Connection();
                objComando = Mapped.Command(sql, conexao);
                objComando.Parameters.Add(Mapped.Parameter("?pri_codigo", codigo));
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
        public static Projeto_Inter Select(int codigo)
        {
            try
            {
                Projeto_Inter objProInt = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM pri_projeto_inter WHERE pri_codigo = ?pri_codigo", objConnection);
                objCommnad.Parameters.Add(Mapped.Parameter("?san_codigo", codigo));
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    objProInt = new Projeto_Inter();
                    objProInt.Pri_codigo = Convert.ToInt32(objDataReader["pri_codigo"]);
                    objProInt.San_codigo.San_codigo = Convert.ToInt32(objDataReader["san_semestre_ano"]);
                    //objProInt.Adi_codigo.Adi_codigo = Convert.ToInt32(objDataReader["adi_codigo"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objProInt;
            }
            catch (Exception e)
            {
                return null;
            }
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
                objCommnad = Mapped.Command("SELECT MAX(PRI_CODIGO) FROM PRI_PROJETO_INTER", objConnection);
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    ultimoCod = Convert.ToInt32(objDataReader["Max(pri_codigo)"]);
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

        //SELECT ALL
        public static DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pri_projeto_inter ORDER BY pri_codigo", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }

        //SELECT CODIGO DO PI ATUAL ATIVO DA MATÉRIA
        public static int SelectCodPiAtivoMateria(int codAtribuicaoMateria)
        {
            try
            {
                int codPiAtivo = 0;
                IDbConnection objConnection;
                IDbCommand objCommand;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommand = Mapped.Command("SELECT PR.PRI_CODIGO FROM SAN_SEMESTRE_ANO SA INNER JOIN PRI_PROJETO_INTER PR USING(SAN_CODIGO) INNER JOIN API_ATRIBUICAO_PI USING(PRI_CODIGO) WHERE ADI_CODIGO = ?adi_codigo AND SA.SAN_ATIVO = 1;", objConnection);
                objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", codAtribuicaoMateria));
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {
                    codPiAtivo = Convert.ToInt32(objDataReader["PRI_CODIGO"]);
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommand.Dispose();
                objDataReader.Dispose();
                return codPiAtivo;
            }
            catch (Exception e)
            {
                return -2;
            }
        }
    }


