using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



    public class Atribuicao_PI{

        private Projeto_Inter pri_codigo;
        private int adi_codigo;
        private bool adi_mae;

        public bool Adi_mae
        {
            get { return adi_mae; }
            set { adi_mae = value; }
        }


        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }        

        public int Adi_codigo
        {
            get { return adi_codigo; }
            set { adi_codigo = value; }
        }


    }

