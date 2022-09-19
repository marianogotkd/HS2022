Public Class LiquidacionFinal_PrestamosComision
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DaPrestamosCreditos As New Capa_Datos.WC_prestamoscreditos
  Dim DACtaCte As New Capa_Datos.WC_CtaCte
  Dim DACliente As New Capa_Datos.WB_clientes
#End Region

#Region "EVENTOS"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      HF_fecha.Value = Session("fecha_parametro")
      Dim FECHA As Date = CDate(HF_fecha.Value)
      'LABEL_fecha_parametro.Text = FECHA.ToString("yyyy-MM-dd")
      LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")

      'Luego de continuar deberia consultar si se desea descontar "prestamos por comision"
      'en el caso de contestar que "SI" el sistema deberia hacer el cobro de los prestamos activos por comision,
      'en el caso de contestar que "NO" deberia saltar este proceso y continuar.

      Dim DS_liqfinal As New DS_liqfinal
      DS_liqfinal.Tables("PrestamosComision").Rows.Clear()

      '1) El proceso de cobro de prestamos a descontar de la comision consiste en buscar los prestamos
      'activos dbo.PrestamosCreditos.Estado = "A" y en donde dbo.PrestamosCreditos.Tipo = P y
      'dbo.PrestamosCreditos.Tipocobro = 1 para cada cliente 
      Dim DS_PrestamosComision As DataSet = DaPrestamosCreditos.Prestamos_obtener_prestamosxcomision()
      If DS_PrestamosComision.Tables(0).Rows.Count <> 0 Then
        'evaluar si el cliente tuvo movimientos. De haber tenido movimiento hay que ver,
        'si cobro comision en el dia (dbo.CtaCte.Comision > 0) De haber cobrado comision el proceso deberia
        'grabar un movimiento en la tabla dbo.CobroPrestamosCreditos.
        Dim i As Integer = 0
        While i < DS_PrestamosComision.Tables(0).Rows.Count
          Dim Cliente_ID As Integer = DS_PrestamosComision.Tables(0).Rows(i).Item("Cliente_ID")
          Dim Cliente_Codigo As String = DS_PrestamosComision.Tables(0).Rows(i).Item("Cliente_Codigo")
          Dim fecha_prestamo As Date = DS_PrestamosComision.Tables(0).Rows(i).Item("Fecha")
          If fecha_prestamo <> CDate(HF_fecha.Value) Then 'Si el prestamo fue dado de alta en la fecha del dia a liquidar no deberia ejecutarse ningun cobro.
            Dim ds_ctacte As DataSet = DACtaCte.CtaCte_obtener(CInt(Cliente_Codigo), HF_fecha.Value)
            If ds_ctacte.Tables(0).Rows.Count <> 0 Then
              Dim IdCtaCte As Integer = ds_ctacte.Tables(0).Rows(0).Item("IdCtaCte")
              Dim CtaCte_Comision As Decimal = CDec(0)
              Try
                CtaCte_Comision = CDec(ds_ctacte.Tables(0).Rows(0).Item("Comision"))
              Catch ex As Exception
                CtaCte_Comision = CDec(0)
              End Try
              If CtaCte_Comision > CDec(0) Then
                Dim PrestamosCreditos_IdPrestamoCredito As Integer = DS_PrestamosComision.Tables(0).Rows(i).Item("Idprestamocredito")
                Dim PrestamosCreditos_Porcentaje As Decimal = DS_PrestamosComision.Tables(0).Rows(i).Item("Porcentaje")
                Dim PrestamosCreditos_Saldo As Decimal = DS_PrestamosComision.Tables(0).Rows(i).Item("Saldo")

                'dbo.CobroPrestamosCreditos.Importe = dbo.CtaCte.Comision * dbo.PrestamosCreditos.Porcentaje
                '(hay que revisar el saldo que le queda al prestamo dbo.PrestamosCreditos.Saldo ya que el cobro
                'no puede ser mayor al saldo que le queda al prestamo)
                Dim importe As Decimal = (CtaCte_Comision * PrestamosCreditos_Porcentaje) / 100
                Dim Estado_id As Integer = 1 '1 activo, 2 cancelado, 3 baja
                If importe > PrestamosCreditos_Saldo Then
                  importe = PrestamosCreditos_Saldo
                End If

                '/////////////////////////////////////////////////////////
                'AQUI GUARDO EN BD
                DaPrestamosCreditos.CobroPrestamosCreditos_alta(PrestamosCreditos_IdPrestamoCredito, HF_fecha.Value, importe)
                '/////////////////////////////////////////////////////////

                'Actualizar el saldo del prestamo dbo.PrestamosCreditos.Saldo = dbo.PrestamosCreditos.Saldo - dbo.CobroPrestamoCredito.Importe
                '(si el cobro del prestamo cancela el saldo es decir el total del prestamo se deberia marcar este prestamo como "Cancelado" dbo.PrestamosCreditos.Estado = C)
                PrestamosCreditos_Saldo = PrestamosCreditos_Saldo - importe
                If (PrestamosCreditos_Saldo = 0) Or (PrestamosCreditos_Saldo < 0) Then
                  PrestamosCreditos_Saldo = 0
                  'esta cancelado el prestamo
                  Estado_id = 2
                End If
                DaPrestamosCreditos.PrestamosCreditos_ActualizarSaldo(PrestamosCreditos_IdPrestamoCredito, PrestamosCreditos_Saldo, Estado_id)

                '--------------------------------------------------------------------------------------------------------------------------
                'Actualizar el campo dbo.CtaCte.CobPrestamo = dbo.CtaCte.CobPrestamo + dbo.CobroPrestamosCreditos.Importe
                Dim CobPrestamo As Decimal = 0
                Try 'el try lo uso x que el campo recuperado de ctacte es null
                  CobPrestamo = ds_ctacte.Tables(0).Rows(0).Item("CobPrestamo") + importe
                Catch ex As Exception
                  CobPrestamo = importe
                End Try

                'AQUI GUARDO EN BD
                DACtaCte.CtaCte_actualizarCobPrestamo(IdCtaCte, CobPrestamo)
                '--------------------------------------------------------------------------------------------------------------------------

                '--------------------------------------------------------------------------------------------------------------------------
                'Actualizar el saldo dbo.Clientes.Saldo = dbo.Clientes.Saldo + dbo.CtaCte.CobPrestamo
                DACliente.Cliente_ActualizarSaldo_ctacte(Cliente_ID, importe)
                '--------------------------------------------------------------------------------------------------------------------------


                'agrego 1 registro al datatable q voy a mandar al gridview.
                Dim fila As DataRow = DS_liqfinal.Tables("PrestamosComision").NewRow
                fila("Cliente") = CInt(Cliente_Codigo)
                Dim FechaPrestamo_Ori As Date = DS_PrestamosComision.Tables(0).Rows(i).Item("Fecha")
                fila("Fecha_Ori") = FechaPrestamo_Ori.ToString("dd-MM-yyyy")
                fila("Importe_Cob") = (Math.Round(importe, 2).ToString("N2"))
                fila("Saldo") = (Math.Round(PrestamosCreditos_Saldo, 2).ToString("N2"))
                Dim Prestamo As Decimal = DS_PrestamosComision.Tables(0).Rows(i).Item("Importe")
                fila("Prestamo") = (Math.Round(Prestamo, 2).ToString("N2"))
                DS_liqfinal.Tables("PrestamosComision").Rows.Add(fila)


              End If
            End If
          End If

          i = i + 1
        End While

      Else
        'no hay prestamosxcomision
      End If

      '------------------AQUIREPORTE ------------------------------------------------
      Dim fila_1 As DataRow = DS_liqfinal.Tables("PrestamosComision_info").NewRow
      fila_1("Fecha") = CDate(HF_fecha.Value)
      DS_liqfinal.Tables("PrestamosComision_info").Rows.Add(fila_1)
      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/LiquidacionFinal_informe03.rpt"))
      CrReport.Database.Tables("PrestamosComision").SetDataSource(DS_liqfinal.Tables("PrestamosComision"))
      CrReport.Database.Tables("PrestamosComision_info").SetDataSource(DS_liqfinal.Tables("PrestamosComision_info"))
      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/LiqFinal_CobPrestamosComision.pdf"))

      '------------------------------------------------------------------------------







      'ahora muestro DS_liqfinal.tables("PrestamosComision") en un gridview.

      GridView1.DataSource = DS_liqfinal.Tables("PrestamosComision")
      GridView1.DataBind()



      If GridView1.Rows.Count = 0 Then
        Label_noprestamos.Visible = True
      End If

      btn_continuar.Focus()
    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    'continuamos al form donde se consultara si hay prestamos x comision
    Session("fecha_parametro") = HF_fecha.Value
    Response.Redirect("~/WC_LiquidacionFinal/LiquidacionFinal_Creditos.aspx")
  End Sub
#End Region

#Region "METODOS"

#End Region



End Class
