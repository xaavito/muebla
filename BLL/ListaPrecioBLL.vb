Imports BE


Public Class ListaPrecioBLL

    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)
        listaPrecio.id = DAL.ListaPrecioDAL.altaListaPrecio(listaPrecio)
        DAL.ListaPrecioDAL.altaDetallesListaPrecio(listaPrecio)
        DAL.ListaPrecioDAL.cerrarVigencia(listaPrecio)
    End Sub

   Public Shared Function buscarListas(ByVal activo As Integer, ByVal tipoVenta As String) As List(Of ListaPrecioBE)
        Return DAL.ListaPrecioDAL.buscarListas(activo, tipoVenta)
    End Function

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

    Shared Sub altaPromocion(idProd As Integer, precio As Decimal, desde As Date, hasta As Date)
        BLL.ListaPrecioBLL.checkFechas(desde, hasta)
        DAL.ListaPrecioDAL.altaPromocion(idProd, precio, desde, hasta)
        'TODO ACA DEBERIAMOS MANDAR UN MAIL A MUCHOS DE LOS QUE YA HAYAN COMPRADO!
        BLL.ProductoBLL.limpiarProds()
    End Sub

    Private Shared Sub checkFechas(desde As Date, hasta As Date)
        If desde >= hasta Then
            Throw New Util.FechaHastaMenorIgualDesde
        End If
    End Sub


End Class ' ListaPrecioBLL
