<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mensaje.aspx.cs" Inherits="mensaje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2><asp:Literal ID="Titulo" runat="server"></asp:Literal></h2>
    </div>
        <div>
            <asp:Literal ID="Mensaje" runat="server"></asp:Literal>
        </div>
        <div>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
    </form>
</body>
</html>
