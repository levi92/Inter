using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Mensagem
{

    public int Id { get; private set; } //CHAVE PRIMÁRIA.Identificador da Mensagem. Set privado porque o ID é autoincrementado no BD
    public string Id_Enviado { get; set; } //Identificador do usuario que enviou a mensagem
    public int Id_Ticket { get; set; } //Identificador do ticket ao qual a mensagem pertence
    public DateTime Timestamp { get; set; } //Data e hora de envio da mensagem
    public string Corpo { get; set; } //Conteúdo da mensagem 
}
