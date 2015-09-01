Public Class UsuarioNoEncontradoExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Usuario No encontrado")
        Me.codigo = Enumeradores.Excepeciones.UsuarioNoEncontrado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class
Public Class UsuariosNoEncontradosExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Usuario No encontrado")
        Me.codigo = Enumeradores.Excepeciones.UsuariosNoEncontrados
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class

Public Class UsuarioCreadoExistosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Usuario C")
        Me.codigo = Enumeradores.Excepeciones.UsuarioCreadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class

Public Class UsuarioEliminadoExistosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Usuario C")
        Me.codigo = Enumeradores.Excepeciones.UsuarioEliminadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class

Public Class UsuarioModificadoExitosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Usuario C")
        Me.codigo = Enumeradores.Excepeciones.UsuarioModificadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Usuario No encontrado"
    End Sub
End Class
