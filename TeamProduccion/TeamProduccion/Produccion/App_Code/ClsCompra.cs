using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsCompra
/// </summary>
public class ClsCompra
{
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
}