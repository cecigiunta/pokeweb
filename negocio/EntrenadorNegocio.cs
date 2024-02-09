using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dominio;
using System.Threading.Tasks;

namespace negocios
{
    public class EntrenadorNegocio
    {
        //id es automatico
        //datos que tenemos : id, email password y admin
        // no tenemos: nombre apellido img fecha

        public int insertarNuevo(Entrenador nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar(); //que devuelva el id del dato ingresado
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



/*PROCEDIMIENTO INSERTARNUEVO
 
 create procedure insertarNuevo
@email varchar (50),
@pass varchar (50)
as

insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)g


exec insertarNuevo
 
 ---- vamos a obtener por medio de OUTPUT el id del user que acabo de generar
--- output inserted.id con esto devuelve el ID del ultimo user que genero
--- el procedim devuelve un valor entero, que es el id, seria como un return
g
 
 */
