using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ventas : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    List<ClsVenta> lstVenta = null;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string ventas = objWCF.getAllVentas();
        var res = JsonConvert.DeserializeObject<List<ClsVenta>>(ventas);
        var _res = (from v in res
                    select new
                    {
                        v.Idventa,
                        v.Cliente,
                        v.Producto,
                        v.Nopedido,
                        v.Cantidad,
                        v.Nolote,
                        v.Precio,
                        v.Total,
                        v.Fecha
                    }).ToList();
        lstVenta = JsonConvert.DeserializeObject<List<ClsVenta>>(ventas);
        gvVentas.DataSource = _res;
        gvVentas.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        var res = from v in lstVenta
                  where v.Cliente.Contains(txtCliente.Text)
                  select new
                  {
                      v.Idventa,
                      v.Cliente,
                      v.Producto,
                      v.Nopedido,
                      v.Cantidad,
                      v.Nolote,
                      v.Precio,
                      v.Total,
                      v.Fecha
                  };
        gvVentas.DataSource = res.ToList();
        gvVentas.DataBind();
    }
}