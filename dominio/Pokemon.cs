using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {

        //MODIFICAR : NUEVO - Agregamos la property id
        public int Id { get; set; }


        [DisplayName("Número")]   //ANNOTATION: Para que funcione, va ARRIBA del atributo que quiero modificar
        public int Numero { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string UrlImagen { get; set; }

        //Creo la nueva propiedad que va a ser el Tipo (es de tipo Elemento, la clase q cree)
        public Elemento Tipo { get; set; }

        public Elemento Debilidad { get; set; }
    }
}
