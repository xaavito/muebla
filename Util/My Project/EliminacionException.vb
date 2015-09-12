Public Class EliminacionException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al eliminar")
        Me.codigo = Enumeradores.Excepeciones.FalloAlEliminar
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Fallo Al Eliminar"
    End Sub
End Class

