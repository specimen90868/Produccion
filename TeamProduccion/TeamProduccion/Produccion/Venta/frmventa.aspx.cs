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
                listas();
                DataTable dttDato = new DataTable();
                ClsVenta objDato = new ClsVenta();
                objDato.Idventa = Id;
                dttDato = objWCF.getVenta(JsonConvert.SerializeObject(objDato));
                ddlCliente.SelectedValue = dttDato.Rows[0]["idcliente"].ToString();
                ddlProducto.SelectedValue = dttDato.Rows[0]["idproducto"].ToString();
                txtPedido.Text = dttDato.Rows[0]["nopedido"].ToString();
                txtCantidad.Text = dttDato.Rows[0]["cantidad"].ToString();
                txtLote.Text = dttDato.Rows[0]["nolote"].ToString();
                txtPrecio.Text = dttDato.Rows[0]["precio"].ToString();
                txtTotal.Text = dttDato.Rows[0]["total"].ToString();
                fecha = DateTime.Parse(dttDato.Rows[0]["fecha"].ToString());
            }
            else
                listas();
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
        objDato.Idcliente = int.Parse(ddlCliente.SelectedValue);
        objDato.Idproducto = int.Parse(ddlProducto.SelectedValue);
        objDato.Nopedido = int.Parse(txtPedido.Text);
        objDato.Cantidad = int.Parse(txtCantidad.Text);
        objDato.Nolote = int.Parse(txtLote.Text);
        objDato.Precio = decimal.Parse(txtPrecio.Text);
        objDato.Total = decimal.Parse(txtTotal.Text);
        objDato.Fecha = DateTime.Now;
        objDato.Idusuario = int.Parse(Session["sesIdUsuarios"].ToString());

        if (tipoOperacion == 0)
        {
            ///VERIFICA SI HAY EXISTENCIAS PARA REALIZAR EL PEDIDO
            ClsProductoInsumo objProdInsumo = new ClsProductoInsumo();
            objProdInsumo.idproducto = int.Parse(ddlProducto.SelectedValue);
            string pi = objWCF.ProductoInsumos(JsonConvert.SerializeObject(objProdInsumo));
            List<ClsProductoInsumo> lstPI = JsonConvert.DeserializeObject<List<ClsProductoInsumo>>(pi);
            for (int i = 0; i < lstPI.Count; i++)
            {
                if (lstPI[i].cantidad != 0)
                {
                    ClsInsumo insumo = new ClsInsumo();
                    insumo.idinsumo = lstPI[i].idinsumo;
                    DataTable ddtDato = new DataTable();
                    ddtDato = objWCF.GetInsumo(JsonConvert.SerializeObject(insumo));
                    ///CANTIDAD INGRESADA POR LA CANTIDAD DEL INSUMO QUE TIENE EL PRODUCTO
                    int a = int.Parse(txtCantidad.Text) * lstPI[i].cantidad;
                    if (a > int.Parse(ddtDato.Rows[0]["existencia"].ToString()))
                    {
                        Session["sesTitulo"] = "Venta";
                        Session["sesMensaje"] = "La venta no se puede realizar. Revasa las existencias del insumo " + ddtDato.Rows[0]["insumo"].ToString();
                        Session["sesPagina"] = "/lsw/serviciolsw/Venta/ventas.aspx";
                        Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
                    }
                }
            }

            valido = objWCF.insertVenta(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                for (int i = 0; i < lstPI.Count; i++)
                {
                    if (lstPI[i].cantidad != 0)
                    {
                        ClsInsumo insumo = new ClsInsumo();
                        insumo.idinsumo = lstPI[i].idinsumo;
                        DataTable ddtDato = new DataTable();
                        ddtDato = objWCF.GetInsumo(JsonConvert.SerializeObject(insumo));
                        int a = int.Parse(txtCantidad.Text) * lstPI[i].cantidad;
                        int existencia = int.Parse(ddtDato.Rows[0]["existencia"].ToString()) - a;
                        ClsInsumo uInsumo = new ClsInsumo();
                        uInsumo.idinsumo = lstPI[i].idinsumo;
                        uInsumo.Existencia = existencia;
                        objWCF.updateExistencia(JsonConvert.SerializeObject(uInsumo));
                    }
                }
                
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta se registró correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Venta/ventas.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta se no se pudo realizar correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Venta/frmventa.aspx?Id=0";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
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
                Session["sesPagina"] = "/lsw/serviciolsw/Venta/ventas.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Venta";
                Session["sesMensaje"] = "La venta no pudo ser actualizada.";
                Session["sesPagina"] = "/lsw/serviciolsw/Venta/frmventa.aspx?Id=" + Id;
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
    }

    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClsProductos objProducto = new ClsProductos();
        objProducto.idProducto = int.Parse(ddlProducto.SelectedValue);
        DataTable ddtDato = new DataTable();
        ddtDato = objWCF.GetProducto(JsonConvert.SerializeObject(objProducto));
        foreach (DataRow fila in ddtDato.Rows)
        {
            txtPrecio.Text = fila["precio"].ToString();
        }
    }

    protected void txtCantidad_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = (decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text)).ToString();
    }

    private void listas()
    {
        string clientes = objWCF.GetClientes();
        var res = JsonConvert.DeserializeObject<List<Cliente>>(clientes);
        ddlCliente.DataSource = res.ToList();
        ddlCliente.DataTextField = "cliente";
        ddlCliente.DataValueField = "idcliente";
        ddlCliente.DataBind();

        string productos = objWCF.GetProductos();
        var p = JsonConvert.DeserializeObject<List<ClsProductos>>(productos);
        ddlProducto.DataSource = p.ToList();
        ddlProducto.DataTextField = "producto";
        ddlProducto.DataValueField = "idproducto";
        ddlProducto.DataBind();
    }
}