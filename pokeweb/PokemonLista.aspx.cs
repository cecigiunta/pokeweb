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
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.listarConSP();
            dgvPokemons.DataBind();



        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();  //capturo el valor y voy a la otra pagina ya con el ID
            Response.Redirect("FormPokemon.aspx?id=" + id);
        }
    }
}