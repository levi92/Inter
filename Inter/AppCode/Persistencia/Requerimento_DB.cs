using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class Requerimento_DB
{

    //INSERT
    public static int Insert(Requerimento requerimento)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = " ";

            if (requerimento.CodigoGrupo != 0) {
               sql = "INSERT INTO req_requerimento(REQ_CODIGO, PRO_MATRICULA, GRU_CODIGO, REQ_ASSUNTO, REQ_DT_REQUISICAO, REQ_STATUS, REQ_CATEGORIA, REQ_USUARIO) VALUES (?req_codigo, ?pro_matricula, ?gru_codigo, ?req_assunto, ?req_dt_requisicao, ?req_status, ?req_categoria, ?req_usuario)";
            } else {
               sql = "INSERT INTO req_requerimento(REQ_CODIGO, PRO_MATRICULA, REQ_ASSUNTO, REQ_DT_REQUISICAO, REQ_STATUS, REQ_CATEGORIA, REQ_USUARIO) VALUES (?req_codigo, ?pro_matricula, ?req_assunto, ?req_dt_requisicao, ?req_status, ?req_categoria, ?req_usuario)";
            }
            
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?req_codigo", requerimento.CodigoReq));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", requerimento.MatriculaPro));
            objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", requerimento.CodigoGrupo));
            objCommand.Parameters.Add(Mapped.Parameter("?req_assunto", requerimento.Assunto));
            objCommand.Parameters.Add(Mapped.Parameter("?req_dt_requisicao", requerimento.DataReq));
            objCommand.Parameters.Add(Mapped.Parameter("?req_status", requerimento.Status));
            objCommand.Parameters.Add(Mapped.Parameter("?req_categoria", requerimento.Categoria));
            objCommand.Parameters.Add(Mapped.Parameter("?req_usuario", requerimento.Usuario));
            
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
                
                var CodigoReq = Convert.ToInt32(objDataReader["req_codigo"]);
                var Assunto = objDataReader["req_assunto"].ToString();
                var DataReq = Convert.ToDateTime(objDataReader["req_dt_requisicao"]);
                var MatriculaPro = objDataReader["pro_matricula"].ToString();
                var Status = Convert.ToInt32(objDataReader["req_status"]);
                var Categoria = objDataReader["req_categoria"].ToString();    
           
                objRequerimento = new Requerimento(CodigoReq, MatriculaPro, Assunto, DataReq, Status, Categoria);
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
    public static DataSet SelectAll()
    {
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