using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmventa : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int tipoOperacion, Id;
    private DateTime fecha;
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
                ClsVenta objDato = new ClsVenta();
                objDato.Idventa = Id;
                dttDato = objWCF.getVenta(JsonConvert.SerializeObject(objDato));
                txtCliente.Text = dttDato.Rows[0]["idcliente"].ToString();
                txtProducto.Text = dttDato.Rows[0]["idproducto"].ToString();
                txtPedido.Text = dttDato.Rows[0]["nopedido"].ToString();
                txtCantidad.Text = dttDato.Rows[0]["cantidad"].ToString();
                txtLote.Text = dttDato.Rows[0]["nolote"].ToString();
                txtPrecio.Text = dttDato.Rows[0]["precio"].ToString();
                txtTotal.Text = dttDato.Rows[0]["total"].ToString();
                fecha = DateTime.Parse(dttDato.Rows[0]["fecha"].ToString());
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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsVenta objDato = new ClsVenta();
        objDato.Idcliente = int.Parse(txtCliente.Text);
        objDato.Idproducto = int.Parse(txtProducto.Text);
        objDato.Nopedido = int.Parse(txtPedido.Text);
        objDato.Cantidad = int.Parse(txtCantidad.Text);
        objDato.Nolote = int.Parse(txtLote.Text);
        objDato.Precio = decimal.Parse(txtPrecio.Text);
        objDato.Total = decimal.Parse(txtTotal.Text);
        objDato.Fecha = DateTime.Now;
        objDato.Idusuario = int.Parse(Session["sesIdUsuarios"].ToString());

        if (tipoOperacion == 0)
        {
            valido = objWCF.insertVenta(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta se ingresó correctamente.";
                Session["sesPagina"] = "/Venta/ventas.aspx";
                Server.Transfer("/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta se no se pudo realizar correctamente.";
                Session["sesPagina"] = "/Venta/frmventa.aspx?Id=0";
                Server.Transfer("/mensaje.aspx");
            }
        }
        else
        {
            objDato.Idventa = Id;
            valido = objWCF.updateVenta(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta fue actualizada correctamente.";
                Session["sesPagina"] = "/Venta/ventas.aspx";
                Server.Transfer("/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta no pudo ser actualizada.";
                Session["sesPagina"] = "/Venta/frmventa.aspx?Id=" + Id;
                Server.Transfer("/mensaje.aspx");
            }
        }
    }
}