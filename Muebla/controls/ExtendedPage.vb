﻿Imports Util
Imports BLL

Public Class ExtendedPage
    Inherits System.Web.UI.Page

    Private _idioma As BE.IdiomaBE
    Public Property idioma() As BE.IdiomaBE
        Get
            Return _idioma
        End Get
        Set(ByVal value As BE.IdiomaBE)
            _idioma = value
        End Set
    End Property

    Private _usuario As BE.UsuarioBE
    Public Property usuario() As BE.UsuarioBE
        Get
            Return _usuario
        End Get
        Set(ByVal value As BE.UsuarioBE)
            _usuario = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
    End Sub

    Public Sub logMessage(ByVal ex As Exception)
        Dim messageLogger As Label = CType(Me.Master.FindControl("messageLogger"), Label)
        idioma = New BE.IdiomaBE
        idioma.id = Session("Idioma")
        If (TypeOf ex Is ExceptionManager) Then
            Dim excep = DirectCast(ex, ExceptionManager)
            Try
                messageLogger.Text = BLL.GestorExcepcionesBLL.buscarExcepcion(excep.codigo, idioma.id)
            Catch e As BusquedaSinResultadosException
                messageLogger.Text = e.mensaje
            End Try
        Else
            messageLogger.Text = ex.Message
        End If
    End Sub
End Class
