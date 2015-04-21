<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="reporteconsumo.aspx.cs" Inherits="Reportes_reporteconsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Reporte de Consumo por Usuario</h2>
    <div class="form-inline">
        <div class="form-group">
            <label>Tipo de Reporte:</label>
            <asp:DropDownList ID="ddlTipoReporte" CssClass="form-control" runat="server">
                <asp:ListItem Value="0" Text="Compras"></asp:ListItem>
                <asp:ListItem Value="1" Text="Ventas"></asp:ListItem>
            </asp:DropDownList>

            <label>Fecha Inicial:</label>
            <input id="dtInicial" class="form-control" type="date" runat="server" />

            <label>Fecha Final:</label>
            <input id="dtFinal" type="date" class="form-control" runat="server" />

            <asp:Button ID="btnGenerar" CssClass="btn btn-default" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
            </div>
    </div>
    
    <div style="width: 50%">
      <div>
          <canvas id="grafica" height="250" width="400"></canvas>
          <%--<canvas id="2" height="250" width="400"></canvas>
          <canvas id="3" height="250" width="400"></canvas>
          <canvas id="4" height="250" width="400"></canvas>
          <canvas id="5" height="250" width="400"></canvas>
          <canvas id="6" height="250" width="400"></canvas>
          <canvas id="7" height="250" width="400"></canvas>
          <canvas id="8" height="250" width="400"></canvas>
          <canvas id="9" height="250" width="400"></canvas>
          <canvas id="10" height="250" width="400"></canvas>
          <canvas id="11" height="250" width="400"></canvas>
          <canvas id="12" height="250" width="400"></canvas>--%>
      </div>
    </div>
    
    <script>
        var lineChartData = {
            labels: <% =this.ChartLabels %>,
            datasets: [
                {
                    label: "Enero",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataEnero %>]
                },
                {
                    label: "Febrero",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,2)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataFebrero %>]
                },
                {
                    label: "Marzo",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,3)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataMarzo %>]
                },
                {
                    label: "Abril",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,4)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataAbril %>]
                },
                {
                    label: "Mayo",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,5)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataMayo %>]
                },
                {
                    label: "Junio",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,6)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataJunio %>]
                },
                {
                    label: "Julio",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,7)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataJulio %>]
                },
                {
                    label: "Agosto",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,8)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataAgosto %>]
                },
                {
                    label: "Septiembre",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,9)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataSept %>]
                },
                {
                    label: "Octubre",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,10)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataOct %>]
                },
                {
                    label: "Noviembre",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,11)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataNov %>]
                },
                {
                    label: "Diciembre",
                    fillColor: "rgba(220,220,220,0.2)",
                    strokeColor: "rgba(220,220,220,12)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [<% =this.ChartDataDic %>]
                },
            ]
        }

        function DrawChart() {
            var ctx = document.getElementById("grafica").getContext("2d");
            window.myLine = new Chart(ctx).Line(lineChartData, {
                responsive: true
            });
        }
    </script>
</asp:Content>

