Imports BE


Public Class ListaPrecioBLL


    ''' 
    ''' <param name="listaPrecio"></param>
    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)

    End Sub

    ''' 
    ''' <param name="desde"></param>
    ''' <param name="listaPrecio"></param>
    ''' <param name="descuento"></param>
    Public Shared Sub altaPromocion(ByVal desde As DateTime, ByVal listaPrecio As ListaPrecioBE, ByVal descuento As Integer)

    End Sub

    ''' 
    ''' <param name="activo"></param>
    ''' <param name="tipoVenta"></param>
    Public Shared Function buscarListas(ByVal activo As Integer, ByVal tipoVenta As String) As List(Of ListaPrecioBE)
        Return DAL.ListaPrecioDAL.buscarListas(activo, tipoVenta)
    End Function

    ''' 
    ''' <param name="desde"></param>
    ''' <param name="aumento"></param>
    ''' <param name="tipoAumento"></param>
    Public Shared Sub modificarListaPrecio(ByVal desde As DateTime, ByVal aumento As Integer, ByVal tipoAumento As Boolean)

    End Sub

    Shared Function getDetalleListaPrecio(id As Integer) As List(Of BE.ListaPrecioDetalleBE)
        Return DAL.ListaPrecioDAL.getDetalleListaPrecio(id)
    End Function


End Class ' ListaPrecioBLL
