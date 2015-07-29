using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Criterio_PI
    {

        private int cpi_codigo, cpi_peso;
        private Projeto_Inter pri_codigo;
        private Atribuicao_PI adi_codigo;
        private Criterios_Gerais cge_codigo;
        private string cpi_usuario;

        public global::Criterios_Gerais Cge_codigo
        {
            get { return cge_codigo; }
            set { cge_codigo = value; }
        }

        public global::Atribuicao_PI Adi_codigo
        {
            get { return adi_codigo; }
            set { adi_codigo = value; }
        }

        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

        public int Cpi_peso
        {
            get { return cpi_peso; }
            set { cpi_peso = value; }
        }

        public int Cpi_codigo
        {
            get { return cpi_codigo; }
            set { cpi_codigo = value; }
        }

        public string Cpi_usuario
        {
            get { return cpi_usuario; }
            set { cpi_usuario = value; }
        }

    }
