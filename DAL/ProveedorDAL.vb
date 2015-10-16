Imports BE


Public Class ProveedorDAL


    Public Shared Function altaProveedor(ByVal prov As ProveedorBE) As Integer
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PROVEEDOR_SP")
            repository.addParam("@raz", prov.razonSocial)
            repository.addParam("@mail", prov.mail)
            repository.addParam("@tel", prov.telefono)
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@dir", prov.direccion)
            repository.addParam("@con", prov.contacto)
            
            id = repository.executeWithReturnValue

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
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Public Shared Sub asociarProvProd(ByVal prod As ProductoBE, ByVal prov As ProveedorBE)

    End Sub

    Public Shared Sub bajaProveedor(ByVal proveedor As ProveedorBE)

    End Sub

    Public Shared Function buscarProveedor(ByVal prov As ProveedorBE) As List(Of ProveedorBE)
        buscarProveedor = Nothing
    End Function

    Public Shared Function checkProvExist(ByVal prov As ProveedorBE) As Boolean
        checkProvExist = False
    End Function

    Public Shared Function checkProvUtilizado(ByVal prov As ProveedorBE) As Boolean
        checkProvUtilizado = False
    End Function

    Public Shared Sub modificarProveedor(ByVal prov As ProveedorBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_PROVEEDOR_SP")
            repository.addParam("@id", prov.id)
            repository.addParam("@raz", prov.razonSocial)
            repository.addParam("@mail", prov.mail)
            repository.addParam("@tel", prov.telefono)
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@dir", prov.direccion)
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
                Dim prov As New BE.ProveedorBE
                prov.id = item.Item(0)
                prov.razonSocial = item.Item(1)
                prov.cuit = item.Item(2)
                prov.mail = item.Item(3)
                prov.telefono = item.Item(4)
                prov.direccion = item.Item(5)
                prov.estado = item.Item(6)
                prov.contacto = item.Item(7)

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


End Class

