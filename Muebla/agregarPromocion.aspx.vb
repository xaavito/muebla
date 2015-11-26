Public Class agregarPromocion
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("listaPrecioDetalle") = BLL.ListaPrecioBLL.getListaPrecioParaAlta
            Me.detalleListaPrecioResultGrid.DataSource = Session("listaPrecioDetalle")
            Me.detalleListaPrecioResultGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ButtonConfirmarOkay_Click(sender As Object, e As EventArgs)
        Try
            Dim idProd As Integer
            For Each a As BE.ListaPrecioDetalleBE In Session("listaPrecioDetalle")
                If a.id = Session("idSeleccionado") Then
                    idProd = a.producto.id
                    Exit For
                End If
            Next
            BLL.ListaPrecioBLL.altaPromocion(idProd, Decimal.Parse(Me.precioPromoTextBox.Text), Util.Util.getDate(Me.fechaDesdeTextBox1.Text), Util.Util.getDate(Me.fechaHastaTextBox1.Text))
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnAddPromo_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Session("idSeleccionado") = getItemId(sender, Me.detalleListaPrecioResultGrid)
            For Each a As BE.ListaPrecioDetalleBE In Session("listaPrecioDetalle")
                If a.id = Session("idSeleccionado") Then
                    Me.precioActualTextBox.Text = a.precio
                    Exit For
                End If
            Next
            lnkAddPromo_ModalPopupExtender.Show()
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(detalleListaPrecioResultGrid)
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.detalleListaPrecioResultGrid.PageIndex = e.NewPageIndex
    End Sub
End Class