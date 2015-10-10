Imports BE
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing


Public Class ProductoDAL


    ''' 
    ''' <param name="prod"></param>
    ''' <param name="cant"></param>
    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Function altaProducto(ByVal producto As ProductoBE) As Integer
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

        For Each a As BE.ProductoBE In producto.productos
            repository = New AccesoSQLServer
            Try
                repository.crearComando("ALTA_PRODUCTO_COMPUESTO_SP")
                repository.addParam("@id", id)
                repository.addParam("@idCompuesto", a.id)
                id = repository.executeWithReturnValue
            Catch ex As Exception
                Throw ex
            End Try
        Next
        Return id
    End Function

    ''' 
    ''' <param name="producto"></param>
    Public Shared Function bajaProducto(ByVal producto As Integer) As Integer
        Dim ret As Integer
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BAJA_PRODUCTO_SP")
            repository.addParam("@id", producto)
            ret = repository.executeSearchWithStatus
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Public Shared Function buscarProductos(ByVal tipo As Integer, ByVal nombre As String) As List(Of BE.ProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        'Try
        repository.crearComando("BUSCAR_PRODUCTOS_SP")
        repository.addParam("@tipo", tipo)
        repository.addParam("@nom", nombre)
        table = New DataTable
        table = repository.executeSearchWithAdapter()
        If (table.Rows.Count <> 1) Then
            'Throw New Excepciones.UsuarioNoEncontradoExcepcion
        End If
        For Each item As DataRow In table.Rows
            Dim producto As New BE.ProductoBE
            producto.id = item.Item(0)
            producto.descripcion = item.Item(1)
            Dim tipoProd As New BE.TipoProductoBE
            tipoProd.id = item.Item(2)
            tipoProd.descripcion = item.Item(3)
            producto.tipoProducto = tipoProd
            list.Add(producto)
        Next

        Return list
    End Function

    Public Shared Function buscarProducto(ByVal id As Integer) As BE.ProductoBE
        Dim table As DataTable
        Dim producto As New BE.ProductoBE

        Dim repository As New AccesoSQLServer
        'Try
        repository.crearComando("BUSCAR_PRODUCTO_SP")
        repository.addParam("@id", id)
        table = New DataTable
        table = repository.executeSearchWithAdapter()
        If (table.Rows.Count <> 1) Then
            'Throw New Excepciones.UsuarioNoEncontradoExcepcion
        End If
        For Each item As DataRow In table.Rows
            producto.id = item.Item(0)
            producto.descripcion = item.Item(1)
            Dim tipoProd As New BE.TipoProductoBE
            tipoProd.id = item.Item(2)
            tipoProd.descripcion = item.Item(3)
            producto.tipoProducto = tipoProd
        Next

        Return producto
    End Function

    ''' 
    ''' <param name="producto"></param>
    Public Shared Function checkProductoEnPedidos(ByVal producto As ProductoBE) As Boolean
        checkProductoEnPedidos = False
    End Function

    ''' 
    ''' <param name="prod"></param>
    Public Sub compararCosto(ByVal prod As ProductoBE)

    End Sub

    ''' 
    ''' <param name="prod"></param>
    Public Shared Sub generarOrdenCompra(ByVal prod As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub modificarProducto(ByVal producto As ProductoBE)

    End Sub

    Shared Function listarProductos() As List(Of ListaPrecioDetalleBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        'Try
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
            lpd.listaPrecio = lp
            lpd.producto = producto
            list.Add(lpd)
        Next

        Return list
    End Function

    Shared Function getImagenProducto(idInt As Integer) As Byte()
        Dim table As DataTable
        Dim list As New List(Of BE.ListaPrecioDetalleBE)

        Dim repository As New AccesoSQLServer
        'Try
        repository.crearComando("GET_PRODUCTO_IMAGEN_SP")
        repository.addParam("@ID", idInt)
        table = New DataTable
        table = repository.executeSearchWithAdapter()
        If (table.Rows.Count <> 1) Then
            'Throw New Excepciones.UsuarioNoEncontradoExcepcion
        End If
        For Each item As DataRow In table.Rows
            Return (DirectCast(item.Item(0), Byte()))
        Next

    End Function

    Shared Function getTipoProductos() As List(Of TipoProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.TipoProductoBE)

        Dim repository As New AccesoSQLServer
        'Try
        repository.crearComando("LISTAR_TIPO_PRODUCTOS_SP")
        table = New DataTable
        table = repository.executeSearchWithAdapter()
        If (table.Rows.Count <> 1) Then
            'Throw New Excepciones.UsuarioNoEncontradoExcepcion
        End If
        For Each item As DataRow In table.Rows
            Dim producto As New BE.TipoProductoBE
            producto.id = item.Item(0)
            producto.descripcion = item.Item(1)

            list.Add(producto)
        Next

        Return list
    End Function


End Class ' ProductoDAL

