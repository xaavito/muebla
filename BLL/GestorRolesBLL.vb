Imports BE


Public Class GestorRolesBLL

    Public Shared Function buscarRoles() As List(Of RolBE)
        Return DAL.GestorRolesDAL.buscarRoles()
    End Function

    Public Shared Function getRoles(ByVal usr As UsuarioBE) As List(Of RolBE)
        Return DAL.GestorRolesDAL.getRoles(usr)
    End Function


End Class ' GestorRolesBLL
