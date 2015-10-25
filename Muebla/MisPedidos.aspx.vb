Public Class MisPedidos
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        loadEstadosPedidos()
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

    Protected Sub detallePedidosResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.detallePedidosResultGrid)
    End Sub

    Protected Sub detallePedidosResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        'TODO VER ESTO DEL PAGINADO...
    End Sub

    Private Sub loadPedidos()
        Try
            Me.detallePedidosResultGrid.DataSource = BLL.GestorPedidoBLL.buscarPedidos(getUsuario, Util.Util.getDate(Me.fechaDesdeTextBox.Text), Util.Util.getDate(Me.fechaHastaTextBox.Text), Me.estadoListBox.SelectedValue)
            Me.detallePedidosResultGrid.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub loadEstadosPedidos()
        Me.estadoListBox.DataSource = BLL.GestorPedidoBLL.getEstadosPedidos()
        Me.estadoListBox.DataTextField = "descripcion"
        Me.estadoListBox.DataValueField = "id"
        Me.estadoListBox.DataBind()
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        loadPedidos()
    End Sub

    Protected Sub ibtnCambiarEstado_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class