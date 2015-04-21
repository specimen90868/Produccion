<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principaluser.aspx.cs" Inherits="Usuario_principaluser" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Usuarios</h2>
    <div>
        <ul class="nav nav-tabs">
          <li role="presentation" class="active">
              <asp:LinkButton ID="lkbtnNuevo" runat="server" OnClick="lkbtnNuevo_Click">Nuevo</asp:LinkButton>
          </li>
          <li role="presentation">
              <asp:LinkButton ID="lkbtnEliminar" runat="server" OnClick="lkbtnEliminar_Click">Eliminar</asp:LinkButton>
          </li>
          <li role="presentation">
              <asp:LinkButton ID="lbtnActualizar" runat="server" OnClick="lkbtnActualizar">Actualizar</asp:LinkButton>
          </li>
        </ul>
    </div>
        <asp:GridView ID="gridlista" class="table table-striped" runat="server">
        </asp:GridView>
</asp:Content>
