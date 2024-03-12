using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Entrenador //es como nuestra clase usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenPerfil { get; set; }
        public bool Admin { get; set; }


        // EJEMPLO: VALIDACION EN LAS PROPIEDADES
        /*private string email2;
        public string Email2
        {
            get { return email2; }
            set
            {
                if (value != "")
                {
                email2 = value;

                } else
                {
                    throw new Exception("email vacio en el dominio");
                }
            }
        }
        */

        // nivel BD: las tablas que admiten o no admiten NULL, las constraints que son REGLAS por si las tablas se relacionan
    }
}
