﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Para hacer la conexion a la BD tengo que incluir una libreria:
using System.Data.SqlClient;
using dominio;

namespace negocios
{
    public class PokemonNegocio
    {
        //Creo el primer metodo, le digo qué devuelve (una lista de Pokemon)
        //MODIFICAR POKEMON AGREGO OPCIONAL QUE RECIBA UN ID
        public List<Pokemon> listar(string id = "")
        {
            //Creamos esa lista
            List<Pokemon> lista = new List<Pokemon>();

            SqlConnection conexion = new SqlConnection();

            //las acciones q realizo
            SqlCommand comando = new SqlCommand();

            //Una vez q vuelvan los datos, los guardo aca
            //No genero instancia porque voy a obtener como resultado un objeto
            SqlDataReader lector;

            try
            {
                //lo primero es el servidor, lo segundo es a qué base de datos (database=EL NOMBRE DE LA BD)
                //lo tercero es como me voy  a autenticar(en este caso es cuando usamos Microsoft Auth
                //si tuviese un usuario seria : integrated security= false y le agrego el usr y contra
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";

                //Lo siguiente que configuro es el comando. Le decimos el tipo. Hay 3: 1. Tipo procedimiento almacenado: le voy a pedir que ejecute una funcion guardada en la bd
                //2. Tipo enlace directo con la tabla: no se usa

                //3. Tipo texto : le inyectamos una sentencia sql -- usamos esa. Es recomendable hacerla PRIMERO en el sql
                comando.CommandType = System.Data.CommandType.Text;

                //MODIFICO ESTA CONSULTA SACANDOLE EL AND ACTIVO ASI NO FILTRA Y PUEDO REACTIVAR
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad ";
                if (id != "")
                {
                    comando.CommandText += " and P.Id = " + id; //le concateno el AND con el ID que recibe, asi la consulta ya me trae un solo poke
                }


                //("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");

                comando.Connection = conexion;  //le digo al comando que esa sentencia la ejecute en la conexion que defini

                conexion.Open();
                lector = comando.ExecuteReader(); //ejecuto la lectura (da como resultado un sqldatareader)
                //los datos ahora los tengo en mi variable "lector"

                //Ahora tengo que transformar esos datos en una Lista, que defini arriba
                while (lector.Read())
                {
                    //Si da true, apunta al PRIMER registro
                    Pokemon aux = new Pokemon(); //me creo un auxiliar
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);  //Tengo que conocer qué tipo de dato es (int)
                    aux.Nombre = (string)lector["Nombre"];   //Le pongo el nombre de la columna. Es mas practico
                    aux.Descripcion = (string)lector["Descripcion"];

                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    //CARGAR TIPO Y DEBILIDAD
                    aux.Tipo = new Elemento(); //para que no de referencia nula, porque viene sin instancia la 1 vez
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    //REACTIVAR:
                    aux.Activo = bool.Parse(lector["Activo"].ToString());


                    lista.Add(aux);        //En cada vuelta va a ir creando una nueva instancia y guardando en la lista
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pokemon> listarConSP()
        {
            //Creamos esa lista
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //string consulta ... datos.setear consulta...
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    //Si da true, apunta al PRIMER registro
                    Pokemon aux = new Pokemon(); //me creo un auxiliar
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);  //Tengo que conocer qué tipo de dato es (int)
                    aux.Nombre = (string)datos.Lector["Nombre"];   //Le pongo el nombre de la columna. Es mas practico
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    //CARGAR TIPO Y DEBILIDAD
                    aux.Tipo = new Elemento(); //para que no de referencia nula, porque viene sin instancia la 1 vez
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    //AGREGO ACTIVO PARA HACER LA INACTIVACION/REACTIVACION
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(aux);        //En cada vuelta va a ir creando una nueva instancia y guardando en la lista
                }
                return lista;              //hacemos que la devuelva. Cuando no haya más, deja de leer y la devuelve
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO PARA INSERTAR
        public void agregar(Pokemon nuevo)
        {
            //CAMBIO ESTO PARA HACERLO CON PROCEDIMIENTO ALMACENADO 


            //Creo un objeto de la clase de conexion a la BD
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Le seteo la consulta que quiero ejecutar
                //LE AGREGO LA URL IMAGEN NUEVA A LA CONSULTA
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, idTipo, idDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "',1, @idTipo, @idDebilidad, @urlImagen)");

                //el @ es como crear una variable (parametros), se los tengo que agregar al PARAMETRO. Cuando se ejecute va a reemplazar el @ de la consulta por los numeros de ID que recibe4
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);   //la imagen que se da de Alta

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

