<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principaluser.aspx.cs" Inherits="Usuario_principaluser" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:LinkButton ID="lkbtnNuevo" runat="server" OnClick="lkbtnNuevo_Click">Nuevo</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbtConsulta" runat="server" OnClick="lkbtConsulta_Click">Consulta</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lkbtnEliminar" runat="server" OnClick="lkbtnEliminar_Click">Eliminar</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbtnActualizar" runat="server" OnClick="lkbtnActualizar">Actualizar</asp:LinkButton>
        <br />
    </div>
        <asp:GridView ID="gridlista" runat="server">
        </asp:GridView>
</asp:Content>
