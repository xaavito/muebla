Public Class UsuarioTienePedidosEnProcesoException
    Inherits ExceptionManager
    'TODO
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.TienePedidosEnProceso
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class CancelarPedidoException
    Inherits ExceptionManager
    'TODO
    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.NoSePuedeCancelarPedidoEstado
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class