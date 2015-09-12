

Public Class TipoEventoBE


    Private _id As Long
    Private _texto As String
    Private _codigo As Long

    Public Property codigo() As Long
        Get
            Return _codigo
        End Get
        Set(ByVal value As Long)
            _codigo = value
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

    Public Property texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal Value As String)
            _texto = Value
        End Set
    End Property


End Class ' TipoEventoBE
