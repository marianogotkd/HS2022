Public Class TicketsGeneral
  Inherits System.Web.UI.Page

  Dim DAtickets As New Capa_Datos.WC_tickets

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      Txt_FechaDesde.Focus()

    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub Txt_FechaDesde_Init(sender As Object, e As EventArgs) Handles Txt_FechaDesde.Init
    Txt_FechaDesde.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_FechaHasta_Init(sender As Object, e As EventArgs) Handles Txt_FechaHasta.Init
    Txt_FechaHasta.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_Boleta_Init(sender As Object, e As EventArgs) Handles Txt_Boleta.Init
    Txt_Boleta.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_GrupoCodigo_Init(sender As Object, e As EventArgs) Handles Txt_GrupoCodigo.Init
    Txt_GrupoCodigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_ClienteCod_Init(sender As Object, e As EventArgs) Handles Txt_ClienteCod.Init
    Txt_ClienteCod.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub BOTON_GRABA_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABA.ServerClick

    Dim valido = "si"
    Try
      Txt_FechaDesde.Text = CDate(Txt_FechaDesde.Text)
      Dim fecha_base As Date = CDate("01/01/1900")
      If Txt_FechaDesde.Text < fecha_base Then
        valido = "no"
      End If
    Catch ex As Exception
      valido = "no"
    End Try

    Try
      Txt_FechaHasta.Text = CDate(Txt_FechaHasta.Text)

    Catch ex As Exception
      valido = "no"
    End Try


    If valido = "si" Then 'si hasta etapa estan bien las fechas, ahora controlo que el intervalo de fechas sea correcto
      If CDate(Txt_FechaHasta.Text) < CDate(Txt_FechaDesde.Text) Then
        valido = "no"
      End If
    End If


    If (Txt_Boleta.Text.ToUpper = "SI") Or (Txt_Boleta.Text.ToUpper = "NO") Then

    Else
      valido = "no"
    End If

    'puedo ingresar solo el grupo o bien solo el cliente....si ingreso cod de cliente, anulo la busqueda por grupo.


    If valido = "si" Then

      If (Txt_GrupoCodigo.Text = "999") And (Txt_ClienteCod.Text = "") Then

        If Txt_Boleta.Text.ToUpper = "SI" Then
          GENERAR_REPORTE()
        Else
          GENERAR_REPORTE2() 'NO TENGO EN CUENTA BOLETA
        End If
      Else
        If Txt_ClienteCod.Text <> "" Then
          If Txt_Boleta.Text.ToUpper = "SI" Then
            GENERAR_REPORTE5()
          Else
            generar_reporte6() 'NO TENGO EN CUENTA BOLETA
          End If
        Else
          'entonces es 1 solo codigo
          If Txt_Boleta.Text.ToUpper = "SI" Then
            GENERAR_REPORTE3()
          Else
            GENERAR_REPORTE4() 'NO TENGO EN CUENTA BOLETA
          End If
        End If
      End If




    Else

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error2", "$(document).ready(function () {$('#modal-ok_error2').modal();});", True)

      'ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    End If




  End Sub


  Private Sub GENERAR_REPORTE()
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener1(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text))

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")

        fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral").Rows.Add(fila)

        'ahora si hay mas registros para el mismo cliente, se suma sus valores en cada campo.
        Dim Cliente As Integer = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        Dim j = i + 1
        While j < DS_CTA.Tables(0).Rows.Count

          If Cliente = CInt(DS_CTA.Tables(0).Rows(j).Item("Cliente_codigo")) Then
            Dim indice As Integer = DS_ticketsclientes.Tables("TicketGeneral").Rows.Count - 1
            Try
              Dim Recaudacion As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") + DS_CTA.Tables(0).Rows(j).Item("Recaudacion")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") = (Math.Round(Recaudacion, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim Comision As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") + DS_CTA.Tables(0).Rows(j).Item("Comision")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") = (Math.Round(Comision, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Premios As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") + DS_CTA.Tables(0).Rows(j).Item("Premios")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") = (Math.Round(Premios, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Reclamos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") + DS_CTA.Tables(0).Rows(j).Item("Reclamos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") = (Math.Round(Reclamos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Regalos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") + DS_CTA.Tables(0).Rows(j).Item("Regalos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") = (Math.Round(Regalos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGano As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") = (Math.Round(DejoGano, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////SIN CALCULO/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") = (Math.Round(RecaudacionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") + DS_CTA.Tables(0).Rows(j).Item("ComisionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") = (Math.Round(ComisionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") + DS_CTA.Tables(0).Rows(j).Item("PremiosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") = (Math.Round(PremiosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") + DS_CTA.Tables(0).Rows(j).Item("ReclamosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") = (Math.Round(ReclamosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") = (Math.Round(DejoGanoSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////////BOLETA/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionB") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionB") = (Math.Round(RecaudacionB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionB") + DS_CTA.Tables(0).Rows(j).Item("ComisionB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionB") = (Math.Round(ComisionB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosB") + DS_CTA.Tables(0).Rows(j).Item("PremiosB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosB") = (Math.Round(PremiosB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosB") + DS_CTA.Tables(0).Rows(j).Item("ReclamosB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosB") = (Math.Round(ReclamosB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoB") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoB") = (Math.Round(DejoGanoB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try




          Else
            i = j - 1 'RETROCEDO 1 PARA QUE EL INDICE APUNTE AL PROXIMO NO REPETIDO.(UNA VER EJECUTADO I=I+1)
            Exit While
          End If

          j = j + 1
        End While

        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe01a.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub GENERAR_REPORTE2() 'NO TENGO EN CUENTA BOLETA
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener1(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text))

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")

        'fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        'fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        'fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        'fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        'fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral").Rows.Add(fila)

        'ahora si hay mas registros para el mismo cliente, se suma sus valores en cada campo.
        Dim Cliente As Integer = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        Dim j = i + 1
        While j < DS_CTA.Tables(0).Rows.Count

          If Cliente = CInt(DS_CTA.Tables(0).Rows(j).Item("Cliente_codigo")) Then
            Dim indice As Integer = DS_ticketsclientes.Tables("TicketGeneral").Rows.Count - 1
            Try
              Dim Recaudacion As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") + DS_CTA.Tables(0).Rows(j).Item("Recaudacion")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") = (Math.Round(Recaudacion, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Comision As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") + DS_CTA.Tables(0).Rows(j).Item("Comision")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") = (Math.Round(Comision, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Premios As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") + DS_CTA.Tables(0).Rows(j).Item("Premios")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") = (Math.Round(Premios, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Reclamos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") + DS_CTA.Tables(0).Rows(j).Item("Reclamos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") = (Math.Round(Reclamos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Regalos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") + DS_CTA.Tables(0).Rows(j).Item("Regalos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") = (Math.Round(Regalos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGano As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") = (Math.Round(DejoGano, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////SIN CALCULO/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") = (Math.Round(RecaudacionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") + DS_CTA.Tables(0).Rows(j).Item("ComisionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") = (Math.Round(ComisionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") + DS_CTA.Tables(0).Rows(j).Item("PremiosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") = (Math.Round(PremiosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") + DS_CTA.Tables(0).Rows(j).Item("ReclamosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") = (Math.Round(ReclamosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") = (Math.Round(DejoGanoSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try

            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try

          Else
            i = j - 1 'RETROCEDO 1 PARA QUE EL INDICE APUNTE AL PROXIMO NO REPETIDO.(UNA VER EJECUTADO I=I+1)
            Exit While
          End If

          j = j + 1
        End While

        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe02.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub GENERAR_REPORTE3() 'trae solo 1 grupo y considera boletas
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener1_grupo(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text), Txt_GrupoCodigo.Text)

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")

        fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral").Rows.Add(fila)

        'ahora si hay mas registros para el mismo cliente, se suma sus valores en cada campo.
        Dim Cliente As Integer = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        Dim j = i + 1
        While j < DS_CTA.Tables(0).Rows.Count

          If Cliente = CInt(DS_CTA.Tables(0).Rows(j).Item("Cliente_codigo")) Then
            Dim indice As Integer = DS_ticketsclientes.Tables("TicketGeneral").Rows.Count - 1
            Try
              Dim Recaudacion As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") + DS_CTA.Tables(0).Rows(j).Item("Recaudacion")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") = (Math.Round(Recaudacion, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Comision As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") + DS_CTA.Tables(0).Rows(j).Item("Comision")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") = (Math.Round(Comision, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Premios As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") + DS_CTA.Tables(0).Rows(j).Item("Premios")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") = (Math.Round(Premios, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Reclamos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") + DS_CTA.Tables(0).Rows(j).Item("Reclamos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") = (Math.Round(Reclamos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Regalos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") + DS_CTA.Tables(0).Rows(j).Item("Regalos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") = (Math.Round(Regalos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGano As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") = (Math.Round(DejoGano, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////SIN CALCULO/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") = (Math.Round(RecaudacionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") + DS_CTA.Tables(0).Rows(j).Item("ComisionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") = (Math.Round(ComisionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") + DS_CTA.Tables(0).Rows(j).Item("PremiosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") = (Math.Round(PremiosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") + DS_CTA.Tables(0).Rows(j).Item("ReclamosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") = (Math.Round(ReclamosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") = (Math.Round(DejoGanoSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////////BOLETA/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionB") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionB") = (Math.Round(RecaudacionB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionB") + DS_CTA.Tables(0).Rows(j).Item("ComisionB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionB") = (Math.Round(ComisionB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosB") + DS_CTA.Tables(0).Rows(j).Item("PremiosB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosB") = (Math.Round(PremiosB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosB") + DS_CTA.Tables(0).Rows(j).Item("ReclamosB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosB") = (Math.Round(ReclamosB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoB As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoB") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoB") = (Math.Round(DejoGanoB, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoB")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
          Else
            i = j - 1 'RETROCEDO 1 PARA QUE EL INDICE APUNTE AL PROXIMO NO REPETIDO.(UNA VER EJECUTADO I=I+1)
            Exit While
          End If

          j = j + 1
        End While

        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe01a.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub GENERAR_REPORTE4() '1 SOLO GRUPO, PERO SIN BOLETAS
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener1_grupo(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text), Txt_GrupoCodigo.Text)

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")

        'fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        'fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        'fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        'fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        'fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral").Rows.Add(fila)

        'ahora si hay mas registros para el mismo cliente, se suma sus valores en cada campo.
        Dim Cliente As Integer = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        Dim j = i + 1
        While j < DS_CTA.Tables(0).Rows.Count

          If Cliente = CInt(DS_CTA.Tables(0).Rows(j).Item("Cliente_codigo")) Then
            Dim indice As Integer = DS_ticketsclientes.Tables("TicketGeneral").Rows.Count - 1
            Try
              Dim Recaudacion As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") + DS_CTA.Tables(0).Rows(j).Item("Recaudacion")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Recaudacion") = (Math.Round(Recaudacion, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Comision As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") + DS_CTA.Tables(0).Rows(j).Item("Comision")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Comision") = (Math.Round(Comision, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Premios As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") + DS_CTA.Tables(0).Rows(j).Item("Premios")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Premios") = (Math.Round(Premios, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Reclamos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") + DS_CTA.Tables(0).Rows(j).Item("Reclamos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Reclamos") = (Math.Round(Reclamos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim Regalos As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") + DS_CTA.Tables(0).Rows(j).Item("Regalos")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("Regalos") = (Math.Round(Regalos, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGano As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGano") = (Math.Round(DejoGano, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            '/////////////////////////////////SIN CALCULO/////////////////////////////////////////////////////////////////
            Try
              Dim RecaudacionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") + DS_CTA.Tables(0).Rows(j).Item("RecaudacionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("RecaudacionSC") = (Math.Round(RecaudacionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ComisionSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") + DS_CTA.Tables(0).Rows(j).Item("ComisionSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ComisionSC") = (Math.Round(ComisionSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim PremiosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") + DS_CTA.Tables(0).Rows(j).Item("PremiosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("PremiosSC") = (Math.Round(PremiosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim ReclamosSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") + DS_CTA.Tables(0).Rows(j).Item("ReclamosSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("ReclamosSC") = (Math.Round(ReclamosSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try
            Try
              Dim DejoGanoSC As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("DejoGanoSC") = (Math.Round(DejoGanoSC, 2).ToString("N2"))
            Catch ex As Exception
            End Try

            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGano")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try
            Try
              Dim totalDG As Decimal = DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") + DS_CTA.Tables(0).Rows(j).Item("DejoGanoSC")
              DS_ticketsclientes.Tables("TicketGeneral").Rows(indice).Item("TotalDejoGano") = (Math.Round(totalDG, 2).ToString("N2"))
            Catch ex As Exception

            End Try

          Else
            i = j - 1 'RETROCEDO 1 PARA QUE EL INDICE APUNTE AL PROXIMO NO REPETIDO.(UNA VER EJECUTADO I=I+1)
            Exit While
          End If

          j = j + 1
        End While

        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe02.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub GENERAR_REPORTE5() 'BUSCA 1 CLIENTE, CONSIDERANDO BOLETAS
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener2(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text), CInt(Txt_ClienteCod.Text))

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral1").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")

        fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        fila("Fecha") = DS_CTA.Tables(0).Rows(i).Item("Fecha")

        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral1").Rows.Add(fila)



        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe03.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral1").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral1"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub generar_reporte6() '1 solo cliente, sin boletas
    Dim DS_ticketsclientes As New DS_ticketsclientes
    Dim DS_CTA As DataSet = DAtickets.TicketGeneral_obtener2(CDate(Txt_FechaDesde.Text), CDate(Txt_FechaHasta.Text), CInt(Txt_ClienteCod.Text))

    If DS_CTA.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < DS_CTA.Tables(0).Rows.Count
        Dim fila As DataRow = DS_ticketsclientes.Tables("TicketGeneral1").NewRow
        fila("Grupo") = CInt(DS_CTA.Tables(0).Rows(i).Item("Grupo_codigo"))
        fila("Cliente") = CInt(DS_CTA.Tables(0).Rows(i).Item("Cliente_codigo"))
        fila("Recaudacion") = DS_CTA.Tables(0).Rows(i).Item("Recaudacion")
        fila("Comision") = DS_CTA.Tables(0).Rows(i).Item("Comision")
        fila("Premios") = DS_CTA.Tables(0).Rows(i).Item("Premios")
        fila("Reclamos") = DS_CTA.Tables(0).Rows(i).Item("Reclamos")
        fila("DejoGano") = DS_CTA.Tables(0).Rows(i).Item("DejoGano")

        fila("RecaudacionSC") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionSC")
        fila("ComisionSC") = DS_CTA.Tables(0).Rows(i).Item("ComisionSC")
        fila("PremiosSC") = DS_CTA.Tables(0).Rows(i).Item("PremiosSC")
        fila("ReclamosSC") = DS_CTA.Tables(0).Rows(i).Item("ReclamosSC")
        fila("DejoGanoSC") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")
        fila("Fecha") = DS_CTA.Tables(0).Rows(i).Item("Fecha")
        'fila("RecaudacionB") = DS_CTA.Tables(0).Rows(i).Item("RecaudacionB")
        'fila("ComisionB") = DS_CTA.Tables(0).Rows(i).Item("ComisionB")
        'fila("PremiosB") = DS_CTA.Tables(0).Rows(i).Item("PremiosB")
        'fila("ReclamosB") = DS_CTA.Tables(0).Rows(i).Item("ReclamosB")
        'fila("DejoGanoB") = DS_CTA.Tables(0).Rows(i).Item("DejoGanoB")
        Dim totaldejogano As Decimal = 0
        Try
          totaldejogano = DS_CTA.Tables(0).Rows(i).Item("DejoGano") + DS_CTA.Tables(0).Rows(i).Item("DejoGanoSC")
        Catch ex As Exception

        End Try
        fila("TotalDejoGano") = (Math.Round(totaldejogano, 2).ToString("N2"))

        DS_ticketsclientes.Tables("TicketGeneral1").Rows.Add(fila)

        i = i + 1
      End While

      'GENERO EL REPORTE.
      Dim fila2 As DataRow = DS_ticketsclientes.Tables("TicketGeneral_info").NewRow
      fila2("Fecha") = CDate(Now)
      fila2("Fecha_desde") = CDate(Txt_FechaDesde.Text)
      fila2("Fecha_hasta") = CDate(Txt_FechaHasta.Text)
      DS_ticketsclientes.Tables("TicketGeneral_info").Rows.Add(fila2)


      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketGeneral_informe04.rpt"))
      CrReport.Database.Tables("TicketGeneral_info").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral_info"))
      CrReport.Database.Tables("TicketGeneral1").SetDataSource(DS_ticketsclientes.Tables("TicketGeneral1"))

      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketGeneral.pdf"))

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    Else
      'AQUI MSJ ERROR...LA BUSQUEDA NO ARROJO RESULTADOS

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)
    End If

  End Sub

  Private Sub btn_error_close2_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close2.ServerClick
    Txt_FechaDesde.Focus()
  End Sub

  Private Sub btn_ok_error2_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error2.ServerClick
    Txt_FechaDesde.Focus()
  End Sub

  Private Sub btn_ok_error3_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error3.ServerClick
    Txt_FechaDesde.Focus()
  End Sub

  Private Sub btn_error_close3_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close3.ServerClick
    Txt_FechaDesde.Focus()
  End Sub
End Class
