Public Class Carrito
    Inherits ExtendedPage
    Dim carrito As List(Of BE.ListaPrecioDetalleBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.detalleCarritoResultGrid.DataSource = Session("carrito")
        Me.detalleCarritoResultGrid.DataBind()
    End Sub

    Protected Sub comprar_Click(sender As Object, e As EventArgs)
        Dim pedido As New BE.PedidoBE
        pedido.productos = New List(Of BE.PedidoProductoBE)

        For Each prod As ListViewDataItem In Me.lvProductos.Items
            Dim lpd As New BE.ListaPrecioDetalleBE

            Debug.WriteLine("Cantidad " + CType(prod.FindControl("cantidad"), DropDownList).SelectedValue)
            Debug.WriteLine("Lista Precio Detalle ID " + CType(prod.FindControl("listaPrecioDetalleId"), Label).Text)
        Next
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnEditDetail_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDetailsDetail_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub detalleCarritoResultGrid_PreRender(sender As Object, e As EventArgs)

    End Sub

    Protected Sub detalleCarritoResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

    End Sub
End Class