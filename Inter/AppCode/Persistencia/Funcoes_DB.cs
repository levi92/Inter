using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Inter.Funcoes;
using Interdisciplinar;
public class Funcoes_DB
{


    public static int ValidarAdmMaster(string login, string senha)
    {
        int verificacao = 0;
        //string verificaLogin = "";
        //bool adm = false;
        //int proadmcodigo = 0;
        //int promatricula = 0;
        IDbConnection objconexao;
        IDbCommand objCommand;
        IDataReader objDataReader;
        //string sql = "SELECT P.PES_EMAIL, PR.PRO_ADMINISTRADOR FROM PES_PESSOAS P, PRO_PROFESSOR PR WHERE P.PES_EMAIL=?LOGIN AND PR.PRO_SENHA=sha1(?SENHA)";
        //string sql = "SELECT P.PES_EMAIL, PR.ADM_CODIGO FROM PES_PESSOAS P, PRO_PROFESSOR PR WHERE P.PES_EMAIL=?LOGIN AND PR.PRO_SENHA=sha1(?SENHA)";
        //        string sql = "select P.pes_email, A.adm_codigo, Pro.PRO_MATRICULA from pes_pessoas P left join pro_professor Pro using(pes_codigo) left join adm_administrador A using(pes_codigo)" +
        //" left join alu_aluno AL using(pes_codigo) where (AL.ALU_MATRICULA is null) AND P.PES_EMAIL=?LOGIN AND Pro.PRO_SENHA=sha1(?SENHA) OR A.ADM_SENHA=sha1(?SENHA) ";
        string sql = "Select per_login, per_senha, per_descricao from per_perfil where per_login = ?login and per_senha=sha1(?senha);";

        objconexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objconexao);

        //string criptografada = Funcoes.Criptografar(senha, "SHA1");
        objCommand.Parameters.Add(Mapped.Parameter("?LOGIN", login));
        objCommand.Parameters.Add(Mapped.Parameter("?SENHA", senha));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {

            //if (objDataReader["per_descricao"].ToString() == "") se é nulo ele nem entra no while então isso era desnecessário
            //{
            //    verificacao = -2;
            //}

            if (Convert.ToInt32(objDataReader["per_descricao"]) == 1)
            {
                verificacao = 1;
            }


        }

        //else if (promatricula != 0)
        //{
        //    //verifica se é professor
        //    verificacao = 0;
        //}
        //else if(descricao != 0) //validação do campo para melhor entendimento
        //{
        //    //verifica se é administrador
        //    verificacao = 1;
        //}
        objDataReader.Close();
        objconexao.Close();
        objconexao.Dispose();
        objCommand.Dispose();
        objDataReader.Dispose();

        return verificacao; //retorna o valor do resultado da verificação feita acima
    }

    public static int ValidarAdmCoord(Professor prof)
    {
        string matricula = prof.Matricula; //pega matrícula do objeto professor obtido do método Professor.Validar
        int verificacao = 0;
        //string verificaLogin = "";
        //bool adm = false;
        //int proadmcodigo = 0;
        //int promatricula = 0;
        IDbConnection objconexao;
        IDbCommand objCommand;
        IDataReader objDataReader;
        string sql = "Select per_matricula, per_descricao from per_perfil where per_matricula = ?per_matricula;";
        objconexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objconexao);

        //string criptografada = Funcoes.Criptografar(senha, "SHA1");
        objCommand.Parameters.Add(Mapped.Parameter("?per_matricula", matricula));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {

            if (Convert.ToInt32(objDataReader["per_descricao"]) == 2)
            {
                verificacao = 2;
            }
        }
        //else if (promatricula != 0)
        //{
        //    //verifica se é professor
        //    verificacao = 0;
        //}
        //else if(descricao != 0) //validação do campo para melhor entendimento
        //{
        //    //verifica se é administrador
        //    verificacao = 1;
        //}
        objDataReader.Close();
        objconexao.Close();
        objconexao.Dispose();
        objCommand.Dispose();
        objDataReader.Dispose();

        return verificacao; //retorna o valor do resultado da verificação feita acima
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