Public Class BackupBE


    Private desc As String
    Private _fecha As DateTime
    Private _id As Long
    Private _path As String
    Private _activo As Integer

    Public Property activo() As Integer
        Get
            Return _activo
        End Get
        Set(ByVal value As Integer)
            _activo = value
        End Set
    End Property

    Public Property path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property


    Public Property descripcion() As String
        Get
            Return desc
        End Get
        Set(ByVal Value As String)
            desc = Value
        End Set
    End Property

    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal Value As DateTime)
            _fecha = Value
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



End Class ' BackupBE

