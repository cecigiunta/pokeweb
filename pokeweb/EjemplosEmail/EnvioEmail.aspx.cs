using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocios;

namespace pokeweb.EjemplosEmail
{
    public partial class EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();  //creo una clase email service, la obtengo de mi capa de negocio
            //genero una instancia, llamo a mi metodo armar correo, recibe el mail asunto y mensaje

            emailService.armarCorreo(txtEmail.Text, txtAsunto.Text, txtMensaje.Text);

            try
            {
                emailService.enviarEmail();  
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}