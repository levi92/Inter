using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Criterio_PI_DB{
    public static int Insert(Criterio_PI criterio)
    {
        int retorno = 0;
        try
        {
            IDbConnection conexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO cpi_criterio_pi(cpi_codigo, cge_codigo, pri_codigo, adi_codigo, cpi_peso) VALUES(0, ?cge_codigo, ?pri_codigo, ?adi_codigo, ?cpi_peso)";
            conexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, conexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cge_codigo", criterio.Cge_codigo.Cge_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", criterio.Pri_codigo.Pri_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", criterio.Adi_codigo.Adi_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cpi_peso", criterio.Cpi_peso));
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

    //SELECIONA TODOS OS PESOS E CRITÉRIOS DO PI ATIVO E DA MATÉRIA SELECIONADA
    public static DataSet SelectCriteriosPesosByPI(int codPi, int codAtr)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT CG.CGE_NOME, CG.CGE_DESCRICAO, CP.CPI_PESO FROM CPI_CRITERIO_PI CP INNER JOIN CGE_CRITERIOS_GERAIS CG USING(CGE_CODIGO) WHERE CP.PRI_CODIGO = ?pri_codigo AND CP.ADI_CODIGO = ?adi_codigo;", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?pri_codigo", codPi));
        objCommand.Parameters.Add(Mapped.Parameter("?adi_codigo", codAtr));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}