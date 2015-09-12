
Public Class EliminarException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al eliminar")
        Me.codigo = Enumeradores.Excepeciones.FalloAlEliminar
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Fallo Al Eliminar"
    End Sub
End Class

Public Class EliminacionExitosaException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Eliminacion Extiosa")
        Me.codigo = Enumeradores.Excepeciones.ExitoAlEliminar
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Eliminacion Extiosa"
    End Sub
End Class

