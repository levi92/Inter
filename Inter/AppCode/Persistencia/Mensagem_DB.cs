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
            string sql = "INSERT INTO msg_mensagem(pro_matricula, req_codigo, msg_dt_Envio, msg_conteudo) VALUES (?matricula, ?req_codigo, ?msg_dt_Envio, ?msg_conteudo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?matricula", mensagem.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", mensagem.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_dt_Envio", mensagem.DataEnvio));
            objCommand.Parameters.Add(Mapped.Parameter("?msg_conteudo", mensagem.Conteudo));
            objCommand.ExecuteNonQuery();
            conexao.Close();
            objCommand.Dispose();
            conexao.Dispose();
        }
        catch (Exception e)
        {
            string deuruim = e.Message;
            retorno = -2;
        }

        return retorno;
    }




    
    //SELECT ALL
    public static DataSet SelectAll(int cod)
    {
        var ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM msg_mensagem WHERE req_codigo = ?codigo ORDER BY msg_codigo DESC", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", cod));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}