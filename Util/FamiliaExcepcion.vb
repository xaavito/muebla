Public Class FamiliaNoEncontradaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliaNoEncontrada
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub


End Class

Public Class FamiliasNoEncontradasExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliasNoEncontradas
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub

End Class

Public Class FamiliaCreadaExistosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliasCreadaExitosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub

End Class

Public Class FamiliaEliminadaExitosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliasEliminadaExitosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub

End Class

Public Class FamiliaTieneUsuariosAsociadosExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliaTieneUsuariosAsociados
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub

End Class

Public Class FamiliaModificadaExitosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Familia No encontrada")
        Me.codigo = Enumeradores.Excepeciones.FamiliaModificadaExitosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Familia No encontrada"
    End Sub

End Class
