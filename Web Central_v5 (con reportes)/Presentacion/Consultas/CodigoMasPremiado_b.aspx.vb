Public Class CodigoMasPremiado_b
  Inherits System.Web.UI.Page

#Region "Declaraciones"
  Dim Daparametro As New Capa_Datos.WC_parametro
  Dim DALConsultas As New Capa_Datos.WB_Consultas
  Dim DALiquidacion As New Capa_Datos.WC_Liquidacion
  Dim Lista1Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista2Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista3Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista4Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)



#End Region


  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      TxtCodigo.Focus()
      'recuperar fecha de tabla parametro.

      HF_fecha.Value = Session("fecha_parametro")

      Dim ds_fecha As DataSet = Daparametro.Parametro_obtener_dia
      If ds_fecha.Tables(0).Rows.Count <> 0 Then
        Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
        'txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")


        Dim DS_liqparcial As New DS_liqparcial
        DS_liqparcial.Tables("Recorridos_seleccionados").Merge(Session("tabla_recorridos_seleccionados"))
        txtZona.Text = DS_liqparcial.Tables("Recorridos_seleccionados").Rows(0).Item("Codigo").ToString.ToString
        TxtCodigo.Focus()

      End If

    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Consultas/CodigoMasPremiadoRecorridos_b.aspx")
  End Sub

  Private Sub BusquedaValidadInicial()


    Try
      txtImporte1.Text = CDec(txtImporte1.Text)
    Catch ex As Exception
      txtImporte1.Text = CDec(0)
    End Try
    Try
      txtImporte2.Text = CDec(txtImporte2.Text)
    Catch ex As Exception
      txtImporte2.Text = CDec(0)
    End Try
    Try
      txtImporte3.Text = CDec(txtImporte3.Text)
    Catch ex As Exception
      txtImporte3.Text = CDec(0)
    End Try
    Try
      txtImporte4.Text = CDec(txtImporte4.Text)
    Catch ex As Exception
      txtImporte4.Text = CDec(0)
    End Try

  End Sub

  Private Sub btn_ok_error_busqueda01_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error_busqueda01.ServerClick
    TxtCodigo.Focus()
  End Sub

  Private Sub btn_close_error_busqueda01_ServerClick(sender As Object, e As EventArgs) Handles btn_close_error_busqueda01.ServerClick
    TxtCodigo.Focus()
  End Sub

  Private Sub txtImporte1_Init(sender As Object, e As EventArgs) Handles txtImporte1.Init
    txtImporte1.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub
  Private Sub txtImporte2_Init(sender As Object, e As EventArgs) Handles txtImporte2.Init
    txtImporte2.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub
  Private Sub txtImporte3_Init(sender As Object, e As EventArgs) Handles txtImporte3.Init
    txtImporte3.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub
  Private Sub txtImporte4_Init(sender As Object, e As EventArgs) Handles txtImporte4.Init
    txtImporte4.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub TxtCodigo_Init(sender As Object, e As EventArgs) Handles TxtCodigo.Init
    TxtCodigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub btnBuscar_ServerClick(sender As Object, e As EventArgs) Handles btnBuscar.ServerClick
    'IMPORTANTE SE CARGA DESDE CERO LA TABLA XCARGAS Y XCARGAS RECORRIDOS. FECHA: 22-08-04
    DALiquidacion.XCargas_load()

    '--------------VALIDACION INICIAL------------------------------------------------
    BusquedaValidadInicial()
    '--------------FIN--------------------------------------------------------------



    '--------------AGREGO TODOS LOS COGIDOS EN UNA VARIABLE STRING-------------------
    Dim DS_liqparcial As New DS_liqparcial
    DS_liqparcial.Tables("Recorridos_seleccionados").Merge(Session("tabla_recorridos_seleccionados"))
    Dim CadenaCodigos As String = ""
    GenerarCadenaCodigos(DS_liqparcial.Tables("Recorridos_seleccionados"), CadenaCodigos)
    '--------------FIN---------------------------------------------------------------

    Dim DS_Consultas As New DS_Consultas


    If TxtCodigo.Text <> "" Then
      CargaTabla1Cifra(DS_Consultas, CadenaCodigos)
      CargaTabla2Cifra(DS_Consultas, CadenaCodigos)
      CargaTabla3Cifra(DS_Consultas, CadenaCodigos)
      CargaTabla4Cifra(DS_Consultas, CadenaCodigos)

      'CALCULO LOS TOTALES
      CALCULAR_TOTALREGAUDADO(DS_Consultas)

      If (grvCifra1.Rows.Count = 0) And (grvCifra2.Rows.Count = 0) And (grvCifra3.Rows.Count = 0) And (grvCifra4.Rows.Count = 0) Then
        seccion1.Visible = False
        'error, la busqueda no arrojó resultados.
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_msjerror_busqueda01", "$(document).ready(function () {$('#modal_msjerror_busqueda01').modal();});", True)
      Else
        seccion1.Visible = True
      End If

    Else
      seccion1.Visible = False
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_msjerror_busqueda01", "$(document).ready(function () {$('#modal_msjerror_busqueda01').modal();});", True)
    End If




    TxtCodigo.Focus()


  End Sub

  Private Sub GenerarCadenaCodigos(ByRef TablaRecorridos As DataTable, ByRef CadenaCodigos As String)
    Dim i As Integer = 0
    While i < TablaRecorridos.Rows.Count
      If i = 0 Then
        CadenaCodigos = "'" + TablaRecorridos.Rows(i).Item("Codigo").ToString + "'"
      Else
        CadenaCodigos = CadenaCodigos + "," + "'" + TablaRecorridos.Rows(i).Item("Codigo").ToString + "'"
      End If
      i = i + 1
    End While
  End Sub

  Private Sub CargaTabla1Cifra(ByRef DS_Consultas As DataSet, ByRef CadenaCodigos As String)
    DS_Consultas.Tables("UNA_CIFRA").Rows.Clear()

    Dim dt_consulta As DataTable = DALConsultas.Cargas_Zona_PID(CadenaCodigos, TxtCodigo.Text, HF_fecha.Value)



    Dim i As Integer = 0
    While i < dt_consulta.Rows.Count
      If dt_consulta.Rows(i).Item(0).ToString.Length = 1 Then
        Dim PID As String = dt_consulta.Rows(i).Item(0).ToString
        Dim Codigo_Zona As String = dt_consulta.Rows(i).Item(2).ToString
        Dim Importe As Decimal = dt_consulta.Rows(i).Item(1)
        Dim existe As String = "no"
        Dim j As Integer = 0
        While j < DS_Consultas.Tables("UNA_CIFRA").Rows.Count

          If (PID = DS_Consultas.Tables("UNA_CIFRA").Rows(j).Item("PID")) And (Codigo_Zona = DS_Consultas.Tables("UNA_CIFRA").Rows(j).Item("ZONA")) Then
            DS_Consultas.Tables("UNA_CIFRA").Rows(j).Item("IMPORTE") = DS_Consultas.Tables("UNA_CIFRA").Rows(j).Item("IMPORTE") + Importe
            existe = "si"
            Exit While
          End If

          j = j + 1
        End While

        If existe = "no" Then
          Dim fila As DataRow = DS_Consultas.Tables("UNA_CIFRA").NewRow
          fila("PID") = PID
          fila("ZONA") = Codigo_Zona
          fila("IMPORTE") = Importe
          DS_Consultas.Tables("UNA_CIFRA").Rows.Add(fila)
        End If

      End If
      i = i + 1
    End While

    'ELIMINO LOS REGISTROS QUE NO SEAN MAYOR O IGUAL AL IMPORTE MINIMO PARA 1 DIGITO.
    i = 0
    Dim Importe_minimo As Decimal = CDec(txtImporte1.Text)
    While i < DS_Consultas.Tables("UNA_CIFRA").Rows.Count
      If DS_Consultas.Tables("UNA_CIFRA").Rows(i).Item("IMPORTE") < Importe_minimo Then
        'elimino
        DS_Consultas.Tables("UNA_CIFRA").Rows.RemoveAt(i)
        i = 0
      Else
        i = i + 1
      End If

    End While
    grvCifra1.DataSource = DS_Consultas.Tables("UNA_CIFRA")
    grvCifra1.DataBind()
  End Sub


  Private Sub CargaTabla2Cifra(ByRef DS_Consultas As DataSet, ByRef CadenaCodigos As String)
    DS_Consultas.Tables("DOS_CIFRAS").Rows.Clear()
    Dim dt_consulta As DataTable = DALConsultas.Cargas_Zona_PID(CadenaCodigos, TxtCodigo.Text, HF_fecha.Value)
    Dim i As Integer = 0
    While i < dt_consulta.Rows.Count
      If dt_consulta.Rows(i).Item(0).ToString.Length = 2 Then
        Dim PID As String = dt_consulta.Rows(i).Item(0).ToString
        Dim Codigo_Zona As String = dt_consulta.Rows(i).Item(2).ToString
        Dim Importe As Decimal = dt_consulta.Rows(i).Item(1)
        Dim existe As String = "no"
        Dim j As Integer = 0
        While j < DS_Consultas.Tables("DOS_CIFRAS").Rows.Count
          If (PID = DS_Consultas.Tables("DOS_CIFRAS").Rows(j).Item("PID")) And (Codigo_Zona = DS_Consultas.Tables("DOS_CIFRAS").Rows(j).Item("ZONA")) Then
            DS_Consultas.Tables("DOS_CIFRAS").Rows(j).Item("IMPORTE") = DS_Consultas.Tables("DOS_CIFRAS").Rows(j).Item("IMPORTE") + Importe
            existe = "si"
            Exit While
          End If
          j = j + 1
        End While
        If existe = "no" Then
          Dim fila As DataRow = DS_Consultas.Tables("DOS_CIFRAS").NewRow
          fila("PID") = PID
          fila("ZONA") = Codigo_Zona
          fila("IMPORTE") = Importe
          DS_Consultas.Tables("DOS_CIFRAS").Rows.Add(fila)
        End If
      End If
      i = i + 1
    End While
    'ELIMINO LOS REGISTROS QUE NO SEAN MAYOR O IGUAL AL IMPORTE MINIMO PARA 2 DIGITO.
    i = 0
    Dim Importe_minimo As Decimal = CDec(txtImporte2.Text)
    While i < DS_Consultas.Tables("DOS_CIFRAS").Rows.Count
      If DS_Consultas.Tables("DOS_CIFRAS").Rows(i).Item("IMPORTE") < Importe_minimo Then
        'elimino
        DS_Consultas.Tables("DOS_CIFRAS").Rows.RemoveAt(i)
        i = 0
      Else
        i = i + 1
      End If
    End While
    grvCifra2.DataSource = DS_Consultas.Tables("DOS_CIFRAS")
    grvCifra2.DataBind()
  End Sub

  Private Sub CargaTabla3Cifra(ByRef DS_Consultas As DataSet, ByRef CadenaCodigos As String)
    DS_Consultas.Tables("TRES_CIFRAS").Rows.Clear()
    Dim dt_consulta As DataTable = DALConsultas.Cargas_Zona_PID(CadenaCodigos, TxtCodigo.Text, HF_fecha.Value)
    Dim i As Integer = 0
    While i < dt_consulta.Rows.Count
      If dt_consulta.Rows(i).Item(0).ToString.Length = 3 Then
        Dim PID As String = dt_consulta.Rows(i).Item(0).ToString
        Dim Codigo_Zona As String = dt_consulta.Rows(i).Item(2).ToString
        Dim Importe As Decimal = dt_consulta.Rows(i).Item(1)
        Dim existe As String = "no"
        Dim j As Integer = 0
        While j < DS_Consultas.Tables("TRES_CIFRAS").Rows.Count

          If (PID = DS_Consultas.Tables("TRES_CIFRAS").Rows(j).Item("PID")) And (Codigo_Zona = DS_Consultas.Tables("TRES_CIFRAS").Rows(j).Item("ZONA")) Then
            DS_Consultas.Tables("TRES_CIFRAS").Rows(j).Item("IMPORTE") = DS_Consultas.Tables("TRES_CIFRAS").Rows(j).Item("IMPORTE") + Importe
            existe = "si"
            Exit While
          End If

          j = j + 1
        End While
        If existe = "no" Then
          Dim fila As DataRow = DS_Consultas.Tables("TRES_CIFRAS").NewRow
          fila("PID") = PID
          fila("ZONA") = Codigo_Zona
          fila("IMPORTE") = Importe
          DS_Consultas.Tables("TRES_CIFRAS").Rows.Add(fila)
        End If
      End If
      i = i + 1
    End While
    'ELIMINO LOS REGISTROS QUE NO SEAN MAYOR O IGUAL AL IMPORTE MINIMO PARA 3 DIGITO.
    i = 0
    Dim Importe_minimo As Decimal = CDec(txtImporte3.Text)
    While i < DS_Consultas.Tables("TRES_CIFRAS").Rows.Count
      If DS_Consultas.Tables("TRES_CIFRAS").Rows(i).Item("IMPORTE") < Importe_minimo Then
        'elimino
        DS_Consultas.Tables("TRES_CIFRAS").Rows.RemoveAt(i)
        i = 0
      Else
        i = i + 1
      End If
    End While
    grvCifra3.DataSource = DS_Consultas.Tables("TRES_CIFRAS")
    grvCifra3.DataBind()
  End Sub

  Private Sub CargaTabla4Cifra(ByRef DS_Consultas As DataSet, ByRef CadenaCodigos As String)
    DS_Consultas.Tables("CUATRO_CIFRAS").Rows.Clear()
    Dim dt_consulta As DataTable = DALConsultas.Cargas_Zona_PID(CadenaCodigos, TxtCodigo.Text, HF_fecha.Value)
    Dim i As Integer = 0
    While i < dt_consulta.Rows.Count
      If dt_consulta.Rows(i).Item(0).ToString.Length = 4 Then
        Dim PID As String = dt_consulta.Rows(i).Item(0).ToString
        Dim Codigo_Zona As String = dt_consulta.Rows(i).Item(2).ToString
        Dim Importe As Decimal = dt_consulta.Rows(i).Item(1)
        Dim existe As String = "no"
        Dim j As Integer = 0
        While j < DS_Consultas.Tables("CUATRO_CIFRAS").Rows.Count

          If (PID = DS_Consultas.Tables("CUATRO_CIFRAS").Rows(j).Item("PID")) And (Codigo_Zona = DS_Consultas.Tables("CUATRO_CIFRAS").Rows(j).Item("ZONA")) Then
            DS_Consultas.Tables("CUATRO_CIFRAS").Rows(j).Item("IMPORTE") = DS_Consultas.Tables("CUATRO_CIFRAS").Rows(j).Item("IMPORTE") + Importe
            existe = "si"
            Exit While
          End If

          j = j + 1
        End While

        If existe = "no" Then
          Dim fila As DataRow = DS_Consultas.Tables("CUATRO_CIFRAS").NewRow
          fila("PID") = PID
          fila("ZONA") = Codigo_Zona
          fila("IMPORTE") = Importe
          DS_Consultas.Tables("CUATRO_CIFRAS").Rows.Add(fila)
        End If

      End If
      i = i + 1
    End While

    'ELIMINO LOS REGISTROS QUE NO SEAN MAYOR O IGUAL AL IMPORTE MINIMO PARA 4 DIGITO.
    i = 0
    Dim Importe_minimo As Decimal = CDec(txtImporte4.Text)
    While i < DS_Consultas.Tables("CUATRO_CIFRAS").Rows.Count
      If DS_Consultas.Tables("CUATRO_CIFRAS").Rows(i).Item("IMPORTE") < Importe_minimo Then
        'elimino
        DS_Consultas.Tables("CUATRO_CIFRAS").Rows.RemoveAt(i)
        i = 0
      Else
        i = i + 1
      End If

    End While
    grvCifra4.DataSource = DS_Consultas.Tables("CUATRO_CIFRAS")
    grvCifra4.DataBind()
  End Sub

  Private Sub CALCULAR_TOTALREGAUDADO(ByRef DS_Consultas As DataSet)
    Dim TOTAL As Decimal = 0

    Dim i As Integer = 0
    While i < DS_Consultas.Tables("UNA_CIFRA").Rows.Count
      Try
        TOTAL = TOTAL + CDec(DS_Consultas.Tables("UNA_CIFRA").Rows(i).Item("IMPORTE"))
      Catch ex As Exception

      End Try
      i = i + 1
    End While
    i = 0
    While i < DS_Consultas.Tables("DOS_CIFRAS").Rows.Count
      Try
        TOTAL = TOTAL + CDec(DS_Consultas.Tables("DOS_CIFRAS").Rows(i).Item("IMPORTE"))
      Catch ex As Exception

      End Try
      i = i + 1
    End While
    i = 0
    While i < DS_Consultas.Tables("TRES_CIFRAS").Rows.Count
      Try
        TOTAL = TOTAL + CDec(DS_Consultas.Tables("TRES_CIFRAS").Rows(i).Item("IMPORTE"))
      Catch ex As Exception

      End Try
      i = i + 1
    End While
    i = 0
    While i < DS_Consultas.Tables("CUATRO_CIFRAS").Rows.Count
      Try
        TOTAL = TOTAL + CDec(DS_Consultas.Tables("CUATRO_CIFRAS").Rows(i).Item("IMPORTE"))
      Catch ex As Exception

      End Try
      i = i + 1
    End While
    Label_TotalRecaudado.Text = "TOTAL RECAUDADO: " + TOTAL.ToString


  End Sub

End Class
