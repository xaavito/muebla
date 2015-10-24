Imports BE


Public Class ListaPrecioBLL

    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)
        listaPrecio.id = DAL.ListaPrecioDAL.altaListaPrecio(listaPrecio)
        DAL.ListaPrecioDAL.altaDetallesListaPrecio(listaPrecio)
        DAL.ListaPrecioDAL.cerrarVigencia(listaPrecio)
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
        ' TODO VER QUE NO ESTE VENDIENDOSE
        DAL.ListaPrecioDAL.modificarListaPrecioDetalle(idLpd, precio)
    End Sub

    Shared Function getListaPrecioParaAlta() As List(Of BE.ListaPrecioDetalleBE)
        Return DAL.ListaPrecioDAL.getListaPrecioParaAlta
    End Function


End Class ' ListaPrecioBLL
