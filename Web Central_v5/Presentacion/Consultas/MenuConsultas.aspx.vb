Public Class MenuConsultas
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      txt_opcion.Focus()
    End If


  End Sub


  Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
    txt_opcion.Focus()
  End Sub

  Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
    txt_opcion.Focus()
  End Sub


  'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
  Private Sub txt_opcion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_opcion.Init
    txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub LinkButton_CodigoPremiado_Click(sender As Object, e As EventArgs) Handles LinkButton_CodigoPremiado.Click

  End Sub

  Private Sub LinkButton_CodigosMasCargados_Click(sender As Object, e As EventArgs) Handles LinkButton_CodigosMasCargados.Click
    Response.Redirect("~/Consultas/CodigoMasPremiadoRecorridos.aspx")
  End Sub

  Private Sub LinkButton_IngresoDeTerminales_Click(sender As Object, e As EventArgs) Handles LinkButton_IngresoDeTerminales.Click
    Response.Redirect("~/Consultas/IngresoTerminales.aspx")
  End Sub

  Private Sub BOTON_GRABAR_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABAR.ServerClick
    Select Case txt_opcion.Text.ToUpper
      Case "1"
        Response.Redirect("~/Consultas/CodigoMasPremiadoRecorridos.aspx")
      Case "2"
        'Response.Redirect("~/WC_Carga de Recorridos_Zonas/carga_recorridos_zonas_a.aspx")
      Case "3"
        Response.Redirect("~/Consultas/IngresoTerminales.aspx")

      Case Else
        ''aqui va mensaje de error.
        'no existe
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)

    End Select

  End Sub
End Class
