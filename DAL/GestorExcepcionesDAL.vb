Imports Util

Public Class GestorExcepcionesDAL

    Shared Function buscarExcepcion(codigo As Integer, idIdioma As Integer) As String
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_EXCEPCION_SP")
            repository.addParam("@cod", codigo)
            repository.addParam("@idioma", idIdioma)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Return pepe.Item(0)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing
    End Function

End Class
