Public Class InsertExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Insert Failureee")
        Me.codigo = Enumeradores.Excepeciones.FalloInsert
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Insert Failureee"
    End Sub
End Class

Public Class DeleteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Insert Failureee")
        Me.codigo = Enumeradores.Excepeciones.FalloDelete
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Insert Failureee"
    End Sub
End Class

Public Class SearchExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Insert Failureee")
        Me.codigo = Enumeradores.Excepeciones.FalloBuscar
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Insert Failureee"
    End Sub
End Class


Public Class UpdateExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Insert Failureee")
        Me.codigo = Enumeradores.Excepeciones.FalloUpdate
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Insert Failureee"
    End Sub
End Class