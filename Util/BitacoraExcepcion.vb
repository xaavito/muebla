Public Class BitacoraNoEncontradaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("")
        Me.codigo = Enumeradores.Excepeciones.BitacoraNoEncontrada
        Me.tipo = MsgBoxStyle.Information
        Me.mensaje = ""
    End Sub
End Class

Public Class EliminarBitacoraExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.EliminarBitacora
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class

Public Class ModificacionDeBitacoraExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.ModificacionDeBitacora
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class
