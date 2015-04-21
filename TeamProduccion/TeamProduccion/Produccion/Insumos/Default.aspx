<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Insumos_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-sm-6 col-lg-6">
            <h2>Insumos</h2>
        </div>
        <div class="col-sm-6 col-lg-6">
            <h2>Listado de insumos</h2>
        </div>
    </div>

    <div class="col-sm-6 col-lg-6">
        <div class="form-group">
            <label>Nombre</label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Precio</label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Existencia</label><br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>

        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="Guardar" OnClick="Button1_Click" />
    </div>

    <div class="col-lg-6 col-sm-6">
        <asp:GridView CssClass="table" ID="gvInsumos" runat="server" AutoGenerateColumns="false">
            <Columns>
                    <asp:BoundField DataField="insumo" HeaderText="Insumo" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:BoundField DataField="existencia" HeaderText="Exsitencia" />
                    <asp:HyperLinkField HeaderText="Editar"
                        DataNavigateUrlFormatString="/lsw/serviciolsw/Insumos/frminsumo.aspx?Id={0}"
                        DataNavigateUrlFields="idinsumo"
                        Text="Editar" />
                </Columns>
        </asp:GridView>
    </div>

</asp:Content>

