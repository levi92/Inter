using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Historico_Disciplina{

    private int his_codigo;
    private double his_nota;
    private Criterio_PI cpi_codigo;
    private Projeto_Inter adi_codigo;
    private Grupo_Aluno alu_matricula;

    public global::Grupo_Aluno Alu_matricula{
        get { return alu_matricula; }
        set { alu_matricula = value; }
    }

    public global::Projeto_Inter Adi_codigo{
        get { return adi_codigo; }
        set { adi_codigo = value; }
    }

    public global::Criterio_PI Cpi_codigo{
        get { return cpi_codigo; }
        set { cpi_codigo = value; }
    }    

    public double His_nota{
        get { return his_nota; }
        set { his_nota = value; }
    }

    public int His_codigo{
        get { return his_codigo; }
        set { his_codigo = value; }
    }

}