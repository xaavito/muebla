Imports BE


Public Class ProveedorBLL

    Public Shared Function altaProveedor(ByVal prov As ProveedorBE) As Integer
        DAL.ProveedorDAL.checkCuilExistente(prov)
        Return DAL.ProveedorDAL.altaProveedor(prov)
    End Function

    Public Shared Function buscarProveedores(ByVal nom As String, ByVal contacto As String) As List(Of ProveedorBE)
        Return DAL.ProveedorDAL.buscarProveedores(nom, contacto)
    End Function

    Shared Function getTipoProductos() As List(Of BE.TipoProductoBE)
        Return DAL.ProductoDAL.getTipoProductos
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

End Class ' ProveedorBLL
