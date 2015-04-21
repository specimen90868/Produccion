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
                ddlInsumo.SelectedValue = dttDato.Rows[0]["idinsumo"].ToString();
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

        string insumos = objWCF.GetInsumos();
        var i = JsonConvert.DeserializeObject<List<ClsInsumo>>(insumos);
        ddlInsumo.DataSource = i.ToList();
        ddlInsumo.DataTextField = "insumo";
        ddlInsumo.DataValueField = "idinsumo";
        ddlInsumo.DataBind();

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsCompra objDato = new ClsCompra();
        objDato.IdInsumo = int.Parse(ddlInsumo.SelectedValue);
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
                Session["sesPagina"] = "/lsw/serviciolsw/Compra/compras.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra se no se pudo realizar correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Compra/frmcompra.aspx?Id=0";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
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
                Session["sesPagina"] = "/lsw/serviciolsw/Compra/compras.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Compra";
                Session["sesMensaje"] = "La compra no pudo ser actualizada.";
                Session["sesPagina"] = "/lsw/serviciolsw/Compra/frmcompra.aspx?Id=" + Id;
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
    }

    protected void txtCantidad_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = (decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text)).ToString();
    }

    protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClsInsumo objInsumo = new ClsInsumo();
        objInsumo.idinsumo = int.Parse(ddlInsumo.SelectedValue);
        DataTable ddtDato = new DataTable();
        ddtDato = objWCF.GetInsumo(JsonConvert.SerializeObject(objInsumo));
        foreach (DataRow fila in ddtDato.Rows)
        {
            txtPrecio.Text = fila["precio"].ToString();
        }
    }
}