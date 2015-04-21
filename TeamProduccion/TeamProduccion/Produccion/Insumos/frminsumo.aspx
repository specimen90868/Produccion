<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="frminsumo.aspx.cs" Inherits="Insumos_frminsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Datos del insumo</h2>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">Nombre:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Precio:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Existencia:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtExistencia" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnGuarcar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuarcar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

