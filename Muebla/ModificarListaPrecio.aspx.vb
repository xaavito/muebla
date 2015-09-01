Public Class ModificarListaPrecio
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        Response.Redirect("ModificacionListaPrecio.aspx")
    End Sub
End Class