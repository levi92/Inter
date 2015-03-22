using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Disciplina_Aluno_DB{

	   public static int Insert(Disciplina_Aluno disciplina_aluno){
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO dal_disciplina_aluno(adi_codigo, alu_matricula, dal_semestre_ano) VALUES (?adi_codigo, ?alu_matricula, ?dal_semestre_ano)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", disciplina_aluno.Adi_codigo.Adi_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", disciplina_aluno.Alu_matricula.Alu_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?dal_semestre_ano",disciplina_aluno.Semestre_ano));            
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
    public static int Update(Disciplina_Aluno disciplina_aluno)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "UPDATE dal_disciplina_aluno SET adi_codigo = ?adi_codigo, alu_matricula = ?alu_matricula, dal_semestre_ano = ?dal_semestre_ano " +
            " WHEREadi_codigo = ?adi_codigo ";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("adi_codigo",disciplina_aluno.Adi_codigo.Adi_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?alu_matricula", disciplina_aluno.Alu_matricula.Alu_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?dal_semestre_ano", disciplina_aluno.Semestre_ano));   
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
            string sql = "DELETE FROM dal_disciplina_aluno WHERE adi_codigo = ?adi_codigo ";
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
    public static Disciplina_Aluno Select(int codigo)
    {
        try
        {
            Disciplina_Aluno objDisciplinaAluno = null;
            IDbConnection objConnection;
            IDbCommand objCommnad;
            IDataReader objDataReader;
            objConnection = Mapped.Connection();
            objCommnad = Mapped.Command("SELECT * FROM dal_disciplina_aluno WHERE adi_codigo = ?codigo", objConnection);
            objCommnad.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objCommnad.ExecuteReader();
            while (objDataReader.Read())
            {
                objDisciplinaAluno = new Disciplina_Aluno();
                objDisciplinaAluno.Adi_codigo.Adi_codigo = Convert.ToInt32(objDataReader["adi_codigo"]);
                objDisciplinaAluno.Alu_matricula.Alu_matricula = Convert.ToInt32(objDataReader["alu_matricula"]);
                objDisciplinaAluno.Semestre_ano = objDataReader["dal_semestre_ano"].ToString();
              
            }
            objDataReader.Close();
            objConnection.Close();
            objConnection.Dispose();
            objCommnad.Dispose();
            objDataReader.Dispose();
            return objDisciplinaAluno;
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
        objCommand = Mapped.Command("SELECT * FROM dal_disciplina_aluno ORDER BY adi_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}

