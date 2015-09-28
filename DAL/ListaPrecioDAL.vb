Imports BE


Public Class ListaPrecioDAL


    ''' 
    ''' <param name="listaPrecio"></param>
    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)

    End Sub

    ''' 
    ''' <param name="listaPrecio"></param>
    ''' <param name="descuento"></param>
    ''' <param name="desde"></param>
    Public Shared Sub altaPromocion(ByVal listaPrecio As ListaPrecioBE, ByVal descuento As Integer, ByVal desde As DateTime)

    End Sub

    ''' 
    ''' <param name="tipo"></param>
    ''' <param name="activo"></param>
    Public Shared Function buscarListas(ByVal tipo As TipoVentaBE, ByVal activo As Boolean) As List(Of ListaPrecioBE)
        buscarListas = Nothing
    End Function

    ''' 
    ''' <param name="fecha"></param>
    ''' <param name="tipoVenta"></param>
    Public Shared Function checkListaVigente(ByVal fecha As DateTime, ByVal tipoVenta As TipoVentaBE) As Boolean
        checkListaVigente = False
    End Function

    ''' 
    ''' <param name="desde"></param>
    ''' <param name="aumento"></param>
    ''' <param name="tipoAumento"></param>
    Public Shared Sub modificarListaPrecio(ByVal desde As DateTime, ByVal aumento As Integer, ByVal tipoAumento As Boolean)

    End Sub


End Class ' ListaPrecioDAL

