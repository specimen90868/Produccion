<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NuevoC.aspx.cs" Inherits="Cliente_NuevoC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cliente Nuevo/Actualizar</h1>
    <div>
        <asp:Label ID="Label" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contacto"></asp:Label>
        <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnNuevo" runat="server" Text="Guardar" OnClick="btn_Click" />
    </div>
        <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
</asp:Content>