using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    #region PROVEEDORES
    [OperationContract]
    string getAllProveedores();

    [OperationContract]
    DataTable getProveedor(string id);

    [OperationContract]
    bool insertProveedor(string datos);

    [OperationContract]
    bool updateProveedor(string datos);

    [OperationContract]
    bool deleteProveedor(string id);
    #endregion

    #region COMPRAS
    [OperationContract]
    string getAllCompras(string dato);

    [OperationContract]
    DataTable getCompra(string id);

    [OperationContract]
    bool insertCompra(string datos);

    [OperationContract]
    bool updateCompra(string datos);

    [OperationContract]
    bool deleteCompra(string id);

    [OperationContract]
    bool updatePago(string datos);
    #endregion

    #region VENTAS
    [OperationContract]
    string getAllVentas();

    [OperationContract]
    DataTable getVenta(string id);

    [OperationContract]
    bool insertVenta(string datos);

    [OperationContract]
    bool updateVenta(string datos);

    [OperationContract]
    bool deleteVenta(string id);
    #endregion

    #region USUARIOS
    [OperationContract]
    string GetUsuarios();

    [OperationContract]
    DataTable GetUsuario(string usuario);

    [OperationContract]
    bool InsertaUsuario(string usuario);

    [OperationContract]
    bool ActualizaUsuario(string usuario);

    [OperationContract]
    bool EliminaUsuario(string usuario);

    [OperationContract]
    DataTable ValidaUsuario(string usuario);
    #endregion

    #region CLIENTES
    [OperationContract]
    string GetClientes();

    [OperationContract]
    DataTable GetCliente(string cliente);

    [OperationContract]
    bool InsertaCliente(string cliente);

    [OperationContract]
    bool ActualizaCliente(string cliente);

    [OperationContract]
    bool EliminaCliente(string cliente);
    #endregion

    #region REPORTES
    [OperationContract]
    List<string> ReporteTop(string datos, int tipo);

    [OperationContract]
    List<string> ReporteConsumoVentas(string datos, int tipo);
    #endregion

    #region INSUMOS
    [OperationContract]
    string GetInsumos();

    [OperationContract]
    DataTable GetInsumo(string insumo);

    [OperationContract]
    bool InsertarInsumo(string insumo);
    #endregion

    #region PRODUCTOS
    [OperationContract]
    string GetProductos();

    [OperationContract]
    string getInsumosProducto(int id);
    #endregion
}