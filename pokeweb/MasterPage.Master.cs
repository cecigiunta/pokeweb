﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocios;
using dominio;

namespace pokeweb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //En el load de la MASTER PAGE vamos a hacer la validacion de seguridad para ver si el user esta logueado
            //tengo que exceptuar las páginas que NO quiero que me valide

            //va a tener el obj al que se esta dirigiendo la MasterPage 
            //le pregunto CUAL es la page que está dibujando

            //     if ( (!(Page is Login)) || (!(Page is Default)) || (!(Page is Registro)))

            if (!(Page is Login || Page is Default || Page is Registro ))
            {
                if (!(Seguridad.sessionActiva(Session["entrenador"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

            // NUEVO : IMG PERFIL
            if (!(Seguridad.sessionActiva(Session["entrenador"]))) // le preguntamos si hay una sesion activa
            {
                //Si hay, que cargue en el load en todas las paginas la imagen del user, 
                imgAvatar.ImageUrl = "~/Images/" + ((Entrenador)Session["entrenador"]).ImagenPerfil;
            }
            else
            {
                // si NO hay, que quede la img vacia por defecto
                imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Default_pfp.svg";
            }


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}