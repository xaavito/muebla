

Public Class ProveedorBE


    Private _cuit As Long
    Private _direccion As String
    Private _id As Long
    Private _mail As String
    Private _razonSocial As String
    Private _productos As List(Of BE.ProductoBE)
    Private _estado As BE.EstadoProveedorBE

    Public Property estado() As BE.EstadoProveedorBE
        Get
            Return _estado
        End Get
        Set(ByVal value As BE.EstadoProveedorBE)
            _estado = value
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


    Private _tel As String
    Public Property tel() As String
        Get
            Return _tel
        End Get
        Set(ByVal value As String)
            _tel = value
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

    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal Value As String)
            _direccion = Value
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


End Class ' ProveedorBE
