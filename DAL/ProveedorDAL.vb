Imports BE


Public Class ProveedorDAL


    ''' 
    ''' <param name="prov"></param>
    Public Shared Function altaProveedor(ByVal prov As ProveedorBE) As Integer
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_PROVEEDOR_SP")
            repository.addParam("@raz", prov.razonSocial)
            repository.addParam("@mail", prov.mail)
            repository.addParam("@tel", prov.tel)
            repository.addParam("@cuit", prov.cuit)
            repository.addParam("@dir", prov.direccion)
            
            id = repository.executeWithReturnValue

            For Each a As BE.ProductoBE In prov.productos
                repository = New AccesoSQLServer
                Try
                    repository.crearComando("ALTA_PROVEEDOR_PRODUCTO_SP")
                    repository.addParam("@idProv", id)
                    repository.addParam("@idProd", a.id)
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

    ''' 
    ''' <param name="prod"></param>
    ''' <param name="prov"></param>
    Public Shared Sub asociarProvProd(ByVal prod As ProductoBE, ByVal prov As ProveedorBE)

    End Sub

    ''' 
    ''' <param name="proveedor"></param>
    Public Shared Sub bajaProveedor(ByVal proveedor As ProveedorBE)

    End Sub

    ''' 
    ''' <param name="prov"></param>
    Public Shared Function buscarProveedor(ByVal prov As ProveedorBE) As List(Of ProveedorBE)
        buscarProveedor = Nothing
    End Function

    ''' 
    ''' <param name="prov"></param>
    Public Shared Function checkProvExist(ByVal prov As ProveedorBE) As Boolean
        checkProvExist = False
    End Function

    ''' 
    ''' <param name="prov"></param>
    Public Shared Function checkProvUtilizado(ByVal prov As ProveedorBE) As Boolean
        checkProvUtilizado = False
    End Function

    ''' 
    ''' <param name="proveedor"></param>
    Public Shared Sub modificarProveedor(ByVal proveedor As ProveedorBE)

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


End Class

