<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertaU.aspx.cs" Inherits="Usuario_InsertaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nuevo Usuario</h2>
    <div class="form-horizontal">
       <div class="form-group">
            <asp:Label ID="lblUsuario" class="col-sm-2 control-label" runat="server" Text="Usuario:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" class="col-sm-2 control-label" Text="Password"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" class="col-sm-2 control-label" Text="Email"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnAceptar" CssClass="btn btn-default" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
