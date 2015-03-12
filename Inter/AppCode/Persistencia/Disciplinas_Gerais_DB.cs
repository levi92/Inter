using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Disciplinas_Gerais_DB{

    public static int Insert(Disciplinas_Gerais disciplina)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO dge_disciplinas_gerais(dge_codigo, dge_nome, dge_sigla) VALUES (?dge_codigo, ?dge_nome, ?dge_sigla)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?dge_codigo", disciplina.Dge_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?dge_nome", disciplina.Dge_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?dge_sigla",disciplina.Dge_sigla));            
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
    public static int Update(Disciplinas_Gerais disciplina)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE dge_disciplinas_gerais SET dge_codigo = ?dge_codigo, dge_nome = ?dge_nome, dge_sigla = ?dge_sigla  " +
            " WHERE dge_codigo = ?dge_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?dge_codigo", disciplina.Dge_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?dge_nome", disciplina.Dge_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?dge_sigla", disciplina.Dge_sigla));   
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
            string sql = "DELETE FROM dge_disciplinas_gerais WHERE dge_codigo = ?codigo ";
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
    public static Disciplinas_Gerais Select(int codigo)
    {
        try
        {
            Disciplinas_Gerais objDisciplina = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM dge_disciplinas_gerais WHERE dge_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objDisciplina = new Disciplinas_Gerais();
                objDisciplina.Dge_codigo = Convert.ToInt32(objDataReader["dge_codigo"]);
                objDisciplina.Dge_nome = objDataReader["dge_nome"].ToString();
                objDisciplina.Dge_sigla = objDataReader["dge_sigla"].ToString();
              
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objDisciplina;
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
        objCommand = Mapped.Command("SELECT * FROM dge_disciplinas_gerais ORDER BY dge_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}
