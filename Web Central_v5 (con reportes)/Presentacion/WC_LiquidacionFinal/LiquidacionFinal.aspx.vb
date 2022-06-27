Public Class LiquidacionFinal
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DArecorrido As New Capa_Datos.WC_recorridos_zonas
  Dim DApuntos As New Capa_Datos.WC_puntos
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion
  Dim DACliente As New Capa_Datos.WB_clientes
  Dim DAPremios As New Capa_Datos.WC_premios
  Dim DAAnticipados As New Capa_Datos.WC_anticipados
  Dim DACtaCte As New Capa_Datos.WC_CtaCte
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
        HF_fecha.Value = ds_info.Tables(0).Rows(0).Item("Fecha")
        'Label_fecha.Text = FECHA.ToString("yyyy-MM-dd")
        Label_fecha.Text = FECHA.ToString("dd-MM-yyyy")
        Dim dia As Integer = CInt(ds_info.Tables(0).Rows(0).Item("Dia"))
        HF_dia_id.Value = dia
        Select Case dia
          Case 1
            Label_dia.Text = "DOMINGO."
          Case 2
            Label_dia.Text = "LUNES."
          Case 3
            Label_dia.Text = "MARTES."
          Case 4
            Label_dia.Text = "MIERCOLES."
          Case 5
            Label_dia.Text = "JUEVES."
          Case 6
            Label_dia.Text = "VIERNES."
          Case 7
            Label_dia.Text = "SABADO."
        End Select
        'mostrar_zonas_habilitadas(dia)

      Else
        'AQUI MENSAJE Y QUE CON EL BOTON "OK" U "CLOSE" VUELVA AL MENU PRINCIPAL.
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If

      Txt_OP.Focus()
    End If
  End Sub
  Private Sub Txt_OP_Init(sender As Object, e As EventArgs) Handles Txt_OP.Init
    Txt_OP.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_error_close_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_modificar_ServerClick(sender As Object, e As EventArgs) Handles btn_modificar.ServerClick
    If Txt_OP.Text.ToUpper = "OK" Then
      metodo1()
    Else
      'error
      Txt_OP.Focus()
    End If
  End Sub

  Private Sub Btn_ErrorValidacionOk_ServerClick(sender As Object, e As EventArgs) Handles Btn_ErrorValidacionOk.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub Btn_ErrorValidacionClose_ServerClick(sender As Object, e As EventArgs) Handles Btn_ErrorValidacionClose.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub


#End Region

