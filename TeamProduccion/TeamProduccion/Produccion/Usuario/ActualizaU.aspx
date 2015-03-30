<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizaU.aspx.cs" Inherits="Usuario_ActualizaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />

    </div>
        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</asp:Content>
