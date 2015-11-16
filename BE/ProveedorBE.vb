

Public Class ProveedorBE
    Private _cuit As Long
    Private _id As Long
    Private _mail As String
    Private _razonSocial As String
    Private _productos As List(Of BE.ProductoBE)
    Private _activo As Boolean
    Private _contacto As String
    Private _tel As BE.TelefonoBE
    Private _dom As BE.DomicilioBE

    Public Property dom() As BE.DomicilioBE
        Get
            If _dom Is Nothing Then
                _dom = New BE.DomicilioBE
            End If
            Return _dom
        End Get
        Set(ByVal value As BE.DomicilioBE)
            _dom = value
        End Set
    End Property

    Public Property tel() As BE.TelefonoBE
        Get
            If _tel Is Nothing Then
                _tel = New BE.TelefonoBE
            End If
            Return _tel
        End Get
        Set(ByVal value As BE.TelefonoBE)
            _tel = value
        End Set
    End Property

    Public Property contacto() As String
        Get
            Return _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
        End Set
    End Property

    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Public Property productos() As List(Of BE.ProductoBE)
        Get
            Return _productos
        End Get
        Set(ByVal value As List(Of BE.ProductoBE))
            _productos = value
        End Set
    End Property

    Public Property cuit() As Long
        Get
            Return _cuit
        End Get
        Set(ByVal Value As Long)
            _cuit = Value
        End Set
    End Property

    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal Value As Long)
            _id = Value
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

    Public Property razonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal Value As String)
            _razonSocial = Value
        End Set
    End Property

    Public Function getActivo() As String
        If activo Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function
End Class
