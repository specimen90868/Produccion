<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Insumos_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Insumos</h1>

    <div class="col-sm-5 col-lg-5">
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

    <div class="col-sm-1 col-lg-1"></div>

    <div class="col-lg-6 col-sm-6">
        <asp:GridView CssClass="table" ID="GridView1" runat="server"></asp:GridView>
    </div>

</asp:Content>

