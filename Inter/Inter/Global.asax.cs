using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Inter
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private static void RegisterRoutes()
        {
            System.Web.Routing.RouteTable.Routes.Add("Login",
                new System.Web.Routing.Route("Login", new
                                  PageRouteHandler("~/paginas/Login/login.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("BloqueioUrl",
                new System.Web.Routing.Route("BloqueioUrl", new
                                  PageRouteHandler("~/paginas/Login/bloqueioUrl.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("AvaliarGrupo",
                new System.Web.Routing.Route("AvaliarGrupo", new
                                  PageRouteHandler("~/paginas/Usuario/avaliarGrupo.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("CadastrarPI",
                new System.Web.Routing.Route("CadastrarPI", new
                                  PageRouteHandler("~/paginas/Usuario/cadastrarPi.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("ConsultarPI",
                new System.Web.Routing.Route("ConsultarPI", new
                                  PageRouteHandler("~/paginas/Usuario/consultarPi.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("EscolherDisciplina",
                new System.Web.Routing.Route("EscolherDisciplina", new
                                  PageRouteHandler("~/paginas/Usuario/escolherDisciplina.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("FinalizarGrupo",
                new System.Web.Routing.Route("FinalizarGrupo", new
                                  PageRouteHandler("~/paginas/Usuario/finalizarGrupo.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("Home",
                new System.Web.Routing.Route("Home", new
                                  PageRouteHandler("~/paginas/Usuario/home.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("Notificacoes",
                new System.Web.Routing.Route("Notificacoes", new
                                  PageRouteHandler("~/paginas/Usuario/notificacoes.aspx")));

            System.Web.Routing.RouteTable.Routes.Add("PIFinalizado",
                new System.Web.Routing.Route("PIFinalizado", new
                                  PageRouteHandler("~/paginas/Usuario/piFinalizado.aspx")));

        }
    }
}