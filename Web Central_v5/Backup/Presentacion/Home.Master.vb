Public Class Home
    Inherits System.Web.UI.MasterPage
    'Dim DAUsuario As New Capa_Datos.Usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim HideDiv = Me.FindControl("Obra")
        If HideDiv IsNot Nothing Then
            Dim Obra As HtmlGenericControl = CType(HideDiv.FindControl("Obra"), HtmlGenericControl)
            Dim Vehiculo As HtmlGenericControl = CType(HideDiv.FindControl("Vehiculo"), HtmlGenericControl)
            Dim Articulo As HtmlGenericControl = CType(HideDiv.FindControl("Articulo"), HtmlGenericControl)
            Dim Pedido As HtmlGenericControl = CType(HideDiv.FindControl("Pedido"), HtmlGenericControl)
            Dim Usuario As HtmlGenericControl = CType(HideDiv.FindControl("Usuario"), HtmlGenericControl)
            Dim Grupos As HtmlGenericControl = CType(HideDiv.FindControl("GRUPOS"), HtmlGenericControl)
            Dim Clientes As HtmlGenericControl = CType(HideDiv.FindControl("CLIENTES"), HtmlGenericControl)

            If Session("Us").ToString.ToUpper = "ADMINISTRADOR" And Session("Pass") = "a123456" Then


                'Obra.Visible = True
                'Vehiculo.Visible = True
                'Articulo.Visible = True
                'Pedido.Visible = True
                'Usuario.Visible = True
                'Grupos.Visible = True
                'Clientes.Visible = True
            Else
                'Dim ds = DAUsuario.Usuario_Modulos(Session("UsuId"))
                'Dim i = 0

                'While i < ds.Tables(0).Rows.Count



                '    Dim Modulo As Integer = ds.Tables(0).Rows(i).Item("ModuloId")
                '    Select Case Modulo
                '        Case 1
                '            Obra.Visible = True
                '        Case 2
                '            Vehiculo.Visible = True
                '        Case 3
                '            Articulo.Visible = True
                '        Case 4
                '            Pedido.Visible = True
                '        Case 5
                '            Usuario.Visible = True

                '    End Select

                '    i = i + 1
                'End While

            End If





        End If

    End Sub

End Class