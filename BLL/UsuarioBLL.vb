Imports BE

Public Class UsuarioBLL
    Public Shared Function altaCliente(ByVal usr As UsuarioBE)
        DAL.UsuarioDAL.checkUsr(usr)
        DAL.UsuarioDAL.checkMail(usr)
        usr.password = Util.Encrypter.EncryptPasswordMD5(usr.password)
        usr.id = DAL.UsuarioDAL.altaCliente(usr)
        usr.domicilio.id = DAL.UsuarioDAL.altaDomicilio(usr)
        usr.telefono.id = DAL.UsuarioDAL.altaTelefono(usr)
        Util.Mailer.enviarMail(usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RegistroExitoso), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RegistroExitosoMensaje))
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.RegistroExistoso)
        Return usr
    End Function

    Public Shared Sub altaUsuario(ByVal usr As UsuarioBE)
        DAL.UsuarioDAL.checkUsr(usr)
        DAL.UsuarioDAL.checkMail(usr)
        usr.password = Util.Encrypter.EncryptPasswordMD5(usr.password)
        usr.id = DAL.UsuarioDAL.altaUsuario(usr)
        For Each a As BE.RolBE In usr.roles
            DAL.UsuarioDAL.modificarPermisoUsuario(usr.id, a)
        Next
        Util.Mailer.enviarMail(usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RegistroExitoso), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RegistroExitosoMensaje))
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.RegistroExistoso)
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
        Dim user As BE.UsuarioBE
        Try
            user = DAL.UsuarioDAL.login(Util.Encrypter.EncryptPasswordMD5(pass), usr)
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

    Public Shared Sub modificarUsuario(ByRef usr As UsuarioBE)
        DAL.UsuarioDAL.modificarPass(usr)
        If Not usr.domicilio Is Nothing Then
            DAL.UsuarioDAL.modificarDomicilio(usr)
        End If

        If Not usr.telefono Is Nothing Then
            DAL.UsuarioDAL.modificartelefono(usr)
        End If
        Util.Mailer.enviarMail(usr.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.ModificacionDatos), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.ModificacionDatosMensaje))
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.ModificacionUsuario)
    End Sub

    Public Shared Sub solicitarContraseña(ByVal mail As String, ByVal usuario As String)
        Dim pass As String = Util.Encrypter.DecryptPasswordMD5(DAL.UsuarioDAL.solicitarContrasena(mail, usuario))
        Util.Mailer.enviarMail(mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RecuperarContrasena), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.RecuperarContrasenaMensaje) + " " + pass)
    End Sub

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

    Shared Function getRoles(p1 As Integer) As Object
        Throw New NotImplementedException
    End Function

    Shared Sub notificarClientesPromocion(idProd As Integer, precio As Decimal, desde As Date, hasta As Date)
        Dim lista As List(Of BE.UsuarioBE)
        Dim prod As BE.ProductoBE
        prod = BLL.ProductoBLL.buscarProducto(idProd)
        lista = DAL.UsuarioDAL.getConsumidores()
        For Each usr As BE.UsuarioBE In lista
            Util.Mailer.enviarMail(usr.mail, Util.Enumeradores.CodigoMensaje.NuevaPromo, Util.Enumeradores.CodigoMensaje.NuevaPromoMensaje + "Producto: " + prod.descripcion + " Precio Promocional: " + precio + "Desde " + desde.ToString + " Hasta " + hasta.ToString)
        Next
    End Sub
End Class ' UsuarioBLL
