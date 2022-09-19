Public Class Listados_SaldoRegalo
  Inherits System.Web.UI.Page

  Dim DApatrametro As New Capa_Datos.WC_parametro
  Dim DAListados As New Capa_Datos.Listados
  Dim DS_Listados As New DS_Listados
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      Dim ds_ultliq As DataSet = DApatrametro.Parametro_consultar_ultliq
      If ds_ultliq.Tables(0).Rows.Count <> 0 Then
        'hay ultima liquidacion
        Dim FECHA As Date = CDate(ds_ultliq.Tables(0).Rows(0).Item("Fecha"))
        HF_fecha.Value = FECHA

        LABEL_FECHA_actual.Text = Today.ToString("dd/MM/yyyy")
        LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")
        HF_fecha_actual.Value = CDate(Now)

        Dim ds_SaldosRegalos As DataSet = DAListados.SaldosyRegalos_obtener(HF_fecha.Value)
        If ds_SaldosRegalos.Tables(0).Rows.Count <> 0 Then
          generar_reporte(ds_SaldosRegalos)


          btn_continuar.Focus()
        Else
          'error, no hay liquidacion completada
          ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
        End If

      Else
        'mensaje
        'error, no hay liquidacion completada
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)

      End If


    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub generar_reporte(ByRef ds_SaldosRegalos As DataSet)
    DS_Listados.Tables("SaldoRegalo").Rows.Clear()


    Dim i As Integer = 0

    While i < ds_SaldosRegalos.Tables(0).Rows.Count
      Dim fila As DataRow = DS_Listados.Tables("SaldoRegalo").NewRow
      fila("Grupo") = CInt(ds_SaldosRegalos.Tables(0).Rows(i).Item("Grupo"))
      fila("Cliente") = CInt(ds_SaldosRegalos.Tables(0).Rows(i).Item("Cliente"))
      fila("Nombre") = ds_SaldosRegalos.Tables(0).Rows(i).Item("Nombre")
      fila("Saldo") = CDec(ds_SaldosRegalos.Tables(0).Rows(i).Item("Saldo"))
      If CDec(ds_SaldosRegalos.Tables(0).Rows(i).Item("Saldo")) > CDec(0) Then
        fila("Saldo_desc") = "DEBE"
      End If

      If CDec(ds_SaldosRegalos.Tables(0).Rows(i).Item("Saldo")) < CDec(0) Then
        fila("Saldo_desc") = "GANA"
      End If

      Dim Clie_saldoregalo As Decimal = CDec(ds_SaldosRegalos.Tables(0).Rows(i).Item("SaldoRegalo"))
      Dim Clie_regalo As Decimal = CDec(ds_SaldosRegalos.Tables(0).Rows(i).Item("Regalo"))
      Dim calculo_regalo As Decimal = 0
      If Clie_regalo <> 0 Then
        calculo_regalo = (100 * Clie_saldoregalo) / Clie_regalo
        calculo_regalo = (Math.Round(calculo_regalo, 2).ToString("N2"))
        fila("Regalo") = calculo_regalo
      End If

      If calculo_regalo > 0 Then
        fila("Regalo_desc") = "ATRAS"
      End If
      If calculo_regalo < 0 Then
        fila("Regalo_desc") = "COBRA"
      End If
      DS_Listados.Tables("SaldoRegalo").Rows.Add(fila)
      i = i + 1
    End While

    GridView1.DataSource = DS_Listados.Tables("SaldoRegalo")
    GridView1.DataBind()

    'GENERO EL REPORTE.

    Dim fila2 As DataRow = DS_Listados.Tables("SaldoRegalo_info").NewRow
    fila2("Fecha") = CDate(HF_fecha_actual.Value)
    fila2("Fecha_liq") = CDate(HF_fecha.Value)
    DS_Listados.Tables("SaldoRegalo_info").Rows.Add(fila2)
    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/ListadoSaldoRegalo_informe01.rpt"))
    CrReport.Database.Tables("SaldoRegalo_info").SetDataSource(DS_Listados.Tables("SaldoRegalo_info"))
    CrReport.Database.Tables("SaldoRegalo").SetDataSource(DS_Listados.Tables("SaldoRegalo"))

    CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/ListadoSaldoRegalo.pdf"))



    '////////////////////////////
    'voy a armar un nuevo datatable con los cortes de control.
    '1) copio estructura de datable 
    Dim SaldoRegalo2 As DataTable = DS_Listados.Tables("SaldoRegalo").Clone
    Dim itemAnterior As Integer = 0
    Dim j As Integer = 0
    Dim general_sum_saldo As Decimal = 0
    Dim general_sum_regalo As Decimal = 0
    While j < DS_Listados.Tables("SaldoRegalo").Rows.Count

      Dim e As Integer = SaldoRegalo2.Rows.Count

      Try
        general_sum_saldo = general_sum_saldo + CDec(DS_Listados.Tables("SaldoRegalo").Rows(j).Item("Saldo"))
      Catch ex As Exception

      End Try

      Try
        general_sum_regalo = general_sum_regalo + CDec(DS_Listados.Tables("SaldoRegalo").Rows(j).Item("Regalo"))
      Catch ex As Exception

      End Try




      If SaldoRegalo2.Rows.Count = 0 Then
        'inserto el primero.
        SaldoRegalo2.ImportRow(DS_Listados.Tables("SaldoRegalo").Rows(j))

      Else
        itemAnterior = CInt(SaldoRegalo2.Rows(SaldoRegalo2.Rows.Count - 1).Item("Grupo"))
        Dim itemActual As Integer = CInt(DS_Listados.Tables("SaldoRegalo").Rows(j).Item("Grupo"))
          If itemActual = itemAnterior Then
          SaldoRegalo2.ImportRow(DS_Listados.Tables("SaldoRegalo").Rows(j))
        Else
          'ingreso 2 filas. 1 con

          Dim sum_saldo As Decimal = 0
          Dim sum_regalo As Decimal = 0
          Dim jj As Integer = 0
          While jj < SaldoRegalo2.Rows.Count
            Try
              If itemAnterior = SaldoRegalo2.Rows(jj).Item("Grupo") Then
                Try
                  sum_saldo = sum_saldo + CDec(SaldoRegalo2.Rows(jj).Item("Saldo"))
                Catch ex As Exception

                End Try
                Try
                  sum_regalo = sum_regalo + CDec(SaldoRegalo2.Rows(jj).Item("Regalo"))
                Catch ex As Exception

                End Try



              End If
            Catch ex As Exception

            End Try

            jj = jj + 1
          End While
          Dim fila_s As DataRow = SaldoRegalo2.NewRow
          fila_s("Nombre") = "TOTAL SALDO GRUPO " + CStr(itemAnterior) + ":"
          fila_s("Saldo") = (Math.Round(sum_saldo, 2).ToString("N2"))
          SaldoRegalo2.Rows.Add(fila_s)
          Dim fila_r As DataRow = SaldoRegalo2.NewRow
          fila_r("Nombre") = "TOTAL REGALO GRUPO " + CStr(itemAnterior) + ":"
          fila_r("Saldo") = (Math.Round(sum_regalo, 2).ToString("N2"))
          SaldoRegalo2.Rows.Add(fila_r)
          'ahora agrego el registro "actual" de DS_Listados.tables("SaldoRegalo") en SaldoRegalo2
          SaldoRegalo2.ImportRow(DS_Listados.Tables("SaldoRegalo").Rows(j))
        End If
      End If
      j = j + 1
    End While



    'ingreso 2 filas. 1 con los cortes de control para el ultimo grupo
    itemAnterior = CInt(SaldoRegalo2.Rows(SaldoRegalo2.Rows.Count - 1).Item("Grupo"))
    Dim sum_saldo1 As Decimal = 0
    Dim sum_regalo1 As Decimal = 0
    Dim k As Integer = 0
    While k < SaldoRegalo2.Rows.Count
      Try
        If itemAnterior = SaldoRegalo2.Rows(k).Item("Grupo") Then
          Try
            sum_saldo1 = sum_saldo1 + CDec(SaldoRegalo2.Rows(k).Item("Saldo"))
          Catch ex As Exception

          End Try
          Try
            sum_regalo1 = sum_regalo1 + CDec(SaldoRegalo2.Rows(k).Item("Regalo"))
          Catch ex As Exception

          End Try

        End If
      Catch ex As Exception

      End Try


      k = k + 1
    End While
    Dim fila_ss As DataRow = SaldoRegalo2.NewRow
    fila_ss("Nombre") = "TOTAL SALDO GRUPO " + CStr(itemAnterior) + ":"
    fila_ss("Saldo") = (Math.Round(sum_saldo1, 2).ToString("N2"))
    SaldoRegalo2.Rows.Add(fila_ss)
    Dim fila_rr As DataRow = SaldoRegalo2.NewRow
    fila_rr("Nombre") = "TOTAL REGALO GRUPO " + CStr(itemAnterior) + ":"
    fila_rr("Saldo") = (Math.Round(sum_regalo1, 2).ToString("N2"))
    SaldoRegalo2.Rows.Add(fila_rr)

    'ahora las 2 ultimas filas que tienen la sumatoria final del informe.
    Dim fila_gs As DataRow = SaldoRegalo2.NewRow
    fila_gs("Nombre") = "TOTAL SALDOS GENERALES:"
    fila_gs("Saldo") = (Math.Round(general_sum_saldo, 2).ToString("N2"))
    SaldoRegalo2.Rows.Add(fila_gs)
    Dim fila_gr As DataRow = SaldoRegalo2.NewRow
    fila_gr("Nombre") = "TOTAL REGALOS GENERALES:"
    fila_gr("Saldo") = (Math.Round(general_sum_regalo, 2).ToString("N2"))
    SaldoRegalo2.Rows.Add(fila_gr)

    GridView1.DataSource = SaldoRegalo2
    GridView1.DataBind()



  End Sub


End Class
