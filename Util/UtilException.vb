
Public Class RestauracionExitosaException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.RestauracionExitosa
        Me.tipo = Enumeradores.ImportanciaEvento.Info
        Me.mensaje = "Sin resultados"
    End Sub
End Class

