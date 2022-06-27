Public Class ab_recorridos_zonas_activacion
    Inherits System.Web.UI.Page
    Dim DA_recorridos As New Capa_Datos.WC_recorridos_zonas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dia As Integer = CInt(Session("dia_seleccionado"))
            HF_dia_nro.Value = dia
            Select Case dia
                Case 1
                    Label_dia.Text = "DIA: DOMINGO"
                Case 2
                    Label_dia.Text = "DIA: LUNES"
                Case 3
                    Label_dia.Text = "DIA: MARTES"
                Case 4
                    Label_dia.Text = "DIA: MIERCOLES"
                Case 5
                    Label_dia.Text = "DIA: JUEVES"
                Case 6
                    Label_dia.Text = "DIA: VIERNES"
                Case 7
                    Label_dia.Text = "DIA: SABADO"
            End Select
            obtener_estado_recorridos(dia)

            Drop_1a.Focus()

        End If
    End Sub

    Public Function conv_bit(ByRef estado As Integer)
        If estado = -1 Then
            estado = 1
        Else
            If estado = 0 Then

            End If
        End If
        Return estado
    End Function

    Private Sub obtener_estado_recorridos(ByVal Dia_id As Integer)
        Dim ds_recorridos As DataSet = DA_recorridos.recorridos_zonas_consultar_dia(Dia_id)
        If ds_recorridos.Tables(0).Rows.Count <> 0 Then
            
            Lb_1a.Text = ds_recorridos.Tables(0).Rows(0).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper + ":"
            Lb_1b.Text = ds_recorridos.Tables(0).Rows(1).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(1).Item("Referencia").ToString.ToUpper + ":"
            Lb_1c.Text = ds_recorridos.Tables(0).Rows(2).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(2).Item("Referencia").ToString.ToUpper + ":"
            Lb_1d.Text = ds_recorridos.Tables(0).Rows(3).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(3).Item("Referencia").ToString.ToUpper + ":"
            Lb_1e.Text = ds_recorridos.Tables(0).Rows(4).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(4).Item("Referencia").ToString.ToUpper + ":"
            Lb_1f.Text = ds_recorridos.Tables(0).Rows(5).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(5).Item("Referencia").ToString.ToUpper + ":"
            Lb_1g.Text = ds_recorridos.Tables(0).Rows(6).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(6).Item("Referencia").ToString.ToUpper + ":"
            Lb_1h.Text = ds_recorridos.Tables(0).Rows(7).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(7).Item("Referencia").ToString.ToUpper + ":"
            Lb_1i.Text = ds_recorridos.Tables(0).Rows(8).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(8).Item("Referencia").ToString.ToUpper + ":"
            Lb_1j.Text = ds_recorridos.Tables(0).Rows(9).Item("Codigo").ToString.ToUpper + " - " + ds_recorridos.Tables(0).Rows(9).Item("Referencia").ToString.ToUpper + ":"

            Lb_2a.Text = ds_recorridos.Tables(0).Rows(10).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(10).Item("Referencia").ToString.ToUpper + ":"
            Lb_2b.Text = ds_recorridos.Tables(0).Rows(11).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(11).Item("Referencia").ToString.ToUpper + ":"
            Lb_2c.Text = ds_recorridos.Tables(0).Rows(12).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(12).Item("Referencia").ToString.ToUpper + ":"
            Lb_2d.Text = ds_recorridos.Tables(0).Rows(13).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(13).Item("Referencia").ToString.ToUpper + ":"
            Lb_2e.Text = ds_recorridos.Tables(0).Rows(14).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(14).Item("Referencia").ToString.ToUpper + ":"
            Lb_2f.Text = ds_recorridos.Tables(0).Rows(15).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(15).Item("Referencia").ToString.ToUpper + ":"
            Lb_2g.Text = ds_recorridos.Tables(0).Rows(16).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(16).Item("Referencia").ToString.ToUpper + ":"
            Lb_2h.Text = ds_recorridos.Tables(0).Rows(17).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(17).Item("Referencia").ToString.ToUpper + ":"
            Lb_2i.Text = ds_recorridos.Tables(0).Rows(18).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(18).Item("Referencia").ToString.ToUpper + ":"
            Lb_2j.Text = ds_recorridos.Tables(0).Rows(19).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(19).Item("Referencia").ToString.ToUpper + ":"

            Lb_3a.Text = ds_recorridos.Tables(0).Rows(20).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(20).Item("Referencia").ToString.ToUpper + ":"
            Lb_3b.Text = ds_recorridos.Tables(0).Rows(21).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(21).Item("Referencia").ToString.ToUpper + ":"
            Lb_3c.Text = ds_recorridos.Tables(0).Rows(22).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(22).Item("Referencia").ToString.ToUpper + ":"
            Lb_3d.Text = ds_recorridos.Tables(0).Rows(23).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(23).Item("Referencia").ToString.ToUpper + ":"
            Lb_3e.Text = ds_recorridos.Tables(0).Rows(24).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(24).Item("Referencia").ToString.ToUpper + ":"
            Lb_3f.Text = ds_recorridos.Tables(0).Rows(25).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(25).Item("Referencia").ToString.ToUpper + ":"
            Lb_3g.Text = ds_recorridos.Tables(0).Rows(26).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(26).Item("Referencia").ToString.ToUpper + ":"
            Lb_3h.Text = ds_recorridos.Tables(0).Rows(27).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(27).Item("Referencia").ToString.ToUpper + ":"
            Lb_3i.Text = ds_recorridos.Tables(0).Rows(28).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(28).Item("Referencia").ToString.ToUpper + ":"
            Lb_3j.Text = ds_recorridos.Tables(0).Rows(29).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(29).Item("Referencia").ToString.ToUpper + ":"

            Lb_4a.Text = ds_recorridos.Tables(0).Rows(30).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(30).Item("Referencia").ToString.ToUpper + ":"
            Lb_4b.Text = ds_recorridos.Tables(0).Rows(31).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(31).Item("Referencia").ToString.ToUpper + ":"
            Lb_4c.Text = ds_recorridos.Tables(0).Rows(32).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(32).Item("Referencia").ToString.ToUpper + ":"
            Lb_4d.Text = ds_recorridos.Tables(0).Rows(33).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(33).Item("Referencia").ToString.ToUpper + ":"
            Lb_4e.Text = ds_recorridos.Tables(0).Rows(34).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(34).Item("Referencia").ToString.ToUpper + ":"
            Lb_4f.Text = ds_recorridos.Tables(0).Rows(35).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(35).Item("Referencia").ToString.ToUpper + ":"
            Lb_4g.Text = ds_recorridos.Tables(0).Rows(36).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(36).Item("Referencia").ToString.ToUpper + ":"
            Lb_4h.Text = ds_recorridos.Tables(0).Rows(37).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(37).Item("Referencia").ToString.ToUpper + ":"
            Lb_4i.Text = ds_recorridos.Tables(0).Rows(38).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(38).Item("Referencia").ToString.ToUpper + ":"
            Lb_4j.Text = ds_recorridos.Tables(0).Rows(39).Item("Codigo").ToString.ToUpper + "-" + ds_recorridos.Tables(0).Rows(39).Item("Referencia").ToString.ToUpper + ":"

            Drop_1a.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(0).Item("Habilitada")))
            Drop_1b.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(1).Item("Habilitada")))
            Drop_1c.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(2).Item("Habilitada")))
            Drop_1d.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(3).Item("Habilitada")))
            Drop_1e.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(4).Item("Habilitada")))
            Drop_1f.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(5).Item("Habilitada")))
            Drop_1g.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(6).Item("Habilitada")))
            Drop_1h.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(7).Item("Habilitada")))
            Drop_1i.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(8).Item("Habilitada")))
            Drop_1j.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(9).Item("Habilitada")))

            Drop_2a.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(10).Item("Habilitada")))
            Drop_2b.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(11).Item("Habilitada")))
            Drop_2c.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(12).Item("Habilitada")))
            Drop_2d.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(13).Item("Habilitada")))
            Drop_2e.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(14).Item("Habilitada")))
            Drop_2f.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(15).Item("Habilitada")))
            Drop_2g.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(16).Item("Habilitada")))
            Drop_2h.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(17).Item("Habilitada")))
            Drop_2i.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(18).Item("Habilitada")))
            Drop_2j.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(19).Item("Habilitada")))

            Drop_3a.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(20).Item("Habilitada")))
            Drop_3b.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(21).Item("Habilitada")))
            Drop_3c.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(22).Item("Habilitada")))
            Drop_3d.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(23).Item("Habilitada")))
            Drop_3e.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(24).Item("Habilitada")))
            Drop_3f.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(25).Item("Habilitada")))
            Drop_3g.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(26).Item("Habilitada")))
            Drop_3h.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(27).Item("Habilitada")))
            Drop_3i.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(28).Item("Habilitada")))
            Drop_3j.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(29).Item("Habilitada")))

            Drop_4a.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(30).Item("Habilitada")))
            Drop_4b.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(31).Item("Habilitada")))
            Drop_4c.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(32).Item("Habilitada")))
            Drop_4d.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(33).Item("Habilitada")))
            Drop_4e.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(34).Item("Habilitada")))
            Drop_4f.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(35).Item("Habilitada")))
            Drop_4g.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(36).Item("Habilitada")))
            Drop_4h.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(37).Item("Habilitada")))
            Drop_4i.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(38).Item("Habilitada")))
            Drop_4j.SelectedValue = conv_bit(CInt(ds_recorridos.Tables(0).Rows(39).Item("Habilitada")))

            'Dim i As Integer = 0
            'While i < ds_recorridos.Tables(0).Rows.Count
            '    Dim codigo As String = ds_recorridos.Tables(0).Rows(i).Item("Codigo")
            '    Select Case codigo
            '        Case "1A"
            '            txt_1a.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1B"
            '            txt_1b.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1C"
            '            txt_1c.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1D"
            '            txt_1d.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1E"
            '            txt_1e.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1F"
            '            txt_1f.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1G"
            '            txt_1g.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1H"
            '            txt_1h.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1I"
            '            txt_1i.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "1J"
            '            txt_1j.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2A"
            '            txt_2a.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2B"
            '            txt_2b.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2C"
            '            txt_2c.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2D"
            '            txt_2d.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2E"
            '            txt_2e.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2F"
            '            txt_2f.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2G"
            '            txt_2g.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2H"
            '            txt_2h.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2I"
            '            txt_2i.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "2J"
            '            txt_2j.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))

            '        Case "3A"
            '            txt_3a.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3B"
            '            txt_3b.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3C"
            '            txt_3c.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3D"
            '            txt_3d.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3E"
            '            txt_3e.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3F"
            '            txt_3f.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3G"
            '            txt_3g.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3H"
            '            txt_3h.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3I"
            '            txt_3i.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "3J"
            '            txt_3j.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))

            '        Case "4A"
            '            txt_4a.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4B"
            '            txt_4b.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4C"
            '            txt_4c.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4D"
            '            txt_4d.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4E"
            '            txt_4e.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4F"
            '            txt_4f.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4G"
            '            txt_4g.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4H"
            '            txt_4h.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4I"
            '            txt_4i.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '        Case "4J"
            '            txt_4j.Text = conv_bit(CInt(ds_recorridos.Tables(0).Rows(i).Item("Habilitada")))
            '    End Select

            '    i = i + 1
            'End While
        End If


    End Sub



    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_AB Recorridos_Zonas/ab_recorridos_zonas.aspx")
    End Sub


    Private Sub BOTON_GRABAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABAR.ServerClick
        Try
            Dim ds_recorridos As DataSet = DA_recorridos.recorridos_zonas_consultar_dia(HF_dia_nro.Value)
            If ds_recorridos.Tables(0).Rows.Count <> 0 Then
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(0).Item("Codigo"), CInt(Drop_1a.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(1).Item("Codigo"), CInt(Drop_1b.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(2).Item("Codigo"), CInt(Drop_1c.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(3).Item("Codigo"), CInt(Drop_1d.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(4).Item("Codigo"), CInt(Drop_1e.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(5).Item("Codigo"), CInt(Drop_1f.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(6).Item("Codigo"), CInt(Drop_1g.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(7).Item("Codigo"), CInt(Drop_1h.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(8).Item("Codigo"), CInt(Drop_1i.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(9).Item("Codigo"), CInt(Drop_1j.SelectedValue))

                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(10).Item("Codigo"), CInt(Drop_2a.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(11).Item("Codigo"), CInt(Drop_2b.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(12).Item("Codigo"), CInt(Drop_2c.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(13).Item("Codigo"), CInt(Drop_2d.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(14).Item("Codigo"), CInt(Drop_2e.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(15).Item("Codigo"), CInt(Drop_2f.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(16).Item("Codigo"), CInt(Drop_2g.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(17).Item("Codigo"), CInt(Drop_2h.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(18).Item("Codigo"), CInt(Drop_2i.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(19).Item("Codigo"), CInt(Drop_2j.SelectedValue))

                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(20).Item("Codigo"), CInt(Drop_3a.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(21).Item("Codigo"), CInt(Drop_3b.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(22).Item("Codigo"), CInt(Drop_3c.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(23).Item("Codigo"), CInt(Drop_3d.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(24).Item("Codigo"), CInt(Drop_3e.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(25).Item("Codigo"), CInt(Drop_3f.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(26).Item("Codigo"), CInt(Drop_3g.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(27).Item("Codigo"), CInt(Drop_3h.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(28).Item("Codigo"), CInt(Drop_3i.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(29).Item("Codigo"), CInt(Drop_3j.SelectedValue))

                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(30).Item("Codigo"), CInt(Drop_4a.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(31).Item("Codigo"), CInt(Drop_4b.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(32).Item("Codigo"), CInt(Drop_4c.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(33).Item("Codigo"), CInt(Drop_4d.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(34).Item("Codigo"), CInt(Drop_4e.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(35).Item("Codigo"), CInt(Drop_4f.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(36).Item("Codigo"), CInt(Drop_4g.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(37).Item("Codigo"), CInt(Drop_4h.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(38).Item("Codigo"), CInt(Drop_4i.SelectedValue))
                DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), ds_recorridos.Tables(0).Rows(39).Item("Codigo"), CInt(Drop_4j.SelectedValue))

            End If

            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1A", CInt(txt_1a.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1B", CInt(txt_1b.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1C", CInt(txt_1c.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1D", CInt(txt_1d.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1E", CInt(txt_1e.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1F", CInt(txt_1f.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1G", CInt(txt_1g.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1H", CInt(txt_1h.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1I", CInt(txt_1i.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "1J", CInt(txt_1j.Text))

            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2A", CInt(txt_2a.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2B", CInt(txt_2b.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2C", CInt(txt_2c.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2D", CInt(txt_2d.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2E", CInt(txt_2e.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2F", CInt(txt_2f.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2G", CInt(txt_2g.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2H", CInt(txt_2h.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2I", CInt(txt_2i.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "2J", CInt(txt_2j.Text))

            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3A", CInt(txt_3a.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3B", CInt(txt_3b.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3C", CInt(txt_3c.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3D", CInt(txt_3d.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3E", CInt(txt_3e.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3F", CInt(txt_3f.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3G", CInt(txt_3g.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3H", CInt(txt_3h.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3I", CInt(txt_3i.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "3J", CInt(txt_3j.Text))

            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4A", CInt(txt_4a.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4B", CInt(txt_4b.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4C", CInt(txt_4c.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4D", CInt(txt_4d.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4E", CInt(txt_4e.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4F", CInt(txt_4f.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4G", CInt(txt_4g.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4H", CInt(txt_4h.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4I", CInt(txt_4i.Text))
            'DA_recorridos.recorridos_zonas_activacion(CInt(HF_dia_nro.Value), "4J", CInt(txt_4j.Text))
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)

        End Try

        



    End Sub

    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("~/WC_AB Recorridos_Zonas/ab_recorridos_zonas.aspx")
    End Sub

    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Response.Redirect("~/WC_AB Recorridos_Zonas/ab_recorridos_zonas.aspx")
    End Sub

#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        Drop_1a.Focus()
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        Drop_1a.Focus()
    End Sub


#End Region
End Class