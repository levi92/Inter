using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Pessoas{

    private int pes_codigo;
    private string pes_nome, pes_email, pes_tel, pes_cel;


    public int Pes_codigo{
        get { return pes_codigo; }
        set { pes_codigo = value; }
    }   

    public string Pes_cel{
        get { return pes_cel; }
        set { pes_cel = value; }
    }

    public string Pes_tel{
        get { return pes_tel; }
        set { pes_tel = value; }
    }

    public string Pes_email{
        get { return pes_email; }
        set { pes_email = value; }
    }

    public string Pes_nome{
        get { return pes_nome; }
        set { pes_nome = value; }
    }
}