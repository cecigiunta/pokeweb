using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agregar lo necesario p conectarse a sql
using System.Data.SqlClient;

namespace negocios
{
    public class AccesoDatos
    {
        //los objetos que necesito p establecer una conexion
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //creo la propertie para poder leer el lector desde el exterior
        public SqlDataReader Lector
        {
            get { return lector; }
        }


        //Creo mi constructor y al momento de que se cree el objeto le paso la conexion
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Creamos la funcion en la cual hacemos la consulta a la BD
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        

        //METODO PARA SETEAR EL PROCEDURE - HOY !!!
        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        //metodo que realice la lectura y lo guarde en el lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
            conexion.Open();
            lector = comando.ExecuteReader();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //AGREGO METODO PARA EL INSERT - DE TIPO NON QUERY
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //METODO PARA VALIDAR LOS PARAMETROS DE ID TIPO Y ID DEBILIDAD. Le aviso al comando q los agregue
        public void setearParametro(string nombre, object valor)
        {
            //El metodo AddWithValue permite agregar un parámetro con nombre y valor: recibe un string y un object
            comando.Parameters.AddWithValue(nombre, valor);
        }


        public void cerrarConexion()
        {
            //si hay lector tambien lo cierro
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }      


    }
}
