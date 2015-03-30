<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcompra.aspx.cs" Inherits="frmcompra" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Datos de compra</h2>
    </div>
        <div>
            <label>Insumo:</label>
            <asp:TextBox ID="txtInsumo" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Proveedor:</label>
            <asp:DropDownList ID="ddlProveedor" runat="server"></asp:DropDownList>
        </div>
        <div>
            <label>Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
        </div>
</asp:Content>