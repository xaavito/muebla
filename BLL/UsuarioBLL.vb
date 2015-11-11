Imports BE

Public Class UsuarioBLL
    Public Shared Function altaCliente(ByVal usr As UsuarioBE)
        'TODO ENCRIPTAR PASS?
        DAL.UsuarioDAL.checkUsr(usr)
        DAL.UsuarioDAL.checkMail(usr)
        usr.id = DAL.UsuarioDAL.altaCliente(usr)
        usr.domicilio.id = DAL.UsuarioDAL.altaDomicilio(usr)
        usr.telefono.id = DAL.UsuarioDAL.altaTelefono(usr)
        Util.Mailer.enviarMail(usr.mail, "Alta de Usuario en el sistema", "Bienvenido/a" + usr.usuario + " ya puede empezar a operar con Muebla")
        Return usr
    End Function

    Public Shared Sub altaUsuario(ByVal usr As UsuarioBE)
        DAL.UsuarioDAL.checkMail(usr)
        usr.id = DAL.UsuarioDAL.altaUsuario(usr)
        For Each a As BE.RolBE In usr.roles
            DAL.UsuarioDAL.modificarPermisoUsuario(usr.id, a)
        Next
    End Sub

    Public Shared Function buscarUsuarios(ByVal usuario As String, ByVal mail As String) As List(Of BE.UsuarioBE)
        Return DAL.UsuarioDAL.buscarUsuarios(usuario, mail)
    End Function

    Public Shared Sub eliminarUsuario(ByVal usr As UsuarioBE)
        BLL.UsuarioBLL.checkEstadoActivo(usr)
        BLL.UsuarioBLL.checkNoEsAdmin(usr)
        DAL.UsuarioDAL.eliminarUsuario(usr)
    End Sub

    Public Shared Function login(ByVal pass As String, ByVal usr As String) As UsuarioBE
        'TODO ENCRIPTAR PASS?
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
            user.idioma.mensajes = BLL.GestorIdiomaBLL.buscarMensajes(user.idioma)
            BLL.GestorBitacoraBLL.registrarEvento(user, Util.Enumeradores.Bitacora.LogueoExitoso)
        End If
        Return user
    End Function

    Public Shared Sub modificarCliente(ByVal usr As UsuarioBE)
        'Y ESTO??? NO FALTA ALGO ACA???
    End Sub

    Public Shared Sub modificarUsuario(ByRef usr As UsuarioBE)
        DAL.UsuarioDAL.modificarPass(usr)
        DAL.UsuarioDAL.modificarDomicilio(usr)
        DAL.UsuarioDAL.modificartelefono(usr)
        Util.Mailer.enviarMail(usr.mail, "Modificacion de datos", "Ya sabes")
    End Sub

    Public Shared Function solicitarContrase�a(ByVal mail As String, ByVal usuario As String) As String
        'TODO ENCRIPTAR PASS?
        Dim pass As String = DAL.UsuarioDAL.solicitarContrasena(mail, usuario)
        Util.Mailer.enviarMail(mail, "Recuperar Contrasena Muebla", "Usuario su mail es " + pass)
        Throw New Util.MailEnviadoseException
        Return pass
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

    Shared Sub llenarDatosBlandosUsuario(ByRef usuarioBE As UsuarioBE)
        DAL.UsuarioDAL.llenarDatosBlandosUsuario(usuarioBE)
    End Sub

    Shared Sub checkPreModificacion(usuarioBE As UsuarioBE)
        DAL.UsuarioDAL.checkPreModificacion(usuarioBE)
    End Sub

    Private Shared Sub checkEstadoActivo(usr As UsuarioBE)
        If usr.activo = False Then
            Throw New Util.UsuarioInactivo
        End If
    End Sub

    Private Shared Sub checkNoEsAdmin(usr As UsuarioBE)
        usr.roles = DAL.GestorRolesDAL.getRoles(usr)
        If usr.isAdmin Then
            Throw New Util.UsuarioAdmin
        End If
    End Sub

    Shared Sub checkAdminPermiso(p1 As String)
        If Integer.Parse(p1) = 1 Then
            Throw New Util.UsuarioAdmin
        End If
    End Sub

End Class ' UsuarioBLL
