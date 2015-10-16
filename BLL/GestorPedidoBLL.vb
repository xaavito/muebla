Imports BE


Public Class GestorPedidoBLL


    Public Shared Function buscarMediosPago(ByVal idIdioma As Integer) As List(Of MedioPagoBE)
        Return DAL.GestorPedidoDAL.buscarMediosPago(idIdioma)
    End Function

    Public Shared Function buscarPedidos(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal estado As EstadoPedidoBE) As List(Of PedidoBE)
        Return DAL.GestorPedidoDAL.buscarPedidos(fechaDesde, fechaHasta, estado)
    End Function

    Public Shared Sub cancelarPedido(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub checkEstadoPedido(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Function checkPedidosMismoCliente(ByVal pedidos As PedidoBE) As Boolean
        checkPedidosMismoCliente = False
    End Function

    Public Shared Sub generarComprobantePago(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarFactura(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarHojaRuta(ByVal pedidos As PedidoBE)

    End Sub

    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarPedido(ByVal pedido As PedidoBE)
        DAL.GestorPedidoDAL.generarPedido(pedido)
        'SACAR ESTO HARDCODEADO HORRIBLE!!
        Util.Mailer.sendMail(pedido.usr.mail, "Pedido generado", "A PAGAR MACHOOOO")
    End Sub

    Public Shared Sub generarPedidoPersonalizado(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarRemito(ByVal pedidos As PedidoBE)

    End Sub

    Public Shared Sub generarResena(ByVal comentario As String, ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub solicitarServicio(ByVal arch As Object, ByVal obs As String, ByVal pedido As PedidoBE)

    End Sub

    Shared Function buscarTiposEnvios(idIdioma As Integer) As List(Of TipoEnvioBE)
        Return DAL.GestorPedidoDAL.buscarTiposEnvio(idIdioma)
    End Function


End Class ' GestorPedidoBLL
