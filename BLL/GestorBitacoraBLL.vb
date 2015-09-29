Imports BE


Public Class GestorBitacoraBLL

    Public Shared Function buscarBitacoras(ByVal fechahasta As Date, ByVal fechadesde As Date, ByVal tipo As Integer, ByVal usr As String, ByVal id As Integer) As List(Of EventoBE)
        Return DAL.GestorBitacoraDAL.buscarBitacoras(fechahasta, fechadesde, usr, tipo, id)
    End Function

    Public Shared Sub registrarEvento(ByVal usuarioId As Integer, ByVal tipo As Integer)
        DAL.GestorBitacoraDAL.registrarEvento(usuarioId, tipo)
    End Sub

    Public Shared Sub registrarEvento(ByVal usuario As UsuarioBE, ByVal tipo As Integer)
        DAL.GestorBitacoraDAL.registrarEvento(usuario, tipo)
    End Sub

    Shared Function getTipoEventos(ByVal id As Integer) As List(Of BE.TipoEventoBE)
        Return DAL.GestorBitacoraDAL.getTipoEventos(id)
    End Function


End Class ' GestorBitacoraBLL

