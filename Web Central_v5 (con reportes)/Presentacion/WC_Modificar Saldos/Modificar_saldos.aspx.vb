Public Class Modificar_saldos
    Inherits System.Web.UI.Page
    Dim DAClientes As New Capa_Datos.WB_clientes
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Txt_cliente_id.Focus()
        End If

    End Sub

    Private Sub btn_modificar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.ServerClick
        If Txt_cliente_id.Text <> "" Then
            Dim ds_clie As DataSet = DAClientes.Clientes_buscar_codigo(Txt_cliente_id.Text)

            If ds_clie.Tables(0).Rows.Count <> 0 Then
                Session("clientes_op") = "modificar"
                'pasar ademas el ID del grupo.
                Session("cliente_id") = CInt(ds_clie.Tables(0).Rows(0).Item("Cliente"))
                Response.Redirect("Modificar_saldos_detalle.aspx")
            Else
                'no existe
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
                
            End If
        Else
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
        End If
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        Txt_cliente_id.Focus()
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        Txt_cliente_id.Focus()
    End Sub

    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub Txt_cliente_id_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_id.Init
        Txt_cliente_id.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub



End Class