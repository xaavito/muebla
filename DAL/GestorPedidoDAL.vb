Imports BE


Public Class GestorPedidoDAL


    Public Shared Function buscarMediosPago() As List(Of MedioPagoBE)
        buscarMediosPago = Nothing
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Function buscarPedidos(ByVal usr As UsuarioBE) As List(Of PedidoBE)
        buscarPedidos = Nothing
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub cancelarPedido(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    ''' <param name="estado"></param>
    Public Shared Function checkEstadoPedido(ByVal pedido As PedidoBE, ByVal estado As Boolean) As Boolean
        checkEstadoPedido = False
    End Function

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub generarFactura(ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedidos"></param>
    Public Shared Sub generarHojaRuta(ByVal pedidos As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub generarPedido(ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedidos"></param>
    Public Shared Sub generarRemito(ByVal pedidos As PedidoBE)

    End Sub

    ''' 
    ''' <param name="comentario"></param>
    ''' <param name="pedido"></param>
    Public Shared Sub generarResena(ByVal comentario As String, ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="observacion"></param>
    ''' <param name="arch"></param>
    ''' <param name="pedido"></param>
    Public Shared Sub solicitarServicio(ByVal observacion As String, ByVal arch As Object, ByVal pedido As PedidoBE)

    End Sub


End Class ' GestorPedidoDAL

