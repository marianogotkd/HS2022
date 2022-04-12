Public Class acl_gastos_alta
    Inherits System.Web.UI.Page
    Dim DAgastos As New Capa_Datos.WC_gastos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtener_gastos_tipo()
            Txt_motivo.Text = ""
            limpiar()
            Txt_motivo.Focus()
        End If


    End Sub

    Private Sub obtener_gastos_tipo()
        Dim dataset1 As DataSet = DAgastos.GastosTipo_obtener_todos
        GridView1.DataSource = dataset1.Tables(0)
        GridView1.DataBind()
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_ACL Gastos/acl_gastos.aspx")
    End Sub

    Private Sub btn_graba_mdl_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_mdl_cancelar.ServerClick
        Txt_motivo.Focus()
    End Sub

    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Txt_motivo.Focus()
    End Sub

    Private Sub btn_graba_mdll_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_mdll.ServerClick

        'si confirma, valida y guarda
        Dim valido As String = "si"
        Dim ds_info As DataSet = DAgastos.GastosTipo_validar(Txt_motivo.Text)
        If ds_info.Tables(0).Rows.Count <> 0 Then
            valido = "no"
        End If
        If valido = "si" And Txt_motivo.Text <> "" Then
            DAgastos.GastosTipo_alta(Txt_motivo.Text)
            Response.Redirect("~/WC_ACL Gastos/acl_gastos.aspx")
        Else
            'modifique el motivo, ya existe.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
            lb_error_motivo.Visible = True
        End If
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        Txt_motivo.Focus()
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        Txt_motivo.Focus()
    End Sub

    Private Sub limpiar()
        lb_error_motivo.Visible = False
    End Sub
End Class