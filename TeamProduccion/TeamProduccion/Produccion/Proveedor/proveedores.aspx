<%@ Page Language="C#" AutoEventWireup="true" CodeFile="proveedores.aspx.cs" Inherits="proveedores" MasterPageFile="~/Principal.master"%>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Proveedores</h2>
        <a href="frmproveedor.aspx?Id=0">Agregar nuevo</a>
    </div>
        <div>
            <label>Proveedor</label>
            <asp:TextBox ID="txtProveedor" runat="server" placeholder="Nombre"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
        </div>
        <div>
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                    <asp:BoundField DataField="contacto" HeaderText="Contacto" />
                    <asp:HyperLinkField HeaderText="Editar"
                        DataNavigateUrlFormatString="/Proveedor/frmproveedor.aspx?Id={0}"
                        DataNavigateUrlFields="idproveedor"
                        Text="Editar" />
                    <asp:HyperLinkField HeaderText="Eliminar" 
                        DataNavigateUrlFormatString="/Proveedor/delproveedor.aspx?Id={0}"
                        DataNavigateUrlFields="idproveedor" 
                        Text="Borrar" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>