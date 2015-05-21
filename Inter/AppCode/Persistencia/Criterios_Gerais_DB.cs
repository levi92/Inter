using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class Criterios_Gerais_DB{
    public static int Insert(Criterios_Gerais criterio){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO cge_criterios_gerais(cge_codigo, cge_nome, cge_descricao, cge_ativo) VALUES(?cge_codigo, ?cge_nome, ?cge_descricao, 1)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cge_codigo", criterio.Cge_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cge_nome", criterio.Cge_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cge_descricao", criterio.Cge_descricao));
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
    public static int Update(Criterios_Gerais criterio)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE cge_criterios_gerais SET cge_codigo = ?cge_codigo, cge_nome = ?cge_nome, cge_descricao = ?cge_descricao  " +
            " WHERE cge_codigo = ?cge_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cge_codigo", criterio.Cge_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cge_nome", criterio.Cge_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cge_descricao", criterio.Cge_descricao));
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
            string sql = "DELETE FROM cge_criterios_gerais WHERE cge_codigo = ?codigo ";
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
    public static Criterios_Gerais Select(int codigo)
    {
        try
        {
            Criterios_Gerais objCriterio = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM cge_criterios_gerais WHERE cge_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objCriterio = new Criterios_Gerais();
                objCriterio.Cge_codigo = Convert.ToInt32(objDataReader["cge_codigo"]);
                objCriterio.Cge_nome = objDataReader["cge_nome"].ToString();
                objCriterio.Cge_descricao = objDataReader["cge_descricao"].ToString();

            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objCriterio;
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
            objCommnad = Mapped.Command("SELECT MAX(CGE_CODIGO) FROM CGE_CRITERIOS_GERAIS", objConnection);
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                ultimoCod = Convert.ToInt32(objDataReader["Max(CGE_CODIGO)"]);
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
        objCommand = Mapped.Command("SELECT * FROM cge_criterios_gerais ORDER BY cge_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


    //SELECT TODOS CRITERIOS ATIVOS
    public static DataSet SelectAtivos()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cge_criterios_gerais WHERE cge_ativo=1 ORDER BY cge_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //SELECT TODOS CRITERIOS DESATIVADOS
    public static DataSet SelectDesativados()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cge_criterios_gerais WHERE cge_ativo=0 ORDER BY cge_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //DESATIVAR CRITERIO

    public static int Desativar(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE cge_criterios_gerais SET cge_ativo = 0 WHERE cge_codigo = ?cge_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cge_codigo", codigo));
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

    public static int Ativar(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE cge_criterios_gerais SET cge_ativo = 1 WHERE cge_codigo = ?cge_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cge_codigo", codigo));
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



}