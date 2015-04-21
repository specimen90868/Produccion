using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsProductoInsumo
/// </summary>
public class ClsProductoInsumo : ILogica
{
	public ClsProductoInsumo()
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

    public int IdProducto { get; set; }
    public int IdInsumo { get; set; }
    public int Cantidad { get; set; }
    public string Insumo { get; set; }
    
    #endregion

    #region METODOS GENERALES PARA EL MANEJO DE DATOS

    public List<ClsProductoInsumo> ConvertTableToList(DataTable dttD)
    {
        List<ClsProductoInsumo> lstInsumos = new List<ClsProductoInsumo>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsProductoInsumo objProductoInsumo = new ClsProductoInsumo();
            objProductoInsumo.IdInsumo = int.Parse(registro["idinsumo"].ToString());
            objProductoInsumo.Cantidad = int.Parse(registro["cantidad"].ToString());
            objProductoInsumo.Insumo = registro["insumo"].ToString();
            lstInsumos.Add(objProductoInsumo);
        }
        return lstInsumos;
    }

    #endregion 

    #region ACCESO A BASE DE DATOS
    public string SeleccionaDatos()
    {
        List<ClsProductoInsumo> lstProdInsumo = null;
        string sentencia = "select i.idinsumo, i.insumo, coalesce(a.cantidad,0) as cantidad from insumos i " + 
                        "left join (select id, idproducto, idinsumo, cantidad from producto_insumo where " + 
                        "idproducto = @producto) a on i.idinsumo = a.idinsumo";
        SqlParameter[] parametros ={
            new SqlParameter ("producto", SqlDbType.Int)
            };
        Object[] valores = { IdProducto };
        lstProdInsumo = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Insumos"));
        string datos = JsonConvert.SerializeObject(lstProdInsumo);
        return datos;
    }


    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    { return null; }

    public DataTable ValidaUsuario()
    {
        return null;
    }

    public bool Existe()
    { return false; }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO producto_insumo (idproducto, idinsumo, cantidad) VALUES (@producto, @insumo, @cantidad)";
        SqlParameter[] parametros = {
             new SqlParameter("producto",SqlDbType.Int)
             ,new SqlParameter("insumo",SqlDbType.Int)
             ,new SqlParameter("cantidad",SqlDbType.Int)
        };
        Object[] valores = { IdProducto, IdInsumo, Cantidad };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE producto_insumo SET idproducto = @producto, idinsumo = @insumo, cantidad = @cantidad WHERE id = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int)
             ,new SqlParameter("producto",SqlDbType.Int)
             ,new SqlParameter("insumo",SqlDbType.Int)
             ,new SqlParameter("cantidad",SqlDbType.Int)
        };
        Object[] valores = { IdProducto, IdInsumo, Cantidad };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM producto_insumo WHERE idproducto = @producto";
        SqlParameter[] parametros = { new SqlParameter("producto",SqlDbType.Int) };
        Object[] valores = { IdProducto };
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