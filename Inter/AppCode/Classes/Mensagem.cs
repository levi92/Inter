using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mensagem
{

    //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    public int CodigoMensagem { get; set; }
    //Identificador do ticket ao qual a mensagem pertence
    public int CodigoReq { get; set; }
    //Matricula do Professor que enviou a mensagem
    public string MatriculaPer { get; set; }
    //Data e hora de envio da mensagem
    public DateTime DataEnvio { get; set; }
    //Conteúdo da mensagem 
    public string Conteudo { get; set; }
    //Identificador do usuario que enviou a mensagem
    public string Usuario { get; set; }
    
    //CONSTRUTOR PARA INSERT
    public Mensagem (int codrequerimento, string matricula, string conteudo, string usuario)
    {
        CodigoReq = codrequerimento;
        MatriculaPer = matricula;
        DataEnvio = DateTime.Now;
        Conteudo = conteudo;
        Usuario = usuario;
    }

    //CONSTRUTOR PARA SELECT
    public Mensagem(int codrequerimento, string matricula, DateTime dataenvio, string conteudo, int codigoMensagem, string usuario)
    {
        CodigoReq = codrequerimento;
        MatriculaPer = matricula;
        DataEnvio = dataenvio;
        Conteudo = conteudo;
        CodigoMensagem = codigoMensagem;
        Usuario = usuario;
    }
}
