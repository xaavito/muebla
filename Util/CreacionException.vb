
Public Class CreacionException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Crear")
        Me.codigo = Enumeradores.Excepeciones.FalloAlCrear
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Fallo Al Crear"
    End Sub
End Class

Public Class AltaUsuarioExitosaException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Fallo al Crear")
        Me.codigo = Enumeradores.Excepeciones.ExitoAlCrearUsuario
        Me.tipo = Enumeradores.ImportanciaEvento.Exito
        Me.mensaje = "Fallo Al Crear"
    End Sub
End Class


