using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokeweb
{
    public partial class Pagina2LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hacemos la validacion para que si el usuario NO es admin, no pueda ver el contenido
            if (! (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "no tienes permisos para ingresar");
                Response.Redirect("Error.aspx", false);

                // Response.Redirect("../Error.aspx", false);

            }
        }
    }
}