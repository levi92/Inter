using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Ticket_DB
{

    //INSERT
    public static int Insert(Ticket ticket)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO tic_ticket(tic_assunto, tic_id_professor, tic_data, tic_estado, tic_tipo, tic_prioridade) VALUES (?tic_assunto, ?tic_id_professor, ?tic_data, ?tic_estado, ?tic_tipo, ?tic_prioridade)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tic_assunto", ticket.Tic_Assunto));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id_professor", ticket.Tic_Id_Professor));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_data", ticket.Tic_Data));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_estado", ticket.Tic_Estado));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_tipo", ticket.Tic_Tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_prioridade", ticket.Tic_Prioridade));
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
    public static int Update(Ticket ticket)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE tic_ticket SET tic_assunto = ?tic_assunto, tic_id_professor = ?tic_id_professor, tic_data = ?tic_data, tic_estado = ?tic_estado, tic_tipo = ?tic_tipo, tic_prioridade = ?tic_prioridade WHERE tic_id = ?tic_id ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tic_assunto", ticket.Tic_Assunto));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id_professor", ticket.Tic_Id_Professor));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_data", ticket.Tic_Data));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_estado", ticket.Tic_Estado));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_tipo", ticket.Tic_Tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_prioridade", ticket.Tic_Prioridade));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id", ticket.Tic_Id));
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
            string sql = "DELETE FROM tic_ticket WHERE tic_id = ?codigo ";
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
    public static Ticket Select(int codigo)
    {
        try
        {
            Ticket objTicket = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM tic_ticket WHERE tic_id = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objTicket = new Ticket();
                objTicket.Tic_Assunto = objDataReader["tic_assunto"].ToString();
                objTicket.Tic_Id_Professor = (objDataReader["tic_id_professor"]).ToString();
                objTicket.Tic_Data = DateTime.ParseExact(objDataReader["tic_data"].ToString(), "dd/MM/yyyy - HH:mm", null);
                objTicket.Tic_Estado = Convert.ToInt32(objDataReader["tic_estado"]);
                objTicket.Tic_Prioridade = Convert.ToInt32(objDataReader["tic_prioridade"]);
                objTicket.Tic_Tipo = objDataReader["tic_tipo"].ToString();
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objTicket;
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
        objCommand = Mapped.Command("SELECT * FROM tic_ticket ORDER BY tic_id", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}