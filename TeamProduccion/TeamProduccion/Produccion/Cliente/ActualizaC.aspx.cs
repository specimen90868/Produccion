using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_ActualizaC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Cliente objCliente = new Cliente();

        objCliente.idcliente = int.Parse(txtId.Text);
        objCliente.cliente = txtNombre.Text;
        objCliente.direccion = txtDireccion.Text;
        objCliente.contacto = txtContacto.Text;

        bool valor = false;
        valor = objServicio.ActualizaCliente(JsonConvert.SerializeObject(objCliente));

        if (valor)
        {
            Session["sesTitulo"] = "Cliente";
            Session["sesMensaje"] = "El cliente fue actualizado correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Cliente/principalclient.aspx";
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
        else
            lblCliente.Text = "Problemas al Actualizar";
    }
}