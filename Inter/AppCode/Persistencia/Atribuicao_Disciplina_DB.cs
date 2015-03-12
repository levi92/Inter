using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Atribuicao_Disciplina_DB{
	
        public static int Insert(Atribuicao_Disciplina At_disciplina){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO adi_atribuicao_disciplina(adi_codigo, adi_semestre_ano, adi_mae, trm_codigo, pro_matricula, dge_codigo) VALUES (?adi_codigo, ?adi_semestre_ano, ?adi_mae, ?trm_codigo, ?pro_matricula, ?dge_codigo)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", At_disciplina.Adi_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_semestre_ano", At_disciplina.Adi_semestre_ano));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_mae",At_disciplina.Adi_mae));  
            objCommand.Parameters.Add(Mapped.Parameter("?trm_codigo",At_disciplina.Trm_codigo.Trm_codigo));  
             objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula",At_disciplina.Pro_matricula.Pro_matricula));
             objCommand.Parameters.Add(Mapped.Parameter("?dge_codigo",At_disciplina.Dge_codigo.Dge_codigo));  
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
    public static int Update(Atribuicao_Disciplina At_disciplina)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE adi_atribuicao_disciplina SET adi_codigo = ?adi_codigo, adi_semestre_ano = ?adi_semestre_ano, adi_mae = ?adi_mae, trm_codigo = ?trm_codigo, pro_matricula = ?pro_matricula, dge_codigo = ?dge_codigo  " +
            " WHERE dge_codigo = ?dge_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo",At_disciplina.Adi_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_semestre_ano", At_disciplina.Adi_semestre_ano));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_mae", At_disciplina.Adi_mae)); 
            objCommand.Parameters.Add(Mapped.Parameter("?trm_codigo", At_disciplina.Trm_codigo.Trm_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_matricula", At_disciplina.Pro_matricula.Pro_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?dge_codigo", At_disciplina.Dge_codigo.Dge_codigo)); 
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
            string sql = "DELETE FROM adi_atribuicao_disciplina WHERE adi_codigo = ?codigo ";
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
    public static Atribuicao_Disciplina Select(int codigo)
    {
        try
        {
            Atribuicao_Disciplina objAtDisciplina = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM adi_atribuicao_disciplina WHERE adi_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objAtDisciplina = new Atribuicao_Disciplina();
                objAtDisciplina.Adi_codigo = Convert.ToInt32(objDataReader["adi_codigo"]);
                objAtDisciplina.Adi_semestre_ano = objDataReader["adi_semestre_ano"].ToString();
                objAtDisciplina.Adi_mae = Convert.ToBoolean(objDataReader["adi_mae"]);
                objAtDisciplina.Trm_codigo.Trm_codigo = Convert.ToInt32(objDataReader["trm_codigo"]);
                objAtDisciplina.Pro_matricula.Pro_matricula =  Convert.ToInt32(objDataReader["pro_matricula"]);
                objAtDisciplina.Dge_codigo.Dge_codigo =  Convert.ToInt32(objDataReader["dge_codigo"]);
              
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objAtDisciplina;
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
        objCommand = Mapped.Command("SELECT * FROM adi_atribuicao_disciplina ORDER BY adi_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //SELECT ALL PROF DISCIPLINA
    public static DataSet SelectAll(int codProf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM adi_atribuicao_disciplina where pro_matricula = ?codProf", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codProf", codProf));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


}
