Imports BE

Public Class UsuarioBLL
    Public Shared Function altaCliente(ByVal usr As UsuarioBE)
        usr.id = DAL.UsuarioDAL.altaCliente(usr)
        usr.domicilio.id = DAL.UsuarioDAL.altaDomicilio(usr)
        usr.telefono.id = DAL.UsuarioDAL.altaTelefono(usr)
        Util.Mailer.sendMail(usr.mail, "Alta de Usuario en el sistema", "Bienvenido/a" + usr.usuario + " ya puede empezar a operar con Muebla")
        Return usr
    End Function

    Public Shared Sub altaUsuario(ByVal usr As UsuarioBE)

    End Sub

    Public Shared Function buscarUsuarios(ByVal usuario As String, ByVal tipo As Int16, ByVal mail As String) As List(Of BE.UsuarioBE)
        Return DAL.UsuarioDAL.buscarUsuarios(tipo, usuario, mail)
    End Function

    Public Shared Sub eliminarUsuario(ByVal usr As UsuarioBE)

    End Sub

    Public Shared Function login(ByVal pass As String, ByVal usr As String) As UsuarioBE
        Dim user As BE.UsuarioBE
        Try
            user = DAL.UsuarioDAL.login(pass, usr)
        Catch ex As Util.BusquedaSinResultadosException
            Throw New Util.UsuarioNoEncontradoException
        End Try

        If Not user Is Nothing Then
            user.roles = BLL.GestorRolesBLL.getRoles(user)
            For Each rol As BE.RolBE In user.roles
                rol.componentes = DAL.UsuarioDAL.buscarPermisos(rol)
            Next
            user.idioma.componentes = BLL.GestorIdiomaBLL.buscarComponentes(user.idioma)
            BLL.GestorBitacoraBLL.registrarEvento(user, Util.Enumeradores.Bitacora.LogueoExitoso)
        End If
        Return user
    End Function

    Public Shared Sub modificarCliente(ByVal usr As UsuarioBE)

    End Sub

    Public Shared Sub modificarUsuario(ByVal usr As UsuarioBE)

    End Sub

    Public Shared Function solicitarContraseña(ByVal mail As String, ByVal usuario As String) As String
        Dim pass As String = DAL.UsuarioDAL.solicitarContrasena(mail, usuario)
        If Not pass Is Nothing Then
            Util.Mailer.sendMail(mail, "Recuperar Contrasena Muebla", "Usuario su mail es " + pass)
        End If
        Return pass
    End Function

    Shared Function getTiposUsuarios() As List(Of BE.TipoUsuarioBE)
        Return DAL.UsuarioDAL.getTiposUsuarios()
    End Function

    Shared Function getTiposDocumentos() As List(Of BE.TipoDocumentoBE)
        Return DAL.UsuarioDAL.getTiposDocumentos
    End Function

    Shared Function getProvincias() As List(Of BE.ProvinciaBE)
        Return DAL.UsuarioDAL.getProvincias
    End Function

    Shared Function getTiposLocalidades(p1 As Integer) As Object
        Return DAL.UsuarioDAL.getLocalidades(p1)
    End Function

    Shared Sub modificarUsuario(idUsuario As Integer, roles As List(Of BE.RolBE), estado As Boolean)
        DAL.UsuarioDAL.modificarUsuario(idUsuario, estado)
        DAL.UsuarioDAL.borrarPermisos(idUsuario)
        For Each rol As BE.RolBE In roles
            DAL.UsuarioDAL.modificarPermisoUsuario(idUsuario, rol)
        Next
        BLL.GestorBitacoraBLL.registrarEvento(idUsuario, Util.Enumeradores.Bitacora.ModificacionUsuario)
        Throw New Util.ModificacionExitosaException
    End Sub

    Shared Sub llenarDatosUsuario(ByRef usuario As UsuarioBE)
        DAL.UsuarioDAL.buscarDomicilioUsuario(usuario)
        DAL.UsuarioDAL.buscarTelefono(usuario)
    End Sub


End Class ' UsuarioBLL
