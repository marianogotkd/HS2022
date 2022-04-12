Public Class CodigoMasPremiado
  Inherits System.Web.UI.Page

#Region "Declaraciones"
  Dim Daparametro As New Capa_Datos.WC_parametro
  Dim DALConsultas As New Capa_Datos.WB_Consultas

  Dim Lista1Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista2Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista3Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)
  Dim Lista4Cifras As New List(Of Capa_Datos.CodigoMasCargadoDTO)



#End Region
#Region "Eventos"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      txtClienteDesde.Focus()
      'recuperar fecha de tabla parametro.

      HF_fecha.Value = Session("fecha_parametro")

      Dim ds_fecha As DataSet = Daparametro.Parametro_obtener_dia
      If ds_fecha.Tables(0).Rows.Count <> 0 Then
        Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
        'txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")

      End If

    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Consultas/CodigoMasPremiadoRecorridos.aspx")
  End Sub


  Private Sub BusquedaValidadInicial()
    Try
      txtClienteDesde.Text = CInt(txtClienteDesde.Text)
    Catch ex As Exception
      txtClienteDesde.Text = 0
    End Try
    Try
      txtClienteHasta.Text = CInt(txtClienteHasta.Text)
    Catch ex As Exception
      txtClienteHasta.Text = 0
    End Try
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

  Private Sub btnBuscar_ServerClick(sender As Object, e As EventArgs) Handles btnBuscar.ServerClick
    '--------------VALIDACION INICIAL------------------------------------------------
    BusquedaValidadInicial()
    '--------------FIN--------------------------------------------------------------

    '--------------AGREGO TODOS LOS COGIDOS EN UNA VARIABLE STRING-------------------
    Dim DS_liqparcial As New DS_liqparcial
    DS_liqparcial.Tables("Recorridos_seleccionados").Merge(Session("tabla_recorridos_seleccionados"))
    Dim CadenaCodigos As String = ""
    GenerarCadenaCodigos(DS_liqparcial.Tables("Recorridos_seleccionados"), CadenaCodigos)
    '--------------FIN---------------------------------------------------------------

    LlenarTabla1Cifra(CadenaCodigos)
    LlenarTabla2Cifra(CadenaCodigos)
    LlenarTabla3Cifra(CadenaCodigos)
    LlenarTabla4Cifra(CadenaCodigos)
    If (grvCifra1.Rows.Count = 0) And (grvCifra2.Rows.Count = 0) And (grvCifra3.Rows.Count = 0) And (grvCifra4.Rows.Count = 0) Then
      seccion1.Visible = False
      'error, la busqueda no arrojó resultados.
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_msjerror_busqueda01", "$(document).ready(function () {$('#modal_msjerror_busqueda01').modal();});", True)
    Else
      seccion1.Visible = True
    End If
    txtClienteDesde.Focus()
  End Sub

  Private Sub btn_ok_error_busqueda01_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error_busqueda01.ServerClick
    txtClienteDesde.Focus()
  End Sub

  Private Sub btn_close_error_busqueda01_ServerClick(sender As Object, e As EventArgs) Handles btn_close_error_busqueda01.ServerClick
    txtClienteDesde.Focus()
  End Sub

  Private Sub txtClienteDesde_Init(sender As Object, e As EventArgs) Handles txtClienteDesde.Init
    txtClienteDesde.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub
  Private Sub txtClienteHasta_Init(sender As Object, e As EventArgs) Handles txtClienteHasta.Init
    txtClienteHasta.Attributes.Add("onfocus", "seleccionarTexto(this);")
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
#End Region


