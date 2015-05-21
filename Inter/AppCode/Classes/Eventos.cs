using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Eventos
    {

        private int eve_codigo;
        private DateTime eve_data;
        private string eve_tipo;
        private Projeto_Inter pri_codigo;
        

        public global::Projeto_Inter Pri_codigo
        {
            get { return pri_codigo; }
            set { pri_codigo = value; }
        }

        public int Eve_codigo
        {
            get { return eve_codigo; }
            set { eve_codigo = value; }
        }
        public DateTime Eve_data
        {
            get { return eve_data; }
            set { eve_data = value; }
        }
        public string Eve_tipo
        {
            get { return eve_tipo; }
            set { eve_tipo = value; }
        }

    }
