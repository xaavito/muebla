Public Class AdministrarIdiomas
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub idiomaResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.idiomaResultadosDataGrid)
    End Sub

    Protected Sub idiomaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class