<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delproveedor.aspx.cs" Inherits="delproveedor" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Proveedor</h2>
    </div>
        <div>
            <label>¿Confirmar eliminación del proveedor?</label>
        </div>
        <div>
            <asp:Button ID="btnSi" CssClass="btn btn-default" runat="server" Text="Si" OnClick="btnSi_Click" />
            <asp:Button ID="btnNo" CssClass="btn btn-default" runat="server" Text="No" OnClick="btnNo_Click" />
        </div>
</asp:Content>