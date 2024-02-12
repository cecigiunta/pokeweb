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

        public bool Login(Entrenador entrenador)
        {
            //vamos a tener q hacer una conexion a BD para ver si las credenciales q vienen en ese objeto
            // existen realmente
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, email, pass, admin FROM USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", entrenador.Email);
                datos.setearParametro("@pass", entrenador.Pass);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    //necesito que lea 1 vez o da false
                    //si me trajo el id hay user
                    entrenador.Id = (int)datos.Lector["id"];
                    entrenador.Admin = (bool)datos.Lector["admin"];

                    return true;

                }
                return false; //no hay usuario logueado
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
