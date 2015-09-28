Imports BE
Imports Util


Public Class UsuarioDAL


    ''' 
    ''' <param name="usr"></param>
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

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub altaUsuario(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="tipo"></param>
    ''' <param name="usuario"></param>
    ''' <param name="mail"></param>
    Public Shared Function buscarUsuarios(ByVal tipo As Int16, ByVal usuario As String, ByVal mail As String) As List(Of UsuarioBE)
        Dim table As DataTable

        Dim repository As New AccesoSQLServer
        Dim lista As New List(Of BE.UsuarioBE)
        Try
            repository.crearComando("BUSCAR_USUARIOS_SP")
            repository.addParam("@usr", usuario)
            repository.addParam("@mail", mail)
            repository.addParam("@tipo", tipo)
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
                Dim tip As New BE.TipoUsuarioBE
                tip.id = pepe.Item(4)
                tip.descripcion = pepe.Item(5)
                user.tipoUsuario = tip
                user.activo = pepe.Item(6)
                user.mail = pepe.Item(7)
                lista.Add(user)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return lista
    End Function

    ''' 
    ''' <param name="mail"></param>
    Public Shared Sub checkMailValido(ByVal mail As String)

    End Sub

    ''' 
    ''' <param name="usr"></param>
    Public Shared Function checkUsuarioYaRegistrado(ByVal usr As UsuarioBE) As Boolean
        checkUsuarioYaRegistrado = False
    End Function

    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub eliminarUsuario(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="pass"></param>
    ''' <param name="usr"></param>
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
                Dim idioma As New BE.IdiomaBE
                idioma.id = pepe.Item(3)
                usuario.idioma = idioma
                Return usuario
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return Nothing
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
    ''' <param name="usr"></param>
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
                    Return Nothing
                Else
                    Return pepe.Item(0)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

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

    Shared Function getTiposUsuarios() As List(Of TipoUsuarioBE)
        Dim table As DataTable
        Dim tipos As New List(Of BE.TipoUsuarioBE)

        Dim repository As New AccesoSQLServer
        Try
            repository.crearComando("LISTAR_TIPOS_USUARIOS_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New Util.BusquedaSinResultadosException
            End If

            Dim tipo As New BE.TipoUsuarioBE
            tipo.id = Nothing
            tipo.descripcion = "Todos"
            tipos.Add(tipo)
            For Each pepe As DataRow In table.Rows
                tipo = New BE.TipoUsuarioBE
                tipo.id = pepe.Item(0)
                tipo.descripcion = pepe.Item(1)
                tipos.Add(tipo)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        
        Return tipos
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
            repository.addParam("@loc", usr.domicilio.m_LocalidadBE.id)
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

End Class

