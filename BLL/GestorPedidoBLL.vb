Imports BE


Public Class GestorPedidoBLL


    Public Shared Function buscarMediosPago() As MedioPagoBE
        buscarMediosPago = Nothing
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Function buscarPedidos(ByVal usr As UsuarioBE) As List(Of PedidoBE)
        buscarPedidos = Nothing
    End Function

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub cancelarPedido(ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub checkEstadoPedido(ByVal pedido As PedidoBE)

    End Sub

    ''' 
    ''' <param name="pedidos"></param>
    Public Shared Function checkPedidosMismoCliente(ByVal pedidos As PedidoBE) As Boolean
        checkPedidosMismoCliente = False
    End Function

    ''' 
    ''' <param name="pedido"></param>
    Public Shared Sub generarComprobantePago(ByVal pedido As PedidoBE)

    End Sub

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
    ''' <param name="pedido"></param>
    Public Shared Sub generarPedidoPersonalizado(ByVal pedido As PedidoBE)

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
    ''' <param name="arch"></param>
    ''' <param name="obs"></param>
    ''' <param name="pedido"></param>
    Public Shared Sub solicitarServicio(ByVal arch As Object, ByVal obs As String, ByVal pedido As PedidoBE)

    End Sub


End Class ' GestorPedidoBLL
