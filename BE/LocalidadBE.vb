
Public Class LocalidadBE


    Private _descripcion As String
    Private _id As Long
    Private _provincia As ProvinciaBE
    Private _usr As UsuarioBE
    Public m_ProvinciaBE As ProvinciaBE

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
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

		


End Class ' LocalidadBE

