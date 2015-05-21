using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Perfil_DB
{

    //INSERT ADM COORDENADOR
    public static int InsertAdmCoord(Perfil perfil)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO per_perfil(per_matricula, per_descricao) " +
                "VALUES (?per_matricula, 2)"; 
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?Per_matricula", perfil.Matricula));
            //objCommand.Parameters.Add(Mapped.Parameter("?Per_descricao", perfil.Descricao));
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

    //INSERT
    //public static int Insert(Perfil perfil)
    //{
    //    int retorno = 0;
    //    try
    //    {
    //        IDbConnection conexao;
    //        IDbCommand objCommand;
    //        string sql = "INSERT INTO Per_perfil(Per_matricula, Per_descricao, Per_login, Per_senha) " +
    //            "VALUES (?Per_matricula, ?Per_descricao, ?Per_login, ?Per_senha)";
    //        conexao = Mapped.Connection();
    //        objCommand = Mapped.Command(sql, conexao);
    //        objCommand.Parameters.Add(Mapped.Parameter("?Per_matricula", perfil.Matricula));
    //        objCommand.Parameters.Add(Mapped.Parameter("?Per_descricao", perfil.Descricao));
    //        objCommand.Parameters.Add(Mapped.Parameter("?Per_login", perfil.Login));
    //        objCommand.Parameters.Add(Mapped.Parameter("?Per_senha", perfil.Senha));
    //        objCommand.ExecuteNonQuery();
    //        conexao.Close();
    //        objCommand.Dispose();
    //        conexao.Dispose();
    //    }
    //    catch (Exception e)
    //    {
    //        retorno = -2;
    //    }
    //    return retorno;
    //}

    //UPDATE
    public static int Update(Perfil perfil)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE Per_perfil SET Per_matricula = ?Per_matricula, Per_descricao = ?Per_descricao, Per_login = ?Per_login " +
            " Per_senha = ?Per_senha WHERE Per_matricula = ?Per_matricula";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?Per_matricula", perfil.Matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?Per_descricao", perfil.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?Per_login", perfil.Login));
            objCommand.Parameters.Add(Mapped.Parameter("?Per_senha", perfil.Senha));
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

    //DELETE - TIRAR PERFIL DE ADMIN COORDENADOR
    public static int DeleteAdminCoord(string matricula)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objComando;
            string sql = "DELETE FROM Per_perfil WHERE Per_matricula = ?matricula ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?matricula", matricula));
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


    //SELECT -->>>>>>>>>>>>>>>>>>>>>>  VERIFICAR E ARRUMAR CASO FOR USAR
    //public static string Select(string codigo)
    //{
    //    try
    //    {
    //        perfil objPessoa = null;
    //        IDbConnection objConnection;
    //        IDbCommand objCommnad;
    //        IDataReader objDataReader;
    //        objConnection = Mapped.Connection();
    //        objCommnad = Mapped.Command("SELECT * FROM Per_perfil WHERE Per_matricula = ?codigo", objConnection);
    //        objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
    //        objDataReader = objCommnad.ExecuteReader();
    //        while (objDataReader.Read())
    //        {
    //            objperfil = new perfil();
    //            objperfil.Per_matricula = Convert.ToInt32(objDataReader["Per_matricula"]);
    //            objperfil.Per_descricao = objDataReader["Per_descricao"].ToString();
    //            objperfil.Per_login = objDataReader["Per_login"].ToString();
    //            objperfil.Per_senha = objDataReader["Per_senha"].ToString();
    //            objperfil.Per_senha = objDataReader["Per_cel"].ToString();
    //        }
    //        objDataReader.Close();
    //        objConnection.Close();
    //        objConnection.Dispose();
    //        objCommnad.Dispose();
    //        objDataReader.Dispose();
    //        return objPessoa;
    //    }
    //    catch (Exception e)
    //    {
    //        return null;
    //    }
    //}

   
    //SELECT ALL (COORDENADORES)
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM Per_perfil WHERE per_descricao = 2 ORDER BY per_matricula", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static int SelectCoordById(int matricula)
    {
        int descricao = 0;


        return descricao;
    }
}
