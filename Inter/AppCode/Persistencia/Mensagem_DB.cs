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
            string sql = "INSERT INTO men_tic_mensagem(men_id_enviadopor, men_hora, men_corpo, men_tic_id) VALUES (?men_id_enviadopor, ?men_hora, ?men_corpo, ?men_tic_id)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_id_enviadopor", mensagem.Men_id_enviado));
            objCommand.Parameters.Add(Mapped.Parameter("?men_hora", mensagem.Men_hora));
            objCommand.Parameters.Add(Mapped.Parameter("?men_corpo", mensagem.Men_corpo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_tic_id", mensagem.Men_tic_id));
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
            string sql = "UPDATE men_tic_mensagem SET men_id_enviadopor = ?men_id_enviadopor, men_hora = ?men_hora, men_corpo = ?men_corpo, men_tic_id = ?men_tic_id WHERE men_id = ?men_id ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_id", mensagem.Men_id));
            objCommand.Parameters.Add(Mapped.Parameter("?men_id_enviadopor", mensagem.Men_id_enviado));
            objCommand.Parameters.Add(Mapped.Parameter("?men_hora", mensagem.Men_hora));
            objCommand.Parameters.Add(Mapped.Parameter("?men_corpo", mensagem.Men_corpo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_tic_id", mensagem.Men_tic_id));
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
            string sql = "DELETE FROM men_tic_mensagem WHERE men_id = ?codigo ";
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
            objCommnad = Mapped.Command("SELECT * FROM men_tic_mensagem WHERE men_id = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objMensagem = new Mensagem();
                objMensagem.Men_id_enviado = Convert.ToInt32(objDataReader["men_id_enviado"]);
                objMensagem.Men_hora = DateTime.ParseExact(objDataReader["men_hora"].ToString(), "dd/MM/yyyy - HH:mm", null);
                objMensagem.Men_corpo = objDataReader["men_hora"].ToString();
                objMensagem.Men_tic_id = Convert.ToInt32(objDataReader["men_tic_id"]);
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
        objCommand = Mapped.Command("SELECT * FROM men_tic_mensagem ORDER BY men_id", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}