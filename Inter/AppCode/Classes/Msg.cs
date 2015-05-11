using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Msg
{
    private int id;
    private int id_enviado;
    private DateTime timestamp;
    private string corpo;
    private int id_ticket;

    public Msg(int id, int id_enviado, DateTime hora, string corpo, int id_ticket)
    {
        this.id = id;
        this.id_enviado = id_enviado;
        this.timestamp = timestamp;
        this.corpo = corpo;
        this.id_ticket = id_ticket;
    }

    public string Timestamp()
    {
        return ("Enviado por " + id_enviado + " em " + timestamp);
    }
}
