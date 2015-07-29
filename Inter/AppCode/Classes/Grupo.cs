using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Grupo
    {

        private int gru_codigo;
        private string gru_nome_projeto;
        private double gru_media;
        private int gru_finalizado;
        private Projeto_Inter pri_codigo;
        private string gru_usuario;

        /*public Grupo(int codigo, string nome_projeto, int finalizado)
        {
            gru_codigo = codigo;
            gru_nome_projeto = nome_projeto;
            gru_finalizado = finalizado;
        }*/
        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }       

        public int Gru_finalizado
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

        public string Gru_usuario
        {
            get { return gru_usuario; }
            set { gru_usuario = value; }
        }

    }
