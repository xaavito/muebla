Imports Util
Imports BLL

Public Class ExtendedPage
    Inherits System.Web.UI.Page

    Private _idioma As BE.IdiomaBE
    Public Property idioma() As BE.IdiomaBE
        Get
            Return _idioma
        End Get
        Set(ByVal value As BE.IdiomaBE)
            _idioma = value
        End Set
    End Property

    Private _usuario As BE.UsuarioBE
    Public Property usuario() As BE.UsuarioBE
        Get
            Return _usuario
        End Get
        Set(ByVal value As BE.UsuarioBE)
            _usuario = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Dim messageLogger As Label
        messageLogger = CType(Me.Master.FindControl("errorMessageLogger"), Label)
        messageLogger.Text = ""
        messageLogger = CType(Me.Master.FindControl("infoMessageLogger"), Label)
        messageLogger.Text = ""
        messageLogger = CType(Me.Master.FindControl("warningMessageLogger"), Label)
        messageLogger.Text = ""
        messageLogger = CType(Me.Master.FindControl("exitoMessageLogger"), Label)
        messageLogger.Text = ""
    End Sub

    Public Sub logMessage(ByVal ex As Exception)
        Dim messageLogger As Label = CType(Me.Master.FindControl("errorMessageLogger"), Label)
        If (TypeOf ex Is ExceptionManager) Then
            Dim excep = DirectCast(ex, ExceptionManager)
            If excep.tipo = Enumeradores.ImportanciaEvento.Err Then
                messageLogger = CType(Me.Master.FindControl("errorMessageLogger"), Label)
            ElseIf excep.tipo = Enumeradores.ImportanciaEvento.Info Then
                messageLogger = CType(Me.Master.FindControl("infoMessageLogger"), Label)
            ElseIf excep.tipo = Enumeradores.ImportanciaEvento.Warning Then
                messageLogger = CType(Me.Master.FindControl("warningMessageLogger"), Label)
            Else
                messageLogger = CType(Me.Master.FindControl("exitoMessageLogger"), Label)
            End If
            Try
                messageLogger.Text = BLL.GestorExcepcionesBLL.buscarExcepcion(excep.codigo, getSelectedIdioma())
            Catch e As BusquedaSinResultadosException
                messageLogger.Text = e.mensaje
            End Try
        Else
            messageLogger.Text = ex.Message
        End If
    End Sub

    Public Function getSelectedIdioma() As Integer
        Dim idiomaDropDown As DropDownList
        idiomaDropDown = CType(Me.Master.FindControl("idiomasList"), DropDownList)
        Debug.WriteLine("Idioma seleccionado: " + idiomaDropDown.SelectedValue)
        If idiomaDropDown.SelectedValue <> "" Then
            Return idiomaDropDown.SelectedValue
        Else
            Return Session("Idioma")
        End If
    End Function

    Public Sub translateGrid(ByRef grid As GridView)
        Try
            Dim id As Integer = getSelectedIdioma()

            If Not grid.HeaderRow Is Nothing Then
                For index = 0 To grid.HeaderRow.Cells.Count - 1
                    Dim traduccion As String = BLL.GestorIdiomaBLL.getTranslation(grid.HeaderRow.Cells(index).Text, id)
                    If (Not traduccion Is Nothing) Then
                        grid.HeaderRow.Cells(index).Text = traduccion
                    End If
                Next
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Public Shared Function getItemId(sender As Object, gridView As GridView) As Integer
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(gridView.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Return id
    End Function
End Class
