using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Turma{

    private int trm_codigo;    
    private Turno tur_codigo;
    private Curso cur_codigo;
    private string trm_nome;

    
    public int Trm_codigo{
        get { return trm_codigo; }
        set { trm_codigo = value; }
    }

    public global::Turno Tur_codigo{
        get { return tur_codigo; }
        set { tur_codigo = value; }
    }

    public global::Curso Cur_codigo{
        get { return cur_codigo; }
        set { cur_codigo = value; }
    }

    public string Trm_nome{
        get { return trm_nome; }
        set { trm_nome = value; }
    }
}