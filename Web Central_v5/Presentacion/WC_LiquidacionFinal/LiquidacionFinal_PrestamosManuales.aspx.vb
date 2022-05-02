Public Class LiquidacionFinal_PrestamosManuales
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


      'Luego de continuar se deberia revisar si hubo alguna carga de algun cobro de prestamo manual,
      'revisar si hay algun registro en dbo.CobroPrestamosCreditos.Fecha = fecha del parametro.
      'De haber algun registro perteneciente al dia se deberia ejecutar el proceso de actualizacion de cobro prestamo manual.
      Dim DS_liqfinal As New DS_liqfinal
      DS_liqfinal.Tables("PrestamosManuales").Rows.Clear()

      Dim ds_cobroprestamos As DataSet = DaPrestamosCreditos.CobroPrestamosCreditos_LiqObtener(HF_fecha.Value)



      Dim i As Integer = 0
      While i < ds_cobroprestamos.Tables(0).Rows.Count
        Dim IdPrestamoCredito As Integer = ds_cobroprestamos.Tables(0).Rows(i).Item("IdPrestamoCredito")
        Dim CobroPrestamoCredito_Importe As Decimal = ds_cobroprestamos.Tables(0).Rows(i).Item("Importe")
        Dim ds_prestamo As DataSet = DaPrestamosCreditos.PrestamosCreditos_obtenerXid(IdPrestamoCredito)
        Dim Cliente_ID As Integer = ds_cobroprestamos.Tables(0).Rows(i).Item("Cliente_ID")
        Dim Cliente_Codigo As String = ds_cobroprestamos.Tables(0).Rows(i).Item("Cliente_Codigo")
        Dim PrestamosCreditos_Saldo As Decimal = CDec(ds_prestamo.Tables(0).Rows(0).Item("Saldo")) - CobroPrestamoCredito_Importe
        PrestamosCreditos_Saldo = (Math.Round(PrestamosCreditos_Saldo, 2).ToString("N2"))
        Dim FechaPrestamo_Ori As Date = ds_prestamo.Tables(0).Rows(0).Item("Fecha")
        Dim Prestamo As Decimal = ds_prestamo.Tables(0).Rows(0).Item("Importe")
        Dim Estado_id As Integer = 1 '1 activo, 2 cancelado, 3 baja
        If (PrestamosCreditos_Saldo = 0) Or (PrestamosCreditos_Saldo < 0) Then
          PrestamosCreditos_Saldo = 0
          'esta cancelado el prestamo
          Estado_id = 2
        End If

        'guardo en bd------
        DaPrestamosCreditos.PrestamosCreditos_ActualizarSaldo(IdPrestamoCredito, PrestamosCreditos_Saldo, Estado_id)
        '------------------

        'Actualizar el campo dbo.CtaCte.CobPrestamo = dbo.CtaCte.CobPrestamo + dbo.CobroPrestamosCreditos.Importe
        'nota: como puede no existir el registro con la fecha del dia para el cliente en ctacte, tengo q validar. en caso de no existir hago un alta.
        Dim ds_ctacte As DataSet = DACtaCte.CtaCte_obtener(CInt(Cliente_Codigo), HF_fecha.Value)
        Dim IdCtaCte As Integer = ds_ctacte.Tables(0).Rows(0).Item("IdCtaCte")
        If ds_ctacte.Tables(0).Rows.Count <> 0 Then
          'existe, se actualiza.
          Dim CobPrestamo As Decimal = 0
          Try 'el try lo uso x que el campo recuperado de ctacte es null
            CobPrestamo = ds_ctacte.Tables(0).Rows(0).Item("CobPrestamo") + CobroPrestamoCredito_Importe
          Catch ex As Exception
            CobPrestamo = CobroPrestamoCredito_Importe
          End Try

          DACtaCte.CtaCte_actualizarCobPrestamo(IdCtaCte, CobPrestamo)
        Else
          'no existe, se crea un registro.

        End If
        '---------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------

        'Actualizar el saldo dbo.Clientes.Saldo = dbo.Clientes.Saldo + dbo.CtaCte.CobPrestamo
        DACliente.Cliente_ActualizarSaldo_ctacte(Cliente_ID, IdCtaCte)
        '---------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------


        'agrego 1 registro al datatable q voy a mandar al proximo formulario.
        Dim fila As DataRow = DS_liqfinal.Tables("PrestamosManuales").NewRow
        fila("Cliente") = CInt(Cliente_Codigo)
        fila("Fecha_Ori") = FechaPrestamo_Ori.ToString("dd-MM-yyyy")


        fila("Importe_Cob") = CobroPrestamoCredito_Importe
        fila("Saldo") = PrestamosCreditos_Saldo
        fila("Prestamo") = Prestamo
        DS_liqfinal.Tables("PrestamosManuales").Rows.Add(fila)

        '---------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------

        i = i + 1
      End While

      'ahora muestro DS_liqfinal.tables("PrestamosManuales") en un gridview.


      GridView1.DataSource = DS_liqfinal.Tables("PrestamosManuales")
      GridView1.DataBind()



    End If





  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    'Mdl_CobroPrestamosxComision
    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_CobroPrestamosxComision", "$(document).ready(function () {$('#Mdl_CobroPrestamosxComision').modal();});", True)
  End Sub

#End Region


End Class
