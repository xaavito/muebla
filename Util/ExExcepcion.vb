Public Class ExcepcionNoEncontradaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Excepcion no encontrada")
        Me.codigo = Enumeradores.Excepeciones.MensajeExcepcion
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Excepcion no encontrada"
    End Sub
End Class

Public Class EliminarExcepcionExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Excepcion no encontrada")
        Me.codigo = Enumeradores.Excepeciones.EliminarExcepcion
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Excepcion no encontrada"
    End Sub
End Class

Public Class ModificacionDeExcepcionExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Excepcion no encontrada")
        Me.codigo = Enumeradores.Excepeciones.ModificacionDeExcepcion
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Excepcion no encontrada"
    End Sub
End Class
