Public Class FacturaBE
    Private _nro As Integer
    Private _letra As String
    Private _suc As String
    Private _total As Decimal
    Private _usr As BE.UsuarioBE
    Private _detalles As List(Of BE.FacturaDetalleBE)
    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property


    Public Property detalles() As List(Of BE.FacturaDetalleBE)
        Get
            Return _detalles
        End Get
        Set(ByVal value As List(Of BE.FacturaDetalleBE))
            _detalles = value
        End Set
    End Property

    Public Property usr() As BE.UsuarioBE
        Get
            Return _usr
        End Get
        Set(ByVal value As BE.UsuarioBE)
            _usr = value
        End Set
    End Property

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
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
