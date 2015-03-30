using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cliente_ConsultaC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Cliente objCliente = new Cliente();
        DataTable objTabla = new DataTable();
        objCliente.idclientes = int.Parse(txtIdCliente.Text);
        objTabla = objServicio.GetCliente(JsonConvert.SerializeObject(objCliente));

       if (objTabla != null)
       {
           gridLista.DataSource = objTabla;
           gridLista.DataBind();
       }
           

    }
}