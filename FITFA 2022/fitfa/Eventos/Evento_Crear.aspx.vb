Imports System.Drawing
Imports System.IO
Public Class Evento_Crear
    Inherits System.Web.UI.Page
    Dim DAevento As New Capa_de_datos.Eventos
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("evento_id") = 0 'inicio en 0 para validar el guardado. sino inserta 2 veces.

            Session("imagen") = ""
            Session("foto_subido") = "no"
            lbl_errFecCier.Visible = False
            lbl_errNom.Visible = False
            lbl_costo.Visible = False
            lbl_errfechaini.Visible = False
            lbl_horaCierre.Visible = False
            lbl_turnos_error0.Visible = False
            lbl_error_cap_max_inscr.Visible = False
            'lbl_errImg.Visible = False
            tb_fechainicio.Value = Today
            tb_fechaCierre.Value = Today
            textbox_Costo.Text = 0
            Page.Form.Attributes.Add("enctype", "multipart/form-data")
            div_modal_msjOK.Visible = False
            crear_tabla_turnos()
        End If


    End Sub

    Private Sub crear_tabla_turnos()
        GridView1.DataSource = Nothing
        Dim ds_eventos As New ds_eventos
        ds_eventos.Tables("Turnos").Rows.Clear()
        Dim cont = 0
        Dim horas As Integer = 8
        While cont < 14
            Dim row As DataRow = ds_eventos.Tables("Turnos").NewRow()
            row("Turno") = CStr(horas) + " hrs."

            ds_eventos.Tables("Turnos").Rows.Add(row)
            cont = cont + 1
            horas = horas + 1
        End While
        GridView1.DataSource = ds_eventos.Tables("Turnos")
        GridView1.DataBind()
    End Sub



#Region "manejo de foto"
    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

