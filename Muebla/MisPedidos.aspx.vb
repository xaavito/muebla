Public Class MisPedidos
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cancelarVenta(sender As Object, e As EventArgs)
        Response.Redirect("Observaciones.aspx")
    End Sub

    Protected Sub hojaDeRuta(sender As Object, e As EventArgs)
        Response.Redirect("HojadeRuta.aspx")
    End Sub

    Protected Sub factura(sender As Object, e As EventArgs)
        Response.Redirect("Factura.aspx")
    End Sub

    Protected Sub remito(sender As Object, e As EventArgs)
        Response.Redirect("Remito.aspx")
    End Sub

    Protected Sub notaCredito(sender As Object, e As EventArgs)
        Response.Redirect("NotaCredito.aspx")
    End Sub

    Protected Sub comentario(sender As Object, e As EventArgs)
        Response.Redirect("Observaciones.aspx")
    End Sub

    Protected Sub postVenta(sender As Object, e As EventArgs)
        Response.Redirect("PostVenta.aspx")
    End Sub
End Class