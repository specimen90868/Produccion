using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class delproveedor : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int Id;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = int.Parse(Request.QueryString["Id"].ToString());
    }

    protected void btnSi_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsProveedor objDato = new ClsProveedor();
        objDato.IdProveedor = Id;
        valido = objWCF.deleteProveedor(JsonConvert.SerializeObject(objDato));
        if (valido)
        {
            Session["sesTitulo"] = "Proveedor";
            Session["sesMensaje"] = "El proveedor fue eliminado correctamente.";
            Session["sesPagina"] = "/Proveedor/proveedores.aspx";
            Server.Transfer("/mensaje.aspx");
        }
        else
        {
            Session["sesTitulo"] = "Proveedor";
            Session["sesMensaje"] = "El proveedor no pudo ser eliminado.";
            Session["sesPagina"] = "/Proveedor/delproveedor.aspx?Id=" + Id;
            Server.Transfer("/mensaje.aspx");
        }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Server.Transfer("/Proveedor/proveedores.aspx");      
    }
}