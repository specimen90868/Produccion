using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mensaje : System.Web.UI.Page
{
    private string pagina;

    protected void Page_Load(object sender, EventArgs e)
    {
        Titulo.Text = Session["sesTitulo"].ToString();
        Mensaje.Text = Session["sesMensaje"].ToString();
        pagina = Session["sesPagina"].ToString();
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect(pagina);
    }
}