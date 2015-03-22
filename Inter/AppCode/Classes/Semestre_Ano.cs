using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe Semestre_Ano
    public class Semestre_Ano
    {
        private int san_codigo;
        private int san_ano;
        private int san_semestre;
        private bool san_ativo;

        public bool San_ativo
        {
            get { return san_ativo; }
            set { san_ativo = value; }
        }

        public int San_semestre
        {
            get { return san_semestre; }
            set { san_semestre = value; }
        }

        public int San_ano
        {
            get { return san_ano; }
            set { san_ano = value; }
        }

        public int San_codigo
        {
            get { return san_codigo; }
            set { san_codigo = value; }
        }
    }

