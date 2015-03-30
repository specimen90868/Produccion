using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsVenta
/// </summary>
public class ClsVenta
{
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
}