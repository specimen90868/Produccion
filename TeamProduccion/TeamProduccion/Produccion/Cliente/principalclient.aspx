<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principalclient.aspx.cs" Inherits="Cliente_principalclient" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Clientes
    </h2>
    <div>
        <ul class="nav nav-tabs">
          <li role="presentation" class="active">
              <asp:LinkButton ID="lkbtnNuevo" runat="server" OnClick="lkbtnNuevo_Click">Nuevo</asp:LinkButton>
          </li>
          <li role="presentation">
              <asp:LinkButton ID="lkbActualizar" runat="server" OnClick="lkbActualizar_Click">Actualizar</asp:LinkButton>
          </li>
          <li role="presentation">
              <asp:LinkButton ID="lkbEliminar" runat="server" OnClick="lkbEliminar_Click">Eliminar</asp:LinkButton>
          </li>
        </ul>
    </div>
    <div>
    <asp:GridView ID="gridlista" class="table table-striped" runat="server">
    </asp:GridView>
</asp:Content>
