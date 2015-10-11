Imports System.Drawing

Public Class ProductoBE


    Private _baja As Boolean
    Private _descripcion As String
    Private _breveDescripcion As String
    Private _id As Long
    Private _image1 As Byte()
    Private _image2 As Byte()
    Private _productos As List(Of BE.ProductoBE)
    Private _proveedor As ProveedorBE
    Private _tipoProducto As TipoProductoBE
    Private _stock As Integer
    Private _stockMin As Integer
    Private _precio As Decimal

    Public Property precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property


    Public Property stockMin() As Integer
        Get
            Return _stockMin
        End Get
        Set(ByVal value As Integer)
            _stockMin = value
        End Set
    End Property

    Public Property stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property breveDescripcion() As String
        Get
            Return _breveDescripcion
        End Get
        Set(ByVal Value As String)
            _breveDescripcion = Value
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

    Public Property image1() As Byte()
        Get
            Return _image1
        End Get
        Set(ByVal Value As Byte())
            _image1 = Value
        End Set
    End Property

    Public Property image2() As Byte()
        Get
            Return _image2
        End Get
        Set(ByVal Value As Byte())
            _image2 = Value
        End Set
    End Property


    Public Property productos() As List(Of BE.ProductoBE)
        Get
            Return _productos
        End Get
        Set(ByVal Value As List(Of BE.ProductoBE))
            _productos = Value
        End Set
    End Property

    Public Property proveedor() As ProveedorBE
        Get
            Return _proveedor
        End Get
        Set(ByVal Value As ProveedorBE)
            _proveedor = Value
        End Set
    End Property

    Public Property tipoProducto() As TipoProductoBE
        Get
            Return _tipoProducto
        End Get
        Set(ByVal Value As TipoProductoBE)
            _tipoProducto = Value
        End Set
    End Property


End Class ' ProductoBE
