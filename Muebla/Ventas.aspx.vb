Imports BLL
Imports BE
Public Class Ventas

    Inherits System.Web.UI.Page

    Dim listaProductos As New List(Of ProductoBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listaProductos = BLL.ProductoBLL.listarProductos()
    End Sub

    Public Function listarProductos() As List(Of BE.ProductoBE)
        Return BLL.ProductoBLL.listarProductos()
    End Function
   
End Class