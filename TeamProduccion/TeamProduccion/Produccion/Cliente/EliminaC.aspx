<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaC.aspx.cs" Inherits="Cliente_EliminaC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id de Cliente"></asp:Label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br />
        <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
