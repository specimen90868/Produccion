<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NuevoC.aspx.cs" Inherits="Cliente_NuevoC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Cliente Nuevo</h2>
    <div class="form-horizontal">
       <div class="form-group">
            <asp:Label ID="Label" class="col-sm-2 control-label" runat="server" Text="Nombre"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" class="col-sm-2 control-label" Text="Direccion"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" class="col-sm-2 control-label" Text="Contacto"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtContacto" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnNuevo" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btn_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
</asp:Content>