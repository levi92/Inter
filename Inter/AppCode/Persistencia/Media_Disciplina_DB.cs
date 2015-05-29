using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Media_Disciplina_DB
    {
        public static int Insert(Media_Disciplina mdd)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO mdd_media_disciplina(mdd_codigo, pri_codigo, adi_codigo, gru_codigo, med_media) VALUES(0, ?pri_codigo, ?adi_codigo, ?gru_codigo, ?med_media)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", mdd.Adi_codigo.Adi_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", mdd.Pri_codigo.Pri_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gru_codigo", mdd.Gru_codigo.Gru_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?med_media", mdd.Mdd_media));
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
    }

