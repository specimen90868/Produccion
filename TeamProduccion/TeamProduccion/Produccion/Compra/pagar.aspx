<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pagar.aspx.cs" Inherits="pagar" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Pagos</h2>
    </div>
        <div>
            <label>¿Confirmar el pago de la compra?</label>
        </div>
        <div>
            <asp:Button ID="btnSi" runat="server" CssClass="btn btn-default" Text="Si" OnClick="btnSi_Click" />
            <asp:Button ID="btnNo" runat="server" CssClass="btn btn-default" Text="No" OnClick="btnNo_Click" />
        </div>
</asp:Content>