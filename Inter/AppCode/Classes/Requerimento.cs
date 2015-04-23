using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Requerimento{

    private int req_codigo;
    private string req_descricao;
    private DateTime? req_data_requisicao, req_data_inicial, req_data_final;
    private bool req_resolvido;
    private Professor pro_matricula;
    

    public int Req_codigo{
        get { return req_codigo; }
        set { req_codigo = value; }
    }
    public string Req_descricao{
        get { return req_descricao; }
        set { req_descricao = value; }
    }

    public DateTime? Req_data_final{
        get { return req_data_final; }
        set { req_data_final = value; }
    }

    public DateTime? Req_data_inicial{
        get { return req_data_inicial; }
        set { req_data_inicial = value; }
    }

    public DateTime? Req_data_requisicao{
        get { return req_data_requisicao; }
        set { req_data_requisicao = value; }
    }

    public bool Req_resolvido{
        get { return req_resolvido; }
        set { req_resolvido = value; }
    }

    public global::Professor Pro_matricula{
        get { return pro_matricula; }
        set { pro_matricula = value; }
    }

}