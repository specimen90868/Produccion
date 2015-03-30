using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class compraspagadas : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    List<ClsCompra> lstCompra = null;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string compras = objWCF.getAllCompras("1");
        var res = JsonConvert.DeserializeObject<List<ClsCompra>>(compras);
        var _res = (from c in res
                    select new
                    {
                        c.IdCompra,
                        c.IdInsumo,
                        c.Proveedor,
                        c.Cantidad,
                        c.Precio,
                        c.Total,
                        c.Fecha,
                    }).ToList();
        lstCompra = JsonConvert.DeserializeObject<List<ClsCompra>>(compras);
        gvCompras.DataSource = _res;
        gvCompras.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        var res = from c in lstCompra
                  where c.IdInsumo.Equals(int.Parse(txtInsumo.Text))
                  select new
                  {
                      c.IdCompra,
                      c.IdInsumo,
                      c.Proveedor,
                      c.Cantidad,
                      c.Precio,
                      c.Total,
                      c.Fecha,
                  };
        gvCompras.DataSource = res.ToList();
        gvCompras.DataBind();
    }
}