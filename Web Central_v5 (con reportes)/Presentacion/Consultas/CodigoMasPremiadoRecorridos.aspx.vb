Public Class CodigoMasPremiadoRecorridos
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DArecorrido As New Capa_Datos.WC_recorridos_zonas
  Dim DApuntos As New Capa_Datos.WC_puntos
#End Region

#Region "EVENTOS"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      'AQUI VALIDO, SI NO HAY NINGUNA FECHA EN LA TABLA PARAMETRO, PONGO UN MENSAJE MODAL QUE DIGA:
      'ERROR, PRIMERO DEBE INICIAR DIA.
      Dim ds_info As DataSet = DAparametro.Parametro_obtener_dia
      If ds_info.Tables(0).Rows.Count <> 0 Then
        'cargo la fecha y el dia en los textbox
        HF_parametro_id.Value = ds_info.Tables(0).Rows(0).Item("Parametro_id")
        Dim FECHA As Date = CDate(ds_info.Tables(0).Rows(0).Item("Fecha"))
        Txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")
        'Txt_fecha.Text = FECHA.ToString("dd-MM-yyyy")
        HF_fecha.Value = ds_info.Tables(0).Rows(0).Item("Fecha")
        Dim dia As Integer = CInt(ds_info.Tables(0).Rows(0).Item("Dia"))
        HF_dia_id.Value = dia
        Select Case dia
          Case 1
            Label_dia.Text = "DIA: DOMINGO."
          Case 2
            Label_dia.Text = "DIA: LUNES."
          Case 3
            Label_dia.Text = "DIA: MARTES."
          Case 4
            Label_dia.Text = "DIA: MIERCOLES."
          Case 5
            Label_dia.Text = "DIA: JUEVES."
          Case 6
            Label_dia.Text = "DIA: VIERNES."
          Case 7
            Label_dia.Text = "DIA: SABADO."
        End Select
        mostrar_zonas_habilitadas(dia)

      Else
        'AQUI MENSAJE Y QUE CON EL BOTON "OK" U "CLOSE" VUELVA AL MENU PRINCIPAL.
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If
      Txt_fecha.Enabled = False
      txt_zona.Focus()
    End If
  End Sub
  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub
  Private Sub btn_error_close_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub
  Private Sub BOTON_GRABAR_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABAR.ServerClick
    Dim DS_liqparcial As New DS_liqparcial

    Recorrido_1(DS_liqparcial)
    Recorrido_2(DS_liqparcial)
    Recorrido_3(DS_liqparcial)
    Recorrido_4(DS_liqparcial)

    If DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Count <> 0 Then
      Session("fecha_parametro") = HF_fecha.Value
      Session("tabla_recorridos_seleccionados") = DS_liqparcial.Tables("Recorridos_seleccionados")
      Response.Redirect("~/Consultas/CodigoMasPremiado.aspx")
    Else
      'error, no se seleccionó ningunan item
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_msjerror_liq01", "$(document).ready(function () {$('#modal_msjerror_liq01').modal();});", True)
    End If



  End Sub
  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Consultas/MenuConsultas.aspx")
  End Sub
#End Region

