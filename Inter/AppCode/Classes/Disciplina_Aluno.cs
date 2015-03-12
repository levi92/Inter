using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Disciplina_Aluno{

    private Aluno alu_matricula;    
    private Atribuicao_Disciplina adi_codigo;
    private string semestre_ano;

    public string Semestre_ano
    {
        get { return semestre_ano; }
        set { semestre_ano = value; }
    }
    

    public global::Aluno Alu_matricula{
        get { return alu_matricula; }
        set { alu_matricula = value; }
    }

    public global::Atribuicao_Disciplina Adi_codigo{
        get { return adi_codigo; }
        set { adi_codigo = value; }
    }
}