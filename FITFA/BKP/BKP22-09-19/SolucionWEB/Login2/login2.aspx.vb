Imports System.IO
Imports System.Data.OleDb

Public Class login2
    Inherits System.Web.UI.Page

    Dim DAusuario As New Capa_de_datos.usuario
    Dim DATorneo As New Capa_de_datos.Torneo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        If txt_pass.Text = "" Or txt_Usuario.Text = "" Then
            lbl_error.Text = "Los datos ingresados son incorrectos"
            lbl_error.Visible = True
        Else
            Dim Estado As String
            Dim ds As DataSet = DAusuario.Usuario_Sesion(txt_Usuario.Text, txt_pass.Text)

            If ds.Tables(0).Rows.Count <> 0 Then
                Estado = ds.Tables(0).Rows(0).Item("usuario_estado").ToString
                If Estado = "activo" Then
                    Session("Us_id") = ds.Tables(0).Rows(0).Item(0).ToString
                    Session("Tipo") = ds.Tables(0).Rows(0).Item("usuario_tipo").ToString
                    Session("Area") = ""
                    If Session("Tipo") = "Torneo" Then

                        Dim Ds_torneo As DataSet = DATorneo.UsuarioEvento_Obtener(Session("Us_id"))
                        Session("evento_id") = Ds_torneo.Tables(0).Rows(0).Item(1).ToString
                        Session("ConDni") = False
                        Response.Redirect("../Torneo/Seleccion_Area.aspx")
                    Else
                        Response.Redirect("../Inicio_Blanco.aspx")
                    End If

                Else
                    lbl_error.Text = "Su estado es inactivo consulte con su instructor"
                    lbl_error.Visible = True
                End If
            Else

                lbl_error.Text = "Los datos ingresados son incorrectos"
                lbl_error.Visible = True

            End If
        End If

        



    End Sub
End Class