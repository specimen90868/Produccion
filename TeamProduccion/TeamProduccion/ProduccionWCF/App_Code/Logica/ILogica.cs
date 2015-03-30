using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ILogica
/// </summary>
interface ILogica
{
    dynamic ObjDatos { set; }
    string SeleccionaDatos();
    string SeleccionaDatos(string dato);
    DataTable SeleccionaDato();
    DataTable ValidaUsuario();
    bool Existe();
    bool InsertaDatos();
    bool ActualizaDatos();
    bool ActualizaPago();
    bool EliminaDatos();
}