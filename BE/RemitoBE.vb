Public Class RemitoBE
    Private _fecha As Date
    Private _nro As Integer
    Private _letra As String
    Private _suc As String
    Private _total As Decimal
    Private _prov As BE.ProveedorBE
    Private _detalles As List(Of BE.RemitoDetalleBE)
    Public Property detalles() As List(Of BE.RemitoDetalleBE)
        Get
            Return _detalles
        End Get
        Set(ByVal value As List(Of BE.RemitoDetalleBE))
            _detalles = value
        End Set
    End Property


    Public Property prov() As BE.ProveedorBE
        Get
            Return _prov
        End Get
        Set(ByVal value As BE.ProveedorBE)
            _prov = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Public Property sucursal() As String
        Get
            Return _suc
        End Get
        Set(ByVal value As String)
            _suc = value
        End Set
    End Property

    Public Property letra() As String
        Get
            Return _letra
        End Get
        Set(ByVal value As String)
            _letra = value
        End Set
    End Property

    Public Property nro() As Integer
        Get
            Return _nro
        End Get
        Set(ByVal value As Integer)
            _nro = value
        End Set
    End Property
End Class
