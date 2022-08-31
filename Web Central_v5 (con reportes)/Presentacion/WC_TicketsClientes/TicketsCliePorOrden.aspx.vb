Public Class TicketsCliePorOrden
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DAtickets As New Capa_Datos.WC_tickets
#End Region

#Region "EVENTOS"

#End Region


  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      'VALIDACION: Verificar en BD cual es el dia de la ultima liquidacion en tabla PARAMETRO, donde el campo Estado= "Inactivo"
      Dim ds_parametro As DataSet = DAparametro.Parametro_consultar_ultliq
      If ds_parametro.Tables(0).Rows.Count <> 0 Then

        '/////FECHA DE ULTIMA LIQUIDACION
        HF_parametro_id.Value = ds_parametro.Tables(0).Rows(0).Item("Parametro_id")
        HF_fecha.Value = ds_parametro.Tables(0).Rows(0).Item("Fecha")
        Dim FECHA As Date = CDate(ds_parametro.Tables(0).Rows(0).Item("Fecha"))
        Label_fecha.Text = FECHA.ToString("dd-MM-yyyy")

        '////DIA DE LA LIQUIDACION
        'aqui va un case dependiendo el nro de dia
        Dim Dia As Integer = CInt(ds_parametro.Tables(0).Rows(0).Item("Dia"))
        HF_dia_id.Value = CInt(ds_parametro.Tables(0).Rows(0).Item("Dia"))

        Select Case Dia
          Case 1 'Domingo
            Label_dia.Text = "DOMINGO"
          Case 2 'Lunes
            Label_dia.Text = "LUNES"
          Case 3 'Martes
            Label_dia.Text = "MARTES"
          Case 4 'Miercoles
            Label_dia.Text = "MIERCOLES"
          Case 5 'Jueves
            Label_dia.Text = "JUEVES"
          Case 6 'Viernes
            Label_dia.Text = "VIERNES"
          Case 7 'Sabado
            Label_dia.Text = "SABADO"
        End Select

        Txt_DesdeGrupoCodigo.Focus()


      Else
        'error, no hay liquidacion completada
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If
    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
  End Sub

  Private Sub btn_error_close_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub Txt_DesdeGrupoCodigo_Init(sender As Object, e As EventArgs) Handles Txt_DesdeGrupoCodigo.Init
    Txt_DesdeGrupoCodigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_DesdeClienteCod_Init(sender As Object, e As EventArgs) Handles Txt_DesdeClienteCod.Init
    Txt_DesdeClienteCod.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_HastaGrupoCodigo_Init(sender As Object, e As EventArgs) Handles Txt_HastaGrupoCodigo.Init
    Txt_HastaGrupoCodigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_HastaClienteCod_Init(sender As Object, e As EventArgs) Handles Txt_HastaClienteCod.Init
    Txt_HastaClienteCod.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub Txt_msjgeneral_Init(sender As Object, e As EventArgs) Handles Txt_msjgeneral.Init
    Txt_msjgeneral.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub


  Private Sub Colocar_zona(ByRef Codigo As String, ByRef DS_ticketsclientes As DataSet, ByVal registro As Integer, ByVal item_nomb As String)
    Select Case Codigo
      Case "1A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON1"
      Case "1B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON2"
      Case "1C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON3"
      Case "1D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON4"
      Case "1E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON5"
      Case "1F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON6"
      Case "1G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON7"
      Case "1H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON8"
      Case "1I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON9"
      Case "1J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO10"
      Case "2A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO11"
      Case "2B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO12"
      Case "2C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO13"
      Case "2D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO14"
      Case "2E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO15"
      Case "2F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO16"
      Case "2G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO17"
      Case "2H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO18"
      Case "2I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO19"
      Case "2J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO20"
      Case "3A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO21"
      Case "3B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO22"
      Case "3C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO23"
      Case "3D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO24"
      Case "3E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO25"
      Case "3F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO26"
      Case "3G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO27"
      Case "3H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO28"
      Case "3I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO29"
      Case "3J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO30"
      Case "4A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO31"
      Case "4B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO32"
      Case "4C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO33"
      Case "4D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO34"
      Case "4E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO35"
      Case "4F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO36"
      Case "4G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO37"
      Case "4H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO38"
      Case "4I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO39"
      Case "4J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO40"
      Case "5A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO41"
      Case "5B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO42"
      Case "5C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO43"
      Case "5D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO44"
      Case "5E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO45"
      Case "5F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO46"
      Case "5G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO47"
      Case "5H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO48"
      Case "5I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO49"
      Case "5J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO50"
    End Select
  End Sub


  Private Sub RecuperoZona_part1(ByVal r As Integer, ByVal Codigo As String, ByRef Zona As String, ByRef DS_ticketsclientes As DataSet)
    Select Case r
      Case 0
        Zona = "ZON1" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON1")
      Case 1
        Zona = "ZON2" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON2")
      Case 2
        Zona = "ZON3" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON3")
      Case 3
        Zona = "ZON4" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON4")
      Case 4
        Zona = "ZON5" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON5")
      Case 5
        Zona = "ZON6" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON6")
      Case 6
        Zona = "ZON7" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON7")
      Case 7
        Zona = "ZON8" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON8")
      Case 8
        Zona = "ZON9" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON9")
      Case 9
        Zona = "ZO10" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO10")
      Case 10
        Zona = "ZO11" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO11")
      Case 11
        Zona = "ZO12" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO12")
      Case 12
        Zona = "ZO13" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO13")
      Case 13
        Zona = "ZO14" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO14")
      Case 14
        Zona = "ZO15" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO15")
      Case 15
        Zona = "ZO16" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO16")
      Case 16
        Zona = "ZO17" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO17")
      Case 17
        Zona = "ZO18" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO18")
      Case 18
        Zona = "ZO19" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO19")
      Case 19
        Zona = "ZO20" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO20")
      Case 20
        Zona = "ZO21" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO21")
      Case 21
        Zona = "ZO22" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO22")
      Case 22
        Zona = "ZO23" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO23")
      Case 23
        Zona = "ZO24" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO24")
      Case 24
        Zona = "ZO25" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO25")
      Case 25
        Zona = "ZON1"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON1")
      Case 26
        Zona = "ZON2"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON2")
      Case 27
        Zona = "ZON3"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON3")
      Case 28
        Zona = "ZON4"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON4")
      Case 29
        Zona = "ZON5"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON5")
      Case 30
        Zona = "ZON6"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON6")
      Case 31
        Zona = "ZON7"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON7")
      Case 32
        Zona = "ZON8"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON8")
      Case 33
        Zona = "ZON9"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON9")
      Case 34
        Zona = "ZO10"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO10")
      Case 35
        Zona = "ZO11"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO11")
      Case 36
        Zona = "ZO12"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO12")
      Case 37
        Zona = "ZO13"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO13")
      Case 38
        Zona = "ZO14"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO14")
      Case 39
        Zona = "ZO15"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO15")
      Case 40
        Zona = "ZO16"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO16")
      Case 41
        Zona = "ZO17"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO17")
      Case 42
        Zona = "ZO18"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO18")
      Case 43
        Zona = "ZO19"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO19")
      Case 44
        Zona = "ZO20"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO20")
      Case 45
        Zona = "ZO21"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO21")
      Case 46
        Zona = "ZO22"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO22")
      Case 47
        Zona = "ZO23"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO23")
      Case 48
        Zona = "ZO24"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO24")
      Case 49
        Zona = "ZO25"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO25")

    End Select



  End Sub

  Private Sub NUEVO_GUARDAR_PRUEBA()
    'valido que todos los campos tengas algo ingresado.

    Dim valido As String = "si"

    Try
      Txt_DesdeGrupoCodigo.Text = CInt(Txt_DesdeGrupoCodigo.Text)
    Catch ex As Exception
      valido = "no"
    End Try

    Try
      Txt_DesdeClienteCod.Text = CInt(Txt_DesdeClienteCod.Text)
    Catch ex As Exception
      valido = "no"
    End Try

    Try
      Txt_HastaGrupoCodigo.Text = CInt(Txt_HastaGrupoCodigo.Text)
    Catch ex As Exception
      valido = "no"
    End Try

    Try
      Txt_HastaClienteCod.Text = CInt(Txt_HastaClienteCod.Text)
    Catch ex As Exception
      valido = "no"
    End Try

    If valido = "si" Then
      'recupero todos los puntos y recorridos para la fecha indicada.

      Dim DS_ticketsclientes As New DS_ticketsclientes

