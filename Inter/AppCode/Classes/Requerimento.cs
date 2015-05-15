using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Requerimento{

    //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    public int CodigoReq { get; set; }

    //Identificador do ticket ao qual a mensagem pertence
    public string MatriculaPro { get; set; }

    //Identificador do ticket ao qual a mensagem pertence
    public Grupo CodigoGrupo { get; set; }

    //Identificador do ticket ao qual a mensagem pertence
    public string Assunto {get; set; }

    //Data e hora de envio da mensagem
    public DateTime? DataReq { get; set; }

    //Conteúdo da mensagem 
    public int Status { get; set; }

    //Conteúdo da mensagem 
    public string Categoria { get; set; } 


}