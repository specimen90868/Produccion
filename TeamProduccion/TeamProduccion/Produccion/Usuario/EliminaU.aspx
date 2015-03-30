<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaU.aspx.cs" Inherits="Usuario_EliminaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br />
    </div>
        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</asp:Content>
