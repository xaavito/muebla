Public Class Main
    Inherits ExtendedPage

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.UpdatePanel1.Update()
    End Sub

    Dim listaPromos As New List(Of BE.ListaPrecioDetalleBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            listaPromos = BLL.ProductoBLL.listarPromos()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Public Function listarPromociones() As List(Of BE.ListaPrecioDetalleBE)
        Return listaPromos
    End Function
End Class