using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Mensagem
{

    //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    public int CodigoMsg { get; set; }

    //Identificador do usuario que enviou a mensagem
    public int CodigoReq { get; set; }

    //Identificador do ticket ao qual a mensagem pertence
    public string MatriculaPro { get; set; }

    //Identificador do ticket ao qual a mensagem pertence
    public string MatriculaAdm { get; set; }

    //Data e hora de envio da mensagem
    public DateTime? DataEnvio { get; set; }

    //Conteúdo da mensagem 
    public string Conteudo { get; set; } 
}
