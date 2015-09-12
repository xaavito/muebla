Imports DAL

Public Class GestorExcepcionesBLL

    Shared Function buscarExcepcion(codigo As Integer, idIdioma As Integer) As String
        Return DAL.GestorExcepcionesDAL.buscarExcepcion(codigo, idIdioma)
    End Function

End Class

