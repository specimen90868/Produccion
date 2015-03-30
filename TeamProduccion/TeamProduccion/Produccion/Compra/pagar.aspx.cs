using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pagar : System.Web.UI.Page
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
        ClsCompra objDato = new ClsCompra();
        objDato.Pagado = true;
        objDato.IdCompra = Id;
        valido = objWCF.updatePago(JsonConvert.SerializeObject(objDato));
        if (valido)
        {
            Session["sesTitulo"] = "Pago";
            Session["sesMensaje"] = "El pago de la orden se realizó correctamente.";
            Session["sesPagina"] = "/Compra/compras.aspx";
            Server.Transfer("/mensaje.aspx");
        }
        else
        {
            Session["sesTitulo"] = "Pago";
            Session["sesMensaje"] = "El pago de la orden no se realizó correctamente.";
            Session["sesPagina"] = "/Compra/pagar.aspx?Id=" + Id;
            Server.Transfer("/mensaje.aspx");
        }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Server.Transfer("/Compra/compras.aspx"); 
    }
}