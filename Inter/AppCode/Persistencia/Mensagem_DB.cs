using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Mensagem_DB
{

    //INSERT
    public static int Insert(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO msg_mensagem(pro_matricula, req_codigo, per_matricula, msg_dt_Envio, msg_conteudo) VALUES (?pro_matricula, ?req_codigo, ?per_matricula, ?msg_dt_Envio, ?msg_conteudo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", mensagem.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", mensagem.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?per_matricula", mensagem.MatriculaAdm));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_dt_Envio", mensagem.DataEnvio));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_conteudo", mensagem.Conteudo));
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
    public static int Update(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE msg_mensagem SET pro_matricula = ?pro_matricula, req_codigo = ?req_codigo, per_matricula = ?per_matricula, msg_conteudo = ?msg_conteudo, msg_dt_Envio = ?msg_dt_Envio WHERE msg_codigo = ?msg_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?msg_codigo", mensagem.CodigoMsg));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", mensagem.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", mensagem.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?per_matricula", mensagem.MatriculaAdm));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_dt_Envio", mensagem.DataEnvio));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_conteudo", mensagem.Conteudo));
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
            string sql = "DELETE FROM msg_mensagem WHERE msg_codigo = ?codigo ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
    public static Mensagem Select(int codigo)
    {
        try
        {
            Mensagem objMensagem = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM msg_mensagem WHERE msg_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objMensagem = new Mensagem();
                objMensagem.CodigoMsg = Convert.ToInt32(objDataReader["msg_codigo"]);
                objMensagem.MatriculaPro = objDataReader["pro_matricula"].ToString();
                objMensagem.CodigoReq = Convert.ToInt32(objDataReader["req_codigo"]);
                objMensagem.MatriculaAdm = objDataReader["per_matricula"].ToString();
                objMensagem.DataEnvio = Convert.ToDateTime(objDataReader["msg_dt_Envio"]);
                objMensagem.Conteudo = objDataReader["msg_conteudo"].ToString();
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objMensagem;
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
        objCommand = Mapped.Command("SELECT * FROM msg_mensagem ORDER BY msg_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}