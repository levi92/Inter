using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Turma_DB{
	//INSERT
     public static int Insert(Turma turma){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO trm_turma(trm_codigo, trm_nome, tur_codigo, cur_codigo) VALUES (?trm_codigo, ?trm_nome, ?tur_codigo, ?cur_codigo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?trm_codigo", turma.Trm_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?trm_nome", turma.Trm_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tur_codigo", turma.Tur_codigo.Tur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cur_codigo", turma.Cur_codigo.Cur_codigo));     
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
    public static int Update(Turma turma){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE trm_turma SET trm_codigo = ?trm_codigo, trm_nome = ?trm_nome, tur_codigo = ?tur_codigo, cur_codigo = ?cur_codigo " + 
            " WHERE trm_codigo = ?trm_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?trm_codigo",turma.Trm_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?trm_nome", turma.Trm_nome)); 
             objCommand.Parameters.Add(Mapped.Parameter("?tur_codigo", turma.Tur_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cur_codigo", turma.Cur_codigo));  
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
            string sql = "DELETE FROM trm_turma WHERE trm_codigo = ?codigo ";
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
    public static Turma Select(int codigo){
        try{
            Turma objTurma = null;         
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM trm_turma WHERE trm_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));         
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read()){
                objTurma= new Turma();
                objTurma.Trm_codigo = Convert.ToInt32(objDataReader["trm_codigo"]); 
                objTurma.Trm_nome = objDataReader["trm_nome"].ToString();
                objTurma.Tur_codigo.Tur_codigo = Convert.ToInt32(objDataReader["tur_codigo"]);
                objTurma.Cur_codigo.Cur_codigo = Convert.ToInt32(objDataReader["cur_codigo"]);
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objTurma;
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
        objCommand = Mapped.Command("SELECT * FROM trm_turmao ORDER BY trm_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}


