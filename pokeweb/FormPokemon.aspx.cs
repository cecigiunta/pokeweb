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
    public partial class FormPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false; //ocultar la caja de texto del ID para que no se pueda escribir

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    //cargar desplegables tipo y debilidad
                    ddTipo.DataSource = lista;
                    ddTipo.DataValueField = "Id";
                    ddTipo.DataTextField = "Descripcion";
                    ddTipo.DataBind();

                    ddDebilidad.DataSource = lista;
                    ddDebilidad.DataValueField = "Id";
                    ddDebilidad.DataTextField = "Descripcion";
                    ddDebilidad.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion pantalla
            }

        }

        protected void txtUrlImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagenUrl.Text;
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;

                //Como captura el valor como texto plano, tengo que generar un elemento para que tenga un objeto
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddTipo.SelectedValue); //hacemos la conversion a int porq llega el ID

                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddDebilidad.SelectedValue);

                negocio.agregarConSP(nuevo);
                Response.Redirect("PokemonLista.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion pantalla
            }
        }
    }
}