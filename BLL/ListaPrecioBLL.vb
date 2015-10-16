Imports BE


Public Class ListaPrecioBLL
    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)

    End Sub

    Public Shared Sub altaPromocion(ByVal desde As DateTime, ByVal listaPrecio As ListaPrecioBE, ByVal descuento As Integer)

    End Sub

    Public Shared Function buscarListas(ByVal activo As Integer, ByVal tipoVenta As String) As List(Of ListaPrecioBE)
        Return DAL.ListaPrecioDAL.buscarListas(activo, tipoVenta)
    End Function

    Public Shared Sub modificarListaPrecio(ByVal desde As DateTime, ByVal aumento As Integer, ByVal tipoAumento As Boolean)

    End Sub

    Shared Function getDetalleListaPrecio(id As Integer) As List(Of BE.ListaPrecioDetalleBE)
        Return DAL.ListaPrecioDAL.getDetalleListaPrecio(id)
    End Function

    Shared Sub modificarListaPrecioDetalle(idLpd As Integer, precio As String)
        DAL.ListaPrecioDAL.modificarListaPrecioDetalle(idLpd, precio)
    End Sub


End Class ' ListaPrecioBLL
