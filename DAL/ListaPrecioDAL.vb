Imports BE


Public Class ListaPrecioDAL


    Public Shared Function altaListaPrecio(ByVal listaPrecio As ListaPrecioBE) As Integer
        Dim id As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_LISTA_PRECIO_SP")
            repository.addParam("@desc", listaPrecio.descripcion)
            repository.addParam("@fecha", listaPrecio.fechaDesde)
            id = repository.executeWithReturnValue
            If (id = 0) Then
                Throw New Util.CreacionException
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Public Shared Function buscarListas(ByVal estado As Integer, ByVal descripcion As String) As List(Of ListaPrecioBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_LISTA_PRECIO_SP")
            repository.addParam("@act", estado)
            repository.addParam("@des", descripcion)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim lista As New BE.ListaPrecioBE
                lista.id = item.Item(0)
                lista.descripcion = item.Item(1)
                lista.activo = item.Item(2)
                lista.fechaDesde = item.Item(3)
                If Not IsDBNull(item.Item(4)) Then
                    lista.fechaHasta = item.Item(4)
                End If

                list.Add(lista)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Public Shared Function checkListaVigente(ByVal fecha As DateTime, ByVal tipoVenta As TipoVentaBE) As Boolean
        checkListaVigente = False
    End Function

    Shared Function getDetalleListaPrecio(id As Integer) As List(Of ListaPrecioDetalleBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_LISTA_PRECIO_DETALLES_SP")
            repository.addParam("@id", id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim lista As New BE.ListaPrecioDetalleBE
                lista.id = item.Item(0)
                lista.precio = item.Item(1)
                Dim prod As New BE.ProductoBE
                prod.id = item.Item(2)
                prod.descripcion = item.Item(3)
                lista.producto = prod

                list.Add(lista)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Sub modificarListaPrecioDetalle(idLpd As Integer, precio As String)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_LISTA_PRECIO_DETALLE_SP")
            repository.addParam("@id", idLpd)
            repository.addParam("@precio", Decimal.Parse(precio))

            id = repository.executeSearchWithStatus
            If (id <= 0) Then
                Throw New Util.ModificarException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getListaPrecioParaAlta() As List(Of ListaPrecioDetalleBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_LISTA_PRECIO_DETALLES_ALTA_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim lista As New BE.ListaPrecioDetalleBE
                lista.id = item.Item(0)
                lista.precio = item.Item(1)
                Dim prod As New BE.ProductoBE
                prod.id = item.Item(2)
                prod.descripcion = item.Item(3)
                lista.producto = prod

                list.Add(lista)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Sub altaDetallesListaPrecio(listaPrecio As ListaPrecioBE)
        Dim repository As AccesoSQLServer
        Dim id As Integer
        For Each a As BE.ListaPrecioDetalleBE In listaPrecio.detalles
            repository = New AccesoSQLServer
            Try
                repository.crearComando("ALTA_LISTA_PRECIO_DETALLE_SP")
                repository.addParam("@id", listaPrecio.id)
                repository.addParam("@fecha", listaPrecio.fechaDesde)
                repository.addParam("@precio", a.precio)
                repository.addParam("@prod", a.producto.id)
                id = repository.executeSearchWithStatus
                If (id = 0) Then
                    Throw New Util.CreacionException
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Next
    End Sub

    Shared Sub cerrarVigencia(listaPrecio As ListaPrecioBE)
        Dim id As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CERRAR_VIGENCIA_LISTA_PRECIO_SP")
            repository.addParam("@id", listaPrecio.id)
            repository.addParam("@fecha", listaPrecio.fechaDesde)
            id = repository.executeSearchWithStatus
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub altaPromocion(idProd As Integer, precio As Decimal, desde As Date, hasta As Date)
        Dim repository As AccesoSQLServer
        Dim id As Integer
        repository = New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PROMOCION_SP")
            repository.addParam("@id", idProd)
            repository.addParam("@precio", precio)
            repository.addParam("@desde", desde)
            repository.addParam("@hasta", hasta)
            id = repository.executeSearchWithStatus
            If (id = 0) Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class ' ListaPrecioDAL

