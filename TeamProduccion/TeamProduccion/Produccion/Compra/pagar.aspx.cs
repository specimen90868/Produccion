using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pagar : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int Id,IdInsumo;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = int.Parse(Request.QueryString["Id"].ToString());
        IdInsumo = int.Parse(Request.QueryString["Insumo"].ToString());
    }

    protected void btnSi_Click(object sender, EventArgs e)
    {
        bool valido = false;
        ClsCompra objDato = new ClsCompra();
        objDato.Pagado = true;
        objDato.IdCompra = Id;
        valido = objWCF.updatePago(JsonConvert.SerializeObject(objDato));
        if (valido)
        {
            ///OBTENEMOS LA CANTIDAD COMPRADA
            ClsCompra compra = new ClsCompra();
            compra.IdCompra = Id;
            DataTable ddtCompra = new DataTable();
            ddtCompra = objWCF.getCompra(JsonConvert.SerializeObject(compra));
            int cantidad = int.Parse(ddtCompra.Rows[0]["cantidad"].ToString());
            ///OBTENEMOS LA EXISTENCIA ACTUAL DEL INSUMO
            ClsInsumo insumo = new ClsInsumo();
            insumo.idinsumo = IdInsumo;
            DataTable ddtDato = new DataTable();
            ddtDato = objWCF.GetInsumo(JsonConvert.SerializeObject(insumo));
            int updateExistencia = int.Parse(ddtDato.Rows[0]["existencia"].ToString()) + cantidad;
            ///SE ACTUALIZA EL INVENTARIO DE INSUMOS
            insumo = new ClsInsumo();
            insumo.idinsumo = int.Parse(ddtDato.Rows[0]["idinsumo"].ToString());
            insumo.Existencia = updateExistencia;
            bool validoExistencia = objWCF.updateExistencia(JsonConvert.SerializeObject(insumo));
            if (validoExistencia)
            {
                Session["sesTitulo"] = "Pago";
                Session["sesMensaje"] = "El pago de la orden se realizó correctamente.";
                Session["sesPagina"] = "/lsw/serviciolsw/Compra/compras.aspx";
                Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
            }
        }
        else
        {
            Session["sesTitulo"] = "Pago";
            Session["sesMensaje"] = "El pago de la orden no se realizó correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Compra/pagar.aspx?Id=" + Id;
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Server.Transfer("/lsw/serviciolsw/Compra/compras.aspx"); 
    }
}