#Region "TABLA DE PUNTOS"
      Dim ds_puntos As DataSet = DAtickets.RecorridosPuntos_obtener_fecha(CDate(HF_fecha.Value))
      If ds_puntos.Tables(0).Rows.Count <> 0 Then



        DS_ticketsclientes.Tables("Puntos_A").Rows.Add() 'PRIMERO 1 FILA DONDE VAN A IR LOS ENCABEZADOS DE ZONAS (ZON1, ZON2, ZON3)

        Dim i As Integer = 0
        While i < 20
          Dim Fila As DataRow = DS_ticketsclientes.Tables("Puntos_A").NewRow
          Fila("ITEM") = CStr(i + 1)
          Fila("Fecha") = CDate(HF_fecha.Value)
          DS_ticketsclientes.Tables("Puntos_A").Rows.Add(Fila)
          i = i + 1
        End While

        If ds_puntos.Tables(0).Rows.Count > 24 Then
          DS_ticketsclientes.Tables("Puntos_A").Rows.Add() 'fila en blanco.
          DS_ticketsclientes.Tables("Puntos_A").Rows.Add() 'fila en blanco.--AQUI LUEGO SE CARGAN LOS ENCABEZADOS
          Dim j As Integer = 0
          While j < 20
            Dim Fila As DataRow = DS_ticketsclientes.Tables("Puntos_A").NewRow
            Fila("ITEM") = CStr(j + 1)
            Fila("Fecha") = CDate(HF_fecha.Value)
            DS_ticketsclientes.Tables("Puntos_A").Rows.Add(Fila)
            j = j + 1
          End While
        End If

        Dim r As Integer = 0
          Dim ContZonas As Integer = 0
          While r < ds_puntos.Tables(0).Rows.Count
            Dim Codigo As String = CStr(ds_puntos.Tables(0).Rows(r).Item("Codigo"))
            If ContZonas < 25 Then
              Dim Zona As String = ""
              RecuperoZona_part1(r, Codigo, Zona, DS_ticketsclientes)
              CARGA_1(DS_ticketsclientes, ds_puntos, Zona, 1, r)
            Else
              If ContZonas < 50 Then
              Dim Zona As String = ""
              RecuperoZona_part1(r, Codigo, Zona, DS_ticketsclientes)
                CARGA_1(DS_ticketsclientes, ds_puntos, Zona, 23, r)
              End If
            End If
            ContZonas = ContZonas + 1
            r = r + 1
          End While

        End If



