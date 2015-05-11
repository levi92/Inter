using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Ticket
{

    private int tic_id_professor, tic_estado, tic_prioridade, tic_id;
    private string tic_assunto, tic_tipo;
    private DateTime tic_data;


    public int Tic_id
    {
        get { return tic_id; }
        set { tic_id = value; }
    }

    public string Tic_assunto
    {
        get { return tic_assunto; }
        set { tic_assunto = value; }
    }

    public int Tic_id_professor
    {
        get { return tic_id_professor; }
        set { tic_id_professor = value; }
    }

    public int Tic_estado
    {
        get { return tic_estado; }
        set { tic_estado = value; }
    }

    public DateTime Tic_data
    {
        get { return tic_data; }
        set { tic_data = value; }
    }

    public string Tic_tipo
    {
        get { return tic_tipo; }
        set { tic_tipo = value; }
    }

    public int Tic_prioridade
    {
        get { return tic_prioridade; }
        set { tic_prioridade = value; }
    }

}