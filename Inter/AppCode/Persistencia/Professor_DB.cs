using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class Professor_DB{
    //INSERT
    public static int Insert(Professor professor){
        int retorno = 0;
        try{
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO pro_professor(pro_matricula, pro_administrador, pro_senha, pro_chave_senha, pes_codigo) " + 
            "VALUES (?pro_matricula, ?pro_administrador, sha1(?pro_senha), ?pro_chave_senha, ?pes_codigo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", professor.Pro_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_administrador", professor.Pro_administrador));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_senha", professor.Pro_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_chave_senha", professor.Pro_chave_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", professor.Pes_codigo.Pes_codigo));
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
    public static int Update(Professor professor){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE pro_professor SET pro_matricula = ?pro_matricula, pro_administrador = ?pro_administrador " +
            " pro_senha = sha1(?pro_senha), pro_chave_senha = ?pro_chave_senha, pes_codigo = ?pes_codigo WHERE pro_matricula = ?pro_matricula";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", professor.Pro_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_administrador", professor.Pro_administrador));
           // objCommand.Parameters.Add(Mapped.Parameter("?pro_senha", professor.Pro_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_chave_senha", professor.Pro_chave_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", professor.Pes_codigo.Pes_codigo));
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
            string sql = "DELETE FROM pro_professor WHERE pro_matricula = ?codigo ";
            conexao = Mapped.Connection();
            objComando = Mapped.Command(sql, conexao);
            objComando.Parameters.Add(Mapped.Parameter("?pro_matricula", codigo));
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
    public static Professor Select(int codigo){
        try{
            Professor objProfessor= null;
            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pro_professor WHERE pro_matricula = ?pro_matricula", objConnection); 
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", codigo));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                objProfessor = new Professor();
                objProfessor.Pro_matricula = Convert.ToInt32(objDataReader["pro_matricula"]);
                objProfessor.Pro_administrador = Convert.ToBoolean(objDataReader["pro_administrador"]);
                //objProfessor.Pro_senha = objDataReader["pro_senha"].ToString();
                //objProfessor.Pro_chave_senha = objDataReader["pro_chave_senha"].ToString();
                objProfessor.Pes_codigo.Pes_codigo = Convert.ToInt32(objDataReader["pes_codigo"]);
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
            objDataReader.Dispose();
            return objProfessor;
        }
        catch (Exception e){
            return null;
        }
    }

    ////SELECT VIA COD PES
    //public static Professor SelectPes(int pes_codigo)
    //{
    //    try
    //    {
    //        Professor objProfessor = null;
    //        IDbConnection objConnection;
    //        IDbCommand objCommand;
    //        IDataReader objDataReader;
    //        objConnection = Mapped.Connection();
    //        objCommand = Mapped.Command("SELECT * FROM pro_professor WHERE pes_codigo = ?pes_codigo", objConnection);
    //        objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pes_codigo));
    //        objDataReader = objCommand.ExecuteReader();
    //        while (objDataReader.Read())
    //        {
    //            objProfessor = new Professor();
    //            objProfessor.Pro_matricula = Convert.ToInt32(objDataReader["pro_matricula"]);
    //            objProfessor.Pro_administrador = Convert.ToBoolean(objDataReader["pro_administrador"]);
    //            objProfessor.Pro_senha = objDataReader["pro_senha"].ToString();
    //            objProfessor.Pro_chave_senha = objDataReader["pro_chave_senha"].ToString();
    //            objProfessor.Pes_codigo.Pes_codigo = Convert.ToInt32(objDataReader["pes_codigo"]);
    //        }
    //        objDataReader.Close();
    //        objConnection.Close();
    //        objConnection.Dispose();
    //        objCommand.Dispose();
    //        objDataReader.Dispose();
    //        return objProfessor;
    //    }
    //    catch (Exception e)
    //    {
    //        return null;
    //    }
    //}

    //SELECT ALL
    public static DataSet SelectAll(){
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_professor ORDER BY pro_matricula", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }



    //SELECT VIA COD PES
    public static int SelectPes(int pesCodigo)
    {
        try
        {
            int matricula = 0;

            IDbConnection objConnection;
            IDbCommand objCommand;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command("SELECT pro_matricula FROM pro_professor WHERE pes_codigo = ?pes_codigo", objConnection);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pesCodigo));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {

                matricula = Convert.ToInt32(objDataReader["pro_matricula"]);

            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
            objDataReader.Dispose();
            return matricula;
        }
        catch (Exception e)
        {
            return -2;
        }
    }





}