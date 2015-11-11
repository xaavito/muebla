Imports BE


Public Class ProveedorBLL

    Public Shared Sub altaProveedor(ByRef prov As ProveedorBE)
        DAL.ProveedorDAL.checkCuilExistente(prov)
        DAL.ProveedorDAL.altaProveedor(prov)
        DAL.ProveedorDAL.altaDomicilio(prov)
        DAL.ProveedorDAL.altaTelefono(prov)
    End Sub

    Public Shared Function buscarProveedores(ByVal nom As String, ByVal contacto As String) As List(Of ProveedorBE)
        Return DAL.ProveedorDAL.buscarProveedores(nom, contacto)
    End Function

    Shared Function getTipoProductos() As List(Of BE.TipoProductoBE)
        Dim lista As List(Of BE.TipoProductoBE) = DAL.ProductoDAL.getTipoProductos
        Dim todos As New BE.TipoProductoBE
        todos.id = 0
        todos.descripcion = "Todos"
        lista.Add(todos)
        Return lista
    End Function

    Shared Function listarProveedores() As List(Of BE.ProveedorBE)
        Return DAL.ProveedorDAL.listarProveedores()
    End Function

    Shared Function getProductos(prov As ProveedorBE) As List(Of ProductoBE)
        Return DAL.ProveedorDAL.getProductos(prov)
    End Function

    Shared Sub modificarProveedor(prov As ProveedorBE)
        DAL.ProveedorDAL.checkCuilExistente(prov)
        DAL.ProveedorDAL.modificarProveedor(prov)
    End Sub

    Shared Sub eliminarProveedor(id As Integer, ob As String)
        DAL.ProveedorDAL.checkProveedorProductosVenta(id)
        DAL.ProveedorDAL.checkProveedorProductosStock(id)
        DAL.ProveedorDAL.eliminarProveedor(id)
        DAL.ProveedorDAL.agregarObservacionProv(id, ob)
    End Sub

    Shared Function getProveedoresPorProducto(p1 As Integer) As List(Of ProveedorBE)
        Return DAL.ProveedorDAL.getProveedoresPorProducto(p1)
    End Function

    Shared Function getPrecioProductoProveedor(idProd As Integer, idProv As Integer) As Decimal
        Return DAL.ProveedorDAL.getPrecioProductoProveedor(idProd, idProv)
    End Function

End Class ' ProveedorBLL
