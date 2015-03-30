<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizaC.aspx.cs" Inherits="Cliente_ActualizaC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Contacto"></asp:Label>
        <asp:TextBox ID="txtContacto" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
    </div>
        <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
</asp:Content>
