using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Funcoes_DB
{


    public static int ValidarLogin(string login, string senha)
    {
        int verificacao = 0;
        string verificaLogin = "";
        bool adm = false;
        IDbConnection objconexao;
        IDbCommand objCommand;
        IDataReader objDataReader;
        string sql = "SELECT P.PES_EMAIL, PR.PRO_ADMINISTRADOR FROM PES_PESSOAS P, PRO_PROFESSOR PR WHERE P.PES_EMAIL=?LOGIN AND PR.PRO_SENHA=sha1(?SENHA)";

        objconexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objconexao);

        objCommand.Parameters.Add(Mapped.Parameter("?LOGIN", login));
        objCommand.Parameters.Add(Mapped.Parameter("?SENHA", senha));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            verificaLogin = objDataReader["pes_email"].ToString();
            adm = Convert.ToBoolean(objDataReader["pro_administrador"]);
        }

        if (verificaLogin == "")
        {
            verificacao = -2;
        }
        else if (adm)
        {
            verificacao = 1;
        }
        else
        {
            verificacao = 0;
        }
        objDataReader.Close();
        objconexao.Close();
        objconexao.Dispose();
        objCommand.Dispose();
        objDataReader.Dispose();

        return verificacao;
    }

    public static DataSet SelectDisciplina(int codProf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select tr.trm_nome, dg.dge_sigla, ad.adi_mae, c.cur_sigla from trm_turma tr inner join cur_curso c using(cur_codigo) inner join adi_atribuicao_disciplina ad using(trm_codigo) inner join dge_disciplinas_gerais dg using(dge_codigo) where ad.pro_matricula=?codProf;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codProf", codProf));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }



    








}