
Public Class ListaPrecioBE
    Private _detalles As List(Of BE.ListaPrecioDetalleBE)
    Private _fechaDesde As Date
    Private _fechaHasta As Date
    Private _id As Long
    Private _descripcion As String
    Private _activo As Boolean

    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property


    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property


    Public Property detalles() As List(Of BE.ListaPrecioDetalleBE)
        Get
            Return _detalles
        End Get
        Set(ByVal Value As List(Of BE.ListaPrecioDetalleBE))
            _detalles = Value
        End Set
    End Property

    Public Property fechaDesde() As Date
        Get
            Return _fechaDesde
        End Get
        Set(ByVal Value As Date)
            _fechaDesde = Value
        End Set
    End Property

    Public Property fechaHasta() As Date
        Get
            Return _fechaHasta
        End Get
        Set(ByVal Value As Date)
            _fechaHasta = Value
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
End Class
