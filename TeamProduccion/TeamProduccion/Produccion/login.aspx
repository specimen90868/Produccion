<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
    <form id="form1" class="form-horizontal" runat="server">
        <div class="form-group">
            <label class="col-sm-2 control-label"><h3>Login</h3></label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" class="col-sm-2 control-label" Text="Usuario"></asp:Label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtUsuario" class="form-control" runat="server" placeholder="usuario"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:label ID="lblPassword" runat="server" class="col-sm-2 control-label" Text="Password"></asp:label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password" placeholder="password"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-8">
                <asp:Button ID="btnEntrar" class="btn btn-default" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
            </div>
        </div>
        <p>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </p>
    </form>
    </div>
</body>

</html>
