using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Usuario_ActualizaU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Usuarios objUsuario = new Usuarios();
        objUsuario.idusuarios = int.Parse(txtId.Text);
        objUsuario.Usuario = txtUsuario.Text;
        objUsuario.Password = txtPassword.Text;
        objUsuario.Email = txtEmail.Text;
        bool valor = false;
        valor = objServicio.ActualizaUsuario(JsonConvert.SerializeObject(objUsuario));

        if(valor)
        {
            Session["sesTitulo"] = "Usuario";
            Session["sesMensaje"] = "El usuario fue actualizado correctamente.";
            Session["sesPagina"] = "/Usuario/principaluser.aspx";
            Server.Transfer("/mensaje.aspx");
        }
        else
        {
            lblUsuario.Text = ("Problemas alActualizar");
        }
    }
}