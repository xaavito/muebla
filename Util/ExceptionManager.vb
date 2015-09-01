Public Class ExceptionManager
    Inherits Exception


    Private _codigo As Integer
    Public Property codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private _mensaje As String
    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property


    Private _tipo As MsgBoxStyle

    Public Property tipo() As MsgBoxStyle
        Get
            Return _tipo
        End Get
        Set(ByVal value As MsgBoxStyle)
            _tipo = value
        End Set
    End Property

    Protected Sub New(ByVal p1 As String)
        MyBase.New(p1)
    End Sub

    Public Sub New()

    End Sub

End Class