#End Region
    Dim ChkTurno As CheckBox


    Private Sub limpiar_textbox_etc()
        tb_nombre.Value = ""
        lbl_errNom.Visible = False

        tb_direccion.Value = ""

        tb_fechainicio.Value = Today
        lbl_errfechaini.Visible = False

        tb_fechaCierre.Value = Today
        lbl_errFecCier.Visible = False

        lbl_horaCierre.Visible = False

        textbox_Costo.Text = "0"
        lbl_costo.Visible = False

        tb_capacidad_max.Text = ""
        lbl_error_cap_max_inscr.Visible = False

        lbl_turnos_error0.Visible = False
        'limpio check en grilla turnos
        Dim j As Integer = 0
        While j < GridView1.Rows.Count
            'ChkTurno = CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox)
            CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox).Checked = False
            j = j + 1
        End While
    End Sub

    Private Sub combo_TipoEvento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_TipoEvento.SelectedIndexChanged

        If combo_TipoEvento.SelectedValue = "Examen" Then
            Panel_examenes.Visible = True
            cost_seccion.Visible = False
        Else
            Panel_examenes.Visible = False
            cost_seccion.Visible = True
        End If

    End Sub

    Private Sub boton_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boton_ok.Click

    End Sub

    Private Sub Btn_modal_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_modal_guardar.ServerClick

        Dim Vacio As Boolean

        If tb_nombre.Value = "" Then
            lbl_errNom.Visible = True
            Vacio = True
        End If

        If tb_fechainicio.Value = "" Then
            lbl_errfechaini.Visible = True
            Vacio = True
        End If

        If tb_fechaCierre.Value = "" Then
            lbl_errFecCier.Visible = True
            Vacio = True
        End If

        If tb_horaCierre.Value = "" Then
            lbl_horaCierre.Visible = True
            Vacio = True
        End If
        Dim costo = textbox_Costo.Text
        If Session("foto_subido") = "no" Then
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen") = imagebytes
        End If
        Dim FechaHoraCierre = tb_fechaCierre.Value + " " + tb_horaCierre.Value
        If Vacio = False Then

            Dim server_validar As String = "no"
            If Session("evento_id") = 0 Then
                server_validar = "valido"
            Else
                Try
                    Session("evento_id") = CInt(Session("evento_id"))
                Catch ex As Exception
                    Session("evento_id") = 0
                End Try
                'verifico si en la bd no hay un evento con ese id
                Dim validar As DataSet = DAevento.Eventos_validar(Session("evento_id"))
                If validar.Tables(0).Rows.Count = 0 Then
                    server_validar = "valido"
                End If
            End If

            If server_validar = "valido" Then
                If combo_TipoEvento.SelectedValue = "Examen" Then

                    Dim valido_cap_max As String = "no"
                    If tb_capacidad_max.Text = "" Then
                        tb_capacidad_max.Text = "0"
                        valido_cap_max = "no"
                    Else
                        If CInt(tb_capacidad_max.Text) > 0 Then
                            valido_cap_max = "si"
                        Else
                            valido_cap_max = "no"
                        End If
                    End If
                    'controlo que al menos haya seleccionado 1 turno.
                    Dim valido As String = "no"
                    Dim i As Integer = 0
                    While i < GridView1.Rows.Count
                        ChkTurno = CType(Me.GridView1.Rows(i).FindControl("chk_turno"), CheckBox)
                        If ChkTurno.Checked = True Then
                            valido = "si"
                            Exit While
                        End If
                        i = i + 1
                    End While

                    If (valido = "si") And (valido_cap_max = "si") Then
                        'Dim copia_ds_evento As New ds_eventos
                        'copia_ds_evento.Tables("Turnos").Rows.Clear()
                        ''ahora guardo los turnos
                        'Dim j As Integer = 0
                        'While j < GridView1.Rows.Count
                        '    ChkTurno = CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox)
                        '    If ChkTurno.Checked = True Then
                        '        Dim fila As DataRow = copia_ds_evento.Tables("Turnos").NewRow
                        '        fila("Turnos") = Me.GridView1.Rows(j).Cells("Turno").ToString
                        '        copia_ds_evento.Tables("Turnos").Rows.Add(fila)
                        '    End If
                        '    j = j + 1
                        'End While

                        'es un torneo o un curso
                        If costo = "" Then
                            costo = "0"
                        End If
                        Dim ds_info_evento As DataSet = DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(0), tb_direccion.Value, CInt(tb_capacidad_max.Text))
                        Dim evento_id As Integer = ds_info_evento.Tables(0).Rows(0).Item("evento_id")
                        Session("evento_id") = evento_id
                        'If costo = "" Then
                        '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(0), tb_direccion.Value)
                        'Else
                        '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(costo), tb_direccion.Value)
                        'End If
                        Dim j As Integer = 0
                        While j < GridView1.Rows.Count
                            ChkTurno = CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox)
                            If ChkTurno.Checked = True Then
                                'aqui guardo en bd cada turno.
                                Dim Turno = Me.GridView1.Rows(j).Cells(1).Text
                                DAevento.ExamenTurno_alta(evento_id, Turno)
                            End If
                            j = j + 1
                        End While

                        'limpiar_textbox_etc()
                        limpiar_textbox_etc()
                        div_modal_msjOK.Visible = True
                        Modal_msjOK.Show()

                    Else
                        If valido = "no" Then
                            lbl_turnos_error0.Visible = True
                            Vacio = True
                        End If
                        If valido_cap_max = "no" Then
                            lbl_error_cap_max_inscr.Visible = True
                            Vacio = True
                        End If
                    End If
                    ''aqui paso a otra web page para cargar los turnos de los examenes.
                    'Response.Redirect("~/Eventos/Examenes_turnos_agregar.aspx")
                Else
                    'es un torneo o un curso
                    If costo = "" Then
                        Dim ds_info_evento As DataSet = DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(costo), tb_direccion.Value, CInt(0))
                        Dim evento_id As Integer = ds_info_evento.Tables(0).Rows(0).Item("evento_id")
                        Session("evento_id") = evento_id
                    Else
                        Dim ds_info_evento As DataSet = DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(costo), tb_direccion.Value, CInt(0))
                        Dim evento_id As Integer = ds_info_evento.Tables(0).Rows(0).Item("evento_id")
                        Session("evento_id") = evento_id
                    End If

                    limpiar_textbox_etc()
                    div_modal_msjOK.Visible = True
                    Modal_msjOK.Show()
                End If
                'Response.Redirect("~/Eventos/Evento_Crear.aspx")

                'lbl_ok.Visible = True
                'tb_nombre.Value = ""
                'tb_fechainicio.Value = Today
                'tb_fechaCierre.Value = Today
                'tb_horaCierre.Value = ""
                'textbox_Costo.Text = 0
                'FileUpload1.Attributes.Clear()
                'Image1.Visible = False
                'btn_quitar.Visible = False
                'btn_Examinar.Visible = True
            Else
                'blanqueo la variable de sesion para poder inscribir otro
                limpiar_textbox_etc()
                Session("evento_id") = 0
                div_modal_msjOK.Visible = True
                Modal_msjOK.Show()

            End If

        End If

    End Sub
End Class