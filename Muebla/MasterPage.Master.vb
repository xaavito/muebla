Imports BE

Public Class MasterPage

    Inherits System.Web.UI.MasterPage
    Dim usr As UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usr = Session("Usuario")
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
                        Me.mainTree.Nodes.Add(New TreeNode(comp.texto, "", "", comp.pagina, ""))
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
                                nodo.ChildNodes.Add(New TreeNode(comp.texto, "", "", comp.pagina, ""))
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Sub

    Protected Sub shoppingCart_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("Carrito.aspx")
    End Sub
End Class