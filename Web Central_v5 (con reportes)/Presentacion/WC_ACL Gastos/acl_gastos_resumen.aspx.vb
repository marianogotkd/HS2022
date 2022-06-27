Public Class acl_gastos_resumen
    Inherits System.Web.UI.Page
    Dim Daparametro As New Capa_Datos.WC_parametro
    Dim Dagastos As New Capa_Datos.WC_gastos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Txt_cliente_codigo.Focus()
            'recuperar fecha de tabla parametro.
            Dim ds_fecha As DataSet = Daparametro.Parametro_obtener_dia
            If ds_fecha.Tables(0).Rows.Count <> 0 Then
                Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
                Hf_FECHA.Value = FECHA
                txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")
                obtener_resumen(FECHA)

                txt_fecha.Focus()
            End If

        End If
    End Sub
    Dim DS_gastos As New DS_gastos

    Private Sub obtener_resumen(ByVal Fecha As Date)
        DS_gastos.Tabla1.Rows.Clear()

        GridView1.Columns(0).Visible = True
        'GridView1.DataSource = ""
        Dim ds_info As DataSet = Dagastos.Gastos_resumen(Fecha)
        If ds_info.Tables(0).Rows.Count <> 0 Then
            DS_gastos.Tabla1.Merge(ds_info.Tables(0))

            GridView1.DataSource = DS_gastos.Tabla1
            GridView1.DataBind()
        Else
            GridView1.DataSource = DS_gastos.Tabla1
            GridView1.DataBind()
        End If
        GridView1.Columns(0).Visible = False 'oculto la columna ID

    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_ACL Gastos/acl_gastos.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            Session("ID") = id

            'aqui pregunto si estoy seguro de eliminar.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_baja", "$(document).ready(function () {$('#Mdl_baja').modal();});", True)

        End If
    End Sub

    Private Sub btn_baja_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_close.ServerClick
        'nada
    End Sub

    Private Sub btn_baja_mdl_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_mdl_cancelar.ServerClick
        'nada
    End Sub

    Private Sub btn_baja_mdll_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_mdll.ServerClick
        Try
            'aqui codigo para eliminar.
            Dagastos.Gastos_eliminar(Session("ID"))
            Session("ID") = ""
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKELIMINADO", "$(document).ready(function () {$('#modal-sm_OKELIMINADO').modal();});", True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_ELIMINAR_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ELIMINAR_close.ServerClick
        Try
            'cargo la grilla nuevamente con la info actualizada.
            obtener_resumen(Hf_FECHA.Value)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_ok_elimnar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_elimnar.ServerClick
        'cargo la grilla nuevamente con la info actualizada.
        Try
            obtener_resumen(Hf_FECHA.Value)
            txt_fecha.Focus()
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        Try
            'habilito la columan ID.
            'habilito la columna Eliminar
            GridView1.Columns(0).Visible = True '0 es columna ID
            GridView1.Columns(6).Visible = True '6 es columna eliminar


            DS_gastos.Tabla1.Rows.Clear()
            GridView1.DataSource = ""
            Dim ds_info As DataSet = Dagastos.Gastos_resumen(txt_fecha.Text)
            If ds_info.Tables(0).Rows.Count <> 0 Then
                DS_gastos.Tabla1.Merge(ds_info.Tables(0))
                GridView1.DataSource = DS_gastos.Tabla1
                GridView1.DataBind()
                GridView1.Columns(0).Visible = False '0 es columna ID

                Try
                    If CDate(Hf_FECHA.Value) <> CDate(txt_fecha.Text) Then
                        GridView1.Columns(6).Visible = False '6 es columna eliminar
                    End If
                Catch ex As Exception

                End Try
                GridView1.Focus()

            Else
                GridView1.DataSource = DS_gastos.Tabla1
                GridView1.DataBind()
                GridView1.Columns(0).Visible = False '0 es columna ID
                GridView1.Columns(6).Visible = False '6 es columna eliminar
                'la busqueda no arrojo resultados.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
            GridView1.Columns(0).Visible = False '0 es columna ID
            GridView1.Columns(6).Visible = False '6 es columna eliminar
        End Try
    End Sub

#Region "modal_error_busqueda"
    Private Sub btn_ok_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_busqueda.ServerClick
        txt_fecha.Focus()
    End Sub

    Private Sub btn_close_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_busqueda.ServerClick
        txt_fecha.Focus()
    End Sub
#End Region

#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fecha.Init
        txt_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
#End Region

End Class