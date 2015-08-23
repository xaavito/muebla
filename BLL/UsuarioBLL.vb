'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  UsuarioBLL.vb
''  Implementation of the Class UsuarioBLL
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:42:24
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


Public Class UsuarioBLL


    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub altaCliente(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub altaUsuario(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="usuario"></param>
    ''' <param name="tipo"></param>
    ''' <param name="mail"></param>
    Public Shared Sub buscarUsuarios(ByVal usuario As String, ByVal tipo As TipoUsuarioBE, ByVal mail As Single)

    End Sub

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub eliminarUsuario(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="pass"></param>
    ''' <param name="usr"></param>
    Public Shared Function login(ByVal pass As String, ByVal usr As String) As UsuarioBE
        Dim user As BE.UsuarioBE
        user = DAL.UsuarioDAL.login(pass, usr)
        If Not user Is Nothing Then
            user.roles = BLL.GestorRolesBLL.getRoles(user)
            For Each rol As BE.RolBE In user.roles
                rol.componentes = DAL.UsuarioDAL.buscarPermisos(rol)
            Next
            user.idioma.componentes = BLL.GestorIdiomaBLL.buscarComponentes(user.idioma)
        End If
        Return user
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub modificarCliente(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub modificarUsuario(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="mail"></param>
    ''' <param name="usuario"></param>
    Public Shared Sub solicitarContraseņa(ByVal mail As String, ByVal usuario As String)

    End Sub


End Class ' UsuarioBLL
