Public Class LiquidacionRegalosSemanal_det
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
  Dim DAliquidacion As New Capa_Datos.WC_Liquidacion
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

      End If
    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

#End Region

#Region "METODOS"
  Private Sub Metodo1()
    'Buscar todos los clientes que tengan en el campo dbo.clientes.Proceso = "S".
    Dim ds_clientes As DataSet = DAliquidacion.LiquidacionRegalos_obtener_ClieSemanal
    If ds_clientes.Tables(0).Rows.Count <> 0 Then

      Dim i As Integer = 0
      While i < ds_clientes.Tables(0).Rows.Count
        Dim Cliente_ID As Integer = CInt(ds_clientes.Tables(0).Rows(i).Item("Cliente"))
        Dim Cliente_Codigo As Integer = CInt(ds_clientes.Tables(0).Rows(i).Item("Codigo"))
        Dim SaldoRegalo As Decimal = CDec(ds_clientes.Tables(0).Rows(i).Item("SaldoRegalo"))

        'Buscar todos los clientes que en el campo dbo.Clientes.SaldoRegalo tengan un valor en negativo. 
        If SaldoRegalo < 0 Then
          'obtener cta cta para la fecha de la ultima liquidacion completada.
          Dim ds_ctacte As DataSet = DAliquidacion.LiquidacionRegalos_obtenerctacte(Cliente_Codigo, HF_fecha.Value)
          Dim IdCtaCte As Integer = 0
          If ds_ctacte.Tables(0).Rows.Count <> 0 Then
            IdCtaCte = ds_ctacte.Tables(0).Rows(0).Item("IdCtaCte")
            'dbo.CtaCte.Regalos = dbo.Clientes.SaldoRegalo
            Dim CtaCte_Regalos As Decimal = SaldoRegalo
            DAliquidacion.LiquidacionRegalosSemanal_actualizarCtaCte(IdCtaCte, CtaCte_Regalos)

            '            dbo.Clientes.SaldoRegalo = 0
            '           dbo.Clientes.Saldo = dbo.Clientes.Saldo - dbo.CtaCte.Regalos.
            SaldoRegalo = 0
            Dim Clientes_Saldo As Decimal = ds_clientes.Tables(0).Rows(i).Item("Saldo")
            Clientes_Saldo = Clientes_Saldo + CtaCte_Regalos

            DAliquidacion.LiquidacionRegalosSemanal_actualizarClie(Cliente_ID, SaldoRegalo, Clientes_Saldo)


          Else
            'si no existe, creo un registro en ctacte?

          End If

        End If

        i = i + 1
      End While


      Dim ds_clie As DataSet = DAliquidacion.LiquidacionRegalos_obtener_ClieSemanal
      If ds_clie.Tables(0).Rows.Count <> 0 Then

        Dim DS_liqregalos As New DS_liqregalos
        DS_liqregalos.Tables("Semanal").Rows.Clear()

        Dim filaa As DataRow = DS_liqregalos.Tables("Semanal").NewRow
        filaa("Cliente") = "Cliente"
        filaa("Monto_Favor") = ""
        filaa("Favor") = ""
        filaa("Contra") = ""
        filaa("Monto_Contra") = ""
        DS_liqregalos.Tables("Semanal").Rows.Add(filaa)

        Dim ii As Integer = 0
        While ii < ds_clie.Tables(0).Rows.Count
          Dim Cliente_Codigo As Integer = CInt(ds_clie.Tables(0).Rows(ii).Item("Codigo"))
          Dim CLiente_SaldoRegalo As Decimal = CDec(ds_clie.Tables(0).Rows(ii).Item("SaldoRegalo"))
          If CLiente_SaldoRegalo <> CDec(0) Then '- NO HACE FALTA MOSTRAR TODOS LOS CLIENTES QUE TENGAN LA CONDICION QUE SE LIQUIDO SI EL dbo.clientes.SaldoRegalo = 0
            Dim ds_ctacte As DataSet = DAliquidacion.LiquidacionRegalos_obtenerctacte(Cliente_Codigo, HF_fecha.Value)
            Dim IdCtaCte As Integer = 0
            Dim Monto_contra As String = ""
            Dim Monto_favor As String = ""
            Dim Contra As String = ""
            Dim Favor As String = ""
            If ds_ctacte.Tables(0).Rows.Count <> 0 Then
              If ds_ctacte.Tables(0).Rows(0).Item("Regalos") <> CDec(0) Then
                Monto_favor = CStr(ds_ctacte.Tables(0).Rows(0).Item("Regalos"))
                Favor = "A FAVOR"
              Else
                Monto_contra = CStr(CLiente_SaldoRegalo)
                Contra = "EN CONTRA"
              End If

            Else
              Monto_contra = CStr(CLiente_SaldoRegalo)
              Contra = "EN CONTRA"
            End If
            Dim fila As DataRow = DS_liqregalos.Tables("Semanal").NewRow
            fila("Cliente") = CStr(Cliente_Codigo)
            fila("Monto_Favor") = Monto_favor
            fila("Favor") = Favor
            fila("Contra") = Contra
            fila("Monto_Contra") = Monto_contra
            DS_liqregalos.Tables("Semanal").Rows.Add(fila)
          End If

          ii = ii + 1
        End While

        If DS_liqregalos.Tables("Semanal").Rows.Count > 1 Then
          'si es mayor a 1 entonces hay varios registros...voy a calcular el total
          Dim Total As Decimal = CDec(0)
          Dim j As Integer = 1
          While j < DS_liqregalos.Tables("Semanal").Rows.Count
            Dim Monto_Favor As Decimal = 0
            Try
              Monto_Favor = CDec(DS_liqregalos.Tables("Semanal").Rows(j).Item("Monto_Favor"))
            Catch ex As Exception
              Monto_Favor = 0
            End Try
            Total = Total + Monto_Favor
            j = j + 1
          End While
          Dim fila1 As DataRow = DS_liqregalos.Tables("Semanal").NewRow
          fila1("Cliente") = "TOTAL:"
          fila1("Monto_Favor") = CStr(Total)
          fila1("Favor") = ""
          fila1("Contra") = ""
          fila1("Monto_Contra") = ""
          DS_liqregalos.Tables("Semanal").Rows.Add(fila1)
        End If

        GridView1.DataSource = DS_liqregalos.Tables("Semanal")
        GridView1.DataBind()

      End If


    Else
      'aqui msj?
      Label_noregalos.Visible = True
    End If
  End Sub

#End Region


End Class
