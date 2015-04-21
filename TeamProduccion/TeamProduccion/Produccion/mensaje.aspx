<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="mensaje.aspx.cs" Inherits="mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Información</h2>
    <div>
        <h2><asp:Literal ID="Titulo" runat="server"></asp:Literal></h2>
    </div>
        <div>
            <asp:Literal ID="Mensaje" runat="server"></asp:Literal>
        </div>
        <div>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
</asp:Content>
