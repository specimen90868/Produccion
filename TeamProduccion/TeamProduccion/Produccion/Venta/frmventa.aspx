<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmventa.aspx.cs" Inherits="frmventa" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Datos de venta</h2>
    </div>
        <div>
            <label>Cliente:</label>
            <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Producto:</label>
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>No. Pedido:</label>
            <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>No. Lote:</label>
            <asp:TextBox ID="txtLote" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Precio:</label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Total:</label>
            <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
</asp:Content>