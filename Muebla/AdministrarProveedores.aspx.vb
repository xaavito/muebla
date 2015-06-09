Public Class AdministrarProveedores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub editarProveedor(sender As Object, e As EventArgs)
        Response.Redirect("EditarProveedor.aspx")
    End Sub
End Class