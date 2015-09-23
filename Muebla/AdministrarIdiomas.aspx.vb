Public Class AdministrarIdiomas
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        If Session("idiomaChange") Is Nothing Then
            Me.idiomaDropDownList.DataSource = BLL.GestorIdiomaBLL.buscarIdiomas
            Me.idiomaDropDownList.DataTextField = "descripcion"
            Me.idiomaDropDownList.DataValueField = "id"
            Me.idiomaDropDownList.DataBind()

            Dim idioma As New BE.IdiomaBE
            idioma.id = 1
            Me.idiomaResultadosDataGrid.DataSource = BLL.GestorIdiomaBLL.buscarComponentes(idioma)
            Me.idiomaResultadosDataGrid.DataBind()
        End If
        Me.editDiv.Visible = False
    End Sub

    Protected Sub idiomaResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.idiomaResultadosDataGrid)
    End Sub

    Protected Sub idiomaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim idioma As New BE.IdiomaBE
            Session("idiomaChange") = Me.idiomaDropDownList.SelectedValue
            idioma.id = Me.idiomaDropDownList.SelectedValue
            Me.idiomaResultadosDataGrid.DataSource = BLL.GestorIdiomaBLL.buscarComponentes(idioma)
            Me.idiomaResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorIdiomaBLL.modificarComponente(Session("idTextoIdioma"), Me.textoTextBox.Text)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.idiomaResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Session("idTextoIdioma") = id
        Me.editDiv.Visible = True
    End Sub
End Class