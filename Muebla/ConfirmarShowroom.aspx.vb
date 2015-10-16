Imports BE

Public Class ConfirmarShowroom
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        buscarPedidos()
    End Sub

    Protected Sub showroomDataGrid_PreRender(sender As Object, e As EventArgs)

    End Sub

    Protected Sub showroomDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Session("idEdicion") = getItemId(sender, Me.showroomDataGrid)
        Dim id As Integer = Session("idEdicion")
        For Each a As AsistenciaShowroomBE In Session("pedidos")
            If a.id = id Then
                Me.fechaSolicTextBox.Text = a.fecha
                Me.asitioCheckBox.Checked = a.cumplido
                Exit For
            End If
        Next
        Me.lnkEdit_ModalPopupExtender.Show()
    End Sub

    Protected Sub ibtnConfirm_Click(sender As Object, e As ImageClickEventArgs)
        Dim id As Integer = Session("idEdicion")
        For Each a As AsistenciaShowroomBE In Session("pedidos")
            If a.id = id Then
                a.fecha = Util.Util.getDate(Me.fechaSolicTextBox.Text)
                Try
                    If a.cumplido = Me.asitioCheckBox.Checked Then
                        BLL.GestorShowroomBLL.modificarFechaPedido(a)
                    Else
                        BLL.GestorShowroomBLL.modificarPedido(a)
                    End If
                Catch ex As Exception
                    logMessage(ex)
                End Try
                Exit For
            End If
        Next
        buscarPedidos()
    End Sub

    Protected Sub buttonDeleteOK_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub buscarPedidos()
        Session("pedidos") = BLL.GestorShowroomBLL.getPedidos()
        Me.showroomDataGrid.DataSource = Session("pedidos")
        Me.showroomDataGrid.DataBind()
    End Sub

End Class