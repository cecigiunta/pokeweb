using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //luego de haber creado la consulta y cambiado la consulta en pokemon negocio
    //Creo la nueva clase Elemento
    //en pokemon.cs agrego la nueva propiedad tambien
    public class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }



        //Como muestra la definicion de la clase ejecutando el toString, hay que sobreescribirlo para que muestre el tipo:
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
