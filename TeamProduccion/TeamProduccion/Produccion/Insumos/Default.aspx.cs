﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Insumos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        init();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        wcfProduccion.ServiceClient objServicio = new wcfProduccion.ServiceClient();
        Insumo objInsumo = new Insumo();
        objInsumo.Nombre = TextBox1.Text;
        objInsumo.Precio = decimal.Parse(TextBox2.Text);
        objInsumo.Existencia = int.Parse(TextBox3.Text);

        bool valor = objServicio.InsertarInsumo(Newtonsoft.Json.JsonConvert.SerializeObject(objInsumo));

        if (valor)
        {
            init();
        }
    }

    void init()
    {
        wcfProduccion.ServiceClient cliente = new wcfProduccion.ServiceClient();
        string datos = cliente.GetInsumos();
        List<Insumo> Lista = new List<Insumo>();
        Lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Insumo>>(datos);
        GridView1.DataSource = Lista;
        GridView1.DataBind();
    }
}