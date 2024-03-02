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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            




        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                EntrenadorNegocio negocio = new EntrenadorNegocio();

                // ESCRIBIR IMG
                //tener un lugar FISICO donde guardar las imagenes, no es la BD. Es una carpeta
                //Ya creamos la carpeta images dentro de nuestro proyecto. Hay que hacer la ruta a esa carpeta
                string ruta = Server.MapPath("./Images/");
                //MapPath: retorna la ruta fisica que corresponde a la ruta virtual para que yo luego le agregue la img

                Entrenador entrenador = (Entrenador)Session["entrenador"];  

                //recupero el archivo que ingresaron
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + entrenador.Id + ".jpg");
                //para darle nombre a la img le ponemos el id de usuario y le agregamos la extensión JPG

                //ahora guardamos en BD. Guardamos el nombre de img con el ID user
                entrenador.ImagenPerfil = "perfil-" + entrenador.Id + ".jpg";

                entrenador.Nombre = txtNombrePerfil.Text;
                entrenador.Apellido = txtApellidoPerfil.Text;
                entrenador.Email = txtEmailPerfil.Text;

                negocio.actualizar(entrenador);

                //LEER IMG
                //tengo que acceder a la imagen de avatar de la MASTER
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + entrenador.ImagenPerfil; 
                // lo que hace este ~ es posicionarnos en el home pero de la web, asi buscamos la ruta
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}