using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Usuario_EliminaU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Usuarios objUsuario = new Usuarios();
        objUsuario.Usuario = txtUsuario.Text;
        bool valor = false;
        valor = objServicio.EliminaUsuario(JsonConvert.SerializeObject(objUsuario));
        if (valor)
        {
            Session["sesTitulo"] = "Usuario";
            Session["sesMensaje"] = "El usuario fue eliminado correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Usuario/principaluser.aspx";
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
        else
            lblUsuario.Text = ("Usuario no Existe");
    }
}