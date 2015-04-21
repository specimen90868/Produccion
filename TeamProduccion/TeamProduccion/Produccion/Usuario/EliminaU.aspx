<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaU.aspx.cs" Inherits="Usuario_EliminaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Borrado de usuario</h2>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="Label1" class="col-sm-2 control-label" runat="server" Text="Usuario:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-default" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</asp:Content>
