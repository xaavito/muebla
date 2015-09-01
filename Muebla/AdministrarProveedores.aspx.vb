Public Class AdministrarProveedores
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub editarProveedor(sender As Object, e As EventArgs)
        Response.Redirect("EditarProveedor.aspx")
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)

    End Sub
End Class