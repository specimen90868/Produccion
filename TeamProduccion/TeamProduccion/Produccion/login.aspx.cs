using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Usuarios objUsuarios = new Usuarios();
        string datos;
        objUsuarios.Usuario = txtUsuario.Text;
        objUsuarios.Password = txtPassword.Text;
        datos = JsonConvert.SerializeObject(objUsuarios);
        DataTable variable = new DataTable();
        variable  = objServicio.ValidaUsuario(datos);

        if (variable != null)
        {
            if(variable.Rows.Count > 0)
            {
                Session["sesUsuario"] = variable.Rows[0]["usuario"].ToString();
                Session["sesIdUsuarios"] = variable.Rows[0]["idusuarios"].ToString();
                Response.Redirect("index.aspx");
            }
            else
                lblMensaje.Text = "usuario o contraseña incorrecto";  

        }
           else
        {
            Response.Redirect("login.aspx");
        }

    }
}