Public Class carga_recorridos_zonas_b
    Inherits System.Web.UI.Page
    Dim DArecorrido As New Capa_Datos.WC_recorridos_zonas
    Dim Dapuntos As New Capa_Datos.WC_puntos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HF_idrecorrido.Value = Session("id_recorrido")
            HF_fecha.Value = Session("fecha")
            Dim ds_info As DataSet = DArecorrido.recorridos_zonas_obtener_info_zona(Session("id_recorrido"), Session("fecha"))
            If ds_info.Tables(0).Rows.Count <> 0 Then
                txt_zona.Text = ds_info.Tables(0).Rows(0).Item("Codigo").ToString.ToUpper + "-" + ds_info.Tables(0).Rows(0).Item("Referencia").ToString.ToUpper
            End If
            If ds_info.Tables(1).Rows.Count <> 0 Then
                cargar_puntos(ds_info.Tables(1))
            End If
            txt_01.Focus()
        End If
    End Sub

    Private Sub cargar_puntos(ByVal tabla1 As DataTable)
        txt_01.Text = tabla1.Rows(0).Item("P1")
        txt_02.Text = tabla1.Rows(0).Item("P2")
        txt_03.Text = tabla1.Rows(0).Item("P3")
        txt_04.Text = tabla1.Rows(0).Item("P4")
        txt_05.Text = tabla1.Rows(0).Item("P5")
        txt_06.Text = tabla1.Rows(0).Item("P6")
        txt_07.Text = tabla1.Rows(0).Item("P7")
        txt_08.Text = tabla1.Rows(0).Item("P8")
        txt_09.Text = tabla1.Rows(0).Item("P9")
        txt_10.Text = tabla1.Rows(0).Item("P10")
        txt_11.Text = tabla1.Rows(0).Item("P11")
        txt_12.Text = tabla1.Rows(0).Item("P12")
        txt_13.Text = tabla1.Rows(0).Item("P13")
        txt_14.Text = tabla1.Rows(0).Item("P14")
        txt_15.Text = tabla1.Rows(0).Item("P15")
        txt_16.Text = tabla1.Rows(0).Item("P16")
        txt_17.Text = tabla1.Rows(0).Item("P17")
        txt_18.Text = tabla1.Rows(0).Item("P18")
        txt_19.Text = tabla1.Rows(0).Item("P19")
        txt_20.Text = tabla1.Rows(0).Item("P20")
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_Carga de Recorridos_Zonas/carga_recorridos_zonas_a.aspx")
    End Sub

    Private Sub btn_grabar_cancelar_modal_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_cancelar_modal.ServerClick
        txt_01.Focus()
    End Sub

    Private Sub btn_grabar_pregunta_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_pregunta_close.ServerClick
        txt_01.Focus()
    End Sub

    Private Sub btn_grabar_pregunta_modal_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar_pregunta_modal.ServerClick
        'aqui guardo en bd.

        Dim ds_validar As DataSet = DArecorrido.recorridos_zonas_obtener_info_zona(HF_idrecorrido.Value, HF_fecha.Value)
        If ds_validar.Tables(1).Rows.Count <> 0 Then
            'modifico
            Dapuntos.Puntos_modificar(HF_idrecorrido.Value, HF_fecha.Value,
                                       txt_01.Text, txt_02.Text, txt_03.Text, txt_04.Text, txt_05.Text,
                                       txt_06.Text, txt_07.Text, txt_08.Text, txt_09.Text, txt_10.Text,
                                       txt_11.Text, txt_12.Text, txt_13.Text, txt_14.Text, txt_15.Text,
                                       txt_16.Text, txt_17.Text, txt_18.Text, txt_19.Text, txt_20.Text)
        Else
            'alta
            Dapuntos.Puntos_alta(HF_idrecorrido.Value, HF_fecha.Value,
                                       txt_01.Text, txt_02.Text, txt_03.Text, txt_04.Text, txt_05.Text,
                                       txt_06.Text, txt_07.Text, txt_08.Text, txt_09.Text, txt_10.Text,
                                       txt_11.Text, txt_12.Text, txt_13.Text, txt_14.Text, txt_15.Text,
                                       txt_16.Text, txt_17.Text, txt_18.Text, txt_19.Text, txt_20.Text)
        End If

        'aqui mensaje de guardado, el ok o close deben volver a el form: "carga_recorridos_zonas_a.aspx"
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_ok_grabado", "$(document).ready(function () {$('#modal_ok_grabado').modal();});", True)
    End Sub

    Private Sub btn_ok_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_close.ServerClick
        Response.Redirect("~/WC_Carga de Recorridos_Zonas/carga_recorridos_zonas_a.aspx")
    End Sub

    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("~/WC_Carga de Recorridos_Zonas/carga_recorridos_zonas_a.aspx")
    End Sub


#Region "init"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_zona_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_zona.Init
        txt_zona.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_01_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_01.Init
        txt_01.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_02_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_02.Init
        txt_02.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_03_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_03.Init
        txt_03.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_04_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_04.Init
        txt_04.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_05_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_05.Init
        txt_05.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_06_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_06.Init
        txt_06.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_07_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_07.Init
        txt_07.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_08_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_08.Init
        txt_08.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_09_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_09.Init
        txt_09.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_10_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_10.Init
        txt_10.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_11_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_11.Init
        txt_11.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_12_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_12.Init
        txt_12.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_13_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_13.Init
        txt_13.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_14_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_14.Init
        txt_14.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_15_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_15.Init
        txt_15.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_16_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_16.Init
        txt_16.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_17_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_17.Init
        txt_17.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_18_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_18.Init
        txt_18.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_19_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_19.Init
        txt_19.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub txt_20_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_20.Init
        txt_20.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub


#End Region

    
End Class