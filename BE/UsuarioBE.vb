
Public Class UsuarioBE

    Private _id As Integer
    Private _apellido As String
    Private _activo As Boolean
    Private _dni As Long
    Private _domicilio As DomicilioBE
    Private _idioma As IdiomaBE
    Private _roles As List(Of RolBE)
    Private _mail As String
    Private _nombre As String
    Private _password As String
    Private _telefono As TelefonoBE
    Private _usuario As String
    Private _cuil As String

    Public Property cuil() As String
        Get
            Return _cuil
        End Get
        Set(ByVal value As String)
            _cuil = value
        End Set
    End Property

    Private _tipoDoc As BE.TipoDocumentoBE
    Public Property tipoDoc() As BE.TipoDocumentoBE
        Get
            Return _tipoDoc
        End Get
        Set(ByVal value As BE.TipoDocumentoBE)
            _tipoDoc = value
        End Set
    End Property


    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal Value As String)
            _apellido = Value
        End Set
    End Property

    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal Value As Boolean)
            _activo = Value
        End Set
    End Property

    Public Property dni() As Long
        Get
            Return _dni
        End Get
        Set(ByVal Value As Long)
            _dni = Value
        End Set
    End Property

    Public Property domicilio() As DomicilioBE
        Get
            Return _domicilio
        End Get
        Set(ByVal Value As DomicilioBE)
            _domicilio = Value
        End Set
    End Property

    Public Property idioma() As IdiomaBE
        Get
            Return _idioma
        End Get
        Set(ByVal Value As IdiomaBE)
            _idioma = Value
        End Set
    End Property

    Public Property roles As List(Of RolBE)
        Get
            Return _roles
        End Get
        Set(ByVal Value As List(Of RolBE))
            _roles = Value
        End Set
    End Property

    Public Property mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal Value As String)
            _mail = Value
        End Set
    End Property


    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal Value As String)
            _nombre = Value
        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal Value As String)
            _password = Value
        End Set
    End Property

    Public Property telefono() As TelefonoBE
        Get
            Return _telefono
        End Get
        Set(ByVal Value As TelefonoBE)
            _telefono = Value
        End Set
    End Property

    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal Value As String)
            _usuario = Value
        End Set
    End Property


End Class
