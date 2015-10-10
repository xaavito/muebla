Imports BLL
Imports BE
Public Class Ventas
    Inherits ExtendedPage

    Dim listaProductos As New List(Of ListaPrecioDetalleBE)

    Dim carrito As List(Of ListaPrecioDetalleBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            listaProductos = BLL.ProductoBLL.listarProductos()
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Public Function listarProductos() As List(Of BE.ListaPrecioDetalleBE)
        Return listaProductos
    End Function

    Public Sub lvProductos_ItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        carrito = Session("carrito")
        If carrito Is Nothing Then
            carrito = New List(Of ListaPrecioDetalleBE)
        End If
        If (e.CommandName = "addToCart") Then
            Dim ID As Int32 = Convert.ToInt32(e.CommandArgument)
            For Each a As ListaPrecioDetalleBE In listaProductos
                If a.producto.id = ID Then
                    carrito.Add(a)
                End If
            Next
        End If
        Session("carrito") = carrito
    End Sub

End Class