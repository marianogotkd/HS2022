Public Class abml_prestamoscreditos_resumen
    Inherits System.Web.UI.Page

    Dim DAprestamoscreditos As New Capa_Datos.WC_prestamoscreditos
    Dim Daparametro As New Capa_Datos.WC_parametro

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Txt_cliente_codigo.Focus()
            'recuperar fecha de tabla parametro.
            Dim ds_fecha As DataSet = Daparametro.Parametro_obtener_dia
            If ds_fecha.Tables(0).Rows.Count <> 0 Then
                Dim FECHA As Date = CDate(ds_fecha.Tables(0).Rows(0).Item("Fecha"))
                Hf_FECHA.Value = FECHA
                txt_fecha.Text = FECHA.ToString("yyyy-MM-dd")
                obtener_resumen(FECHA)

                txt_fecha.Focus()
            End If

        End If
    End Sub

    Dim DS_prestamoscreditos As New DS_prestamoscreditos
    Private Sub obtener_resumen(ByVal Fecha As Date)
        DS_prestamoscreditos.Tabla1.Rows.Clear()

        GridView1.Columns(0).Visible = True 'columna ID
        GridView1.Columns(10).Visible = True 'columna ID
        GridView1.Columns(10).Visible = True 'columna ID

        Dim ds_info As DataSet = DAprestamoscreditos.PrestamosCreditos_resumen(Fecha)
        If ds_info.Tables(0).Rows.Count <> 0 Then
            Dim i As Integer = 0
            While i < ds_info.Tables(0).Rows.Count
                Dim fila As DataRow = DS_prestamoscreditos.Tabla1.NewRow
                fila("ID") = ds_info.Tables(0).Rows(i).Item("ID")

                Select Case ds_info.Tables(0).Rows(i).Item("Tipo")
                    Case "P"
                        fila("Tipo") = "Pre."
                    Case "C"
                        fila("Tipo") = "Cre."
                End Select

                fila("Cliente") = ds_info.Tables(0).Rows(i).Item("Codigo")
                fila("Nombre") = ds_info.Tables(0).Rows(i).Item("Nombre")
                fila("Importe") = CStr(ds_info.Tables(0).Rows(i).Item("Importe"))
                fila("Porcentaje") = CStr(ds_info.Tables(0).Rows(i).Item("%"))

                Select Case ds_info.Tables(0).Rows(i).Item("Tipocobro")
                    Case "1"
                        fila("Cobro") = "% Comision"
                    Case "2"
                        fila("Cobro") = "% Regalo"
                    Case "3"
                        fila("Cobro") = "A descontar manual"
                    Case Else
                        'mostrar cantidad de dias en los cuales se cobrará el credito
                        fila("Cobro") = CStr(ds_info.Tables(0).Rows(i).Item("Dias")) + " dias"
                End Select

                fila("Fecha") = ds_info.Tables(0).Rows(i).Item("Fecha")

                fila("Saldo") = ds_info.Tables(0).Rows(i).Item("Saldo")

                fila("Estado") = ds_info.Tables(0).Rows(i).Item("Estado")

                DS_prestamoscreditos.Tabla1.Rows.Add(fila)
                i = i + 1
            End While

            'GridView1.DataSource = DS_prestamoscreditos.Tabla1
            'GridView1.DataBind()
        End If
        GridView1.DataSource = DS_prestamoscreditos.Tabla1
        GridView1.DataBind()

        GridView1.Columns(0).Visible = False '0 es columna ID

        Try
            If CDate(Hf_FECHA.Value) <> CDate(txt_fecha.Text) Then
                GridView1.Columns(10).Visible = False '10 es columna eliminar
            End If

            If CDate(txt_fecha.Text) >= CDate(Hf_FECHA.Value) Then
                GridView1.Columns(11).Visible = False '11 es columna dar de baja
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/WC_ABML Prestamos_Creditos/abml_prestamoscreditos.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            Session("ID") = id

            'aqui pregunto si estoy seguro de eliminar.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_eliminar", "$(document).ready(function () {$('#Mdl_eliminar').modal();});", True)
        Else
            If (e.CommandName = "ID_baja") Then
                ' Retrieve the row index stored in the CommandArgument property.
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
                'Session("usuario_id") = id
                'Response.Redirect("Mensaje_Datos_Personales.aspx")
                Session("ID") = id

                'aqui pregunto si estoy seguro de eliminar.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "Mdl_baja", "$(document).ready(function () {$('#Mdl_baja').modal();});", True)
            End If
        End If
    End Sub
    
