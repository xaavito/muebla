'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  GestorIdiomaBLL.vb
''  Implementation of the Class GestorIdiomaBLL
''  Generated by Enterprise Architect
''  Created on:      21-jun.-2015 17:42:19
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


Public Class GestorIdiomaBLL


    ''' 
    ''' <param name="componentes"></param>
    ''' <param name="idioma"></param>
    Public Shared Sub altaIdioma(ByVal componentes As ComponenteBE, ByVal idioma As String)

    End Sub

    Public Shared Function buscarComponentes() As List(Of ComponenteBE)
        buscarComponentes = Nothing
    End Function

    Public Shared Function buscarIdiomas() As List(Of IdiomaBE)
        buscarIdiomas = Nothing
    End Function

    ''' 
    ''' <param name="idioma"></param>
    Public Shared Sub modificarIdioma(ByVal idioma As IdiomaBE)

    End Sub


End Class ' GestorIdiomaBLL
