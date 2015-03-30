using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ClsCompras
/// </summary>
public class ClsCompras : ILogica
{

    #region PROPIEDADES
    private ClsNegocioSQL _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    private int _idCompra;

    public int IdCompra
    {
        get { return _idCompra; }
        set { _idCompra = value; }
    }
    private int _idInsumo;

    public int IdInsumo
    {
        get { return _idInsumo; }
        set { _idInsumo = value; }
    }
    private int _idproveedor;

    public int Idproveedor
    {
        get { return _idproveedor; }
        set { _idproveedor = value; }
    }
    private int _cantidad;

    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    private decimal _precio;

    public decimal Precio
    {
        get { return _precio; }
        set { _precio = value; }
    }
    private decimal _total;

    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
    }
    private DateTime _fecha;

    public DateTime Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }
    private bool _pagado;

    public bool Pagado
    {
        get { return _pagado; }
        set { _pagado = value; }
    }

    private string _insumo;

    public string Insumo
    {
        get { return _insumo; }
        set { _insumo = value; }
    }
    private string _proveedor;

    public string Proveedor
    {
        get { return _proveedor; }
        set { _proveedor = value; }
    }
       
    #endregion

	#region CONSTRUCTORES
    public ClsCompras()
	{
        _objDatos = new ClsNegocioSQL();
    }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE COMPRAS
    public List<ClsCompras> ConvertTableToList(DataTable dttD)
    {
        List<ClsCompras> lstCompras = new List<ClsCompras>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsCompras objCompra = new ClsCompras();
            objCompra.IdCompra = int.Parse(registro["idcompra"].ToString());
            objCompra.IdInsumo = int.Parse(registro["idinsumo"].ToString());
            objCompra.Idproveedor = int.Parse(registro["idproveedor"].ToString());
            objCompra.Cantidad = int.Parse(registro["cantidad"].ToString());
            objCompra.Precio = decimal.Parse(registro["precio"].ToString());
            objCompra.Total = decimal.Parse(registro["total"].ToString());
            objCompra.Fecha = DateTime.Parse(registro["fecha"].ToString());
            objCompra.Pagado = bool.Parse(registro["pagado"].ToString());
            objCompra.Insumo = registro["insumo"].ToString();
            objCompra.Proveedor = registro["proveedor"].ToString();
            lstCompras.Add(objCompra);
        }
        return lstCompras;
    }
    #endregion

    #region VARIABLE GLOBAL
    string query = "select c.idcompra, i.idinsumo, i.insumo, p.idproveedor, p.proveedor, c.cantidad, c.precio, c.total, c.fecha," +
            "c.pagado from compras c " +
            "left join proveedores p on c.idproveedor = p.idproveedor " +
            "left join insumos i on c.idinsumo = i.idinsumo";
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatos()
    {
        List<ClsCompras> lstCompras = null;
        string sentencia = query;
        lstCompras = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Compras"));
        string datos = JsonConvert.SerializeObject(lstCompras);
        return datos;
    }

    public string SeleccionaDatos(string dato)
    {
        List<ClsCompras> lstCompras = null;
        string sentencia = query + " WHERE c.pagado = " + dato;
        lstCompras = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Compras"));
        string datos = JsonConvert.SerializeObject(lstCompras);
        return datos;
    }

    public DataTable SeleccionaDato()
    {
        DataTable dttDato = new DataTable();
        string sentencia = query + " where c.idcompra = @id";
        SqlParameter[] parametros ={
        new SqlParameter ("id", SqlDbType.Int,50)
        };
        object[] valores = { _idCompra };
        dttDato = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Compra");
        return dttDato;
    }

    public DataTable ValidaUsuario()
    {
        return null;
    }

    public bool Existe()
    {
        return false;
    }
    
    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO compras (idinsumo, idproveedor, cantidad, precio, total, fecha, pagado) " + 
            "VALUES (@idinsumo,@idproveedor,@cantidad,@precio,@total,@fecha,@pagado)";
        SqlParameter[] parametros = {
             new SqlParameter("idinsumo",SqlDbType.Int,50)
             ,new SqlParameter("idproveedor",SqlDbType.Int,50)
             ,new SqlParameter("cantidad",SqlDbType.Int,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,50)
             ,new SqlParameter("total",SqlDbType.Decimal,50)
             ,new SqlParameter("fecha",SqlDbType.Date,20)
             ,new SqlParameter("pagado",SqlDbType.Bit,1)
                                  };
        Object[] valores = { _idInsumo, _idproveedor, _cantidad, _precio, _total, _fecha, _pagado };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE compras SET idinsumo = @idinsumo, idproveedor = @idproveedor, cantidad = @cantidad, " + 
            "precio = @precio, total = @total, fecha = @fecha, pagado = @pagado WHERE idcompra = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
             ,new SqlParameter("idinsumo",SqlDbType.Int,50)
             ,new SqlParameter("idproveedor",SqlDbType.Int,50)
             ,new SqlParameter("cantidad",SqlDbType.Int,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,50)
             ,new SqlParameter("total",SqlDbType.Decimal,50)
             ,new SqlParameter("fecha",SqlDbType.Date,20)
             ,new SqlParameter("pagado",SqlDbType.Bit,1)
                                  };
        Object[] valores = { _idCompra, _idInsumo, _idproveedor, _cantidad, _precio, _total, _fecha, _pagado };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool ActualizaPago()
    {
        bool valido = false;
        string comando = "UPDATE compras SET pagado = @pagado WHERE idcompra = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
             ,new SqlParameter("pagado",SqlDbType.Bit,1)
                                  };
        Object[] valores = { _idCompra, _pagado };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM compras WHERE idcompra = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
                                  };
        Object[] valores = { _idCompra };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    #endregion
}