using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocios;


namespace pokeweb
{
    public partial class LoginEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoguear_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();


            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MenuLoginEjemplo.aspx", false); //si loguea, me guardo el user en session
                }
                else
                {
                    Session.Add("error", "user o pass incorrecta");
                    Response.Redirect("Error.aspx", false);
                }
                usuario.User = txtUser.Text;
                usuario.Pass = txtPassword.Text;


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }
        }
    }
}