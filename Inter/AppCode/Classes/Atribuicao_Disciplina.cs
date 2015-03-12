using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Atribuicao_Disciplina{

    private int adi_codigo;
    private string adi_semestre_ano;
    private bool adi_mae;
    private Turma trm_codigo;
    private Turno tur_codigo;
    private Professor pro_matricula;
    private Disciplinas_Gerais dge_codigo;

    public global::Disciplinas_Gerais Dge_codigo{
        get { return dge_codigo; }
        set { dge_codigo = value; }
    }

    public string Adi_semestre_ano{
        get { return adi_semestre_ano; }
        set { adi_semestre_ano = value; }
    }

    public int Adi_codigo{
        get { return adi_codigo; }
        set { adi_codigo = value; }
    }

    public bool Adi_mae{
        get { return adi_mae; }
        set { adi_mae = value; }
    }

    public global::Turma Trm_codigo{
        get { return trm_codigo; }
        set { trm_codigo = value; }
    }

    public global::Turno Tur_codigo{
        get { return tur_codigo; }
        set { tur_codigo = value; }
    }

    public global::Professor Pro_matricula{
        get { return pro_matricula; }
        set { pro_matricula = value; }
    }
}