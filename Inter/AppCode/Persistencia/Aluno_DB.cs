using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Aluno_DB{

    //INSERT
    public static int Insert(Aluno aluno){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO alu_aluno(alu_matricula, pes_codigo) VALUES (?alu_matricula, ?pes_codigo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", aluno.Alu_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", aluno.Pes_codigo.Pes_codigo));     
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
    public static int Update(Aluno aluno){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE alu_aluno SET alu_matricula = ?alu_matricula, pes_codigoo = ?pes_codigo WHERE alu_matricula = ?alu_matricula ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", aluno.Alu_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", aluno.Pes_codigo.Pes_codigo));            
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
            string sql = "DELETE FROM alu_aluno WHERE alu_matricula = ?codigo ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?alu_matricula", codigo));
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
    public static Aluno Select(int codigo){
        try{
            Aluno objAluno = null;         
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM alu_aluno WHERE alu_matricula = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?alu_matricula", codigo));         
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read()){
                objAluno = new Aluno();
                objAluno.Alu_matricula = Convert.ToInt32(objDataReader["alu_matricula"]);
                objAluno.Pes_codigo.Pes_codigo = Convert.ToInt32(objDataReader["pes_codigo"]);                
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objAluno;
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
        objCommand = Mapped.Command("SELECT * FROM alu_aluno ORDER BY alu_matricula", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


}