#Region "Metodos"

  Private Function Buscar(ByVal ClienteDesde As Integer, ByVal ClienteHasta As Integer, ByVal Cifras As Integer, ByVal Monto As String, ByVal CadenaCodigos As String) As List(Of Capa_Datos.CodigoMasCargadoDTO)
    Dim MyLista As DataTable
    Dim ListaAUX As New List(Of Capa_Datos.CodigoMasCargadoDTO)
    MyLista = DALConsultas.CargasClientesDesdeHasta(ClienteDesde, ClienteHasta, CadenaCodigos, HF_fecha.Value)

    For Each r As DataRow In MyLista.Rows
      If r(0).ToString.Length = Cifras Then
        If r(1) >= Monto Then
          Dim MyCMC As New Capa_Datos.CodigoMasCargadoDTO

          MyCMC.PID = r(0)
          MyCMC.Importe = r(1)
          MyCMC.Zona = r(2)

          ListaAUX.Add(MyCMC)
        End If


      End If

    Next
    Return ListaAUX

  End Function

  Private Sub LlenarTabla1Cifra(ByVal CadenaCodigos As String)
    Lista1Cifras = Buscar(txtClienteDesde.Text, txtClienteHasta.Text, 1, txtImporte1.Text, CadenaCodigos)
    grvCifra1.DataSource = Lista1Cifras
    grvCifra1.DataBind()

  End Sub

  Private Sub LlenarTabla2Cifra(ByVal CadenaCodigos As String)
    Lista2Cifras = Buscar(txtClienteDesde.Text, txtClienteHasta.Text, 2, txtImporte2.Text, CadenaCodigos)
    grvCifra2.DataSource = Lista2Cifras
    grvCifra2.DataBind()

  End Sub
  Private Sub LlenarTabla3Cifra(ByVal CadenaCodigos As String)
    Lista3Cifras = Buscar(txtClienteDesde.Text, txtClienteHasta.Text, 3, txtImporte3.Text, CadenaCodigos)
    grvCifra3.DataSource = Lista3Cifras
    grvCifra3.DataBind()

  End Sub
  Private Sub LlenarTabla4Cifra(ByVal CadenaCodigos As String)
    Lista4Cifras = Buscar(txtClienteDesde.Text, txtClienteHasta.Text, 4, txtImporte4.Text, CadenaCodigos)
    grvCifra4.DataSource = Lista4Cifras
    grvCifra4.DataBind()

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

#End Region


  'Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
  'lb_cliente_nomb.InnerText = "Nombre:"
  'Txt_importe.Text = ""
  'Txt_diasacobrar.Text = ""
  'Txt_porcentaje.Text = ""

  'Try
  '  Dim Fecha As Date = CDate(txt_fecha.Text)

  '  If Txt_cliente_codigo.Text <> "" Then
  '    Dim ds_info As DataSet = DAprestamoscreditos.Creditos_buscar_cliente_info(Txt_cliente_codigo.Text, txt_fecha.Text)
  '    If ds_info.Tables(2).Rows.Count <> 0 Then
  '      'cargo la info del credito que se recupero para esa fecha.
  '      lb_cliente_nomb.InnerText = "Nombre: " + ds_info.Tables(2).Rows(0).Item("Nombre")
  '      Txt_importe.Text = CDec(ds_info.Tables(2).Rows(0).Item("Importe"))
  '      Txt_porcentaje.Text = CDec(ds_info.Tables(2).Rows(0).Item("Porcentaje"))
  '      Txt_diasacobrar.Text = ds_info.Tables(2).Rows(0).Item("Dias")
  '      Txt_importe.Focus()
  '    Else
  '      If ds_info.Tables(0).Rows.Count <> 0 Then
  '        lb_cliente_nomb.InnerText = "Nombre: " + ds_info.Tables(0).Rows(0).Item("Nombre")
  '        Txt_importe.Focus()
  '      Else
  '        'no existe, emitir un mensaje.
  '        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_noexiste", "$(document).ready(function () {$('#modal-sm_error_noexiste').modal();});", True)
  '      End If


  '    End If
  '  Else
  '    'no existe, emitir un mensaje.
  '    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_noexiste", "$(document).ready(function () {$('#modal-sm_error_noexiste').modal();});", True)
  '  End If


  'Catch ex As Exception
  '  'mensaje ingrese fecha para buscar.
  '  'no existe, emitir un mensaje.
  '  ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_fecha", "$(document).ready(function () {$('#modal-sm_error_fecha').modal();});", True)
  'End Try


  '  End Sub
  '
