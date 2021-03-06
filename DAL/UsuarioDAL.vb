Imports BE
Imports Util


Public Class UsuarioDAL
    Public Shared Function altaCliente(ByVal usr As UsuarioBE) As Int16
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_CLIENTE_SP")
            repository.addParam("@usr", usr.usuario)
            repository.addParam("@mail", usr.mail)
            repository.addParam("@nom", usr.nombre)
            repository.addParam("@ape", usr.apellido)
            repository.addParam("@pass", usr.password)
            repository.addParam("@dni", usr.dni)
            repository.addParam("@cuil", usr.cuil)
            repository.addParam("@tipo", usr.tipoDoc.id)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Public Shared Function altaUsuario(ByVal usr As UsuarioBE) As Integer
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_USUARIO_SP")
            repository.addParam("@usr", usr.usuario)
            repository.addParam("@mail", usr.mail)
            repository.addParam("@nom", usr.nombre)
            repository.addParam("@ape", usr.apellido)
            repository.addParam("@pass", usr.password)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Public Shared Function buscarUsuarios(ByVal usuario As String, ByVal mail As String) As List(Of UsuarioBE)
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Dim lista As New List(Of BE.UsuarioBE)
        Try
            repository.crearComando("BUSCAR_USUARIOS_SP")
            repository.addParam("@usr", usuario)
            repository.addParam("@mail", mail)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim user As New BE.UsuarioBE
                user.id = pepe.Item(0)
                user.nombre = pepe.Item(1)
                user.apellido = pepe.Item(2)
                user.usuario = pepe.Item(3)
                user.activo = pepe.Item(4)
                user.mail = pepe.Item(5)
                user.password = pepe.Item(6)
                lista.Add(user)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return lista
    End Function

    Public Shared Sub eliminarUsuario(ByVal usr As UsuarioBE)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ELIMINAR_USUARIO_SP")
            repository.addParam("@id", usr.id)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.EliminacionException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function login(ByVal pass As String, ByVal usr As String) As UsuarioBE
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LOGIN_SP")
            repository.addParam("@usr", usr)
            repository.addParam("@pass", pass)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count > 1) Then
                Throw New Util.ConexionImposibleExcepcion
            End If
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim usuario As New BE.UsuarioBE
                usuario.id = pepe.Item(0)
                usuario.nombre = pepe.Item(1)
                usuario.apellido = pepe.Item(2)
                usuario.usuario = usr
                usuario.password = pass
                If Not IsDBNull(pepe.Item(3)) Then
                    Dim idioma As New BE.IdiomaBE
                    idioma.id = pepe.Item(3)
                    usuario.idioma = idioma
                End If
                If Not IsDBNull(pepe.Item(4)) Then
                    Dim tDoc As New BE.TipoDocumentoBE
                    tDoc.id = pepe.Item(4)
                    usuario.tipoDoc = tDoc
                    usuario.dni = pepe.Item(5)
                End If
                usuario.mail = pepe.Item(6)
                Return usuario
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing
    End Function

    Public Shared Function solicitarContrasena(ByVal mail As String, ByVal usr As String) As String
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("SOLICITAR_CONTRASENA_SP")
            repository.addParam("@mail", mail)
            repository.addParam("@usr", usr)

            table = New DataTable
            table = repository.executeSearchWithAdapter()
            For Each pepe As DataRow In table.Rows
                If IsDBNull(pepe.Item(0)) Then
                    Throw New UsuarioNoEncontradoException
                Else
                    Return pepe.Item(0)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Shared Function buscarPermisos(rol As RolBE) As List(Of BE.ComponenteBE)
        Dim table As DataTable

        Dim listaComponentes As New List(Of BE.ComponenteBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_PERMISOS_SP")
            repository.addParam("@rol", rol.id)

            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            For Each pepe As DataRow In table.Rows
                Dim componente As New BE.ComponenteBE
                componente.id = pepe.Item(0)
                componente.nombre = pepe.Item(1)
                componente.texto = pepe.Item(2)
                If Not IsDBNull(pepe.Item(3)) Then
                    componente.pagina = pepe.Item(3)
                End If

                If Not IsDBNull(pepe.Item(4)) Then
                    componente.padre = New ComponenteBE
                    componente.padre.id = pepe.Item(4)
                    componente.padre.texto = pepe.Item(5)
                End If
                If Not IsDBNull(pepe.Item(6)) Then
                    componente.formulario = pepe.Item(6)
                End If

                listaComponentes.Add(componente)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return listaComponentes
    End Function

    Shared Function getTiposDocumentos() As List(Of TipoDocumentoBE)
        Dim table As DataTable
        Dim tipos As New List(Of BE.TipoDocumentoBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_TIPOS_DOCUMENTOS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            Dim tipo As BE.TipoDocumentoBE
            For Each pepe As DataRow In table.Rows
                tipo = New BE.TipoDocumentoBE
                tipo.id = pepe.Item(0)
                tipo.descripcion = pepe.Item(1)
                tipos.Add(tipo)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return tipos
    End Function

    Shared Function getProvincias() As List(Of ProvinciaBE)
        Dim table As DataTable
        Dim tipos As New List(Of BE.ProvinciaBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_PROVINCIAS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            Dim tipo As BE.ProvinciaBE
            For Each pepe As DataRow In table.Rows
                tipo = New BE.ProvinciaBE
                tipo.id = pepe.Item(0)
                tipo.descripcion = pepe.Item(1)
                tipos.Add(tipo)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return tipos
    End Function

    Shared Function getLocalidades(p1 As Integer) As Object
        Dim table As DataTable
        Dim tipos As New List(Of BE.LocalidadBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_LOCALIDADES_SP")
            repository.addParam("@prov", p1)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            Dim tipo As BE.LocalidadBE
            For Each pepe As DataRow In table.Rows
                tipo = New BE.LocalidadBE
                tipo.id = pepe.Item(0)
                tipo.descripcion = pepe.Item(1)
                tipos.Add(tipo)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return tipos
    End Function

    Shared Function altaDomicilio(usr As UsuarioBE) As Int16
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_DOMICILIO_SP")
            repository.addParam("@usr", usr.id)
            repository.addParam("@calle", usr.domicilio.calle)
            repository.addParam("@nro", usr.domicilio.numero)
            repository.addParam("@piso", usr.domicilio.piso)
            repository.addParam("@dpto", usr.domicilio.dpto)
            repository.addParam("@loc", usr.domicilio.localidad.id)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Shared Function altaTelefono(usr As UsuarioBE) As Int16
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ALTA_TELEFONO_SP")
            repository.addParam("@usr", usr.id)
            repository.addParam("@num", usr.telefono.numero)
            repository.addParam("@int", usr.telefono.interno)
            repository.addParam("@pre", usr.telefono.prefijo)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

        Return id
    End Function

    Shared Sub modificarUsuario(idUsuario As Integer, estado As Integer)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_USUARIO_SP")
            repository.addParam("@id", idUsuario)
            repository.addParam("@est", estado)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Shared Sub modificarPermisoUsuario(idUsuario As Integer, rol As BE.RolBE)
        Dim id As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("INSERTAR_PERMISOS_USUARIO_SP")
            repository.addParam("@id", idUsuario)
            repository.addParam("@rol", rol.id)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Shared Sub borrarPermisos(idUsuario As Integer)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("ELIMINAR_PERMISOS_USUARIO_SP")
            repository.addParam("@id", idUsuario)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub buscarDomicilioUsuario(ByRef usuario As UsuarioBE)
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_DOMICILIO_USR_SP")
            repository.addParam("@id", usuario.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count > 1) Then
                Throw New Util.BusquedaConMuchosResultadosException
            End If
            If (table.Rows.Count = 0) Then
                'Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                'd.id, d.calle, d.numero, d.piso, d.dpto, d.idLocalidad,l.descripcion, l.idProvincia, p.descripcion
                Dim dom As New BE.DomicilioBE
                dom.id = pepe.Item(0)
                dom.calle = pepe.Item(1)
                dom.numero = pepe.Item(2)
                dom.piso = pepe.Item(3)
                dom.dpto = pepe.Item(4)
                Dim loc As New BE.LocalidadBE
                loc.id = pepe.Item(5)
                loc.descripcion = pepe.Item(6)
                Dim prov As New BE.ProvinciaBE
                prov.id = pepe.Item(7)
                prov.descripcion = pepe.Item(8)
                loc.provincia = prov
                dom.localidad = loc
                usuario.domicilio = dom
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub buscarTelefono(ByRef usuario As UsuarioBE)
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_TELEFONO_USR_SP")
            repository.addParam("@id", usuario.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count > 1) Then
                Throw New Util.BusquedaConMuchosResultadosException
            End If
            If (table.Rows.Count = 0) Then
                'Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                Dim telefono As New BE.TelefonoBE
                telefono.id = pepe.Item(0)
                telefono.numero = pepe.Item(1)
                telefono.prefijo = pepe.Item(2)
                telefono.interno = pepe.Item(3)
                usuario.telefono = telefono
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub llenarDatosBlandosUsuario(ByRef usuario As UsuarioBE)
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_DATOS_BLANDOS_SP")
            repository.addParam("@id", usuario.id)
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count > 1) Then
                Throw New Util.BusquedaConMuchosResultadosException
            End If
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                usuario.id = pepe.Item(0)
                usuario.nombre = pepe.Item(1)
                usuario.apellido = pepe.Item(2)
                usuario.usuario = pepe.Item(3)
                usuario.mail = pepe.Item(4)
                usuario.cuil = pepe.Item(5)
                usuario.activo = pepe.Item(6)
                Dim idioma As New BE.IdiomaBE
                idioma.id = pepe.Item(7)
                usuario.idioma = idioma
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkPreModificacion(usuarioBE As UsuarioBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_MODIFICACION_USUARIO_SP")
            repository.addParam("@usr", usuarioBE.id)
            id = repository.executeWithReturnValue
            If id = 1 Then
                Throw New Util.UsuarioTienePedidosEnProcesoException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub modificarPass(usr As UsuarioBE)
        Dim id As Int16
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_PASS_USUARIO_SP")
            repository.addParam("@id", usr.id)
            repository.addParam("@pass", usr.password)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.ModificarException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub modificartelefono(usr As UsuarioBE)
        Dim id As Int16
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_TEL_USUARIO_SP")
            repository.addParam("@id", usr.telefono.id)
            repository.addParam("@prefijo", usr.telefono.prefijo)
            repository.addParam("@nro", usr.telefono.numero)
            repository.addParam("@int", usr.telefono.interno)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.ModificarException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub modificarDomicilio(usr As UsuarioBE)
        Dim id As Int16
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("MODIFICAR_DOMICILIO_USUARIO_SP")
            repository.addParam("@dom", usr.domicilio.id)
            repository.addParam("@calle", usr.domicilio.calle)
            repository.addParam("@nro", usr.domicilio.numero)
            repository.addParam("@piso", usr.domicilio.piso)
            repository.addParam("@dpto", usr.domicilio.dpto)
            repository.addParam("@loc", usr.domicilio.localidad.id)
            id = repository.executeSearchWithStatus
            If id = 0 Then
                Throw New Util.ModificarException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkMail(usr As UsuarioBE)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_MAIL_UTILIZADO_SP")
            repository.addParam("@mail", usr.mail)
            resultado = repository.executeWithReturnValue
            If (resultado >= 1) Then
                Throw New Util.MailYaEstaSiendoUtilizadoException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub checkUsr(usr As UsuarioBE)
        Dim resultado As Integer

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("CHECK_USUARIO_UTILIZADO_SP")
            repository.addParam("@usr", usr.usuario)
            resultado = repository.executeWithReturnValue
            If (resultado >= 1) Then
                Throw New Util.UsuarioYaEstaSiendoUtilizadoException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function getConsumidores() As List(Of UsuarioBE)
        Dim table As DataTable
        Dim lista As New List(Of BE.UsuarioBE)
        Dim usr As BE.UsuarioBE
        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("BUSCAR_CONSUMIDORES_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If
            For Each pepe As DataRow In table.Rows
                usr = New BE.UsuarioBE
                usr.id = pepe.Item(0)
                usr.mail = pepe.Item(1)
                lista.Add(usr)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function
End Class

