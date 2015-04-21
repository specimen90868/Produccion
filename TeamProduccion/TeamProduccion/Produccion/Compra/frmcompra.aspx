<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcompra.aspx.cs" Inherits="frmcompra" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Datos de compra</h2>
    </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">Insumo:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlInsumo" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged" ></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">Proveedor:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlProveedor" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            
            <div class="form-group">
                <label class="col-sm-2 control-label">Cantidad:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group">
                <label class="col-sm-2 control-label">Precio:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">Total:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
        </div>
</asp:Content>