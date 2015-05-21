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
            string sql = "INSERT INTO req_requerimento(req_codigo, req_assunto, req_dt_requisicao, pro_matricula, gru_codigo, req_status, req_categoria ) " +
            " VALUES (?req_codigo, ?req_assunto, ?req_dt_requisicao, ?pro_matricula, ?gru_codigo, ?req_status, ?req_categoria)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", requerimento.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?req_assunto", requerimento.Assunto));
            objCommand.Parameters.Add(Mapped.Parameter("?req_dt_requisicao", requerimento.DataReq));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", requerimento.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", requerimento.CodigoGrupo.Gru_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?req_status", requerimento.Status));
            objCommand.Parameters.Add(Mapped.Parameter("?req_categoria", requerimento.Categoria));
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

    /*UPDATE
    public static int Update(Requerimento requerimento){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE req_requerimento SET req_codigo = ?req_codigo, req_assunto = ?req_assunto, req_dt_requisicao = ?req_dt_requisicao, " +
            "pro_matricula = ?pro_matricula, gru_codigo = ?gru_codigo, req_status = ?req_status, req_categoria = ?req_categoria WHERE req_codigo = ?req_codigo";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", requerimento.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?req_assunto",requerimento.Assunto));
            objCommand.Parameters.Add(Mapped.Parameter("?req_dt_requisicao", requerimento.DataReq));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", requerimento.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", requerimento.CodigoGrupo.Gru_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?req_status", requerimento.Status));
            objCommand.Parameters.Add(Mapped.Parameter("?req_categoria", requerimento.Categoria));
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
            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read()){
                objRequerimento = new Requerimento();
                objRequerimento.CodigoReq = Convert.ToInt32(objDataReader["req_codigo"]);
                objRequerimento.Assunto = objDataReader["req_assunto"].ToString();
                objRequerimento.DataReq = Convert.ToDateTime(objDataReader["req_dt_requisicao"]);
                objRequerimento.MatriculaPro = objDataReader["pro_matricula"].ToString();
                objRequerimento.CodigoGrupo.Gru_codigo = Convert.ToInt32(objDataReader["gru_codigo"]);
                objRequerimento.Status = Convert.ToInt32(objDataReader["req_status"]);
                objRequerimento.Categoria = objDataReader["pro_matricula"].ToString();               
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
    }*/

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

    //SELECT STATUS
    public static DataSet SelectS(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM req_requerimento WHERE req_status=?codigo ORDER BY req_codigo DESC", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objDataAdapter = Mapped.Adapter(objCommand);                            
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}