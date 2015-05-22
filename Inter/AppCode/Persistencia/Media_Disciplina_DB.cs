using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Persistencia
{
    public class Media_Disciplina_DB
    {
        public static int Insert(Media_Disciplina mdd)
        {
            int retorno = 0;
            try
            {
                IDbConnection conexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO mdd_media_disciplina(mdd_codigo, adi_codigo, pri_codigo, gru_codigo, mdd_media) VALUES(?mdd_codigo, ?adi_codigo, ?pri_codigo, ?gru_codigo, ?mdd_media)";
                conexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, conexao);
                objCommand.Parameters.Add(Mapped.Parameter("?mdd_codigo", mdd.Mdd_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", mdd.Adi_codigo));
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
}
