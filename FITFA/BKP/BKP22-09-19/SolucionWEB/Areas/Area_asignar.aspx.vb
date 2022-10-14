Public Class Area_asignar
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAarea As New Capa_de_datos.Area
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            no_evento.Visible = False
            'div_Modal_error_inscripto.Visible = False
            obtener_eventos_disponibles()
            'Session("popup") = "si"
            'popup = "no"
            'evento_disp_div.Visible = False

        End If
    End Sub

    Private Sub recuperar_areas()
        'con el primer evento seleccionado, voy a recuperar las mesas si existen.
        Dim ds_area As DataSet = DAarea.area_obtener_asignadas(DropDownEvento.SelectedValue, 0)
        If ds_area.Tables(0).Rows.Count <> 0 Then
            'Label_evento.Text = DropDownEvento.Text
            seccion_areas_asignadas.Visible = True
            GridView1.DataSource = ds_area.Tables(0)
            GridView1.DataBind()
        Else
            'como no hay nada no muestro.
            'Label_evento.Text = ""
            seccion_areas_asignadas.Visible = False
        End If
    End Sub

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_obtener_torneos()
        'If ds_eventos.Tables(1).Rows.Count <> 0 Then
        '    DropDownList_eventos.DataSource = ds_eventos.Tables(1)
        '    DropDownList_eventos.DataValueField = "id"
        '    DropDownList_eventos.DataTextField = "desc"
        '    DropDownList_eventos.DataBind()
        'End If

        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDownEvento.DataSource = ds_eventos.Tables(0)
            DropDownEvento.DataValueField = "id"
            DropDownEvento.DataTextField = "Descripción"
            DropDownEvento.DataBind()

            'con el primer evento seleccionado, voy a recuperar las mesas si existen.
            Dim ds_area As DataSet = DAarea.area_obtener_asignadas(DropDownEvento.SelectedValue, 0)
            If ds_area.Tables(0).Rows.Count <> 0 Then
                'Label_evento.Text = DropDownEvento.Text
                seccion_areas_asignadas.Visible = True
                GridView1.DataSource = ds_area.Tables(0)
                GridView1.DataBind()
            Else
                'como no hay nada no muestro.
                'Label_evento.Text = ""
                seccion_areas_asignadas.Visible = False
            End If

        Else
            seccion_evento.Visible = False
            seccion_area.Visible = False
            btn_guardar.Visible = False
            seccion_areas_asignadas.Visible = False
            no_evento.Visible = True
            'choco.Visible = True
            '    Label12.Text = "choquito"
            'ModalPopupExtender1.Show()
        End If

    End Sub

    Private Sub DropDownEvento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownEvento.SelectedIndexChanged
        recuperar_areas()
    End Sub

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick
        'no olvidar validar el dropdown evento
        If DropDownEvento.Items.Count <> 0 Then 'valido que existan eventos
            Dim ds_ars As DataSet = DAarea.area_obtener_asignadas(DropDownEvento.SelectedValue, 0)
            If ds_ars.Tables(0).Rows.Count = 0 Then
                If DropDownList_nroareas.Items.Count <> 0 Then
                    'cargo N areas segun lo que indique en el dropdownareas
                    Dim cant As Integer = CInt(DropDownList_nroareas.SelectedValue)
                    'aqui guardo
                    Dim i As Integer = 0
                    Dim nro_area As Integer = 1
                    While i < cant
                        DAarea.area_alta("Area " + CStr(nro_area), DropDownEvento.SelectedValue)
                        nro_area = nro_area + 1
                        i = i + 1
                    End While
                    'luego llamo a la rutina
                    'con el evento actual seleccionado, voy a recuperar las areas si existen.
                    Dim ds_ar As DataSet = DAarea.area_obtener_asignadas(DropDownEvento.SelectedValue, 0)
                    If ds_ar.Tables(0).Rows.Count <> 0 Then
                        'Label_evento.Text = DropDownEvento.Text
                        seccion_areas_asignadas.Visible = True
                        GridView1.DataSource = ds_ar.Tables(0)
                        GridView1.DataBind()
                    Else
                        'como no hay nada no muestro.
                        'Label_evento.Text = ""
                        seccion_areas_asignadas.Visible = False
                    End If
                End If
            Else
                'aqui va el mensaje, no se pueden agregar mas mesas, ya se encuentran configuradas
            End If
        End If
    End Sub
End Class