﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Newtonsoft.Json;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    #region METODOS DE PROVEEDORES
    public string getAllProveedores()
    {
        ClsProveedores objDatos = new ClsProveedores();
        string allProveedores = objDatos.SeleccionaDatos();
        return allProveedores;
    }

    public DataTable getProveedor(string id)
    {
        DataTable dttDato = new DataTable();
        ClsProveedores objDato;
        objDato = JsonConvert.DeserializeObject<ClsProveedores>(id);
        dttDato = objDato.SeleccionaDato();
        return dttDato;
    }

    public bool insertProveedor(string datos)
    {
        ClsProveedores objDato;
        objDato = JsonConvert.DeserializeObject<ClsProveedores>(datos);
        bool valido = objDato.InsertaDatos();
        return valido;
    }

    public bool updateProveedor(string datos)
    {
        ClsProveedores objDato;
        objDato = JsonConvert.DeserializeObject<ClsProveedores>(datos);
        bool valido = objDato.ActualizaDatos();
        return valido;
    }

    public bool deleteProveedor(string id)
    {
        ClsProveedores objDato;
        objDato = JsonConvert.DeserializeObject<ClsProveedores>(id);
        bool valido = objDato.EliminaDatos();
        return valido;
    }
    #endregion

    #region METODOS DE COMPRAS
    public string getAllCompras(string dato)
    {
        ClsCompras objDatos = new ClsCompras();
        string allCompras = objDatos.SeleccionaDatos(dato);
        return allCompras;
    }

    public DataTable getCompra(string id)
    {
        DataTable dttDato = new DataTable();
        ClsCompras objDato;
        objDato = JsonConvert.DeserializeObject<ClsCompras>(id);
        dttDato = objDato.SeleccionaDato();
        return dttDato;
    }

    public bool insertCompra(string datos)
    {
        ClsCompras objDato;
        objDato = JsonConvert.DeserializeObject<ClsCompras>(datos);
        bool valido = objDato.InsertaDatos();
        return valido;
    }

    public bool updateCompra(string datos)
    {
        ClsCompras objDato;
        objDato = JsonConvert.DeserializeObject<ClsCompras>(datos);
        bool valido = objDato.ActualizaDatos();
        return valido;
    }

    public bool deleteCompra(string id)
    {
        ClsCompras objDato;
        objDato = JsonConvert.DeserializeObject<ClsCompras>(id);
        bool valido = objDato.EliminaDatos();
        return valido;
    }

    public bool updatePago(string datos)
    {
        ClsCompras objDato;
        objDato = JsonConvert.DeserializeObject<ClsCompras>(datos);
        bool valido = objDato.ActualizaPago();
        return valido;
    }

    public bool updateExistencia(string datos)
    {
        ClsInsumos objDato;
        objDato = JsonConvert.DeserializeObject<ClsInsumos>(datos);
        bool valido = objDato.Existe();
        return valido;
    }
    #endregion

    #region METODOS DE VENTAS
    public string getAllVentas()
    {
        ClsVentas objDatos = new ClsVentas();
        string allVentas = objDatos.SeleccionaDatos();
        return allVentas;
    }

    public DataTable getVenta(string id)
    {
        DataTable dttDato = new DataTable();
        ClsVentas objDato;
        objDato = JsonConvert.DeserializeObject<ClsVentas>(id);
        dttDato = objDato.SeleccionaDato();
        return dttDato;
    }

    public bool insertVenta(string datos)
    {
        ClsVentas objDato;
        objDato = JsonConvert.DeserializeObject<ClsVentas>(datos);
        bool valido = objDato.InsertaDatos();
        return valido;
    }

    public bool updateVenta(string datos)
    {
        ClsVentas objDato;
        objDato = JsonConvert.DeserializeObject<ClsVentas>(datos);
        bool valido = objDato.ActualizaDatos();
        return valido;
    }

    public bool deleteVenta(string id)
    {
        ClsVentas objDato;
        objDato = JsonConvert.DeserializeObject<ClsVentas>(id);
        bool valido = objDato.EliminaDatos();
        return valido;
    }
    #endregion

    #region METODOS USUARIOS
    public string GetUsuarios()
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        string datos;
        datos = objUsuario.SeleccionaDatos();
        return datos;

    }

    public DataTable GetUsuario(string usuario)
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        DataTable datos = new DataTable();
        objUsuario = JsonConvert.DeserializeObject<ClsUsuarios>(usuario);
        datos = objUsuario.SeleccionaDato();
        return datos;
    }

    public bool InsertaUsuario(string usuario)
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        objUsuario = JsonConvert.DeserializeObject<ClsUsuarios>(usuario);
        bool valido = objUsuario.InsertaDatos();
        return valido;
    }

    public bool EliminaUsuario(string usuario)
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        objUsuario = JsonConvert.DeserializeObject<ClsUsuarios>(usuario);
        bool valido = objUsuario.EliminaDatos();
        return valido;
    }

    public bool ActualizaUsuario(string usuario)
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        objUsuario = JsonConvert.DeserializeObject<ClsUsuarios>(usuario);
        bool valido = objUsuario.ActualizaDatos();
        return valido;
    }

    public DataTable ValidaUsuario(string usuario)
    {
        ClsUsuarios objUsuario = new ClsUsuarios();
        DataTable dato = new DataTable();
        objUsuario = JsonConvert.DeserializeObject<ClsUsuarios>(usuario);
        dato = objUsuario.ValidaUsuario();

        if (dato != null)
        {
            if (dato.Rows.Count > 0)
            {
                return dato;
            }
        }
        return dato;
    }
    #endregion

    #region METODOS CLIENTES
    public string GetClientes()
    {
        ClsClientes objCliente = new ClsClientes();
        string datos;
        datos = objCliente.SeleccionaDatos();
        return datos;
    }

    public DataTable GetCliente(string cliente)
    {
        ClsClientes objCliente = new ClsClientes();
        DataTable datos = new DataTable();
        objCliente = JsonConvert.DeserializeObject<ClsClientes>(cliente);
        datos = objCliente.SeleccionaDato();
        return datos;
    }

    public bool InsertaCliente(string cliente)
    {
        ClsClientes objCliente = new ClsClientes();
        objCliente = JsonConvert.DeserializeObject<ClsClientes>(cliente);
        bool valido = objCliente.InsertaDatos();
        return valido;
    }

    public bool ActualizaCliente(string cliente)
    {
        ClsClientes objCliente = new ClsClientes();
        objCliente = JsonConvert.DeserializeObject<ClsClientes>(cliente);
        bool valido = objCliente.ActualizaDatos();
        return valido;
    }

    public bool EliminaCliente(string cliente)
    {
        ClsClientes objCliente = new ClsClientes();
        objCliente = JsonConvert.DeserializeObject<ClsClientes>(cliente);
        bool valido = objCliente.EliminaDatos();
        return valido;
    }
    #endregion

    #region METODOS REPORTES
    public List<string> ReporteTop(string datos,int tipo)
    {
        ClsReportes objDato;
        objDato = JsonConvert.DeserializeObject<ClsReportes>(datos);
        List<string> data = new List<string>();
        switch (tipo)
        {
                //COMPRAS
            case 0:
                data = objDato.SeleccionaDatosTopCompras();
                break;
                //VENTAS
            case 1:
                data = objDato.SeleccionaDatosTopVentas();
                break;

        }
        return data;
    }

    public List<string> ReporteConsumoVentas(string datos, int tipo)
    {
        ClsReportes objDato;
        objDato = JsonConvert.DeserializeObject<ClsReportes>(datos);
        List<string> data = new List<string>();
        switch (tipo)
        {
            //COMPRAS
            case 0:
                data = objDato.SeleccionaDatosConsumo();
                break;
            //VENTAS
            case 1:
                data = objDato.SeleccionaDatosVentas();
                break;

        }
        return data;
    }
    #endregion

    #region METODOS DE INSUMOS
    public string GetInsumos()
    {
        ClsInsumos objInsumos = new ClsInsumos();
        string datos;
        datos = objInsumos.SeleccionaDatos();
        return datos;

    }
    public DataTable GetInsumo(string usuario)
    {
        ClsInsumos objInsumo = new ClsInsumos();
        DataTable datos = new DataTable();
        objInsumo = JsonConvert.DeserializeObject<ClsInsumos>(usuario);
        datos = objInsumo.SeleccionaDato();
        return datos;
    }

    public bool InsertarInsumo(string insumo)
    {
        ClsInsumos objInsumos = new ClsInsumos();
        objInsumos = JsonConvert.DeserializeObject<ClsInsumos>(insumo);
        bool valido = objInsumos.InsertaDatos();
        return valido;
    }

    public bool ActualizaInsumo(string insumo)
    {
        ClsInsumos objInsumos = new ClsInsumos();
        objInsumos = JsonConvert.DeserializeObject<ClsInsumos>(insumo);
        bool valido = objInsumos.ActualizaDatos();
        return valido;
    }
    #endregion

    #region METODOS DE PRODUCTOS
    public string GetProductos()
    {
        ClsProducto objProductos = new ClsProducto();
        string datos = objProductos.SeleccionaDatos();
        return datos;
    }

    public DataTable GetProducto(string dato)
    {
        ClsProducto objProducto = new ClsProducto();
        DataTable datos = new DataTable();
        objProducto = JsonConvert.DeserializeObject<ClsProducto>(dato);
        datos = objProducto.SeleccionaDato();
        return datos;
    }

    public string getInsumosProducto(int id) {
        ClsInsumos i = new ClsInsumos();
        return i.SeleccionaDatos(id.ToString());
    }

    public bool InsertProducto(string datos)
    {
        ClsProducto objProductos = new ClsProducto();
        objProductos = JsonConvert.DeserializeObject<ClsProducto>(datos);
        bool valido = objProductos.InsertaDatos();
        return valido;
    }

    public bool UpdateProducto(string datos)
    {
        ClsProducto objProductos = new ClsProducto();
        objProductos = JsonConvert.DeserializeObject<ClsProducto>(datos);
        bool valido = objProductos.ActualizaDatos();
        return valido;
    }

    public bool DeleteProducto(string dato)
    {
        ClsProducto objProductos = new ClsProducto();
        objProductos = JsonConvert.DeserializeObject<ClsProducto>(dato);
        bool valido = objProductos.EliminaDatos();
        return valido;
    }

    public string ProductoInsumos(string dato)
    {
        ClsProductoInsumo objProductoInsumo = new ClsProductoInsumo();
        objProductoInsumo = JsonConvert.DeserializeObject<ClsProductoInsumo>(dato);
        string datos = objProductoInsumo.SeleccionaDatos();
        return datos;
    }

    public bool InsertProductoInsumos(string lstDatos)
    {
        bool valido = false;
        ClsProductoInsumo objProductoInsumo = new ClsProductoInsumo();
        List<ClsProductoInsumo> lstProdInsumos = JsonConvert.DeserializeObject<List<ClsProductoInsumo>>(lstDatos);
        for (int i = 0; i < lstProdInsumos.Count; i++)
        {
            objProductoInsumo.IdProducto = lstProdInsumos[i].IdProducto;
            objProductoInsumo.IdInsumo = lstProdInsumos[i].IdInsumo;
            objProductoInsumo.Cantidad = lstProdInsumos[i].Cantidad;
            valido = objProductoInsumo.InsertaDatos();
        }
        return valido;
    }

    public bool DeleteProductoInsumos(string dato)
    {
        ClsProductoInsumo objProdInsumo = new ClsProductoInsumo();
        objProdInsumo = JsonConvert.DeserializeObject<ClsProductoInsumo>(dato);
        bool valido = objProdInsumo.EliminaDatos();
        return valido;
    }
    #endregion
}
