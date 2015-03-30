using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmcompra : System.Web.UI.Page
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
                listaProveedores();
                DataTable dttDato = new DataTable();
                ClsCompra objDato = new ClsCompra();
                objDato.IdCompra = Id;
                dttDato = objWCF.getCompra(JsonConvert.SerializeObject(objDato));
                txtInsumo.Text = dttDato.Rows[0]["idinsumo"].ToString();
                ddlProveedor.SelectedValue = dttDato.Rows[0]["idproveedor"].ToString();
                txtCantidad.Text = dttDato.Rows[0]["cantidad"].ToString();
                txtPrecio.Text = dttDato.Rows[0]["precio"].ToString();
                txtTotal.Text = dttDato.Rows[0]["total"].ToString();
            }
            else
            {
                listaProveedores();
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

    private void listaProveedores()
    {
        string proveedores = objWCF.getAllProveedores();
        var res = JsonConvert.DeserializeObject<List<ClsProveedor>>(proveedores);
        ddlProveedor.DataSource = res.ToList();
        ddlProveedor.DataTextField = "proveedor";
        ddlProveedor.DataValueField = "idproveedor";
        ddlProveedor.DataBind();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsCompra objDato = new ClsCompra();
        objDato.IdInsumo = int.Parse(txtInsumo.Text);
        objDato.Idproveedor = int.Parse(ddlProveedor.SelectedValue.ToString());
        objDato.Cantidad = int.Parse(txtCantidad.Text);
        objDato.Precio = decimal.Parse(txtPrecio.Text);
        objDato.Total = decimal.Parse(txtTotal.Text);
        objDato.Fecha = DateTime.Now;

        if (tipoOperacion == 0)
        {
            objDato.Pagado = false;
            valido = objWCF.insertCompra(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra se ingresó correctamente.";
                Session["sesPagina"] = "/Compra/compras.aspx";
                Server.Transfer("/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra se no se pudo realizar correctamente.";
                Session["sesPagina"] = "/Compra/frmcompra.aspx?Id=0";
                Server.Transfer("/mensaje.aspx");
            }
        }
        else
        {
            objDato.IdCompra = Id;
            valido = objWCF.updateCompra(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra fue actualizada correctamente.";
                Session["sesPagina"] = "/Compra/compras.aspx";
                Server.Transfer("/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra no pudo ser actualizada.";
                Session["sesPagina"] = "/Compra/frmcompra.aspx?Id=" + Id;
                Server.Transfer("/mensaje.aspx");
            }
        }
    }
}