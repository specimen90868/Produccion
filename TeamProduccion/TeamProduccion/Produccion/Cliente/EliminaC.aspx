<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaC.aspx.cs" Inherits="Cliente_EliminaC" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Borrado de cliente</h2>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="Label1" class="col-sm-2 control-label" runat="server" Text="Id de Cliente"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtId" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-default" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
</asp:Content>
