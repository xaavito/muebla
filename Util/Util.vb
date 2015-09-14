Imports System.Globalization

Public Class Util


    Public Function checkDigVerif() As Boolean
        checkDigVerif = False
    End Function

    Public Sub generarDigitosVerif()

    End Sub

    Public Shared Function getDate(ByVal fecha As String) As Date
        Try
            Return Date.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture)
        Catch ex As Exception
            Return Date.ParseExact("01/01/2500", "dd/MM/yyyy", CultureInfo.InvariantCulture)
        End Try
    End Function


End Class ' Util
