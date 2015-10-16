Imports BE

Public Class GestorIdiomaBLL
    Private Shared _comps As List(Of BE.IdiomaBE)

    Public Shared Sub altaIdioma(ByVal componentes As ComponenteBE, ByVal idioma As String)

    End Sub

    Public Shared Function buscarComponentes() As List(Of ComponenteBE)
        buscarComponentes = Nothing
    End Function

    Public Shared Function buscarComponentes(ByVal idioma As BE.IdiomaBE) As List(Of ComponenteBE)
        If idioma.id = 0 Then
            Return Nothing
        End If
        For Each id As BE.IdiomaBE In getComponentesIdiomaticos()
            If id.id = idioma.id Then
                Return id.componentes
            End If
        Next
        Dim nuevoIdioma = New BE.IdiomaBE
        nuevoIdioma.id = idioma.id
        Try
            nuevoIdioma.componentes = DAL.GestorIdiomaDAL.buscarComponentes(nuevoIdioma)
            _comps.Add(nuevoIdioma)
        Catch ex As Exception
            Throw New Exception
        End Try

        Return nuevoIdioma.componentes
    End Function

    Public Shared Function buscarIdiomas() As List(Of IdiomaBE)
        Return DAL.GestorIdiomaDAL.buscarIdiomas
    End Function

    Public Shared Sub modificarIdioma(ByVal idioma As IdiomaBE)

    End Sub

    Shared Function getTranslation(textoATraducir As String, idIdioma As Integer) As String
        Try
            Dim idAbuscar As Integer
            For Each id As BE.IdiomaBE In getComponentesIdiomaticos()
                If idIdioma <> id.id Then
                    For Each comp As BE.ComponenteBE In id.componentes
                        If comp.texto = textoATraducir Then
                            idAbuscar = comp.id
                        End If
                    Next
                End If
            Next
            For Each id As BE.IdiomaBE In getComponentesIdiomaticos()
                If idIdioma = id.id Then
                    For Each comp As BE.ComponenteBE In id.componentes
                        If comp.id = idAbuscar Then
                            Return comp.texto
                        End If
                    Next
                End If
            Next

            Return DAL.GestorIdiomaDAL.getTranslation(textoATraducir, idIdioma)
        Catch ex As Util.BusquedaSinResultadosException
            Return Nothing
        End Try
        
    End Function

    Shared Function getComponentesIdiomaticos()
        If _comps Is Nothing Then
            _comps = New List(Of IdiomaBE)
        End If
        Return _comps
    End Function

    Shared Sub modificarComponente(id As Integer, nuevoTexto As String, idIdioma As Integer)
        DAL.GestorIdiomaDAL.modificarComponente(id, nuevoTexto, idIdioma)
        _comps = New List(Of IdiomaBE)
    End Sub

End Class
