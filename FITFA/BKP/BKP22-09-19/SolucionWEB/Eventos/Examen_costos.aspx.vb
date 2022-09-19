Public Class Examen_costos
    Inherits System.Web.UI.Page


    Dim DAcostos As New Capa_de_datos.Costos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            div_modalOK.Visible = False
            recuperar_costos()



        End If


    End Sub

    Dim Examen_ds As New Examen_ds

    Private Sub recuperar_costos()
        Examen_ds.Tables("Costos_examenes").Rows.Clear()
        Examen_ds.Tables("Costos_otros").Rows.Clear()
        Dim ds_info As DataSet = DAcostos.Costos_obtener
        If ds_info.Tables(0).Rows.Count <> 0 Then
            Examen_ds.Tables("Costos_examenes").Merge(ds_info.Tables(0))
            GridView_examenes.DataSource = Examen_ds.Tables("Costos_examenes")
            GridView_examenes.DataBind()
        End If
        If ds_info.Tables(1).Rows.Count <> 0 Then
            Examen_ds.Tables("Costos_otros").Merge(ds_info.Tables(1))
            GridView_OTROS.DataSource = Examen_ds.Tables("Costos_otros")
            GridView_OTROS.DataBind()
        End If

    End Sub
    Dim chk_select As CheckBox
    Private Sub Btn_confirmar_montoexamen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirmar_montoexamen.Click

        Try
            Dim costos_monto As Decimal = CDec(txt_montoexamen.Text)
            Dim cambios_efectuados As String = "no"
            Dim i As Integer = 0
            While i < GridView_examenes.Rows.Count
                chk_select = CType(Me.GridView_examenes.Rows(i).FindControl("chk_select"), CheckBox)
                If chk_select.Checked = True Then
                    Dim costos_id As Integer = CInt(Me.GridView_examenes.Rows(i).Cells(0).Text)
                    DAcostos.Costos_modificar(costos_id, costos_monto)
                    cambios_efectuados = "si"
                End If
                i = i + 1
            End While
            If cambios_efectuados = "si" Then
                'aqui va el  modal de OK, cambios efectuados.
                recuperar_costos()
                div_modalOK.Visible = True
                Modal_OK.Show()
            End If
            Label_error_monto1.Visible = False
        Catch ex As Exception
            'si falla es x que se tipeo mal el precio.
            'aqui llamo al modal del error, el cartel.
            Label_error_monto1.Visible = True
        End Try
        

    End Sub

    Private Sub Btn_confirmar_montootros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirmar_montootros.Click
        Try
            Dim costos_monto As Decimal = CDec(txt_monto_otro.Text)
            Dim cambios_efectuados As String = "no"
            Dim i As Integer = 0
            While i < GridView_OTROS.Rows.Count
                chk_select = CType(Me.GridView_OTROS.Rows(i).FindControl("chk_select"), CheckBox)
                If chk_select.Checked = True Then
                    Dim costos_id As Integer = CInt(Me.GridView_OTROS.Rows(i).Cells(0).Text)
                    DAcostos.Costos_modificar(costos_id, costos_monto)
                    cambios_efectuados = "si"
                End If
                i = i + 1
            End While
            If cambios_efectuados = "si" Then
                'aqui va el  modal de OK, cambios efectuados.
                recuperar_costos()
                div_modalOK.Visible = True
                Modal_OK.Show()
            End If
            Label_error_monto2.Visible = False
        Catch ex As Exception
            'si falla es x que se tipeo mal el precio.
            'aqui llamo al modal del error, el cartel.
            Label_error_monto2.Visible = True
        End Try
    End Sub
End Class