Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Public Class Inicio_Blanco
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        div_area.Visible = False

        If Session("Area") = "" Then

        Else
            div_area.Visible = True
            Lbl_Nomarea.Text = Session("Nom_area").ToString

        End If

    End Sub

End Class