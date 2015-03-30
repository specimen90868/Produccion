<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaC.aspx.cs" Inherits="Cliente_ConsultaC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id de Cliente"></asp:Label>
        <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <br />
        <asp:GridView ID="gridLista" runat="server"></asp:GridView>
    </div>
</asp:Content>
