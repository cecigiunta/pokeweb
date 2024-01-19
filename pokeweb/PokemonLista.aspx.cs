using negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace pokeweb
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked; // para que en la recarga no pierda el valor en el q quedo el checked

            //filtro avanzado
            if (!IsPostBack)
            {
                FiltroAvanzado = false; //arranca en false



                PokemonNegocio negocio = new PokemonNegocio();

                //FILTRO RAPIDO: obtener el listado y guardarlo en session
                Session.Add("listaPokemons", negocio.listarConSP());


                dgvPokemons.DataSource = Session["listaPokemons"]; //ahora hacemos referencia a la lista guardada en session
                dgvPokemons.DataBind();
            }
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();

        }


        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();  //capturo el valor y voy a la otra pagina ya con el ID
            Response.Redirect("FormPokemon.aspx?id=" + id);
        }


        //FILTRO RAPIDO : No filtra en BBDD
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];

            //de la lista voy a crear otra filtrada por NOMBRE  
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();

            //se podria mejorar haciendo un update panel para que se actualice solo esta parte
            // mejorar estilo de textbox
            // agregarle por tipo, numero
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;  //le agrego el estaod contrario al filtro rapido

            //05 02
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();  //primero le hacemos un clear para que no acumule las cosas cargadas
            if(ddlCampo.SelectedIndex.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscarFiltroAv_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.filtrarContraBD(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString());
                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}