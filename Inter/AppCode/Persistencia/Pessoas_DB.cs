using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Pessoas_DB{

    //INSERT
    public static int Insert(Pessoas pessoa){       
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand; 
            string sql = "INSERT INTO pes_pessoas(pes_codigo, pes_nome, pes_email, pes_tel, pes_cel) " +
                "VALUES (?pes_codigo, ?pes_nome, ?pes_email, ?pes_tel, ?pes_cel)";            
            conexao = Mapped.Connection();            
            objCommand = Mapped.Command(sql, conexao);            
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pessoa.Pes_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pessoa.Pes_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_email", pessoa.Pes_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_tel", pessoa.Pes_tel));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cel", pessoa.Pes_cel));            
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

    //UPDATE
    public static int Update(Pessoas pessoa){
        int retorno = 0;
        try{
            IDbConnection conexao; 
            IDbCommand objCommand;            
            string sql = "UPDATE pes_pessoas SET pes_codigo = ?pes_codigo, pes_nome = ?pes_nome, pes_email = ?pes_email " +
            " pes_tel = ?pes_tel, pes_cel = ?pes_cel WHERE pes_codigo = ?pes_codigo";            
            conexao = Mapped.Connection();            
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pessoa.Pes_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pessoa.Pes_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_email", pessoa.Pes_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_tel", pessoa.Pes_tel));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cel", pessoa.Pes_cel));              
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
            string sql = "DELETE FROM pes_pessoas WHERE pes_codigo = ?codigo ";
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
        public static Pessoas Select(int codigo){
            try{
                Pessoas objPessoa = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;               
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_codigo = ?codigo", objConnection);
                objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
                objDataReader = objCommnad.ExecuteReader();               
                while (objDataReader.Read()){
                    objPessoa = new Pessoas();                    
                    objPessoa.Pes_codigo = Convert.ToInt32(objDataReader["pes_codigo"]);
                    objPessoa.Pes_nome = objDataReader["pes_nome"].ToString();
                    objPessoa.Pes_email = objDataReader["pes_email"].ToString();
                    objPessoa.Pes_tel = objDataReader["pes_tel"].ToString();
                    objPessoa.Pes_tel = objDataReader["pes_cel"].ToString();
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objPessoa;
            }
            catch (Exception e){
                return null;
            }
        }

        //SELECT EMAIL LOAD
        public static Pessoas Select(string email)
        {
            try
            {
                Pessoas objPessoa = null;
                IDbConnection objConnection;
                IDbCommand objCommnad;
                IDataReader objDataReader;
                objConnection = Mapped.Connection();
                objCommnad = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_email = ?email", objConnection);
                objCommnad.Parameters.Add(Mapped.Parameter("?email", email));
                objDataReader = objCommnad.ExecuteReader();
                while (objDataReader.Read())
                {
                    objPessoa = new Pessoas();
                    objPessoa.Pes_codigo = Convert.ToInt32(objDataReader["pes_codigo"]);
                    objPessoa.Pes_nome = objDataReader["pes_nome"].ToString();
                    objPessoa.Pes_email = objDataReader["pes_email"].ToString();
                    objPessoa.Pes_tel = objDataReader["pes_tel"].ToString();
                    objPessoa.Pes_tel = objDataReader["pes_cel"].ToString();
                }
                objDataReader.Close();
                objConnection.Close();
                objConnection.Dispose();
                objCommnad.Dispose();
                objDataReader.Dispose();
                return objPessoa;
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
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas ORDER BY pes_codigo", objConnection);
            objDataAdapter = Mapped.Adapter(objCommand);    
            objDataAdapter.Fill(ds);
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
            return ds;
       }
}



