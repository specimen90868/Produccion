using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Productos_productos : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    List<ClsProductos> lstProductos = null;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string productos = objWCF.GetProductos();
        var res = JsonConvert.DeserializeObject<List<ClsProductos>>(productos);
        lstProductos = JsonConvert.DeserializeObject<List<ClsProductos>>(productos);
        gvProductos.DataSource = res.ToList();
        gvProductos.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        var res = from p in lstProductos
                  where p.Producto.Contains(txtProducto.Text)
                  select new
                  {
                      p.idProducto,
                      p.Producto,
                      p.Precio
                  };
        gvProductos.DataSource = res.ToList();
        gvProductos.DataBind();
    }
}