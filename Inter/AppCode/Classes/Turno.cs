using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Turno{

    private int tur_codigo;
    private string tur_nome;

    public int Tur_codigo{
        get { return tur_codigo; }
        set { tur_codigo = value; }
    }
    
    public string Tur_nome{
        get { return tur_nome; }
        set { tur_nome = value; }
    }	
}