using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocios
{
    public class EmailService
    {
        //atributos privados de la clase:
        private MailMessage email;  //el mensaje en si: el cuerpo, asunto, a quien..
        private SmtpClient server; //servidor mediante el cual envio, hay que configrarle el correo de salida.
        //vamos a usar el servidor de GMAIL

        public EmailService() //constructor
        {
            server = new SmtpClient(); //declaro la instancia del servidor y lo configuro abajo:
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3"); 
            //los parametros son usuario y contraseña
            server.EnableSsl = true; //seguridad
            server.Port = 587;
            server.Host = "smtp.gmail.com"; 
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage(); //para la variable privada creo la instancia
            email.From = new MailAddress("noresponderme@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>Hola! email de prueba !! </h1>"; 
            //esto en algun momento es para que pueda usar plantillas html y cambiar por variables
            //email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
