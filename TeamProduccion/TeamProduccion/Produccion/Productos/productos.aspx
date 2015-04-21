<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="productos.aspx.cs" Inherits="Productos_productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Productos</h2>
        <a href="frmproducto.aspx?Id=0">Agregar nuevo</a>
    </div>
    <div class="form-inline">
        <div class="form-group">
            <label>Producto</label>
            <asp:TextBox ID="txtProducto" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
        </div>
        <asp:Button ID="btnBuscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click"/>
    </div>
    <br />
        <div>
            <asp:GridView ID="gvProductos" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="producto" HeaderText="Producto" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:HyperLinkField HeaderText="Editar"
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Productos/frmproducto.aspx?Id={0}"
                        DataNavigateUrlFields="idproducto"
                        Text="Editar" />
                    <asp:HyperLinkField HeaderText="Insumos"
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Productos/frmpi.aspx?Id={0}&Producto={1}"
                        DataNavigateUrlFields="idproducto,producto"
                        Text="Editar" />
                    <asp:HyperLinkField HeaderText="Eliminar" 
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Productos/delproducto.aspx?Id={0}"
                        DataNavigateUrlFields="idproducto" 
                        Text="Borrar" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>

