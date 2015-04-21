<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="frmproducto.aspx.cs" Inherits="Productos_frmproducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Datos del producto</h2>
    </div>

    <div class="col-sm-6 col-lg-6">
        <div class="form-group">
            <label>Nombre:</label><br />
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Precio:</label><br />
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        </div><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuarcar_Click"/>
    </div>
</asp:Content>

