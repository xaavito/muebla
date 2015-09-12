
Public Class ModificarException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Modificar")
        Me.codigo = Enumeradores.Excepeciones.FalloAlModificar
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Fallo Al Modificar"
    End Sub
End Class

