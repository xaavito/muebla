Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo

Imports BE
Imports Util


Public Class GestorResguardoDAL

    'TODO buscar path relativo
    Public Shared Sub BackUp(ByVal description As String)
        Dim path As String = "C:\\Prueba"
        Dim fecha As String = DateTime.Now.Day.ToString + "-" + DateTime.Now.Month.ToString + "-" + DateTime.Now.Year.ToString + "-" +
                DateTime.Now.Hour.ToString + "-" + DateTime.Now.Minute.ToString + "-" + DateTime.Now.Second.ToString

        'Dim connectionString As String
        Dim repo As New AccesoSQLServer

        'connectionString = 
        Dim builder As New SqlConnectionStringBuilder(repo.conString)
        Dim connection As New ServerConnection(builder.DataSource)
        Dim sqlServer As New Server(connection)

        Dim bk As New Backup
        bk.Database = builder.InitialCatalog
        bk.Action = BackupActionType.Database
        bk.BackupSetDescription = "BU " & bk.Database
        bk.BackupSetName = bk.Database

        Dim fileName As String = bk.Database + fecha + ".sql"
        bk.Devices.AddDevice(path + "\\" + fileName, DeviceType.File)
        bk.Incremental = False
        bk.LogTruncation = BackupTruncateLogType.Truncate
        Try
            bk.SqlBackup(sqlServer)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim result As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("INSERTAR_BACKUP_SP")

            repository.addParam("@path", path + "\\" + bk.Database + fecha + ".sql")
            repository.addParam("@descripcion", description)
            result = repository.executeSearchWithStatus()
            If (result <= 0) Then
                Throw New CreacionException
            End If

        Catch ex As CreacionException
            Throw New CreacionException
        Catch ex As ConexionImposibleExcepcion
            Throw New ConexionImposibleExcepcion
        End Try
    End Sub


    Public Shared Sub Restore(ByVal path As String)
        Dim repo As New AccesoSQLServer

        Dim builder As New SqlConnectionStringBuilder(repo.conString)
        Dim connection As New ServerConnection(builder.DataSource)
        Dim sqlServer As New Server(connection)

        Dim rs As New Restore
        rs.Database = builder.InitialCatalog
        rs.NoRecovery = False
        rs.Action = BackupActionType.Database
        rs.ReplaceDatabase = True
        rs.Devices.AddDevice(path, DeviceType.File)
        sqlServer.KillAllProcesses(builder.InitialCatalog)
        rs.Wait()
        Try
            rs.SqlRestore(sqlServer)
        Catch ex As Exception
            Throw New CreacionException
        End Try
    End Sub

    Shared Function listarBackups() As List(Of BE.BackupBE)
        Dim table As DataTable

        Dim backups As New List(Of BE.BackupBE)
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_BACKUPS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count <= 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim bu As New BE.BackupBE
                bu.id = pepe.Item(0)
                bu.descripcion = pepe.Item(2)
                If Not IsDBNull(pepe.Item(3)) Then
                    bu.fecha = pepe.Item(3)
                End If
                bu.path = pepe.Item(1)
                backups.Add(bu)
            Next

        Catch ex As EliminarException
            Throw New EliminarException
        Catch ex As ConexionImposibleExcepcion
            Throw New ConexionImposibleExcepcion
        End Try

        Return backups
    End Function

    Shared Function eliminarBackup(ByVal backup As BE.BackupBE) As Integer
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ELIMINAR_BACKUP_SP")
            repository.addParam("@idBackup", backup.id)
            resultado = repository.executeSearchWithStatus
            If (resultado <= 0) Then
                Throw New EliminarException
            End If

        Catch ex As EliminarException
            Throw New EliminarException
        Catch ex As ConexionImposibleExcepcion
            Throw New ConexionImposibleExcepcion
        End Try

        Return resultado
    End Function

    Shared Function buscarBackup(backupId As Integer) As BackupBE
        Dim table As DataTable
        Dim bu As BE.BackupBE = Nothing
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_BACKUP_SP")
            repository.addParam("@id", backupId)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                bu = New BE.BackupBE
                bu.id = pepe.Item(0)
                bu.descripcion = pepe.Item(2)
                If Not IsDBNull(pepe.Item(3)) Then
                    bu.fecha = pepe.Item(3)
                End If
                bu.path = pepe.Item(1)
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return bu
    End Function

End Class ' GestorResguardoDAL

