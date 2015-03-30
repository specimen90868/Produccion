<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaU.aspx.cs" Inherits="Usuario_ConsultaU" MasterPageFile="~/Principal.master"%>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnConsulta" runat="server" Text="Consultar" OnClick="btnConsulta_Click" />
        <br />
        <br />
        <asp:GridView ID="gridLista" runat="server"></asp:GridView>
    </div>
        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</asp:Content>
