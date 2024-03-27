using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocios;

namespace pokeweb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Entrenador entrenador = new Entrenador();
            EntrenadorNegocio negocio = new EntrenadorNegocio();

            try
            {
                //VALIDACIONES CLASICAS: 
                /*
                if(Validacion.validaTextoVacio(txtEmailLogin) || Validacion.validaTextoVacio(txtPasswordLogin))
                {
                    Session.Add("error", "Email o Password vacíos");
                    Response.Redirect("Error.aspx");
                }
                */

                entrenador.Email = txtEmailLogin.Text;
                entrenador.Pass = txtPasswordLogin.Text;

                if (negocio.Login(entrenador))  //si el logueo dió true (el metodo login devuelve true/false...)  
                {
                    Session.Add("entrenador", entrenador); //vamos a agregar a session el objeto entrenador
                                                           //nos va a ayudar a saber si esta logueado o no o admin
                    Response.Redirect("MiPerfil.aspx", false);

                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            //para evitar que el Abort exception corte la ejecucion, capturo la excepcion y que no haga nada
            catch(System.Threading.ThreadAbortException ex) { }

            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }


        //Manejo de Error GENERICO a nivel Pantalla:
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("error", exc.ToString());

            // Tenemos que hacer la navegacion por Server.Transfer, no por Response.Redirect
            Server.Transfer("Error.aspx", true);
        }
    }
}