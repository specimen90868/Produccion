<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="reportes.aspx.cs" Inherits="Reportes_reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <label>Tipo de Reporte:</label>
        <asp:DropDownList ID="ddlTipoReporte" runat="server">
            <asp:ListItem Value="0" Text="Compras"></asp:ListItem>
            <asp:ListItem Value="1" Text="Ventas"></asp:ListItem>
        </asp:DropDownList>
        <label>Fecha Inicial:</label>
        <input id="dtInicial" type="date" runat="server" />
        <label>Fecha Final:</label>
        <input id="dtFinal" type="date" runat="server" />
        <label>Top:</label>
        <asp:DropDownList ID="ddlTop" runat="server">
            <asp:ListItem Value="5" Text="5"></asp:ListItem>
            <asp:ListItem Value="10" Text="10"></asp:ListItem>
            <asp:ListItem Value="15" Text="15"></asp:ListItem>
            <asp:ListItem Value="20" Text="20"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
    </div>
    
    <div style="width: 50%">
      <div>
        <canvas id="myCanvas" height="250" width="400"></canvas>
      </div>
    </div>
    
    <script>
        var lineChartData = {
            labels: <% =this.ChartLabels %>,
            datasets: [
                {
                    label: "My First dataset",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartData %>]
                }
            ]
        }

        function DrawChart() {
            var ctx = document.getElementById("myCanvas").getContext("2d");
            window.myLine = new Chart(ctx).Line(lineChartData, {
                responsive: true
            });
        }
    </script>
</asp:Content>