#Region "METODOS"
  Public Function conv_bit(ByRef estado As Integer)
    If estado = -1 Then
      estado = 1
    Else
      If estado = 0 Then

      End If
    End If
    Return estado
  End Function

  Private Sub Validar_recorridos_a(ByRef valido As String, ByVal Codigo As String, ByRef codigo_error As String, ByRef check As String)
    check = "si"

    'valido que exista al menos 1 punto cargado para el item seleccionado.
    Dim dataset_recorridos As DataSet = DALiquidacion.Liquidacion_validar_recorridos(HF_fecha.Value, Codigo)
    Dim validacion As String = "no"
    If dataset_recorridos.Tables(0).Rows.Count <> 0 Then
      Dim punto_encontrado As String = ""
      Dim i As Integer = 7 'desde p1 a p20...va 7 porque es la posicion de la columna en el dataset
      While i < 27
        If dataset_recorridos.Tables(0).Rows(0).Item(i) <> "" Then
          validacion = "si"
          Exit While
        End If
        i = i + 1
      End While
      If validacion = "si" Then
        valido = "si"
        codigo_error = ""
      Else
        valido = "no"
        codigo_error = "No se encontraron puntos cargados."
      End If
    Else
      valido = "no"
      codigo_error = "No se encontraron puntos cargados."
    End If

  End Sub

  Private Sub metodo1()
    Dim DS_liqparcial As New DS_liqparcial

    '1ra VALIDACION.------------------------------------
    Dim check As String = "no"
    Dim valido As String = "si"
    Dim codigo_error As String = "" 'aqui se va a almacenar el codigo donde la validación falló, para poder mostrarlo posteriormente en un mensaje al usuario.
    Dim valido_xcargas As String = "si"

    'validamos todos los elementos de Recorrido1
    Validacion(DS_liqparcial, valido, valido_xcargas, codigo_error, check)

    If valido = "si" Then
      'en la rutina VALIDACION se cargaron los codigos de las zonas habilitadas aqui: DS_liqparcial.Tables("Recorridos_seleccionados")

      Dim DS_liqfinal As New DS_liqfinal


      Liquidacion(DS_liqparcial, DS_liqfinal)

      'envio los parametros y tablas para generar el informe con los Totales Finales.
      Session("fecha_parametro") = HF_fecha.Value
      Session("tabla_recorridos_seleccionados") = DS_liqparcial.Tables("Recorridos_seleccionados")



      If DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Count <> 0 Then
        Dim SumPagos As Decimal = 0
        Dim SumCobros As Decimal = 0
        Dim SumReclamos As Decimal = 0
        Dim i As Integer = 0
        While i < DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Count
          Dim movimiento As String = DS_liqfinal.Tables("PagosCobrosReclamos").Rows(i).Item("Movimiento").ToString
          If movimiento = "PAGO" Then
            SumPagos = SumPagos + CDec(DS_liqfinal.Tables("PagosCobrosReclamos").Rows(i).Item("Importe"))
          End If
          If movimiento = "COBRO" Then
            SumCobros = SumCobros + CDec(DS_liqfinal.Tables("PagosCobrosReclamos").Rows(i).Item("Importe"))
          End If
          If movimiento = "RECLAMO" Then
            SumReclamos = SumReclamos + CDec(DS_liqfinal.Tables("PagosCobrosReclamos").Rows(i).Item("Importe"))
          End If
          i = i + 1
        End While
        DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add() 'fila en blanco


        SumPagos = (Math.Round(SumPagos, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
        SumCobros = (Math.Round(SumCobros, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
        SumReclamos = (Math.Round(SumReclamos, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
        Dim fila_p As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
        fila_p("Cliente") = ""
        fila_p("Movimiento") = "TOTAL PAGOS:"
        fila_p("Importe") = SumPagos
        DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_p)

        Dim fila_c As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
        fila_c("Cliente") = ""
        fila_c("Movimiento") = "TOTAL COBROS:"
        fila_c("Importe") = SumCobros
        DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_c)

        Dim fila_r As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
        fila_r("Cliente") = ""
        fila_r("Movimiento") = "TOTAL RECLAMOS:"
        fila_r("Importe") = SumReclamos
        DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_r)
      End If


      Session("tabla_PagosCobrosReclamos") = DS_liqfinal.Tables("PagosCobrosReclamos")

      Response.Redirect("~/WC_LiquidacionFinal/LiquidacionFinal_TotalesFinales.aspx")

    Else
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ErrorValidacion", "$(document).ready(function () {$('#modal-ErrorValidacion').modal();});", True)
    End If


  End Sub

  Private Sub Validacion(ByRef DS_liqparcial As DataSet, ByRef valido As String, ByRef valido_xcargas As String, ByRef codigo_error As String, ByRef check As String)
    'recupero los codigos de las zonas habilitadas para el dia vigente.
    Dim DS_Recorridos As DataSet = DArecorrido.recorridos_zonas_obtener_habilitados_x_dia(HF_dia_id.Value)
    'voy a recorrer todas las zonas habilitadas para el dia
    Dim ContZonaHab As Integer = 0 'contar zonas habilitadas
    Dim i As Integer = 0
    While i < DS_Recorridos.Tables(1).Rows.Count
      Dim Habilitada As Integer = conv_bit(CInt(DS_Recorridos.Tables(1).Rows(i).Item("Habilitada")))
      Dim codigo As String = DS_Recorridos.Tables(1).Rows(i).Item("Codigo")
      If Habilitada = 1 Then
        '1 VALIDACACION, contar zonas habilitadas 
        ContZonaHab = ContZonaHab + 1
        If valido = "si" And valido_xcargas = "si" Then
          '2 VALIDACION: que al menos tenga 1 punto para la zona habilitada
          Validar_recorridos_a(valido, codigo, codigo_error, check)

        End If
      End If

      i = i + 1
    End While
    If ContZonaHab <> 0 Then
      If valido = "no" Then
        'mensaje error: alguna de las zonas no tiene puntos asignados.
        Label_ErrorValidacion.Text = "Alguna de las zonas no tiene puntos cargados."
      End If
    Else
      'mensaje...no hay zonas habilitadas
      Label_ErrorValidacion.Text = "No hay zonas habilitadas."
      valido = "no"
    End If

    If valido = "si" Then
      Dim ds_xcargas As DataSet = DALiquidacion.Liquidacion_todoXcargas
      '3 VALIDACION: QUE EXISTA AL MENOS 1 REGISTRO EN XCARGAS
      If ds_xcargas.Tables(0).Rows.Count <> 0 Then
        '4 VALIDACION: CONTROLAR QUE NO EXISTA UN REGISTRO CON FECHA DIFERENTE A LA DEL PARAMETRO
        Dim error_tipo As String = ""
        Dim j As Integer = 0
        While j < ds_xcargas.Tables(0).Rows.Count
          Dim fecha As Date = CDate(ds_xcargas.Tables(0).Rows(j).Item("Fecha"))

          If fecha = HF_fecha.Value Then
            '5 VALIDACION: Controlar que no exista ninguna Zona dentro de las tablas XCargas.. que no este habilitada en la tabla Parametro.
            '----------------------------------------------------------------------------------------------------------
            Dim Recorrido_codigo As String = ds_xcargas.Tables(0).Rows(j).Item("Recorrido_codigo")
            i = 0
            While i < DS_Recorridos.Tables(1).Rows.Count
              Dim Habilitada As Integer = conv_bit(CInt(DS_Recorridos.Tables(1).Rows(i).Item("Habilitada")))
              Dim codigo As String = DS_Recorridos.Tables(1).Rows(i).Item("Codigo")
              If Recorrido_codigo = codigo And Habilitada = 0 Then
                valido = "no"
                error_tipo = "Zona"
                Exit While
              End If

              i = i + 1
            End While
            If valido = "no" Then
              Exit While
            End If
            '----------------------------------------------------------------------------------------------------------
          Else
            valido = "no"
            error_tipo = "fecha"
            Exit While
          End If
          j = j + 1
        End While
        If valido = "si" Then
          'continuo con las validaciones
          Dim ds_banderas As DataSet = DALiquidacion.Liquidacion_obtenerBanderas
          '6 VALIDACION Y ULTIMA: Controlar que el campo "Web" de la tabla Banderas este en False.(Si se encuentra en True, mostrar mensaje y salir del proceso de liquidacion)
          Dim WEB = ds_banderas.Tables(0).Rows(0).Item("Web")
          If WEB = False Then
            'validacion CORRECTA
            valido = "si"
            Cargar_recorrido_habilitados(DS_Recorridos, DS_liqparcial)
          Else
            valido = "no"
            'mensaje error: bandera.web = true
            Label_ErrorValidacion.Text = "No se puede realizar la liquidacion. Consulte bandera.web."
          End If
        Else
          Select Case error_tipo
            Case "fecha"
              'mensaje error: uno de los registros en xcargas tiene fecha diferente.
              Label_ErrorValidacion.Text = "Registro en Xcargas con fecha diferente."
            Case "Zona"
              'mensaje error: se encontro un registro en xcargas con info de una zona no habilitada.
              Label_ErrorValidacion.Text = "Registro con zona no habilitada en Xcargas."
          End Select
        End If

      Else
        'no hay registros en xcargas
        Label_ErrorValidacion.Text = "No hay registros en Xcargas."
        valido = "no"
      End If


    End If

  End Sub

  Private Sub Cargar_recorrido_habilitados(ByRef DS_Recorridos As DataSet, ByRef DS_liqparcial As DataSet)
    Dim i As Integer = 0
    While i < DS_Recorridos.Tables(1).Rows.Count
      Dim Habilitada As Integer = conv_bit(CInt(DS_Recorridos.Tables(1).Rows(i).Item("Habilitada")))
      Dim codigo As String = DS_Recorridos.Tables(1).Rows(i).Item("Codigo")
      If Habilitada = 1 Then
        Dim fila As DataRow = DS_liqparcial.Tables("Recorridos_seleccionados").NewRow
        fila("Codigo") = codigo
        DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Add(fila)
      End If
      i = i + 1
    End While
  End Sub

  Private Sub Liquidacion(ByRef DS_liqparcial As DataSet, ByRef DS_liqfinal As DataSet)
    'obtener_premios_x_clientes(DS_liqparcial)
    '1) recupero todos los registros de Xcargas y los ordenos en un datatable-----------------------------------------
    Dim DS_XCARGAS1 As DataSet = DALiquidacion.Liquidacion_parcial_recuperarXcargas(DS_liqparcial.Tables("Recorridos_seleccionados").Rows(0).Item("Codigo"), HF_fecha.Value)
    Dim i As Integer = 1
    While i < DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Count
      Dim codigo As String = DS_liqparcial.Tables("Recorridos_seleccionados").Rows(i).Item("Codigo")
      Dim DS_XCARGAS2 As DataSet = DALiquidacion.Liquidacion_parcial_recuperarXcargas(codigo, HF_fecha.Value)
      If DS_XCARGAS2.Tables(0).Rows.Count <> 0 Then
        DS_XCARGAS1.Tables(0).Merge(DS_XCARGAS2.Tables(0))
      End If
      i = i + 1
    End While
    'ahora ordeno por Cliente ASC
    Dim rows() As DataRow = DS_XCARGAS1.Tables(0).Select("IDcarga > 0", "Cliente, Recorrido_codigo ASC")
    Dim dtTemp As DataTable = DS_XCARGAS1.Tables(0).Clone() 'copio la estructura de la tabla.
    For Each row As DataRow In rows
      ' Indicamos que el registro ha sido añadido
      row.SetAdded()
      dtTemp.ImportRow(row)
    Next
    'dtTemp tiene todos los registros de XCargas ya ordenas para poder continuar.
    '-------------fin paso 1------------------------------------------------------------------------------------------

    proceso_liquidacion(dtTemp, DS_liqfinal)


    'GridView2.DataSource = dtTemp
    'GridView2.DataBind()
  End Sub

  Private Sub proceso_liquidacion(ByVal dtTemp As DataTable, ByRef DS_liqfinal As DataSet)
    '---------------PRIMERA ETAPA: PREMIOS--------------------------------
    Dim DS_liqparcial1 As New DS_liqparcial
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Clear()

    Dim valor11 = 1234
    Dim undigito As String = valor11.ToString.Substring(3, 1)
    Dim dosdigitos As String = valor11.ToString.Substring(2, 2)
    Dim tresdigitos As String = valor11.ToString.Substring(1, 3)

    Dim i As Integer = 0
    While i < dtTemp.Rows.Count
      Dim XCargas_Suc = dtTemp.Rows(i).Item("Suc")
      Dim XCargas_Suc2 = dtTemp.Rows(i).Item("Suc2") 'lo uso en la 3ra alternativa
      Dim XCargas_R = dtTemp.Rows(i).Item("R") 'true or false

      '--------------------------------------1) PRIMERA ALTERNATIVA-------------------------------------------------------------------------------
      If (XCargas_Suc = 0 Or XCargas_Suc = 1) And XCargas_R = False Then
        Dim XCargas_Pid = dtTemp.Rows(i).Item("Pid")
        Dim XCargas_recorridocodigo = dtTemp.Rows(i).Item("Recorrido_codigo")
        Dim ds_recorridos As DataSet = DALiquidacion.Liquidacion_validar_recorridos(HF_fecha.Value, XCargas_recorridocodigo)
        Dim referencia_recorrido As String = ds_recorridos.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper
        Dim Puntos_P1 = ds_recorridos.Tables(0).Rows(0).Item("P1")

        Select Case Len(XCargas_Pid) 'devuelve cantidad de digitos en pid
          Case 1
            'comparar con 1 digito en puntos_p1

            Select Case Len(Puntos_P1)
              Case 1
                'Puntos_P1 = Puntos_P1
              Case 2
                Puntos_P1 = Puntos_P1.ToString.Substring(1, 1)
              Case 3
                Puntos_P1 = Puntos_P1.ToString.Substring(2, 1)
              Case 4
                Puntos_P1 = Puntos_P1.ToString.Substring(3, 1)
            End Select
            If XCargas_Pid = Puntos_P1 Then

              Dim respuesta = "son iguales"
              grabar_premios_op1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
            Else
              Dim respuesta = "no hay coincidencia"

            End If

          Case 2
            'comparar con 2 digito en puntos_p1
            Select Case Len(Puntos_P1)
              Case 1
                'Puntos_P1 = Puntos_P1
              Case 2
               'Puntos_P1
              Case 3
                Puntos_P1 = Puntos_P1.ToString.Substring(1, 2)
              Case 4
                Puntos_P1 = Puntos_P1.ToString.Substring(2, 2)
            End Select
            If XCargas_Pid = Puntos_P1 Then

              Dim respuesta = "son iguales"
              grabar_premios_op1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
            Else
              Dim respuesta = "no hay coincidencia"

            End If
          Case 3
            'comparar con 3 digito en puntos_p1
            Select Case Len(Puntos_P1)
              Case 1
                'Puntos_P1 = Puntos_P1
              Case 2
               'Puntos_P1
              Case 3
                'Puntos_P1
              Case 4
                Puntos_P1 = Puntos_P1.ToString.Substring(1, 3)
            End Select
            If XCargas_Pid = Puntos_P1 Then

              Dim respuesta = "son iguales"
              grabar_premios_op1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
            Else
              Dim respuesta = "no hay coincidencia"

            End If
          Case 4
            'comparar con 4 digito en puntos_p1
            If XCargas_Pid = Puntos_P1 Then

              Dim respuesta = "son iguales"
              grabar_premios_op1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
            Else
              Dim respuesta = "no hay coincidencia"

            End If
        End Select
        '--------------------------------------1) FIN-------------------------------------------------------------------------------------------------

      Else
        If XCargas_Suc > 1 And XCargas_R = False Then
          '--------------------------------------2) SEGUNDA ALTERNATIVA-------------------------------------------------------------------------------
          Dim XCargas_Pid = dtTemp.Rows(i).Item("Pid")
          Dim XCargas_recorridocodigo = dtTemp.Rows(i).Item("Recorrido_codigo")
          Dim ds_recorridos As DataSet = DALiquidacion.Liquidacion_validar_recorridos(HF_fecha.Value, XCargas_recorridocodigo)
          Dim referencia_recorrido As String = ds_recorridos.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper

          Dim IndicePuntos As Integer = 7 '7 ES LA POSICION DE P1 EN LA CONSULTA.

          '16 ES P10

          Dim PtoLimite = CInt(XCargas_Suc) + 6 + 1 'mas 6 x que p1 empieza en la celda 7 Y mas uno porque para el limite uso un while con la condicion "menor"

          Dim ContCoincidencia As Integer = 0 'cuento la cantidad de veces donde "XCargas_Pid = PtoSelec"

          Dim i1 As Integer = 0
          While IndicePuntos < PtoLimite
            Dim PtoSelec = ds_recorridos.Tables(0).Rows(0).Item(IndicePuntos)
            Select Case Len(XCargas_Pid) 'devuelve cantidad de digitos en pid
              Case 1
                'comparar con 1 digito en puntos_p1

                Select Case Len(PtoSelec)
                  Case 1
                'Puntos_P1 = Puntos_P1
                  Case 2
                    PtoSelec = PtoSelec.ToString.Substring(1, 1)
                  Case 3
                    PtoSelec = PtoSelec.ToString.Substring(2, 1)
                  Case 4
                    PtoSelec = PtoSelec.ToString.Substring(3, 1)
                End Select
                If XCargas_Pid = PtoSelec Then

                  Dim respuesta = "son iguales"
                  ContCoincidencia = ContCoincidencia + 1
                Else
                  Dim respuesta = "no hay coincidencia"
                End If
              Case 2
                'comparar con 2 digito en puntos_p1
                Select Case Len(PtoSelec)
                  Case 1
                'Puntos_P1 = Puntos_P1
                  Case 2
               'Puntos_P1
                  Case 3
                    PtoSelec = PtoSelec.ToString.Substring(1, 2)
                  Case 4
                    PtoSelec = PtoSelec.ToString.Substring(2, 2)
                End Select
                If XCargas_Pid = PtoSelec Then
                  Dim respuesta = "son iguales"
                  ContCoincidencia = ContCoincidencia + 1
                Else
                  Dim respuesta = "no hay coincidencia"
                End If
              Case 3
                'comparar con 3 digito en puntos_p1
                Select Case Len(PtoSelec)
                  Case 1
                'Puntos_P1 = Puntos_P1
                  Case 2
               'Puntos_P1
                  Case 3
                'Puntos_P1
                  Case 4
                    PtoSelec = PtoSelec.ToString.Substring(1, 3)
                End Select
                If XCargas_Pid = PtoSelec Then
                  Dim respuesta = "son iguales"
                  ContCoincidencia = ContCoincidencia + 1
                Else
                  Dim respuesta = "no hay coincidencia"
                End If
              Case 4
                'comparar con 4 digito en puntos_p1
                If XCargas_Pid = PtoSelec Then
                  Dim respuesta = "son iguales"
                  ContCoincidencia = ContCoincidencia + 1
                Else
                  Dim respuesta = "no hay coincidencia"
                End If
            End Select
            IndicePuntos = IndicePuntos + 1
            i1 = i1 + 1
          End While

          If ContCoincidencia <> 0 Then
            grabar_premios_op2(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido, ContCoincidencia)
          End If

        Else
          If (XCargas_Suc = 0 Or XCargas_Suc = 1) And XCargas_R = True Then
            '--------------------------------------3) TERCERA ALTERNATIVA-------------------------------------------------------------------------------
            Dim XCargas_Pid = dtTemp.Rows(i).Item("Pid")
            Dim XCargas_Pid2 = dtTemp.Rows(i).Item("Pid2")
            Dim XCargas_recorridocodigo = dtTemp.Rows(i).Item("Recorrido_codigo")
            Dim ds_recorridos As DataSet = DALiquidacion.Liquidacion_validar_recorridos(HF_fecha.Value, XCargas_recorridocodigo)
            Dim referencia_recorrido As String = ds_recorridos.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper
            Dim Puntos_P1 = ds_recorridos.Tables(0).Rows(0).Item("P1")
            Dim Coincidencia1 As String = "" 'pid = p1
            Dim Coincidencia2 As String = "" 'pid2 = dbo.Puntos.P(con algunos de los campos hasta el valor de dbo.XCargasL.Suc2 + 1, excluyendo la coincidencia con el campo dbo.Puntos.P1)
            '1) primera validacion: pid=p1
            Select Case Len(XCargas_Pid) 'devuelve cantidad de digitos en pid
              Case 2 'tener en cuenta que Pid va ha tener 2 digitos. Hay que comparar con la unidad y decena de dbo.Puntos.P1
                'comparar con 2 digito en puntos_p1
                Select Case Len(Puntos_P1)
                  Case 1
                'Puntos_P1 = Puntos_P1
                  Case 2
               'Puntos_P1
                  Case 3
                    Puntos_P1 = Puntos_P1.ToString.Substring(1, 2)
                  Case 4
                    Puntos_P1 = Puntos_P1.ToString.Substring(2, 2)
                End Select
                If XCargas_Pid = Puntos_P1 Then
                  Dim respuesta = "son iguales"
                  Coincidencia1 = "si"
                Else
                  Dim respuesta = "no hay coincidencia"
                End If
            End Select
            '2) segunda validacion: pid2 = 
            Dim IndicePuntos As Integer = 8 '8 ES LA POSICION DE P2 EN LA CONSULTA.
            Dim PtoLimite As Integer = 0
            If XCargas_Suc2 < 20 Then
              PtoLimite = XCargas_Suc2 + 1 'dbo.XCargasL.Suc2 + 1. NOTA: lo hago solo si es menor a 20...sino hay desbordamiento.."CONSULTAR ESTO"
            End If
            PtoLimite = PtoLimite + 6 + 1 'mas 6 x que p2 empieza en la celda 8 Y mas uno porque para el limite uso un while con la condicion "menor"
            Dim ContCoincidencia As Integer = 0 'cuento la cantidad de veces donde "XCargas_Pid2 = PtoSelec"
            While IndicePuntos < PtoLimite
              Dim PtoSelec = ds_recorridos.Tables(0).Rows(0).Item(IndicePuntos)
              Select Case Len(XCargas_Pid2) 'devuelve cantidad de digitos en pid2
                Case 2 'tener en cuenta que Pid2 va ha tener 2 digitos.
                  'comparar con 2 digito en puntos_p
                  Select Case Len(PtoSelec)
                    Case 1
                'Puntos_P1 = Puntos_P1
                    Case 2
               'Puntos_P1
                    Case 3
                      PtoSelec = PtoSelec.ToString.Substring(1, 2)
                    Case 4
                      PtoSelec = PtoSelec.ToString.Substring(2, 2)
                  End Select
                  If XCargas_Pid2 = PtoSelec Then
                    Dim respuesta = "son iguales"
                    Coincidencia2 = "si"
                    ContCoincidencia = ContCoincidencia + 1
                  Else
                    Dim respuesta = "no hay coincidencia"
                  End If

              End Select
              IndicePuntos = IndicePuntos + 1
            End While
            If Coincidencia1 = "si" And Coincidencia2 = "si" Then
              grabar_premios_op3(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido, ContCoincidencia)

            End If
            '--------------------------------------3) TERCERA ALTERNATIVA (FIN)-------------------------------------------------------------------------------------------------
          Else
            If XCargas_Suc > 1 And XCargas_R = True Then
              '--------------------------------------4) CUARTA ALTERNATIVA-------------------------------------------------------------------------------
              Dim XCargas_Pid = dtTemp.Rows(i).Item("Pid")
              Dim XCargas_Pid2 = dtTemp.Rows(i).Item("Pid2")
              Dim XCargas_recorridocodigo = dtTemp.Rows(i).Item("Recorrido_codigo")
              Dim ds_recorridos As DataSet = DALiquidacion.Liquidacion_validar_recorridos(HF_fecha.Value, XCargas_recorridocodigo)
              Dim referencia_recorrido As String = ds_recorridos.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper
              Dim IndicePuntos As Integer = 7 '7 ES LA POSICION DE P1 EN LA CONSULTA.
              Dim PtoLimite As Integer = 0
              PtoLimite = XCargas_Suc + 6 + 1 'mas 6 x que p1 empieza en la celda 7 Y mas uno porque para el limite uso un while con la condicion "menor"
              '1)primera validacion: buscar hasta dbo.Puntos.P(el valor de dbo.XCargasL.Suc) que dbo.XCargasL.Pid = dbo.Puntos.P(con algunos de los campos hasta el valor de dbo.XCargasL.Suc) 
              '(tener en cuenta que Pid va ha tener 2 digitos. Hay que comparar con la unidad y decena de dbo.Puntos.P(con algunos de los campos hasta el valor de dbo.XCargasL.Suc))
              Dim ContCoincidencia1 As Integer = 0 'cuento la cantidad de veces donde "XCargas_Pid = PtoSelec"
              While IndicePuntos < PtoLimite
                Dim PtoSelec = ds_recorridos.Tables(0).Rows(0).Item(IndicePuntos)
                Select Case Len(XCargas_Pid) 'devuelve cantidad de digitos en pid
                  Case 2 'tener en cuenta que Pid va ha tener 2 digitos.
                    'comparar con 2 digito en puntos_p
                    Select Case Len(PtoSelec)
                      Case 1
                      'Puntos_P1 = Puntos_P1
                      Case 2
                      'Puntos_P1
                      Case 3
                        PtoSelec = PtoSelec.ToString.Substring(1, 2)
                      Case 4
                        PtoSelec = PtoSelec.ToString.Substring(2, 2)
                    End Select
                    If XCargas_Pid = PtoSelec Then
                      Dim respuesta = "son iguales"
                      ContCoincidencia1 = ContCoincidencia1 + 1
                    Else
                      Dim respuesta = "no hay coincidencia"
                    End If

                End Select
                IndicePuntos = IndicePuntos + 1
              End While
              '2)buscar hasta dbo.Puntos.P(el valor de dbo.XCargasL.Suc2) que dbo.XCargasL.Pid2 = dbo.Puntos.P(con algunos de los campos hasta el valor de dbo.XCargasL.Suc2)
              '(tener en cuenta que Pid2 va ha tener 2 digitos. Hay que comparar con la unidad y decena de dbo.PuntosP(con algunos de los campos hasta el valor de dbo.XcargasL.Suc2))
              IndicePuntos = 7 'reinicio a la posicion de p1
              PtoLimite = XCargas_Suc2 + 6 + 1 'cambio el PtoLimite hasta el "P" que me indice el campo Suc2
              Dim ContCoincidencia2 As Integer = 0 'cuento la cantidad de veces donde "XCargas_Pid2 = PtoSelec"
              While IndicePuntos < PtoLimite
                Dim PtoSelec = ds_recorridos.Tables(0).Rows(0).Item(IndicePuntos)
                Select Case Len(XCargas_Pid2) 'devuelve cantidad de digitos en pid2
                  Case 2 'tener en cuenta que Pid2 va ha tener 2 digitos.
                    'comparar con 2 digito en puntos_p
                    Select Case Len(PtoSelec)
                      Case 1
                '     Puntos_P1 = Puntos_P1
                      Case 2
                      'Puntos_P1
                      Case 3
                        PtoSelec = PtoSelec.ToString.Substring(1, 2)
                      Case 4
                        PtoSelec = PtoSelec.ToString.Substring(2, 2)
                    End Select
                    If XCargas_Pid2 = PtoSelec Then
                      Dim respuesta = "son iguales"
                      ContCoincidencia2 = ContCoincidencia2 + 1
                    Else
                      Dim respuesta = "no hay coincidencia"
                    End If
                End Select
                IndicePuntos = IndicePuntos + 1
              End While

              '3) verifico si se dan ambas coincidencias
              If ContCoincidencia1 <> 0 And ContCoincidencia2 <> 0 Then
                grabar_premios_op4(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido, ContCoincidencia1, ContCoincidencia2)
              End If
              '--------------------------------------4) CUARTA ALTERNATIVA (FIN)-------------------------------------------------------------------------------------------------

            End If
          End If
        End If
      End If
      i = i + 1
    End While

    'AQUI AGREGO LOS CORTES DE CONTROL ---------------------------------------------------------------------
    '----------COPIO LA ESTRUCTURA EN OTRO DATATABLE
    Dim dtTemp_con_cortes_control As DataTable = DS_liqparcial1.Tables("PremiosxClientes").Clone()

    i = 0
    Dim total_general As Decimal = 0
    While i < DS_liqparcial1.Tables("PremiosxClientes").Rows.Count
      total_general = total_general + CDec(DS_liqparcial1.Tables("PremiosxClientes").Rows(i).Item("Premio"))
      Dim Cliente = DS_liqparcial1.Tables("PremiosxClientes").Rows(i).Item("Cliente")

      If dtTemp_con_cortes_control.Rows.Count = 0 Then
        'agrego registro
        dtTemp_con_cortes_control.ImportRow(DS_liqparcial1.Tables("PremiosxClientes").Rows(i))

      Else
        Dim validar = ""
        Dim ultimo_registro As Integer = dtTemp_con_cortes_control.Rows.Count - 1
        If dtTemp_con_cortes_control.Rows(ultimo_registro).Item("Cliente") = Cliente Then
          'agrego
          dtTemp_con_cortes_control.ImportRow(DS_liqparcial1.Tables("PremiosxClientes").Rows(i))
        Else
          'si son diferentes primero hago el recuento de los premios para ese cliente y luego agrego un registro a modo de resumen.
          Dim j As Integer = 0
          Dim suma_premio As Decimal = 0
          Cliente = DS_liqparcial1.Tables("PremiosxClientes").Rows(ultimo_registro).Item("Cliente")
          While j < dtTemp_con_cortes_control.Rows.Count
            If Cliente = dtTemp_con_cortes_control.Rows(j).Item("Cliente") Then
              suma_premio = suma_premio + CDec(dtTemp_con_cortes_control.Rows(j).Item("Premio"))
            End If
            j = j + 1
          End While
          Dim fila As DataRow = dtTemp_con_cortes_control.NewRow
          fila("Cliente") = "TOTAL"
          fila("Premio") = (Math.Round(suma_premio, 2).ToString("N2"))
          dtTemp_con_cortes_control.Rows.Add(fila)
          'ahora agrego el registro diferente, o sea nuevo cliente
          dtTemp_con_cortes_control.ImportRow(DS_liqparcial1.Tables("PremiosxClientes").Rows(i))
        End If
      End If


      i = i + 1
    End While

    If dtTemp_con_cortes_control.Rows.Count <> 0 Then
      'calculo total para ultimo cliente ingreso
      Dim j As Integer = 0
      Dim suma_premio As Decimal = 0
      Dim ultimo_registro As Integer = dtTemp_con_cortes_control.Rows.Count - 1
      Dim Cliente = dtTemp_con_cortes_control.Rows(ultimo_registro).Item("Cliente")
      If Cliente <> "TOTAL" Then
        While j < dtTemp_con_cortes_control.Rows.Count
          If Cliente = dtTemp_con_cortes_control.Rows(j).Item("Cliente") Then
            suma_premio = suma_premio + CDec(dtTemp_con_cortes_control.Rows(j).Item("Premio"))
          End If
          j = j + 1
        End While
        Dim filaa As DataRow = dtTemp_con_cortes_control.NewRow
        filaa("Cliente") = "TOTAL"
        filaa("Premio") = (Math.Round(suma_premio, 2).ToString("N2"))
        dtTemp_con_cortes_control.Rows.Add(filaa)
      End If
      'agrego fila con TOTAL GENERAL
      Dim fila_a As DataRow = dtTemp_con_cortes_control.NewRow
      fila_a("Cliente") = "TOTAL GENERAL"
      fila_a("Premio") = (Math.Round(total_general, 2).ToString("N2"))
      dtTemp_con_cortes_control.Rows.Add(fila_a)

    End If

    'MUESTRO EN EL GRIDVIEW---------------------------------------------------------------------------------
    'GridView1.DataSource = dtTemp_con_cortes_control
    'GridView1.DataBind()


    '-------------------------------------------------------------------------------------------------------

    '------------SEGUNDA ETAPA: CALCULO Y GRABACION EN LA TABLA CTACTE------------------------------------------------
    'NOTA: ds_xcargas recupera todos los registros de la fecha del parametro, ordenados por cliente ASC
    Dim ds_xcargas As DataSet = DALiquidacion.Liquidacion_final_recuperarXcargas(HF_fecha.Value)
    If ds_xcargas.Tables(0).Rows.Count <> 0 Then
      Dim Fecha As Date = HF_fecha.Value
      i = 0
      Dim cliente_agregado = ""
      While i < ds_xcargas.Tables(0).Rows.Count
        Dim Grupo_id As Integer = ds_xcargas.Tables(0).Rows(i).Item("Grupo_id")
        Dim Codigo_cliente As String = ds_xcargas.Tables(0).Rows(i).Item("Cliente")
        Dim SaldoAnterior As Decimal = ds_xcargas.Tables(0).Rows(i).Item("Cliente_Saldo")

        Dim recaudacion As Decimal = 0
        Dim recaudacionSC As Decimal = 0
        If cliente_agregado <> Codigo_cliente Then
          Dim j As Integer = 0
          While j < ds_xcargas.Tables(0).Rows.Count
            'operacion: Recaudacion = a la suma de todos los importes de la tabla dbo.XCargasL.TotalImporte donde dbo.XCargasL.Sincomputo = False 
            If (Codigo_cliente = ds_xcargas.Tables(0).Rows(j).Item("Cliente")) And (ds_xcargas.Tables(0).Rows(j).Item("SinComputo") = False) Then
              recaudacion = recaudacion + ds_xcargas.Tables(0).Rows(j).Item("TotalImporte")
            End If
            'operacion: RecaudacionSC = a la suma de todos los importes de la tabla dbo.XCargasL.TotalImporte donde dbo.XCargasL.Sincomputo = True 
            If (Codigo_cliente = ds_xcargas.Tables(0).Rows(j).Item("Cliente")) And (ds_xcargas.Tables(0).Rows(j).Item("SinComputo") = True) Then
              recaudacionSC = recaudacionSC + ds_xcargas.Tables(0).Rows(j).Item("TotalImporte")
            End If

            j = j + 1
          End While
          recaudacion = (Math.Round(recaudacion, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          recaudacionSC = (Math.Round(recaudacionSC, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento


          'calculo comision y comisionSC---------------------------------------------------------------------------------------------------------------------------------------
          'operacion: Comision = al calculo del porcentaje del total de Recaudacion (el porcentaje se obtiene de la tabla dbo.Clientes.Comision) del cliente.
          Dim cliente_comision As Decimal = ds_xcargas.Tables(0).Rows(i).Item("Cliente_Comision")
          Dim comision As Decimal = (recaudacion * cliente_comision) / 100
          comision = (Math.Round(comision, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          'operacion: ComisionSC = al calculo del porcentaje del total de Recaudacion (el porcentaje se obtiene de la tabla dbo.Clientes.Comision) del cliente.
          Dim comisionSC As Decimal = (recaudacionSC * cliente_comision) / 100
          '--------------------------------------------------------------------------------------------------------------------------------------------------------------------

          'calculo premios-----------------------------------------------------------------------------------------------------------------------------------------------------
          'operacion: Premios = a la suma de todos los importes de la tabla dbo.Premios.Premio del cliente, donde dbo.Premios.Sincomputo = False
          'operacion 2: PremiosSC = a la suma de todos los importes de la tabla dbo.Premios.Premio del cliente, donde dbo.Premios.Sincomputo = True
          Dim ds_premios As DataSet = DAPremios.Premios_ClienteobtenerXfecha(HF_fecha.Value, Codigo_cliente)
          Dim Premios As Decimal = 0
          Dim PremiosSC As Decimal = 0
          Dim jj As Integer = 0
          While jj < ds_premios.Tables(0).Rows.Count
            If ds_premios.Tables(0).Rows(jj).Item("Sincomputo") = False Then
              Premios = Premios + ds_premios.Tables(0).Rows(jj).Item("Premio")
            End If
            If ds_premios.Tables(0).Rows(jj).Item("Sincomputo") = True Then
              PremiosSC = PremiosSC + ds_premios.Tables(0).Rows(jj).Item("Premio")
            End If
            jj = jj + 1
          End While
          Premios = (Math.Round(Premios, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          '---------------------------------------------------------------------------------------------------------------------------------------------------------------------

          'calculo Reclamos y ReclamosSC-----------------------------------------------------------------------------------------------------------------------------------------------------
          'operacion: Reclamos = a la suma de todos los importes de la tabla dbo.Anticipados.Importe del cliente,
          'donde dbo.Anticipados.Sincalculo = False y dbo.Anticipados.Origen = False y dbo.Anticipados.Tipo = 1.
          'operacion2: ReclamosSC = a la suma de todos los importes de la tabla dbo.Anticipados.Importe del cliente, donde dbo.Anticipados.Sincalculo = True y dbo.Anticipados.Origen = False y dbo.Anticipados.Tipo = 1
          'operacion3: dbo.CtaCte.ReclamosB = a la suma de todos los importes de la tabla dbo.Anticipados.Importe del cliente, donde dbo.Anticipados.Origen = True y dbo.Anticipados.Tipo = 1 
          Dim Reclamos As Decimal = 0
          Dim ReclamosSC As Decimal = 0
          Dim ReclamosB As Decimal = 0
          Dim ds_anticipados As DataSet = DAAnticipados.Anticipados_ClienteobtenerXfecha(HF_fecha.Value, Codigo_cliente)
          'operacon4: Cobros = a la suma de todos los importes de la tabla dbo.Anticpados.Importe del cliente, donde dbo.Anticipados.Tipo = 2
          'operacion5: Pagos = a la suma de todos los importes de la tabla dbo.Anticpados.Importe del cliente, donde dbo.Anticipados.Tipo = 3
          Dim Cobros As Decimal = 0
          Dim Pagos As Decimal = 0
          Dim ii As Integer = 0
          While ii < ds_anticipados.Tables(0).Rows.Count
            If ds_anticipados.Tables(0).Rows(ii).Item("AnticipadosTipo_id") = 1 Then
              If (ds_anticipados.Tables(0).Rows(ii).Item("Sincalculo") = False) And (ds_anticipados.Tables(0).Rows(ii).Item("Origen") = False) Then
                Reclamos = Reclamos + ds_anticipados.Tables(0).Rows(ii).Item("Importe")
              End If
              If (ds_anticipados.Tables(0).Rows(ii).Item("Sincalculo") = True) And (ds_anticipados.Tables(0).Rows(ii).Item("Origen") = False) Then
                ReclamosSC = ReclamosSC + ds_anticipados.Tables(0).Rows(ii).Item("Importe")
              End If
              If ds_anticipados.Tables(0).Rows(ii).Item("Origen") = True Then
                ReclamosB = ReclamosB + ds_anticipados.Tables(0).Rows(ii).Item("Importe")
              End If
            End If
            If ds_anticipados.Tables(0).Rows(ii).Item("AnticipadosTipo_id") = 2 Then
              Cobros = Cobros + ds_anticipados.Tables(0).Rows(ii).Item("Importe")
            End If
            If ds_anticipados.Tables(0).Rows(ii).Item("AnticipadosTipo_id") = 3 Then
              Pagos = Pagos + ds_anticipados.Tables(0).Rows(ii).Item("Importe")
            End If
            ii = ii + 1
          End While
          Reclamos = (Math.Round(Reclamos, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          ReclamosSC = (Math.Round(ReclamosSC, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          ReclamosB = (Math.Round(ReclamosB, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          Cobros = (Math.Round(Cobros, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          Pagos = (Math.Round(Pagos, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          '--------------------------------------------------------------------------------------------------------------------------------------------------------------------

          'calculo DejoGano y DejoGanoSC----------------------------------------------------------------------------------------------------------------------------------------------------
          'operacion: DejoGano = dbo.CtaCte.Recaudacion - dbo.CtaCte.Comision - dbo.CtaCte.Premios - dbo.CtaCte.Reclamos
          Dim DejoGano As Decimal = recaudacion - comision - Premios - Reclamos
          DejoGano = (Math.Round(DejoGano, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          'operacion2: DejoGanoSC = dbo.CtaCte.RecaudacionSC - dbo.CtaCte.ComisionSC - dbo.CtaCte.PremiosSC - dbo.CtaCte.ReclamosSC
          Dim DejoGanoSC As Decimal = recaudacionSC - comisionSC - PremiosSC - ReclamosSC
          DejoGanoSC = (Math.Round(DejoGanoSC, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento
          'operacion3: DejoGanoB = dbo.CtaCte.RecaudacionB - dbo.CtaCte.ComisionB - dbo.CtaCte.PremiosB - dbo.CtaCte.ReclamosB
          Dim RecaudacionB = 0
          Dim ComisionB = 0
          Dim PremiosB = 0
          Dim DejoGanoB As Decimal = RecaudacionB - ComisionB - PremiosB - ReclamosB
          '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


          '--------------------------------------------------------------------------------------------------------------------------------------------------
          'dbo.CtaCte.Prestamo = a la suma de todos los prestamos dados de alta para la fecha (dbo.PrestamosCreditos.Saldo)
          'dbo.CtaCte.Credito = a la suma de todos los creditos dados de alta para la fecha (dbo.PrestamosCreditos.Saldo)
          Dim Prestamo As Decimal = 0
          Dim Credito As Decimal = 0
          'recupero primero todos los prestamos donde fecha= fecha_liquidacion
          Dim ds_prescred As DataSet = DALiquidacion.LiquidacionFinal_obtener_prestamoscreditos(CDate(HF_fecha.Value), CInt(Codigo_cliente))
          Dim k As Integer = 0
          While k < ds_prescred.Tables(0).Rows.Count
            Select Case ds_prescred.Tables(0).Rows(k).Item("Tipo")
              Case "P"
                Prestamo = Prestamo + CDec(ds_prescred.Tables(0).Rows(k).Item("Saldo"))
              Case "C"
                Credito = Credito + CDec(ds_prescred.Tables(0).Rows(k).Item("Saldo"))
            End Select
            k = k + 1
          End While


          '--------------------------------------------------------------------------------------------------------------------------------------------------


          '-------aqui guardo en bd-----
          DACtaCte.CtaCte_alta(Grupo_id, CInt(Codigo_cliente), HF_fecha.Value, SaldoAnterior, recaudacion, comision, Premios, Reclamos, DejoGano,
                      recaudacionSC, comisionSC, PremiosSC, ReclamosSC, DejoGanoSC,
                      RecaudacionB, ComisionB, PremiosB, ReclamosB, DejoGanoB, Cobros, Pagos, Prestamo, Credito)
          '---------fin--------------


          '//////////////////////////////EN ESTA SECCION AGREGO UN REGISTRO POR CADA MOVIMIENTO DEL CLIENTE: PAGOS, COBROS, RECLAMOS/////////////////
          'valido si alguno de esos parametros es distinto de 0 lo agrego.
          If Pagos <> CDec(0) Then
            Dim fila_mov As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
            fila_mov("Cliente") = Codigo_cliente
            fila_mov("Movimiento") = "PAGO"
            fila_mov("Importe") = CDec(Pagos)
            DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_mov)
          End If
          If Cobros <> CDec(0) Then
            Dim fila_mov As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
            fila_mov("Cliente") = Codigo_cliente
            fila_mov("Movimiento") = "COBRO"
            fila_mov("Importe") = CDec(Cobros)
            DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_mov)
          End If
          Dim SumReclamos As Decimal = Reclamos + ReclamosSC + ReclamosB
          If SumReclamos <> CDec(0) Then
            Dim fila_mov As DataRow = DS_liqfinal.Tables("PagosCobrosReclamos").NewRow
            fila_mov("Cliente") = Codigo_cliente
            fila_mov("Movimiento") = "RECLAMO"
            fila_mov("Importe") = CDec(SumReclamos)
            DS_liqfinal.Tables("PagosCobrosReclamos").Rows.Add(fila_mov)
          End If
          '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

          '-------------TERCERA ETAPA: Actualizacion de Saldo y SaldoRegaldo por cada cliente que tuvo movimento en la fecha del parametro a liquidar.------------------------------------------------------------


          'ACTUALIZACION DE SALDO------------
          'dbo.Clientes.SaldoAnterior = dbo.Clientes.Saldo
          Dim Clie_Saldo As Decimal = ds_xcargas.Tables(0).Rows(i).Item("Cliente_Saldo")
          Dim Clie_SaldoAnterior As Decimal = Clie_Saldo
          'dbo.Clientes.Saldo = dbo.Clientes.Saldo + dbo.CtaCteRecaudacion + dbo.CtaCteRecaudacionSC + dbo.CtaCteRecaudacionB - dbo.CtaCte.Comision - dbo.CtaCte.ComisionSC - dbo.CtaCte.ComisionB - dbo.CtaCte.Premios - dbo.CtaCte.PremiosSC - dbo.CtaCte.PremiosB - dbo.CtaCte.Reclamos - dbo.CtaCte.ReclamosSC - dbo.CtaCte.ReclamosB - dbo.CtaCte.Cobros + dbo.CtaCte.Pagos + dbo.CtaCte.CobPrestamo + dbo.CtaCte.CobCredito + dbo.Ctacte.Prestamo + dbo.Ctacte.Credito
          Clie_Saldo = Clie_Saldo + recaudacion + recaudacionSC + RecaudacionB - comision - comisionSC - ComisionB - Premios - PremiosSC - PremiosB - Reclamos - ReclamosSC - ReclamosB + Cobros - Pagos + 0 + 0 + Prestamo + Credito

          '---aqui guardo en bd -----
          DACliente.Clientes_ActualizarSaldo(Codigo_cliente, Clie_SaldoAnterior, Clie_Saldo)
          '--------------------------

          'ACTUALIZACION DE SALDO REGALO--------------
          'Operacion: dbo.Clientes.SaldoRegalo = dbo.Clientes.SaldoRegalo + ((dbo.CtaCte.Recaudacion - dbo.CtaCte.Comision - dbo.CtaCte.Premios - dbo.CtaCte.Reclamos) * dbo.Clientes.Regalo)
          Dim Clie_Regalo As Decimal = ds_xcargas.Tables(0).Rows(i).Item("Cliente_Regalo")
          Dim SaldoRegalo As Decimal = ds_xcargas.Tables(0).Rows(i).Item("Cliente_SaldoRegalo")
          SaldoRegalo = SaldoRegalo + (((recaudacion - comision - Premios - Reclamos) / 100) * Clie_Regalo * -1)

          '---aqui guardo en bd----
          DACliente.Clientes_ActualizarSaldoRegalo(Codigo_cliente, SaldoRegalo)
          '------------------------




        End If
        cliente_agregado = Codigo_cliente 'esto lo hago para no contar 2 veces la recaudacion, y pasar continuar hasta el nuevo codigo de cliente

        i = i + 1
      End While

      'ACTUALIZACON DE ULTIMA FECHA DE LIQUIDACION---------------
      'Operacion: dbo.Clientes.UltFechaLiq = a la fecha del parametro del dia de liquidacion, se actuliza la fecha de liquidacion aunque el cliente no haya tenido ningun movimiento.
      DACliente.Clientes_ActualizarFechaLiq(HF_fecha.Value)


    End If
    '-----------------------------------------------------------------------------------------------------------------

  End Sub

  Private Sub grabar_premios_op1(ByRef DS_liqparcial1 As DataSet, ByVal registro As DataRow, ByVal referencia_recorrido As String)

    Dim fila As DataRow = DS_liqparcial1.Tables("PremiosxClientes").NewRow
    fila("Cliente") = registro.Item("Cliente")
    fila("Recorrido") = referencia_recorrido
    fila("Importe") = registro.Item("Importe")
    fila("PID") = registro.Item("Pid")
    fila("SUC") = registro.Item("Suc")
    fila("P2") = ""

    If registro.Item("SinComputo") = True Then
      fila("SC") = "X"
    Else
      fila("SC") = ""
    End If
    Dim premio As Decimal = 0
    Select Case Len(registro.Item("Pid").ToString)
      Case 1
        premio = CDec(CDec(registro.Item("Importe")) * 7)
      Case 2
        premio = CDec(CDec(registro.Item("Importe")) * 70)
      Case 3
        premio = CDec(CDec(registro.Item("Importe")) * 600)
      Case 4
        premio = CDec(CDec(registro.Item("Importe")) * 3500)
    End Select
    fila("Premio") = (Math.Round(premio, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento

    fila("T") = registro.Item("Terminal").ToString.ToUpper

    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
        premio = premio * (-1)
      End If
    End If


    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)

    '-----------------------AQUI GUARDO EN LA BASE DATOS ----NUEVO REGISTRO EN TABLA PREMIOS----------------------
    Dim NroTicket As String = ""
    If registro.Item("Terminal").ToString.ToUpper = "W" Then
      NroTicket = registro.Item("Item").ToString
    End If
    DAPremios.Premios_altaOP1y2(HF_fecha.Value, registro.Item("Recorrido_codigo"),
                           CStr(registro.Item("Pid")), CDec(registro.Item("Importe")),
                           CInt(registro.Item("Suc")), CInt(0), CInt(registro.Item("SinComputo")),
premio, NroTicket, CStr(registro.Item("Terminal")), CStr(registro.Item("Cliente")))



  End Sub

  Private Sub grabar_premios_op2(ByRef DS_liqparcial1 As DataSet, ByVal registro As DataRow, ByVal referencia_recorrido As String, ByVal ContCoincidencia As Integer)
    Dim fila As DataRow = DS_liqparcial1.Tables("PremiosxClientes").NewRow
    fila("Cliente") = registro.Item("Cliente")
    fila("Recorrido") = referencia_recorrido
    fila("Importe") = registro.Item("Importe")
    fila("PID") = registro.Item("Pid")
    fila("SUC") = registro.Item("Suc")
    fila("P2") = ""
    If registro.Item("SinComputo") = True Then
      fila("SC") = "X"
    Else
      fila("SC") = ""
    End If
    Dim premio As Decimal = 0
    Select Case Len(registro.Item("Pid").ToString)
      Case 1
        premio = (CDec(CDec(registro.Item("Importe")) * 7)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 2
        premio = (CDec(CDec(registro.Item("Importe")) * 70)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 3
        premio = (CDec(CDec(registro.Item("Importe")) * 600)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 4
        premio = (CDec(CDec(registro.Item("Importe")) * 3500)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
    End Select

    fila("Premio") = (Math.Round(premio, 2).ToString("N2")) 'redondeo a 2dig en el decimal para evitar desbordamiento


    fila("T") = registro.Item("Terminal").ToString.ToUpper
    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
        premio = premio * (-1)
      End If
    End If
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)

    '-----------------------AQUI GUARDO EN LA BASE DATOS ----NUEVO REGISTRO EN TABLA PREMIOS----------------------
    Dim NroTicket As String = ""
    If registro.Item("Terminal").ToString.ToUpper = "W" Then
      NroTicket = registro.Item("Item").ToString
    End If
    DAPremios.Premios_altaOP1y2(HF_fecha.Value, registro.Item("Recorrido_codigo"),
                           CStr(registro.Item("Pid")), CDec(registro.Item("Importe")),
                           CInt(registro.Item("Suc")), 0, CInt(registro.Item("SinComputo")),
premio, NroTicket, CStr(registro.Item("Terminal")), CStr(registro.Item("Cliente")))

  End Sub

  Private Sub grabar_premios_op3(ByRef DS_liqparcial1 As DataSet, ByVal registro As DataRow, ByVal referencia_recorrido As String, ByVal ContCoincidencia As Integer)
    Dim fila As DataRow = DS_liqparcial1.Tables("PremiosxClientes").NewRow
    fila("Cliente") = registro.Item("Cliente")
    fila("Recorrido") = referencia_recorrido
    fila("Importe") = registro.Item("Importe")
    fila("PID") = registro.Item("Pid")
    fila("SUC") = registro.Item("Suc")
    fila("S2") = registro.Item("Suc2")
    fila("P2") = registro.Item("Pid2")
    Dim premio As Decimal = 0

    If registro.Item("SinComputo") = True Then
      fila("SC") = "X"
    Else
      fila("SC") = ""
    End If
    Try
      '-------------------------------------------------------------------------------------------------------------------------------------------
      '----------------•	si XCargasL.Suc2 < 20, dbo.Premios.Premio = el valor del importe encontrado en -----------------------------------------
      '----------------el registro de la coincidencia dbo.XCargasL.Importe * 80 * ((80 / dbo.XCargasL.Suc2) * la cantidad de veces ---------------
      '----------------que coincidio dbo.XCargasL.Pid2 dentro de la dbo.Puntos.P(hasta el valor de dbo.XCargasL.Suc2 + 1)) -----------------------
      '-------------------------------------------------------------------------------------------------------------------------------------------
      If CInt(registro.Item("Suc2")) < 20 Then
        Dim Suc2 As Integer = CInt(registro.Item("Suc2"))
        Dim Importe As Decimal = CDec(registro.Item("Importe"))
        premio = Importe * 80 * ((80 / Suc2) * ContCoincidencia)
        fila("Premio") = (Math.Round(premio, 2).ToString("N2"))
      Else
        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-------------•	si XCargasL.Suc2 = 20, dbo.Premios.Premio = el valor del importe encontrado en el registro
        '-------------de la coincidencia dbo.XCargasL.Importe * 80 * ((80 / 19) * la cantidad de veces que------------------------------------------
        '-------------coincidio dbo.XCargasL.Pid2 dentro de la dbo.Puntos.P(hasta el valor de dbo.XCargasL.Suc2))-----------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------
        If CInt(registro.Item("Suc2")) = 20 Then
          Dim Importe As Decimal = CDec(registro.Item("Importe"))
          premio = Importe * 80 * ((80 / 19) * ContCoincidencia)
          fila("Premio") = (Math.Round(premio, 2).ToString("N2"))
        End If
      End If
    Catch ex As Exception

    End Try
    fila("T") = registro.Item("Terminal").ToString.ToUpper
    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
        premio = premio * (-1)
      End If
    End If
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)

    '-----------------------AQUI GUARDO EN LA BASE DATOS ----NUEVO REGISTRO EN TABLA PREMIOS----------------------
    Dim NroTicket As String = ""
    If registro.Item("Terminal").ToString.ToUpper = "W" Then
      NroTicket = registro.Item("Item").ToString
    End If
    DAPremios.Premios_altaOP3y4(HF_fecha.Value, registro.Item("Recorrido_codigo"),
                           CStr(registro.Item("Pid")), CDec(registro.Item("Importe")),
                           CInt(registro.Item("Suc")), CStr(registro.Item("Pid2")), CInt(registro.Item("Suc2")), 1, CInt(registro.Item("SinComputo")),
                           premio, NroTicket, CStr(registro.Item("Terminal")), CStr(registro.Item("Cliente")))


  End Sub

  Private Sub grabar_premios_op4(ByRef DS_liqparcial1 As DataSet, ByVal registro As DataRow, ByVal referencia_recorrido As String, ByVal ContCoincidencia1 As Integer, ByVal ContCoincidencia2 As Integer)
    Dim fila As DataRow = DS_liqparcial1.Tables("PremiosxClientes").NewRow
    fila("Cliente") = registro.Item("Cliente")
    fila("Recorrido") = referencia_recorrido
    fila("Importe") = registro.Item("Importe")
    fila("PID") = registro.Item("Pid")
    fila("SUC") = registro.Item("Suc")
    fila("S2") = registro.Item("Suc2")
    fila("P2") = registro.Item("Pid2")
    Dim premio As Decimal = 0
    If registro.Item("SinComputo") = True Then
      fila("SC") = "X"
    Else
      fila("SC") = ""
    End If

    Try
      Dim importe As Decimal = CDec(registro.Item("Importe"))
      Dim suc As Integer = CInt(registro.Item("Suc"))
      Dim suc2 As Integer = CInt(registro.Item("Suc2"))
      premio = importe * ((80 / suc) * ContCoincidencia1) * ((80 / suc2) * ContCoincidencia2)
      fila("Premio") = (Math.Round(premio, 2).ToString("N2"))
    Catch ex As Exception

    End Try
    fila("T") = registro.Item("Terminal").ToString.ToUpper
    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
        premio = premio * (-1)
      End If
    End If
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)

    '-----------------------AQUI GUARDO EN LA BASE DATOS ----NUEVO REGISTRO EN TABLA PREMIOS----------------------
    Dim NroTicket As String = ""
    If registro.Item("Terminal").ToString.ToUpper = "W" Then
      NroTicket = registro.Item("Item").ToString
    End If
    DAPremios.Premios_altaOP3y4(HF_fecha.Value, registro.Item("Recorrido_codigo"),
                           CStr(registro.Item("Pid")), CDec(registro.Item("Importe")),
                           CInt(registro.Item("Suc")), CStr(registro.Item("Pid2")), CInt(registro.Item("Suc2")), 1, CInt(registro.Item("SinComputo")),
premio, NroTicket, CStr(registro.Item("Terminal")), CStr(registro.Item("Cliente")))



  End Sub




#End Region

End Class
