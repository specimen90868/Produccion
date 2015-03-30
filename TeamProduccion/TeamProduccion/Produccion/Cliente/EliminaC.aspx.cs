using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_EliminaC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Cliente objCliente = new Cliente();
        objCliente.idclientes = int.Parse(txtId.Text);
        bool valor;

        valor = objServicio.EliminaCliente(JsonConvert.SerializeObject(objCliente));

        if (valor)
        {
            Session["sesTitulo"] = "Cliente";
            Session["sesMensaje"] = "El cliente fue eliminado correctamente.";
            Session["sesPagina"] = "/Cliente/principalclient.aspx";
            Server.Transfer("/mensaje.aspx");
        }
        else
            lblCliente.Text = "Problemas al Eliminar";
      }
}