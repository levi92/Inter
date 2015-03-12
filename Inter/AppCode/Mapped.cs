using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//As bibliotecas MySql 
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public class Mapped{

    // Método de Conexão 
    
    public static IDbConnection Connection(){        
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);       
        conexao.Open();       
        return conexao;
    }

    // Comandos SQL - Cria o objeto e valida o comando a ser executado

    public static IDbCommand Command(string query, IDbConnection conexao){
       IDbCommand command = conexao.CreateCommand();      
        command.CommandText = query;
        return command;
    }

    // Executa o comando
   
    public static IDataAdapter Adapter(IDbCommand command){        
        IDbDataAdapter adap = new MySqlDataAdapter();        
        adap.SelectCommand = command;
        return adap;
    }

    //  Parametrização

    public static IDbDataParameter Parameter(string nomeDoParametro, object valor){      
        return new MySqlParameter(nomeDoParametro, valor);
    }
}