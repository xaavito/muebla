Public Class NoHayIdiomasExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("No hay Idiomas")
        Me.codigo = Enumeradores.Excepeciones.NoHayIdioma
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "No hay Idiomas"
    End Sub
End Class

Public Class IdiomaNoEncontradoExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaNoEncontrado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class GeneracionDeIdiomaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaNoCreado
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class IdiomaModificadoExistosamente
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaModificadoExistosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class IdiomaEliminadoExistosamenteExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaEliminadoExitosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class IdiomaTieneUsuariosAsociadosExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaTieneUsuariosAsociados
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class ModificacionDeIdiomaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.ModificacionDeIdiomaExcepcion
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class EliminarIdiomaExcepcion
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.EliminarIdiomaExcepcion
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class

Public Class GeneracionDeIdiomaExitosa
    Inherits ExceptionManager

    Public Sub New()
        MyBase.new("Idioma No encontrado")
        Me.codigo = Enumeradores.Excepeciones.IdiomaGeneradoExistosamente
        Me.tipo = MsgBoxStyle.Exclamation
        Me.mensaje = "Idioma No encontrado"
    End Sub
End Class