#End Region



      Dim ds_ctacte As DataSet = DAtickets.CtaCte_MovimientosBuscar(CDate(HF_fecha.Value), CInt(Txt_DesdeGrupoCodigo.Text), CInt(Txt_DesdeClienteCod.Text), CInt(Txt_HastaGrupoCodigo.Text), CInt(Txt_HastaClienteCod.Text))

      If ds_ctacte.Tables(0).Rows.Count <> 0 Then

        'vamos a cargar la info de la cta cta y premios para cada cliente.

        Dim indice As Integer = 0
        While indice < ds_ctacte.Tables(0).Rows.Count

          Dim fila As DataRow = DS_ticketsclientes.Tables("Cliente_CtacteInfo").NewRow
          fila("Grupo_id") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Grupo_id"))
          fila("Grupo_codigo") = ds_ctacte.Tables(0).Rows(indice).Item("Grupo_codigo")
          fila("Grupo_nombre") = ds_ctacte.Tables(0).Rows(indice).Item("Grupo_nombre")
          fila("Cliente") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente"))
          fila("Cliente_codigo") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente_codigo"))
          fila("Cliente_nombre") = ds_ctacte.Tables(0).Rows(indice).Item("Cliente_Nombre")
          fila("R") = ds_ctacte.Tables(0).Rows(indice).Item("R")
          fila("O") = ds_ctacte.Tables(0).Rows(indice).Item("O")
          fila("Recaudacion") = ds_ctacte.Tables(0).Rows(indice).Item("Recaudacion")
          fila("Comision") = ds_ctacte.Tables(0).Rows(indice).Item("Comision")
          fila("Premios") = ds_ctacte.Tables(0).Rows(indice).Item("Premios")
          fila("Reclamos") = ds_ctacte.Tables(0).Rows(indice).Item("Reclamos")
          fila("DejoGano") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")
          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")) > 0 Then
            fila("DejoGano_desc") = "DEJO:"
          Else
            fila("DejoGano_desc") = "GANO:"
          End If
          fila("RecaudacionSC") = ds_ctacte.Tables(0).Rows(indice).Item("RecaudacionSC")
          fila("ComisionSC") = ds_ctacte.Tables(0).Rows(indice).Item("ComisionSC")
          fila("PremiosSC") = ds_ctacte.Tables(0).Rows(indice).Item("PremiosSC")
          fila("ReclamosSC") = ds_ctacte.Tables(0).Rows(indice).Item("ReclamosSC")
          fila("DejoGanoSC") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC")
          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC")) > 0 Then
            fila("DejoGanoSC_desc") = "DEJO:"
          Else
            fila("DejoGanoSC_desc") = "GANO:"
          End If
          Dim DejoGano_sum As Decimal = CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")) + CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC"))
          fila("DejoGanoGeneral") = DejoGano_sum
          If DejoGano_sum > 0 Then
            fila("DejoGanoGeneral_desc") = "GENERAL DEJO:"
          Else
            fila("DejoGanoGeneral_desc") = "GENERAL GANO:"
          End If
          fila("RecaudacionB") = ds_ctacte.Tables(0).Rows(indice).Item("RecaudacionB")
          fila("ComisionB") = ds_ctacte.Tables(0).Rows(indice).Item("ComisionB")
          fila("PremiosB") = ds_ctacte.Tables(0).Rows(indice).Item("PremiosB")
          fila("ReclamosB") = ds_ctacte.Tables(0).Rows(indice).Item("ReclamosB")
          fila("DejoGanoB") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB")
          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB")) > 0 Then
            fila("DejoGanoB_desc") = "DEJO:"
          Else
            fila("DejoGanoB_desc") = "GANO:"
          End If
          DejoGano_sum = DejoGano_sum + CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB"))
          fila("DejoGanoGeneralDia") = DejoGano_sum
          If DejoGano_sum > 0 Then
            fila("DejoGanoGeneralDia_desc") = "GENERAL DEL DIA DEJO:"
          Else
            fila("DejoGanoGeneralDia_desc") = "GENERAL DEL DIA GANO:"
          End If
          fila("Saldoanterior") = ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Saldoanterior")
          fila("Cobros") = ds_ctacte.Tables(0).Rows(indice).Item("Cobros") 'PAGO
          fila("Regalos") = ds_ctacte.Tables(0).Rows(indice).Item("Regalos") 'PAGO REGALO
          fila("Pagos") = ds_ctacte.Tables(0).Rows(indice).Item("Pagos") 'DI
          fila("Prestamo") = ds_ctacte.Tables(0).Rows(indice).Item("Prestamo") 'ENTREGA DE PRESTAMO
          fila("CobPrestamo") = ds_ctacte.Tables(0).Rows(indice).Item("CobPrestamo") 'DEVOLUCION PRESTAMO
          fila("Credito") = ds_ctacte.Tables(0).Rows(indice).Item("Credito") 'ENTREGA DE CREDITO
          fila("CobCredito") = ds_ctacte.Tables(0).Rows(indice).Item("CobCredito")

          Dim ds_credi As DataSet = DAtickets.CobroCreditos_ClienteObtener(CDate(HF_fecha.Value), CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente")))
          If ds_credi.Tables(0).Rows.Count <> 0 Then
            Dim nro_cta As Integer = CInt(ds_credi.Tables(0).Rows(0).Item("Cuota"))
            Dim dias As Integer = CInt(ds_credi.Tables(0).Rows(0).Item("Dias"))
            fila("Credito_Cuota") = "CREDITO CUOTA " + CStr(nro_cta) + "/" + CStr(dias) 'dbo.CobroPrestamosCreditos para saer que cuota se cobra
          Else
            fila("Credito_Cuota") = "CREDITO CUOTA"
          End If
          fila("Clientes_Saldo") = ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Saldo")

          '--------------------------------------------------------------------
          'nota: MODIF 29-08-2022
          Try
            Dim Clie_Saldo As Decimal = ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Saldo")
            If Clie_Saldo > 0 Then
              fila("Clientes_SaldoDESC") = "SALDO FINAL DEBE:"
            Else
              If Clie_Saldo < 0 Then
                fila("Clientes_SaldoDESC") = "SALDO FINAL GANO:"
              End If
            End If
          Catch ex As Exception
          End Try
          '--------------------------------------------------------------------

          If ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Imprime") = True Then
            Dim calculo_importe As Decimal = (100 * CDec(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_SaldoRegalo"))) / CDec(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo"))
            fila("Regalo_monto") = calculo_importe

            If calculo_importe > 0 Then
              fila("Regalo_desc") = "REGALO EN CONTRA % " + CStr(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo")) + ":"
            Else
              fila("Regalo_desc") = "REGALO A FAVOR % " + CStr(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo")) + ":"
            End If
            'Este dato solo es a nivel informativo y
            'puede tomar la referencia "A FAVOR" si el valor es negativo, o "EN CONTRA" Si es positivo.
            'Se muestra si dbo.Clientes.Imprime = true. El valor del porcentaje se obtiene del dbo.Clientes.Regalo.
            'El importe se obtiene de multiplicar (100 * dbo.Clientes.SaldoRegalo / dbo.Clientes.Regalo).
          End If

          fila("Fecha") = CDate(HF_fecha.Value)
          fila("mensaje_usuario") = Txt_msjgeneral.Text.ToString
          DS_ticketsclientes.Tables("Cliente_CtacteInfo").Rows.Add(fila)


          'OBTENGO PREMIOS

          Dim DS_Premios As DataSet = DAtickets.Premios_Cliente_Obtener(CDate(HF_fecha.Value), CInt(HF_dia_id.Value), CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente")))
          If DS_Premios.Tables(0).Rows.Count <> 0 Then
            Dim indice2 As Integer = 0
            While indice2 < DS_Premios.Tables(0).Rows.Count
              Dim row1 As DataRow = DS_ticketsclientes.Tables("Cliente_PremiosInfo").NewRow
              row1("Cliente") = CInt(DS_Premios.Tables(0).Rows(indice2).Item("Cliente"))
              row1("Premios_id") = DS_Premios.Tables(0).Rows(indice2).Item("Premios_id")
              row1("Recorrido_codigo") = DS_Premios.Tables(0).Rows(indice2).Item("Recorrido_codigo")
              row1("Referencia") = DS_Premios.Tables(0).Rows(indice2).Item("Referencia")
              row1("Importe") = DS_Premios.Tables(0).Rows(indice2).Item("Importe")
              row1("Pid") = DS_Premios.Tables(0).Rows(indice2).Item("Pid")
              row1("Suc") = DS_Premios.Tables(0).Rows(indice2).Item("Suc")
              row1("Pid2") = DS_Premios.Tables(0).Rows(indice2).Item("Pid2")
              row1("Suc2") = DS_Premios.Tables(0).Rows(indice2).Item("Suc2")
              row1("Premio") = DS_Premios.Tables(0).Rows(indice2).Item("Premio")
              row1("Terminal") = DS_Premios.Tables(0).Rows(indice2).Item("Terminal")

              DS_ticketsclientes.Tables("Cliente_PremiosInfo").Rows.Add(row1)

              indice2 = indice2 + 1
            End While


          End If

          indice = indice + 1
        End While


        'Dim filab As DataRow = DS_ticketsclientes.Tables("TicketClieOrden_info1").NewRow
        'filab("Cliente_codigo") = "1"
        'filab("Cliente_nombre") = "CHOCOLONEA, PABLO"
        'filab("Fecha") = CDate(HF_fecha.Value)
        'filab("R") = "0000"
        'filab("O") = "0000"
        'filab("Dia") = "LUNES"
        'DS_ticketsclientes.Tables("TicketClieOrden_info1").Rows.Add(filab)

        '------------------AQUIREPORTE ------------------------------------------------

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketsClientesPorOrden_informe01a.rpt"))
        CrReport.Database.Tables("TicketClieOrden_info1").SetDataSource(DS_ticketsclientes.Tables("TicketClieOrden_info1"))
        CrReport.Database.Tables("Puntos_A").SetDataSource(DS_ticketsclientes.Tables("Puntos_A"))

        CrReport.Database.Tables("Cliente_CtacteInfo").SetDataSource(DS_ticketsclientes.Tables("Cliente_CtacteInfo"))
        CrReport.Database.Tables("Cliente_PremiosInfo").SetDataSource(DS_ticketsclientes.Tables("Cliente_PremiosInfo"))

        'creo una cadena que voy a necesitar para el nombre del archivo a generar
        Dim grupo_longitud As Integer = 3
        Dim cliente_longitud As Integer = 4
        Dim grupo_dig As String = Txt_DesdeGrupoCodigo.Text
        While grupo_dig.Length < grupo_longitud
          grupo_dig = "0" + grupo_dig
        End While
        Dim cliente_dig As String = Txt_DesdeClienteCod.Text
        While cliente_dig.Length < cliente_longitud
          cliente_dig = "0" + cliente_dig
        End While

        Dim nombre_archivo As String = CDate(HF_fecha.Value).ToString("ddMMyy") + grupo_dig + cliente_dig
        'Dim nombre_archivo As String = CDate(HF_fecha.Value).ToString("ddMMyy") + Txt_DesdeGrupoCodigo.Text + Txt_DesdeClienteCod.Text
        Dim ruta As String = "/WC_Reportes/Rpt/TicketsClientesPorOrden/" + nombre_archivo + ".pdf"

        CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), ruta))
        'CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketsClientesPorOrden/TicketsClientesPorOrden.pdf"))

        'CrReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "Reporte")



        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

        '------------------------------------------------------------------------------
      Else
        'error, la busqueda no arrojo resultados. No hay movimientos para la fecha y los parametros ingresados.

        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)


      End If
    Else
      'msj complete información solicitada.

      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error2", "$(document).ready(function () {$('#modal-ok_error2').modal();});", True)

    End If



  End Sub





  Private Sub BOTON_GRABA_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABA.ServerClick

    NUEVO_GUARDAR_PRUEBA()



    '/////////////COMENTO DESDE AQUI

