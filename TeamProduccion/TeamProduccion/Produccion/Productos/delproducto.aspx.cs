using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Productos_delproducto : System.Web.UI.Page
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
        bool validoPI = false;
        ClsProductos objDato = new ClsProductos();
        ClsProductoInsumo objProdInsumo = new ClsProductoInsumo();
        objDato.idProducto = Id;
        objProdInsumo.idproducto = Id;
        valido = objWCF.DeleteProducto(JsonConvert.SerializeObject(objDato));
        validoPI = objWCF.DeleteProductoInsumos(JsonConvert.SerializeObject(objProdInsumo));
        if (valido && validoPI)
        {
            Session["sesTitulo"] = "Producto";
            Session["sesMensaje"] = "El producto fue eliminado correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Productos/productos.aspx";
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
        else
        {
            Session["sesTitulo"] = "Producto";
            Session["sesMensaje"] = "El producto no pudo ser eliminado.";
            Session["sesPagina"] = "/lsw/serviciolsw/Productos/productos.aspx?Id=" + Id;
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        Server.Transfer("/lsw/serviciolsw/Productos/productos.aspx");
    }
}