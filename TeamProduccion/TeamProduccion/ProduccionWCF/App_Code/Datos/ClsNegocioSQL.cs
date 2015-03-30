using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ClsNegocioSQL
/// </summary>
public class ClsNegocioSQL : ClsDatosSQL, INegocio
{
    #region CONSTRUCTOR
    public ClsNegocioSQL(int tipoAutentica)
        : base(tipoAutentica)
    {

    }
    public ClsNegocioSQL()
        : base(1)
    {
        _servidor = @"localhost\sqlexpress";
        _basedatos = "produccion";
        _usuario = "sa";
        _contrasena = "sql2008";
    }

    public ClsNegocioSQL(string cadena)
        : base(cadena)
    {

    }
    #endregion

    #region PROPIEDADES
    public string MensajeError { get; set; }
    #endregion

    #region METODOS A ACCESO A DATOS

    /*Ejecuta una sentencia Sql, puede ser un query que retorne una serie de datos
        * Retorna: Objeto que es un DataTable, 
        * Recibe:
        * parametros: Conjunto de parámetros que requiere la sentencia o el procedimiento almacenado
        * valores: Conjunto de valores que se requiere asignar a cada parámetro
        * sentencia: Comando T-Sql o nombre del procedimiento almacenado
        * tipoEjecucion: El tipo de comando si es texto o procedimiento almacenado
        * nombreTabla: Asigna el nombre de la tabla a la consulta
        */
    public object EjecutaAdaptador(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion, string nombreTabla)
    {
        DataTable dttDatos = new DataTable();
        try
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = (SqlConnection)Conexion;
            comando.CommandType = (CommandType)tipoEjecucion;
            comando.CommandText = sentencia;
            AsignaParametros(ref comando, (SqlParameter[])parametros);
            AsignaValores(ref comando, valores);
            SqlDataAdapter daDatos = new SqlDataAdapter(comando);
            daDatos.Fill(dttDatos);
            dttDatos.TableName = nombreTabla;
            CierraConexion();
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            dttDatos = null;
        }
        return dttDatos;
    }
    /*Ejecuta una sentencia Sql, no retorna una consulta
  * Retorna: el número de registros que alteró, si retorna -1 hubo un error, 
  * Recibe:
  * parametros: Conjunto de parámetros que requiere la sentencia o el procedimiento almacenado
  * valores: Conjunto de valores que se requiere asignar a cada parámetro
  * sentencia: Comando T-Sql o nombre del procedimiento almacenado
  * tipoEjecucion: El tipo de comando si es texto o procedimiento almacenado
  * nombreTabla: Asigna el nombre de la tabla a la consulta
  */
    public int EjecutaComando(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion)
    {
        int n = -1;
        SqlCommand comando = ((SqlConnection)Conexion).CreateCommand();
        try
        {
            comando.Connection = (SqlConnection)Conexion;
            comando.CommandType = (CommandType)tipoEjecucion;
            comando.CommandText = sentencia;
            AsignaParametros(ref comando, (SqlParameter[])parametros);
            AsignaValores(ref comando, valores);
            n = comando.ExecuteNonQuery();
            CierraConexion();
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            n = -1;
        }
        return n;
    }

    /*Ejecuta una serie de sentencias Sql, no retorna una consulta, en base al manejo de transacciones
* Retorna: si hubo un error -1, o un número >0 si se realizó con éxito,
     * en caso de un error no hay commit, sino rollback, no se realiza ninguna acción
     * Si todo se realizón con éxito hay un commit en la transacción aceptando todos los cambios
* Recibe:
* parametros: Lista de un Conjunto de parámetros que requiere la sentencia o el procedimiento almacenado
* valores:Lista de un Conjunto de valores que se requiere asignar a cada parámetro
* sentencia:Lista de Comandos T-Sql o nombre del procedimiento almacenado
* tipoEjecucion: El tipo de comando si es texto o procedimiento almacenado
* nombreTabla: Asigna el nombre de la tabla a la consulta
*/
    public int EjecutaComandoTrans(List<IDbDataParameter[]> parametros, List<object[]> valores, List<string> sentencia, object tipoEjecucion)
    {
        int n = -1;
        SqlCommand comando = ((SqlConnection)Conexion).CreateCommand();
        SqlTransaction objTransaccion = ((SqlConnection)Conexion).BeginTransaction();
        try
        {
            comando.Connection = (SqlConnection)Conexion;
            comando.Transaction = objTransaccion;
            comando.CommandType = (CommandType)tipoEjecucion;
            int i = 0;
            foreach (string varSentencia in sentencia)
            {
                comando.Parameters.Clear();
                comando.CommandText = varSentencia;

                AsignaParametros(ref comando, (SqlParameter[])parametros[i]);
                AsignaValores(ref comando, valores[i]);
                n = comando.ExecuteNonQuery();
                i++;
            }
            objTransaccion.Commit();
            CierraConexion();
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            n = -1;
            objTransaccion.Rollback();
        }
        return n;
    }


    #endregion

    #region PARÁMETROS Y VALORES
    void AsignaParametros(ref SqlCommand cmdSql, params SqlParameter[] parametros)
    {
        if (parametros != null)
            foreach (SqlParameter par in parametros)
                cmdSql.Parameters.Add(par);

    }

    void AsignaValores(ref SqlCommand cmdSql, params Object[] valores)
    {
        int i = 0;
        if (valores != null)
            foreach (Object val in valores)
                cmdSql.Parameters[i++].Value = val;

    }
    #endregion
}