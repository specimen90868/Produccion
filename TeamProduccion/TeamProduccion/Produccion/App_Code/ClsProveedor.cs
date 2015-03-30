using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsProveedor
/// </summary>
public class ClsProveedor
{
    private int _idProveedor;

    public int IdProveedor
    {
        get { return _idProveedor; }
        set { _idProveedor = value; }
    }

    private string _proveedor;

    public string Proveedor
    {
        get { return _proveedor; }
        set { _proveedor = value; }
    }
    private string _direccion;

    public string Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }

    private string _contacto;

    public string Contacto
    {
        get { return _contacto; }
        set { _contacto = value; }
    }
}