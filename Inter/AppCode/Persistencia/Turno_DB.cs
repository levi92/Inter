using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class Turno_DB{
    public static int Insert(Turno turno){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO tur_turno(tur_codigo, tur_nome) VALUES (?tur_codigo, ?tur_nome)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tur_codigo", turno.Tur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?tur_nome",turno.Tur_nome));
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
    public static int Update(Turno turno){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE tur_turno SET tur_codigo = ?tur_codigo, tur_nome = ?tur_nome WHERE tur_codigo = ?tur_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tur_codigo", turno.Tur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?tur_nome", turno.Tur_nome));
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
    public static int Delete(int codigo){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objComando;
            string sql = "DELETE FROM tur_turno WHERE tur_codigo = ?codigo ";
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
    public static Turno Select(int codigo){
        try
        {
            Turno objTurno = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM tur_turno WHERE tur_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objTurno= new Turno();
                objTurno.Tur_codigo = Convert.ToInt32(objDataReader["tur_codigo"]);
                objTurno.Tur_nome = objDataReader["tur_nome"].ToString();
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objTurno;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    //SELECT ALL
    public static DataSet SelectAll(){
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tur_turno ORDER BY tur_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


}