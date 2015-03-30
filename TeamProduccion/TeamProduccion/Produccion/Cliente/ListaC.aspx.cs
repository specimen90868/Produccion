using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Cliente_ListaC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ActualizaGrid();
    }

    public void ActualizaGrid()
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        List<Cliente> objLista = new List<Cliente>();
        string datos = objServicio.GetClientes();
        objLista = JsonConvert.DeserializeObject<List<Cliente>>(datos);
        gridLista.DataSource = objLista;
        gridLista.DataBind();
    }
}