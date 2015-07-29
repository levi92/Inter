using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Grupo_Aluno
    {

        private Grupo gru_codigo;
        private string alu_matricula;
        private string gal_usuario;

        public global::Grupo Gru_codigo
        {
            get { return gru_codigo; }
            set { gru_codigo = value; }
        }

        public string Alu_matricula
        {
            get { return alu_matricula; }
            set { alu_matricula = value; }
        }

        public string Gal_usuario
        {
            get { return gal_usuario; }
            set { gal_usuario = value; }
        }

    }
