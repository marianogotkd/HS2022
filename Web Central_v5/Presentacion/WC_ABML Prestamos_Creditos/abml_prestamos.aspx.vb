Public Class abml_prestamos
    Inherits System.Web.UI.Page
    Dim Daparametro As New Capa_Datos.WC_parametro
    Dim DAprestamoscreditos As New Capa_Datos.WC_prestamoscreditos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Txt_cliente_codigo.Focus()
            'recuperar fecha de tabla parametro.
            Dim ds_fecha As DataSet = Daparametro.Parametro_obtener_dia
            If ds_fecha.Tables(0).Rows.Count <> 0 Then
                Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
                txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")
            End If

        End If
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
    End Sub

    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        lb_cliente_nomb.InnerText = "Nombre:"
        Txt_importe.Text = ""
        'Txt_tipo.Text = ""
        Txt_porcentaje.Text = ""

        Try
            Dim Fecha As Date = CDate(txt_fecha.Text)

            If Txt_cliente_codigo.Text <> "" Then
                Dim ds_info As DataSet = DAprestamoscreditos.Prestamos_buscar_cliente_info(Txt_cliente_codigo.Text, txt_fecha.Text)
                If ds_info.Tables(2).Rows.Count <> 0 Then
                    'cargo la info del credito que se recupero para esa fecha.
                    lb_cliente_nomb.InnerText = "Nombre: " + ds_info.Tables(2).Rows(0).Item("Nombre")
                    Txt_importe.Text = CDec(ds_info.Tables(2).Rows(0).Item("Importe"))
                    'Txt_tipo.Text = ds_info.Tables(2).Rows(0).Item("Tipocobro")

                    DropDownList_tipo.SelectedValue = ds_info.Tables(2).Rows(0).Item("Tipocobro")

                    Txt_porcentaje.Text = CDec(ds_info.Tables(2).Rows(0).Item("Porcentaje"))
                    Txt_importe.Focus()
                Else
                    If ds_info.Tables(0).Rows.Count <> 0 Then
                        lb_cliente_nomb.InnerText = "Nombre: " + ds_info.Tables(0).Rows(0).Item("Nombre")
                        Txt_importe.Focus()
                    Else
                        'no existe, emitir un mensaje.
                        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_noexiste", "$(document).ready(function () {$('#modal-sm_error_noexiste').modal();});", True)
                    End If


                End If
            Else
                'no existe, emitir un mensaje.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_noexiste", "$(document).ready(function () {$('#modal-sm_error_noexiste').modal();});", True)
            End If


        Catch ex As Exception
            'mensaje ingrese fecha para buscar.
            'no existe, emitir un mensaje.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_fecha", "$(document).ready(function () {$('#modal-sm_error_fecha').modal();});", True)
        End Try


    End Sub

#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub Txt_cliente_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_codigo.Init
        Txt_cliente_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fecha.Init
        txt_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    'Private Sub Txt_tipo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_tipo.Init
    '    Txt_tipo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    'End Sub

    Private Sub Txt_porcentaje_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_porcentaje.Init
        Txt_porcentaje.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
    Private Sub Txt_importe_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_importe.Init
        Txt_importe.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
#End Region


#Region "modal-sm_error_noexiste"
    Private Sub btn_close_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_noexiste.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_ok_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_noexiste.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region
#Region "modal-sm_error_fecha"
    Private Sub btn_close_error_fecha_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_fecha.ServerClick
        txt_fecha.Focus()
    End Sub

    Private Sub btn_ok_error_fecha_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_fecha.ServerClick
        txt_fecha.Focus()
    End Sub
