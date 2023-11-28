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
    public partial class Default : System.Web.UI.Page
    {
        //me creo una propertie que va a ser una lista
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ListaPokemon = negocio.listarConSP();  //y la voy a cargar con los result del metodo listar

        }
    }
}