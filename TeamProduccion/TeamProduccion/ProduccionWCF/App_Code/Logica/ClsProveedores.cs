using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

/// <summary>
/// Descripción breve de ClsProveedores
/// </summary>
public class ClsProveedores : ILogica
{
    #region PROPIEDADES
    private ClsNegocioSQL _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

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
    #endregion

    #region CONSTRUCTORES
    public ClsProveedores()
	{
        _objDatos = new ClsNegocioSQL();
    }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE PROVEEDORES
    public List<ClsProveedores> ConvertTableToList(DataTable dttD)
    {
        List<ClsProveedores> lstProveedores = new List<ClsProveedores>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsProveedores objProveedor = new ClsProveedores();
            objProveedor.IdProveedor = int.Parse(registro["idproveedor"].ToString());
            objProveedor.Proveedor = registro["proveedor"].ToString();
            objProveedor.Direccion = registro["direccion"].ToString();
            objProveedor.Contacto = registro["contacto"].ToString();
            lstProveedores.Add(objProveedor);
        }
        return lstProveedores;
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatos()
    {
        List<ClsProveedores> lstProveedores = null;
        string sentencia = "select * from proveedores";
        lstProveedores = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Proveedores"));
        string datos = JsonConvert.SerializeObject(lstProveedores);
        return datos;
    }

    public string SeleccionaDatos(string dato)
    { return null;  }

    public DataTable ValidaUsuario()
    { return null; }
    
    public DataTable SeleccionaDato()
    {
        DataTable dttDato = new DataTable();
        string sentencia = "select * from proveedores where idproveedor = @id";
        SqlParameter[] parametros ={
        new SqlParameter ("id", SqlDbType.Int,50)
        };
        object[] valores = { _idProveedor };
        dttDato = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Proveedor");
        return dttDato;
    }

    public bool Existe()
    {
        return false;
    }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO proveedores (proveedor, direccion, contacto) VALUES (@nombre,@direccion,@contacto)";
        SqlParameter[] parametros = {
             new SqlParameter("nombre",SqlDbType.NVarChar,100)
             ,new SqlParameter("direccion",SqlDbType.NVarChar,100)
             ,new SqlParameter("contacto",SqlDbType.NChar,100)
                                  };
        Object[] valores = { _proveedor, _direccion, _contacto };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE proveedores SET proveedor = @nombre, direccion = @direccion, contacto = @contacto WHERE idproveedor = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
             ,new SqlParameter("nombre",SqlDbType.NVarChar,100)
             ,new SqlParameter("direccion",SqlDbType.NVarChar,100)
             ,new SqlParameter("contacto",SqlDbType.NVarChar,100)
                                  };
        Object[] valores = { _idProveedor, _proveedor, _direccion, _contacto };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM proveedores WHERE idproveedor = @id";
        SqlParameter[] parametros = {
             new SqlParameter("id",SqlDbType.Int,50)
                                  };
        Object[] valores = { _idProveedor };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaPago()
    { return false; }

    #endregion
}