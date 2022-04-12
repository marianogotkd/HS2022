Public Class Cobro_prestamos_manuales
    Inherits System.Web.UI.Page
    Dim DAprestamoscreditos As New Capa_Datos.WC_prestamoscreditos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Txt_cliente_codigo.Focus()

        End If
    End Sub
    Dim DS_cobro_prestamos_manuales As New DS_cobro_prestamos_manuales
    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        Try
            seccion_resultado_busqueda.Visible = False
            DS_cobro_prestamos_manuales.Prestamos_Activos.Rows.Clear()
            GridView1.DataSource = ""
            GridView1.Columns(0).Visible = True '0 es columna ID

            Dim ds_info As DataSet = DAprestamoscreditos.Prestamos_cliente_buscar_activos(Txt_cliente_codigo.Text)
            If ds_info.Tables(0).Rows.Count <> 0 Then
                seccion_resultado_busqueda.Visible = True
                Label_cliente.Text = ds_info.Tables(0).Rows(0).Item("Codigo") + ". " + ds_info.Tables(0).Rows(0).Item("Nombre")

                If ds_info.Tables(1).Rows.Count <> 0 Then
                    DS_cobro_prestamos_manuales.Prestamos_Activos.Merge(ds_info.Tables(1))
                    GridView1.DataSource = DS_cobro_prestamos_manuales.Prestamos_Activos
                    GridView1.DataBind()
                    GridView1.Columns(0).Visible = False '0 es columna ID
                Else
                    'no posee prestamos activos
                    seccion_resultado_busqueda.Visible = False
                    'aqui mensaje informativo.
                    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_noactivos", "$(document).ready(function () {$('#modal_error_noactivos').modal();});", True)
                End If

            Else
                'error la busqueda no arrojo resultados. verifique el codigo de cliente.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
            End If

        Catch ex As Exception
            'error la busqueda no arrojo resultados. verifique el codigo de cliente.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
        End Try
        Txt_cliente_codigo.Focus() 'siempre queda aqui el foco


    End Sub


#Region "modal_error_busqueda"
    Private Sub btn_close_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_busqueda.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_ok_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_busqueda.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region


#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub Txt_cliente_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_codigo.Init
        Txt_cliente_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
#End Region

#Region "modal_error_noactivos"
    Private Sub btn_close_error_noactivos_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_noactivos.ServerClick
        Txt_cliente_codigo.Focus()

    End Sub

    Private Sub btn_ok_error_noactivos_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_noactivos.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region
    
    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub
    Dim DAparametro As New Capa_Datos.WC_parametro
    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")

            'obtener fecha del dia de la tabla parametro
            Dim ds_fecha As DataSet = DAparametro.Parametro_obtener_dia
            Dim FECHA As Date = Today
            If ds_fecha.Tables(0).Rows.Count <> 0 Then
                FECHA = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
                Session("Idprestamocredito") = id
                Response.Redirect("~/WC_Cobro Prestamos Manuales/Cobro_prestamos_manuales_det.aspx")
            Else
                
                'mostrar msj de error...debe iniciar el dia.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-error_iniciar_dia", "$(document).ready(function () {$('#modal-error_iniciar_dia').modal();});", True)



            End If


            
        End If


    End Sub

    Private Sub btn_error_iniciar_dia_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_error_iniciar_dia_close.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_error_iniciar_dia_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_error_iniciar_dia_ok.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
End Class