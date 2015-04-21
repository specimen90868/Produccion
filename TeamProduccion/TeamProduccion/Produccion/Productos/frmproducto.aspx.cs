using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;

public partial class Productos_frmproducto : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int tipoOperacion, Id;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = int.Parse(Request.QueryString["Id"].ToString());
        if (!Page.IsPostBack)
        {
            if (Id != 0)
            {
                DataTable dttDato = new DataTable();
                ClsProductos objDato = new ClsProductos();
                objDato.idProducto = Id;
                dttDato = objWCF.GetProducto(JsonConvert.SerializeObject(objDato));
                txtNombre.Text = dttDato.Rows[0]["producto"].ToString();
                txtPrecio.Text = dttDato.Rows[0]["precio"].ToString();
            }
        }
        else
        {
            if (Id != 0)
                tipoOperacion = 1;
            else
                tipoOperacion = 0;
        }
    }

    protected void btnGuarcar_Click(object sender, EventArgs e)
    {
        bool valido;
        ClsProductos objDato = new ClsProductos();
        objDato.Producto = txtNombre.Text;
        objDato.Precio = decimal.Parse(txtPrecio.Text);
        if (tipoOperacion == 0)
        {
            valido = objWCF.InsertProducto(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Producto";
                Session["sesMensaje"] = "El producto fue ingresado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Productos/productos.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Producto";
                Session["sesMensaje"] = "El producto no pudo ser ingresado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Productos/frmproducto.aspx?Id=0";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
        else
        {
            valido = objWCF.UpdateProducto(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Producto";
                Session["sesMensaje"] = "El producto fue actualizado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Productos/productos.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Producto";
                Session["sesMensaje"] = "El producto no pudo ser actualizado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Productos/frmproducto.aspx?Id=0";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
        
    }
}