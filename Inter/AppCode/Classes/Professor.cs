using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Professor{

    private int pro_matricula;
    private bool pro_administrador;
    private string pro_senha, pro_chave_senha;
    private Pessoas pes_codigo;  


    public int Pro_matricula{
        get { return pro_matricula; }
        set { pro_matricula = value; }
    }

    public bool Pro_administrador{
        get { return pro_administrador; }
        set { pro_administrador = value; }
    }

    public string Pro_chave_senha{
        get { return pro_chave_senha; }
        set { pro_chave_senha = value; }
    }

    public string Pro_senha{
        get { return pro_senha; }
        set { pro_senha = value; }
    }

    public global::Pessoas Pes_codigo{
        get { return pes_codigo; }
        set { pes_codigo = value; }
    }
}