Imports BE


Public Class ProductoBLL


    ''' 
    ''' <param name="prod"></param>
    ''' <param name="cant"></param>
    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Function altaProducto(ByVal producto As ProductoBE) As Integer
        Return DAL.ProductoDAL.altaProducto(producto)
    End Function

    Public Shared Function bajaProducto(ByVal id As Integer) As Integer
        Return DAL.ProductoDAL.bajaProducto(id)
    End Function

    Public Shared Function buscarProducto(ByVal id As Integer) As BE.ProductoBE
        Return DAL.ProductoDAL.buscarProducto(id)
    End Function

    Public Shared Function buscarProductos(ByVal tipo As Integer, ByVal nombre As String) As List(Of ProductoBE)
        Return DAL.ProductoDAL.buscarProductos(tipo, nombre)
    End Function

    Public Shared Function listarProductos() As List(Of ListaPrecioDetalleBE)
        Return DAL.ProductoDAL.listarProductos()
    End Function

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub compararCosto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub generarOrdenCompra(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub modificarProducto(ByVal producto As ProductoBE)

    End Sub

    Shared Function getImagenProducto(idInt As Integer) As Byte()
        Return DAL.ProductoDAL.getImagenProducto(idInt)
    End Function

    Shared Function buscarProductoCompuesto(id As Integer) As List(Of ProductoBE)
        Return DAL.ProductoDAL.buscarProductoCompuesto(id)
    End Function


End Class ' ProductoBLL

