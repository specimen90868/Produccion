using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Reportes_reporteconsumo : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    public string ChartLabels = null;
    public string ChartData = null;
    public string id = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        string[] lista;
        ClsReporte objReporte = new ClsReporte();
        objReporte.FechaInicio = DateTime.Parse(this.dtInicial.Value);
        objReporte.FechaFin = DateTime.Parse(this.dtFinal.Value);
        lista = objWCF.ReporteConsumoVentas(JsonConvert.SerializeObject(objReporte), int.Parse(ddlTipoReporte.SelectedValue));
        ChartLabels = lista[0];
        for (int i = 1; i <= 12; i++)
        {
            ChartData = lista[i];
            id = "\"" + i.ToString() + "\"";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "DrawChart();", true);
        }

    }
}