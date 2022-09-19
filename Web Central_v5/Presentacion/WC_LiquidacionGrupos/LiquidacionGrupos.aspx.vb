Public Class LiquidacionGrupos
  Inherits System.Web.UI.Page
  Dim DAgrupos As New Capa_Datos.WC_grupos
  Dim DAliquidacion As New Capa_Datos.WC_Liquidacion

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      Txt_fecha_desde.Focus()
    End If
  End Sub

  Private Sub Txt_fecha_desde_Init(sender As Object, e As EventArgs) Handles Txt_fecha_desde.Init
    Txt_fecha_desde.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_fecha_hasta_Init(sender As Object, e As EventArgs) Handles Txt_fecha_hasta.Init
    Txt_fecha_hasta.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_grupo_codigo_Init(sender As Object, e As EventArgs) Handles Txt_grupo_codigo.Init
    Txt_grupo_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_modificar_ServerClick(sender As Object, e As EventArgs) Handles btn_modificar.ServerClick
    Dim DS_liqgrupos As New DS_liqgrupos

    'valido el ingreso del rango de fechas
    Dim valido = "si"

    Dim fecha_desde As Date = Today
    Try
      fecha_desde = CDate(Txt_fecha_desde.Text)
    Catch ex As Exception
      valido = "no"
    End Try
    Dim fecha_hasta As Date = Today
    Try
      fecha_hasta = CDate(Txt_fecha_hasta.Text)
    Catch ex As Exception
      valido = "no"
    End Try

    If Txt_grupo_codigo.Text = "" Then
      valido = "no"
    End If

    If valido = "si" Then

      If (fecha_hasta > fecha_desde) Or (fecha_desde = fecha_hasta) Then

        If Txt_grupo_codigo.Text = "999" Then
          'se realiza una consulta para todos los grupos
          Dim ds_grupo As DataSet = DAgrupos.Grupos_obtenertodos
          If ds_grupo.Tables(0).Rows.Count <> 0 Then
            Dim ii As Integer = 0
            While ii < ds_grupo.Tables(0).Rows.Count
              Dim Grupo_Id As Integer = ds_grupo.Tables(0).Rows(ii).Item("Grupo_id")
              Dim Grupo_Codigo As String = ds_grupo.Tables(0).Rows(ii).Item("Codigo")
              Dim Grupo_Nombre As String = ds_grupo.Tables(0).Rows(ii).Item("Nombre")
              Dim Grupo_Tipo As String = ds_grupo.Tables(0).Rows(ii).Item("Tipo")
              If Grupo_Tipo = "3" Or Grupo_Tipo = "4" Then
                Dim fila As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila("Columna1") = ""
                fila("Columna2") = "RESULTADO DEL PERIODO " + CDate(Txt_fecha_desde.Text).ToString("dd-MM-yyyy") + " AL " + CDate(Txt_fecha_hasta.Text).ToString("dd-MM-yyyy")
                'fila("Columna3") = "
                fila("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila)

                Dim fila2 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila2("Columna1") = ""
                fila2("Columna2") = "GRUPO:" + Grupo_Codigo + " " + Grupo_Nombre.ToString.ToUpper
                'fila2("Columna3") = ""
                fila2("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila2)


                Dim Grupo_fecha As Date = CDate(ds_grupo.Tables(0).Rows(ii).Item("Fecha"))
                Dim Grupo_SaldoAnterior As Decimal = CDec(ds_grupo.Tables(0).Rows(ii).Item("Saldoanterior"))
                Dim Grupo_CodigoCobro As String = ds_grupo.Tables(0).Rows(ii).Item("Codigocobro")
                Dim Grupo_Porcentaje As Decimal = ds_grupo.Tables(0).Rows(ii).Item("Porcentaje")
                Dim ds_ctacteGrupo As DataSet = DAliquidacion.LiquidacionGrupos_ObtenerCtaCtexrangofecha(fecha_desde, fecha_hasta, Grupo_Id)

                Dim fila3 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila3("Columna1") = ""
                fila3("Columna2") = "SALDO ANTERIOR AL " + Grupo_fecha
                fila3("Columna3") = Grupo_SaldoAnterior
                fila3("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila3)

                Dim CtaCte_DejoGano As Decimal = 0
                Dim CtaCte_DejoGanoSC As Decimal = 0
                Dim CtaCte_DejoGanoB As Decimal = 0

                Dim TrabajoPeriodo As Decimal = 0

                If ds_ctacteGrupo.Tables(0).Rows.Count <> 0 Then
                  '-------CALCULO DE "TRABAJO EN PERIODO"
                  Dim i As Integer = 0

                  While i < ds_ctacteGrupo.Tables(0).Rows.Count
                    CtaCte_DejoGano = CtaCte_DejoGano + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGano"))
                    CtaCte_DejoGanoSC = CtaCte_DejoGanoSC + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGanoSC"))
                    CtaCte_DejoGanoB = CtaCte_DejoGanoB + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGanoB"))
                    i = i + 1
                  End While

                  Select Case Grupo_CodigoCobro
                    Case "1"
                      'Si dbo.Grupos.CodigoCobro = 1,
                      'EL TRABAJO EN EL PERIODO = dbo.CtaCte.DejoGano + dbo.CtaCte.DejoGanoSC + dbo.CtaCte.DejoGanoB
                      'entre las fechas seleccionadas para la liquidacion.
                      '(Si el resultado del calculo es positivo se colocara la siguiente referencia ++DEJO,
                      'si el resultado del calculo es negativo se colocara la siguiente referencia --GANO)
                      TrabajoPeriodo = CtaCte_DejoGano + CtaCte_DejoGanoSC + CtaCte_DejoGanoSC
                    Case "2"
                      TrabajoPeriodo = CtaCte_DejoGano + CtaCte_DejoGanoSC
                    Case "3"
                      TrabajoPeriodo = CtaCte_DejoGanoB
                    Case "4"
                      TrabajoPeriodo = CtaCte_DejoGano
                  End Select
                Else
                  'msj, no hay resultados para el rango de fecha
                End If

                Dim fila4 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                If TrabajoPeriodo > 0 Then
                  fila4("Columna1") = "++DEJO"

                End If
                If TrabajoPeriodo < 0 Then
                  fila4("Columna1") = "--GANO"
                End If
                fila4("Columna2") = "EL TRABAJO EN EL PERIODO"
                fila4("Columna3") = TrabajoPeriodo
                fila4("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila4)


                '///////////////////////////////////////////////////////////////////////////////////////////////////////
                'El total de gastos es igual a la suma de los gastos dbo.Gastos.Importe cargados al grupo entre las fechas seleccionadas para la liquidacion.
                Dim DS_Gastos As DataSet = DAliquidacion.LiquidacionGrupos_ObtenerGastosxrangofecha(fecha_desde, fecha_hasta, Grupo_Id)
                Dim Gastos_importe As Decimal = 0
                If DS_Gastos.Tables(0).Rows.Count <> 0 Then
                  Dim j As Integer = 0
                  While j < DS_Gastos.Tables(0).Rows.Count
                    Gastos_importe = Gastos_importe + CDec(DS_Gastos.Tables(0).Rows(j).Item("Importe"))
                    j = j + 1
                  End While
                Else
                  'No se registran gastos para el rango de fecha

                End If
                Dim fila5 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila5("Columna1") = ""
                fila5("Columna2") = "GASTOS"
                fila5("Columna3") = Gastos_importe
                fila5("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila5)

                '///////////////////////////////////////////////////////////////////////////////////////////////////////

                Dim Saldo_periodo As Decimal = Grupo_SaldoAnterior + TrabajoPeriodo + Gastos_importe
                Dim fila6 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila6("Columna1") = ""
                fila6("Columna2") = "SALDO PARA EL PERIODO"
                fila6("Columna3") = Saldo_periodo
                If Saldo_periodo > 0 Then
                  fila6("Columna4") = "++DEJO"
                End If
                If Saldo_periodo < 0 Then
                  fila6("Columna4") = "--GANO"
                End If
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila6)

                'Si el saldo para el periodo es positivo y el grupo es de tipo=3 (% del grupo) se debe
                'calcular que % le corresponde al socio. Esto se obtine de multiplicar el % dbo.Grupos.Porcentaje * el total del "SALDO PARA EL PERIODO"
                Dim porcentaje_socio As Decimal = 0
                If Saldo_periodo > 0 And Grupo_Tipo = "3" Then
                  porcentaje_socio = (Saldo_periodo * Grupo_Porcentaje) / 100
                End If

                Dim fila7 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
                fila7("Columna1") = ""
                fila7("Columna2") = "% CORRESPONDIENTE AL SOCIO"
                If porcentaje_socio <> 0 Then
                  fila7("Columna3") = porcentaje_socio
                Else
                  'fila7("Columna3") = ""
                End If
                fila7("Columna4") = ""
                DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila7)

                DS_liqgrupos.Tables("LiqGrupos").Rows.Add()

                '///////////////////GUARDO EN BD///////////////////////////
                DAliquidacion.LiquidacionGrupos_GruposModiffecha(Grupo_Id, fecha_hasta)
                If Grupo_Tipo = "3" Then
                  If Saldo_periodo > 0 Then
                    DAliquidacion.LiquidacionGrupos_GruposModifimporte(Grupo_Id, CDec(0))
                  Else
                    If Saldo_periodo < 0 Then
                      DAliquidacion.LiquidacionGrupos_GruposModifimporte(Grupo_Id, Saldo_periodo)
                    End If
                  End If
                End If
                '//////////////////////////////////////////////////////////




              Else
                'no se considera grupos del tipo 1 y 2
              End If




              ii = ii + 1
            End While
            Session("Tabla_LiqGrupos") = DS_liqgrupos.Tables("LiqGrupos")

            Response.Redirect("~/WC_LiquidacionGrupos/LiquidacionGrupos_det.aspx")
          Else
            'error, no hay grupos


          End If



        Else
          'se realiza una consulta con un codigo de grupo especifico.

          Dim ds_grupo As DataSet = DAgrupos.Grupos_buscar_codigo(Txt_grupo_codigo.Text)
          If ds_grupo.Tables(0).Rows.Count <> 0 Then
            Dim Grupo_Id As Integer = ds_grupo.Tables(0).Rows(0).Item("Grupo_id")
            Dim Grupo_Codigo As String = ds_grupo.Tables(0).Rows(0).Item("Codigo")
            Dim Grupo_Nombre As String = ds_grupo.Tables(0).Rows(0).Item("Nombre")
            Dim Grupo_Tipo As String = ds_grupo.Tables(0).Rows(0).Item("Tipo")
            If Grupo_Tipo = "3" Or Grupo_Tipo = "4" Then
              Dim fila As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila("Columna1") = ""
              fila("Columna2") = "RESULTADO DEL PERIODO " + CDate(Txt_fecha_desde.Text).ToString("dd-MM-yyyy") + " AL " + CDate(Txt_fecha_hasta.Text).ToString("dd-MM-yyyy")
              'fila("Columna3") = "
              fila("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila)

              Dim fila2 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila2("Columna1") = ""
              fila2("Columna2") = "GRUPO:" + Grupo_Codigo + " " + Grupo_Nombre.ToString.ToUpper
              'fila2("Columna3") = ""
              fila2("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila2)


              Dim Grupo_fecha As Date = CDate(ds_grupo.Tables(0).Rows(0).Item("Fecha"))
              Dim Grupo_SaldoAnterior As Decimal = CDec(ds_grupo.Tables(0).Rows(0).Item("Saldoanterior"))
              Dim Grupo_CodigoCobro As String = ds_grupo.Tables(0).Rows(0).Item("Codigocobro")
              Dim Grupo_Porcentaje As Decimal = ds_grupo.Tables(0).Rows(0).Item("Porcentaje")
              Dim ds_ctacteGrupo As DataSet = DAliquidacion.LiquidacionGrupos_ObtenerCtaCtexrangofecha(fecha_desde, fecha_hasta, Grupo_Id)

              Dim fila3 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila3("Columna1") = ""
              fila3("Columna2") = "SALDO ANTERIOR AL " + Grupo_fecha
              fila3("Columna3") = Grupo_SaldoAnterior
              fila3("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila3)

              Dim CtaCte_DejoGano As Decimal = 0
              Dim CtaCte_DejoGanoSC As Decimal = 0
              Dim CtaCte_DejoGanoB As Decimal = 0

              Dim TrabajoPeriodo As Decimal = 0

              If ds_ctacteGrupo.Tables(0).Rows.Count <> 0 Then
                '-------CALCULO DE "TRABAJO EN PERIODO"
                Dim i As Integer = 0

                While i < ds_ctacteGrupo.Tables(0).Rows.Count
                  CtaCte_DejoGano = CtaCte_DejoGano + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGano"))
                  CtaCte_DejoGanoSC = CtaCte_DejoGanoSC + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGanoSC"))
                  CtaCte_DejoGanoB = CtaCte_DejoGanoB + CDec(ds_ctacteGrupo.Tables(0).Rows(i).Item("DejoGanoB"))
                  i = i + 1
                End While

                Select Case Grupo_CodigoCobro
                  Case "1"
                    'Si dbo.Grupos.CodigoCobro = 1,
                    'EL TRABAJO EN EL PERIODO = dbo.CtaCte.DejoGano + dbo.CtaCte.DejoGanoSC + dbo.CtaCte.DejoGanoB
                    'entre las fechas seleccionadas para la liquidacion.
                    '(Si el resultado del calculo es positivo se colocara la siguiente referencia ++DEJO,
                    'si el resultado del calculo es negativo se colocara la siguiente referencia --GANO)
                    TrabajoPeriodo = CtaCte_DejoGano + CtaCte_DejoGanoSC + CtaCte_DejoGanoSC
                  Case "2"
                    TrabajoPeriodo = CtaCte_DejoGano + CtaCte_DejoGanoSC
                  Case "3"
                    TrabajoPeriodo = CtaCte_DejoGanoB
                  Case "4"
                    TrabajoPeriodo = CtaCte_DejoGano
                End Select
              Else
                'msj, no hay resultados para el rango de fecha
              End If

              Dim fila4 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              If TrabajoPeriodo > 0 Then
                fila4("Columna1") = "++DEJO"

              End If
              If TrabajoPeriodo < 0 Then
                fila4("Columna1") = "--GANO"
              End If
              fila4("Columna2") = "EL TRABAJO EN EL PERIODO"
              fila4("Columna3") = TrabajoPeriodo
              fila4("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila4)


              '///////////////////////////////////////////////////////////////////////////////////////////////////////
              'El total de gastos es igual a la suma de los gastos dbo.Gastos.Importe cargados al grupo entre las fechas seleccionadas para la liquidacion.
              Dim DS_Gastos As DataSet = DAliquidacion.LiquidacionGrupos_ObtenerGastosxrangofecha(fecha_desde, fecha_hasta, Grupo_Id)
              Dim Gastos_importe As Decimal = 0
              If DS_Gastos.Tables(0).Rows.Count <> 0 Then
                Dim j As Integer = 0
                While j < DS_Gastos.Tables(0).Rows.Count
                  Gastos_importe = Gastos_importe + CDec(DS_Gastos.Tables(0).Rows(j).Item("Importe"))
                  j = j + 1
                End While
              Else
                'No se registran gastos para el rango de fecha

              End If
              Dim fila5 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila5("Columna1") = ""
              fila5("Columna2") = "GASTOS"
              fila5("Columna3") = Gastos_importe
              fila5("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila5)

              '///////////////////////////////////////////////////////////////////////////////////////////////////////

              Dim Saldo_periodo As Decimal = Grupo_SaldoAnterior + TrabajoPeriodo + Gastos_importe
              Dim fila6 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila6("Columna1") = ""
              fila6("Columna2") = "SALDO PARA EL PERIODO"
              fila6("Columna3") = Saldo_periodo
              If Saldo_periodo > 0 Then
                fila6("Columna4") = "++DEJO"
              End If
              If Saldo_periodo < 0 Then
                fila6("Columna4") = "--GANO"
              End If
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila6)

              'Si el saldo para el periodo es positivo y el grupo es de tipo=3 (% del grupo) se debe
              'calcular que % le corresponde al socio. Esto se obtine de multiplicar el % dbo.Grupos.Porcentaje * el total del "SALDO PARA EL PERIODO"
              Dim porcentaje_socio As Decimal = 0
              If Saldo_periodo > 0 And Grupo_Tipo = "3" Then
                porcentaje_socio = (Saldo_periodo * Grupo_Porcentaje) / 100
              End If

              Dim fila7 As DataRow = DS_liqgrupos.Tables("LiqGrupos").NewRow
              fila7("Columna1") = ""
              fila7("Columna2") = "% CORRESPONDIENTE AL SOCIO"
              If porcentaje_socio <> 0 Then
                fila7("Columna3") = porcentaje_socio
              Else
                'fila7("Columna3") = ""
              End If
              fila7("Columna4") = ""
              DS_liqgrupos.Tables("LiqGrupos").Rows.Add(fila7)

              '///////////////////GUARDO EN BD///////////////////////////
              DAliquidacion.LiquidacionGrupos_GruposModiffecha(Grupo_Id, fecha_hasta)
              If Grupo_Tipo = "3" Then
                If Saldo_periodo > 0 Then
                  DAliquidacion.LiquidacionGrupos_GruposModifimporte(Grupo_Id, CDec(0))
                Else
                  If Saldo_periodo < 0 Then
                    DAliquidacion.LiquidacionGrupos_GruposModifimporte(Grupo_Id, Saldo_periodo)
                  End If
                End If
              End If
              '//////////////////////////////////////////////////////////

              Session("Tabla_LiqGrupos") = DS_liqgrupos.Tables("LiqGrupos")

                Response.Redirect("~/WC_LiquidacionGrupos/LiquidacionGrupos_det.aspx")


              Else
                'no se considera grupos del tipo 1 y 2
              End If

          Else
            'error, el código no existe
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error3", "$(document).ready(function () {$('#modal-sm_error3').modal();});", True)
          End If


        End If

      Else
        'error, aqui msj que ingrese rango de fechas validas. 
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error2", "$(document).ready(function () {$('#modal-sm_error2').modal();});", True)
      End If
    Else
      'error, ingrese la informacion solicitada
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error1", "$(document).ready(function () {$('#modal-sm_error1').modal();});", True)
    End If


  End Sub

  Private Sub btn_ok_error1_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error1.ServerClick
    Txt_fecha_desde.Focus()
  End Sub

  Private Sub btn_close_error1_ServerClick(sender As Object, e As EventArgs) Handles btn_close_error1.ServerClick
    Txt_fecha_desde.Focus()
  End Sub

  Private Sub Btn_close_error2_ServerClick(sender As Object, e As EventArgs) Handles Btn_close_error2.ServerClick
    Txt_fecha_desde.Focus()
  End Sub

  Private Sub Btn_ok_error2_ServerClick(sender As Object, e As EventArgs) Handles Btn_ok_error2.ServerClick
    Txt_fecha_desde.Focus()
  End Sub

  Private Sub Btn_close_error3_ServerClick(sender As Object, e As EventArgs) Handles Btn_close_error3.ServerClick
    Txt_grupo_codigo.Focus()
  End Sub

  Private Sub Btn_ok_error3_ServerClick(sender As Object, e As EventArgs) Handles Btn_ok_error3.ServerClick
    Txt_grupo_codigo.Focus()
  End Sub
End Class
