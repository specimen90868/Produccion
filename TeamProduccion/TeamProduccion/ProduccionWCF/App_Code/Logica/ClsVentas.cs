using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsVentas
/// </summary>
public class ClsVentas : ILogica
{
	#region PROPIEDADES
    private ClsNegocioSQL _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    private int _idventa;

    public int Idventa
    {
        get { return _idventa; }
        set { _idventa = value; }
    }
    private int _idcliente;

    public int Idcliente
    {
        get { return _idcliente; }
        set { _idcliente = value; }
    }
    private int _idproducto;

    public int Idproducto
    {
        get { return _idproducto; }
        set { _idproducto = value; }
    }
    private int _nopedido;

    public int Nopedido
    {
        get { return _nopedido; }
        set { _nopedido = value; }
    }
    private int _cantidad;

    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    private int _nolote;

    public int Nolote
    {
        get { return _nolote; }
        set { _nolote = value; }
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
    private int _idusuario;

    public int Idusuario
    {
        get { return _idusuario; }
        set { _idusuario = value; }
    }

    private string _cliente;

    public string Cliente
    {
        get { return _cliente; }
        set { _cliente = value; }
    }
    private string _producto;

    public string Producto
    {
        get { return _producto; }
        set { _producto = value; }
    }

    private string _usuario;

    public string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }
    
    #endregion

    #region CONSTRUCTORES
    public ClsVentas()
	{
        _objDatos = new ClsNegocioSQL();
    }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE COMPRAS
    public List<ClsVentas> ConvertTableToList(DataTable dttD)
    {
        List<ClsVentas> lstVentas = new List<ClsVentas>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsVentas objVenta = new ClsVentas();
            objVenta.Idventa = int.Parse(registro["idventa"].ToString());
            objVenta.Idcliente = int.Parse(registro["idcliente"].ToString());
            objVenta.Idproducto = int.Parse(registro["idproducto"].ToString());
            objVenta.Nopedido = int.Parse(registro["nopedido"].ToString());
            objVenta.Cantidad = int.Parse(registro["cantidad"].ToString());
            objVenta.Nolote = int.Parse(registro["nolote"].ToString());
            objVenta.Precio = decimal.Parse(registro["precio"].ToString());
            objVenta.Total = decimal.Parse(registro["total"].ToString());
            objVenta.Fecha = DateTime.Parse(registro["fecha"].ToString());;
            objVenta.Idusuario = int.Parse(registro["idusuario"].ToString());
            objVenta.Cliente = registro["cliente"].ToString();
            objVenta.Producto = registro["producto"].ToString();
            objVenta.Usuario = registro["usuario"].ToString();
            lstVentas.Add(objVenta);
        }
        return lstVentas;
    }
    #endregion

    #region VARIABLE GLOBAL
    string query = "select v.idventa, v.idcliente, c.cliente, v.idproducto, p.producto, v.nopedido, v.cantidad," +
        "v.nolote, v.precio, v.total, v.fecha, v.idusuario, u.usuario from ventas v " +
        "left join clientes c on v.idcliente = c.idcliente " +
        "left join productos p on v.idproducto = p.idproducto " +
        "left join usuarios u on v.idusuario = u.idusuarios ";
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatos()
    {
        List<ClsVentas> lstCompras = null;
        string sentencia = query;
        lstCompras = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Ventas"));
        string datos = JsonConvert.SerializeObject(lstCompras);
        return datos;
    }

    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    {
        DataTable dttDato = new DataTable();
        string sentencia = query + "where v.idventa = @id";
        SqlParameter[] parametros ={
        new SqlParameter ("id", SqlDbType.Int,50)
        };
        object[] valores = { _idventa };
        dttDato = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Venta");
        return dttDato;
    }

    public bool Existe()
    {
        return false;
    }

    public DataTable ValidaUsuario()
    {
        return null;
    }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO ventas (idcliente, idproducto, nopedido, cantidad, nolote, precio, total, fecha, idusuario) " +
            "VALUES (@idcliente,@idproducto,@nopedido,@cantidad,@nolote,@precio,@total,@fecha,@idusuario)";
        SqlParameter[] parametros = {
             new SqlParameter("idcliente",SqlDbType.Int,50)
             ,new SqlParameter("idproducto",SqlDbType.Int,50)
             ,new SqlParameter("nopedido",SqlDbType.Int,50)
             ,new SqlParameter("cantidad",SqlDbType.Int,50)
             ,new SqlParameter("nolote",SqlDbType.Int,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,20)
             ,new SqlParameter("total",SqlDbType.Decimal,1)
             ,new SqlParameter("fecha",SqlDbType.Date,1)
             ,new SqlParameter("idusuario",SqlDbType.Int,1)
                                  };
        Object[] valores = { _idcliente, _idproducto, _nopedido, _cantidad, _nolote, _precio, _total, _fecha, _idusuario };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE ventas SET idcliente = @idcliente, idproducto = @idproducto, nopedido = @nopedido ,cantidad = @cantidad, " +
            "nolote = @nolote, precio = @precio, total = @total, fecha = @fecha, idusuario = @idusuario WHERE idventa = @id";
        SqlParameter[] parametros = {
            new SqlParameter("idcliente",SqlDbType.Int,50)
             ,new SqlParameter("idproducto",SqlDbType.Int,50)
             ,new SqlParameter("nopedido",SqlDbType.Int,50)
             ,new SqlParameter("cantidad",SqlDbType.Int,50)
             ,new SqlParameter("nolote",SqlDbType.Int,50)
             ,new SqlParameter("precio",SqlDbType.Decimal,20)
             ,new SqlParameter("total",SqlDbType.Decimal,1)
             ,new SqlParameter("fecha",SqlDbType.Date,1)
             ,new SqlParameter("idusuario",SqlDbType.Int,1)
                                  };
        Object[] valores = { _idcliente, _idproducto, _nopedido, _cantidad, _nolote, _precio, _total, _fecha, _idusuario };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM ventas WHERE idventa = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
                                  };
        Object[] valores = { _idventa };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaPago()
    { return false; }
    #endregion
}