using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Aluno{

    private int alu_matricula;
    private Pessoas pes_codigo;    


    public int Alu_matricula{
        get { return alu_matricula; }
        set { alu_matricula = value; }
    }   

    public global::Pessoas Pes_codigo{
        get { return pes_codigo; }
        set { pes_codigo = value; }
    }


}