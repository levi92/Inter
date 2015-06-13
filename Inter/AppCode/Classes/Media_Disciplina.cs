using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Media_Disciplina
    {

        private int mdd_codigo;
        private double mdd_media;
        private Projeto_Inter pri_codigo;
        private Atribuicao_PI adi_codigo;
        private Grupo gru_codigo;

        public Atribuicao_PI Adi_codigo
        {
            get { return adi_codigo; }
            set { adi_codigo = value; }
        }

        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

        public global::Grupo Gru_codigo
        {
            get { return gru_codigo; }
            set { gru_codigo = value; }
        }

        public double Mdd_media
        {
            get { return mdd_media; }
            set { mdd_media = value; }
        }

        public int Mdd_codigo
        {
            get { return mdd_codigo; }
            set { mdd_codigo = value; }
        }

    }
