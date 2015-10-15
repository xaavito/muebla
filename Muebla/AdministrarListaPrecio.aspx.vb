﻿Public Class ModificarListaPrecio
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.estadoListBox.DataSource = Util.Util.getEstadoCombo
        Me.estadoListBox.DataValueField = "id"
        Me.estadoListBox.DataTextField = "descripcion"
        Me.estadoListBox.DataBind()
        Me.detailsData.Visible = True
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        Try
            Me.listaPrecioResultadosDataGrid.DataSource = BLL.ListaPrecioBLL.buscarListas(Me.estadoListBox.SelectedValue, Me.descripcionTextBox.Text)
            Me.listaPrecioResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Me.lnkDelete_ModalPopupExtender.Show()
    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)
        Session("idListaPrecio") = getItemId(sender, Me.listaPrecioResultadosDataGrid)
        buscarDetalles()
    End Sub

    Protected Sub listaPrecioResultadosDataGrid_PreRender(sender As Object, e As EventArgs)

    End Sub

    Protected Sub listaPrecioResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

    End Sub

    Protected Sub detalleListaPrecioResultGrid_PreRender(sender As Object, e As EventArgs)

    End Sub

    Protected Sub detalleListaPrecioResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.detalleListaPrecioResultGrid.PageIndex = e.NewPageIndex
        buscarDetalles()
    End Sub

    Protected Sub ibtnDetailsDetail_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDeleteDetail_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnEditDetail_Click(sender As Object, e As ImageClickEventArgs)
        Session("idListaPrecioDetalle") = getItemId(sender, Me.detalleListaPrecioResultGrid)
        For Each a As BE.ListaPrecioDetalleBE In Session("detallesListaPrecio")
            If a.id = Session("idListaPrecioDetalle") Then
                Me.valorTextBox.Text = a.precio
            End If
        Next
        Me.lnkEditDetail_ModalPopupExtender.Show()
    End Sub

    Private Sub buscarDetalles()
        'Me.detailsData.Visible = Not Me.detailsData.Visible
        Session("detallesListaPrecio") = BLL.ListaPrecioBLL.getDetalleListaPrecio(Session("idListaPrecio"))
        Me.detalleListaPrecioResultGrid.DataSource = Session("detallesListaPrecio")
        Me.detalleListaPrecioResultGrid.DataBind()
    End Sub

    Protected Sub ButtonDeleleOkay_Click(sender As Object, e As EventArgs)
        Debug.WriteLine("borrando!!!")
    End Sub

    Protected Sub confirmarEdicionButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ButtonEditDetailCancel_Click(sender As Object, e As EventArgs)

    End Sub
End Class