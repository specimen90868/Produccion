using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuario_principaluser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        string datos = objServicio.GetUsuarios();
        List<Usuarios> Lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuarios>>(datos);
        gridlista.DataSource = Lista;
        gridlista.DataBind();
    }
    protected void lkbtnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertaU.aspx");
    }
    protected void lkbtnEliminar_Click(object sender, EventArgs e)
    {
        Response.Redirect("EliminaU.aspx");
    }
    protected void lkbtConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultaU.aspx");
    }
    protected void lkbtnActualizar(object sender, EventArgs e)
    {
        Response.Redirect("ActualizaU.aspx");
    }
}