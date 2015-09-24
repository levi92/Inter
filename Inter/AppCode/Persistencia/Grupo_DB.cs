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
                string sql = "INSERT INTO gru_grupo(gru_codigo, pri_codigo, gru_nome_projeto, gru_media, gru_finalizado, gru_usuario) VALUES(?gru_codigo, ?pri_codigo, ?gru_nome_projeto, null, 0, ?gru_usuario)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", gru.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", gru.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_nome_projeto", gru.Gru_nome_projeto));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_usuario", gru.Gru_usuario));
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
                string sql = "INSERT INTO gru_grupo(gru_codigo, pri_codigo, gru_nome_projeto, gru_media, gru_finalizado, gru_usuario) VALUES" + sqlInsert;
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

        //SELECT GRUPOS DO SEMESTRE ATUAL PARA A PÁGINA DE AVALIAÇÃO
        public static DataSet SelectAllGruposAvaliar(int codPi, int atrCod)
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT GR.GRU_CODIGO, GR.GRU_NOME_PROJETO FROM GRU_GRUPO GR INNER JOIN PRI_PROJETO_INTER PR USING(PRI_CODIGO) INNER JOIN API_ATRIBUICAO_PI AP USING(PRI_CODIGO) WHERE PR.PRI_CODIGO = ?PRI_CODIGO AND GR.GRU_FINALIZADO = 0 AND AP.ADI_CODIGO = ?ADI_CODIGO AND GR.GRU_CODIGO NOT IN(SELECT MD.GRU_CODIGO FROM MDD_MEDIA_DISCIPLINA MD WHERE MD.ADI_CODIGO = ?ADI_CODIGO);", objConnection);
            objCommand.Parameters.Add(Mapped.Parameter("?PRI_CODIGO", codPi));
            objCommand.Parameters.Add(Mapped.Parameter("?ADI_CODIGO", atrCod));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = null;
            }
            return ds;
        }

        //SELECT GRUPOS PARA A PAGINA DE FINALIZAR
        public static DataSet SelectAllGruposFinalizar(int codPi, int atrCod)
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT GR.GRU_CODIGO, GR.GRU_NOME_PROJETO, MD.MDD_MEDIA FROM GRU_GRUPO GR INNER JOIN MDD_MEDIA_DISCIPLINA MD USING(GRU_CODIGO) INNER JOIN API_ATRIBUICAO_PI AP USING(ADI_CODIGO) WHERE AP.PRI_CODIGO = ?pri_codigo AND GR.GRU_FINALIZADO = 0 AND MD.MDD_MEDIA>=0 AND AP.ADI_CODIGO = ?adi_codigo;", objConnection);
            objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", codPi));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", atrCod));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = null;
            }
            return ds;
        }

        //SELECT GRUPOS PARA A PAGINA DE CONSULTAR PI
        public static DataSet SelectAllGruposAtual(int codPi, int atrCod)
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT GR.GRU_CODIGO, GR.GRU_NOME_PROJETO FROM GRU_GRUPO GR INNER JOIN PRI_PROJETO_INTER PR USING(PRI_CODIGO) INNER JOIN API_ATRIBUICAO_PI AP USING(PRI_CODIGO) WHERE PR.PRI_CODIGO = ?pri_codigo AND AP.ADI_CODIGO = ?adi_codigo;", objConnection);
            objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", codPi));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", atrCod));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = null;
            }
            return ds;
        }

        public static DataSet SelectAllGruposFinalizadosAtual(int atrCod)
        {
            DataSet ds = new DataSet();
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("select gru.gru_codigo, gru.gru_nome_projeto from gru_grupo gru inner join gru_grupo gru2 inner join pri_projeto_inter pri on gru.pri_codigo = pri.pri_codigo inner join api_atribuicao_pi api on pri.pri_codigo = api.pri_codigo and api.adi_codigo = ?adi_codigo and gru.gru_finalizado = 1 group by gru.gru_codigo;", objConnection);            
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", atrCod));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
        }

        public static int UpdateGrupoAvaliado(Grupo gru)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "UPDATE gru_grupo SET gru_finalizado = 1, gru_media = ?gru_media, gru_usuario = ?gru_usuario WHERE gru_codigo = ?gru_codigo";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", gru.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_media", gru.Gru_media));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_usuario", gru.Gru_usuario));
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


        public static int Update(int cod)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "UPDATE gru_grupo SET gru_finalizado = 0 WHERE gru_codigo = ?codigo ";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", cod));
                objCommand.ExecuteNonQuery();
                conexao.Close();
                objCommand.Dispose();
                conexao.Dispose();
            }
            catch (Exception e)
            {
                string erro = e.Message;
                retorno = -2;
            }
            return retorno;
        }

        public static Grupo Select(int codigo)
        {
            try
            {
                Grupo objGrupo = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM gru_grupo WHERE gru_codigo = ?codigo", objConnection);
                objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {

                    var gru_codigo = Convert.ToInt32(objDataReader["gru_codigo"]);
                    var gru_nome_projeto = objDataReader["gru_nome_projeto"].ToString();
                    var gru_finalizado = Convert.ToInt32(objDataReader["gru_finalizado"]);

                    objGrupo = new Grupo();
                    objGrupo.Gru_codigo = gru_codigo;
                    objGrupo.Gru_nome_projeto = gru_nome_projeto;
                    objGrupo.Gru_finalizado = gru_finalizado;
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objGrupo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
