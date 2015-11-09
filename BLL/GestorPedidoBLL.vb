Imports BE
Imports System.IO
Imports System.Web.Configuration


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

    Public Shared Function generarHojaRuta(ByVal pedidos As List(Of BE.PedidoBE)) As MemoryStream
        'TODO CHECK QUE NO ESTE GENERADO
        For Each p As BE.PedidoBE In pedidos
            DAL.GestorPedidoDAL.loadDatosPedido(p)
            BLL.UsuarioBLL.llenarDatosUsuario(p.usr)
        Next

        Dim id As Integer = DAL.GestorPedidoDAL.generarHojaRuta(pedidos)

        DAL.GestorPedidoDAL.asociarComprobantePedido(id, pedidos)

        Dim hr As BE.HojaRutaBE = DAL.GestorPedidoDAL.getHojaRuta(id)

        Dim ms As MemoryStream = Util.PDFGenerator.HojaRutaPDF(hr)
        ' MAIL PARA EL PROVEEDOR de logistica
        Util.Mailer.enviarMailConAdjunto(hr.prov.mail.ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRuta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRutaMensaje), ms)
        'para nosotros
        ms = Util.PDFGenerator.HojaRutaPDF(hr)
        'todo pincha aca por traducciones
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRuta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRutaMensaje), ms)
        ms.Position = 0
        Return ms
    End Function

    Public Shared Function generarNotaCredito(ByVal pedido As PedidoBE) As MemoryStream
        'TODO CHECK QUE NO ESTE YA GENERADO
        DAL.GestorPedidoDAL.loadDatosPedido(pedido)
        DAL.GestorPedidoDAL.generarNotaCredito(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)

        Dim nc As BE.NotaCreditoBE = DAL.GestorPedidoDAL.getNotaCredito(pedido)
        Dim ms As MemoryStream = Util.PDFGenerator.NotaCreditoPDF(nc)
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NC, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NCMensaje, 1), ms)
        'para nosotros
        ms = Util.PDFGenerator.NotaCreditoPDF(nc)
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NCMensaje), ms)
        'TODO ENVIAR PDF CON PAGO MIS CUENTAS O EL QUE SEA
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.NCRealizada)
        ms.Position = 0
        Return ms
    End Function

    Public Shared Function generarPedido(ByVal pedido As PedidoBE) As MemoryStream
        DAL.GestorPedidoDAL.generarPedido(pedido)
        'TODO SACAR ESTO HARDCODEADO HORRIBLE!! mails
        'para el usr
        Dim ms As MemoryStream = Util.PDFGenerator.PedidoPDF(pedido)
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Pedido, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoMensaje, 1), ms)
        'para nosotros
        ms = Util.PDFGenerator.PedidoPDF(pedido)
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Pedido, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoMensaje, 1), ms)
        'TODO ENVIAR PDF CON PAGO MIS CUENTAS O EL QUE SEA
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.PedidoRealizado)
        Return ms
    End Function

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
            Util.Mailer.enviarMail(a.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCancelado, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCanceladoMensaje, 1) + " " + a.id)
            'para nosotros
            Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCancelado, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCanceladoMensaje, 1) + " " + a.id)
            BLL.GestorBitacoraBLL.registrarEvento(a.usr.id, Util.Enumeradores.Bitacora.PedidoCancelado)
        Else
            Throw New Util.CancelarPedidoException
        End If
    End Sub

    Shared Sub generarComentario(usuario As UsuarioBE, pedido As BE.PedidoBE, comentario As String)
        DAL.GestorPedidoDAL.generarComentario(usuario, pedido, comentario)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)
        'usr
        Util.Mailer.enviarMail(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentario), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentarioMensaje) + " Pedido: " + pedido.id.ToString)
        'nosotros
        Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentario), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentarioMensaje) + " Pedido: " + pedido.id.ToString)
    End Sub

    Shared Function generarFactura(pedido As PedidoBE) As MemoryStream
        'TODO CHECK QUE NO ESTE YA GENERADO
        DAL.GestorPedidoDAL.loadDatosPedido(pedido)
        DAL.GestorPedidoDAL.generarFactura(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)

        Dim fact As BE.FacturaBE = DAL.GestorPedidoDAL.getFactura(pedido)
        Dim ms As MemoryStream = Util.PDFGenerator.FacturaPDF(fact)
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Factura, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.FacturaMensaje, 1), ms)
        'para nosotros
        ms = Util.PDFGenerator.FacturaPDF(fact)
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Factura), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.FacturaMensaje), ms)
        'TODO ENVIAR PDF CON PAGO MIS CUENTAS O EL QUE SEA
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.FacturaRealizada)
        ms.Position = 0
        Return ms
    End Function

    Shared Function generarRemito(pedidos As List(Of PedidoBE)) As MemoryStream
        'TODO CHECK QUE NO ESTE GENERADO
        For Each p As BE.PedidoBE In pedidos
            DAL.GestorPedidoDAL.loadDatosPedido(p)
        Next

        Dim id As Integer = DAL.GestorPedidoDAL.generarRemito(pedidos)

        DAL.GestorPedidoDAL.asociarComprobantePedido(id, pedidos)

        Dim remito As BE.RemitoBE = DAL.GestorPedidoDAL.getRemito(id)

        Dim ms As MemoryStream = Util.PDFGenerator.RemitoPDF(remito)
        ' MAIL PARA EL PROVEEDOR
        'Util.Mailer.enviarMailConAdjunto(remito.prov.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Remito, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RemitoMensaje, 1), ms)
        'para nosotros
        ms = Util.PDFGenerator.RemitoPDF(remito)
        'todo pincha aca por traducciones
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Remito), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RemitoMensaje), ms)
        ms.Position = 0
        Return ms
    End Function

    Shared Sub generarPedidoPersonalizado(pedido As PedidoPersonalizado)
        DAL.GestorPedidoDAL.generarPedidoPersonalizado(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)
        'USR
        Util.Mailer.enviarMail(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoPersonalizado), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoPersonalizadoMensaje))
        'NOS
        Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoPersonalizado), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoPersonalizadoMensaje))
        'EVENTO
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.PedidoPersonalizado)
    End Sub

    Shared Function buscarComentarios(p1 As Integer) As List(Of BE.Comentario)
        Return DAL.GestorPedidoDAL.buscarComentarios(p1)
    End Function

End Class ' GestorPedidoBLL
