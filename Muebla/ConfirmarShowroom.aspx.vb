Public Class ConfirmarShowroom
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub asignar(sender As Object, e As EventArgs)
        Response.Redirect("AsignarShowroom.aspx")
    End Sub
End Class