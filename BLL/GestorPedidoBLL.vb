Imports BE


Public Class GestorPedidoBLL
    Public Shared Function buscarMediosPago() As List(Of MedioPagoBE)
        Return DAL.GestorPedidoDAL.buscarMediosPago()
    End Function

    Public Shared Function buscarPedidos(ByVal usr As BE.UsuarioBE, ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal estado As Integer) As List(Of PedidoBE)
        Return DAL.GestorPedidoDAL.buscarPedidos(usr, fechaDesde, fechaHasta, estado)
    End Function

    
    Public Shared Sub checkEstadoPedido(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Function checkPedidosMismoCliente(ByVal pedidos As PedidoBE) As Boolean
        checkPedidosMismoCliente = False
    End Function

    Public Shared Sub generarComprobantePago(ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarFactura(ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarHojaRuta(ByVal pedidos As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarPedido(ByVal pedido As PedidoBE)
        DAL.GestorPedidoDAL.generarPedido(pedido)
        'TODO SACAR ESTO HARDCODEADO HORRIBLE!! mails
        Util.PDFGenerator.PedidoPDF(pedido)
        Util.Mailer.sendMailWithAttachment(pedido.usr.mail, "Pedido generado", "A PAGAR MACHOOOO", Util.PDFGenerator.PedidoPDF(pedido))
        'TODO ENVIAR PDF CON PAGO MIS CUENTAS O EL QUE SEA
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.PedidoRealizado)
    End Sub

    Public Shared Sub generarPedidoPersonalizado(ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarRemito(ByVal pedidos As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub generarResena(ByVal comentario As String, ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Public Shared Sub solicitarServicio(ByVal arch As Object, ByVal obs As String, ByVal pedido As PedidoBE)
        'TODO
    End Sub

    Shared Function buscarTiposEnvios(idIdioma As Integer) As List(Of TipoEnvioBE)
        Return DAL.GestorPedidoDAL.buscarTiposEnvio(idIdioma)
    End Function

    Shared Function getEstadosPedidos() As List(Of BE.EstadoPedidoBE)
        Return DAL.GestorPedidoDAL.getEstadosPedidos
    End Function

    Shared Sub cancelarPedido(a As PedidoBE)
        If a.estado.id = 1 Then
            DAL.GestorPedidoDAL.cancelarPedido(a)
        Else
            Throw New Util.CancelarPedidoException
        End If
    End Sub


End Class ' GestorPedidoBLL
