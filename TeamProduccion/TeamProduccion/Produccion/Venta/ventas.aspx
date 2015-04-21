<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ventas.aspx.cs" Inherits="ventas" MasterPageFile="~/Principal.master"%>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Ventas</h2>
        <ul class="nav nav-tabs">
            <li role="presentation" class="active"><a href="frmventa.aspx?Id=0">Nueva venta</a></li>
        </ul>
        
    </div>
        <div class="form-inline">
            <div class="form-group">
                <label>Cliente:</label>
                <asp:TextBox ID="txtCliente" CssClass="form-control" runat="server" placeholder="Cliente"></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="bnt btn-default" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div>
            <asp:GridView ID="gvVentas" CssClass="table table-striped" runat="server" AutoGenerateColumns="false">
                <Columns>
                    
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="producto" HeaderText="Producto" />
                    <asp:BoundField DataField="nopedido" HeaderText="No. Pedido" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="nolote" HeaderText="No. Lote" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:BoundField DataField="total" HeaderText="Total" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:HyperLinkField 
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Venta/frmventa.aspx?Id={0}"
                        DataNavigateUrlFields="idventa"
                        Text="Editar" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>