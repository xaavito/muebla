'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ProductoDAL.vb
''  Implementation of the Class ProductoDAL
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:42:43
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


Public Class ProductoDAL


    ''' 
    ''' <param name="prod"></param>
    ''' <param name="cant"></param>
    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Sub altaProducto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Sub bajaProducto(ByVal producto As ProductoBE)

    End Sub

    ''' 
    ''' <param name="stockMin"></param>
    ''' <param name="tipo"></param>
    ''' <param name="nombre"></param>
    Public Sub buscarProductos(ByVal stockMin As Boolean, ByVal tipo As TipoProductoBE, ByVal nombre As String)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Shared Function checkProductoEnPedidos(ByVal producto As ProductoBE) As Boolean
        checkProductoEnPedidos = False
    End Function

    ''' 
    ''' <param name="prod"></param>
    Public Sub compararCosto(ByVal prod As ProductoBE)

    End Sub

    ''' 
    ''' <param name="prod"></param>
    Public Sub generarOrdenCompra(ByVal prod As ProductoBE)

    End Sub

    ''' 
    ''' <param name="producto"></param>
    Public Sub modificarProducto(ByVal producto As ProductoBE)

    End Sub


End Class ' ProductoDAL

