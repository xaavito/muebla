Public Class AdministrarProveedores
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub editarProveedor(sender As Object, e As EventArgs)
        Response.Redirect("EditarProveedor.aspx")
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub proveedoresResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.proveedoresResultadosDataGrid)
    End Sub

    Protected Sub proveedoresResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.proveedoresResultadosDataGrid.PageIndex = e.NewPageIndex
        buscar()
    End Sub

    Private Sub buscar()
        Throw New NotImplementedException
    End Sub

End Class