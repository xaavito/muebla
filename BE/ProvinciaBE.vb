'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ProvinciaBE.vb
''  Implementation of the Class ProvinciaBE
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:41:49
''  Original author: Javier
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On


Public Class ProvinciaBE


    Private _descripcion As String
    Private _id As Long

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


End Class ' ProvinciaBE
