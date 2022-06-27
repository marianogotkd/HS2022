Public Class Cobro_PrestamosxRegalos_det
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DAprestamoscreditos As New Capa_Datos.WC_prestamoscreditos
  Dim DActacte As New Capa_Datos.WC_CtaCte
  Dim DACliente As New Capa_Datos.WB_clientes
#End Region

#Region "EVENTOS"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      'VALIDACION: Verificar en BD cual es el dia de la ultima liquidacion en tabla PARAMETRO, donde el campo Estado= "Inactivo"
      Dim ds_parametro As DataSet = DAparametro.Parametro_consultar_ultliq
      If ds_parametro.Tables(0).Rows.Count <> 0 Then
        HF_parametro_id.Value = ds_parametro.Tables(0).Rows(0).Item("Parametro_id")
        HF_fecha.Value = ds_parametro.Tables(0).Rows(0).Item("Fecha")
        Dim FECHA As Date = CDate(ds_parametro.Tables(0).Rows(0).Item("Fecha"))
        LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")
        Metodo1()
      Else
        'error, no hay liquidacion completada
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If
    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub


#End Region

#Region "METODOS"
  Private Sub Metodo1()
    Dim DS_cobro_prestamos_regalos As New DS_cobro_prestamos_regalos
    DS_cobro_prestamos_regalos.Tables("CobPrestRegalo").Rows.Clear()


    Dim ds_prestamos As DataSet = DAprestamoscreditos.Prestamos_obtener_prestamosxregalo
    If ds_prestamos.Tables(0).Rows.Count <> 0 Then
      Dim i As Integer = 0
      While i < ds_prestamos.Tables(0).Rows.Count
        'POR CADA PRESTAMOS: evaluar si el cliente tuvo movimiento de cobro de regalos dbo.CtaCte.Regalos.
        Dim Cliente_ID As Integer = ds_prestamos.Tables(0).Rows(i).Item("Cliente_ID")
        Dim Cliente_Codigo As Integer = CInt(ds_prestamos.Tables(0).Rows(i).Item("Cliente_Codigo"))
        Dim Fecha_prestamo As Date = CDate(ds_prestamos.Tables(0).Rows(i).Item("Fecha"))
        Dim Idprestamocredito As Integer = ds_prestamos.Tables(0).Rows(i).Item("Idprestamocredito")
        Dim ds_ctacte As DataSet = DActacte.CtaCte_obtener(Cliente_Codigo, HF_fecha.Value) 'la fecha es la de la ultima liquidacion 
        If ds_ctacte.Tables(0).Rows.Count <> 0 Then
          'verifico si CtaCte.Regalos es <> 0, NOTA:Si el prestamo fue dado de alta en la fecha del dia a liquidar no deberia ejecutarse ningun cobro.
          If Fecha_prestamo <> CDate(HF_fecha.Value) Then
            Dim CtaCte_Regalos As Decimal = 0
            Dim IdCtaCte As Integer = ds_ctacte.Tables(0).Rows(0).Item("IdCtaCte")
            Try
              CtaCte_Regalos = CDec(ds_ctacte.Tables(0).Rows(0).Item("Regalos"))
            Catch ex As Exception
              CtaCte_Regalos = CDec(0)
            End Try
            If CtaCte_Regalos <> CDec(0) Then
              'tuvo movimiento en regalos
              '------------------------------------------------------------------------------------------------------------
              'dbo.CobroPrestamosCreditos.Importe = dbo.CtaCte.Regalos * dbo.PrestamosCreditos.Porcentaje
              '(hay que revisar el saldo que le queda al prestamo dbo.PrestamosCreditos.Saldo ya que el
              'cobro no puede ser mayor al saldo que le queda al prestamo)
              Dim PrestamosCreditos_Porcentaje As Decimal = ds_prestamos.Tables(0).Rows(i).Item("Porcentaje")
              Dim PrestamosCreditos_Saldo As Decimal = ds_prestamos.Tables(0).Rows(i).Item("Saldo")
              Dim importe As Decimal = Math.Abs((CtaCte_Regalos * PrestamosCreditos_Porcentaje) / 100) 'ponemos valor absoluto x que el resultado es negativo
              Dim importe_absoluto As Decimal = Math.Abs(importe)

              Dim Estado_id As Integer = 1 '1 activo, 2 cancelado, 3 baja
              If importe > PrestamosCreditos_Saldo Then
                importe = PrestamosCreditos_Saldo
              End If
              '/////////////////////////////////////////////////////////
              'AQUI GUARDO EN BD
              DAprestamoscreditos.CobroPrestamosCreditos_alta(Idprestamocredito, HF_fecha.Value, importe)
              '/////////////////////////////////////////////////////////
              '------------------------------------------------------------------------------------------------------------
              'Actualizar el saldo del prestamo dbo.PrestamosCreditos.Saldo = dbo.PrestamosCreditos.Saldo - dbo.CobroPrestamoCredito.Importe
              '(si el cobro del prestamo cancela el saldo es decir el total del prestamo se deberia
              'marcar este prestamo como "Cancelado" dbo.PrestamosCreditos.Estado = C)
              PrestamosCreditos_Saldo = PrestamosCreditos_Saldo - importe
              If (PrestamosCreditos_Saldo = 0) Or (PrestamosCreditos_Saldo < 0) Then
                PrestamosCreditos_Saldo = 0
                'esta cancelado el prestamo
                Estado_id = 2
              End If

              '/////////////////////////////////////////////////////////
              'AQUI GUARDO EN BD
              DAprestamoscreditos.PrestamosCreditos_ActualizarSaldo(Idprestamocredito, PrestamosCreditos_Saldo, Estado_id)
              '/////////////////////////////////////////////////////////

              '------------------------------------------------------------------------------------------------------------
              'Actualizar el campo dbo.CtaCte.CobPrestamo = dbo.CtaCte.CobPrestamo + dbo.CobroPrestamosCreditos.Importe

              Dim CobPrestamo As Decimal = 0
              Try 'el try lo uso x que el campo recuperado de ctacte es null
                CobPrestamo = ds_ctacte.Tables(0).Rows(0).Item("CobPrestamo") + importe
              Catch ex As Exception
                CobPrestamo = importe
              End Try

              '/////////////////////////////////////////////////////////
              'AQUI GUARDO EN BD
              DActacte.CtaCte_actualizarCobPrestamo(IdCtaCte, CobPrestamo)
              '/////////////////////////////////////////////////////////

              '------------------------------------------------------------------------------------------------------------
              'Actualizar el saldo dbo.Clientes.Saldo = dbo.Clientes.Saldo + dbo.CtaCte.CobPrestamo
              DACliente.Cliente_ActualizarSaldo_ctacte(Cliente_ID, importe)
              '-----------------------------------------------------------------------------------------------------------

              Dim fila As DataRow = DS_cobro_prestamos_regalos.Tables("CobPrestRegalo").NewRow
              fila("Cliente") = CInt(Cliente_Codigo)
              fila("Fecha_Ori") = HF_fecha.Value
              fila("Importe") = (Math.Round(importe, 2).ToString("N2"))
              fila("Saldo") = (Math.Round(PrestamosCreditos_Saldo, 2).ToString("N2"))

              DS_cobro_prestamos_regalos.Tables("CobPrestRegalo").Rows.Add(fila)

            Else
              'no tuvo ningun movimiento en CtaCte para la fecha indicada.
            End If
          Else
            'no cobro, es prestamo se genero la misma fecha
          End If
        Else
          'no tuvo ningun movimiento en CtaCte para la fecha indicada.
        End If

        i = i + 1
      End While



    Else
      'error, no hay prestamos x regalo
    End If

    GridView1.DataSource = DS_cobro_prestamos_regalos.Tables("CobPrestRegalo")
    GridView1.DataBind()

    If GridView1.Rows.Count = 0 Then
      Label_noregalos.Visible = True
    End If

  End Sub




#End Region


End Class
