using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class Requerimento_DB{

    //INSERT
    public static int Insert(Requerimento requerimento){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO req_requerimento(req_codigo, req_descricao, req_data_requisicao, req_data_inicial, req_data_final, req_resolvido, pro_matricula ) " +
            " VALUES (?req_codigo, ?req_descricao, ?req_data_requisicao, ?req_data_inicial, ?req_data_final, ?req_resolvido, ?pro_matricula)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", requerimento.Req_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?req_descricao", requerimento.Req_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_requisicao", requerimento.Req_data_requisicao));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_inicial", requerimento.Req_data_inicial));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_final", requerimento.Req_data_final));
            objCommand.Parameters.Add(Mapped.Parameter("?req_resolvido", requerimento.Req_resolvido));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", requerimento.Pro_matricula.Pro_matricula));
            conexao.Close();
            objCommand.Dispose();
            conexao.Dispose();
        }
        catch (Exception e){
            retorno = -2;
        }
        return retorno;
    }

    //UPDATE
    public static int Update(Requerimento requerimento){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE req_requerimento SET req_codigo = ?req_codigo, req_descricao = ?req_descricao, req_data_requisicao = ?req_data_requisicao, " + 
            "req_data_inicial = ?req_data_inicial, req_data_final = ?req_data_final, req_resolvido = ?req_resolvido, pro_matricula = ?pro_matricula WHERE req_codigo = ?req_codigo";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", requerimento.Req_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?req_descricao",requerimento.Req_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_requisicao", requerimento.Req_data_requisicao));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_inicial", requerimento.Req_data_inicial));
            objCommand.Parameters.Add(Mapped.Parameter("?req_data_final", requerimento.Req_data_final));
            objCommand.Parameters.Add(Mapped.Parameter("?req_resolvido", requerimento.Req_resolvido));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", requerimento.Pro_matricula.Pro_matricula));
            objCommand.ExecuteNonQuery();
            conexao.Close();
            objCommand.Dispose();
            conexao.Dispose();
        }
        catch (Exception e){
            retorno = -2;
        }
        return retorno;
    }

    //DELETE   
    public static int Delete(int codigo){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objComando;
            string sql = "DELETE FROM req_requerimento WHERE req_codigo = ?codigo ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?req_codigo", codigo));
            objComando.ExecuteNonQuery();
            conexao.Close();
            objComando.Dispose();
            conexao.Dispose();
        }
        catch (Exception e){
            retorno = -2;
        }
        return retorno;
    }

    //SELECT
    public static Requerimento Select(int codigo){
        try{
            Requerimento objRequerimento = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM req_requerimento WHERE req_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?req_codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read()){
                objRequerimento = new Requerimento();
                objRequerimento.Req_codigo = Convert.ToInt32(objDataReader["req_codigo"]);
                objRequerimento.Req_descricao = objDataReader["req_descricao"].ToString();
                objRequerimento.Req_data_requisicao = Convert.ToDateTime(objDataReader["req_data_requisicao"]);
                objRequerimento.Req_data_inicial = Convert.ToDateTime(objDataReader["req_data_inicial"]);
                objRequerimento.Req_data_final = Convert.ToDateTime(objDataReader["req_data_final"]);
                objRequerimento.Req_resolvido = Convert.ToBoolean(objDataReader["req_resolvido"]);
                objRequerimento.Pro_matricula.Pro_matricula = Convert.ToInt32(objDataReader["pro_matricula"]);               
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objRequerimento;
        }
        catch (Exception e){
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
        objCommand = Mapped.Command("SELECT * FROM req_requerimento ORDER BY req_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}