        //METODO AGREGAR POKEMON USANDO STORED PROCEDURE
        public void agregarConSP(Pokemon nuevo)
        {
            //Creo un objeto de la clase de conexion a la BD
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedAltaPokemon");

                //vamos a setear los parámetros TAL CUAL los pusimos en la BBDD
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.UrlImagen);
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                //datos.setearParametro("@idEvolucion", null);


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


        //METODO MODIFICAR
        public void modificar(Pokemon pokeMod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //como ya nace seteado, lo que yo tengo que hacer es setear la consulta con los parámetros
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");
                datos.setearParametro("@numero", pokeMod.Numero);
                datos.setearParametro("@nombre", pokeMod.Nombre);
                datos.setearParametro("@descripcion", pokeMod.Descripcion);
                datos.setearParametro("@img", pokeMod.UrlImagen);
                datos.setearParametro("@idTipo", pokeMod.Tipo.Id);
                datos.setearParametro("@idDebilidad", pokeMod.Debilidad.Id);
                datos.setearParametro("@id", pokeMod.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        //MODIFICAR USANDO STORED PROCEDURE
        public void modificarConSP(Pokemon pokeMod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //como ya nace seteado, lo que yo tengo que hacer es setear la consulta con los parámetros
                datos.setearProcedimiento("storedModificarPokemon");
                datos.setearParametro("@numero", pokeMod.Numero);
                datos.setearParametro("@nombre", pokeMod.Nombre);
                datos.setearParametro("@descripcion", pokeMod.Descripcion);
                datos.setearParametro("@img", pokeMod.UrlImagen);
                datos.setearParametro("@idTipo", pokeMod.Tipo.Id);
                datos.setearParametro("@idDebilidad", pokeMod.Debilidad.Id);
                datos.setearParametro("@id", pokeMod.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        //METODO ELIMINAR FISICA
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where Id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Metodo ELIMINACION LOGICA: Le cambio el estado de la columna Activo a 0 asi se "deshabilita" pero sigue existiendo en bd
        //Para reactivar: cambiamos el metodo para que haga las 2 cosas
        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                //cambio el 0 por @activo
                datos.setearConsulta("update POKEMONS set Activo = @activo Where Id = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);  //le seteo el nuevo parametro

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //METODO FILTRAR AVANZADO - CONTRA LA BD
        //NUEVO, LE AGREGO PARA Q RECIBE STRING ESTADO DE ACTIVO
        public List<Pokemon> filtrarContraBD(string campo, string criterio, string filtro, string estado)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //NUEVO: A LA CONSULTAR LE AGREGO Q TRAIGA EL ACTIVO Y QUE EN EL AND YA NO SEA OBLIGATORIO
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And ";
                //despues del ultimo caracter, le agrego el And y un espacio para concatenarle posibles filtros como like o el numerico

                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:  //contiene
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else  //NUEVO AHORA ES TIPO :  en vez de P.Descripcion ahora es E.Descripcion
                {
                    switch (criterio)
                    {
                        case "Comienza con":  //like 'filtro%'
                            consulta += "E.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":  // like '%filtro'
                            consulta += "E.Descripcion like '%" + filtro + "'";
                            break;
                        default:  //contiene  P.Descripcion like '%filtro%' -> va entre %%
                            consulta += "E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                if (estado == "Activo")
                {
                    consulta += " and P.Activo = 1";
                }
                else if (estado == "Inactivo")
                {
                    consulta += " and P.Activo = 0";
                }
            

                datos.setearConsulta(consulta);
            datos.ejecutarLectura();

            //me traigo todo el codigo desde el while lector read de arriba y a cada lector lo cambio por datos.Lector
            while (datos.Lector.Read()) // ACA TAMBIEN LE AGREGO EL AUX PARA ACTIVO
            {
                Pokemon aux = new Pokemon();
                aux.Id = (int)datos.Lector["Id"];
                aux.Numero = datos.Lector.GetInt32(0);
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];

                if (!(datos.Lector["UrlImagen"] is DBNull))
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                aux.Tipo = new Elemento();
                aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                aux.Debilidad = new Elemento();
                aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                aux.Activo = bool.Parse(datos.Lector["Activo"].ToString()); //NUEVO

                lista.Add(aux);
            }

            return lista;

        }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}
