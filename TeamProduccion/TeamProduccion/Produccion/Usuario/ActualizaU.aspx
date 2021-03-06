﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizaU.aspx.cs" Inherits="Usuario_ActualizaU" MasterPageFile="~/Principal.master" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Modificacion de usuario</h2>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="Label1" class="col-sm-2 control-label" runat="server" Text="Id:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtId" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" class="col-sm-2 control-label" Text="Usuario:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" class="col-sm-2 control-label" runat="server" Text="Password:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

         <div class="form-group">
            <asp:Label ID="Label4" class="col-sm-2 control-label" runat="server" Text="Email:"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtEmail"  class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnActualizar" CssClass="btn btn-default" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</asp:Content>
