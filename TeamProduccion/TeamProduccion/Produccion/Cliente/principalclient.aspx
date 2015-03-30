<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principalclient.aspx.cs" Inherits="Cliente_principalclient" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:LinkButton ID="lkbtnNuevo" runat="server" OnClick="lkbtnNuevo_Click">Nuevo</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbConsultar" runat="server" OnClick="lkbConsultar_Click">Consultar</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbActualizar" runat="server" OnClick="lkbActualizar_Click">Actualizar</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbEliminar" runat="server" OnClick="lkbEliminar_Click">Eliminar</asp:LinkButton>
    </div>
        <asp:GridView ID="gridlista" runat="server">
        </asp:GridView>
</asp:Content>
