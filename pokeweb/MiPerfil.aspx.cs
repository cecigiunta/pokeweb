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
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["entrenador"]))
                    {
                        Entrenador entrenador = (Entrenador)Session["entrenador"];
                        txtEmailPerfil.Text = entrenador.Email;
                        txtEmailPerfil.ReadOnly = true;
                        txtNombrePerfil.Text = entrenador.Nombre;
                        txtApellidoPerfil.Text = entrenador.Apellido;
                        txtFecNacPerfil.Text = entrenador.FechaNacimiento.ToString("yyyy-MM-dd"); //darle formato porq lo pide
                        if (!string.IsNullOrEmpty(entrenador.ImagenPerfil))
                        {
                            imageNuevoPerfil.ImageUrl = "~/Images/" + entrenador.ImagenPerfil;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                //NUEVO : VALIDATORS ASP REQUIRED
                Page.Validate();  //va a ejecutar las validaciones configuradas
                if (!Page.IsValid)
                {
                    return;   // le pregunto si la pagina NO es valida, que finaliza la ejecucion del evento
                }




                EntrenadorNegocio negocio = new EntrenadorNegocio();
                Entrenador entrenador = (Entrenador)Session["entrenador"];  

                //Validacion para que si no hay nada seleccionado, que no guarde nada vacio y no rompa la bd
                if(txtImagen.PostedFile.FileName != "")
                {
                    //tener un lugar FISICO donde guardar las imagenes, no es la BD. Es una carpeta
                    //Ya creamos la carpeta images dentro de nuestro proyecto. Hay que hacer la ruta a esa carpeta
                    string ruta = Server.MapPath("./Images/");
                    //MapPath: retorna la ruta fisica que corresponde a la ruta virtual para que yo luego le agregue la img

                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + entrenador.Id + ".jpg");
                    //recupero el archivo que ingresaron. para darle nombre a la img le ponemos el id de usuario y le agregamos la extensión JPG

                    entrenador.ImagenPerfil = "perfil-" + entrenador.Id + ".jpg"; //ahora guardamos en BD. Guardamos el nombre de img con el ID user

                }

                entrenador.Nombre = txtNombrePerfil.Text;
                entrenador.Apellido = txtApellidoPerfil.Text;
                entrenador.Email = txtEmailPerfil.Text;
                //nuevo : capturar y guardar fecha de nacimiento
                entrenador.FechaNacimiento = DateTime.Parse(txtFecNacPerfil.Text);

                negocio.actualizar(entrenador);

                //Leer img: tengo que acceder a la imagen de avatar de la MASTER
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