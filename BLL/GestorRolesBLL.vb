Imports BE


Public Class GestorRolesBLL


    ''' 
    ''' <param name="roles"></param>
    ''' <param name="usr"></param>
    Public Shared Sub asignarRoles(ByVal roles As RolBE, ByVal usr As UsuarioBE)

    End Sub

    Public Shared Function buscarRoles() As List(Of RolBE)
        Return DAL.GestorRolesDAL.buscarRoles()
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Function getRoles(ByVal usr As UsuarioBE) As List(Of RolBE)
        Return DAL.GestorRolesDAL.getRoles(usr)
    End Function


End Class ' GestorRolesBLL
