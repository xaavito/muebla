Public Class PermisoNoEncontradoExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Permiso/s no encontrados")
        Me.codigo = Enumeradores.Excepeciones.PermisoNoEncontrado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Permiso/s no encontrados"
    End Sub
End Class


Public Class AsociacionDePermisosExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Permiso/s no encontrados")
        Me.codigo = Enumeradores.Excepeciones.PermisoNoAsociado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Permiso/s no encontrados"
    End Sub
End Class

Public Class AsociacionDePermisosExitosa
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Permiso/s no encontrados")
        Me.codigo = Enumeradores.Excepeciones.PermisoAsociadoExitosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Permiso/s no encontrados"
    End Sub
End Class