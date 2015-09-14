
Imports BE
Imports Util


Public Class GestorBitacoraDAL


    Public Shared Function buscarBitacoras(ByVal hasta As Date, ByVal desde As Date, ByVal usr As String, ByVal tipo As Integer, ByVal id As Integer) As List(Of BE.EventoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.EventoBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_BITACORAS_SP")
            repository.addParam("@desde", desde)
            repository.addParam("@hasta", hasta)
            repository.addParam("@usr", usr)
            repository.addParam("@tipo", tipo)
            repository.addParam("@idioma", id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim evento As New BE.EventoBE
                evento.id = pepe.Item(0)
                evento.descripcion = pepe.Item(1)
                Dim usuario As New BE.UsuarioBE
                usuario.id = pepe.Item(2)
                usuario.usuario = pepe.Item(3)
                evento.usr = usuario

                Dim tipoeven As New BE.TipoEventoBE
                tipoeven.id = pepe.Item(4)
                tipoeven.texto = pepe.Item(5)
                tipoeven.codigo = pepe.Item(6)
                evento.tipoEvento = tipoeven

                evento.fecha = pepe.Item(7)
                componentes.Add(evento)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

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

    Shared Function getTipoEventos(ByVal id As Integer) As List(Of BE.TipoEventoBE)
        Dim table As DataTable
        Dim tipos As New List(Of BE.TipoEventoBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_TIPO_EVENTOS_SP")
            repository.addParam("@id", id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                'Throw New Excepciones.UsuarioNoEncontradoExcepcion
            End If

            For Each pepe As DataRow In table.Rows
                Dim tipo As New BE.TipoEventoBE
                tipo.id = pepe.Item(0)
                tipo.texto = pepe.Item(1)
                tipo.codigo = pepe.Item(2)
                tipos.Add(tipo)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return tipos
    End Function


End Class

