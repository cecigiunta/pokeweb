using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocios
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>(); //necesito crear la lista
            AccesoDatos datos = new AccesoDatos();     //necesito crear el acceso a datos, con esto nace el objeto con la conexion, comando y cadena de conexion configurada
                       
            try
            {
                //el prox paso es abrir sql y generar la consulta a los ELEMENTOS , para poder despues copiarla aca:
                datos.setearConsulta("Select Id, Descripcion From ELEMENTOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