#Region "COMENTADA"
    '    'valido que todos los campos tengas algo ingresado.

    '    Dim valido As String = "si"

    '    Try
    '      Txt_DesdeGrupoCodigo.Text = CInt(Txt_DesdeGrupoCodigo.Text)
    '    Catch ex As Exception
    '      valido = "no"
    '    End Try

    '    Try
    '      Txt_DesdeClienteCod.Text = CInt(Txt_DesdeClienteCod.Text)
    '    Catch ex As Exception
    '      valido = "no"
    '    End Try

    '    Try
    '      Txt_HastaGrupoCodigo.Text = CInt(Txt_HastaGrupoCodigo.Text)
    '    Catch ex As Exception
    '      valido = "no"
    '    End Try

    '    Try
    '      Txt_HastaClienteCod.Text = CInt(Txt_HastaClienteCod.Text)
    '    Catch ex As Exception
    '      valido = "no"
    '    End Try

    '    If valido = "si" Then
    '      'recupero todos los puntos y recorridos para la fecha indicada.

    '#Region "TABLA DE PUNTOS"

    '      'voy a cargar los 3 tables con las 5 zonas, en total son 3 tablas de 21 registros (encabezado+20 puntos).
    '      Dim DS_ticketsclientes As New DS_ticketsclientes
    '      Dim Fila_A As DataRow = DS_ticketsclientes.Tables("Puntos_A").NewRow
    '      Fila_A("ZON1") = "ZON1" '1A
    '      Fila_A("ZON2") = "ZON2" '1B
    '      Fila_A("ZON3") = "ZON3" '1C
    '      Fila_A("ZON4") = "ZON4" '1D
    '      Fila_A("ZON5") = "ZON5" '1E
    '      Fila_A("ZON6") = "ZON6" '1F
    '      Fila_A("ZON7") = "ZON7" '1G
    '      Fila_A("ZON8") = "ZON8" '1H
    '      Fila_A("ZON9") = "ZON9" '1I
    '      Fila_A("ZO10") = "ZO10" '1J
    '      Fila_A("ZO11") = "ZO11" '2A
    '      Fila_A("ZO12") = "ZO12" '2B
    '      Fila_A("ZO13") = "ZO13" '2C
    '      Fila_A("ZO14") = "ZO14" '2D
    '      Fila_A("ZO15") = "ZO15" '2E
    '      Fila_A("ZO16") = "ZO16" '2F
    '      Fila_A("ZO17") = "ZO17" '2G
    '      Fila_A("ZO18") = "ZO18" '2H
    '      Fila_A("ZO19") = "ZO19" '2I
    '      Fila_A("ZO20") = "ZO20" '2J
    '      Fila_A("ZO21") = "ZO21" '3A
    '      Fila_A("ZO22") = "ZO22" '3B
    '      Fila_A("ZO23") = "ZO23" '3C
    '      Fila_A("ZO24") = "ZO24" '3D
    '      Fila_A("ZO25") = "ZO25" '3E

    '      Fila_A("Fecha") = CDate(HF_fecha.Value)
    '      DS_ticketsclientes.Tables("Puntos_A").Rows.Add(Fila_A)
    '      Dim i As Integer = 0
    '      While i < 20
    '        Dim Fila As DataRow = DS_ticketsclientes.Tables("Puntos_A").NewRow
    '        Fila("ITEM") = CStr(i + 1)
    '        Fila("Fecha") = CDate(HF_fecha.Value)
    '        DS_ticketsclientes.Tables("Puntos_A").Rows.Add(Fila)
    '        i = i + 1
    '      End While
    '      Dim Puntos_B As DataTable = DS_ticketsclientes.Tables("Puntos_A").Clone() 'copio solo la estructura de Puntos_A
    '      DS_ticketsclientes.Tables("Puntos_A").Rows.Add()
    '      'ahora creo registros para Puntos_B
    '      Dim Fila_B As DataRow = Puntos_B.NewRow
    '      Fila_B("ZON1") = "ZO26"
    '      Fila_B("ZON2") = "ZO27"
    '      Fila_B("ZON3") = "ZO28"
    '      Fila_B("ZON4") = "ZO29"
    '      Fila_B("ZON5") = "ZO30"
    '      Fila_B("ZON6") = "ZO31"
    '      Fila_B("ZON7") = "ZO32"
    '      Fila_B("ZON8") = "ZO33"
    '      Fila_B("ZON9") = "ZO34"
    '      Fila_B("ZO10") = "ZO35"
    '      Fila_B("ZO11") = "ZO36"
    '      Fila_B("ZO12") = "ZO37"
    '      Fila_B("ZO13") = "ZO38"
    '      Fila_B("ZO14") = "ZO39"
    '      Fila_B("ZO15") = "ZO40"
    '      Fila_B("ZO16") = "ZO41"
    '      Fila_B("ZO17") = "ZO42"
    '      Fila_B("ZO18") = "ZO43"
    '      Fila_B("ZO19") = "ZO44"
    '      Fila_B("ZO20") = "ZO45"
    '      Fila_B("ZO21") = "ZO46"
    '      Fila_B("ZO22") = "ZO47"
    '      Fila_B("ZO23") = "ZO48"
    '      Fila_B("ZO24") = "ZO49"
    '      Fila_B("ZO25") = "ZO50"
    '      Fila_B("Fecha") = CDate(HF_fecha.Value)
    '      Puntos_B.Rows.Add(Fila_B)
    '      Dim ii As Integer = 0
    '      While ii < 20
    '        Dim Fila As DataRow = Puntos_B.NewRow
    '        Fila("ITEM") = CStr(ii + 1)
    '        Fila("Fecha") = CDate(HF_fecha.Value)
    '        Puntos_B.Rows.Add(Fila)
    '        ii = ii + 1
    '      End While
    '      DS_ticketsclientes.Tables("Puntos_A").Merge(Puntos_B)
    '      DS_ticketsclientes.Tables("Puntos_A").Rows.Add()


    '      Dim ds_puntos As DataSet = DAtickets.RecorridosPuntos_obtener_fecha(CDate(HF_fecha.Value))
    '      If ds_puntos.Tables(0).Rows.Count <> 0 Then
    '        'si recupero algo cargo
    '        Dim r As Integer = 0
    '        While r < ds_puntos.Tables(0).Rows.Count
    '          Dim Codigo As String = CStr(ds_puntos.Tables(0).Rows(r).Item("Codigo"))
    '          Select Case Codigo
    '            Case "1A"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON1", 1, r)
    '            Case "1B"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON2", 1, r)
    '            Case "1C"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON3", 1, r)
    '            Case "1D"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON4", 1, r)
    '            Case "1E"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON5", 1, r)
    '            Case "1F"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON6", 1, r)
    '            Case "1G"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON7", 1, r)
    '            Case "1H"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON8", 1, r)
    '            Case "1I"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON9", 1, r)
    '            Case "1J"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO10", 1, r)
    '            Case "2A"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO11", 1, r)
    '            Case "2B"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO12", 1, r)
    '            Case "2C"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO13", 1, r)
    '            Case "2D"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO14", 1, r)
    '            Case "2E"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO15", 1, r)
    '            Case "2F"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO16", 1, r)
    '            Case "2G"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO17", 1, r)
    '            Case "2H"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO18", 1, r)
    '            Case "2I"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO19", 1, r)
    '            Case "2J"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO20", 1, r)
    '            Case "3A"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO21", 1, r)
    '            Case "3B"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO22", 1, r)
    '            Case "3C"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO23", 1, r)
    '            Case "3D"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO24", 1, r)
    '            Case "3E"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO25", 1, r)
    '            Case "3F"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON1", 23, r)
    '            Case "3G"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON2", 23, r)
    '            Case "3H"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON3", 23, r)
    '            Case "3I"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON4", 23, r)
    '            Case "3J"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON5", 23, r)
    '            Case "4A"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON6", 23, r)
    '            Case "4B"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON7", 23, r)
    '            Case "4C"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON8", 23, r)
    '            Case "4D"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZON9", 23, r)
    '            Case "4E"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO10", 23, r)
    '            Case "4F"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO11", 23, r)
    '            Case "4G"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO12", 23, r)
    '            Case "4H"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO13", 23, r)
    '            Case "4I"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO14", 23, r)
    '            Case "4J"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO15", 23, r)
    '            Case "5A"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO16", 23, r)
    '            Case "5B"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO17", 23, r)
    '            Case "5C"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO18", 23, r)
    '            Case "5D"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO19", 23, r)
    '            Case "5E"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO20", 23, r)
    '            Case "5F"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO21", 23, r)
    '            Case "5G"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO22", 23, r)
    '            Case "5H"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO23", 23, r)
    '            Case "5I"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO24", 23, r)
    '            Case "5J"
    '              CARGA_1(DS_ticketsclientes, ds_puntos, "ZO25", 23, r)
    '          End Select


    '          r = r + 1
    '        End While


    '      Else
    '        'error. no hay puntos o recorridos para dicha fecha.
    '      End If

    '#End Region



    '      Dim ds_ctacte As DataSet = DAtickets.CtaCte_MovimientosBuscar(CDate(HF_fecha.Value), CInt(Txt_DesdeGrupoCodigo.Text), CInt(Txt_DesdeClienteCod.Text), CInt(Txt_HastaGrupoCodigo.Text), CInt(Txt_HastaClienteCod.Text))

    '      If ds_ctacte.Tables(0).Rows.Count <> 0 Then

    '        'vamos a cargar la info de la cta cta y premios para cada cliente.

    '        Dim indice As Integer = 0
    '        While indice < ds_ctacte.Tables(0).Rows.Count

    '          Dim fila As DataRow = DS_ticketsclientes.Tables("Cliente_CtacteInfo").NewRow
    '          fila("Grupo_id") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Grupo_id"))
    '          fila("Grupo_codigo") = ds_ctacte.Tables(0).Rows(indice).Item("Grupo_codigo")
    '          fila("Grupo_nombre") = ds_ctacte.Tables(0).Rows(indice).Item("Grupo_nombre")
    '          fila("Cliente") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente"))
    '          fila("Cliente_codigo") = CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente_codigo"))
    '          fila("Cliente_nombre") = ds_ctacte.Tables(0).Rows(indice).Item("Cliente_Nombre")
    '          fila("R") = ds_ctacte.Tables(0).Rows(indice).Item("R")
    '          fila("O") = ds_ctacte.Tables(0).Rows(indice).Item("O")
    '          fila("Recaudacion") = ds_ctacte.Tables(0).Rows(indice).Item("Recaudacion")
    '          fila("Comision") = ds_ctacte.Tables(0).Rows(indice).Item("Comision")
    '          fila("Premios") = ds_ctacte.Tables(0).Rows(indice).Item("Premios")
    '          fila("Reclamos") = ds_ctacte.Tables(0).Rows(indice).Item("Reclamos")
    '          fila("DejoGano") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")
    '          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")) > 0 Then
    '            fila("DejoGano_desc") = "DEJO:"
    '          Else
    '            fila("DejoGano_desc") = "GANO:"
    '          End If
    '          fila("RecaudacionSC") = ds_ctacte.Tables(0).Rows(indice).Item("RecaudacionSC")
    '          fila("ComisionSC") = ds_ctacte.Tables(0).Rows(indice).Item("ComisionSC")
    '          fila("PremiosSC") = ds_ctacte.Tables(0).Rows(indice).Item("PremiosSC")
    '          fila("ReclamosSC") = ds_ctacte.Tables(0).Rows(indice).Item("ReclamosSC")
    '          fila("DejoGanoSC") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC")
    '          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC")) > 0 Then
    '            fila("DejoGanoSC_desc") = "DEJO:"
    '          Else
    '            fila("DejoGanoSC_desc") = "GANO:"
    '          End If
    '          Dim DejoGano_sum As Decimal = CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGano")) + CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoSC"))
    '          fila("DejoGanoGeneral") = DejoGano_sum
    '          If DejoGano_sum > 0 Then
    '            fila("DejoGanoGeneral_desc") = "GENERAL DEJO:"
    '          Else
    '            fila("DejoGanoGeneral_desc") = "GENERAL GANO:"
    '          End If
    '          fila("RecaudacionB") = ds_ctacte.Tables(0).Rows(indice).Item("RecaudacionB")
    '          fila("ComisionB") = ds_ctacte.Tables(0).Rows(indice).Item("ComisionB")
    '          fila("PremiosB") = ds_ctacte.Tables(0).Rows(indice).Item("PremiosB")
    '          fila("ReclamosB") = ds_ctacte.Tables(0).Rows(indice).Item("ReclamosB")
    '          fila("DejoGanoB") = ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB")
    '          If CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB")) > 0 Then
    '            fila("DejoGanoB_desc") = "DEJO:"
    '          Else
    '            fila("DejoGanoB_desc") = "GANO:"
    '          End If
    '          DejoGano_sum = DejoGano_sum + CDec(ds_ctacte.Tables(0).Rows(indice).Item("DejoGanoB"))
    '          fila("DejoGanoGeneralDia") = DejoGano_sum
    '          If DejoGano_sum > 0 Then
    '            fila("DejoGanoGeneralDia_desc") = "GENERAL DEL DIA DEJO:"
    '          Else
    '            fila("DejoGanoGeneralDia_desc") = "GENERAL DEL DIA GANO:"
    '          End If
    '          fila("Saldoanterior") = ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Saldoanterior")
    '          fila("Cobros") = ds_ctacte.Tables(0).Rows(indice).Item("Cobros")
    '          fila("Regalos") = ds_ctacte.Tables(0).Rows(indice).Item("Regalos")
    '          fila("Pagos") = ds_ctacte.Tables(0).Rows(indice).Item("Pagos")
    '          fila("Prestamo") = ds_ctacte.Tables(0).Rows(indice).Item("Prestamo")
    '          fila("CobPrestamo") = ds_ctacte.Tables(0).Rows(indice).Item("CobPrestamo")
    '          fila("Credito") = ds_ctacte.Tables(0).Rows(indice).Item("Credito")
    '          fila("CobCredito") = ds_ctacte.Tables(0).Rows(indice).Item("CobCredito")

    '          Dim ds_credi As DataSet = DAtickets.CobroCreditos_ClienteObtener(CDate(HF_fecha.Value), CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente")))
    '          If ds_credi.Tables(0).Rows.Count <> 0 Then
    '            Dim nro_cta As Integer = CInt(ds_credi.Tables(0).Rows(0).Item("Cuota"))
    '            Dim dias As Integer = CInt(ds_credi.Tables(0).Rows(0).Item("Dias"))
    '            fila("Credito_Cuota") = "CREDITO CUOTA " + CStr(nro_cta) + "/" + CStr(dias) 'dbo.CobroPrestamosCreditos para saer que cuota se cobra
    '          Else
    '            fila("Credito_Cuota") = "CREDITO CUOTA"
    '          End If
    '          fila("Clientes_Saldo") = ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Saldo")

    '          If ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Imprime") = True Then
    '            Dim calculo_importe As Decimal = (100 * CDec(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_SaldoRegalo"))) / CDec(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo"))
    '            fila("Regalo_monto") = calculo_importe

    '            If calculo_importe > 0 Then
    '              fila("Regalo_desc") = "REGALO EN CONTRA % " + CStr(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo")) + ":"
    '            Else
    '              fila("Regalo_desc") = "REGALO A FAVOR % " + CStr(ds_ctacte.Tables(0).Rows(indice).Item("Clientes_Regalo")) + ":"
    '            End If
    '            'Este dato solo es a nivel informativo y
    '            'puede tomar la referencia "A FAVOR" si el valor es negativo, o "EN CONTRA" Si es positivo.
    '            'Se muestra si dbo.Clientes.Imprime = true. El valor del porcentaje se obtiene del dbo.Clientes.Regalo.
    '            'El importe se obtiene de multiplicar (100 * dbo.Clientes.SaldoRegalo / dbo.Clientes.Regalo).
    '          End If

    '          fila("Fecha") = CDate(HF_fecha.Value)
    '          fila("mensaje_usuario") = Txt_msjgeneral.Text.ToString
    '          DS_ticketsclientes.Tables("Cliente_CtacteInfo").Rows.Add(fila)


    '          'OBTENGO PREMIOS

    '          Dim DS_Premios As DataSet = DAtickets.Premios_Cliente_Obtener(CDate(HF_fecha.Value), CInt(HF_dia_id.Value), CInt(ds_ctacte.Tables(0).Rows(indice).Item("Cliente")))
    '          If DS_Premios.Tables(0).Rows.Count <> 0 Then
    '            Dim indice2 As Integer = 0
    '            While indice2 < DS_Premios.Tables(0).Rows.Count
    '              Dim row1 As DataRow = DS_ticketsclientes.Tables("Cliente_PremiosInfo").NewRow
    '              row1("Cliente") = CInt(DS_Premios.Tables(0).Rows(indice2).Item("Cliente"))
    '              row1("Premios_id") = DS_Premios.Tables(0).Rows(indice2).Item("Premios_id")
    '              row1("Recorrido_codigo") = DS_Premios.Tables(0).Rows(indice2).Item("Recorrido_codigo")
    '              row1("Referencia") = DS_Premios.Tables(0).Rows(indice2).Item("Referencia")
    '              row1("Importe") = DS_Premios.Tables(0).Rows(indice2).Item("Importe")
    '              row1("Pid") = DS_Premios.Tables(0).Rows(indice2).Item("Pid")
    '              row1("Suc") = DS_Premios.Tables(0).Rows(indice2).Item("Suc")
    '              row1("Pid2") = DS_Premios.Tables(0).Rows(indice2).Item("Pid2")
    '              row1("Suc2") = DS_Premios.Tables(0).Rows(indice2).Item("Suc2")
    '              row1("Premio") = DS_Premios.Tables(0).Rows(indice2).Item("Premio")
    '              row1("Terminal") = DS_Premios.Tables(0).Rows(indice2).Item("Terminal")

    '              DS_ticketsclientes.Tables("Cliente_PremiosInfo").Rows.Add(row1)

    '              indice2 = indice2 + 1
    '            End While


    '          End If

    '          indice = indice + 1
    '        End While


    '        'Dim filab As DataRow = DS_ticketsclientes.Tables("TicketClieOrden_info1").NewRow
    '        'filab("Cliente_codigo") = "1"
    '        'filab("Cliente_nombre") = "CHOCOLONEA, PABLO"
    '        'filab("Fecha") = CDate(HF_fecha.Value)
    '        'filab("R") = "0000"
    '        'filab("O") = "0000"
    '        'filab("Dia") = "LUNES"
    '        'DS_ticketsclientes.Tables("TicketClieOrden_info1").Rows.Add(filab)

    '        '------------------AQUIREPORTE ------------------------------------------------

    '        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    '        CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketsClientesPorOrden_informe01a.rpt"))
    '        CrReport.Database.Tables("TicketClieOrden_info1").SetDataSource(DS_ticketsclientes.Tables("TicketClieOrden_info1"))
    '        CrReport.Database.Tables("Puntos_A").SetDataSource(DS_ticketsclientes.Tables("Puntos_A"))

    '        CrReport.Database.Tables("Cliente_CtacteInfo").SetDataSource(DS_ticketsclientes.Tables("Cliente_CtacteInfo"))
    '        CrReport.Database.Tables("Cliente_PremiosInfo").SetDataSource(DS_ticketsclientes.Tables("Cliente_PremiosInfo"))

    '        'creo una cadena que voy a necesitar para el nombre del archivo a generar
    '        Dim grupo_longitud As Integer = 3
    '        Dim cliente_longitud As Integer = 4
    '        Dim grupo_dig As String = Txt_DesdeGrupoCodigo.Text
    '        While grupo_dig.Length < grupo_longitud
    '          grupo_dig = "0" + grupo_dig
    '        End While
    '        Dim cliente_dig As String = Txt_DesdeClienteCod.Text
    '        While cliente_dig.Length < cliente_longitud
    '          cliente_dig = "0" + cliente_dig
    '        End While

    '        Dim nombre_archivo As String = CDate(HF_fecha.Value).ToString("ddMMyy") + grupo_dig + cliente_dig
    '        'Dim nombre_archivo As String = CDate(HF_fecha.Value).ToString("ddMMyy") + Txt_DesdeGrupoCodigo.Text + Txt_DesdeClienteCod.Text
    '        Dim ruta As String = "/WC_Reportes/Rpt/TicketsClientesPorOrden/" + nombre_archivo + ".pdf"

    '        CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), ruta))
    '        'CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketsClientesPorOrden/TicketsClientesPorOrden.pdf"))

    '        'CrReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "Reporte")



    '        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok", "$(document).ready(function () {$('#modal-ok').modal();});", True)

    '        '------------------------------------------------------------------------------
    '      Else
    '        'error, la busqueda no arrojo resultados. No hay movimientos para la fecha y los parametros ingresados.

    '        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error3", "$(document).ready(function () {$('#modal-ok_error3').modal();});", True)


    '      End If
    '    Else
    '      'msj complete información solicitada.

    '      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error2", "$(document).ready(function () {$('#modal-ok_error2').modal();});", True)

    '    End If