#Region "INIT"
  'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
  'Private Sub Txt_cliente_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_codigo.Init
  '  Txt_cliente_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
  'End Sub

  'Private Sub txt_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fecha.Init
  '  txt_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
  'End Sub

  'Private Sub Txt_importe_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_importe.Init
  '  Txt_importe.Attributes.Add("onfocus", "seleccionarTexto(this);")
  'End Sub

  'Private Sub Txt_porcentaje_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_porcentaje.Init
  '  Txt_porcentaje.Attributes.Add("onfocus", "seleccionarTexto(this);")
  'End Sub

  'Private Sub Txt_diasacobrar_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_diasacobrar.Init
  '  Txt_diasacobrar.Attributes.Add("onfocus", "seleccionarTexto(this);")
  'End Sub

#End Region

#Region "modal-sm_error_noexiste"
  Private Sub btn_close_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_noexiste.ServerClick
    'Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_ok_error_noexiste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_noexiste.ServerClick
    ' Txt_cliente_codigo.Focus()
  End Sub
#End Region

#Region "modal-sm_error_fecha"
  Private Sub btn_close_error_fecha_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_fecha.ServerClick
    ' txt_fecha.Focus()
  End Sub

  Private Sub btn_ok_error_fecha_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_fecha.ServerClick
    'txt_fecha.Focus()
  End Sub
#End Region

  Private Sub limpiar_label_error()
    'lb_error_codigo.Visible = False
    'lb_error_fecha.Visible = False
    'lb_error_importe.Visible = False
    'lb_error_porcentaje.Visible = False
    'lb_error_dias.Visible = False
  End Sub

  Private Sub BOTON_GRABA_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABA.ServerClick
    'limpiar_label_error()
    'Dim valido_ingreso As String = "si"

    'If Txt_cliente_codigo.Text = "" Then
    '  valido_ingreso = "no"
    '  lb_error_codigo.Visible = True
    'End If

    'If txt_fecha.Text = "" Then
    '  valido_ingreso = "no"
    '  lb_error_fecha.Visible = True
    'Else
    '  Try
    '    Dim fecha As Date = CDate(txt_fecha.Text)
    '  Catch ex As Exception
    '    valido_ingreso = "no"
    '    lb_error_fecha.Visible = True
    '  End Try
    'End If

    'Dim importe As Decimal
    'Try
    '  importe = CDec(Txt_importe.Text.Replace(".", ","))
    'Catch ex As Exception
    '  valido_ingreso = "no"
    '  lb_error_importe.Visible = True
    'End Try

    'Dim porcentaje As Decimal
    'Try
    '  porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))
    'Catch ex As Exception
    '  porcentaje = CDec(0)
    '  lb_error_porcentaje.Visible = True
    '  valido_ingreso = "no"
    'End Try

    'Dim dias As Integer = 0
    'If Txt_diasacobrar.Text = "" Or Txt_diasacobrar.Text = "0" Then
    '  valido_ingreso = "no"
    '  lb_error_dias.Visible = True
    'End If
    'Try
    '  dias = CInt(Txt_diasacobrar.Text)
    'Catch ex As Exception
    '  valido_ingreso = "no"
    '  lb_error_dias.Visible = True
    'End Try

    'If valido_ingreso = "si" Then
    '  Try
    '    Dim ds_info As DataSet = DAprestamoscreditos.Creditos_buscar_cliente_info(Txt_cliente_codigo.Text, txt_fecha.Text)
    '    If ds_info.Tables(0).Rows.Count <> 0 Then 'verifico que existe el cliente
    '      Session("Cliente") = ds_info.Tables(0).Rows(0).Item("Cliente")
    '      If ds_info.Tables(2).Rows.Count <> 0 Then
    '        'entonces pregunto si quiero modificar el prestamo actual.
    '        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba_modif", "$(document).ready(function () {$('#Mdl_graba_modif').modal();});", True)
    '      Else
    '        'entonces es un alta para ello primero valido si tengo margen para pedir creditos

    '        Dim cant_pc As Integer = CInt(ds_info.Tables(0).Rows(0).Item("Cantidadpc"))

    '        If ds_info.Tables(1).Rows.Count < cant_pc Then
    '          'entonces pregunto si deseo dar de alta el prestamo.
    '          ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba_alta", "$(document).ready(function () {$('#Mdl_graba_alta').modal();});", True)
    '        Else
    '          'mensaje: Cantidad máxima. No puede solicitar un prestamo.

    '          ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_limite", "$(document).ready(function () {$('#modal-sm_error_limite').modal();});", True)
    '        End If

    '      End If
    '    End If


    '  Catch ex As Exception

    '  End Try
    'Else
    '  'mensaje ingrese la informacion solicitada.
    '  ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_ingreso", "$(document).ready(function () {$('#modal-sm_error_ingreso').modal();});", True)
    'End If


  End Sub


