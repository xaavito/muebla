'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ProductoBLL.vb
''  Implementation of the Class ProductoBLL
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:42:22
''  Original author: Javier
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On

Imports BE


Public Class ProductoBLL


    ''' 
    ''' <param name="prod"></param>
    ''' <param name="cant"></param>
    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub altaProducto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub bajaProducto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="stockMin"></param>
    ''' <param name="tipo"></param>
    ''' <param name="nombre"></param>
    Public Shared Function buscarProductos(ByVal stockMin As Boolean, ByVal tipo As TipoProductoBE, ByVal nombre As String) As List(Of ProductoBE)
        buscarProductos = Nothing
    End Function

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub compararCosto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub generarOrdenCompra(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Sub modificarProducto(ByVal producto As ProductoBE)

    End Sub


End Class ' ProductoBLL

