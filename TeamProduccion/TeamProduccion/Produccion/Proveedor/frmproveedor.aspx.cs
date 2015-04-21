using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;

public partial class frmproveedor : System.Web.UI.Page
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
                ClsProveedor objDato = new ClsProveedor();
                objDato.IdProveedor = Id;
                dttDato = objWCF.getProveedor(JsonConvert.SerializeObject(objDato));
                txtNombre.Text = dttDato.Rows[0]["proveedor"].ToString();
                txtDireccion.Text = dttDato.Rows[0]["direccion"].ToString();
                txtContacto.Text = dttDato.Rows[0]["contacto"].ToString();
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
        bool valido = false;
        ClsProveedor objDato = new ClsProveedor();
        objDato.Proveedor = txtNombre.Text;
        objDato.Direccion = txtDireccion.Text;
        objDato.Contacto = txtContacto.Text;
        if (tipoOperacion == 0)
        {
            valido = objWCF.insertProveedor(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Proveedor";
                Session["sesMensaje"] = "El proveedor fue ingresado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Proveedor/proveedores.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Proveedor";
                Session["sesMensaje"] = "El proveedor no pudo ser ingresado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Proveedor/frmproveedor.aspx?Id=0";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
        else
        {
            objDato.IdProveedor = Id;
            valido = objWCF.updateProveedor(JsonConvert.SerializeObject(objDato));
            if (valido)
            {
                Session["sesTitulo"] = "Proveedor";
                Session["sesMensaje"] = "El proveedor fue actualizado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Proveedor/proveedores.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
            else
            {
                Session["sesTitulo"] = "Proveedor";
                Session["sesMensaje"] = "El proveedor no pudo ser actualizado correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Proveedor/frmproveedor.aspx?Id=" + Id;
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
    }
}