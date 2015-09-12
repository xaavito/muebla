
Public Class CreacionException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Crear")
        Me.codigo = Enumeradores.Excepeciones.FalloAlCrear
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Fallo Al Crear"
    End Sub
End Class

