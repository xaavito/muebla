
Public Class BusquedaSinResultadosException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.BusquedaSinResultados
        Me.tipo = Enumeradores.ImportanciaEvento.Info
        Me.mensaje = "Sin resultados"
    End Sub
End Class