#Region "BOTON ELIMINAR"
    Private Sub btn_eliminar1_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar1_close.ServerClick
        'nada
    End Sub
    Private Sub btn_eliminar_mdl_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar_mdl_cancelar.ServerClick
        'nada
    End Sub
    Private Sub btn_eliminar_mdll_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar_mdll.ServerClick
        Try
            'aqui codigo para eliminar.
            DAprestamoscreditos.PrestamosCreditos_eliminar(Session("ID"))
            Session("ID") = ""
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKELIMINADO", "$(document).ready(function () {$('#modal-sm_OKELIMINADO').modal();});", True)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_ELIMINAR_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ELIMINAR_close.ServerClick
        Try
            'cargo la grilla nuevamente con la info actualizada.
            obtener_resumen(txt_fecha.Text)
            txt_fecha.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_ok_elimnar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_elimnar.ServerClick
        Try
            'cargo la grilla nuevamente con la info actualizada.
            obtener_resumen(txt_fecha.Text)
            txt_fecha.Focus()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "BOTON DAR DE BAJA"

    Private Sub btn_baja_mdll_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_mdll.ServerClick
        Try
            'aqui codigo para eliminar.
            DAprestamoscreditos.PrestamosCreditos_baja(Session("ID"), 3, CDate(txt_fecha.Text))
            Session("ID") = ""
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKBAJA", "$(document).ready(function () {$('#modal-sm_OKBAJA').modal();});", True)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_ok_baja_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_baja.ServerClick
        Try
            'cargo la grilla nuevamente con la info actualizada.
            obtener_resumen(txt_fecha.Text)
            txt_fecha.Focus()
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub btn_BAJA_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_BAJA_close.ServerClick
        Try
            'cargo la grilla nuevamente con la info actualizada.
            obtener_resumen(txt_fecha.Text)
            txt_fecha.Focus()
        Catch ex As Exception

        End Try
        
    End Sub

#End Region


    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        Try
            'habilito la columan ID.
            'habilito la columna Eliminar
            'habilitio la columna dar de baja
            GridView1.Columns(0).Visible = True '0 es columna ID
            GridView1.Columns(10).Visible = True '10 es columna eliminar
            GridView1.Columns(11).Visible = True '11 es columna dar de baja


            DS_prestamoscreditos.Tabla1.Rows.Clear()
            GridView1.DataSource = ""
            Dim ds_info As DataSet = DAprestamoscreditos.PrestamosCreditos_resumen(txt_fecha.Text)
            If ds_info.Tables(0).Rows.Count <> 0 Then
                Dim i As Integer = 0
                While i < ds_info.Tables(0).Rows.Count
                    Dim fila As DataRow = DS_prestamoscreditos.Tabla1.NewRow
                    fila("ID") = ds_info.Tables(0).Rows(i).Item("ID")

                    Select Case ds_info.Tables(0).Rows(i).Item("Tipo")
                        Case "P"
                            fila("Tipo") = "Pre."
                        Case "C"
                            fila("Tipo") = "Cre."
                    End Select

                    fila("Cliente") = ds_info.Tables(0).Rows(i).Item("Codigo")
                    fila("Nombre") = ds_info.Tables(0).Rows(i).Item("Nombre")
                    fila("Importe") = CStr(ds_info.Tables(0).Rows(i).Item("Importe"))
                    fila("Porcentaje") = CStr(ds_info.Tables(0).Rows(i).Item("%"))

                    Select Case ds_info.Tables(0).Rows(i).Item("Tipocobro")
                        Case "1"
                            fila("Cobro") = "% Comision"
                        Case "2"
                            fila("Cobro") = "% Regalo"
                        Case "3"
                            fila("Cobro") = "A descontar manual"
                        Case Else
                            'mostrar cantidad de dias en los cuales se cobrará el credito
                            fila("Cobro") = CStr(ds_info.Tables(0).Rows(i).Item("Dias")) + " dias"
                    End Select
                    fila("Fecha") = ds_info.Tables(0).Rows(i).Item("Fecha")

                    fila("Saldo") = ds_info.Tables(0).Rows(i).Item("Saldo")

                    fila("Estado") = ds_info.Tables(0).Rows(i).Item("Estado")

                    DS_prestamoscreditos.Tabla1.Rows.Add(fila)
                    i = i + 1
                End While

                GridView1.DataSource = DS_prestamoscreditos.Tabla1
                GridView1.DataBind()

                GridView1.Columns(0).Visible = False '10 es columna eliminar
                Try
                    If CDate(Hf_FECHA.Value) <> CDate(txt_fecha.Text) Then
                        GridView1.Columns(10).Visible = False '10 es columna eliminar
                    End If

                    If CDate(txt_fecha.Text) >= CDate(Hf_FECHA.Value) Then
                        GridView1.Columns(11).Visible = False '11 es columna dar de baja
                    End If
                Catch ex As Exception
                End Try


                GridView1.Focus()


            Else
                GridView1.DataSource = DS_prestamoscreditos.Tabla1
                GridView1.DataBind()
                GridView1.Columns(0).Visible = False '0 es columna ID
                GridView1.Columns(10).Visible = False '10 es columna eliminar
                GridView1.Columns(11).Visible = False '11 es columna dar de baja

                'la busqueda no arrojo resultados.
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
                'System.Web.UI.ScriptManager.GetCurrent(Me.Page).SetFocus(Me.btn_ok_error_busqueda)
                'System.Web.UI.ScriptManager.GetCurrent(Me).SetFocus(Me.btn_ok_error_busqueda)

            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal_error_busqueda", "$(document).ready(function () {$('#modal_error_busqueda').modal();});", True)
            'System.Web.UI.ScriptManager.GetCurrent(Me).SetFocus(Me.btn_ok_error_busqueda)
            'System.Web.UI.ScriptManager.GetCurrent(Me.Page).SetFocus(Me.btn_ok_error_busqueda)
        End Try
    End Sub

#Region "modal_error_busqueda"

    

    Private Sub btn_ok_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error_busqueda.ServerClick
        txt_fecha.Focus()
    End Sub

    Private Sub btn_close_error_busqueda_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error_busqueda.ServerClick
        txt_fecha.Focus()
    End Sub
#End Region


#Region "INIT"
    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fecha.Init
        txt_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub
#End Region
    





End Class