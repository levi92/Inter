using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Curso_DB{
	   public static int Insert(Curso curso){
       int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO cur_curso(cur_codigo, cur_nome) VALUES (?cur_codigo, ?cur_nome)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cur_codigo", curso.Cur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cur_nome",curso.Cur_nome));
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
    public static int Update(Curso curso)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE cur_curso SET cur_codigo = ?cur_codigo, cur_nome = ?cur_nome WHERE cur_codigo = ?cur_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cur_codigo", curso.Cur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cur_nome", curso.Cur_nome));
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
            string sql = "DELETE FROM cur_curso WHERE cur_codigo = ?codigo ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?cur_codigo", codigo));
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
    public static Curso Select(int codigo)
    {
        try
        {
            Curso objCurso = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM cur_curso WHERE cur_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?cur_codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objCurso = new Curso();
                objCurso.Cur_codigo = Convert.ToInt32(objDataReader["cur_codigo"]);
                objCurso.Cur_nome = objDataReader["cur_nome"].ToString();
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objCurso;
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
        objCommand = Mapped.Command("SELECT * FROM cur_curso ORDER BY cur_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


}
