using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;



namespace negocios
{
    public class UsuarioNegocio
    {
		public bool Loguear(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				//voy a la bd, si me trae un user me lo guardo
				datos.setearConsulta("Select id, usuario, pass, TipoUser from USUARIOS where usuario = @user AND pass = @pass");
				datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);

				datos.ejecutarLectura();
				while (datos.Lector.Read())  //el while deberia leer 1 sola vez o nunca
					//completo el objeto con los datos que recuperé de la bd
				{
					usuario.Id = (int)datos.Lector["id"];
					//usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
					return true; //return true porque logueó
				}
            }
			catch (Exception ex)
			{

				throw ex;
				
			}
			finally
			{
				datos.cerrarConexion();
			}
			return false;	
        }

    }
}
