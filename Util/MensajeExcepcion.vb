Public Class NoHayMensajesExcepcion
    Inherits ExceptionManager
    Public Sub New()
        MyBase.new("Usuario No encontrado")
        Me.codigo = Enumeradores.Excepeciones.MensajeNoEncontrado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class

Public Class EliminarMensajeControlExcepcion
    Inherits ExceptionManager
    Public Sub New()
        MyBase.new("Usuario No encontrado")
        Me.codigo = Enumeradores.Excepeciones.EliminarMensajeControl
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class

Public Class ModificacionDeMensajeControlExcepcion
    Inherits ExceptionManager
    Public Sub New()
        MyBase.new("Usuario No encontrado")
        Me.codigo = Enumeradores.Excepeciones.ModificacionDeMensajeControl
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class