#End Region






  End Sub


  Private Sub btn_error_close2_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close2.ServerClick
    focus_error()
  End Sub

  Private Sub btn_ok_error2_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error2.ServerClick
    focus_error()
  End Sub

  Private Sub btn_ok_ServerClick(sender As Object, e As EventArgs) Handles btn_ok.ServerClick
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
  End Sub

  Private Sub btn_ok_close_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_close.ServerClick
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
  End Sub


  Private Sub btn_error_close3_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close3.ServerClick
    Txt_DesdeGrupoCodigo.Focus()
  End Sub

  Private Sub btn_ok_error3_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error3.ServerClick
    Txt_DesdeGrupoCodigo.Focus()
  End Sub


#Region "METODOS"
  Private Sub focus_error()
    Try
      Txt_DesdeGrupoCodigo.Text = CInt(Txt_DesdeGrupoCodigo.Text)
      Try
        Txt_DesdeClienteCod.Text = CInt(Txt_DesdeClienteCod.Text)
        Try
          Txt_HastaGrupoCodigo.Text = CInt(Txt_HastaGrupoCodigo.Text)
          Try
            Txt_HastaClienteCod.Text = CInt(Txt_HastaClienteCod.Text)
          Catch ex As Exception
            Txt_HastaClienteCod.Focus()
          End Try
        Catch ex As Exception
          Txt_HastaGrupoCodigo.Focus()
        End Try
      Catch ex As Exception
        Txt_DesdeClienteCod.Focus()
      End Try
    Catch ex As Exception
      Txt_DesdeGrupoCodigo.Focus()
    End Try
  End Sub

  Private Sub CARGA_1(ByRef DS_ticketsclientes As DataSet, ByRef ds_puntos As DataSet, ByVal Zona As String, ByVal indice As Integer, ByVal r As Integer)
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P1"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 1).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P2"))
    Catch ex As Exception

    End Try

    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 2).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P3"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 3).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P4"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 4).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P5"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 5).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P6"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 6).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P7"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 7).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P8"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 8).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P9"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 9).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P10"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 10).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P11"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 11).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P12"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 12).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P13"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 13).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P14"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 14).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P15"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 15).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P16"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 16).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P17"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 17).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P18"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 18).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P19"))
    Catch ex As Exception

    End Try
    Try
      DS_ticketsclientes.Tables("Puntos_A").Rows(indice + 19).Item(Zona) = CStr(ds_puntos.Tables(0).Rows(r).Item("P20"))
    Catch ex As Exception

    End Try


  End Sub






#End Region


End Class