Public Class AdministrarIdiomas
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        'If Session("idiomaChange") Is Nothing Then
        Try
            Me.idiomaDropDownList.DataSource = BLL.GestorIdiomaBLL.buscarIdiomas
            Me.idiomaDropDownList.DataTextField = "descripcion"
            Me.idiomaDropDownList.DataValueField = "id"
            Me.idiomaDropDownList.DataBind()

            llenarTabla()
            'End If
            Me.editDiv.Visible = False
        Catch ex As Exception
            logMessage(ex)
        End Try
        'TODO PASAR A AJAX CONTROL TOOLKIT
    End Sub

    Protected Sub idiomaResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.idiomaResultadosDataGrid)
    End Sub

    Protected Sub idiomaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim idioma As New BE.IdiomaBE
            Session("idiomaChange") = Me.idiomaDropDownList.SelectedValue
            idioma.id = Session("idiomaChange")
            Me.idiomaResultadosDataGrid.DataSource = BLL.GestorIdiomaBLL.buscarComponentes(idioma)
            Me.idiomaResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorIdiomaBLL.modificarComponente(Session("idTextoIdioma"), Me.textoTextBox.Text, Session("idiomaChange"))
            llenarTabla()
            Me.editDiv.Visible = False
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Session("idTextoIdioma") = getItemId(sender, Me.idiomaResultadosDataGrid)
        Dim texto As Label = CType(Me.idiomaResultadosDataGrid.Rows(CType(CType(sender, ImageButton).NamingContainer, GridViewRow).RowIndex).Cells(0).FindControl("itemTexto"), Label)
        Me.textoTextBox.Text = texto.Text
        Me.editDiv.Visible = True
    End Sub

    Protected Sub cancelarButton_Click(sender As Object, e As EventArgs)
        Me.editDiv.Visible = False
    End Sub

    Private Sub llenarTabla()
        Dim idioma As New BE.IdiomaBE
        If Session("idiomaChange") Is Nothing Then
            idioma.id = 1
            Session("idiomaChange") = 1
        Else
            idioma.id = Session("idiomaChange")
        End If

        Me.idiomaResultadosDataGrid.DataSource = BLL.GestorIdiomaBLL.buscarComponentes(idioma)
        Me.idiomaResultadosDataGrid.DataBind()
    End Sub

    Protected Sub idiomaResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.idiomaResultadosDataGrid.PageIndex = e.NewPageIndex
        llenarTabla()
    End Sub
End Class