using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Mensagem
{

    private int men_id;
    private int men_id_enviado;
    private DateTime men_hora;
    private string men_corpo;
    private int men_tic_id;


    public int Men_id
    {
        get { return men_id; }
        set { men_id = value; }
    }

    public int Men_id_enviado
    {
        get { return men_id_enviado; }
        set { men_id_enviado = value; }
    }

    public DateTime Men_hora
    {
        get { return men_hora; }
        set { men_hora = value; }
    }

    public string Men_corpo
    {
        get { return men_corpo; }
        set { men_corpo = value; }
    }

    public int Men_tic_id
    {
        get { return men_tic_id; }
        set { men_tic_id = value; }
    }

}