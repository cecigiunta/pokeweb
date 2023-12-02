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


            //Cargo de datos el Repeater
            if (!IsPostBack)
            {
                repetidor.DataSource = ListaPokemon;
                repetidor.DataBind();

            }
            //la sintaxis es mas limpia con el repeater, solo hacemos pequeñas adiciones de C# para las propiedades
            //con el repetar podemos mandar un dato al code behind con un boton y el CommandArgument

        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            //el object sender es el elemento que envia el evento, en este caso es el boton
            //transformo el objeto sender en un objeto boton

            string valor = ((Button)sender).CommandArgument;
        }
    }
}