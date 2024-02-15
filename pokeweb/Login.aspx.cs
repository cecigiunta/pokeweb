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
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}