#Region "METODOS"
  Private Sub mostrar_zonas_habilitadas(ByVal dia As Integer)
    HF_1TODAS.Value = "1*"
    HF_2TODAS.Value = "2*"
    HF_3TODAS.Value = "3*"
    HF_4TODAS.Value = "4*"
    LK_1TODOS.Text = "1* - TODAS"
    LK_2TODAS.Text = "2* - TODAS"
    LK_3TODAS.Text = "3* - TODAS"
    LK_4TODAS.Text = "4* - TODAS"

    Dim DS_Recorridos As DataSet = DArecorrido.recorridos_zonas_obtener_habilitados_x_dia(dia)
    'inicialmente tengo los label de zonas en "visible=false"
    Dim i As Integer = 0
    While i < DS_Recorridos.Tables(1).Rows.Count
      Dim Habilitada As Integer = conv_bit(CInt(DS_Recorridos.Tables(1).Rows(i).Item("Habilitada")))
      Dim codigo As String = DS_Recorridos.Tables(1).Rows(i).Item("Codigo")
      Select Case i
        Case 0
          If Habilitada = 1 Then
            HF_1A_codigo.Value = codigo
            Div_1A.Visible = True
            LK_1A.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1A.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If

        Case 1
          If Habilitada = 1 Then
            HF_1B_codigo.Value = codigo
            Div_1B.Visible = True
            LK_1B.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1B.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If

        Case 2
          If Habilitada = 1 Then
            HF_1C_codigo.Value = codigo
            Div_1C.Visible = True
            LK_1C.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1C.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 3
          If Habilitada = 1 Then
            HF_1D_codigo.Value = codigo
            Div_1D.Visible = True
            LK_1D.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1D.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 4
          If Habilitada = 1 Then
            HF_1E_codigo.Value = codigo
            Div_1E.Visible = True
            LK_1E.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1E.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 5
          If Habilitada = 1 Then
            HF_1F_codigo.Value = codigo
            Div_1F.Visible = True
            LK_1F.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1F.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 6
          If Habilitada = 1 Then
            HF_1G_codigo.Value = codigo
            Div_1G.Visible = True
            LK_1G.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1G.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 7
          If Habilitada = 1 Then
            HF_1H_codigo.Value = codigo
            Div_1H.Visible = True
            LK_1H.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1H.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 8
          If Habilitada = 1 Then
            HF_1I_codigo.Value = codigo
            Div_1I.Visible = True
            LK_1I.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1I.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If
        Case 9
          If Habilitada = 1 Then
            HF_1J_codigo.Value = codigo
            Div_1J.Visible = True
            LK_1J.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_1J.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_1TODAS.Visible = True
          End If


        Case 10
          If Habilitada = 1 Then
            HF_2A_codigo.Value = codigo
            Div_2A.Visible = True
            LK_2A.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2A.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 11
          If Habilitada = 1 Then
            HF_2B_codigo.Value = codigo
            Div_2B.Visible = True
            LK_2B.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2B.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 12
          If Habilitada = 1 Then
            HF_2C_codigo.Value = codigo
            Div_2C.Visible = True
            LK_2C.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2C.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 13
          If Habilitada = 1 Then
            HF_2D_codigo.Value = codigo
            Div_2D.Visible = True
            LK_2D.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2D.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 14
          If Habilitada = 1 Then
            HF_2E_codigo.Value = codigo
            Div_2E.Visible = True
            LK_2E.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2E.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 15
          If Habilitada = 1 Then
            HF_2F_codigo.Value = codigo
            Div_2F.Visible = True
            LK_2F.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2F.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 16
          If Habilitada = 1 Then
            HF_2G_codigo.Value = codigo
            Div_2G.Visible = True
            LK_2G.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2G.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 17
          If Habilitada = 1 Then
            HF_2H_codigo.Value = codigo
            Div_2H.Visible = True
            LK_2H.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2H.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 18
          If Habilitada = 1 Then
            HF_2I_codigo.Value = codigo
            Div_2I.Visible = True
            LK_2I.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2I.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 19
          If Habilitada = 1 Then
            HF_2J_codigo.Value = codigo
            Div_2J.Visible = True
            LK_2J.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_2J.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_2TODAS.Visible = True
          End If
        Case 20
          If Habilitada = 1 Then
            HF_3A_codigo.Value = codigo
            Div_3A.Visible = True
            LK_3A.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3A.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 21
          If Habilitada = 1 Then
            HF_3B_codigo.Value = codigo
            Div_3B.Visible = True
            LK_3B.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3B.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 22
          If Habilitada = 1 Then
            HF_3C_codigo.Value = codigo
            Div_3C.Visible = True
            LK_3C.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3C.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 23
          If Habilitada = 1 Then
            HF_3D_codigo.Value = codigo
            Div_3D.Visible = True
            LK_3D.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3D.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 24
          If Habilitada = 1 Then
            HF_3E_codigo.Value = codigo
            Div_3E.Visible = True
            LK_3E.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3E.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 25
          If Habilitada = 1 Then
            HF_3F_codigo.Value = codigo
            Div_3F.Visible = True
            LK_3F.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3F.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 26
          If Habilitada = 1 Then
            HF_3G_codigo.Value = codigo
            Div_3G.Visible = True
            LK_3G.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3G.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 27
          If Habilitada = 1 Then
            HF_3H_codigo.Value = codigo
            Div_3H.Visible = True
            LK_3H.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3H.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 28
          If Habilitada = 1 Then
            HF_3I_codigo.Value = codigo
            Div_3I.Visible = True
            LK_3I.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3I.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 29
          If Habilitada = 1 Then
            HF_3J_codigo.Value = codigo
            Div_3J.Visible = True
            LK_3J.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_3J.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_3TODAS.Visible = True
          End If
        Case 30
          If Habilitada = 1 Then
            HF_4A_codigo.Value = codigo
            Div_4A.Visible = True
            LK_4A.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4A.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 31
          If Habilitada = 1 Then
            HF_4B_codigo.Value = codigo
            Div_4B.Visible = True
            LK_4B.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4B.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 32
          If Habilitada = 1 Then
            HF_4C_codigo.Value = codigo
            Div_4C.Visible = True
            LK_4C.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4C.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 33
          If Habilitada = 1 Then
            HF_4D_codigo.Value = codigo
            Div_4D.Visible = True
            LK_4D.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4D.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 34
          If Habilitada = 1 Then
            HF_4E_codigo.Value = codigo
            Div_4E.Visible = True
            LK_4E.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4E.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 35
          If Habilitada = 1 Then
            HF_4F_codigo.Value = codigo
            Div_4F.Visible = True
            LK_4F.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4F.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 36
          If Habilitada = 1 Then
            HF_4G_codigo.Value = codigo
            Div_4G.Visible = True
            LK_4G.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4G.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 37
          If Habilitada = 1 Then
            HF_4H_codigo.Value = codigo
            Div_4H.Visible = True
            LK_4H.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4H.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 38
          If Habilitada = 1 Then
            HF_4I_codigo.Value = codigo
            Div_4I.Visible = True
            LK_4I.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4I.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
        Case 39
          If Habilitada = 1 Then
            HF_4J_codigo.Value = codigo
            Div_4J.Visible = True
            LK_4J.Text = DS_Recorridos.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper + " - " + DS_Recorridos.Tables(1).Rows(i).Item("Referencia").ToString.ToUpper
            Dim cargado As String = verificar_puntos_guardados2(dia, codigo, "si")
            If cargado = "si" Then
              LK_4J.ForeColor = Drawing.Color.ForestGreen
            End If
            Div_4TODAS.Visible = True
          End If
      End Select
      'verificar_puntos_guardados(dia, codigo)
      i = i + 1
    End While
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
  Private Function verificar_puntos_guardados2(ByVal dia As Integer, ByVal codigo As String, ByRef cargado As String)
    Dim ds_info As DataSet = DApuntos.Puntos_obtener_cargados(Txt_fecha.Text, dia, codigo)
    If ds_info.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 2
      While i < 22
        If ds_info.Tables(0).Rows(0).Item(i).ToString = "" Then
          cargado = "no"
          Exit While
        End If
        i = i + 1
      End While
    Else
      cargado = "no"
    End If
    Return cargado
  End Function
  Private Sub Cargar_recorrido_valido(ByVal codigo As String, ByRef DS_liqparcial As DataSet)
    Dim fila As DataRow = DS_liqparcial.Tables("Recorridos_seleccionados").NewRow
    fila("Codigo") = codigo
    DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Add(fila)
  End Sub
  Private Sub Recorrido_1(ByRef DS_liqparcial As DataSet)
    If ChkBox_1TODAS.Checked = True Then
      Cargar_recorrido_valido("1A", DS_liqparcial)
      Cargar_recorrido_valido("1B", DS_liqparcial)
      Cargar_recorrido_valido("1C", DS_liqparcial)
      Cargar_recorrido_valido("1D", DS_liqparcial)
      Cargar_recorrido_valido("1E", DS_liqparcial)
      Cargar_recorrido_valido("1F", DS_liqparcial)
      Cargar_recorrido_valido("1G", DS_liqparcial)
      Cargar_recorrido_valido("1H", DS_liqparcial)
      Cargar_recorrido_valido("1I", DS_liqparcial)
      Cargar_recorrido_valido("1J", DS_liqparcial)

    Else
      If ChkBox_1A.Checked = True Then
        Cargar_recorrido_valido("1A", DS_liqparcial)
      End If
      If ChkBox_1B.Checked = True Then
        Cargar_recorrido_valido("1B", DS_liqparcial)
      End If
      If ChkBox_1C.Checked = True Then
        Cargar_recorrido_valido("1C", DS_liqparcial)
      End If
      If ChkBox_1D.Checked = True Then
        Cargar_recorrido_valido("1D", DS_liqparcial)
      End If
      If ChkBox_1E.Checked = True Then
        Cargar_recorrido_valido("1E", DS_liqparcial)
      End If
      If ChkBox_1F.Checked = True Then
        Cargar_recorrido_valido("1F", DS_liqparcial)
      End If
      If ChkBox_1G.Checked = True Then
        Cargar_recorrido_valido("1G", DS_liqparcial)
      End If
      If ChkBox_1H.Checked = True Then
        Cargar_recorrido_valido("1H", DS_liqparcial)
      End If
      If ChkBox_1I.Checked = True Then
        Cargar_recorrido_valido("1I", DS_liqparcial)
      End If
      If ChkBox_1J.Checked = True Then
        Cargar_recorrido_valido("1J", DS_liqparcial)
      End If

    End If
  End Sub
  Private Sub Recorrido_2(ByRef DS_liqparcial As DataSet)
    If ChkBox_2TODAS.Checked = True Then
      Cargar_recorrido_valido("2A", DS_liqparcial)
      Cargar_recorrido_valido("2B", DS_liqparcial)
      Cargar_recorrido_valido("2C", DS_liqparcial)
      Cargar_recorrido_valido("2D", DS_liqparcial)
      Cargar_recorrido_valido("2E", DS_liqparcial)
      Cargar_recorrido_valido("2F", DS_liqparcial)
      Cargar_recorrido_valido("2G", DS_liqparcial)
      Cargar_recorrido_valido("2H", DS_liqparcial)
      Cargar_recorrido_valido("2I", DS_liqparcial)
      Cargar_recorrido_valido("2J", DS_liqparcial)

    Else
      If ChkBox_2A.Checked = True Then
        Cargar_recorrido_valido("2A", DS_liqparcial)
      End If
      If ChkBox_2B.Checked = True Then
        Cargar_recorrido_valido("2B", DS_liqparcial)
      End If
      If ChkBox_2C.Checked = True Then
        Cargar_recorrido_valido("2C", DS_liqparcial)
      End If
      If ChkBox_2D.Checked = True Then
        Cargar_recorrido_valido("2D", DS_liqparcial)
      End If
      If ChkBox_2E.Checked = True Then
        Cargar_recorrido_valido("2E", DS_liqparcial)
      End If
      If ChkBox_2F.Checked = True Then
        Cargar_recorrido_valido("2F", DS_liqparcial)
      End If
      If ChkBox_2G.Checked = True Then
        Cargar_recorrido_valido("2G", DS_liqparcial)
      End If
      If ChkBox_2H.Checked = True Then
        Cargar_recorrido_valido("2H", DS_liqparcial)
      End If
      If ChkBox_2I.Checked = True Then
        Cargar_recorrido_valido("2I", DS_liqparcial)
      End If
      If ChkBox_2J.Checked = True Then
        Cargar_recorrido_valido("2J", DS_liqparcial)
      End If

    End If
  End Sub
  Private Sub Recorrido_3(ByRef DS_liqparcial As DataSet)
    If ChkBox_3TODAS.Checked = True Then
      Cargar_recorrido_valido("3A", DS_liqparcial)
      Cargar_recorrido_valido("3B", DS_liqparcial)
      Cargar_recorrido_valido("3C", DS_liqparcial)
      Cargar_recorrido_valido("3D", DS_liqparcial)
      Cargar_recorrido_valido("3E", DS_liqparcial)
      Cargar_recorrido_valido("3F", DS_liqparcial)
      Cargar_recorrido_valido("3G", DS_liqparcial)
      Cargar_recorrido_valido("3H", DS_liqparcial)
      Cargar_recorrido_valido("3I", DS_liqparcial)
      Cargar_recorrido_valido("3J", DS_liqparcial)

    Else
      If ChkBox_3A.Checked = True Then
        Cargar_recorrido_valido("3A", DS_liqparcial)
      End If
      If ChkBox_3B.Checked = True Then
        Cargar_recorrido_valido("3B", DS_liqparcial)
      End If
      If ChkBox_3C.Checked = True Then
        Cargar_recorrido_valido("3C", DS_liqparcial)
      End If
      If ChkBox_3D.Checked = True Then
        Cargar_recorrido_valido("3D", DS_liqparcial)
      End If
      If ChkBox_3E.Checked = True Then
        Cargar_recorrido_valido("3E", DS_liqparcial)
      End If
      If ChkBox_3F.Checked = True Then
        Cargar_recorrido_valido("3F", DS_liqparcial)
      End If
      If ChkBox_3G.Checked = True Then
        Cargar_recorrido_valido("3G", DS_liqparcial)
      End If
      If ChkBox_3H.Checked = True Then
        Cargar_recorrido_valido("3H", DS_liqparcial)
      End If
      If ChkBox_3I.Checked = True Then
        Cargar_recorrido_valido("3I", DS_liqparcial)
      End If
      If ChkBox_3J.Checked = True Then
        Cargar_recorrido_valido("3J", DS_liqparcial)
      End If

    End If
  End Sub
  Private Sub Recorrido_4(ByRef DS_liqparcial As DataSet)
    If ChkBox_4TODAS.Checked = True Then
      Cargar_recorrido_valido("4A", DS_liqparcial)
      Cargar_recorrido_valido("4B", DS_liqparcial)
      Cargar_recorrido_valido("4C", DS_liqparcial)
      Cargar_recorrido_valido("4D", DS_liqparcial)
      Cargar_recorrido_valido("4E", DS_liqparcial)
      Cargar_recorrido_valido("4F", DS_liqparcial)
      Cargar_recorrido_valido("4G", DS_liqparcial)
      Cargar_recorrido_valido("4H", DS_liqparcial)
      Cargar_recorrido_valido("4I", DS_liqparcial)
      Cargar_recorrido_valido("4J", DS_liqparcial)

    Else
      If ChkBox_4A.Checked = True Then
        Cargar_recorrido_valido("4A", DS_liqparcial)
      End If
      If ChkBox_4B.Checked = True Then
        Cargar_recorrido_valido("4B", DS_liqparcial)
      End If
      If ChkBox_4C.Checked = True Then
        Cargar_recorrido_valido("4C", DS_liqparcial)
      End If
      If ChkBox_4D.Checked = True Then
        Cargar_recorrido_valido("4D", DS_liqparcial)
      End If
      If ChkBox_4E.Checked = True Then
        Cargar_recorrido_valido("4E", DS_liqparcial)
      End If
      If ChkBox_4F.Checked = True Then
        Cargar_recorrido_valido("4F", DS_liqparcial)
      End If
      If ChkBox_4G.Checked = True Then
        Cargar_recorrido_valido("4G", DS_liqparcial)
      End If
      If ChkBox_4H.Checked = True Then
        Cargar_recorrido_valido("4H", DS_liqparcial)
      End If
      If ChkBox_4I.Checked = True Then
        Cargar_recorrido_valido("4I", DS_liqparcial)
      End If
      If ChkBox_4J.Checked = True Then
        Cargar_recorrido_valido("4J", DS_liqparcial)
      End If

    End If
  End Sub
#End Region

End Class
