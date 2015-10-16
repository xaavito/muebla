Imports BE
Imports Util


Public Class GestorPedidoDAL


    Public Shared Function buscarMediosPago(ByVal idIdioma As Integer) As List(Of MedioPagoBE)
        Dim table As DataTable
        Dim componentes As New List(Of BE.MedioPagoBE)
        Dim repository As New AccesoSQLServer
        Try
            'NO IMPLEMENTADO
            repository.crearComando("BUSCAR_MEDIOS_PAGO_SP")
            repository.addParam("@idIdioma", idIdioma)
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

    Public Shared Function buscarPedidos(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal estado As EstadoPedidoBE) As List(Of PedidoBE)
        buscarPedidos = Nothing
    End Function

    Public Shared Sub cancelarPedido(ByVal usr As UsuarioBE)

    End Sub

    Public Shared Function checkEstadoPedido(ByVal pedido As PedidoBE, ByVal estado As Boolean) As Boolean
        checkEstadoPedido = False
    End Function

    Public Shared Sub generarFactura(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarHojaRuta(ByVal pedidos As PedidoBE)

    End Sub

    Public Shared Sub generarNotaCredito(ByVal pedido As PedidoBE)

    End Sub

    Public Shared Sub generarPedido(ByVal pedido As PedidoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            'NO IMPLEMENTADO
            repository.crearComando("ALTA_PEDIDO_SP")
            repository.addParam("@fecha", pedido.fechaCreacion)
            repository.addParam("@pago", pedido.medioPago.id)
            repository.addParam("@envio", pedido.tipoEnvio.id)
            repository.addParam("@estado", pedido.estado)
            repository.addParam("@fecha", pedido.fechaCreacion)
            id = repository.executeWithReturnValue
            If (id <= 0) Then
                Throw New CreacionException
            End If
            pedido.id = id

            'NO IMPLEMENTADO
            'CAMBIAR EN LA BD, PEDIDO PRODUCTO A FK CON LISTA PRECIO DETALLE!!
            Dim idDet As Integer
            For Each prod As PedidoProductoBE In pedido.productos
                repository.crearComando("ALTA_PEDIDO_PRODUCTO_SP")
                repository.addParam("@idPedido", pedido.id)
                repository.addParam("@idLpd", prod.id)
                repository.addParam("@cant", prod.cantidad)
                idDet = repository.executeWithReturnValue
                If (idDet <= 0) Then
                    Throw New CreacionException
                End If
                prod.id = idDet
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub generarRemito(ByVal pedidos As PedidoBE)

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
            'NO IMPLEMENTADO
            repository.crearComando("BUSCAR_TIPO_ENVIO_SP")
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


End Class ' GestorPedidoDAL

