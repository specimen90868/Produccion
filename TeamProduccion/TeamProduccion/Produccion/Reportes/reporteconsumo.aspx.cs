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
    public string ChartDataEnero = null;
    public string ChartDataFebrero = null;
    public string ChartDataMarzo = null;
    public string ChartDataAbril = null;
    public string ChartDataMayo = null;
    public string ChartDataJunio = null;
    public string ChartDataJulio = null;
    public string ChartDataAgosto = null;
    public string ChartDataSept = null;
    public string ChartDataOct = null;
    public string ChartDataNov = null;
    public string ChartDataDic = null;
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
        ChartDataEnero = lista[1];
        ChartDataFebrero = lista[2];
        ChartDataMarzo = lista[3];
        ChartDataAbril = lista[4];
        ChartDataMayo = lista[5];
        ChartDataJunio = lista[6];
        ChartDataJulio = lista[7];
        ChartDataAgosto = lista[8];
        ChartDataSept = lista[9];
        ChartDataOct = lista[10];
        ChartDataNov = lista[11];
        ChartDataDic = lista[12];
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "DrawChart();", true);
    }
}
