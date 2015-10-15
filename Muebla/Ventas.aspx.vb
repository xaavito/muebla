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

    Protected Sub cantDropDown_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim drop As DropDownList = DirectCast(sender, DropDownList)
        Debug.WriteLine(drop.SelectedValue)
    End Sub

    Protected Sub btnAgregarAlCarrito_Click(sender As Object, e As ImageClickEventArgs)
        carrito = Session("carrito")
        If carrito Is Nothing Then
            carrito = New List(Of ListaPrecioDetalleBE)
        End If
        Dim ID As Integer = Integer.Parse(getItemId(sender, Me.lvProductos))
        For Each a As ListaPrecioDetalleBE In listaProductos
            If a.producto.id = ID Then
                carrito.Add(a)
                Exit For
            End If
        Next
        getSelectedCantidad(sender, Me.lvProductos)
        'transformar a pedido?????
        Session("carrito") = carrito

    End Sub

    Public Function getSelectedCantidad(sender As Object, listView As ListView) As Integer
        Try
            Dim listItem As ListViewItem = CType(CType(sender, ImageButton).NamingContainer, ListViewItem)
            Dim con As DropDownList = CType(listItem.FindControl("cantDropDown"), DropDownList)
            Dim cantidad As Integer = Integer.Parse(con.SelectedValue)
            Return cantidad
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Function
End Class