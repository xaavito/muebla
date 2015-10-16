Imports BE


Public Class GestorRolesDAL


    Public Shared Sub asignarRoles(ByVal roles As RolBE, ByVal usr As UsuarioBE)
    End Sub

    Public Shared Function buscarRoles() As List(Of RolBE)
        Try
            Dim table As DataTable

            Dim repository As New AccesoSQLServer
            repository.crearComando("LISTAR_ROLES_SP")

            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
                '
            End If
            Dim listaRoles As New List(Of BE.RolBE)
            For Each pepe As DataRow In table.Rows
                Dim rol As New BE.RolBE
                rol.id = pepe.Item(0)
                rol.descripcion = pepe.Item(1)

                listaRoles.Add(rol)
            Next

            Return listaRoles
        Catch ex As Exception
            Throw ex
        End Try
        
    End Function

    Public Shared Function getRoles(ByVal usr As UsuarioBE) As List(Of RolBE)
        Try
            Dim table As DataTable

            Dim repository As New AccesoSQLServer

            repository.crearComando("BUSCAR_ROLES_SP")
            repository.addParam("@usr", usr.id)

            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <> 1) Then
            End If
            Dim listaRoles As New List(Of BE.RolBE)
            For Each pepe As DataRow In table.Rows
                Dim rol As New BE.RolBE
                rol.id = pepe.Item(0)
                rol.descripcion = pepe.Item(1)

                listaRoles.Add(rol)
            Next

            Return listaRoles
        Catch ex As Exception
            Throw ex
        End Try
        
    End Function


End Class ' GestorRolesDAL

