using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Productos_frmpi : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    private int Id;
    wcfProduccion.ServiceClient objWCF = new wcfProduccion.ServiceClient();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = int.Parse(Request.QueryString["Id"].ToString());
        Nombre.Text = Request.QueryString["Producto"].ToString();

        if (!Page.IsPostBack)
        {
            ClsProductoInsumo objProdInsumo = new ClsProductoInsumo();
            objProdInsumo.idproducto = Id;
            string datos = objWCF.ProductoInsumos(JsonConvert.SerializeObject(objProdInsumo));
            List<ClsProductoInsumo> Lista = new List<ClsProductoInsumo>();
            Lista = JsonConvert.DeserializeObject<List<ClsProductoInsumo>>(datos);
            gvInsumos.DataSource = Lista.ToList();
            gvInsumos.DataBind();
        }
    }

    protected void btnGuarcar_Click(object sender, EventArgs e)
    {
        bool valido = false;
        List<ClsProductoInsumo> lstProdInsumo = new List<ClsProductoInsumo>();
        int Rows = gvInsumos.Rows.Count;
        for (int i = 0; i < Rows; i++)
        {
            Label idInsumo = (Label)gvInsumos.Rows[i].Cells[0].FindControl("lblId");
            CheckBox cb = (CheckBox)gvInsumos.Rows[i].Cells[2].FindControl("chkRow");
            TextBox cantidad = (TextBox)gvInsumos.Rows[i].Cells[3].FindControl("txtCantidad");
            if (cb.Checked == true)
            {
                ClsProductoInsumo objDatos = new ClsProductoInsumo();
                objDatos.idproducto = Id;
                objDatos.idinsumo = int.Parse(idInsumo.Text);
                objDatos.cantidad = int.Parse(cantidad.Text);
                lstProdInsumo.Add(objDatos);
            }
        }
        valido = objWCF.InsertProductoInsumos(JsonConvert.SerializeObject(lstProdInsumo));
        if (valido)
        {
            Session["sesTitulo"] = "Insumos";
            Session["sesMensaje"] = "Los insumos fue ingresados correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Productos/productos.aspx";
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
        else
        {
            Session["sesTitulo"] = "Insumos";
            Session["sesMensaje"] = "Los insumos no pudieron ser ingresados correctamente.";
            Session["sesPagina"] = "/lsw/serviciolsw/Productos/frmpi.aspx?Id=" + Id + "&Producto=" + Nombre.Text;
            Server.Transfer("/lsw/serviciolsw/mensaje.aspx");
        }
    }
}