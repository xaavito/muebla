
Public Class ModificarException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Modificar")
        Me.codigo = Enumeradores.Excepeciones.FalloAlModificar
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Fallo Al Modificar"
    End Sub
End Class

Public Class ModificacionExitosaException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Modificar")
        Me.codigo = Enumeradores.Excepeciones.ExitoAlModificar
        Me.tipo = Enumeradores.ImportanciaEvento.Exito
        Me.mensaje = "Fallo Al Modificar"
    End Sub
End Class

