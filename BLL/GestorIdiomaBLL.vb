Imports BE
Imports System.Web.Configuration

Public Class GestorIdiomaBLL
    Private Shared _comps As List(Of BE.IdiomaBE)

    Public Shared Sub altaIdioma(ByVal usr As BE.UsuarioBE, ByVal idioma As String)
        DAL.GestorIdiomaDAL.altaIdioma(idioma)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.AltaIdioma)
    End Sub

    Public Shared Function buscarComponentes(ByVal idioma As BE.IdiomaBE) As List(Of ComponenteBE)
        If idioma.id = 0 Then
            Return Nothing
        End If

        'If WebConfigurationManager.AppSettings("cacheIdioma").ToString().Equals("true") Then
        For Each id As BE.IdiomaBE In getComponentesIdiomaticos()
            If id.id = idioma.id Then
                Return id.componentes
            End If
        Next
        'End If

        Dim nuevoIdioma = New BE.IdiomaBE
        nuevoIdioma.id = idioma.id
        Try
            nuevoIdioma.componentes = DAL.GestorIdiomaDAL.buscarComponentes(nuevoIdioma)
            _comps.Add(nuevoIdioma)
        Catch ex As Exception
            Throw ex
        End Try

        Return nuevoIdioma.componentes
    End Function

    Public Shared Function buscarIdiomas() As List(Of IdiomaBE)
        Return DAL.GestorIdiomaDAL.buscarIdiomas
    End Function

    Shared Function getTranslation(textoATraducir As String, idIdioma As Integer) As String
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

        Try
            Return DAL.GestorIdiomaDAL.getTranslation(textoATraducir, idIdioma)
        Catch ex As Util.BusquedaSinResultadosException
            Return textoATraducir
        End Try
    End Function

    Shared Function getMensajeTraduccion(codigo As Util.Enumeradores.CodigoMensaje, idIdioma As Integer) As String
        Return DAL.GestorIdiomaDAL.getMensajeTraducion(codigo, idIdioma)
    End Function

    Shared Function getMensajeTraduccion(codigo As Util.Enumeradores.CodigoMensaje) As String
        Return DAL.GestorIdiomaDAL.getMensajeTraducion(codigo, 1)
    End Function

    Shared Function getComponentesIdiomaticos()
        If _comps Is Nothing Then
            _comps = New List(Of IdiomaBE)
        End If
        Return _comps
    End Function

    Shared Sub modificarComponente(ByVal usr As BE.UsuarioBE, id As Integer, nuevoTexto As String, idIdioma As Integer)
        DAL.GestorIdiomaDAL.modificarComponente(id, nuevoTexto, idIdioma)
        _comps = New List(Of IdiomaBE)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.ModificacionIdioma)
    End Sub

    Shared Function buscarMensajes(idioma As IdiomaBE) As List(Of MensajeBE)
        If idioma.id = 0 Then
            Return Nothing
        End If
        For Each id As BE.IdiomaBE In getComponentesIdiomaticos()
            If id.id = idioma.id Then
                Return id.mensajes
            End If
        Next
        Dim nuevoIdioma = New BE.IdiomaBE
        nuevoIdioma.id = idioma.id
        Try
            nuevoIdioma.mensajes = DAL.GestorIdiomaDAL.buscarMensajes(nuevoIdioma)
            _comps.Add(nuevoIdioma)
        Catch ex As Exception
            Throw ex
        End Try

        Return nuevoIdioma.mensajes
    End Function

End Class
