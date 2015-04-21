<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmproveedor.aspx.cs" Inherits="frmproveedor" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Datos de proveedor</h2>
    </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Dirección:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Contacto:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtContacto" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnGuarcar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuarcar_Click"/>
                </div>
            </div>
        </div>
</asp:Content>
