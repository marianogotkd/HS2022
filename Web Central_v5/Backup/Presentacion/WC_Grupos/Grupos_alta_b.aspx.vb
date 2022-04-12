Public Class Grupos_alta_b
    Inherits System.Web.UI.Page
    Dim DAgrupos As New Capa_Datos.WC_grupos
    Dim DAclientes As New Capa_Datos.WB_clientes
    Dim Ds_grupos As New DS_grupos
    Private Sub Cargar_combos()
        'COMBO TIPO
        Ds_grupos.Combo_tipo.Rows.Clear()
        Dim f_tipo0 As DataRow = Ds_grupos.Combo_tipo.NewRow
        f_tipo0("Tipo") = ""
        f_tipo0("Valor") = 0
        Ds_grupos.Combo_tipo.Rows.Add(f_tipo0)

        Dim f_tipo1 As DataRow = Ds_grupos.Combo_tipo.NewRow
        f_tipo1("Tipo") = "1"
        f_tipo1("Valor") = 1
        Ds_grupos.Combo_tipo.Rows.Add(f_tipo1)

        Dim f_tipo2 As DataRow = Ds_grupos.Combo_tipo.NewRow
        f_tipo2("Tipo") = "2"
        f_tipo2("Valor") = 2
        Ds_grupos.Combo_tipo.Rows.Add(f_tipo2)

        Dim f_tipo3 As DataRow = Ds_grupos.Combo_tipo.NewRow
        f_tipo3("Tipo") = "3"
        f_tipo3("Valor") = 3
        Ds_grupos.Combo_tipo.Rows.Add(f_tipo3)

        Dim f_tipo4 As DataRow = Ds_grupos.Combo_tipo.NewRow
        f_tipo4("Tipo") = "4"
        f_tipo4("Valor") = 4
        Ds_grupos.Combo_tipo.Rows.Add(f_tipo4)

        DropDownList_tipo.DataSource = Ds_grupos.Combo_tipo
        DropDownList_tipo.DataTextField = "Tipo"
        DropDownList_tipo.DataValueField = "Valor"
        DropDownList_tipo.DataBind()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Limpiar_campos()
            Cargar_combos()
            If Session("grupos_op") = "modificar" Then

                Dim ds_info As DataSet = DAgrupos.Grupos_buscar_codigo(Session("grupo_codigo")) 'traer del otro formulario
                If ds_info.Tables(0).Rows.Count <> 0 Then

                    HF_grupo_id.Value = ds_info.Tables(0).Rows(0).Item("Grupo_id")
                    Txt_grupo_codigo.Text = Session("grupo_codigo") 'aqui va el codigo del grupo
                    Txt_grupo_nomb.Text = ds_info.Tables(0).Rows(0).Item("Nombre").ToString
                    'Txt_tipo.Text = ds_info.Tables(0).Rows(0).Item("Tipo")
                    DropDownList_tipo.SelectedValue = CInt(ds_info.Tables(0).Rows(0).Item("Tipo"))

                    Txt_porcentaje.Text = ds_info.Tables(0).Rows(0).Item("Porcentaje")
                    Txt_clieporcentaje.Text = ds_info.Tables(0).Rows(0).Item("Clienteporcentaje")
                    'Txt_codcobro.Text = ds_info.Tables(0).Rows(0).Item("Codigocobro")
                    DropDownList_codcobro.SelectedValue = ds_info.Tables(0).Rows(0).Item("Codigocobro")
                    Txt_importe_fecha.Text = ds_info.Tables(0).Rows(0).Item("Importe").ToString
                    Dim FECHA As Date = CDate(ds_info.Tables(0).Rows(0).Item("Fecha"))
                    Txt_fechaproc.Text = FECHA.ToString("yyyy-MM-dd")
                End If
                'Label_grupo_id0.Visible = True
                Txt_grupo_codigo.ReadOnly = True
            Else
                DropDownList_tipo.SelectedValue = 0
                DropDownList_codcobro.SelectedValue = 1
                Txt_grupo_codigo.ReadOnly = True
                Session("grupos_op") = "alta"
                Txt_grupo_codigo.Text = Session("codigo_nuevo")

                'Dim fecha As Date = Today
                'Txt_fechaproc.Text = fecha.ToString("yyyy-MM-dd")
                'Label_grupo_id0.Visible = False
                'Txt_grupo_id.Visible = False
            End If
            Txt_grupo_nomb.Focus()



        End If
    End Sub
    Private Sub Limpiar_campos()
        HF_grupo_id.Value = 0
        'Txt_grupo_id.Enabled = False
        Txt_grupo_codigo.Text = ""
        Txt_grupo_nomb.Text = ""
        'Txt_tipo.Text = 0
        Txt_porcentaje.Text = CDec(0)
        Txt_clieporcentaje.Text = CDec(0)
        'Txt_codcobro.Text = 1
        'Dim fecha As Date = Today
        'Txt_fechaproc.Text = fecha
        Txt_grupo_nomb.Focus()
        lb_errores_blanqueo()
    End Sub

    Private Sub lb_errores_blanqueo()
        '----------lb errores-------
        Lb_error_validacion.Text = ""
        Lb_error_validacion.Visible = False
        lb_error_codigo.Visible = False
        lb_error_nombre.Visible = False
        lb_error_tipo.Visible = False
        lb_error_porcentaje.Visible = False
        lb_error_clieporcentaje.Visible = False
        lb_error_codcobro.Visible = False
        lb_error_fecha.Visible = False
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("Grupos_abm.aspx")
    End Sub

    Private Sub btn_baja_mdl_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_mdl.ServerClick
        Try
            If Txt_grupo_codigo.Text <> "" Then
                Dim ds_clientes As DataSet = DAgrupos.Grupos_obtener_clientes(HF_grupo_id.Value)
                If ds_clientes.Tables(0).Rows.Count = 0 Then
                    DAgrupos.Grupos_baja(CDec(HF_grupo_id.Value)) 'el hf tiene el id en 0 si es una alta, sino recupera del form grupo_abm
                    Limpiar_campos()
                    Txt_grupo_codigo.Text = ""
                    'redireccionar a menu de grupos.
                    Response.Redirect("Grupos_abm.aspx")
                Else
                    'mensaje: Error, el grupo tiene clientes asignados.
                    ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error_eliminar", "$(document).ready(function () {$('#modal-sm_error_eliminar').modal();});", True)
                End If

                
            End If
        Catch ex As Exception
            Txt_grupo_nomb.Focus()
        End Try
    End Sub

    Private Sub BOTON_GRABAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABAR.ServerClick
        lb_errores_blanqueo()
        Try
            Dim valido_ingreso As String = "si"

            If Txt_grupo_codigo.Text = "" Then
                valido_ingreso = "no"
                lb_error_codigo.Visible = True
            End If

            'If Txt_grupo_nomb.Text = "" Then
            '    valido_ingreso = "no"
            '    lb_error_nombre.Visible = True
            'End If

            Try
                If DropDownList_tipo.SelectedValue = 0 Then
                    valido_ingreso = "no"
                    lb_error_tipo.Visible = True
                End If

                'If Txt_tipo.Text = "" Or Txt_tipo.Text = "0" Or Txt_tipo.Text > 4 Then
                '    If Txt_tipo.Text = "" Then
                '        Txt_tipo.Text = 0
                '    End If
                '    valido_ingreso = "no"
                '    lb_error_tipo.Visible = True
                'End If
            Catch ex As Exception
                'Txt_tipo.Text = 0
                valido_ingreso = "no"
                lb_error_tipo.Visible = True
            End Try


            Dim porcentaje As Decimal
            Try
                porcentaje = CDec(Txt_porcentaje.Text.Replace(".", ","))
            Catch ex As Exception
                porcentaje = CDec(0)
                'lb_error_porcentaje.Visible = True
                'valido_ingreso = "no"
            End Try

            Dim clieporcentaje As Integer
            Try
                clieporcentaje = CInt(Txt_clieporcentaje.Text)

                If clieporcentaje <> 0 Then
                    'lo busco y valido
                    Dim ds_clie As DataSet = DAclientes.Clientes_buscar_codigo(clieporcentaje)
                    If ds_clie.Tables(0).Rows.Count = 0 Then
                        'aqui msj error.
                        lb_error_clieporcentaje.Visible = True
                        valido_ingreso = "no"
                    End If
                End If



            Catch ex As Exception
                clieporcentaje = CInt(0)
                'lb_error_clieporcentaje.Visible = True
                'valido_ingreso = "no"
            End Try

            'Try
            '    If Txt_codcobro.Text = "" Or Txt_codcobro.Text = "0" Or CInt(Txt_codcobro.Text) > 4 Then
            '        Txt_codcobro.Text = "1"
            '        'valido_ingreso = "no"
            '        'lb_error_codcobro.Visible = True
            '    End If
            'Catch ex As Exception
            '    Txt_codcobro.Text = "1"
            '    'valido_ingreso = "no"
            '    'lb_error_codcobro.Visible = True
            'End Try

            'Dim fecha As String = CDate(Txt_fechaproc.Text.ToString)

            Dim fecha As Date
            If Txt_fechaproc.Text = "" Then
                fecha = Today
                'valido_ingreso = "no"
                'lb_error_fecha.Visible = True
            Else
                Try
                    fecha = CDate(Txt_fechaproc.Text)
                Catch ex As Exception
                    valido_ingreso = "no"
                    lb_error_fecha.Visible = True
                End Try
            End If

            Dim importe_procesamiento As Decimal
            Try
                importe_procesamiento = CDec(Txt_importe_fecha.Text.Replace(".", ","))
            Catch ex As Exception
                importe_procesamiento = CDec(0)
                'lb_error_porcentaje.Visible = True
                'valido_ingreso = "no"
            End Try

            If valido_ingreso = "si" Then
                Select Case Session("grupos_op")
                    Case "alta"
                        If Session("grupos_op") = "alta" Then
                            '1) valido que no exista.
                            Dim ds_info As DataSet = DAgrupos.Grupos_buscar(Txt_grupo_nomb.Text, Txt_grupo_codigo.Text)
                            If (ds_info.Tables(1).Rows.Count = 0) Then 'no existe
                                '2) guardo en bd
                                DAgrupos.Grupos_alta(Txt_grupo_nomb.Text, CStr(DropDownList_tipo.SelectedValue), porcentaje, clieporcentaje, CStr(DropDownList_codcobro.SelectedValue), fecha, CDec(0), CDec(0), CDec(0), Txt_grupo_codigo.Text, importe_procesamiento)
                                Limpiar_campos()
                                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)

                                'el response.redirect lo pongo en ok
                                'Response.Redirect("Grupos_abm.aspx")
                            Else
                                'aqui muestro mensaje notificando que existe.
                                Lb_error_validacion.Text = "Error! El grupo ya existe, modifique los datos ingresados."
                                Lb_error_validacion.Visible = True
                                If ds_info.Tables(0).Rows.Count <> 0 Then
                                    lb_error_nombre.Visible = True
                                End If
                                If ds_info.Tables(1).Rows.Count <> 0 Then
                                    lb_error_codigo.Visible = True
                                End If
                                Txt_grupo_codigo.Focus()
                            End If
                        End If
                    Case "modificar"
                        If Session("grupos_op") = "modificar" Then
                            '1) valido que el nombre q ingreso, ya no exista con otro id
                            Dim ds_info As DataSet = DAgrupos.Grupos_buscar(Txt_grupo_nomb.Text, Txt_grupo_codigo.Text)
                            Dim existe = "no"
                            Dim existe_nombre = "no"
                            'If ds_info.Tables(0).Rows.Count <> 0 Then 'existe
                            '    Dim i As Integer = 0
                            '    While i < ds_info.Tables(0).Rows.Count
                            '        If (CInt(HF_grupo_id.Value) <> ds_info.Tables(0).Rows(i).Item("Grupo_id")) And (Txt_grupo_nomb.Text.ToUpper = ds_info.Tables(0).Rows(i).Item("Nombre").ToString.ToUpper) Then
                            '            existe = "si"
                            '            existe_nombre = "si"
                            '            Exit While
                            '        End If
                            '        i = i + 1
                            '    End While
                            'Else
                            '    'puedo guardar.
                            'End If
                            Dim existe_codigo = "no"
                            If ds_info.Tables(1).Rows.Count <> 0 Then 'no existe
                                Dim i As Integer = 0
                                While i < ds_info.Tables(1).Rows.Count
                                    If (CInt(HF_grupo_id.Value) <> ds_info.Tables(1).Rows(i).Item("Grupo_id")) And (Txt_grupo_codigo.Text.ToUpper = ds_info.Tables(1).Rows(i).Item("Codigo").ToString.ToUpper) Then
                                        existe = "si"
                                        existe_codigo = "si"
                                        Exit While
                                    End If
                                    i = i + 1
                                End While
                            Else
                                'puedo guardar.
                            End If


                            If existe = "no" Then
                                DAgrupos.Grupos_modificar(CInt(HF_grupo_id.Value), Txt_grupo_nomb.Text, CStr(DropDownList_tipo.SelectedValue), porcentaje, clieporcentaje, CStr(DropDownList_codcobro.SelectedValue), fecha, Txt_grupo_codigo.Text, importe_procesamiento)
                                Limpiar_campos()
                                'regresar al form que lista grupos.
                                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_OKGRABADO", "$(document).ready(function () {$('#modal-sm_OKGRABADO').modal();});", True)

                                'el response.redirect lo pongo en ok
                                'Response.Redirect("Grupos_abm.aspx")
                            Else
                                'aqui muestro mensaje notificando que existe.
                                Lb_error_validacion.Text = "Error! El grupo ya existe, modifique los datos ingresados."
                                Lb_error_validacion.Visible = True
                                If existe_nombre = "si" Then
                                    lb_error_nombre.Visible = True
                                End If
                                If existe_codigo = "si" Then
                                    lb_error_codigo.Visible = True
                                End If
                                Txt_grupo_codigo.Focus()
                            End If
                        End If
                End Select
            Else
                'aqui mensaje de que cargue todos los paretros solicitados correctamente
                Lb_error_validacion.Text = "Error! Ingrese los datos solicitados correctamente."
                Lb_error_validacion.Visible = True
                Txt_grupo_codigo.Focus()
            End If
        Catch ex As Exception
            'aqui mensaje de que cargue todos los paretros solicitados correctamente
            Lb_error_validacion.Text = "Error! Ingrese los datos solicitados correctamente."
            Lb_error_validacion.Visible = True
            Txt_grupo_codigo.Focus()
        End Try

    End Sub

    Private Sub btn_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.ServerClick
        Response.Redirect("Grupos_abm.aspx")
    End Sub

    Private Sub btn_graba_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_graba_close.ServerClick
        Response.Redirect("Grupos_abm.aspx")
    End Sub

    Private Sub btn_baja_mdl_cancelar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_mdl_cancelar.ServerClick
        Txt_grupo_codigo.Focus()
    End Sub

    Private Sub btn_baja_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_baja_close.ServerClick
        Txt_grupo_codigo.Focus()
    End Sub


    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido

    Private Sub Txt_grupo_codigo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_grupo_codigo.Init
        Txt_grupo_codigo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_grupo_nomb_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_grupo_nomb.Init
        Txt_grupo_nomb.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    'Private Sub Txt_tipo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_tipo.Init
    '    Txt_tipo.Attributes.Add("onfocus", "seleccionarTexto(this);")
    'End Sub

    Private Sub Txt_porcentaje_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_porcentaje.Init
        Txt_porcentaje.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_clieporcentaje_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_clieporcentaje.Init
        Txt_clieporcentaje.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    'Private Sub Txt_codcobro_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_codcobro.Init
    '    Txt_codcobro.Attributes.Add("onfocus", "seleccionarTexto(this);")
    'End Sub

    Private Sub Txt_fechaproc_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fechaproc.Init
        Txt_fechaproc.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub Txt_importe_fecha_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_importe_fecha.Init
        Txt_importe_fecha.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub


#Region "modal-sm_error_eliminar"
    Private Sub btn_erroreliminar_close_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_erroreliminar_close.ServerClick
        Txt_grupo_nomb.Focus()
    End Sub

    Private Sub btn_erroreliminar_ok_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_erroreliminar_ok.ServerClick
        Txt_grupo_nomb.Focus()
    End Sub
#End Region

    
End Class