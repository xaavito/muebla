Public Class Comentario

    Private _id As Integer
    Private _texto As String
    Private _usr As BE.UsuarioBE

    Public Property usuario() As BE.UsuarioBE
        Get
            Return _usr
        End Get
        Set(ByVal value As BE.UsuarioBE)
            _usr = value
        End Set
    End Property

    Public Property texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
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
