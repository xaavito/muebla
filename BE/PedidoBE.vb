'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  PedidoBE.vb
''  Implementation of the Class PedidoBE
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:41:47
''  Original author: Javier
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On


Public Class PedidoBE


    Private _comprobantes As List(Of ComprobanteBE)
    Private _envioPorFlete As Boolean
    Private _fechaCreacion As DateTime
    Private _id As Long
    Private _medioPago As MedioPagoBE
    Private _pagado As Boolean
    Private _tipoVenta As TipoVentaBE
    Public m_UsuarioBE As UsuarioBE
    Public m_MedioPagoBE As MedioPagoBE
    Public m_TipoVentaBE As TipoVentaBE
    Public m_ComprobanteBE As ComprobanteBE

    Public Property comprobantes() As List(Of ComprobanteBE)
        Get
            Return _comprobantes
        End Get
        Set(ByVal Value As List(Of ComprobanteBE))
            _comprobantes = Value
        End Set
    End Property

    Public Property envioPorFlete() As Boolean
        Get
            Return _envioPorFlete
        End Get
        Set(ByVal Value As Boolean)
            _envioPorFlete = Value
        End Set
    End Property

    Public Property fechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal Value As DateTime)
            _fechaCreacion = Value
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

    Public Property medioPago() As MedioPagoBE
        Get
            Return _medioPago
        End Get
        Set(ByVal Value As MedioPagoBE)
            _medioPago = Value
        End Set
    End Property


    Public Property pagado() As Boolean
        Get
            Return _pagado
        End Get
        Set(ByVal Value As Boolean)
            _pagado = Value
        End Set
    End Property

    Public Property tipoVenta() As TipoVentaBE
        Get
            Return _tipoVenta
        End Get
        Set(ByVal Value As TipoVentaBE)
            _tipoVenta = Value
        End Set
    End Property


End Class ' PedidoBE
