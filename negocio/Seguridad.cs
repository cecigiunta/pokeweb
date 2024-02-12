using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocios
{
    public static class Seguridad
    {

        public static bool sessionActiva(object user)
        {
            //validacion para que si NO hay un user logueado, que lo lleve al login

            Entrenador entrenador = user != null ? (Entrenador)user : null;
            if (entrenador != null && entrenador.Id != 0)  //Si hay user, está logueado...
            {
                return true;
            }
            return false;
        }


        //metodo para validar SI ES ADMIN , valido que haya un user logueado
        public static bool esAdmin(object user)
        {
            Entrenador entrenador = user != null ? (Entrenador)user : null;
            return entrenador != null ? entrenador.Admin : false; //devuelvo la propiedad booleana admin 
        }
    }
}
