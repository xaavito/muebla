Public Class UsuarioTienePedidosEnProcesoException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.TienePedidosEnProceso
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class CancelarPedidoException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.NoSePuedeCancelarPedidoEstado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class CuitExistenteException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.CuitExistente
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class ProveedorProductosEnVentaException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.ProveedorProductosEnVenta
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class ProductosEnStockException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.ProveedorProductosEnStock
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class


Public Class MailYaEstaSiendoUtilizadoException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.MailYaEstaUtilizado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class UsuarioYaEstaSiendoUtilizadoException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.UsuarioYaEstaUtilizado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class SeleccionMultiple
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.MasDeUnaSeleccion
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class PedidoPersonalizadoExitosoException
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.PedidoPersonalizado
        Me.tipo = Enumeradores.ImportanciaEvento.Exito
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class ProveedorInactivo
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.ProveedorInactivo
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class ProveedorDeudor
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.ProveedorDeudor
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class PedidoNoFacturado
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.PedidoNoFacturado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class PedidoNoFinalizado
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.PedidoNoFinalizado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class PedidoFacturado
    Inherits ExceptionManager
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.PedidoFacturado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class