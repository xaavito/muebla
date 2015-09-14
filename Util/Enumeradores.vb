Public Class Enumeradores
    Enum Excepeciones
        'BD
        ConexionBDFallida = 1
        'Genericas
        BusquedaSinResultados = 2
        FalloAlEliminar = 3
        FalloAlCrear = 4
        FalloAlModificar = 5
        ExitoAlEliminar = 6
        ExitoAlCrear = 7
        ExitoAlModificar = 8
        'Alta Registro
        ExitoAlCrearUsuario = 9
    End Enum

    Enum Bitacora
        LogueoExitoso = 1
        LogoutExitoso = 2
    End Enum

    Enum ImportanciaEvento
        Err = 1
        Exito = 2
        Warning = 3
        Info = 4
    End Enum
End Class
