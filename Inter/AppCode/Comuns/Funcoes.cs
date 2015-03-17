using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for funcoes
/// </summary>

namespace Inter.Funcoes
{
    public class Funcoes
    {

        // CHAMAR A MASTER PAGE  
        public static string chamarMasterPage(string mae)
        {
            if (mae == "True")
            {
                return "~/paginas/Usuario/MasterPageMenuMae.master";
            }
            else
                return "~/paginas/Usuario/MasterPageMenuFilha.master";

        }


    }
}