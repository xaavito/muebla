Public Class PedidoPersonalizado
    Private _id As Integer
    Private _des As String
    Private _bytes As Byte()
    Private _usr As BE.UsuarioBE

    Public Property usr() As BE.UsuarioBE
        Get
            Return _usr
        End Get
        Set(ByVal value As BE.UsuarioBE)
            _usr = value
        End Set
    End Property

    Public Property imagen() As Byte()
        Get
            Return _bytes
        End Get
        Set(ByVal value As Byte())
            _bytes = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _des
        End Get
        Set(ByVal value As String)
            _des = value
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
