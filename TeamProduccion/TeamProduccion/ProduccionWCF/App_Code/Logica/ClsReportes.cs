using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsReportes
/// </summary>
public class ClsReportes 
{
    public ClsReportes()
	{
        //string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegocioSQL();

	}

    #region VARIABLE GLOBAL

    private ClsNegocioSQL _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }
    #endregion

    #region PROPIEDADES
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int Top { get; set; }
    #endregion

    #region ACCESO A BASE DE DATOS

    public List<string> SeleccionaDatosTopCompras()
    {
        List<string> lstString = new List<string>();
        DataTable ddt = new DataTable();
        string labels = "[";
        string data = "";
        string sentencia = "exec sp_topcompras @fechaini, @fechafin, @top";
        SqlParameter[] parametros ={
            new SqlParameter ("fechaini", SqlDbType.Date),
            new SqlParameter ("fechafin", SqlDbType.Date),
            new SqlParameter ("top", SqlDbType.Int),
                                   };
        object[] valores = { FechaInicio, FechaFin, Top };
        ddt = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "ReporteTop");

        foreach (DataRow registro in ddt.Rows)
        {
            labels = labels + "\"" + registro["descripcion"].ToString() + "\",";
            data = data + "\"" + registro["Cantidad"].ToString() + "\",";
        }

        labels = labels.Remove(labels.Length - 1, 1);
        data = data.Remove(data.Length - 1, 1);

        labels = labels + "]";

        lstString.Add(labels);
        lstString.Add(data);

        return lstString;
    }

    public List<string> SeleccionaDatosTopVentas()
    {
        List<string> lstString = new List<string>();
        DataTable ddt = new DataTable();
        string labels = "[";
        string data = "";
        string sentencia = "exec sp_topventas @fechaini, @fechafin, @top";
        SqlParameter[] parametros ={
            new SqlParameter ("fechaini", SqlDbType.Date),
            new SqlParameter ("fechafin", SqlDbType.Date),
            new SqlParameter ("top", SqlDbType.Int),
                                   };
        object[] valores = { FechaInicio, FechaFin, Top };
        ddt = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "ReporteTop");

        foreach (DataRow registro in ddt.Rows)
        {
            labels = labels + "\"" + registro["descripcion"].ToString() + "\",";
            data = data + "\"" + registro["Cantidad"].ToString() + "\",";
        }

        labels = labels.Remove(labels.Length - 1, 1);
        data = data.Remove(data.Length - 1, 1);

        labels = labels + "]";

        lstString.Add(labels);
        lstString.Add(data);

        return lstString;
    }

    public List<string> SeleccionaDatosConsumo()
    {
        List<string> lstString = new List<string>();
        DataTable ddt = new DataTable();
        string labels = "[";
        string Enero = "", Febrero = "", Marzo = "", Abril = "", Mayo = "", Junio = "", Julio = "",
            Agosto = "", Septiembre = "", Octubre = "", Noviembre = "", Diciembre = "";
        string sentencia = "exec sp_comprasxmes @fechaini, @fechafin";
        SqlParameter[] parametros ={
            new SqlParameter ("fechaini", SqlDbType.Date),
            new SqlParameter ("fechafin", SqlDbType.Date)
                                   };
        object[] valores = { FechaInicio, FechaFin };
        ddt = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "ReporteCompras");

        foreach (DataRow registro in ddt.Rows)
        {
            labels = labels + "\"" + registro["item"].ToString() + "\",";
            Enero = Enero + "\"" + registro["Enero"].ToString() + "\",";
            Febrero = Febrero + "\"" + registro["Febrero"].ToString() + "\",";
            Marzo = Marzo + "\"" + registro["Marzo"].ToString() + "\",";
            Abril = Abril + "\"" + registro["Abril"].ToString() + "\",";
            Mayo = Mayo + "\"" + registro["Mayo"].ToString() + "\",";
            Junio = Junio +"\"" + registro["Junio"].ToString() + "\",";
            Julio = Julio + "\"" + registro["Julio"].ToString() + "\",";
            Agosto = Agosto + "\"" + registro["Agosto"].ToString() + "\",";
            Septiembre = Septiembre + "\"" + registro["Septiembre"].ToString() + "\",";
            Octubre = Octubre + "\"" + registro["Octubre"].ToString() + "\",";
            Noviembre = Noviembre + "\"" + registro["Noviembre"].ToString() + "\",";
            Diciembre = Diciembre + "\"" + registro["Diciembre"].ToString() + "\",";
        }

        labels = labels.Remove(labels.Length - 1, 1);
        Enero = Enero.Remove(Enero.Length - 1, 1);
        Febrero = Febrero.Remove(Febrero.Length - 1, 1);
        Marzo = Marzo.Remove(Marzo.Length - 1, 1);
        Abril = Abril.Remove(Abril.Length - 1, 1);
        Mayo = Mayo.Remove(Mayo.Length - 1, 1);
        Junio = Junio.Remove(Junio.Length - 1, 1);
        Julio = Julio.Remove(Julio.Length - 1, 1);
        Agosto = Agosto.Remove(Agosto.Length - 1, 1);
        Septiembre = Septiembre.Remove(Septiembre.Length - 1, 1);
        Octubre = Octubre.Remove(Octubre.Length - 1, 1);
        Noviembre = Noviembre.Remove(Noviembre.Length - 1, 1);
        Diciembre = Diciembre.Remove(Diciembre.Length - 1, 1);

        labels = labels + "]";

        lstString.Add(labels);
        lstString.Add(Enero);
        lstString.Add(Febrero);
        lstString.Add(Marzo);
        lstString.Add(Abril);
        lstString.Add(Mayo);
        lstString.Add(Junio);
        lstString.Add(Julio);
        lstString.Add(Agosto);
        lstString.Add(Septiembre);
        lstString.Add(Octubre);
        lstString.Add(Noviembre);
        lstString.Add(Diciembre);

        return lstString;
    }

    public List<string> SeleccionaDatosVentas()
    {
        List<string> lstString = new List<string>();
        DataTable ddt = new DataTable();
        string labels = "[";
        string Enero = "", Febrero = "", Marzo = "", Abril = "", Mayo = "", Junio = "", Julio = "",
            Agosto = "", Septiembre = "", Octubre = "", Noviembre = "", Diciembre = "";
        string sentencia = "exec sp_ventasxmes @fechaini, @fechafin";
        SqlParameter[] parametros ={
            new SqlParameter ("fechaini", SqlDbType.Date),
            new SqlParameter ("fechafin", SqlDbType.Date)
                                   };
        object[] valores = { FechaInicio, FechaFin };
        ddt = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "ReporteCompras");

        foreach (DataRow registro in ddt.Rows)
        {
            labels = labels + "\"" + registro["item"].ToString() + "\",";
            Enero = "\"" + registro["Enero"].ToString() + "\",";
            Febrero = "\"" + registro["Enero"].ToString() + "\",";
            Marzo = "\"" + registro["Enero"].ToString() + "\",";
            Abril = "\"" + registro["Enero"].ToString() + "\",";
            Mayo = "\"" + registro["Enero"].ToString() + "\",";
            Junio = "\"" + registro["Enero"].ToString() + "\",";
            Julio = "\"" + registro["Enero"].ToString() + "\",";
            Agosto = "\"" + registro["Enero"].ToString() + "\",";
            Septiembre = "\"" + registro["Enero"].ToString() + "\",";
            Octubre = "\"" + registro["Enero"].ToString() + "\",";
            Noviembre = "\"" + registro["Enero"].ToString() + "\",";
            Diciembre = "\"" + registro["Enero"].ToString() + "\",";
        }

        labels = labels.Remove(labels.Length - 1, 1);
        Enero = Enero.Remove(Enero.Length - 1, 1);
        Febrero = Febrero.Remove(Febrero.Length - 1, 1);
        Marzo = Marzo.Remove(Marzo.Length - 1, 1);
        Abril = Abril.Remove(Abril.Length - 1, 1);
        Mayo = Mayo.Remove(Mayo.Length - 1, 1);
        Junio = Junio.Remove(Junio.Length - 1, 1);
        Julio = Julio.Remove(Julio.Length - 1, 1);
        Agosto = Agosto.Remove(Agosto.Length - 1, 1);
        Septiembre = Septiembre.Remove(Septiembre.Length - 1, 1);
        Octubre = Octubre.Remove(Octubre.Length - 1, 1);
        Noviembre = Noviembre.Remove(Noviembre.Length - 1, 1);
        Diciembre = Diciembre.Remove(Diciembre.Length - 1, 1);

        labels = labels + "]";

        lstString.Add(labels);
        lstString.Add(Enero);
        lstString.Add(Febrero);
        lstString.Add(Marzo);
        lstString.Add(Abril);
        lstString.Add(Mayo);
        lstString.Add(Junio);
        lstString.Add(Julio);
        lstString.Add(Agosto);
        lstString.Add(Septiembre);
        lstString.Add(Octubre);
        lstString.Add(Noviembre);
        lstString.Add(Diciembre);

        return lstString;
    }
    #endregion
}