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


public class ClsProducto : ILogica
{
    public ClsProducto()
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

    public int idProducto { get; set; }
    public string Producto { get; set; }
    public decimal Precio { get; set; }
    public List<ClsInsumos> Insumos { get; set; }


    #endregion

    #region METODOS GENERALES PARA EL MANEJO DE DATOS

    public List<ClsProducto> ConvertTableToList(DataTable dttD)
    {
        List<ClsProducto> lstInsumos = new List<ClsProducto>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsProducto objProducto = new ClsProducto();
            objProducto.idProducto = int.Parse(registro["idProducto"].ToString());
            objProducto.Producto = registro["producto"].ToString();
            objProducto.Precio = decimal.Parse(registro["precio"].ToString());
            lstInsumos.Add(objProducto);
        }
        return lstInsumos;
    }

    #endregion

    #region ACCESO A BASE DE DATOS
    public string SeleccionaDatos()
    {
        List<ClsProducto> lstProductos = null;
        string sentencia = "SELECT * from productos";
        var values = (DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Insumos");
        lstProductos = ConvertTableToList(values);
        string datos = JsonConvert.SerializeObject(lstProductos);
        return datos;
    }


    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    {
        DataTable lstInsumos = new DataTable();
        string sentencia = "select * from productos where idproducto = @producto";
        SqlParameter[] parametros ={
        new SqlParameter ("producto", SqlDbType.Int)
        };
        Object[] valores = { idProducto };
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

        string comando = "INSERT INTO productos (producto, precio) VALUES (@producto, @precio)";
        SqlParameter[] parametros = {
             new SqlParameter("producto",SqlDbType.NVarChar,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,18)
        };
        Object[] valores = { Producto, Precio };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE productos SET producto = @producto, precio = @precio WHERE idproducto = @idproducto";
        SqlParameter[] parametros = {
             new SqlParameter("idproducto",SqlDbType.Int,50)
             ,new SqlParameter("producto",SqlDbType.NVarChar,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,18)
        };
        Object[] valores = { idProducto, Producto, Precio };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM productos WHERE idproducto = @idproducto";
        SqlParameter[] parametros = {
             new SqlParameter("idproducto",SqlDbType.Int)
                                  };
        Object[] valores = { idProducto };
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