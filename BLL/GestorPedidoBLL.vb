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

    Public Shared Function checkPedidosMismoCliente(ByVal pedidos As PedidoBE) As Boolean
        checkPedidosMismoCliente = False
    End Function

    Public Shared Function generarHojaRuta(ByVal usr As BE.UsuarioBE, ByVal pedidos As List(Of BE.PedidoBE)) As MemoryStream
        For Each p As BE.PedidoBE In pedidos
            DAL.GestorPedidoDAL.loadDatosPedido(p)
            BLL.UsuarioBLL.llenarDatosUsuario(p.usr)
            DAL.GestorPedidoDAL.checkPedidoFacturado(p)
            BLL.GestorPedidoBLL.checkPedidoFinalizado(p)
        Next

        Dim id As Integer = DAL.GestorPedidoDAL.generarHojaRuta(pedidos)

        DAL.GestorPedidoDAL.asociarComprobantePedido(id, pedidos)

        Dim hr As BE.HojaRutaBE = DAL.GestorPedidoDAL.getHojaRuta(id)

        Dim ms As MemoryStream = Util.PDFGenerator.HojaRutaPDF(hr)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        ' MAIL PARA EL PROVEEDOR de logistica
        Util.Mailer.enviarMailConAdjunto(hr.prov.mail.ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRuta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRutaMensaje), ms2)
        'para nosotros
        ms = Util.PDFGenerator.HojaRutaPDF(hr)
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRuta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.HojaRutaMensaje), ms3)
        ms.Position = 0
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.HojaRutaGenerada)
        Return ms
    End Function

    Public Shared Function generarNotaCredito(ByVal usr As BE.UsuarioBE, ByVal pedido As PedidoBE) As MemoryStream
        DAL.GestorPedidoDAL.loadDatosPedido(pedido)
        DAL.GestorPedidoDAL.checkPedidoFacturado(pedido)
        DAL.GestorPedidoDAL.generarNotaCredito(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)

        BLL.GestorPedidoBLL.devolverPedido(pedido)

        Dim nc As BE.NotaCreditoBE = DAL.GestorPedidoDAL.getNotaCredito(pedido)

        DAL.GestorPedidoDAL.ajustarVarianza(nc.nro, pedido, False)

        Dim ms As MemoryStream = Util.PDFGenerator.NotaCreditoPDF(nc)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        'USR
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NC, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NCMensaje, 1), ms2)
        'para nosotros
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.NCMensaje), ms3)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.NCRealizada)
        ms.Position = 0
        Return ms
    End Function

    Public Shared Function generarPedido(ByVal pedido As PedidoBE) As MemoryStream
        BLL.GestorPedidoBLL.checkMasDeUnPedido(pedido)
        DAL.GestorPedidoDAL.generarPedido(pedido)
        'para el usr
        Dim ms As MemoryStream = Util.PDFGenerator.PedidoPDF(pedido)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        'USR
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Pedido, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoMensaje, 1), ms2)
        'para nosotros
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Pedido, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoMensaje, 1), ms3)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.PedidoRealizado)
        ms.Position = 0
        Return ms
    End Function

    Shared Function buscarTiposEnvios(idIdioma As Integer) As List(Of TipoEnvioBE)
        Return DAL.GestorPedidoDAL.buscarTiposEnvio(idIdioma)
    End Function

    Shared Function getEstadosPedidos() As List(Of BE.EstadoPedidoBE)
        Return DAL.GestorPedidoDAL.getEstadosPedidos
    End Function

    Shared Sub cancelarPedido(pedido As PedidoBE)
        BLL.GestorPedidoBLL.checkEstadoEnPago(pedido)
        DAL.GestorPedidoDAL.cancelarPedido(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)
        ' para el usr
        Util.Mailer.enviarMail(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCancelado, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCanceladoMensaje, 1) + " " + pedido.id)
        'para nosotros
        Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCancelado, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoCanceladoMensaje, 1) + " " + pedido.id)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.PedidoCancelado)
    End Sub

    Shared Sub generarComentario(usuario As UsuarioBE, pedido As BE.PedidoBE, comentario As String)
        DAL.GestorPedidoDAL.generarComentario(usuario, pedido, comentario)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)
        'usr
        Util.Mailer.enviarMail(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentario), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentarioMensaje) + " Pedido: " + pedido.id.ToString)
        'nosotros
        Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentario), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.PedidoComentarioMensaje) + " Pedido: " + pedido.id.ToString)
        BLL.GestorBitacoraBLL.registrarEvento(usuario, Util.Enumeradores.Bitacora.ComentarioGenerado)
    End Sub

    Shared Function generarFactura(pedido As PedidoBE) As MemoryStream
        DAL.GestorPedidoDAL.loadDatosPedido(pedido)
        'DAL.GestorPedidoDAL.checkPedidoNoFacturado(pedido)
        BLL.GestorPedidoBLL.checkPedidoFinalizado(pedido)
        DAL.GestorPedidoDAL.generarFactura(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)

        Dim fact As BE.FacturaBE = DAL.GestorPedidoDAL.getFactura(pedido)
        DAL.GestorPedidoDAL.ajustarVarianza(fact.nro, pedido, True)
        Dim ms As MemoryStream = Util.PDFGenerator.FacturaPDF(fact)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        'PARA EL USUARIO
        Util.Mailer.enviarMailConAdjunto(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Factura, 1), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.FacturaMensaje, 1), ms2)
        'para nosotros
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Factura), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.FacturaMensaje), ms3)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.FacturaRealizada)
        ms.Position = 0
        Return ms
    End Function

    Shared Function generarRemito(ByVal usr As BE.UsuarioBE, pedidos As List(Of PedidoBE)) As MemoryStream
        For Each p As BE.PedidoBE In pedidos
            DAL.GestorPedidoDAL.loadDatosPedido(p)
            DAL.GestorPedidoDAL.checkPedidoFacturado(p)
            BLL.GestorPedidoBLL.checkPedidoFinalizado(p)
        Next

        Dim id As Integer = DAL.GestorPedidoDAL.generarRemito(pedidos)

        DAL.GestorPedidoDAL.asociarComprobantePedido(id, pedidos)

        Dim remito As BE.RemitoBE = DAL.GestorPedidoDAL.getRemito(id)

        Dim ms As MemoryStream = Util.PDFGenerator.RemitoPDF(remito)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        ' MAIL PARA EL PROVEEDOR
        Util.Mailer.enviarMailConAdjunto(remito.prov.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Remito), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RemitoMensaje), ms2)
        'para nosotros
        'todo pincha aca por traducciones
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.Remito), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RemitoMensaje), ms3)
        ms.Position = 0
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.RemitoGenerado)
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

    Shared Sub anularVenta(pedido As PedidoBE, ByVal comentario As String, ByVal usr As BE.UsuarioBE)
        Try
            DAL.GestorPedidoDAL.checkPedidoFacturado(pedido)
            BLL.GestorPedidoBLL.checkEstadoPedidoNoEnviado(pedido)
        Catch ex As Util.PedidoFacturado
            generarNotaCredito(usr, pedido)
        End Try

        DAL.GestorPedidoDAL.anularVenta(pedido)
        BLL.GestorPedidoBLL.devolverPedido(pedido)
        DAL.GestorPedidoDAL.generarComentario(usr, pedido, comentario)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usr)
        'USR
        Util.Mailer.enviarMail(pedido.usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.AnulacionVenta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.AnulacionVentaMensaje))
        'NOS
        Util.Mailer.enviarMail(WebConfigurationManager.AppSettings("mailVentas").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.AnulacionVenta), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.AnulacionVentaMensaje))
        'EVENTO
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usr.id, Util.Enumeradores.Bitacora.VentaAnulada)
    End Sub

    Shared Sub cambiarEstadoPedido(ByVal usr As BE.UsuarioBE, pedido As BE.PedidoBE, idNuevoEstado As Integer)
        'todo check el tema de los cambios no se puede hacer cualquier cosa
        DAL.GestorPedidoDAL.cambiarEstadoPedido(pedido, idNuevoEstado)
    End Sub

    Private Shared Sub checkPedidoFinalizado(pedido As PedidoBE)
        If pedido.estado.id <> Util.Enumeradores.EstadoPedido.Construido Then
            Throw New Util.PedidoNoFinalizado
        End If
    End Sub

    Private Shared Sub checkEstadoPedidoNoEnviado(pedido As PedidoBE)
        If pedido.estado.id = Util.Enumeradores.EstadoPedido.Enviado Then
            Throw New Util.PedidoEnviado
        End If
    End Sub

    Private Shared Sub checkEstadoEnPago(pedido As PedidoBE)
        If pedido.estado.id <> Util.Enumeradores.EstadoPedido.ProcesoDePago Then
            Throw New Util.CancelarPedidoException
        End If
    End Sub

    Private Shared Sub checkMasDeUnPedido(pedido As PedidoBE)
        DAL.GestorPedidoDAL.checkMasDeUnPedido(pedido)
    End Sub

    Shared Function getDetallePedido(idPedido As Integer) As DataTable
        Return DAL.GestorPedidoDAL.getDetallePedido(idPedido)
    End Function

    Private Shared Sub devolverPedido(pedido As PedidoBE)
        DAL.GestorPedidoDAL.devolverPedido(pedido)
    End Sub

End Class ' GestorPedidoBLL
