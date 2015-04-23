using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Projeto_Inter
    {

        private int pri_codigo;
        private Semestre_Ano san_semestre_ano;
        private string pri_descricao, pri_ementa;
        private Atribuicao_Disciplina adi_codigo;

        public global::Semestre_Ano San_semestre_ano
        {
            get { return san_semestre_ano; }
            set { san_semestre_ano = value; }
        }

        public global::Atribuicao_Disciplina Adi_codigo
        {
            get { return adi_codigo; }
            set { adi_codigo = value; }
        }

        public string Pri_ementa
        {
            get { return pri_ementa; }
            set { pri_ementa = value; }
        }

        public string Pri_descricao
        {
            get { return pri_descricao; }
            set { pri_descricao = value; }
        }

        public int Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

    }
