Imports System.IO
Imports System.Data.OleDb
Public Class LoginDNI


    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button_Reg_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Reg.ServerClick
        Response.Redirect("../Registro/registro.aspx")
    End Sub

    Private Sub Button_conti_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_conti.ServerClick
        Dim Estado As String
        Dim ds As DataSet = DAusuario.Usuario_validar_DNI(txt_Usuario.Text)
        If ds.Tables(0).Rows.Count <> 0 Then
            Estado = ds.Tables(0).Rows(0).Item("usuario_estado").ToString
            If (Estado = "activo") Or (Estado = "invitado") Then
                Session("Us_id") = ds.Tables(0).Rows(0).Item(0).ToString
                Session("Tipo") = ds.Tables(0).Rows(0).Item("usuario_tipo").ToString
                Session("ConDni") = True
                Response.Redirect("../Inscripciones/Evento_seleccionar.aspx")
            Else
                lbl_error.Text = "Su estado es inactivo consulte con su instructor"
                lbl_error.Visible = True
            End If
        Else
            lbl_error.Text = "Lo sentimos, no se encuentra registrado"
            lbl_error.Visible = True

        End If

    End Sub
End Class