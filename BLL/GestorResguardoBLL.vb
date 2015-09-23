Imports BE


Public Class GestorResguardoBLL

    Public Shared Function buscarBackups() As List(Of BackupBE)
        Return DAL.GestorResguardoDAL.listarBackups()
    End Function

    ''' 
    ''' <param name="nombre"></param>
    Public Shared Sub realizarBackup(ByVal nombre As String)
        DAL.GestorResguardoDAL.BackUp(nombre)
    End Sub

    Public Shared Sub realizarRestore(ByVal backupId As Integer)
        Dim back As BE.BackupBE = Nothing
        Try
            back = DAL.GestorResguardoDAL.buscarBackup(backupId)
        Catch ex As Exception
            Throw ex
        End Try
        DAL.GestorResguardoDAL.Restore(back.path)
    End Sub


End Class
