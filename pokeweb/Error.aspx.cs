using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokeweb
{
    public partial class Error : System.Web.UI.Page
    {
        //pantalla de error generica
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Session["error"].ToString();
            }
        }
    }
}


// SI DA EL ERROR DE ABORT EXCEPTION ES PORQUE AL RESPONSE REDIRECT LE FALTA EL ", FALSE"
// en todas las pantallas de FRONT, tendria q tener try y catch guardando excepcion y renavegando a pagina de error
// REVISAR la app y agregar en todas que redirige a pantalla de error
// para mejorar, la idea seria manejarlo en un metodo para luego si hay que cambiarlo, que se pueda

/*              EN EL CATCH
                 Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
*/