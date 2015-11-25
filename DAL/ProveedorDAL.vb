Imports BE


Public Class ProveedorDAL

    
    Public Shared Sub altaProveedor(ByRef prov As ProveedorBE)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PROVEEDOR_SP")
            repository.addParam("@raz", prov.razonSocial)
            repository.addParam("@mail", prov.mail)
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@con", prov.contacto)

            id = repository.executeWithReturnValue

            If Not prov.productos Is Nothing Then
                For Each a As BE.ProductoBE In prov.productos
                    repository = New AccesoSQLServer
                    Try
                        repository.crearComando("ALTA_PRODUCTO_PROVEEDOR_SP")
                        repository.addParam("@id", id)
                        repository.addParam("@idProducto", a.id)
                        repository.addParam("@precio", a.precio)
                        repository.executeWithReturnValue()
                    Catch ex As Exception
                        Throw ex
                    End Try
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try

        prov.id = id
    End Sub

    Public Shared Sub modificarProveedor(ByVal prov As ProveedorBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_PROVEEDOR_SP")
            repository.addParam("@id", prov.id)
            repository.addParam("@raz", prov.razonSocial)
            repository.addParam("@mail", prov.mail)
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@con", prov.contacto)

            repository.executeWithReturnValue()

            repository.crearComando("ELIMINAR_PRODUCTO_PROVEEDOR_SP")
            repository.addParam("@id", prov.id)
            repository.executeWithReturnValue()

            For Each a As BE.ProductoBE In prov.productos
                repository = New AccesoSQLServer
                Try
                    repository.crearComando("ALTA_PRODUCTO_PROVEEDOR_SP")
                    repository.addParam("@id", prov.id)
                    repository.addParam("@idProducto", a.id)
                    repository.addParam("@precio", a.precio)
                    repository.executeWithReturnValue()
                Catch ex As Exception
                    Throw ex
                End Try
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function listarProveedores() As List(Of BE.ProveedorBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProveedorBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_PROVEEDORES_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim prov As New BE.ProveedorBE
                prov.id = item.Item(0)
                prov.razonSocial = item.Item(1)

                list.Add(prov)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return list
    End Function

    Shared Function buscarProveedores(nom As String, contacto As String) As List(Of ProveedorBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProveedorBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PROVEEDORES_SP")
            repository.addParam("@nom", nom)
            repository.addParam("@con", contacto)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                'p.id, P.razonSocial, P.cuil, P.mail, p.activo, p.contacto, t.id, t.numero, t.prefijo, t.interno, d.id, d.calle, d.numero, d.dpto, d.piso, d.idLocalidad, l.idProvincia
                Dim prov As New BE.ProveedorBE
                prov.id = item.Item(0)
                prov.razonSocial = item.Item(1)
                prov.cuit = item.Item(2)
                prov.mail = item.Item(3)
                prov.activo = item.Item(4)
                prov.contacto = item.Item(5)
                prov.tel.id = item.Item(6)
                prov.tel.numero = item.Item(7)
                prov.tel.prefijo = item.Item(8)
                prov.tel.interno = item.Item(9)
                prov.dom.id = item.Item(10)
                prov.dom.calle = item.Item(11)
                prov.dom.numero = item.Item(12)
                prov.dom.dpto = item.Item(13)
                prov.dom.piso = item.Item(14)
                prov.dom.localidad.id = item.Item(15)
                prov.dom.localidad.provincia.id = item.Item(16)

                list.Add(prov)
            Next

            Return list
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function getProductos(prov As ProveedorBE) As List(Of ProductoBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProductoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PRODUCTOS_PROVEEDORES_SP")
            repository.addParam("@id", prov.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
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
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Sub eliminarProveedor(id As Integer)
        Dim resultado As Integer
        
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ELIMINAR_PROVEEDOR_SP")
            repository.addParam("@id", id)
            resultado = repository.executeSearchWithStatus()
            If (resultado <> 1) Then
                Throw New Util.EliminacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkCuilExistente(prov As ProveedorBE)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_CUIL_PROVEEDOR_SP")
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@id", prov.id)
            resultado = repository.executeWithReturnValue
            If (resultado >= 1) Then
                Throw New Util.CuitExistenteException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkProveedorProductosVenta(id As Integer)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_PROVEEDOR_PRODUCTOS_VENTA_SP")
            repository.addParam("@id", id)
            resultado = repository.executeWithReturnValue
            If (resultado >= 1) Then
                Throw New Util.ProveedorProductosEnVentaException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkProveedorProductosStock(id As Integer)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_PROVEEDOR_PRODUCTOS_STOCK_SP")
            repository.addParam("@id", id)
            resultado = repository.executeWithReturnValue
            If (resultado >= 1) Then
                Throw New Util.ProductosEnStockException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub agregarObservacionProv(id As Integer, ob As String, usr As UsuarioBE)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("AGREGAR_OBSERVACION_PROV_SP")
            repository.addParam("@id", id)
            repository.addParam("@ob", ob)
            repository.addParam("@usr", usr.id)
            resultado = repository.executeSearchWithStatus()
            If (resultado = 0) Then
                Throw New Util.CreacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getProveedoresPorProducto(p1 As Integer) As List(Of ProveedorBE)
        Dim table As DataTable
        Dim list As New List(Of BE.ProveedorBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PROVEEDORES_PROD_SP")
            repository.addParam("@idProd", p1)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Dim prov As New BE.ProveedorBE
                't.id, t.razonSocial, t.contacto, t.cuil, t.telefono, t.direccion
                prov.id = item.Item(0)
                prov.razonSocial = item.Item(1)
                prov.contacto = item.Item(2)
                prov.cuit = item.Item(3)
                prov.mail = item.Item(4)
                prov.activo = item.Item(5)

                prov.dom.id = item.Item(6)
                prov.dom.calle = item.Item(7)
                prov.dom.numero = item.Item(8)
                prov.dom.dpto = item.Item(9)
                prov.dom.piso = item.Item(10)
                prov.dom.localidad.id = item.Item(11)
                prov.dom.localidad.descripcion = item.Item(12)
                prov.dom.localidad.provincia.id = item.Item(13)

                list.Add(prov)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return list
    End Function

    Shared Function getPrecioProductoProveedor(idProd As Integer, idProv As Integer) As Decimal
        Dim table As DataTable
        Dim list As New List(Of BE.ProveedorBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PRECIO_PROVEEDORES_PROD_SP")
            repository.addParam("@idProd", idProd)
            repository.addParam("@idProv", idProv)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each item As DataRow In table.Rows
                Return item.Item(0)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Shared Sub altaDomicilio(ByRef prov As ProveedorBE)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_DOMICILIO_PROV_SP")
            repository.addParam("@usr", prov.id)
            repository.addParam("@calle", prov.dom.calle)
            repository.addParam("@nro", prov.dom.numero)
            repository.addParam("@piso", prov.dom.piso)
            repository.addParam("@dpto", prov.dom.dpto)
            repository.addParam("@loc", prov.dom.localidad.id)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        prov.dom.id = id
    End Sub

    Shared Sub altaTelefono(ByRef prov As ProveedorBE)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_TELEFONO_PROV_SP")
            repository.addParam("@usr", prov.id)
            repository.addParam("@num", prov.tel.numero)
            repository.addParam("@int", prov.tel.interno)
            repository.addParam("@pre", prov.tel.prefijo)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        prov.tel.id = id
    End Sub

    Shared Function getObservaciones(idProveedor As Integer) As DataTable
        Dim table As DataTable
        Dim list As New List(Of BE.ComparacionProductos)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_OBS_PROV_SP")
            repository.addParam("@id", idProveedor)
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

End Class

