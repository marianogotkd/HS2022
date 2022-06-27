Public Class Iniciar_dia
    Inherits System.Web.UI.Page
    Dim DArecorrido As New Capa_Datos.WC_recorridos_zonas
    Dim DAparametro As New Capa_Datos.WC_parametro

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            HF_fecha.Value = ""
            Dim ds_parametro As DataSet = DAparametro.Parametro_obtener_dia
            If ds_parametro.Tables(0).Rows.Count <> 0 Then
                Dim fecha As Date = CDate(ds_parametro.Tables(0).Rows(0).Item("Fecha"))
                HF_fecha.Value = fecha.ToString("yyyy-MM-dd")
                Txt_fecha.Text = fecha.ToString("yyyy-MM-dd")
                txt_dia.Text = ds_parametro.Tables(0).Rows(0).Item("Dia")
                Txt_fecha.ReadOnly = True
                txt_dia.Visible = False
                DIA_recuperado.Visible = True

                Select Case ds_parametro.Tables(0).Rows(0).Item("Dia")
                    Case 1 'domingo
                        DIA_recuperado.Text = "Domingo"
                    Case 2 'lunes
                        DIA_recuperado.Text = "Lunes"
                    Case 3 'martes
                        DIA_recuperado.Text = "Martes"
                    Case 4 'miercoles
                        DIA_recuperado.Text = "Miercoles"
                    Case 5 'jueves
                        DIA_recuperado.Text = "Jueves"
                    Case 6 'viernes
                        DIA_recuperado.Text = "Viernes"
                    Case 7 'sabado
                        DIA_recuperado.Text = "Sabado"
                End Select
            Else

            End If

            'Dim fecha As Date = Today
            'Txt_fecha.Text = fecha.ToString("yyyy-MM-dd")


            'Select Case fecha.DayOfWeek
            '    Case DayOfWeek.Sunday 'domingo
            '        txt_dia.Text = 1
            '    Case DayOfWeek.Monday 'lunes
            '        txt_dia.Text = 2
            '    Case DayOfWeek.Tuesday 'martes
            '        txt_dia.Text = 3
            '    Case DayOfWeek.Wednesday 'miercoles
            '        txt_dia.Text = 4
            '    Case DayOfWeek.Thursday 'jueves
            '        txt_dia.Text = 5
            '    Case DayOfWeek.Friday 'viernes
            '        txt_dia.Text = 6
            '    Case DayOfWeek.Saturday 'sabado
            '        txt_dia.Text = 7
            'End Select

            Txt_fecha.Focus()



            'colocar por defecto el dia en base a la fecha actua "today"


        End If


    End Sub
    Private Sub limpiar()
        lb_error_fecha.Visible = False
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub btn_grabar_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_close.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_grabar_mdl_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_mdl_cancelar.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_grabar_mdl_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_mdl.ServerClick
        If HF_fecha.Value = "" Then
            limpiar()
            Dim valido_ingreso As String = "si"
            Dim fecha As Date
            If Txt_fecha.Text = "" Then
                valido_ingreso = "no"
                lb_error_fecha.Visible = True
            Else
                Try
                    fecha = CDate(Txt_fecha.Text)
                Catch ex As Exception
                    valido_ingreso = "no"
                    lb_error_fecha.Visible = True
                End Try
            End If

            Dim dia As Integer
            Try
                dia = CInt(txt_dia.Text)
            Catch ex As Exception
                valido_ingreso = "no"

            End Try

            If valido_ingreso = "si" Then

                Dim ds_recorridos As DataSet = DArecorrido.recorridos_zonas_consultar_dia(dia)
                Dim recorrido As String = ""
                Dim i As Integer = 0
                While i < ds_recorridos.Tables(0).Rows.Count
                    If ds_recorridos.Tables(0).Rows(i).Item("Habilitada") <> "0" Then
                        recorrido = recorrido + CStr(ds_recorridos.Tables(0).Rows(i).Item("Codigo"))
                    End If

                    i = i + 1
                End While

                'consulto que no exista ya datos cargados para dicha fecha.
                Dim ds_info As DataSet = DAparametro.Parametro_consultar_fecha(fecha)
                If ds_info.Tables(0).Rows.Count = 0 Then
                    'alta
                    DAparametro.Parametro_Iniciar_dia(fecha, dia, recorrido)
                    'mensaje para notificar que se guardó correctamente.
                    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
                Else
                    'mensaje para confirmar modificación.
                    Dim Parametro_id As Integer = ds_info.Tables(0).Rows(0).Item("Parametro_id")
                    Session("Parametro_id") = Parametro_id
                    Session("recorrido") = recorrido
                    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_modif", "$(document).ready(function () {$('#Mdl_modif').modal();});", True)

                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
            End If
        Else
            'Error! ya se inició el dia de trabajo.   modal_sm_error_iniciodia
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_sm_error_iniciodia", "$(document).ready(function () {$('#modal_sm_error_iniciodia').modal();});", True)
        End If

        


    End Sub

    Private Sub btn_ok_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_close.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub btn_modif_close_mdl_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modif_close_mdl.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_modif_cancelar_mdl_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modif_cancelar_mdl.ServerClick
        Txt_fecha.Focus()
    End Sub

    Private Sub btn_modif_confirmar_mdl_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modif_confirmar_mdl.ServerClick
        limpiar()
        Dim valido_ingreso As String = "si"
        Dim fecha As Date
        If Txt_fecha.Text = "" Then
            valido_ingreso = "no"
            lb_error_fecha.Visible = True
        Else
            Try
                fecha = CDate(Txt_fecha.Text)
            Catch ex As Exception
                valido_ingreso = "no"
                lb_error_fecha.Visible = True
            End Try
        End If

        Dim dia As Integer
        Try
            dia = CInt(txt_dia.Text)
        Catch ex As Exception
            valido_ingreso = "no"

        End Try

        If valido_ingreso = "si" Then
            DAparametro.Parametro_modificar_dia(Session("Parametro_id"), fecha, dia, Session("recorrido"))
            Session("recorrido") = ""
            Session("Parametro_id") = ""
            'mensaje para notificar que se guardó correctamente.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
        End If
    End Sub

    Private Sub LinkButton_Domingo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Domingo.Click
        txt_dia.Text = 1
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Lunes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Lunes.Click
        txt_dia.Text = 2
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Martes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Martes.Click
        txt_dia.Text = 3
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Miercoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Miercoles.Click
        txt_dia.Text = 4
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Jueves_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Jueves.Click
        txt_dia.Text = 5
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Viernes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Viernes.Click
        txt_dia.Text = 6
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Sabado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Sabado.Click
        txt_dia.Text = 7
        txt_dia.Focus()
    End Sub
End Class