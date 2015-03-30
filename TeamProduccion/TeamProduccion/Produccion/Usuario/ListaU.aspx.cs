using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

public partial class Usuario_ListaU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ActualizaGrid();

    }

    public void ActualizaGrid()
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        string datos = objServicio.GetUsuarios();
        List<Usuarios> Lista = new List<Usuarios>();
         Lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuarios>>(datos);
        GridLista.DataSource = Lista;
        GridLista.DataBind();
    }
}