#End Region
    Private Sub limpiar_label_error()
        lb_error_codigo.Visible = False
        lb_error_fecha.Visible = False
        lb_error_importe.Visible = False
        lb_error_tipo.Visible = False
        lb_error_porcentaje.Visible = False
    End Sub

    Private Sub BOTON_GRABA_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABA.DataBinding

    End Sub
    
    Private Sub BOTON_GRABA_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABA.ServerClick
        limpiar_label_error()
        Dim valido_ingreso As String = "si"

        If Txt_cliente_codigo.Text = "" Then
            valido_ingreso = "no"
            lb_error_codigo.Visible = True
        End If

        If txt_fecha.Text = "" Then
            valido_ingreso = "no"
            lb_error_fecha.Visible = True
        Else
            Try
                Dim fecha As Date = CDate(txt_fecha.Text)
            Catch ex As Exception
                valido_ingreso = "no"
                lb_error_fecha.Visible = True
            End Try
        End If

        Dim importe As Decimal
        Try
            importe = CDec(Txt_importe.Text.Replace(".", ","))
        Catch ex As Exception
            valido_ingreso = "no"
            lb_error_importe.Visible = True
        End Try

        'If Txt_tipo.Text = "" Then
        '    valido_ingreso = "no"
        '    lb_error_tipo.Visible = True
        'End If

        Dim porcentaje As Decimal
        Try
            porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))
        Catch ex As Exception
            porcentaje = CDec(0)
            lb_error_porcentaje.Visible = False
            valido_ingreso = "no"
        End Try

        If valido_ingreso = "si" Then
            Try
                Dim ds_info As DataSet = DAprestamoscreditos.Prestamos_buscar_cliente_info(Txt_cliente_codigo.Text, txt_fecha.Text)
                If ds_info.Tables(0).Rows.Count <> 0 Then 'verifico que existe el cliente
                    Session("Cliente") = ds_info.Tables(0).Rows(0).Item("Cliente")
                    If ds_info.Tables(2).Rows.Count <> 0 Then
                        'entonces pregunto si quiero modificar el prestamo actual.
                        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba_modif", "$(document).ready(function () {$('#Mdl_graba_modif').modal();});", True)
                    Else
                        'entonces es un alta para ello primero valido si tengo margen para pedir creditos

                        Dim cant_pc As Integer = CInt(ds_info.Tables(0).Rows(0).Item("Cantidadpc"))

                        If ds_info.Tables(1).Rows.Count < cant_pc Then
                            'entonces pregunto si deseo dar de alta el prestamo.
                            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba_alta", "$(document).ready(function () {$('#Mdl_graba_alta').modal();});", True)
                        Else
                            'mensaje: Cantidad máxima. No puede solicitar un prestamo.

                            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_limite", "$(document).ready(function () {$('#modal-sm_error_limite').modal();});", True)
                        End If

                    End If
                End If


            Catch ex As Exception

            End Try
        Else
            'mensaje ingrese la informacion solicitada.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_ingreso", "$(document).ready(function () {$('#modal-sm_error_ingreso').modal();});", True)
        End If

        

    End Sub
#Region "Mdl_graba_alta"
    Private Sub btn_graba_alta_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_close.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_graba_alta_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_cancelar.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_graba_alta_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_confirmar.ServerClick
        'aqui codigo de alta.
        Dim importe As Decimal
        Try
            importe = CDec(Txt_importe.Text.Replace(".", ","))

        Catch ex As Exception
            importe = CDec(0)
        End Try
        Dim porcentaje As Decimal

        Try
            porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))

        Catch ex As Exception
            porcentaje = CDec(0)
        End Try

        DAprestamoscreditos.Prestamos_alta(CInt(Session("Cliente")), txt_fecha.Text, importe, CStr(DropDownList_tipo.SelectedValue), porcentaje)

        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
    End Sub
#End Region

#Region "modal-sm_OKGRABADO"
    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
    End Sub

    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
    End Sub
#End Region
    
#Region "modal-sm_error_ingreso"
    Private Sub btn_close_error_ingreso_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_ingreso.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_ok_error_ingreso_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_ingreso.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region

#Region "Mdl_graba_modif"
    Private Sub btn_graba_modif_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_cancelar.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_graba_modif_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_close.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_graba_modif_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_confirmar.ServerClick
        'aqui codigo de alta.
        Dim importe As Decimal
        Try
            importe = CDec(Txt_importe.Text.Replace(".", ","))
        Catch ex As Exception
            importe = CDec(0)
        End Try

        Dim porcentaje As Decimal
        Try
            porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))
        Catch ex As Exception
            porcentaje = CDec(0)
        End Try
        DAprestamoscreditos.Prestamos_modificar(CInt(Session("Cliente")), txt_fecha.Text, importe, CStr(DropDownList_tipo.SelectedValue), porcentaje, 1)
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
    End Sub
#End Region

#Region "modal-sm_error_limite"
    Private Sub btn_close_error_limite_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_limite.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub

    Private Sub btn_ok_error_limite_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_limite.ServerClick
        Txt_cliente_codigo.Focus()
    End Sub
#End Region


    

End Class