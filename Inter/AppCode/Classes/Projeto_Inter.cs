using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Projeto_Inter
    {

        private int pri_codigo;
        private Semestre_Ano san_codigo;
        private int pri_semestre;
        private string cur_nome;

        public string Cur_nome
        {
            get { return cur_nome; }
            set { cur_nome = value; }
        }

        public int Pri_semestre
        {
            get { return pri_semestre; }
            set { pri_semestre = value; }
        }

        public global::Semestre_Ano San_codigo
        {
            get { return san_codigo; }
            set { san_codigo = value; }
        }     

        public int Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

    }
