Public Class RemitoDetalleBE
    Private _prod As BE.ProductoBE
    Private _cant As Integer

    Public Property cantidad() As Integer
        Get
            Return _cant
        End Get
        Set(ByVal value As Integer)
            _cant = value
        End Set
    End Property

    Public Property producto() As BE.ProductoBE
        Get
            Return _prod
        End Get
        Set(ByVal value As BE.ProductoBE)
            _prod = value
        End Set
    End Property


End Class
