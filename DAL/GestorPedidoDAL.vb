Imports BE
Imports Util


Public Class GestorPedidoDAL
    Public Shared Function buscarMediosPago() As List(Of MedioPagoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.MedioPagoBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_MEDIOS_PAGO_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim evento As New MedioPagoBE
                evento.id = pepe.Item(0)
                evento.descripcion = pepe.Item(1)

                componentes.Add(evento)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

    Public Shared Function buscarPedidos(ByVal usr As BE.UsuarioBE, ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal estado As Integer) As List(Of PedidoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.PedidoBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PEDIDOS_SP")
            repository.addParam("@fechaDesde", fechaDesde)
            repository.addParam("@fechaHasta", fechaHasta)
            repository.addParam("@estado", estado)
            repository.addParam("@usr", usr.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim evento As New PedidoBE
                evento.id = pepe.Item(0)
                evento.fechaCreacion = pepe.Item(1)
                Dim mp As New BE.MedioPagoBE
                mp.id = pepe.Item(2)
                mp.descripcion = pepe.Item(3)
                evento.medioPago = mp
                Dim te As New BE.TipoEnvioBE
                te.id = pepe.Item(4)
                te.texto = pepe.Item(5)
                evento.tipoEnvio = te
                Dim us As New BE.UsuarioBE
                us.id = pepe.Item(6)
                us.usuario = pepe.Item(7)
                evento.usr = us
                Dim ep As New BE.EstadoPedidoBE
                ep.id = pepe.Item(8)
                ep.descripcion = pepe.Item(9)
                evento.estado = ep
                evento.total = pepe.Item(10)
                componentes.Add(evento)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

    Public Shared Function checkEstadoPedido(ByVal pedido As PedidoBE, ByVal estado As Boolean) As Boolean
        checkEstadoPedido = False
    End Function

    Public Shared Sub generarFactura(ByVal pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_FACTURA_SP")
            repository.addParam("@fecha", pedido.fechaCreacion)
            repository.addParam("@idPedido", pedido.id)
            repository.addParam("@total", pedido.total)
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If

            Dim idDet As Integer
            For Each prod As PedidoProductoBE In pedido.productos
                repository.crearComando("ALTA_FACTURA_DETALLE_SP")
                repository.addParam("@idCabecera", id)
                repository.addParam("@idLpd", prod.producto.id)
                repository.addParam("@cant", prod.cantidad)
                idDet = repository.executeSearchWithStatus
                If (idDet <= 0) Then
                    Throw New CreacionException
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function generarHojaRuta(ByVal pedidos As List(Of PedidoBE))
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_HR_SP")
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If

            Dim idDet As Integer
            For Each ped As PedidoBE In pedidos
                For Each pp As PedidoProductoBE In ped.productos
                    repository.crearComando("ALTA_HR_DETALLE_SP")
                    repository.addParam("@idCabecera", id)
                    repository.addParam("@desc", ped.usr.domicilio.formatedLine)
                    idDet = repository.executeSearchWithStatus
                    If (idDet <= 0) Then
                        Throw New CreacionException
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_NC_SP")
            repository.addParam("@fecha", pedido.fechaCreacion)
            repository.addParam("@idPedido", pedido.id)
            repository.addParam("@total", pedido.total)
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If

            Dim idDet As Integer
            For Each prod As PedidoProductoBE In pedido.productos
                repository.crearComando("ALTA_NC_DETALLE_SP")
                repository.addParam("@idCabecera", id)
                repository.addParam("@desc", prod.producto.producto.descripcion)
                repository.addParam("@val", prod.getPrecioSinFormato)
                idDet = repository.executeSearchWithStatus
                If (idDet <= 0) Then
                    Throw New CreacionException
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub generarPedido(ByVal pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PEDIDO_SP")
            repository.addParam("@fecha", pedido.fechaCreacion)
            repository.addParam("@pago", pedido.medioPago.id)
            repository.addParam("@envio", pedido.tipoEnvio.id)
            repository.addParam("@usr", pedido.usr.id)
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If
            pedido.id = id

            Dim idDet As Integer
            For Each prod As PedidoProductoBE In pedido.productos
                repository.crearComando("ALTA_PEDIDO_PRODUCTO_SP")
                repository.addParam("@idPedido", pedido.id)
                repository.addParam("@idLpd", prod.producto.id)
                repository.addParam("@cant", prod.cantidad)
                idDet = repository.executeSearchWithStatus
                If (idDet <= 0) Then
                    Throw New CreacionException
                End If
                prod.id = idDet
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub generarResena(ByVal comentario As String, ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub solicitarServicio(ByVal observacion As String, ByVal arch As Object, ByVal pedido As PedidoBE)

    End Sub

    Shared Function buscarTiposEnvio(idIdioma As Integer) As List(Of TipoEnvioBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.TipoEnvioBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_TIPOS_ENVIO_SP")
            repository.addParam("@idIdioma", idIdioma)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim evento As New TipoEnvioBE
                evento.id = pepe.Item(0)
                evento.texto = pepe.Item(1)

                componentes.Add(evento)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

    Shared Function getEstadosPedidos() As List(Of EstadoPedidoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.EstadoPedidoBE)
        Dim repository As New AccesoSQLServer
        'TODO LE METO IDIOMA???
        Try
            repository.crearComando("BUSCAR_ESTADOS_ENVIO_SP")
            'repository.addParam("@idIdioma", idIdioma)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim evento As New EstadoPedidoBE
                evento.id = pepe.Item(0)
                evento.descripcion = pepe.Item(1)

                componentes.Add(evento)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return componentes
    End Function

    Shared Sub cancelarPedido(a As PedidoBE)
        Dim idRet As Integer
        Dim repository As New AccesoSQLServer
        repository.crearComando("CANCELAR_PEDIDO_SP")
        repository.addParam("@id", a.id)
        idRet = repository.executeSearchWithStatus
        If (idRet <= 0) Then
            Throw New EliminacionException
        End If
    End Sub

    Shared Sub generarComentario(usuario As UsuarioBE, pedido As BE.PedidoBE, comentario As String)
        Dim idRet As Integer
        Dim repository As New AccesoSQLServer
        repository.crearComando("ALTA_COMENTARIO_PEDIDO_SP")
        repository.addParam("@id", pedido.id)
        repository.addParam("@com", comentario)
        repository.addParam("@usr", usuario.id)
        idRet = repository.executeSearchWithStatus
        If (idRet <= 0) Then
            Throw New CreacionException
        End If
    End Sub

    Shared Sub loadDatosPedido(ByRef pedido As PedidoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.PedidoProductoBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_DETALLES_PEDIDO_SP")
            repository.addParam("@id", pedido.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim det As New PedidoProductoBE
                det.id = pepe.Item(0)
                det.cantidad = pepe.Item(1)
                Dim lpd As New BE.ListaPrecioDetalleBE
                lpd.id = pepe.Item(2)
                lpd.precio = pepe.Item(3)
                Dim prod As New BE.ProductoBE
                prod.id = pepe.Item(4)
                prod.descripcion = pepe.Item(5)
                lpd.producto = prod
                det.producto = lpd

                componentes.Add(det)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        pedido.productos = componentes
    End Sub

    Shared Function getFactura(pedido As PedidoBE) As BE.FacturaBE
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim comp As New FacturaBE
        Dim lista As New List(Of BE.FacturaDetalleBE)
        Try
            repository.crearComando("BUSCAR_FACTURA_PEDIDO_SP")
            repository.addParam("@id", pedido.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows

                comp.nro = pepe.Item(0)
                comp.letra = pepe.Item(1)
                comp.sucursal = pepe.Item(2)
                comp.total = pepe.Item(3)
                comp.fecha = pepe.Item(8)
                Dim usr As New BE.UsuarioBE
                usr.id = pepe.Item(4)
                usr.nombre = pepe.Item(5)
                usr.apellido = pepe.Item(6)
                usr.cuil = pepe.Item(7)
                comp.usr = usr
            Next

            repository.crearComando("BUSCAR_FACTURA_DETALLE_PEDIDO_SP")
            repository.addParam("@nro", comp.nro)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim det As New BE.FacturaDetalleBE
                det.cant = pepe.Item(0)
                det.iva = pepe.Item(1)
                Dim lpd As New BE.ListaPrecioDetalleBE
                lpd.id = pepe.Item(2)
                lpd.precio = pepe.Item(3)
                Dim prod As New BE.ProductoBE
                prod.id = pepe.Item(4)
                prod.descripcion = pepe.Item(5)
                lpd.producto = prod

                det.lpd = lpd
                lista.Add(det)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        comp.detalles = lista
        Return comp
    End Function

    Shared Function generarRemito(lista As List(Of PedidoBE)) As Integer
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_REMITO_SP")
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If

            Dim idDet As Integer
            For Each ped As PedidoBE In lista
                For Each pp As PedidoProductoBE In ped.productos
                    repository.crearComando("ALTA_REMITO_DETALLE_SP")
                    repository.addParam("@idCabecera", id)
                    repository.addParam("@idProd", pp.producto.producto.id)
                    repository.addParam("@cant", pp.cantidad)
                    idDet = repository.executeSearchWithStatus
                    If (idDet <= 0) Then
                        Throw New CreacionException
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Shared Function getRemito(nro As Integer) As RemitoBE
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim comp As New RemitoBE
        Dim lista As New List(Of BE.RemitoDetalleBE)
        Try
            repository.crearComando("BUSCAR_REMITO_COMPROBANTE_SP")
            repository.addParam("@nro", nro)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                comp.nro = pepe.Item(0)
                comp.letra = pepe.Item(1)
                comp.sucursal = pepe.Item(2)
                comp.fecha = pepe.Item(3)
                Dim prov As New BE.ProveedorBE
                prov.id = pepe.Item(4)
                prov.razonSocial = pepe.Item(5)
                prov.mail = pepe.Item(6)
                comp.prov = prov
            Next

            repository.crearComando("BUSCAR_REMITO_DETALLE_SP")
            repository.addParam("@nro", comp.nro)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim det As New BE.RemitoDetalleBE
                det.cantidad = pepe.Item(0)

                Dim prod As New BE.ProductoBE
                prod.id = pepe.Item(1)
                prod.descripcion = pepe.Item(2)
                det.producto = prod

                lista.Add(det)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        comp.detalles = lista
        Return comp
    End Function

    Shared Sub asociarComprobantePedido(nroComprobante As Integer, pedidos As List(Of PedidoBE))
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            For Each p As BE.PedidoBE In pedidos
                repository.crearComando("ALTA_ASOCIACION_COMP_PED_SP")
                repository.addParam("@idPedido", p.id)
                repository.addParam("@nroComp", nroComprobante)
                id = repository.executeSearchWithStatus
                If (id <= 0) Then
                    Throw New CreacionException
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getHojaRuta(nroComprobante As Integer) As HojaRutaBE
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim comp As New HojaRutaBE
        Dim lista As New List(Of BE.HojaRutaDetalleBE)
        Try
            repository.crearComando("BUSCAR_HR_COMPROBANTE_SP")
            repository.addParam("@nro", nroComprobante)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                comp.nro = pepe.Item(0)
                comp.letra = pepe.Item(1)
                comp.sucursal = pepe.Item(2)
                comp.fecha = pepe.Item(3)
                Dim prov As New BE.ProveedorBE
                prov.id = pepe.Item(4)
                prov.razonSocial = pepe.Item(5)
                prov.mail = pepe.Item(6)
                comp.prov = prov
            Next

            repository.crearComando("BUSCAR_HR_DETALLE_SP")
            repository.addParam("@nro", comp.nro)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim det As New BE.HojaRutaDetalleBE
                det.descripcion = pepe.Item(0)

                lista.Add(det)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        comp.detalles = lista
        Return comp
    End Function

    Shared Function getNotaCredito(pedido As PedidoBE) As NotaCreditoBE
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim comp As New NotaCreditoBE
        Dim lista As New List(Of BE.NotaCreditoDetalleBE)
        Try
            repository.crearComando("BUSCAR_NC_PEDIDO_SP")
            repository.addParam("@id", pedido.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                comp.nro = pepe.Item(0)
                comp.letra = pepe.Item(1)
                comp.sucursal = pepe.Item(2)
                comp.total = pepe.Item(3)
                comp.fecha = pepe.Item(8)
                Dim usr As New BE.UsuarioBE
                usr.id = pepe.Item(4)
                usr.nombre = pepe.Item(5)
                usr.apellido = pepe.Item(6)
                usr.cuil = pepe.Item(7)
                comp.usr = usr
                Exit For
            Next

            repository.crearComando("BUSCAR_NC_DETALLE_PEDIDO_SP")
            repository.addParam("@nro", comp.nro)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim det As New BE.NotaCreditoDetalleBE
                det.texto = pepe.Item(0)
                det.valor = pepe.Item(1)
                det.iva = pepe.Item(2)

                lista.Add(det)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        comp.detalles = lista
        Return comp
    End Function

    Shared Sub generarPedidoPersonalizado(pedido As PedidoPersonalizado)
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PEDIDO_PERSONALIZADO_SP")
            repository.addParam("@des", pedido.descripcion)
            repository.addParam("@usr", pedido.usr.id)
            repository.addParam("@imagen", pedido.imagen)
            id = repository.executeWithReturnValue
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
        pedido.id = id
    End Sub

    Shared Function buscarComentarios(p1 As Integer) As List(Of Comentario)
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim lista As New List(Of BE.Comentario)
        Try
            repository.crearComando("BUSCAR_COMENTARIOS_SP")
            repository.addParam("@id", p1)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim com As New BE.Comentario
                com.id = pepe.Item(0)
                com.texto = pepe.Item(1)
                Dim usr As New BE.UsuarioBE
                usr.id = pepe.Item(2)
                usr.usuario = pepe.Item(3)
                usr.mail = pepe.Item(4)
                com.usuario = usr

                lista.Add(com)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Shared Sub anularVenta(pedido As BE.PedidoBE)
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ANULAR_VENTA_SP")
            repository.addParam("@id", pedido.id)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub cambiarEstadoPedido(pedido As PedidoBE, idNuevoEstado As Integer)
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CAMBIAR_ESTADO_PEDIDO_SP")
            repository.addParam("@id", pedido.id)
            repository.addParam("@idEstado", idNuevoEstado)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkPedidoFacturado(p As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_PEDIDO_FACTURADO_SP")
            repository.addParam("@id", p.id)
            id = repository.executeWithReturnValue
            If id = 0 Then
                Throw New Util.PedidoNoFacturado
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkPedidoNoFacturado(pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_PEDIDO_FACTURADO_SP")
            repository.addParam("@id", pedido.id)
            id = repository.executeWithReturnValue
            If id <> 0 Then
                Throw New Util.PedidoFacturado
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkMasDeUnPedido(pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_MAS_DE_UN_PEDIDO_SP")
            repository.addParam("@id", pedido.usr.id)
            id = repository.executeWithReturnValue
            If id <> 0 Then
                Throw New Util.MasDeUnPedido
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getDetallePedido(idPedido As Integer) As DataTable
        Dim table As DataTable
        Dim repository As New AccesoSQLServer
        Dim lista As New List(Of BE.Comentario)
        Try
            repository.crearComando("BUSCAR_DETALLE_PEDIDO_SP")
            repository.addParam("@id", idPedido)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return table
    End Function

    Shared Sub devolverPedido(pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            For Each p As BE.PedidoProductoBE In pedido.productos
                repository.crearComando("DEVOLVER_PEDIDO_SP")
                repository.addParam("@idPedido", p.id)
                repository.addParam("@prod", p.producto.producto.id)
                repository.addParam("@cant", p.cantidad)
                id = repository.executeSearchWithStatus
                If (id <= 0) Then
                    Throw New CreacionException
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub ajustarVarianza(nroComprobante As Integer, pedido As PedidoBE, incrementa As Boolean)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            For Each p As BE.PedidoProductoBE In pedido.productos
                repository.crearComando("AJUSTAR_VARIANZA_SP")
                repository.addParam("@nroComp", nroComprobante)
                repository.addParam("@prod", p.producto.producto.id)
                repository.addParam("@cant", p.cantidad)
                repository.addParam("@inc", IIf(incrementa = True, 1, -1))
                id = repository.executeSearchWithStatus
                If (id <= 0) Then
                    Throw New CreacionException
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class ' GestorPedidoDAL

