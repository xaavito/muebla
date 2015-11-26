Imports BLL
Imports BE

Public Class Ventas
    Inherits ExtendedPage

    Dim listaProductos As New List(Of ListaPrecioDetalleBE)
    Dim carrito As New BE.PedidoBE

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
        Try
            carrito = Session("carrito")
            If carrito Is Nothing Then
                carrito = New BE.PedidoBE
                carrito.usr = getUsuario()
            End If
            Dim ID As Integer = Integer.Parse(getItemId(sender, Me.lvProductos))
            For Each a As ListaPrecioDetalleBE In listaProductos
                If a.id = ID Then
                    carrito.addProducto(a, getSelectedCantidad(sender, Me.lvProductos))
                    Exit For
                End If
            Next
            Session("carrito") = carrito
        Catch ex As Exception
            logMessage(ex)
        End Try
        
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
        Return Nothing
    End Function

    Protected Sub compraPersonalizadaButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("compraPersonalizada.aspx", False)
    End Sub
End Class