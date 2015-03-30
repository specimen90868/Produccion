using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuario_ConsultaU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConsulta_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        DataTable datos = new DataTable();
        Usuarios objUsuario = new Usuarios();
        objUsuario.Usuario = txtUsuario.Text;
        datos = objServicio.GetUsuario(JsonConvert.SerializeObject(objUsuario));

        if(datos != null)
        {
            gridLista.DataSource = datos;
            gridLista.DataBind();
        }

        else
        {
            lblUsuario.Text = ("Usuario no existe, verifica el nombre");
        }
    }
}