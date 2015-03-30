using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ClsDatosSQL
/// </summary>
public class ClsDatosSQL : ClsDatosAbs
{
    #region CONSTRUCTORES
    //Constructor por default, inicializa el tipo de autenticacíón a Sql Server
    public ClsDatosSQL()
    {
        this.tipo = 1;
    }
    //Asigna el tipo de Autenticación, el cuál se recibe por pase de parámetros
    public ClsDatosSQL(int tipo)
    {
        this.tipo = tipo;

    }
    //Asigna la cadena de conexión directamente
    public ClsDatosSQL(string cadena)
    {
        this._cadenaCnn = cadena;

    }
    #endregion

    #region PROPIEDADES
    private int tipo = 0;

    public int Tipo
    {
        get { return tipo; }
    }

    public override string Servidor
    {
        get
        {
            return _servidor;
        }
        set
        {
            _servidor = value;
        }
    }

    public override string BaseDatos
    {
        get
        {
            return _basedatos;
        }
        set
        {
            _basedatos = value;
        }
    }

    public override string Usuario
    {
        get
        {
            return _usuario;
        }
        set
        {
            _usuario = value;
        }
    }

    public override string Contrasena
    {
        get
        {
            return _contrasena;
        }
        set
        {
            _contrasena = value;
        }
    }

    public override string CadenaCnn
    {
        get
        {
            if (_cadenaCnn == "")
                GeneraCadenaCnn();
            return _cadenaCnn;
        }
    }

    public override System.Data.IDbConnection Conexion
    {
        get
        {
            if (_conexion == null)
            {
                GeneraCadenaCnn();
                AbreConexion();
            }
            else
                if (((SqlConnection)_conexion).State != System.Data.ConnectionState.Open)
                    AbreConexion();
            return _conexion;
        }
    }

    public override string Mensaje
    {
        get { return _mensaje; }
    }

    #endregion

    #region ACCESO A BASE DE DATOS

    public override void GeneraCadenaCnn()
    {
        switch (tipo)
        {
            case 1:

                if (_servidor != "" && _basedatos != "" && _usuario != "" && _contrasena != "")
                {
                    _cadenaCnn = String.Format("Data Source ={0}; Initial Catalog={1}; User ID={2}; Password = {3}", _servidor, _basedatos, _usuario, _contrasena);
                }
                else
                    _cadenaCnn = "";
                break;
            case 2: //Autenticación Windows

                if (_servidor != "" && _basedatos != "")
                {
                    _cadenaCnn = String.Format("Data Source ={0}; Initial Catalog={1}; Integrated Security=SSPI", _servidor, _basedatos);
                }
                else
                    _cadenaCnn = "";
                break;
            default:
                _cadenaCnn = "";
                break;
        }
    }

    public override bool AbreConexion()
    {
        bool valido = false;
        try
        {
            _conexion = new SqlConnection();
            _conexion.ConnectionString = CadenaCnn;
            _conexion.Open();
            valido = true;
            _mensaje = "Conexión Abierta";
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            valido = false;
            _conexion = null;
        }

        return valido;
    }

    public override bool CierraConexion()
    {
        bool valido = false;
        try
        {
            if (_conexion != null)
            {
                SqlConnection conexionBD = (SqlConnection)_conexion;
                if (conexionBD.State == System.Data.ConnectionState.Open)
                    conexionBD.Close();

                else
                    throw new Exception("Conexión No está abierta");
                _conexion = conexionBD;
                valido = true;

            }
            else
            {
                throw new Exception("Conexión No Existe");
            }
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            valido = false;
        }
        return valido;
    }
    #endregion
}