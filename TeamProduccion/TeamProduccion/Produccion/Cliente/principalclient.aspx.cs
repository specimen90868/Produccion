using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_principalclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        string datos = objServicio.GetClientes();
        List<Cliente> Lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cliente>>(datos);
        gridlista.DataSource = Lista.ToList();
        gridlista.DataBind();
    }
    protected void lkbtnNuevo_Click(object sender, EventArgs e)
    {
        Server.Transfer("NuevoC.aspx");
    }
    protected void lkbConsultar_Click(object sender, EventArgs e)
    {
        Server.Transfer("ConsultaC.aspx");
    }
    protected void lkbActualizar_Click(object sender, EventArgs e)
    {
        Server.Transfer("ActualizaC.aspx");
    }
    protected void lkbEliminar_Click(object sender, EventArgs e)
    {
        Server.Transfer("EliminaC.aspx");
    }
}