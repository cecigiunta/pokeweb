using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokeweb
{
    public partial class UpdatePanel : System.Web.UI.Page
    {
        public string urlImagen { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptarUP_Click(object sender, EventArgs e)
        {
            txtNombreUP.Text = "texto cambiado desde el back";

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblNombreUP.Text = txtNombreUP.Text;
        }

        protected void txtUrlImagenUP_TextChanged(object sender, EventArgs e)
        {
            //esto es desde el textbox
            urlImagen = txtUrlImagenUP.Text;
        }

        protected void btnImagenUP_Click(object sender, EventArgs e)
        {
            urlImagen = txtUrlImagenUP.Text;
        }
    }
}