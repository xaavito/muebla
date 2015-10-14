Imports BE


Public Class ListaPrecioDAL


    ''' 
    ''' <param name="listaPrecio"></param>
    Public Shared Sub altaListaPrecio(ByVal listaPrecio As ListaPrecioBE)

    End Sub

    ''' 
    ''' <param name="listaPrecio"></param>
    ''' <param name="descuento"></param>
    ''' <param name="desde"></param>
    Public Shared Sub altaPromocion(ByVal listaPrecio As ListaPrecioBE, ByVal descuento As Integer, ByVal desde As DateTime)

    End Sub

    ''' 
    ''' <param name="tipo"></param>
    ''' <param name="activo"></param>
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

    ''' 
    ''' <param name="fecha"></param>
    ''' <param name="tipoVenta"></param>
    Public Shared Function checkListaVigente(ByVal fecha As DateTime, ByVal tipoVenta As TipoVentaBE) As Boolean
        checkListaVigente = False
    End Function

    ''' 
    ''' <param name="desde"></param>
    ''' <param name="aumento"></param>
    ''' <param name="tipoAumento"></param>
    Public Shared Sub modificarListaPrecio(ByVal desde As DateTime, ByVal aumento As Integer, ByVal tipoAumento As Boolean)

    End Sub

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


End Class ' ListaPrecioDAL

