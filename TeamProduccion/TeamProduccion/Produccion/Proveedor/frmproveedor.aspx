<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmproveedor.aspx.cs" Inherits="frmproveedor" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Datos de proveedor</h2>
    </div>
        <div>
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Contacto:</label>
            <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGuarcar" runat="server" Text="Guardar" OnClick="btnGuarcar_Click"/>
        </div>
</asp:Content>
