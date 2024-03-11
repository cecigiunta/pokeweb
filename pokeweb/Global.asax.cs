using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace pokeweb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        // Le agregamos el evento copiado pero solo dejamos la parte de capturar la excepcion
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Session.Add("error", exc.ToString());

            // Tenemos que hacer la navegacion por Server.Transfer, no por Response.Redirect
            Server.Transfer("Error.aspx", true);

        }


        // PARA PROBAR ERRORES POR EJ EN EL METODO LOGIN EN EL TRY PONEMOS
        /*  throw new Exception("error PRUEBA");
         *  
         *  */

        // OTRA ALTERNATIVA ES A NIVEL PANTALLA, EN CADA PAGINA: PAGE_ERROR
        // https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/aspnet-error-handling

        /*  El PAGE ERROR es como un nivel 2 de errores si NO la manejamos o se escapa de try catch
            el APPLICATION ERROR es como un nivel 3 si falla o no tiene un PAGE ERROR
        Si se hacen manejos de errores independientes, se pueden tomar MAS desiciones por cada error (try catch)

        Recomendacion siempre por evento y por las dudas en global asax
         
        */


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}