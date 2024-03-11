using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocios;
using dominio;

namespace pokeweb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        
        //CAMBIO EL EVENTO LOAD DE LA MASTER PARA QUE MUESTRE EL MAIL Y SIEMPRE MUESTRE LA IMG VACIA
        protected void Page_Load(object sender, EventArgs e)
        {
            //primero pone por defecto una img vacia
            imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Default_pfp.svg";

            //En el load de la MASTER PAGE vamos a hacer la validacion de seguridad para ver si el user esta logueado
            //tengo que exceptuar las páginas que NO quiero que me valide. Va a tener el obj al que se esta dirigiendo la MasterPage 
            //le pregunto CUAL es la page que está dibujando
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                if (!(Seguridad.sessionActiva(Session["entrenador"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else  //Si HAY una session
                {
                    Entrenador entrenador = (Entrenador)Session["entrenador"];  //capturo el user
                    lblUser.Text = entrenador.Email;  //y me guardo en la label el nombre
                    if (! string.IsNullOrEmpty(entrenador.ImagenPerfil))  //si NO es nulo, que tambien me muestre la img
                    {
                        imgAvatar.ImageUrl = "~/Images/" + ((Entrenador)Session["entrenador"]).ImagenPerfil;
                    }

                }

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}