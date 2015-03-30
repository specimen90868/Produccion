using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class proveedores : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    List<ClsProveedor> lstProveedor = null;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string proveedores = objWCF.getAllProveedores();
        var res = JsonConvert.DeserializeObject<List<ClsProveedor>>(proveedores);
        lstProveedor = JsonConvert.DeserializeObject<List<ClsProveedor>>(proveedores);
        gvProveedores.DataSource = res.ToList();
        gvProveedores.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        var res = from p in lstProveedor
                  where p.Proveedor.Contains(txtProveedor.Text)
                  select new { p.IdProveedor, p.Proveedor, p.Direccion, p.Contacto };
        gvProveedores.DataSource = res.ToList();
        gvProveedores.DataBind();
    }
}