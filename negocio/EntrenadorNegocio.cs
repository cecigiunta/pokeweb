using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dominio;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace negocios
{
    public class EntrenadorNegocio
    {

        //ACTUALIZAR PARA IMG PERFI
        public void actualizar(Entrenador entrenador)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //CAMBIO CONSULTA Y PARAMETROS ASI TB ACTUALIZA NOMBRE APELLIDO y fechanacimiento
                datos.setearConsulta("update USERS set imagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fecha Where Id = @id");
                datos.setearParametro("@imagen", entrenador.ImagenPerfil != null ? entrenador.ImagenPerfil : ""); //validacion q no sea nula
                datos.setearParametro("@nombre", entrenador.Nombre);
                datos.setearParametro("@apellido", entrenador.Apellido);
                datos.setearParametro("@fecha", entrenador.FechaNacimiento);
                datos.setearParametro("@id", entrenador.Id);
                datos.ejecutarAccion();
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


        public int insertarNuevo(Entrenador nuevo)
        {

            //id es automatico
            //datos que tenemos : id, email password y admin
            // no tenemos: nombre apellido img fecha

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
            //conexion a BD para ver si las credenciales q vienen en ese objeto existen realmente
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //HACER QUE TAMBIEN LEA LA IMAGEN CUANDO SE LOGUEA EN LA CONSULTA
                datos.setearConsulta("Select id, email, pass, admin, imagenPerfil, nombre, apellido, fechaNacimiento FROM USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", entrenador.Email);
                datos.setearParametro("@pass", entrenador.Pass);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    entrenador.Id = (int)datos.Lector["id"];
                    entrenador.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["imagenPerfil"] is DBNull)) //lo cargo solo si no es nulo
                    {
                        entrenador.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    }
                    if (!(datos.Lector["nombre"] is DBNull)) 
                    {
                        entrenador.Nombre = (string)datos.Lector["nombre"];
                    }
                    if (!(datos.Lector["apellido"] is DBNull)) 
                    {
                        entrenador.Apellido = (string)datos.Lector["apellido"];
                    }
                    if (!(datos.Lector["fechaNacimiento"] is DBNull)) 
                    {
                        entrenador.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());
                    }
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
