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
                //Si se AGREGA un pokemon

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

                // Si se MODIFICA un pokemon
                if (Request.QueryString["id"] != null && !IsPostBack)  //si viene el querystring con un id..
                {
                    //voy a la bd a traerme el pokemon
                    PokemonNegocio negocio = new PokemonNegocio();
                    List<Pokemon> lista = negocio.listar(Request.QueryString["id"].ToString());
                    Pokemon seleccionado = lista[0];  //como el metodo devuelve 1 solo si le paso el id, seria en la posicion 0

                    //Pre cargamos los campos
                    txtId.Text = Request.QueryString["id"];
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagenUrl.Text = seleccionado.UrlImagen;
                    txtNumero.Text = seleccionado.Numero.ToString();

                    // preseleccionar los desplegables Tipo y debilidad
                    ddTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    // forzamos el evento para que la imagen aparezca cargada...
                    txtUrlImagenUrl_TextChanged(sender, e);  

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

                //NUEVO MODIFICAR: PREGUNTO SI AGREGO O SI MODIFICO

                if (Request.QueryString["id"]!= null) //si el ID vino distinto de nulo, significa q quiero modificar
                {
                    // le paso el ID
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                } else
                {
                    negocio.agregarConSP(nuevo);

                }



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