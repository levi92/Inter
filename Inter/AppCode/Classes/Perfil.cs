using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 public class Perfil
    {
        private string per_matricula;
        private int per_descricao;
        private string per_login;
        private string per_senha;

        public string Per_matricula
        {
            get { return per_matricula; }
            set { per_matricula = value; }
        }

        public int Per_descricao
        {
            get { return per_descricao; }
            set { per_descricao = value; }
        }
     
        public string Per_login
        {
            get { return per_login; }
            set { per_login = value; }
        }   

        public string Per_senha
        {
            get { return per_senha; }
            set { per_senha = value; }
        }


    }

