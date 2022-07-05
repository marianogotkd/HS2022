Public Class LiquidacionParcial_TotalesParciales
  Inherits System.Web.UI.Page
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      HF_fecha.Value = Session("fecha_parametro")
      Dim FECHA As Date = CDate(HF_fecha.Value)
      'LABEL_fecha_parametro.Text = FECHA.ToString("yyyy-MM-dd")
      LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")

      '---------------------------------------------------------
      Dim DS_liqparcial As New DS_liqparcial
      DS_liqparcial.Tables("Recorridos_seleccionados").Merge(Session("tabla_recorridos_seleccionados"))
      'GridView1.DataSource = DS_liqparcial.Tables("Recorridos_seleccionados")
      'GridView1.DataBind()

      'obtener_totales_parciales(DS_liqparcial)
      'obtener_total_parciales2(DS_liqparcial)
      obtener_totales_parciales3(DS_liqparcial)

      btn_continuar.Focus()

    End If

  End Sub

  Private Sub obtener_total_parciales2(ByVal DS_liqparcial As DataSet)
    Dim ds_Xcargas As DataSet = DALiquidacion.Liquidacion_recuperarXcargas_totales()
    Dim j As Integer = 0
    While j < ds_Xcargas.Tables(0).Rows.Count
      Dim Terminal As String = ds_Xcargas.Tables(0).Rows(j).Item("Terminal").ToString.ToUpper
      Dim verificado = ds_Xcargas.Tables(0).Rows(j).Item("Verificado")
      Dim encontrado = "no"
      Dim k As Integer = 0
      While k < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
        If Terminal = DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Terminal").ToString.ToUpper Then
          'sumo registro
          DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros")) + 1
          If verificado = False Then
            'sumo como "no verificado"
            DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados")) + 1
          End If
          encontrado = "si"
          Exit While
        End If
        k = k + 1
      End While
      If encontrado = "no" Then
        'agrego fila en datatable
        Dim fila As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
        fila("Terminal") = Terminal
        fila("Registros") = 1
        If verificado = False Then
          fila("NoVerificados") = 1
        Else
          fila("NoVerificados") = 0
        End If
        DS_liqparcial.Tables("Totales_Parciales").Rows.Add(fila)
      End If
      j = j + 1
    End While


    Dim i As Integer = 0
    Dim count_registros As Integer = 0
    Dim count_noverificados As Integer = 0
    While i < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
      count_registros = count_registros + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      count_noverificados = count_noverificados + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal") = "TERMINAL " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros") = "REGISTROS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados") = "NO VERIFICADOS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))

      i = i + 1
    End While
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add()
    Dim filaa As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
    filaa("Terminal") = "TOTAL"
    filaa("Registros") = "REGISTROS: " + CStr(count_registros)
    filaa("NoVerificados") = "NO VERIFICADOS: " + CStr(count_noverificados)
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add(filaa)

    GridView2.DataSource = ""

    GridView2.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView2.DataBind()
    GridView2.Visible = False

    GridView1.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView1.DataBind()

  End Sub

  Private Sub obtener_totales_parciales3(ByVal DS_liqparcial As DataSet)
    Dim ds_Xcargas As DataSet = DALiquidacion.Liquidacion_recuperarXcargas_totales()
    Dim j As Integer = 0
    While j < ds_Xcargas.Tables(0).Rows.Count
      'por cada registro en Xcargas voy a en xcargas_recorridos, cuando obtenga el Recorrido_codigo voy a ver si esta en DS_liqparcial.tables("Recorridos_seleccionados"), lo voy a contar 1 sola vez como verificado o no.
      Dim IDcarga As Integer = CInt(ds_Xcargas.Tables(0).Rows(j).Item("IDcarga"))
      Dim H As Integer = 0
      Dim existe As String = "no"
      While H < ds_Xcargas.Tables(1).Rows.Count
        If IDcarga = CInt(ds_Xcargas.Tables(1).Rows(H).Item("IDcarga")) Then
          'una vez encontrado, voy a ver si esta eb DS_liqparcial.
          Dim Recorrido_codigo As String = ds_Xcargas.Tables(1).Rows(H).Item("Recorrido_codigo").ToString.ToUpper
          Dim G As Integer = 0
          While G < DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Count
            If DS_liqparcial.Tables("Recorridos_seleccionados").Rows(G).Item("Codigo").ToString.ToUpper = Recorrido_codigo Then
              'ENCONTRE, ENTONCES LO SUMO PARA LOS TOTALES PARCIALES-----------------------------

              Dim Terminal As String = ds_Xcargas.Tables(0).Rows(j).Item("Terminal").ToString.ToUpper
              Dim verificado = ds_Xcargas.Tables(0).Rows(j).Item("Verificado")
              Dim encontrado = "no"
              Dim k As Integer = 0
              While k < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
                If Terminal = DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Terminal").ToString.ToUpper Then
                  'sumo registro
                  DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros")) + 1
                  If verificado = False Then
                    'sumo como "no verificado"
                    DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados")) + 1
                  End If
                  encontrado = "si"
                  Exit While
                End If
                k = k + 1
              End While
              If encontrado = "no" Then
                'agrego fila en datatable
                Dim fila As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
                fila("Terminal") = Terminal
                fila("Registros") = 1
                If verificado = False Then
                  fila("NoVerificados") = 1
                Else
                  fila("NoVerificados") = 0
                End If
                DS_liqparcial.Tables("Totales_Parciales").Rows.Add(fila)
              End If

              '----------------------------------------------------------------------------------
              existe = "si"
              Exit While
            End If
            G = G + 1
          End While
        End If
        If existe = "si" Then
          Exit While
        End If
        H = H + 1
      End While



      j = j + 1
    End While


    Dim i As Integer = 0
    Dim count_registros As Integer = 0
    Dim count_noverificados As Integer = 0
    While i < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
      count_registros = count_registros + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      count_noverificados = count_noverificados + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal") = "TERMINAL " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros") = "REGISTROS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados") = "NO VERIFICADOS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))

      i = i + 1
    End While
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add()
    Dim filaa As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
    filaa("Terminal") = "TOTAL"
    filaa("Registros") = "REGISTROS: " + CStr(count_registros)
    filaa("NoVerificados") = "NO VERIFICADOS: " + CStr(count_noverificados)
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add(filaa)

    GridView2.DataSource = ""

    GridView2.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView2.DataBind()
    GridView2.Visible = False

    GridView1.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView1.DataBind()



    Try
      'aqui viene la generacion del reporte 
      Dim fila_1 As DataRow = DS_liqparcial.Tables("Totales_Parciales_info").NewRow
      fila_1("Fecha") = CDate(HF_fecha.Value)
      DS_liqparcial.Tables("Totales_Parciales_info").Rows.Add(fila_1)

      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/LiquidacionParcial_informe01_totalesparciales.rpt"))
      CrReport.Database.Tables("Totales_Parciales").SetDataSource(DS_liqparcial.Tables("Totales_Parciales"))
      CrReport.Database.Tables("Totales_Parciales_info").SetDataSource(DS_liqparcial.Tables("Totales_Parciales_info"))
      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/LiqParcial_TotalesParciales.pdf"))

    Catch ex As Exception

    End Try





  End Sub

  Private Sub obtener_totales_parciales(ByVal DS_liqparcial As DataSet)

    Dim i As Integer = 0
    While i < DS_liqparcial.Tables("Recorridos_seleccionados").Rows.Count
      Dim codigo As String = DS_liqparcial.Tables("Recorridos_seleccionados").Rows(i).Item("Codigo")
      Dim ds_Xcargas As DataSet = DALiquidacion.Liquidacion_parcial_recuperarXcargas(codigo, HF_fecha.Value)
      Dim j As Integer = 0
      While j < ds_Xcargas.Tables(0).Rows.Count

        Dim Terminal As String = ds_Xcargas.Tables(0).Rows(j).Item("Terminal").ToString.ToUpper
        Dim verificado = ds_Xcargas.Tables(0).Rows(j).Item("Verificado")
        Dim encontrado = "no"
        Dim k As Integer = 0
        While k < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
          If Terminal = DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Terminal").ToString.ToUpper Then
            'sumo registro
            DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("Registros")) + 1
            If verificado = False Then
              'sumo como "no verificado"
              DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados") = CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(k).Item("NoVerificados")) + 1
            End If
            encontrado = "si"
            Exit While
          End If
          k = k + 1
        End While
        If encontrado = "no" Then
          'agrego fila en datatable
          Dim fila As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
          fila("Terminal") = Terminal
          fila("Registros") = 1
          If verificado = False Then
            fila("NoVerificados") = 1
          Else
            fila("NoVerificados") = 0
          End If
          DS_liqparcial.Tables("Totales_Parciales").Rows.Add(fila)
        End If

        j = j + 1
      End While


      i = i + 1
    End While


    i = 0
    Dim count_registros As Integer = 0
    Dim count_noverificados As Integer = 0
    While i < DS_liqparcial.Tables("Totales_Parciales").Rows.Count
      count_registros = count_registros + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      count_noverificados = count_noverificados + CInt(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal") = "TERMINAL " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Terminal"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros") = "REGISTROS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("Registros"))
      DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados") = "NO VERIFICADOS: " + CStr(DS_liqparcial.Tables("Totales_Parciales").Rows(i).Item("NoVerificados"))

      i = i + 1
    End While
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add()
    Dim filaa As DataRow = DS_liqparcial.Tables("Totales_Parciales").NewRow
    filaa("Terminal") = "TOTAL"
    filaa("Registros") = "REGISTROS: " + CStr(count_registros)
    filaa("NoVerificados") = "NO VERIFICADOS: " + CStr(count_noverificados)
    DS_liqparcial.Tables("Totales_Parciales").Rows.Add(filaa)

    GridView2.DataSource = ""

    GridView2.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView2.DataBind()
    GridView2.Visible = False

    GridView1.DataSource = DS_liqparcial.Tables("Totales_Parciales")
    GridView1.DataBind()

  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    'aqui envío los parametros para la carga del segundo reporte.
    Session("fecha_parametro") = HF_fecha.Value
    Session("tabla_recorridos_seleccionados") = Session("tabla_recorridos_seleccionados")
    Response.Redirect("~/WC_Liquidacion Parcial/LiquidacionParcial_PremiosxClientes.aspx")

  End Sub
End Class
