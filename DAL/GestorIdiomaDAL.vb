Imports BE
Imports Util


Public Class GestorIdiomaDAL


    Public Shared Sub altaIdioma(ByVal componentes As ComponenteBE, ByVal idioma As String)

    End Sub

    Public Shared Function buscarComponentes() As List(Of ComponenteBE)
        buscarComponentes = Nothing
    End Function

    Public Shared Function buscarComponentes(ByVal idioma As BE.IdiomaBE) As List(Of ComponenteBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.ComponenteBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_IDIOMA_COMPONENTE_SP")
            repository.addParam("@idioma", idioma.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim componente As New BE.ComponenteBE
                componente.id = pepe.Item(0)
                componente.nombre = pepe.Item(1)
                componente.texto = pepe.Item(2)
                If Not IsDBNull(pepe.Item(4)) Then
                    componente.formulario = pepe.Item(4)
                End If

                componentes.Add(componente)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

    Public Shared Function buscarIdiomas() As List(Of IdiomaBE)
        Dim table As DataTable
        Dim idiomas As New List(Of BE.IdiomaBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_IDIOMAS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            For Each pepe As DataRow In table.Rows
                Dim idioma As New BE.IdiomaBE
                idioma.id = pepe.Item(0)
                idioma.descripcion = pepe.Item(1)
                idiomas.Add(idioma)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return idiomas
    End Function

    Public Shared Sub modificarIdioma(ByVal idioma As IdiomaBE)

    End Sub

    Shared Function getTranslation(p1 As String, p2 As Integer) As String
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_TRADUCCION_SP")
            repository.addParam("@comp", p1)
            repository.addParam("@idioma", p2)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            Dim componentes As New List(Of BE.ComponenteBE)
            For Each pepe As DataRow In table.Rows
                Dim traduccion As String
                traduccion = pepe.Item(0)

                Return traduccion
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return Nothing
    End Function

    Shared Sub modificarComponente(id As Integer, nuevoTexto As String, idIdioma As Integer)
        Dim ret As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_TRADUCCION_SP")
            repository.addParam("@id", id)
            repository.addParam("@texto", nuevoTexto)
            repository.addParam("@idIdioma", idIdioma)
            ret = repository.executeSearchWithStatus
            If (ret <> 1) Then
                Throw New Util.ModificarException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class ' GestorIdiomaDAL

