using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Grupo
    {

        private int gru_codigo;
        private string gru_nome_projeto;
        private double gru_media;
        private bool gru_finalizado;
        private Projeto_Inter pri_codigo, adi_codigo;

        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

        public global::Projeto_Inter Adi_codigo
        {
            get { return adi_codigo; }
            set { adi_codigo = value; }
        }

        public bool Gru_finalizado
        {
            get { return gru_finalizado; }
            set { gru_finalizado = value; }
        }

        public double Gru_media
        {
            get { return gru_media; }
            set { gru_media = value; }
        }

        public string Gru_nome_projeto
        {
            get { return gru_nome_projeto; }
            set { gru_nome_projeto = value; }
        }

        public int Gru_codigo
        {
            get { return gru_codigo; }
            set { gru_codigo = value; }
        }

    }
