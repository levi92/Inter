using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mensagem
{

    //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    private int _codigomsg;
    //Identificador do usuario que enviou a mensagem
    private int _codigoreq;
    //Identificador do ticket ao qual a mensagem pertence
    private string _matriculapro;
    //Data e hora de envio da mensagem
    private DateTime _dataenvio;
    //Conteúdo da mensagem 
    private string _conteudo;

    public Mensagem (int codrequerimento, string matricula, DateTime dataenvio, string conteudo)
    {
        _codigoreq = codrequerimento;
        _matriculapro = matricula;
        _dataenvio = dataenvio;
        _conteudo = conteudo;
    }
}
