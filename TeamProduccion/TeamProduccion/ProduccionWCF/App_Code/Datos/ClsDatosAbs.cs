using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsDatosAbs
/// </summary>
public abstract class ClsDatosAbs
{
    #region PROPIEDADES
    protected string _servidor;
    protected string _basedatos;
    protected string _usuario;
    protected string _contrasena;
    protected string _cadenaCnn;
    protected string _mensaje;
    protected IDbConnection _conexion;

    public abstract string Servidor { get; set; }
    public abstract string BaseDatos { get; set; }
    public abstract string Usuario { get; set; }
    public abstract string Contrasena { get; set; }
    public abstract string CadenaCnn { get; }
    public abstract string Mensaje { get; }
    public abstract IDbConnection Conexion { get; }
    #endregion

    #region METODOS DE ACCESO
    public abstract void GeneraCadenaCnn();
    public abstract bool AbreConexion();
    public abstract bool CierraConexion();
    #endregion
}