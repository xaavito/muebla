﻿Imports BLL
Imports Util
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub login(sender As Object, e As EventArgs)
        Dim usr As String = Me.usr.Text
        Dim pass As String = Me.pass.Text
        Dim usuario As New BE.UsuarioBE
        usuario = BLL.UsuarioBLL.login(pass, usr)
        If usuario Is Nothing Then

        Else
            Session("Usuario") = usuario
            Response.Redirect("Main.aspx")
        End If

    End Sub
End Class