Imports BE

Public Class GestorResguardoBLL
    Public Shared Function buscarBackups() As List(Of BackupBE)
        Return DAL.GestorResguardoDAL.listarBackups()
    End Function

    Public Shared Sub realizarBackup(ByVal usr As BE.UsuarioBE, ByVal nombre As String)
        DAL.GestorResguardoDAL.BackUp(nombre)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.BackupGenerado)
    End Sub

    Public Shared Sub realizarRestore(ByVal usr As BE.UsuarioBE, ByVal backupId As Integer)
        Dim back As BE.BackupBE = Nothing
        back = DAL.GestorResguardoDAL.buscarBackup(backupId)
        DAL.GestorResguardoDAL.Restore(back.path)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.BackupRestaurado)
    End Sub
End Class
