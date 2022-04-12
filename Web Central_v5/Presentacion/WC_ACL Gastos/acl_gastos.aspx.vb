Public Class acl_gastos
    Inherits System.Web.UI.Page
    Dim DAgastos As New Capa_Datos.WC_gastos

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
                Response.Redirect("~/WC_ACL Gastos/acl_gastos_alta.aspx")
            Case "2"
                'primero verifico que exista al menos 1 grupo_tipo
                Dim ds_validar As DataSet = DAgastos.GastosTipo_obtener_todos
                If ds_validar.Tables(0).Rows.Count <> 0 Then
                    Response.Redirect("~/WC_ACL Gastos/acl_gastos_carga.aspx")

                Else
                    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_sm_error2", "$(document).ready(function () {$('#modal_sm_error2').modal();});", True)
                End If
            Case "3"
                Response.Redirect("~/WC_ACL Gastos/acl_gastos_resumen.aspx")
            
            Case Else
                ''aqui va mensaje de error.
                'no existe
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)

        End Select

    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        txt_opcion.Focus()
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        txt_opcion.Focus()
    End Sub

    Private Sub btn_close_error2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error2.ServerClick
        txt_opcion.Focus()

    End Sub

    Private Sub btn_ok_error2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error2.ServerClick
        txt_opcion.Focus()
    End Sub

    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_opcion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_opcion.Init
        txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub LinkButton_alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_alta.Click
        Response.Redirect("~/WC_ACL Gastos/acl_gastos_alta.aspx")
    End Sub

    Private Sub LinkButton_carga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_carga.Click
        'primero verifico que exista al menos 1 grupo_tipo
        Dim ds_validar As DataSet = DAgastos.GastosTipo_obtener_todos
        If ds_validar.Tables(0).Rows.Count <> 0 Then
            Response.Redirect("~/WC_ACL Gastos/acl_gastos_carga.aspx")

        Else
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_sm_error2", "$(document).ready(function () {$('#modal_sm_error2').modal();});", True)
        End If
    End Sub

    Private Sub LinkButton_resumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_resumen.Click
        Response.Redirect("~/WC_ACL Gastos/acl_gastos_resumen.aspx")
    End Sub
End Class