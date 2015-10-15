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

    Public Shared Function getEstadoCombo() As List(Of BE.Estado)
        Dim lista As New List(Of BE.Estado)
        Dim ob As New BE.Estado(1, "Activo")
        lista.Add(ob)
        ob = New BE.Estado(0, "Inactivo")
        lista.Add(ob)
        ob = New BE.Estado(-1, "Todos")
        lista.Add(ob)
        Return lista
    End Function

    Public Shared Function getCantidadCombo() As List(Of BE.Estado)
        Dim lista As New List(Of BE.Estado)
        Dim ob As New BE.Estado(1, "1")
        lista.Add(ob)
        ob = New BE.Estado(2, "2")
        lista.Add(ob)
        ob = New BE.Estado(3, "3")
        lista.Add(ob)
        ob = New BE.Estado(4, "4")
        lista.Add(ob)
        ob = New BE.Estado(5, "5")
        lista.Add(ob)
        Return lista
    End Function
End Class ' Util
