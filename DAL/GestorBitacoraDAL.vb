
Imports BE
Imports Util


Public Class GestorBitacoraDAL


    Public Shared Sub buscarBitacoras(ByVal hasta As DateTime, ByVal desde As DateTime, ByVal usr As UsuarioBE, ByVal tipo As Integer)

    End Sub

    Public Shared Sub registrarEvento(ByVal usuario As UsuarioBE, ByVal evento As Integer)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_LOG_SP")
            repository.addParam("@usr", usuario.id)
            repository.addParam("@evento", evento)
            id = repository.executeWithReturnValue
            If id <= 0 Then
                Throw New CreacionException
            End If
        Catch ex As Exception
            Throw New CreacionException
        End Try
    End Sub


End Class

