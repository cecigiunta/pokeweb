using dominio;
using negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokeweb
{
    public partial class EjDropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //ejemplo DropDownList con BD
                if (!IsPostBack)
                {
                    dropPokemon.DataSource = negocio.listarConSP();
                    dropPokemon.DataBind();


                    /* EJEMPLO dropdown enlazados:
                     * Para que empiecen todos cargados:
                    dropPokemonFiltrados.DataSource = listaPokemon;
                    dropPokemonFiltrados.DataBind();
               

                    List<Tipo> listaTipo = negocioTipo.listar();

                     dropTipos.DataSource = listaTipo;
                     dropTipos.DataTextField = "Descripcion";
                     dropTipos.DataValueField = "Id";
                     dropTipos.DataBind();
                    */

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dropTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //como tiene el autopostback en true, el mismo elemento es capaz de ejecutar el metodo o la accion

            /*  EJEMPLO DROP ENLAZADOS
            CAPTURO EL ID, HAGO UAN BUSQUEDA EN LA LISTA DONDE TODOS LOS POKEMON CUYO ID DE TIPO SEA EL MISMO, Q LOS DEVUELVA

            Recuperar el valor de algo que seleccionaron en un DropDown
            int id = int.Parse(dropTipos.SelectedItem.Value);

            dropPokemonFiltrados.DataSource = ((List<Pokemon>)Session["listaPokemon"]).FindAll(x => Tipo.Id == id);
            dropPokemonFiltrados.DataBind();
            */



        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string id = txtTipo.Text;
            
            //De este elemento, dame el indice que encuentres en este lugar

            DropTipoPreseleccionado.SelectedIndex = DropTipoPreseleccionado.Items.IndexOf(
                DropTipoPreseleccionado.Items.FindByValue(id));
        }
    }
}