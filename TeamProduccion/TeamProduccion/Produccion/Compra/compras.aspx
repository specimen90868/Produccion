<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compras.aspx.cs" Inherits="Compras" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Compras</h2>
        <ul class="nav nav-tabs">
            <li role="presentation" class="active"><a href="frmcompra.aspx?Id=0">Nueva compra</a></li>
            <li role="presentation"><a href="compraspagadas.aspx?Id=0">Compras pagadas</a></li>
        </ul>
    </div>
    <br />
        <div class="form-inline">
            <div class="form-group">
                <label>Insumo</label>
                <asp:TextBox ID="txtInsumo" class="form-control" runat="server" placeholder="Insumo"></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="btn btn-default" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
            </div>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvCompras" CssClass="table table-striped" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="idinsumo" HeaderText="Id Insumo" Visible="false" />
                    <asp:BoundField DataField="insumo" HeaderText="Insumo" />
                    <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:BoundField DataField="total" HeaderText="Total" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:HyperLinkField 
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Compra/frmcompra.aspx?Id={0}"
                        DataNavigateUrlFields="idcompra"
                        Text="Editar" />
                    <asp:HyperLinkField  
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Compra/pagar.aspx?Id={0}&Insumo={1}"
                        DataNavigateUrlFields="idcompra,idinsumo" 
                        Text="Pagar" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>