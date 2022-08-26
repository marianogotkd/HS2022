Imports System.Drawing
Imports System.IO

Public Class Modificar_Evento
    Inherits System.Web.UI.Page
    Public Cambio_foto As String = "no"
    Dim DAevento As New Capa_de_datos.Eventos
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Not IsPostBack Then
            lbl_errFecCier.Visible = False
            lbl_errNom.Visible = False
            lbl_costo.Visible = False
            lbl_errfechaini.Visible = False
            lbl_horaCierre.Visible = False
            lbl_errImg.Visible = False
            lbl_turnos_error0.Visible = False
            lbl_error_cap_max_inscr.Visible = False

            combo_TipoEvento.Enabled = False
            Ocultar.Visible = False
            Session("imagen") = ""
            Session("foto_subido") = "no"

            ObetenerEventos()
            Cargar_Evento()

        End If

    End Sub

    Private Sub crear_tabla_turnos()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Dim ds_eventos As New ds_eventos
        ds_eventos.Tables("Turnos").Rows.Clear()
        Dim cont = 0
        Dim horas As Integer = 8
        While cont < 14
            Dim row As DataRow = ds_eventos.Tables("Turnos").NewRow()
            row("Turno") = CStr(horas) + " hrs."

            ds_eventos.Tables("Turnos").Rows.Add(row)
            cont = cont + 1
            horas = horas + 1
        End While
        GridView1.DataSource = ds_eventos.Tables("Turnos")
        GridView1.DataBind()

        GridView1.Enabled = False


    End Sub

    Public Sub ObetenerEventos()
        Dim ds_Eventos As DataSet = DAevento.Evento_ObetenerEventos()
        If ds_Eventos.Tables(0).Rows.Count <> 0 Then
            drop_evento.DataSource = ds_Eventos.Tables(0)
            drop_evento.DataTextField = "evento_descripcion"
            drop_evento.DataValueField = "evento_id"
            drop_evento.DataBind()
        End If



    End Sub

    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function
    Dim ChkTurno As CheckBox
    

    Private Sub Subir_Foto_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Subir_Foto.ServerClick


        System.Threading.Thread.Sleep(5000)

        If FileUpload1.HasFile Then
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".png" Or fileExt = ".jpg" Or fileExt = ".JPG" Or fileExt = ".PNG" Or fileExt = ".JPEG" Or fileExt = ".BMP" Then
                Session("foto_subido") = "si"
                tamanio = FileUpload1.PostedFile.ContentLength
                'int Tamanio = fuploadImagen.PostedFile.ContentLength;
                'choco
                ImagenOriginal = New Byte(tamanio - 1) {}
                'byte[] ImagenOriginal = new byte[Tamanio];
                'choco
                FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
                'fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
                'choco
                ImagenOriginalBinaria = New Bitmap(FileUpload1.PostedFile.InputStream)
                'Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                'choco
                ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
                'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);

                Session("imagen") = ImagenOriginal
                Image1.ImageUrl = ImagenDataURL64

                Image1.Visible = True
                lbl_errImg.Visible = False
                'btn_Examinar.Visible = False
                'btn_quitar.Visible = True
                Cambio_foto = "si"
            Else
                lbl_errImg.Visible = True
                lbl_errImg.InnerText = "Solo Archivos de Tipo Imagen"
            End If

        End If

    End Sub

    Private Sub btn_quitar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar.ServerClick
        FileUpload1.Attributes.Clear()
        Image1.ImageUrl = "~/Eventos/imagen/logo_evento.jpg"
        Session("imagen") = ""
        Session("foto_subido") = "no"

        'Image1.Visible = False
        'btn_quitar.Visible = False
        'btn_Examinar.Visible = True

    End Sub

    Private Sub drop_evento_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop_evento.Init
    End Sub

    Public Sub Cargar_Evento()
        lbl_no_turnos.Visible = False
        crear_tabla_turnos()

        Dim ds_Eventos As DataSet = DAevento.Evento_ObetenerEvento_ID(drop_evento.SelectedValue)
        If ds_Eventos.Tables(0).Rows.Count <> 0 Then
            combo_TipoEvento.SelectedValue = ds_Eventos.Tables(0).Rows(0).Item("evento_tipoevento")
            tb_nombre.Value = ds_Eventos.Tables(0).Rows(0).Item("evento_descripcion")
            tb_fechainicio.Value = ds_Eventos.Tables(0).Rows(0).Item("evento_fecha")
            tb_fechaCierre.Value = ds_Eventos.Tables(0).Rows(0).Item("fechacierre")
            tb_horaCierre.Value = ds_Eventos.Tables(0).Rows(0).Item("horacierre")
            textbox_Costo.Text = ds_Eventos.Tables(0).Rows(0).Item("evento_costo")
            Try
                tb_direccion.Value = ds_Eventos.Tables(0).Rows(0).Item("evento_direccion")
            Catch ex As Exception
                tb_direccion.Value = ""
            End Try


            Dim ImagenBD As Byte() = ds_Eventos.Tables(0).Rows(0).Item("evento_foto")
            Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)
            'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
            'choco
            'image1.ImageUrl = ImagenDataURL64
            Image1.ImageUrl = ImagenDataURL64

            Image1.Visible = True
            lbl_errImg.Visible = False
            'btn_Examinar.Visible = False
            'btn_quitar.Visible = True
            Session("imagen_ModEvnt") = ImagenBD 'esta variable tiene la foto de la bd
            Session("foto_subido") = "img_recuperadaBD"


            If combo_TipoEvento.SelectedValue = "Examen" Then
                Panel_examenes.Visible = True
                tb_capacidad_max.Text = ds_Eventos.Tables(0).Rows(0).Item("evento_cap_max_insc")
                'Div_Costos.Visible = True
                cost_seccion.Visible = False
            Else
                Panel_examenes.Visible = False
                tb_capacidad_max.Text = 0
                'Div_Costos.Visible = False
                cost_seccion.Visible = True
            End If

            If ds_Eventos.Tables(1).Rows.Count <> 0 Then
                'Dim chk_turno As CheckBox
                Dim i As Integer = 0
                While i < ds_Eventos.Tables(1).Rows.Count
                    Dim ExamenTurno_desc As String = ds_Eventos.Tables(1).Rows(i).Item("ExamenTurno_desc")
                    Dim j As Integer = 0
                    While j < GridView1.Rows.Count
                        If ExamenTurno_desc = GridView1.Rows(j).Cells(1).Text Then
                            CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox).Checked = True
                            Exit While
                        End If
                        j = j + 1
                    End While
                    i = i + 1
                End While

                If ds_Eventos.Tables(2).Rows.Count = 0 Then
                    GridView1.Enabled = True
                    lbl_no_turnos.Visible = False
                Else
                    GridView1.Enabled = False
                    lbl_no_turnos.Visible = True
                End If

            End If


        End If



    End Sub

    Private Sub drop_evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop_evento.SelectedIndexChanged

        Cargar_Evento()


        If combo_TipoEvento.SelectedValue = "Examen" Then
            Panel_examenes.Visible = True
            'Div_Costos.Visible = True
            cost_seccion.Visible = False
        Else
            Panel_examenes.Visible = False
            'Div_Costos.Visible = False
            cost_seccion.Visible = True
        End If

    End Sub

    Private Sub btn_eliminar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.ServerClick

        'System.Threading.Thread.Sleep(5000)

        DAevento.Evento_eliminar(drop_evento.SelectedValue)

        Ocultar.Visible = True
        ModalPopupExtender1.Show()
        Label2.Text = "Evento Eliminado"
        ObetenerEventos()
        Cargar_Evento()

    End Sub

    Private Sub btn_Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cerrar.Click
        Response.Redirect("~/Inicio_Blanco.aspx")
    End Sub

    Private Sub Btn_modal_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_modal_guardar.ServerClick
        Label2.Text = "Evento Guardado"
        Dim Vacio As Boolean

        If tb_nombre.Value = "" Then
            lbl_errNom.Visible = True
            Vacio = True
        End If

        If tb_fechainicio.Value = "" Then
            lbl_errfechaini.Visible = True
            Vacio = True
        End If

        If tb_fechaCierre.Value = "" Then
            lbl_errFecCier.Visible = True
            Vacio = True
        End If

        If tb_horaCierre.Value = "" Then
            lbl_horaCierre.Visible = True
            Vacio = True
        End If


        Dim costo = textbox_Costo.Text
        If Image1.Visible = False Then
            lbl_errImg.Visible = True
            lbl_errImg.InnerText = "Debe Seleccionar una Foto"
            'Vacio = True
        End If

        Dim FechaHoraCierre = tb_fechaCierre.Value + " " + tb_horaCierre.Value

        If Session("foto_subido") = "no" Then 'nota: esto valido en caso que quiera dejar la foto con la imagen generica de LOGO
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen") = imagebytes
            Session("foto_subido") = "si"
        Else
            If Session("foto_subido") = "img_recuperadaBD" Then
                Session("imagen") = Session("imagen_ModEvnt")
            End If

        End If

        If Cambio_foto = "no" Then
            Session("imagen") = Session("imagen_ModEvnt")
        End If


        If Vacio = False Then
            If combo_TipoEvento.SelectedValue = "Examen" Then
                Dim valido_cap_max As String = "no"
                If tb_capacidad_max.Text = "" Then
                    tb_capacidad_max.Text = "0"
                    valido_cap_max = "no"
                Else
                    If CInt(tb_capacidad_max.Text) > 0 Then
                        valido_cap_max = "si"
                    Else
                        valido_cap_max = "no"
                    End If
                End If
                'controlo que al menos haya seleccionado 1 turno.
                Dim valido As String = "no"
                Dim i As Integer = 0
                While i < GridView1.Rows.Count
                    ChkTurno = CType(Me.GridView1.Rows(i).FindControl("chk_turno"), CheckBox)
                    If ChkTurno.Checked = True Then
                        valido = "si"
                        Exit While
                    End If
                    i = i + 1
                End While
                If (valido = "si") And (valido_cap_max = "si") Then
                    Try
                        textbox_Costo.Text = CDec(textbox_Costo.Text)
                    Catch ex As Exception
                        textbox_Costo.Text = 0
                    End Try
                    DAevento.Evento_Actualizar(drop_evento.SelectedValue, tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(0), tb_capacidad_max.Text, tb_direccion.Value)


                    If lbl_no_turnos.Visible = False Then 'si esta oculto, significa que puedo editar.

                        'primero elimino.
                        DAevento.ExamenTurno_eliminar(drop_evento.SelectedValue)

                        Dim j As Integer = 0
                        While j < GridView1.Rows.Count
                            ChkTurno = CType(Me.GridView1.Rows(j).FindControl("chk_turno"), CheckBox)
                            If ChkTurno.Checked = True Then
                                'aqui guardo en bd cada turno.
                                Dim Turno = Me.GridView1.Rows(j).Cells(1).Text
                                DAevento.ExamenTurno_alta(drop_evento.SelectedValue, Turno)
                            End If
                            j = j + 1
                        End While
                    End If
                    limpiar_label_error()
                    Ocultar.Visible = True
                    ModalPopupExtender1.Show()




                Else
                    If valido = "no" Then
                        lbl_turnos_error0.Visible = True
                        Vacio = True
                    End If
                    If valido_cap_max = "no" Then
                        lbl_error_cap_max_inscr.Visible = True
                        Vacio = True
                    End If
                End If


            Else
                'es un torneo o curso
                If costo = "" Then
                    DAevento.Evento_Actualizar(drop_evento.SelectedValue, tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, IsDBNull(costo), CDec(0), tb_direccion.Value)
                Else
                    DAevento.Evento_Actualizar(drop_evento.SelectedValue, tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, costo, CDec(0), tb_direccion.Value)
                End If
                limpiar_label_error()

                Ocultar.Visible = True
                ModalPopupExtender1.Show()



            End If


            'lbl_ok.Visible = True
            'tb_nombre.Value = ""
            'tb_fechainicio.Value = ""
            'tb_fechaCierre.Value = ""
            'tb_horaCierre.Value = ""
            'textbox_Costo.Text = ""
            FileUpload1.Attributes.Clear()
            Image1.Visible = False
            btn_quitar.Visible = False
            btn_Examinar.Visible = True




        End If
    End Sub

    Private Sub limpiar_label_error()
        lbl_errNom.Visible = False
        lbl_errfechaini.Visible = False
        lbl_errFecCier.Visible = False
        lbl_horaCierre.Visible = False
        lbl_costo.Visible = False
        lbl_errImg.Visible = False
        lbl_error_cap_max_inscr.Visible = False
        lbl_turnos_error0.Visible = False
        lbl_no_turnos.Visible = False
    End Sub

   
End Class


