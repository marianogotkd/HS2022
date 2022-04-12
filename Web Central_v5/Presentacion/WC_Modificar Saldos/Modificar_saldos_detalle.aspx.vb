Public Class Modificar_saldos_detalle
    Inherits System.Web.UI.Page
    Dim DAcliente As New Capa_Datos.WB_clientes
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'recupero info del cliente
            HF_cliente_id.Value = Session("cliente_id")
            Dim ds_info As DataSet = DAcliente.Clientes_buscar_id(Session("cliente_id"))
            If ds_info.Tables(0).Rows.Count <> 0 Then
                Txt_cliente_codigo.Text = ds_info.Tables(0).Rows(0).Item("Codigo")
                Txt_cliente_nomb.Text = ds_info.Tables(0).Rows(0).Item("Nombre")
                Txt_Saldos.Text = CDec(ds_info.Tables(0).Rows(0).Item("Saldo"))
                Txt_regalo.Text = CDec(ds_info.Tables(0).Rows(0).Item("SaldoRegalo"))
            End If
            Txt_Saldos.Focus()
            Txt_cliente_codigo.ReadOnly = True
            Txt_cliente_nomb.ReadOnly = True
        End If
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_Modificar Saldos/Modificar_saldos.aspx")
    End Sub


#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub Txt_cliente_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_codigo.Init
        Txt_cliente_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_cliente_nomb1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_cliente_nomb.Init
        Txt_cliente_nomb.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_Saldos_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Saldos.Init
        Txt_Saldos.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_regalo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_regalo.Init
        Txt_regalo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
#End Region

#Region "Mdl_graba"
    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Txt_Saldos.Focus()
    End Sub

    Private Sub btn_graba_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_cancelar.ServerClick
        Txt_Saldos.Focus()

    End Sub

    Private Sub btn_graba_confirmar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_confirmar.ServerClick
        Dim Saldo As Decimal
        Dim SaldoRegalo As Decimal

        Try
            Saldo = CDec(Txt_Saldos.Text.Replace(".", ","))
            
        Catch ex As Exception
            Saldo = CDec(0)
        End Try

        Try
            SaldoRegalo = CDec(Txt_regalo.Text.Replace(".", ","))
        Catch ex As Exception
            SaldoRegalo = CDec(0)
        End Try
        'aqui guardo
        DAcliente.Clientes_modificar_saldos(HF_cliente_id.Value, Saldo, SaldoRegalo)
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)
    End Sub
#End Region

#Region "modal-sm_OKGRABADO"
    Private Sub btn_okgraba_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_okgraba.ServerClick
        'redirecciono
        Response.Redirect("~/WC_Modificar Saldos/Modificar_saldos.aspx")
    End Sub

    Private Sub btn_okgraba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_okgraba_close.ServerClick
        'redirecciono
        Response.Redirect("~/WC_Modificar Saldos/Modificar_saldos.aspx")
    End Sub
#End Region

    
    Private Sub BOTON_GRABA_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABA.ServerClick
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_graba", "$(document).ready(function () {$('#Mdl_graba').modal();});", True)
    End Sub
End Class