using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mensagem
{

    //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    public int CodigoMensagem { get; }
    //Identificador do usuario que enviou a mensagem
    public int CodigoReq { get; }
    //Identificador do ticket ao qual a mensagem pertence
    public string MatriculaPro { get; }
    //Data e hora de envio da mensagem
    public DateTime DataEnvio { get; }
    //Conteúdo da mensagem 
    public string Conteudo { get; }

    public Mensagem (int codrequerimento, string matricula, DateTime dataenvio, string conteudo)
    {
        CodigoReq = codrequerimento;
        MatriculaPro = matricula;
        DataEnvio = dataenvio;
        Conteudo = conteudo;
    }

    public Mensagem(int codrequerimento, string matricula, DateTime dataenvio, string conteudo, int codigoMensagem)
    {
        CodigoReq = codrequerimento;
        MatriculaPro = matricula;
        DataEnvio = dataenvio;
        Conteudo = conteudo;
        CodigoMensagem = codigoMensagem;
    }
}
