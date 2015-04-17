using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class ClsInsumos : ILogica
{
    public ClsInsumos()
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

    public int idInsumo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Existencia { get; set; }
  

    #endregion

    #region METODOS GENERALES PARA EL MANEJO DE DATOS

    public List<ClsInsumos> ConvertTableToList(DataTable dttD)
    {
        List<ClsInsumos> lstInsumos = new List<ClsInsumos>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsInsumos objInsumo = new ClsInsumos();
            objInsumo.idInsumo = int.Parse(registro["idinsumo"].ToString());
            objInsumo.Nombre = registro["nombre"].ToString();
            objInsumo.Precio = decimal.Parse(registro["precio"].ToString());
            objInsumo.Existencia = int.Parse(registro["existencia"].ToString());
            lstInsumos.Add(objInsumo);
        }
        return lstInsumos;
    }

    #endregion

    #region ACCESO A BASE DE DATOS
    public string SeleccionaDatos()
    {
        List<ClsInsumos> lstInsumos = null;
        string sentencia = "SELECT * from insumos";
        var values = (DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Insumos");
        lstInsumos = ConvertTableToList(values);
        string datos = JsonConvert.SerializeObject(lstInsumos);
        return datos;
    }

    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    {
        DataTable lstInsumos = new DataTable();
        string sentencia = "select * from insumos where idinsumo = @insumo";
        SqlParameter[] parametros ={
        new SqlParameter ("insumo", SqlDbType.Int)
        };
        Object[] valores = { idInsumo };
        lstInsumos = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Insumos");
        return lstInsumos;
    }

    public DataTable ValidaUsuario()
    {
        return null;
    }

    public bool Existe()
    { return false; }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO insumos (nombre, precio, existencia) VALUES (@nombre, @precio, @existencia)";
        SqlParameter[] parametros = {
             new SqlParameter("nombre",SqlDbType.NVarChar,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,18)
             ,new SqlParameter("existencia",SqlDbType.Int)
                                  };
        Object[] valores = { Nombre, Precio, Existencia };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE insumos SET nombre = @nombre, precio = @precio, existencia = @existencia WHERE idinsumo = @idinsumo";
        SqlParameter[] parametros = {
             new SqlParameter("idinsumo",SqlDbType.Int,50)
             ,new SqlParameter("nombre",SqlDbType.NVarChar,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,18)
             ,new SqlParameter("existencia",SqlDbType.Int)
                                  };
        Object[] valores = { idInsumo, Nombre, Precio, Existencia };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM insumos WHERE idinsumo = @idinsumo";
        SqlParameter[] parametros = {
             new SqlParameter("idinsumo",SqlDbType.Int)
                                  };
        Object[] valores = { idInsumo };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaPago()
    { return false; }
    #endregion

    #region JSON

    public Dictionary<string, Dictionary<string, object>> DatatableDictionary(DataTable dt, string id)
    {
        var cols = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != id);
        return dt.Rows.Cast<DataRow>()
            .ToDictionary(r => r[id].ToString(),
            r => cols.ToDictionary(c => c.ColumnName, c => r[c.ColumnName]));

    }

    #endregion
}