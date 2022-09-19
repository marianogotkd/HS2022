Public Class abml_prestamoscreditos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_opcion.Focus()
        End If
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub BOTON_GRABAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABAR.ServerClick

        Select Case txt_opcion.Text.ToUpper
            Case "1"
                Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamos.aspx")
            Case "2"
                Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_creditos.aspx")
            Case "3"
                Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos_resumen.aspx")

            Case Else
                ''aqui va mensaje de error.
                'no existe
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)

        End Select
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        txt_opcion.Focus()
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        txt_opcion.Focus()
    End Sub

    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_opcion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_opcion.Init
        txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub LinkButton_prestamos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_prestamos.Click
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamos.aspx")
    End Sub

    Private Sub LinkButton_creditos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_creditos.Click
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_creditos.aspx")
    End Sub

    Private Sub LinkButton_resumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_resumen.Click
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos_resumen.aspx")
    End Sub
End Class