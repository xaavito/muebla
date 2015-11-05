Public Class MensajeBE

    Private _id As Integer
    Private _codigo As Integer
    Private _mensaje As String

    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Public Property codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
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


End Class
