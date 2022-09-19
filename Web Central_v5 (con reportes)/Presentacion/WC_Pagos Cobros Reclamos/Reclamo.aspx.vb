Public Class Reclamo
    Inherits System.Web.UI.Page
    Dim Dacliente As New Capa_Datos.WB_clientes
    Dim DAparametro As New Capa_Datos.WC_parametro
    Dim DAanticipados As New Capa_Datos.WC_anticipados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'recuperar fecha de tabla parametro.
            Dim ds_fecha As DataSet = DAparametro.Parametro_obtener_dia
            If ds_fecha.Tables(0).Rows.Count <> 0 Then
                Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
                Txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")
            End If
            Txt_cliente_codigo.Focus()
            Txt_nombre.ReadOnly = True
            Txt_saldo.ReadOnly = True
            Txt_fecha.ReadOnly = True


        End If
    End Sub

    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick

        Try

            Dim ds_validar As DataSet = Dacliente.Clientes_buscar_codigo(Txt_cliente_codigo.Text)
            If ds_validar.Tables(0).Rows.Count <> 0 Then
                Txt_nombre.Text = ds_validar.Tables(0).Rows(0).Item("Nombre")
                Txt_saldo.Text = ds_validar.Tables(0).Rows(0).Item("Saldo")
                Txt_importe.Focus()
            Else
                'mensaje la busqueda no arrojo resultados.
                Txt_nombre.Text = ""
                Txt_saldo.Text = ""

                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_noexiste", "$(document).ready(function () {$('#modal-sm_error_noexiste').modal();});", True)
                btn_ok_error_noexiste.Focus()
            End If

        Catch ex As Exception

        End Try


    End Sub


#Region "modal-sm_error_noexiste"
    Private Sub btn_close_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_noexiste.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_ok_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_noexiste.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region


    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_Pagos Cobros Reclamos/PagosCobrosReclamos.aspx")
    End Sub

#Region "init"
    Private Sub Txt_cliente_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_codigo.Init
        Txt_cliente_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_nombre_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_nombre.Init
        Txt_nombre.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_saldo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_saldo.Init
        Txt_saldo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_importe_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_importe.Init
        Txt_importe.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    'Private Sub Txt_calculo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_calculo.Init
    '    Txt_calculo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    'End Sub

    'Private Sub Txt_prestamocredito_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_prestamocredito.Init
    '    Txt_prestamocredito.Attributes.Add("onfocus", "seleccionarTexto(this);")
    'End Sub

    Private Sub Txt_descripcion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_descripcion.Init
        Txt_descripcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fecha.Init
        Txt_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

#End Region

    

#Region "Mdl_graba"
    Private Sub btn_graba_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_cancelar.ServerClick
        Txt_importe.Focus()
    End Sub

    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Txt_importe.Focus()
    End Sub

    Private Sub lb_errores_blanqueo()
        lb_error_codigo.Visible = False
        lb_error_importe.Visible = False
        lb_error_sincalculo.Visible = False
        lb_error_prestamocredito.Visible = False
        lb_error_descripcion.Visible = False
        lb_error_fecha.Visible = False
    End Sub


    Private Sub btn_graba_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_confirmar.ServerClick
        lb_errores_blanqueo()
        'aqui guardo y abro el mensaje siguiente
        Dim valido_ingreso As String = "si"
        'consulto el cliente
        Dim ds_cliente As DataSet = Dacliente.Clientes_buscar_codigo(Txt_cliente_codigo.Text)
        Dim cliente As Integer = 0
        If ds_cliente.Tables(0).Rows.Count <> 0 Then
            cliente = ds_cliente.Tables(0).Rows(0).Item("Cliente")
        Else
            valido_ingreso = "no"
            lb_error_codigo.Visible = True
        End If

        Dim importe As Decimal = 0
        Try
            importe = CDec(Txt_importe.Text.Replace(".", ","))
        Catch ex As Exception
            lb_error_importe.Visible = True
            valido_ingreso = "no"
        End Try

        'Dim sincalculo As Integer
        'If Txt_calculo.Text = "" Then
        '    lb_error_sincalculo.Visible = True
        '    valido_ingreso = "no"
        'Else
        '    sincalculo = Txt_calculo.Text
        'End If

        'Dim prestamo_credito As Integer
        'If Txt_prestamocredito.Text = "" Then
        '    lb_error_prestamocredito.Visible = True
        '    valido_ingreso = "no"
        'Else
        '    prestamo_credito = Txt_prestamocredito.Text
        'End If

        'If Txt_descripcion.Text = "" Then
        '    lb_error_descripcion.Visible = True
        '    valido_ingreso = "no"
        'End If


        If Txt_fecha.Text = "" Then
            valido_ingreso = "no"
            lb_error_fecha.Visible = True
        Else
            Try
                Dim fecha As Date = CDate(Txt_fecha.Text)
            Catch ex As Exception
                valido_ingreso = "no"
                lb_error_fecha.Visible = True
            End Try
        End If

        If valido_ingreso = "si" Then
            DAanticipados.Anticipados_reclamo_alta(Txt_fecha.Text, cliente, 1, importe, CInt(DropDownList_sincalculo.SelectedValue), CInt(DropDownList_prestamocredito.SelectedValue), Txt_descripcion.Text, 0)
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
        Else
            'aqui va mensaje: "error, ingrese info solicitada"
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_ingreso", "$(document).ready(function () {$('#modal-sm_error_ingreso').modal();});", True)

        End If

    End Sub
#End Region


    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("~/WC_Pagos Cobros Reclamos/PagosCobrosReclamos.aspx")
    End Sub

    Private Sub btn_ok_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_close.ServerClick
        Response.Redirect("~/WC_Pagos Cobros Reclamos/PagosCobrosReclamos.aspx")
    End Sub

    Private Sub BOTON_GRABA_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABA.ServerClick
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba", "$(document).ready(function () {$('#Mdl_graba').modal();});", True)
    End Sub


    Private Sub error_foco_op()
        If lb_error_codigo.Visible = True Then
            Txt_cliente_codigo.Focus()
        Else
            If lb_error_importe.Visible = True Then
                Txt_importe.Focus()
            Else
                If lb_error_sincalculo.Visible = True Then
                    DropDownList_sincalculo.Focus()
                Else
                    If lb_error_prestamocredito.Visible = True Then
                        DropDownList_prestamocredito.Focus()
                    Else
                        If lb_error_descripcion.Visible = True Then
                            Txt_descripcion.Focus()
                        Else
                            If lb_error_fecha.Visible = True Then
                                Txt_fecha.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_erroringreso_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_erroringreso_close.ServerClick
        error_foco_op()
    End Sub

    Private Sub btn_erroringreso_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_erroringreso_ok.ServerClick
        error_foco_op()
    End Sub
End Class