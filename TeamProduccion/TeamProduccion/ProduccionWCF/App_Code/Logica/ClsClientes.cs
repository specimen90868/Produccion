using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class ClsClientes: ILogica
{
	public ClsClientes()
	{
        //string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegocioSQL();

	}

    # region VARIABLE GLOBAL

    private ClsNegocioSQL _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

#endregion

    #region PROPIEDADES

    private int _idclientes;
    private string _nombre;
    private string _direccion;
    private string _contacto;
    public int Idclientes
    {
        get { return _idclientes; }
        set { _idclientes = value; }
    }

    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public string Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }

    public string Contacto
    {
        get { return _contacto; }
        set { _contacto = value; }
    }
    #endregion 

    #region METODOS GENERALES PARA EL MANEJO DE DATOS
    public List<ClsClientes> ConvertTableToList(DataTable dttD)
    {
        List<ClsClientes> lstClientes = new List<ClsClientes>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsClientes objCliente = new ClsClientes();
            objCliente.Idclientes = int.Parse(registro["idcliente"].ToString());
            objCliente.Nombre = registro["cliente"].ToString();
            objCliente.Direccion = registro["direccion"].ToString();
            objCliente.Contacto = registro["contacto"].ToString();
            
            lstClientes.Add(objCliente);
        }
        return lstClientes;
    }
    
    #endregion

    #region ACCESO A BASE DE DATOS
    
    public string SeleccionaDatos()
    {
        List<ClsClientes> lsClientes = null;
        string sentencia = "SELECT * FROM clientes";
        lsClientes = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Clientes"));
        string datos = JsonConvert.SerializeObject(lsClientes);
        return datos;
    }
    
    public string SeleccionaDatos(string dato)
    { return null; }

    public DataTable SeleccionaDato()
    {
        DataTable lsClientes = new DataTable();
        string sentencia = "SELECT * FROM clientes WHERE idcliente = @idclientes";
        SqlParameter[] parametros = {
                                        new SqlParameter("idclientes",SqlDbType.Int,50)
                                    };
        Object[] valores = { _idclientes };
        lsClientes = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Clientes");
        return lsClientes;
    }
    
    public DataTable ValidaUsuario()
    { return null; }
    
    public bool Existe()
    { return false; }

    public bool InsertaDatos()
    {
        bool valido = false;
        string comando = "INSERT INTO clientes(cliente,direccion,contacto) VALUES (@cliente,@direccion,@contacto)";
        SqlParameter[] parametros ={
                                       new SqlParameter("cliente",SqlDbType.NVarChar,50)
                                       , new SqlParameter("direccion",SqlDbType.NVarChar,50)
                                       , new SqlParameter("contacto",SqlDbType.NVarChar,50)
                                   };
        Object[] valores = { _nombre, _direccion, _contacto };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if(n > 0)
            valido = true;
        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE clientes SET cliente = @nombre, direccion = @direccion, contacto = @contacto WHERE idcliente = @idclientes";
        SqlParameter[] parametros = {
                                       new SqlParameter("idclientes",SqlDbType.Int,50)
                                       ,new SqlParameter("nombre",SqlDbType.NVarChar,50)
                                       , new SqlParameter("direccion",SqlDbType.NVarChar,50)
                                       , new SqlParameter("contacto", SqlDbType.NVarChar,50)
                                   };
        Object[] valores = { _idclientes, _nombre, _direccion, _contacto };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }

    public bool ActualizaPago()
    { return false; }

    public bool EliminaDatos()
    {
        bool valido = false;
        string comando = "DELETE FROM clientes WHERE idcliente = @idclientes";
        SqlParameter[] parametros = {
                                        new SqlParameter("idclientes",SqlDbType.Int,50)
                                    };
        Object[] valores = { _idclientes };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;
        return valido;
    }
     
    #endregion
}