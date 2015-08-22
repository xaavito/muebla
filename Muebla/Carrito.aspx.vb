Public Class Carrito
    Inherits System.Web.UI.Page
    Dim carrito As List(Of BE.ListaPrecioDetalleBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function buscarSeleccionados() As List(Of BE.ListaPrecioDetalleBE)
        Return DirectCast(Session("carrito"), List(Of BE.ListaPrecioDetalleBE))
    End Function

    Public Sub lvProductos_ItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        carrito = Session("carrito")
        If carrito Is Nothing Then
            carrito = New List(Of BE.ListaPrecioDetalleBE)
        End If
        If (e.CommandName = "removeFromCart") Then
            Dim ID As Int32 = Convert.ToInt32(e.CommandArgument)
            For Each a As BE.ListaPrecioDetalleBE In carrito
                If a.id = ID Then
                    carrito.Remove(a)
                    Exit For
                End If
            Next
        End If
        Session("carrito") = carrito
    End Sub

    Protected Sub comprar_Click(sender As Object, e As EventArgs)
        Dim pedido As New BE.PedidoBE
        pedido.productos = New List(Of BE.ListaPrecioDetalleBE)

        For Each prod As ListViewDataItem In Me.lvProductos.Items
            Dim lpd As New BE.ListaPrecioDetalleBE

            Debug.WriteLine("Cantidad " + CType(prod.FindControl("cantidad"), DropDownList).SelectedValue)
            Debug.WriteLine("Lista Precio Detalle ID " + CType(prod.FindControl("listaPrecioDetalleId"), Label).Text)

        Next

    End Sub
End Class