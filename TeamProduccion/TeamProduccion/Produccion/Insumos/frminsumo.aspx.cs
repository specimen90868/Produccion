using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;

public partial class Insumos_frminsumo : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int Id;
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
                ClsInsumo objDato = new ClsInsumo();
                objDato.idinsumo = Id;
                dttDato = objWCF.GetInsumo(JsonConvert.SerializeObject(objDato));
                txtNombre.Text = dttDato.Rows[0]["insumo"].ToString();
                txtPrecio.Text = dttDato.Rows[0]["precio"].ToString();
                txtExistencia.Text = dttDato.Rows[0]["existencia"].ToString();
            }
        }
    }
    protected void btnGuarcar_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsInsumo objDato = new ClsInsumo();
        objDato.Insumo = txtNombre.Text;
        objDato.Precio = decimal.Parse(txtPrecio.Text);
        objDato.Existencia = int.Parse(txtExistencia.Text);
        objDato.idinsumo = Id;
        valido = objWCF.ActualizaInsumo(JsonConvert.SerializeObject(objDato));
        if (valido)
        {
            Session["sesTitulo"] = "Insumo";
            Session["sesMensaje"] = "El insumo fue actualizado correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Insumos/Default.aspx";
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
        else
        {
            Session["sesTitulo"] = "Insumo";
            Session["sesMensaje"] = "El insumo no pudo ser actualizado correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Insumos/frminsumo.aspx?Id=" + Id;
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
    }
}