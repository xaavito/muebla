Public Class CompradorNoEncontradoExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Comprador No encontrado")
        Me.codigo = Enumeradores.Excepeciones.CompradorNoEncontrado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Comprador No encontrado"
    End Sub
End Class
Public Class CompradorsNoEncontradosExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Comprador No encontrado")
        Me.codigo = Enumeradores.Excepeciones.CompradorsNoEncontrados
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Comprador No encontrado"
    End Sub
End Class

Public Class CompradorCreadoExistosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Comprador C")
        Me.codigo = Enumeradores.Excepeciones.CompradorCreadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Comprador No encontrado"
    End Sub
End Class

Public Class CompradorEliminadoExistosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Comprador C")
        Me.codigo = Enumeradores.Excepeciones.CompradorEliminadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Comprador No encontrado"
    End Sub
End Class

Public Class CompradorModificadoExitosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Comprador C")
        Me.codigo = Enumeradores.Excepeciones.CompradorModificadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Comprador No encontrado"
    End Sub
End Class
