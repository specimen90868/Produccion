using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de INegocio
/// </summary>
interface INegocio
{
    string MensajeError { get; }

    object EjecutaAdaptador(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion, string nombreTabla);

    int EjecutaComando(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion);

    int EjecutaComandoTrans(List<IDbDataParameter[]> parametros, List<object[]> valores, List<string> sentencia, object tipoEjecucion);
}