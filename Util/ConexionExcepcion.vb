Public Class ConexionImposibleExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Conexion a la BD de datos no lograda!")
        Me.codigo = Enumeradores.Excepeciones.ConexionBDFallida
        Me.tipo = Enumeradores.ImportanciaEvento.Err
        Me.mensaje = "Conexion a la BD de datos no lograda!"
    End Sub
End Class
