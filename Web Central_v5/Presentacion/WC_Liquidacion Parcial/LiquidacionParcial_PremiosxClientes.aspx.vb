Public Class LiquidacionParcial_PremiosxClientes
  Inherits System.Web.UI.Page
#Region "Declaraciones"
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion
  Dim DACliente As New Capa_Datos.WB_clientes
#End Region

#Region "Eventos"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      HF_fecha.Value = Session("fecha_parametro")
      Dim FECHA As Date = CDate(HF_fecha.Value)
      'LABEL_fecha_parametro.Text = FECHA.ToString("yyyy-MM-dd")
      LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")

      '---------------------------------------------------------
      Dim DS_liqparcial As New DS_liqparcial
      DS_liqparcial.Tables("Recorridos_seleccionados").Merge(Session("tabla_recorridos_seleccionados"))
      'GridView2.DataSource = DS_liqparcial.Tables("Recorridos_seleccionados")
      'GridView2.DataBind()
      GridView2.Visible = False

      'obtener_totales_parciales(DS_liqparcial)
      obtener_premios_x_clientes(DS_liqparcial)
    End If
  End Sub
#End Region

#Region "Metodos"

  Private Sub obtener_premios_x_clientes(ByVal DS_liqparcial As DataSet)
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
    'ahora ordeno
    Dim rows() As DataRow = DS_XCARGAS1.Tables(0).Select("IDcarga > 0", "Cliente, Recorrido_codigo ASC")
    Dim dtTemp As DataTable = DS_XCARGAS1.Tables(0).Clone() 'copio la estructura de la tabla.
    For Each row As DataRow In rows
      ' Indicamos que el registro ha sido añadido
      row.SetAdded()
      dtTemp.ImportRow(row)
    Next
    'dtTemp tiene todos los registros de XCargas ya ordenas para poder continuar.
    '-------------fin paso 1------------------------------------------------------------------------------------------

    carga_liquidacion_parcial(dtTemp)

    GridView2.DataSource = dtTemp
    GridView2.DataBind()

  End Sub

  Private Sub carga_liquidacion_parcial(ByVal dtTemp As DataTable)

    Dim DS_liqparcial1 As New DS_liqparcial
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Clear()

    Dim valor11 = 1234
    Dim undigito As String = valor11.ToString.Substring(3, 1)
    Dim dosdigitos As String = valor11.ToString.Substring(2, 2)
    Dim tresdigitos As String = valor11.ToString.Substring(1, 3)

    Dim i As Integer = 0
    While i < dtTemp.Rows.Count
      Dim XCargas_Suc = dtTemp.Rows(i).Item("Suc")
      Dim XCargas_R = dtTemp.Rows(i).Item("R") 'true or false

      '--------------------------------------1) PRIMERA ALTERNATIVA-------------------------------------------------------------------------------
      If XCargas_Suc = 0 Or XCargas_Suc = 1 And XCargas_R = False Then
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
              grabar_premios_P1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
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
              grabar_premios_P1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
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
              grabar_premios_P1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
            Else
              Dim respuesta = "no hay coincidencia"

            End If
          Case 4
            'comparar con 4 digito en puntos_p1
            If XCargas_Pid = Puntos_P1 Then

              Dim respuesta = "son iguales"
              grabar_premios_P1(DS_liqparcial1, dtTemp.Rows(i), referencia_recorrido)
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
          If XCargas_Suc = 0 Or XCargas_Suc = 1 And XCargas_R = True Then
          Else
            If XCargas_Suc > 1 And XCargas_R = True Then
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
          fila("Premio") = CDec(suma_premio)
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
        filaa("Premio") = CDec(suma_premio)
        dtTemp_con_cortes_control.Rows.Add(filaa)
      End If
      'agrego fila con TOTAL GENERAL
      Dim fila_a As DataRow = dtTemp_con_cortes_control.NewRow
      fila_a("Cliente") = "TOTAL GENERAL"
      fila_a("Premio") = CDec(total_general)
      dtTemp_con_cortes_control.Rows.Add(fila_a)

    End If

    'MUESTRO EN EL GRIDVIEW---------------------------------------------------------------------------------
    GridView1.DataSource = dtTemp_con_cortes_control
    GridView1.DataBind()

    'GridView1.DataSource = DS_liqparcial1.Tables("PremiosxClientes")
    'GridView1.DataBind()
    '-------------------------------------------------------------------------------------------------------

  End Sub

  Private Sub grabar_premios_P1(ByRef DS_liqparcial1 As DataSet, ByVal registro As DataRow, ByVal referencia_recorrido As String)

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

    Select Case Len(registro.Item("Pid").ToString)
      Case 1
        fila("Premio") = CDec(CDec(registro.Item("Importe")) * 7)
      Case 2
        fila("Premio") = CDec(CDec(registro.Item("Importe")) * 70)
      Case 3
        fila("Premio") = CDec(CDec(registro.Item("Importe")) * 600)
      Case 4
        fila("Premio") = CDec(CDec(registro.Item("Importe")) * 3500)
    End Select

    fila("T") = registro.Item("Terminal").ToString.ToUpper

    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
      End If
    End If


    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)

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

    Select Case Len(registro.Item("Pid").ToString)
      Case 1
        fila("Premio") = (CDec(CDec(registro.Item("Importe")) * 7)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 2
        fila("Premio") = (CDec(CDec(registro.Item("Importe")) * 70)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 3
        fila("Premio") = (CDec(CDec(registro.Item("Importe")) * 600)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
      Case 4
        fila("Premio") = (CDec(CDec(registro.Item("Importe")) * 3500)) / (CDec(registro.Item("Suc")) * ContCoincidencia)
    End Select

    fila("T") = registro.Item("Terminal").ToString.ToUpper
    fila("OBS") = "" 'corresponde graba "CUB.", en el caso que el cliente tenga la variable1 = true y ademas el valor del premio va en negativo.
    Dim ds_cliente As DataSet = DACliente.Clientes_buscar_codigo(registro.Item("Cliente"))
    If ds_cliente.Tables(0).Rows.Count <> 0 Then
      If ds_cliente.Tables(0).Rows(0).Item("Variable1") = True Then
        fila("OBS") = "CUB."
        fila("Premio") = fila("Premio") * (-1)
      End If
    End If
    DS_liqparcial1.Tables("PremiosxClientes").Rows.Add(fila)
  End Sub

#End Region

End Class
