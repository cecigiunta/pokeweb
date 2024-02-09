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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Entrenador user = new Entrenador();
                EntrenadorNegocio negocio = new EntrenadorNegocio();
                user.Email = txtEmailRegistro.Text;
                user.Pass = txtPasswordRegistro.Text;
                int id = negocio.insertarNuevo(user);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}