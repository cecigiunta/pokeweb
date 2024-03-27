using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocios
{
    public static class Validacion
    {
        public static bool validaTextoVacio(object control)
        {
            if(control is TextBox)
            {
                if (string.IsNullOrEmpty(((TextBox)control).Text))
                {
                    return false;  //si el campo está vacio, false, no valida
                }
                else
                {
                    return true;
                }
            }

            return true;
        }
















    }
}
