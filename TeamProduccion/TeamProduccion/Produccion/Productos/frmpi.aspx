<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="frmpi.aspx.cs" Inherits="Productos_frmpi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Insumos del producto</h2>
        <h2><asp:Literal ID="Nombre" runat="server"></asp:Literal></h2>
    </div>

    <div class="col-lg-6 col-sm-6">
        <asp:GridView CssClass="table" ID="gvInsumos" runat="server" AutoGenerateColumns="False" >
            <Columns>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Bind("idinsumo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%#Bind("insumo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Asignar">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidad" runat="server" Width="50" Enabled="false" Text='<%#Bind("cantidad")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView><br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuarcar_Click"/>
    </div>
</asp:Content>

