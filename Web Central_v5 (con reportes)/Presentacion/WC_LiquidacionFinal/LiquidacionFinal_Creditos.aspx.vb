Public Class LiquidacionFinal_Creditos
  Inherits System.Web.UI.Page
#Region "DECLARACIONES"
  Dim DaPrestamosCreditos As New Capa_Datos.WC_prestamoscreditos
  Dim DACtaCte As New Capa_Datos.WC_CtaCte
  Dim DACliente As New Capa_Datos.WB_clientes
  Dim DAParametro As New Capa_Datos.WC_parametro
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion
#End Region

#Region "METODOS"

#End Region

#Region "EVENTOS"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      HF_fecha.Value = Session("fecha_parametro")
      Dim FECHA As Date = CDate(HF_fecha.Value)
      'LABEL_fecha_parametro.Text = FECHA.ToString("yyyy-MM-dd")
      LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")


      Dim DS_liqfinal As New DS_liqfinal
      DS_liqfinal.Tables("Creditos").Rows.Clear()

      '1) El proceso de cobro de creditos consiste en buscar los
      'creditos activos dbo.PrestamosCreditos.Estado = "A" y en donde dbo.PrestamosCreditos.Tipo = C
      Dim DS_Creditos As DataSet = DaPrestamosCreditos.Creditos_obtener
      If DS_Creditos.Tables(0).Rows.Count <> 0 Then
        Dim i As Integer = 0
        While i < DS_Creditos.Tables(0).Rows.Count
          Dim Cliente_ID As Integer = DS_Creditos.Tables(0).Rows(i).Item("Cliente_ID")
          Dim Cliente_Codigo As String = DS_Creditos.Tables(0).Rows(i).Item("Cliente_Codigo")

          Dim fecha_prestamo As Date = DS_Creditos.Tables(0).Rows(i).Item("Fecha")
          If fecha_prestamo <> CDate(HF_fecha.Value) Then 'Si el credito fue dado de alta en la fecha del dia a liquidar no deberia ejecutarse ningun cobro.
            Dim ds_ctacte As DataSet = DACtaCte.CtaCte_obtener(CInt(Cliente_Codigo), HF_fecha.Value)
            If ds_ctacte.Tables(0).Rows.Count <> 0 Then
              Dim IdCtaCte As Integer = ds_ctacte.Tables(0).Rows(0).Item("IdCtaCte")
              Dim PrestamosCreditos_Saldo As Decimal = DS_Creditos.Tables(0).Rows(i).Item("Saldo")
              Dim PrestamosCreditos_IdPrestamoCredito As Integer = DS_Creditos.Tables(0).Rows(i).Item("Idprestamocredito")
              Dim PrestamosCreditos_cuota As Decimal = DS_Creditos.Tables(0).Rows(i).Item("Cuota_valor") 'ojo el valor de la cuota es 0 en la tabla
              'RECUPERO NRO ULTIMA CUOTA
              Dim DS_cuota As DataSet = DaPrestamosCreditos.CobroPrestamosCreditos_obtener_cuota(PrestamosCreditos_IdPrestamoCredito)
              Dim nro_cta_cobrada As Integer = 0 '---de donde lo saco...hago un select de todos los cobrosprestamoscreditos para ese id?
              If DS_cuota.Tables(0).Rows.Count <> 0 Then
                nro_cta_cobrada = CDec(DS_cuota.Tables(0).Rows(0).Item("Cuota")) + 1
              Else
                nro_cta_cobrada = CDec(1)
              End If

              Dim importe As Decimal = PrestamosCreditos_cuota
              'AQUI GUARDO EN BD
              DaPrestamosCreditos.CobroPrestamosCreditos_altaCredito(PrestamosCreditos_IdPrestamoCredito, HF_fecha.Value, importe, nro_cta_cobrada)

              '----------------------------------------------------------------------------------------------------------------------------------------------------
              'Actualizar el saldo del credito dbo.PrestamosCreditos.Saldo = dbo.PrestamosCreditos.Saldo - dbo.CobroPrestamosCreditos.Importe
              '(si el cobro del credito es de la ultima cuota se deberia marcar este credito como "Cancelado" dbo.PrestamosCreditos.Estado = C)
              PrestamosCreditos_Saldo = PrestamosCreditos_Saldo - PrestamosCreditos_cuota
              Dim Estado_id As Integer = 1 '1 activo, 2 cancelado, 3 baja
              If (PrestamosCreditos_Saldo = 0) Or (PrestamosCreditos_Saldo < 0) Then
                PrestamosCreditos_Saldo = 0
                'esta cancelado el prestamo
                Estado_id = 2
              End If

              'AQUI ACTUALIZO EN BD
              DaPrestamosCreditos.PrestamosCreditos_ActualizarSaldo(PrestamosCreditos_IdPrestamoCredito, PrestamosCreditos_Saldo, Estado_id)
              '----------------------------------------------------------------------------------------------------------------------------------------------------

              '----------------------------------------------------------------------------------------------------------------------------------------------------
              'Actualizar el campo dbo.CtaCte.CobCredito = dbo.CtaCte.CobCredito + dbo.CobroPrestamosCreditos.Importe
              Dim CobCredito As Decimal = 0
              Try 'el try lo uso x que el campo recuperado de ctacte es null
                CobCredito = ds_ctacte.Tables(0).Rows(0).Item("CobCredito") + importe
              Catch ex As Exception
                CobCredito = importe
              End Try


              DACtaCte.CtaCte_actualizarCobCredito(IdCtaCte, CobCredito)
              '----------------------------------------------------------------------------------------------------------------------------------------------------

              '----------------------------------------------------------------------------------------------------------------------------------------------------
              'Actualizar el saldo dbo.Clientes.Saldo = dbo.Clientes.Saldo + dbo.CtaCte.CobCredito
              DACliente.Cliente_ActualizarSaldo_ctacte2(Cliente_ID, importe)
              '----------------------------------------------------------------------------------------------------------------------------------------------------

              'agrego 1 registro al datatable q voy a mandar al gridview.
              Dim fila As DataRow = DS_liqfinal.Tables("Creditos").NewRow
              fila("Cliente") = CInt(Cliente_Codigo)
              Dim FechaPrestamo_Ori As Date = DS_Creditos.Tables(0).Rows(i).Item("Fecha")
              fila("Fecha_Ori") = FechaPrestamo_Ori.ToString("dd-MM-yyyy")
              fila("Importe_Cob") = (Math.Round(importe, 2).ToString("N2"))
              fila("Cuota") = (Math.Round(nro_cta_cobrada, 2).ToString("N2"))
              fila("Saldo") = (Math.Round(PrestamosCreditos_Saldo, 2).ToString("N2"))

              Dim porcentaje As Decimal = DS_Creditos.Tables(0).Rows(i).Item("Porcentaje")
              Dim Interes As Decimal = porcentaje / 100
              Dim MontoInteres As Decimal = CDec(DS_Creditos.Tables(0).Rows(i).Item("Importe")) * Interes
              Dim Credito As Decimal = CDec(DS_Creditos.Tables(0).Rows(i).Item("Importe")) + MontoInteres
              '              Dim Credito As Decimal = DS_Creditos.Tables(0).Rows(i).Item("Importe")


              fila("Credito") = (Math.Round(Credito, 2).ToString("N2"))
              DS_liqfinal.Tables("Creditos").Rows.Add(fila)

            End If

          End If


          i = i + 1
        End While


      End If

      'ahora muestro DS_liqfinal.tables("Creditos") en un gridview.

      GridView1.DataSource = DS_liqfinal.Tables("Creditos")
      GridView1.DataBind()

      '------------------AQUIREPORTE ------------------------------------------------
      Dim fila_1 As DataRow = DS_liqfinal.Tables("Creditos_info").NewRow
      fila_1("Fecha") = CDate(HF_fecha.Value)
      DS_liqfinal.Tables("Creditos_info").Rows.Add(fila_1)
      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/LiquidacionFinal_informe04.rpt"))
      CrReport.Database.Tables("Creditos").SetDataSource(DS_liqfinal.Tables("Creditos"))
      CrReport.Database.Tables("Creditos_info").SetDataSource(DS_liqfinal.Tables("Creditos_info"))
      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/LiqFinal_CobCreditos.pdf"))

      '------------------------------------------------------------------------------

      If GridView1.Rows.Count = 0 Then
        Label_noprestamos.Visible = True
      End If

      DAParametro.Parametro_finalizar_dia(HF_fecha.Value)

      '-------------------------------------------------------------------------------
      'NOTA: ELIMINO LOS REGISTRO EN XCARGAS 1 A N.
      DALiquidacion.XCargas_delete()
      'fecha:11-08-2022
      '-------------------------------------------------------------------------------


      btn_continuar.Focus()

    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Session("fecha_parametro") = HF_fecha.Value
    Response.Redirect("~/Inicio.aspx")
  End Sub
#End Region




End Class
