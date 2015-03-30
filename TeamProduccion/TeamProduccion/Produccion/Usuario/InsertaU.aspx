<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertaU.aspx.cs" Inherits="Usuario_InsertaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nuevo Usuario</h1>
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
