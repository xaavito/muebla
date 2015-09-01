Public Class BackupsNoEncontrados
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.BackupsNoEncontrados
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class FalloAlEliminarBackup
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.FalloAlEliminarBackup
        Me.tipo = MsgBoxStyle.Critical
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class FalloAlCrearBackup
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.FalloAlCrearBackup
        Me.tipo = MsgBoxStyle.Critical
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class RestoreRealizadoExitosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.RestoreRealizadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class FalloAlRealizarRestore
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.FalloAlRealizarRestore
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class BackupRealizadoExitosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.BackupRealizadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class BackupEliminadoExitosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.BackupEliminadoExitosamente
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class