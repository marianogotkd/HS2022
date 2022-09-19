Public Class TicketsCliePorOrdenImp
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DAtickets As New Capa_Datos.WC_tickets
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
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op2.aspx")
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



  Private Sub Colocar_zona(ByRef Codigo As String, ByRef DS_ticketsclientes As DataSet, ByVal registro As Integer, ByVal item_nomb As String, ByVal Referencia As String)
    Select Case Codigo
      Case "1A"
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON2"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
      Case "1B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON2"
      Case "1C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON3"
      Case "1D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON4"
      Case "1E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON5"
      Case "1F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON6"
      Case "1G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON7"
      Case "1H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON8"
      Case "1I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZON9"
      Case "1J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO10"
      Case "2A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO11"
      Case "2B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO12"
      Case "2C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO13"
      Case "2D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO14"
      Case "2E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO15"
      Case "2F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO16"
      Case "2G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO17"
      Case "2H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO18"
      Case "2I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO19"
      Case "2J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO20"
      Case "3A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO21"
      Case "3B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO22"
      Case "3C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO23"
      Case "3D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO24"
      Case "3E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO25"
      Case "3F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO26"
      Case "3G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO27"
      Case "3H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO28"
      Case "3I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO29"
      Case "3J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO30"
      Case "4A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO31"
      Case "4B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO32"
      Case "4C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO33"
      Case "4D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO34"
      Case "4E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO35"
      Case "4F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO36"
      Case "4G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO37"
      Case "4H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO38"
      Case "4I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO39"
      Case "4J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO40"
      Case "5A"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO41"
      Case "5B"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO42"
      Case "5C"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO43"
      Case "5D"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO44"
      Case "5E"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO45"
      Case "5F"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO46"
      Case "5G"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO47"
      Case "5H"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO48"
      Case "5I"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO49"
      Case "5J"
        DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = Referencia
        'DS_ticketsclientes.Tables("Puntos_A").Rows(registro).Item(item_nomb) = "ZO50"
    End Select
  End Sub


  Private Sub RecuperoZona_part1(ByVal r As Integer, ByVal Codigo As String, ByRef Zona As String, ByRef DS_ticketsclientes As DataSet, ByVal Referencia As String)
    Select Case r
      Case 0
        Zona = "ZON1" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON1", Referencia)
      Case 1
        Zona = "ZON2" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON2", Referencia)
      Case 2
        Zona = "ZON3" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON3", Referencia)
      Case 3
        Zona = "ZON4" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON4", Referencia)
      Case 4
        Zona = "ZON5" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON5", Referencia)
      Case 5
        Zona = "ZON6" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON6", Referencia)
      Case 6
        Zona = "ZON7" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON7", Referencia)
      Case 7
        Zona = "ZON8" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON8", Referencia)
      Case 8
        Zona = "ZON9" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZON9", Referencia)
      Case 9
        Zona = "ZO10" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO10", Referencia)
      Case 10
        Zona = "ZO11" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO11", Referencia)
      Case 11
        Zona = "ZO12" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO12", Referencia)
      Case 12
        Zona = "ZO13" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO13", Referencia)
      Case 13
        Zona = "ZO14" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO14", Referencia)
      Case 14
        Zona = "ZO15" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO15", Referencia)
      Case 15
        Zona = "ZO16" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO16", Referencia)
      Case 16
        Zona = "ZO17" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO17", Referencia)
      Case 17
        Zona = "ZO18" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO18", Referencia)
      Case 18
        Zona = "ZO19" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO19", Referencia)
      Case 19
        Zona = "ZO20" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO20", Referencia)
      Case 20
        Zona = "ZO21" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO21", Referencia)
      Case 21
        Zona = "ZO22" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO22", Referencia)
      Case 22
        Zona = "ZO23" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO23", Referencia)
      Case 23
        Zona = "ZO24" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO24", Referencia)
      Case 24
        Zona = "ZO25" 'ESTO PARA QUE LE INDIQUE EN QUE PARTE DEL DATATABLE SE VA A GUARDAR.
        Colocar_zona(Codigo, DS_ticketsclientes, 0, "ZO25", Referencia)
      Case 25
        Zona = "ZON1"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON1", Referencia)
      Case 26
        Zona = "ZON2"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON2", Referencia)
      Case 27
        Zona = "ZON3"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON3", Referencia)
      Case 28
        Zona = "ZON4"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON4", Referencia)
      Case 29
        Zona = "ZON5"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON5", Referencia)
      Case 30
        Zona = "ZON6"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON6", Referencia)
      Case 31
        Zona = "ZON7"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON7", Referencia)
      Case 32
        Zona = "ZON8"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON8", Referencia)
      Case 33
        Zona = "ZON9"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZON9", Referencia)
      Case 34
        Zona = "ZO10"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO10", Referencia)
      Case 35
        Zona = "ZO11"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO11", Referencia)
      Case 36
        Zona = "ZO12"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO12", Referencia)
      Case 37
        Zona = "ZO13"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO13", Referencia)
      Case 38
        Zona = "ZO14"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO14", Referencia)
      Case 39
        Zona = "ZO15"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO15", Referencia)
      Case 40
        Zona = "ZO16"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO16", Referencia)
      Case 41
        Zona = "ZO17"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO17", Referencia)
      Case 42
        Zona = "ZO18"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO18", Referencia)
      Case 43
        Zona = "ZO19"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO19", Referencia)
      Case 44
        Zona = "ZO20"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO20", Referencia)
      Case 45
        Zona = "ZO21"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO21", Referencia)
      Case 46
        Zona = "ZO22"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO22", Referencia)
      Case 47
        Zona = "ZO23"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO23", Referencia)
      Case 48
        Zona = "ZO24"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO24", Referencia)
      Case 49
        Zona = "ZO25"
        Colocar_zona(Codigo, DS_ticketsclientes, 22, "ZO25", Referencia)

    End Select



  End Sub



  Private Sub BOTON_GRABA_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABA.ServerClick
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

        If ds_puntos.Tables(0).Rows.Count > 25 Then
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
          Dim Referencia As String = CStr(ds_puntos.Tables(0).Rows(r).Item("Referencia"))
          If ContZonas < 25 Then
            Dim Zona As String = ""
            RecuperoZona_part1(r, Codigo, Zona, DS_ticketsclientes, Referencia)
            CARGA_1(DS_ticketsclientes, ds_puntos, Zona, 1, r)
          Else
            If ContZonas < 50 Then
              Dim Zona As String = ""
              RecuperoZona_part1(r, Codigo, Zona, DS_ticketsclientes, Referencia)
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
          fila("Cobros") = ds_ctacte.Tables(0).Rows(indice).Item("Cobros")
          fila("Regalos") = ds_ctacte.Tables(0).Rows(indice).Item("Regalos")
          fila("Pagos") = ds_ctacte.Tables(0).Rows(indice).Item("Pagos")
          fila("Prestamo") = ds_ctacte.Tables(0).Rows(indice).Item("Prestamo")
          fila("CobPrestamo") = ds_ctacte.Tables(0).Rows(indice).Item("CobPrestamo")
          fila("Credito") = ds_ctacte.Tables(0).Rows(indice).Item("Credito")
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
        'CORRECCION: 2022-09-07
        '-------------------------------------------------------------------------------
        DS_ticketsclientes.Tables("Cliente_CtacteInfo_2").Merge(DS_ticketsclientes.Tables("Cliente_CtacteInfo"))
        '-------------------------------------------------------------------------------

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/TicketsClientesPorOrden_informe01a.rpt"))
        CrReport.Database.Tables("TicketClieOrden_info1").SetDataSource(DS_ticketsclientes.Tables("TicketClieOrden_info1"))
        CrReport.Database.Tables("Puntos_A").SetDataSource(DS_ticketsclientes.Tables("Puntos_A"))

        CrReport.Database.Tables("Cliente_CtacteInfo").SetDataSource(DS_ticketsclientes.Tables("Cliente_CtacteInfo"))
        CrReport.Database.Tables("Cliente_CtacteInfo_2").SetDataSource(DS_ticketsclientes.Tables("Cliente_CtacteInfo_2"))
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

        'CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), ruta))
        CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/TicketsClientesPorOrden/TicketsClientesPorOrden.pdf"))

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


  Private Sub btn_error_close2_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close2.ServerClick
    focus_error()
  End Sub

  Private Sub btn_ok_error2_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error2.ServerClick
    focus_error()
  End Sub

  Private Sub btn_ok_close_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_close.ServerClick
    Txt_DesdeGrupoCodigo.Focus()
  End Sub

  Private Sub BTN_IMPRIMIR_Click(sender As Object, e As EventArgs) Handles BTN_IMPRIMIR.Click
    Txt_DesdeGrupoCodigo.Focus()
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
