Imports BE


Public Class ProveedorBLL


    ''' 
    ''' <param name="prov"></param>
    Public Shared Function altaProveedor(ByVal prov As ProveedorBE) As Integer
        Return DAL.ProveedorDAL.altaProveedor(prov)
    End Function

    ''' 
    ''' <param name="proveedor"></param>
    Public Shared Sub bajaProveedor(ByVal proveedor As ProveedorBE)

    End Sub

    ''' 
    ''' <param name="prov"></param>
    Public Shared Function buscarProveedores(ByVal nom As String, ByVal contacto As String) As List(Of ProveedorBE)
        Return DAL.ProveedorDAL.buscarProveedores(nom, contacto)
    End Function

    ''' 
    ''' <param name="proveedor"></param>
    Public Shared Sub modifcarProveedor(ByVal proveedor As ProveedorBE)

    End Sub

    Shared Function getTipoProductos() As List(Of BE.TipoProductoBE)
        Return DAL.ProductoDAL.getTipoProductos
    End Function

    Shared Function listarProveedores() As List(Of BE.ProveedorBE)
        Return DAL.ProveedorDAL.listarProveedores()
    End Function

    Shared Function getProductos(prov As ProveedorBE) As List(Of ProductoBE)
        Return DAL.ProveedorDAL.getProductos(prov)
    End Function


End Class ' ProveedorBLL
