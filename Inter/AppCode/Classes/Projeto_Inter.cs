using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Projeto_Inter
    {

        private int pri_codigo;
        private Semestre_Ano san_codigo;
       

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
