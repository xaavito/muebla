'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  GestorResguardoBLL.vb
''  Implementation of the Class GestorResguardoBLL
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:42:21
''  Original author: Javier
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On

Imports BE


Public Class GestorResguardoBLL


    Public Shared Function buscarBackups() As List(Of BackupBE)
        buscarBackups = Nothing
    End Function

    ''' 
    ''' <param name="nombre"></param>
    Public Shared Sub realizarBackup(ByVal nombre As String)

    End Sub

    ''' 
    ''' <param name="backup"></param>
    Public Shared Sub realizarRestore(ByVal backup As BackupBE)

    End Sub


End Class ' GestorResguardoBLL
