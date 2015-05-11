using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Criterios_Gerais{

    private int cge_codigo;
    private string cge_descricao;
    private string cge_nome;
    private bool cge_ativo;

   
    public string Cge_nome{
        get { return cge_nome; }
        set { cge_nome = value; }
    }

    public string Cge_descricao{
        get { return cge_descricao; }
        set { cge_descricao = value; }
    }

    public int Cge_codigo{
        get { return cge_codigo; }
        set { cge_codigo = value; }
    }

    public bool Cge_ativo
    {
        get { return cge_ativo; }
        set { cge_ativo = value; }
    }

}