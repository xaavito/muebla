Imports BE

Public Class MasterPage

    Inherits System.Web.UI.MasterPage
    Dim usr As UsuarioBE
    Dim idioma As IdiomaBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        usr = Session("Usuario")

        loadPermisos(usr)
        loadIdiomas()
        idioma = New BE.IdiomaBE
        idioma.id = Session("Idioma")
        loadSelectedIdioma(idioma)
        Me.idiomasList.SelectedValue = idioma.id
    End Sub

    Protected Sub shoppingCart_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("Carrito.aspx")
    End Sub

    Protected Sub idiomasList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Idioma") = Me.idiomasList.SelectedValue
        If Not Session("Idioma") Is Nothing Then
            Dim idioma As New BE.IdiomaBE
            idioma.id = Session("Idioma")
            loadSelectedIdioma(idioma)
        End If
    End Sub

    Private Sub getItems(comp As BE.ComponenteBE, con As Control)
        If TypeOf con Is GridView Then
            If Not CType(con, GridView).HeaderRow Is Nothing Then
                For Each cel As TableCell In CType(con, GridView).HeaderRow.Cells
                    For Each c As Control In cel.Controls
                        If TypeOf c Is LinkButton Then
                            Debug.WriteLine(CType(c, LinkButton).Text)
                            'aca me voy a tener que mandar un reverse search, o sea por el nombre en un idioma busco el equivalente en el otro...
                            'If CType(c, LinkButton).ID.Equals(comp.nombre) Then
                            'CType(c, LinkButton).Text = comp.texto
                            'End If
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
                            If CType(Control, Label).ID.Equals(comp.nombre) Then
                                CType(Control, Label).Text = comp.texto
                            End If
                        End If
                    Next
                Next
            Next
        Else
            If con.HasControls Then
                For Each c As Control In con.Controls
                    getItems(comp, c)
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
        End If
    End Sub

    Private Sub loadIdiomas()
        Me.idiomasList.DataSource = BLL.GestorIdiomaBLL.buscarIdiomas
        Me.idiomasList.DataTextField = "descripcion"
        Me.idiomasList.DataValueField = "id"
        Me.idiomasList.DataBind()
    End Sub

    Private Sub loadSelectedIdioma(idioma As IdiomaBE)
        For Each comp As BE.ComponenteBE In BLL.GestorIdiomaBLL.buscarComponentes(idioma)
            For Each con As Control In Page.Controls
                getItems(comp, con)
            Next
        Next
    End Sub

End Class