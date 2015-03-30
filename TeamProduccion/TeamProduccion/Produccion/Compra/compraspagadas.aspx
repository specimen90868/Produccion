<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compraspagadas.aspx.cs" Inherits="compraspagadas" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Compras</h2>
        <a href="frmcompra.aspx?Id=0">Nueva compra</a>
        <a href="compras.aspx?Id=0">Compras pendientes</a>
    </div>
        <div>
            <label>Insumo</label>
            <asp:TextBox ID="txtInsumo" runat="server" placeholder="Insumo"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
        </div>
        <div>
            <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="false">
                <Columns>
                    
                    <asp:BoundField DataField="idinsumo" HeaderText="IdInsumo" />
                    <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:BoundField DataField="total" HeaderText="Total" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>