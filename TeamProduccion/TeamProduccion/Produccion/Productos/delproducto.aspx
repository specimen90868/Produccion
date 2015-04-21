<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="delproducto.aspx.cs" Inherits="Productos_delproducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Producto</h2>
    </div>
        <div>
            <label>¿Confirmar eliminación del producto?</label>
        </div>
        <div>
            <asp:Button ID="btnSi" runat="server" CssClass="btn btn-default" Text="Si" OnClick="btnSi_Click" />
            <asp:Button ID="btnNo" runat="server" CssClass="btn btn-default" Text="No" OnClick="btnNo_Click" />
        </div>
</asp:Content>

