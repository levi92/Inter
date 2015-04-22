using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Inter.Funcoes;
public class Funcoes_DB
{


    public static int ValidarLogin(string login, string senha)
    {
        int verificacao = 0;
        string verificaLogin = "";
        //bool adm = false;
        //int proadmcodigo = 0;
        int promatricula = 0;
        int admcodigo = 0;
        IDbConnection objconexao;
        IDbCommand objCommand;
        IDataReader objDataReader;
        //string sql = "SELECT P.PES_EMAIL, PR.PRO_ADMINISTRADOR FROM PES_PESSOAS P, PRO_PROFESSOR PR WHERE P.PES_EMAIL=?LOGIN AND PR.PRO_SENHA=sha1(?SENHA)";
        //string sql = "SELECT P.PES_EMAIL, PR.ADM_CODIGO FROM PES_PESSOAS P, PRO_PROFESSOR PR WHERE P.PES_EMAIL=?LOGIN AND PR.PRO_SENHA=sha1(?SENHA)";
        string sql = "select P.pes_email, A.adm_codigo, Pro.PRO_MATRICULA from pes_pessoas P left join pro_professor Pro using(pes_codigo) left join adm_administrador A using(pes_codigo)" +
" left join alu_aluno AL using(pes_codigo) where (AL.ALU_MATRICULA is null) AND P.PES_EMAIL=?LOGIN AND Pro.PRO_SENHA=sha1(?SENHA) OR A.ADM_SENHA=sha1(?SENHA) ";
        

        objconexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objconexao);

        //string criptografada = Funcoes.Criptografar(senha, "SHA1");
        objCommand.Parameters.Add(Mapped.Parameter("?LOGIN", login));
        objCommand.Parameters.Add(Mapped.Parameter("?SENHA", senha));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            verificaLogin = objDataReader["pes_email"].ToString();
            if (objDataReader["adm_codigo"] == DBNull.Value)
            {
                admcodigo = 0;
            }
            else
            {
                admcodigo = Convert.ToInt32(objDataReader["adm_codigo"]);
            }
           
            if (objDataReader["pro_matricula"] == DBNull.Value)
            {
                promatricula = 0;  
            }
            else
            {
                promatricula = Convert.ToInt32(objDataReader["pro_matricula"]);
            }

                
            
        }

        if (verificaLogin == "")
        {
            verificacao = -2;
        }
        else if (admcodigo == 1)
        {
            //verifica se é administrador master
            verificacao = 3;
        }
        else if ((admcodigo != 0) && (promatricula != 0))
        {
            //verifica se é administrador e professor
            verificacao = 2;
        }
        else if (promatricula != 0)
        {
            //verifica se é professor
            verificacao = 0;
        }
        else if(admcodigo != 0) //validação do campo para melhor entendimento
        {
            //verifica se é administrador
            verificacao = 1;
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