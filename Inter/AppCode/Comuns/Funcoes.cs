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

        /// <summary>
        /// Função para verificar e retornar o caminho da master page correspondent a mãe ou filha.
        /// </summary>
        /// <param name="mae"> Recebe o que está na sessão mãe (True/False) </param>
        /// <returns> Retorna o caminho da masterpage</returns>
        public static string chamarMasterPage(string mae)
        {
            if (mae == "True")
            {
                return "~/paginas/Usuario/MasterPageMenuMae.master";
            }
            else
                return "~/paginas/Usuario/MasterPageMenuFilha.master";

        }

        public static string chamarMasterPage_Admin(string coord)
        {
            
            if (coord == "True")
            {
                return "~/paginas/Administrador/MasterPage_MenuCoord.master";
            }
            else
            {
                return "~/paginas/Administrador/MasterPage_MenuMaster.master";
            }
        }


    }
}