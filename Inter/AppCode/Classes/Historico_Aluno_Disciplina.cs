using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Historico_Aluno_Disciplina
    {

        private int his_codigo;
        private double his_nota;
        private Criterio_PI cpi_codigo;
        private Grupo_Aluno alu_matricula;
        private string his_usuario;

        public global::Grupo_Aluno Alu_matricula
        {
            get { return alu_matricula; }
            set { alu_matricula = value; }
        }

        public global::Criterio_PI Cpi_codigo
        {
            get { return cpi_codigo; }
            set { cpi_codigo = value; }
        }

        public double His_nota
        {
            get { return his_nota; }
            set { his_nota = value; }
        }

        public int His_codigo
        {
            get { return his_codigo; }
            set { his_codigo = value; }
        }

        public string His_usuario
        {
            get { return his_usuario; }
            set { his_usuario = value; }
        }

    }
