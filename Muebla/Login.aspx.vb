﻿Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub login(sender As Object, e As EventArgs)
        Response.Redirect("Main.aspx")
    End Sub
End Class