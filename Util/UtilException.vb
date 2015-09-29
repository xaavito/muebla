
Public Class RestauracionExitosaException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.RestauracionExitosa
        Me.tipo = Enumeradores.ImportanciaEvento.Info
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class MailEnviadoseException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.MailEnviandose
        Me.tipo = Enumeradores.ImportanciaEvento.Info
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class MailFalloException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Sin resultados")
        Me.codigo = Enumeradores.Excepeciones.MailFallo
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Sin resultados"
    End Sub
End Class

Public Class ErrorBizarroException
    Inherits ExceptionManager

    Public Sub New()
        MyBase.New("Error Bizarro")
        Me.codigo = Enumeradores.Excepeciones.ErrorBizarro
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Error Bizarro!"
    End Sub
End Class