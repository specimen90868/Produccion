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


public class ClsUsuarios:ILogica
{
	public ClsUsuarios()
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

    private int _idusuarios;
    private string _usuario;
    private string _password;
    private string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    public int IdUsuarios
    {
        get { return _idusuarios; }
        set { _idusuarios = value; }
    }

        #endregion

    #region METODOS GENERALES PARA EL MANEJO DE DATOS

    public List<ClsUsuarios> ConvertTableToList(DataTable dttD)
    {
        List<ClsUsuarios> lstUsuarios = new List<ClsUsuarios>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsUsuarios objUsuario = new ClsUsuarios();
            objUsuario.IdUsuarios = int.Parse(registro["idusuarios"].ToString());
            objUsuario.Usuario = registro["usuario"].ToString();
            objUsuario.Password = registro["password"].ToString();
            objUsuario.Email = registro["email"].ToString();
            lstUsuarios.Add(objUsuario);
        }
        return lstUsuarios;
    }
    
    #endregion

    #region ACCESO A BASE DE DATOS
    public string SeleccionaDatos()
    {
        List<ClsUsuarios> lstUsuarios = null;
        string sentencia = "SELECT * from usuarios";
        lstUsuarios = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Usuarios"));
        string datos = JsonConvert.SerializeObject(lstUsuarios);
        return datos;
    }

    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    {
        DataTable lstUsuarios = new DataTable();
        string sentencia = "select * from usuarios where usuario = @usuario";
        SqlParameter[] parametros ={
        new SqlParameter ("usuario", SqlDbType.NVarChar,50)
        };
        Object[] valores = { _usuario };
        lstUsuarios = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Usuarios");
        return lstUsuarios;
    }

    public DataTable ValidaUsuario()
    {
        DataTable lstUsuarios = new DataTable();
        string sentencia = "select idusuarios,usuario from usuarios where usuario = @usuario and password = @password";
        SqlParameter[] parametros ={
        new SqlParameter ("usuario", SqlDbType.NVarChar,50),
        new SqlParameter ("password", SqlDbType.NVarChar,50)
        };
        Object[] valores = { _usuario, _password };
        lstUsuarios = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Usuarios");
        return lstUsuarios;
    }

    public bool Existe()
    { return false; }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO usuarios (usuario, password, email) VALUES (@usuario,@password,@email)";
        SqlParameter[] parametros = {
             new SqlParameter("usuario",SqlDbType.NVarChar,50)
             ,new SqlParameter("password",SqlDbType.NVarChar,50)
             
             ,new SqlParameter("email",SqlDbType.NVarChar,50)
                                  };
        Object[] valores = { _usuario, _password, _email };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE usuarios SET usuario = @usuario, password = @password, email = @email WHERE idusuarios = @idusuarios";
        SqlParameter[] parametros = {
             new SqlParameter("idusuarios",SqlDbType.Int,50)
             ,new SqlParameter("usuario",SqlDbType.NVarChar,100)
             ,new SqlParameter("password",SqlDbType.NVarChar,100)
             ,new SqlParameter("email",SqlDbType.NVarChar,100)
                                  };
        Object[] valores = { _idusuarios, _usuario, _password, _email };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool EliminaDatos()
    {
        bool valido = false;

        string comando = "DELETE FROM usuarios WHERE usuario = @usuario";
        SqlParameter[] parametros = {
             new SqlParameter("usuario",SqlDbType.NVarChar,50)
                                  };
        Object[] valores = { _usuario };
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