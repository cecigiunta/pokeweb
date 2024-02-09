using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokeweb
{
    public partial class MenuLoginEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnPagina1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina1Login.aspx");
        }

        protected void btnPagina2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx");
        }
    }
}