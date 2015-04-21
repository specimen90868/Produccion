<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmventa.aspx.cs" Inherits="frmventa" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>Datos de venta</h2>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">Producto:</label>
            <div class="col-sm-10">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Cliente:</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlCliente" CssClass="form-control" runat="server"></asp:DropDownList> 
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">No. Pedido:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPedido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Cantidad:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">No. Lote:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtLote" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Precio:</label>
            <div class="col-sm-10">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProducto" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Total:</label>
            <div class="col-sm-10">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnGuardar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>