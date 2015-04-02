<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="reporteconsumo.aspx.cs" Inherits="Reportes_reporteconsumo" %>

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
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
    </div>
    
    <div style="width: 50%">
      <div>
          <canvas id="1" height="250" width="400"></canvas>
          <canvas id="2" height="250" width="400"></canvas>
          <canvas id="3" height="250" width="400"></canvas>
          <canvas id="4" height="250" width="400"></canvas>
          <canvas id="5" height="250" width="400"></canvas>
          <canvas id="6" height="250" width="400"></canvas>
          <canvas id="7" height="250" width="400"></canvas>
          <canvas id="8" height="250" width="400"></canvas>
          <canvas id="9" height="250" width="400"></canvas>
          <canvas id="10" height="250" width="400"></canvas>
          <canvas id="11" height="250" width="400"></canvas>
          <canvas id="12" height="250" width="400"></canvas>
      </div>
    </div>
    
    <script>
        var lineChartData = {
            labels: <% =this.ChartLabels %>,
            datasets: [
                {
                    label: "Grafica",
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
            var ctx = document.getElementById(<% =this.id %>).getContext("2d");
            window.myLine = new Chart(ctx).Line(lineChartData, {
                responsive: true
            });
        }
    </script>
</asp:Content>

