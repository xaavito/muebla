Imports BE
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing


Public Class ProductoDAL


    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)
        'WHO KNOWS!
    End Sub

    Public Shared Sub altaProducto(ByVal producto As ProductoBE)
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PRODUCTO_SP")
            repository.addParam("@des", producto.descripcion)
            repository.addParam("@bDes", producto.breveDescripcion)
            repository.addParam("@tipo", producto.tipoProducto.id)
            repository.addParam("@sto", producto.stock)
            repository.addParam("@stomin", producto.stockMin)
            repository.addParam("@prov", producto.proveedor.id)
            repository.addParam("@img", producto.image1)
            id = repository.executeWithReturnValue
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
        producto.id = id
        altaProductoCompuesto(producto)
    End Sub

    Public Shared Function bajaProducto(ByVal producto As BE.ProductoBE) As Integer
        Dim ret As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BAJA_PRODUCTO_SP")
            repository.addParam("@id", producto.id)
            ret = repository.executeSearchWithStatus
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function

    Public Shared Function buscarProductos(ByVal tipo As Integer, ByVal nombre As String) As List(Of BE.ProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PRODUCTOS_SP")
            repository.addParam("@tipo", tipo)
            repository.addParam("@nom", nombre)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.ProductoBE
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)
                producto.breveDescripcion = item.Item(4)
                Dim tipoProd As New BE.TipoProductoBE
                tipoProd.id = item.Item(2)
                tipoProd.descripcion = item.Item(3)
                producto.tipoProducto = tipoProd
                producto.baja = item.Item(5)
                list.Add(producto)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return list
    End Function

    Public Shared Function buscarProducto(ByVal id As Integer) As BE.ProductoBE
        Dim table As DataTable
        Dim producto As New BE.ProductoBE

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PRODUCTO_SP")
            repository.addParam("@id", id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                Throw New Util.BusquedaConMuchosResultadosException
            End If
            For Each item As DataRow In table.Rows
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)
                producto.breveDescripcion = item.Item(4)
                Dim tipoProd As New BE.TipoProductoBE
                tipoProd.id = item.Item(2)
                tipoProd.descripcion = item.Item(3)
                producto.tipoProducto = tipoProd
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return producto
    End Function

    Public Shared Function checkProductoEnPedidos(ByVal producto As ProductoBE) As Boolean
        Dim ret As Integer
        Try
            Dim repository As New AccesoSQLServer
            repository.crearComando("CHECK_PRODUCTO_PEDIDO_SP")
            repository.addParam("@id", producto.id)
            ret = repository.executeWithReturnValue
            If ret = 1 Then
                Throw New Util.PedidosEnProceso
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub modificarProducto(ByVal producto As ProductoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_PRODUCTO_SP")
            repository.addParam("@id", producto.id)
            repository.addParam("@desc", producto.descripcion)
            repository.addParam("@descBreve", producto.breveDescripcion)
            repository.addParam("@sto", producto.stock)
            repository.addParam("@stomin", producto.stockMin)
            id = repository.executeSearchWithStatus
            If (id = 0) Then
                Throw New Util.ModificarException
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function listarProductos() As List(Of ListaPrecioDetalleBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_PRODUCTOS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.ProductoBE
                Dim lpd As New BE.ListaPrecioDetalleBE
                Dim lp As New BE.ListaPrecioBE
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)
                producto.breveDescripcion = item.Item(6)

                producto.image1 = (DirectCast(item.Item(2), Byte()))
                lpd.precio = item.Item(3)
                lpd.id = item.Item(4)
                lp.id = item.Item(5)
                lp.promo = item.Item(7)
                lpd.listaPrecio = lp
                lpd.producto = producto
                list.Add(lpd)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Function getImagenProducto(idInt As Integer) As Byte()
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("GET_PRODUCTO_IMAGEN_SP")
            repository.addParam("@ID", idInt)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                Throw New Util.BusquedaConMuchosResultadosException
            End If
            For Each item As DataRow In table.Rows
                Return (DirectCast(item.Item(0), Byte()))
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Shared Function getTipoProductos() As List(Of TipoProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.TipoProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_TIPO_PRODUCTOS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.TipoProductoBE
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)

                list.Add(producto)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Function buscarProductoCompuesto(id As Integer) As List(Of ProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PRODUCTO_COMPUESTO_SP")
            repository.addParam("@id", id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.ProductoBE
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)

                list.Add(producto)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Sub eliminarProductoCompuesto(producto As ProductoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ELIMINAR_PRODUCTO_COMPUESTO_SP")
            repository.addParam("@id", producto.id)
            id = repository.executeSearchWithStatus
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub altaProductoCompuesto(producto As ProductoBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer

        For Each a As BE.ProductoBE In producto.productos
            repository = New AccesoSQLServer
            Try
                repository.crearComando("ALTA_PRODUCTO_COMPUESTO_SP")
                repository.addParam("@id", producto.id)
                repository.addParam("@idCompuesto", a.id)
                id = repository.executeWithReturnValue()
            Catch ex As Exception
                Throw ex
            End Try
        Next
    End Sub

    Shared Function listarPromos() As List(Of ListaPrecioDetalleBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_PROMOS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.ProductoBE
                Dim lpd As New BE.ListaPrecioDetalleBE
                Dim lp As New BE.ListaPrecioBE
                producto.id = item.Item(0)
                producto.descripcion = item.Item(1)
                producto.breveDescripcion = item.Item(6)

                producto.image1 = (DirectCast(item.Item(2), Byte()))
                lpd.precio = item.Item(3)
                lpd.id = item.Item(4)
                lp.id = item.Item(5)
                lp.promo = item.Item(7)
                lpd.listaPrecio = lp
                lpd.producto = producto
                list.Add(lpd)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Function getComparacion(p1 As Integer) As List(Of ComparacionProductos)
        Dim table As DataTable
        Dim list As New List(Of BE.ComparacionProductos)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("COMPARACION_PRODUCTO_SP")
            repository.addParam("@id", p1)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim producto As New BE.ComparacionProductos
               
                producto.proveedor = item.Item(0)
                producto.valor = item.Item(1)
                list.Add(producto)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Function generarOrdenCompra(oc As OrdenCompraBE) As Integer
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_ORDEN_COMPRA_SP")
            repository.addParam("@prov", oc.proveedor.id)
            repository.addParam("@fecha", oc.fecha)
            id = repository.executeWithReturnValue
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return id
    End Function

    Shared Sub generarOrdenCompraDetalles(oc As OrdenCompraBE)
        Dim id As Integer
        Dim list As New List(Of BE.ProductoBE)

        Try
            For Each ocd As OrdenCompraDetalleBE In oc.detalle
                Dim repository As New AccesoSQLServer
                repository.crearComando("ALTA_ORDEN_COMPRA_DETALLE_SP")

                repository.addParam("@id", oc.id)
                repository.addParam("@prod", ocd.producto.id)
                repository.addParam("@precio", ocd.precioUnitario)
                repository.addParam("@cant", ocd.cantidad)

                id = repository.executeSearchWithStatus
            Next
            
            If id = 0 Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkProveedorAlDia(proveedor As ProveedorBE)
        Dim id As Integer
        Try
            Dim repository As New AccesoSQLServer
            repository.crearComando("CHECK_PROV_AL_DIA_SP")
            repository.addParam("@id", proveedor.id)
            id = repository.executeWithReturnValue
            If id = 1 Then
                Throw New Util.ProveedorDeudor
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getDetalleProducto(idProducto As Integer) As DataTable
        Dim table As DataTable
        Dim list As New List(Of BE.ComparacionProductos)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_DETALLE_PRODUCTO_SP")
            repository.addParam("@id", idProducto)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return table
    End Function

End Class ' ProductoDAL

