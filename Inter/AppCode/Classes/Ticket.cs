using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ticket
{
    private int id;
    private string assunto;
    private int id_professor;
    private DateTime data;
    private int estado;
    private string tipo;
    private int prioridade;
    private List<Msg> mensagens;

    public Ticket(int id, string assunto, int id_professor, DateTime data, int estado, string tipo, int prioridade, List<Msg> mensagens)
    {
        this.id = id;
        this.assunto = assunto;
        this.id_professor = id_professor;
        this.data = data;
        this.estado = estado;
        this.tipo = tipo;
        this.prioridade= prioridade;
        this.mensagens = mensagens;
    }
}