using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lkbtnUsuario_Click(object sender, EventArgs e)
    {
        Server.Transfer("Usuario/principaluser.aspx");
    }
    protected void lkbtnCliente_Click(object sender, EventArgs e)
    {
        Server.Transfer("Cliente/principalclient.aspx");
    }
}