#Region "Mdl_graba_alta"
  Private Sub btn_graba_alta_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_close.ServerClick
    'Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_graba_alta_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_cancelar.ServerClick
    'Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_graba_alta_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_alta_confirmar.ServerClick
    ''aqui codigo de alta.
    'Dim importe As Decimal
    'Try
    '  importe = CDec(Txt_importe.Text.Replace(".", ","))

    'Catch ex As Exception
    '  importe = CDec(0)
    'End Try
    'Dim porcentaje As Decimal

    'Try
    '  porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))

    'Catch ex As Exception
    '  porcentaje = CDec(0)
    'End Try

    'Dim Saldo As Decimal = CDec(importe) * CDec(porcentaje)
    'Dim Cuota_valor As Decimal = (importe * porcentaje) / CInt(Txt_diasacobrar.Text)
    'DAprestamoscreditos.Creditos_alta(CInt(Session("Cliente")), txt_fecha.Text, importe, porcentaje, Txt_diasacobrar.Text, Saldo, Cuota_valor)

    'ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
  End Sub
#End Region

#Region "modal-sm_OKGRABADO"
  Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
    Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
  End Sub

  Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
    Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
  End Sub
#End Region

#Region "modal-sm_error_ingreso"
  Private Sub btn_close_error_ingreso_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_ingreso.ServerClick
    ' Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_ok_error_ingreso_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_ingreso.ServerClick
    ' Txt_cliente_codigo.Focus()
  End Sub
#End Region


#Region "Mdl_graba_modif"
  Private Sub btn_graba_modif_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_cancelar.ServerClick
    ' Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_graba_modif_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_close.ServerClick
    ' Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_graba_modif_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_modif_confirmar.ServerClick
    ''aqui codigo de alta.
    'Dim importe As Decimal
    'Try
    '  importe = CDec(Txt_importe.Text.Replace(".", ","))
    'Catch ex As Exception
    '  importe = CDec(0)
    'End Try

    'Dim porcentaje As Decimal
    'Try
    '  porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))
    'Catch ex As Exception
    '  porcentaje = CDec(0)
    'End Try
    'Dim Saldo As Decimal = CDec(importe) * CDec(porcentaje)
    'Dim Cuota_valor As Decimal = (importe * porcentaje) / CInt(Txt_diasacobrar.Text)
    'DAprestamoscreditos.Creditos_modificar(CInt(Session("Cliente")), txt_fecha.Text, importe, porcentaje, Txt_diasacobrar.Text, Saldo, 1, Cuota_valor)
    'ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
  End Sub
#End Region

#Region "modal-sm_error_limite"
  Private Sub btn_close_error_limite_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_limite.ServerClick
    'Txt_cliente_codigo.Focus()
  End Sub

  Private Sub btn_ok_error_limite_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_limite.ServerClick
    'Txt_cliente_codigo.Focus()
  End Sub






#End Region



End Class
