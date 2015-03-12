using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Disciplinas_Gerais{

    private int dge_codigo;
    private string dge_nome, dge_sigla;

   
    public int Dge_codigo{
        get { return dge_codigo; }
        set { dge_codigo = value; }
    }  

    public string Dge_nome{
        get { return dge_nome; }
        set { dge_nome = value; }
    }

    public string Dge_sigla{
        get { return dge_sigla; }
        set { dge_sigla = value; }
    }
}