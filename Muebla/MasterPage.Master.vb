Imports BE
Imports System.IO

Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Dim usr As UsuarioBE
    Dim idioma As IdiomaBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
       
        usr = Session("Usuario")

        If usr Is Nothing Then
            Me.logoutButton.Visible = False
            Me.shoppingCart.Visible = False
            Me.loginButton.Visible = True
            Me.greetingsLabel.Visible = False
        Else
            Me.logoutButton.Visible = True
            Me.shoppingCart.Visible = True
            Me.loginButton.Visible = False
            Me.greetingsLabel.Visible = False
        End If

        loadPermisos(usr)
        loadIdiomas()
        idioma = New BE.IdiomaBE
        idioma.id = Session("Idioma")
        loadSelectedIdioma(idioma)
        Me.idiomasList.SelectedValue = idioma.id
        checkPermisoPaginaActual()
    End Sub

    Protected Sub shoppingCart_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("Carrito.aspx", False)
    End Sub

    Protected Sub idiomasList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Idioma") = Me.idiomasList.SelectedValue
        If Not Session("Idioma") Is Nothing Then
            Dim idioma As New BE.IdiomaBE
            idioma.id = Session("Idioma")
            loadSelectedIdioma(idioma)
        End If
    End Sub

    Private Sub loadSelectedIdioma(comp As BE.ComponenteBE, con As Control)
        If TypeOf con Is GridView Then
            If Not CType(con, GridView).HeaderRow Is Nothing Then
                For Each cel As TableCell In CType(con, GridView).HeaderRow.Cells
                    For Each c As Control In cel.Controls
                        If TypeOf c Is LinkButton Then
                            'Debug.WriteLine("LinkButton: " + CType(c, LinkButton).Text)
                            idioma = New BE.IdiomaBE
                            idioma.id = Session("Idioma")
                            CType(c, LinkButton).Text = BLL.GestorIdiomaBLL.getTranslation(CType(c, LinkButton).Text, idioma.id)
                        End If
                    Next
                Next
            End If
        End If
        If TypeOf con Is TreeView Then
            For Each c As TreeNode In CType(con, TreeView).Nodes
                If c.Value.Equals(comp.nombre) Then
                    c.Text = comp.texto
                End If
                For Each children As TreeNode In c.ChildNodes
                    If children.Value.Equals(comp.nombre) Then
                        children.Text = comp.texto
                    End If
                Next
            Next
        ElseIf TypeOf con Is Table Then
            For Each c As TableRow In CType(con, Table).Rows
                For Each cell As TableCell In c.Cells
                    For Each Control As Control In cell.Controls
                        If TypeOf Control Is Label Then
                            If Not CType(Control, Label).ID Is Nothing Then
                                If CType(Control, Label).ID.Equals(comp.nombre) Then
                                    CType(Control, Label).Text = comp.texto
                                End If
                            End If
                        End If
                    Next
                Next
            Next
        ElseIf TypeOf con Is Button Then
            If Not CType(con, Button).ID Is Nothing Then
                If CType(con, Button).ID.Equals(comp.nombre) Then
                    CType(con, Button).Text = comp.texto
                End If
            End If
        ElseIf TypeOf con Is LinkButton Then
            If Not CType(con, LinkButton).ID Is Nothing Then
                'Debug.WriteLine("Link button: " + CType(con, LinkButton).ID.ToString)
                If CType(con, LinkButton).ID.Equals(comp.nombre) Then
                    CType(con, LinkButton).Text = comp.texto
                End If
            End If
        ElseIf TypeOf con Is Label Then
            If Not CType(con, Label).ID Is Nothing Then
                'Debug.WriteLine("Label: " + CType(con, Label).ID.ToString)
                If CType(con, Label).ID.Equals(comp.nombre) Then
                    CType(con, Label).Text = comp.texto
                End If
            End If
        ElseIf TypeOf con Is DropDownList Then
            If Not CType(con, DropDownList).ID Is Nothing Then
                'Debug.WriteLine("DropDownList: " + CType(con, DropDownList).ID.ToString)
            End If
        Else
            If con.HasControls Then
                'Debug.WriteLine("generico: " + con.ID)
                For Each c As Control In con.Controls
                    loadSelectedIdioma(comp, c)
                Next
            End If
        End If
    End Sub

    Private Sub loadPermisos(usr As UsuarioBE)
        If Not usr Is Nothing Then
            Me.usrText.Text = usr.apellido + " " + usr.nombre
            Me.mainTree.Nodes.Clear()
            For Each rol As BE.RolBE In usr.roles
                For Each comp As BE.ComponenteBE In rol.componentes
                    If comp.padre Is Nothing Then
                        For Each nodo As TreeNode In Me.mainTree.Nodes
                            If nodo.Text.Equals(comp.texto) Then
                                Exit For
                            End If
                        Next
                        Me.mainTree.Nodes.Add(New TreeNode(comp.texto, comp.nombre, "", comp.pagina, ""))
                    End If
                Next
                For Each comp As BE.ComponenteBE In rol.componentes
                    If Not comp.padre Is Nothing Then
                        For Each nodo As TreeNode In Me.mainTree.Nodes
                            If nodo.Text.Equals(comp.padre.texto) Then
                                For Each nodito As TreeNode In nodo.ChildNodes
                                    If nodito.Text.Equals(comp.texto) Then
                                        Exit For
                                    End If
                                Next
                                nodo.ChildNodes.Add(New TreeNode(comp.texto, comp.nombre, "", comp.pagina, ""))
                            End If
                        Next
                    End If
                Next
            Next
        Else
            loadBasic()
        End If
    End Sub

    Private Sub loadIdiomas()
        Me.idiomasList.DataSource = BLL.GestorIdiomaBLL.buscarIdiomas
        Me.idiomasList.DataTextField = "descripcion"
        Me.idiomasList.DataValueField = "id"
        Me.idiomasList.DataBind()
    End Sub

    Private Sub loadSelectedIdioma(idioma As IdiomaBE)
        If idioma.id = 0 Then
            Return
        End If
        Try
            For Each comp As BE.ComponenteBE In BLL.GestorIdiomaBLL.buscarComponentes(idioma)
                For Each con As Control In Page.Controls
                    loadSelectedIdioma(comp, con)
                Next
                For Each val As IValidator In Page.Validators
                    If Not val.ErrorMessage Is Nothing Then
                        val.ErrorMessage = BLL.GestorIdiomaBLL.getTranslation(val.ErrorMessage, idioma.id)
                    End If
                Next
            Next
        Catch ex As Exception
            Me.errorMessageLogger.Text = ex.Message
        End Try
    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs)
        Me.mainTree.Nodes.Clear()
        Session("Usuario") = Nothing
        usr = Nothing
        loadBasic()
        Response.Redirect("Main.aspx", False)
    End Sub

    Private Sub loadBasic()
        Dim t As New TreeNode
        t.Text = "Shop!"
        t.NavigateUrl = "Ventas.aspx"
        Me.mainTree.Nodes.Add(t)
    End Sub

    Private Sub checkPermisoPaginaActual()
        Dim paginaActual As String = Path.GetFileName(Request.PhysicalPath)
        'Debug.WriteLine("Pagina donde estoy parado 2: " + paginaActual)
        Dim permisoPaginaActual = False
        If paginaActual = "Login.aspx" Or paginaActual = "Main.aspx" Or paginaActual = "Ventas.aspx" Then
            permisoPaginaActual = True
        Else
            If Not usr Is Nothing And Not usr.roles Is Nothing Then
                For Each rol As BE.RolBE In usr.roles
                    For Each com As BE.ComponenteBE In rol.componentes
                        If Not com.pagina Is Nothing Then
                            If com.pagina = paginaActual Then
                                permisoPaginaActual = True
                            End If
                        End If
                    Next
                Next
            End If
        End If

        If permisoPaginaActual = False Then
            Response.Redirect("Main.aspx", False)
        End If
    End Sub

    Protected Sub loginButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Login.aspx", False)
    End Sub
End Class