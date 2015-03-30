using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuario_InsertaU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Usuarios objUsuario = new Usuarios();
        objUsuario.Usuario =  txtUsuario.Text;
        objUsuario.Password = txtPassword.Text;
        objUsuario.Email = txtEmail.Text;
        bool valor = false;
        valor = objServicio.InsertaUsuario(JsonConvert.SerializeObject(objUsuario));

        if (valor)
        {
            Session["sesTitulo"] = "Usuario";
            Session["sesMensaje"] = "El usuario fue ingresado correctamente.";
            Session["sesPagina"] = "/Usuario/principaluser.aspx";
            Server.Transfer("/mensaje.aspx");
        }
        else
            lblMensaje.Text = "Problemas al Insertar Usuario";
    }
}