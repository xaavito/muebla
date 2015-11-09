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

    Public Shared Sub generarHojaRuta(ByVal pedidos As PedidoBE)

    End Sub

    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)

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

    Shared Sub generarComentario(idPedido As Integer, comentario As String)
        Dim idRet As Integer
        Dim repository As New AccesoSQLServer
        repository.crearComando("ALTA_COMENTARIO_PEDIDO_SP")
        repository.addParam("@id", idPedido)
        repository.addParam("@com", comentario)
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


End Class ' GestorPedidoDAL

