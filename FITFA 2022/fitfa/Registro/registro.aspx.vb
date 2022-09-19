Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Public Class registro
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txt_fechanacimiento.Text = Today
        'If FileUpload1.PostedFile IsNot Nothing AndAlso FileUpload1.PostedFile.ContentLength > 0 Then
        'UpLoadAndDisplay()
        'End If
        If Not IsPostBack Then
            txt_fechanacimiento.Text = Today
            Txt_fechanac_2.Text = Today
            Session("imagen_registro") = ""
            Session("foto_subido_registro") = "no"


            'seleccionamos siempre en el combo de provincia = "santiago del estero" e institucion "ANT"
            Try
                DropDown_prov_con_institucion.SelectedValue = 14
                obtener_instituciones_x_provincia()
                obtener_instructores_x_institucion()
                DropDownList_instituciones.SelectedValue = 23
                obtener_instructores_x_institucion()
            Catch ex As Exception

            End Try

        End If
        If (IsPostBack = False) Then 'o es true
            'txt_fechanacimiento.ForeColor = Drawing.Color.LightGoldenrodYellow
            'txt_fechanacimiento.ForeColor = Drawing.Color.DeepPink
            'txt_fechanacimiento.Font.Bold = True
            'txt_fechanacimiento.Font.Size = FontUnit.Medium
            'txt_fechanacimiento.Font.Name = "Comic Sans MS"
        End If
        'If Session("imagen") <> "" Then
        '    ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(Session("imagen"))
        '    'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
        '    Image1.ImageUrl = ImagenDataURL64
        'End If
    End Sub

    Private Sub UpLoadAndDisplay()
        'Dim imgName As String = FileUpload1.FileName
        'Dim imgPath As String = "imagen/" & imgName
        ''Dim imgSize As Integer = FileUpload1.PostedFile.ContentLength
        'If FileUpload1.PostedFile IsNot Nothing AndAlso FileUpload1.PostedFile.FileName <> "" Then
        '    FileUpload1.SaveAs(Server.MapPath(imgPath))
        '    'Image1.ImageUrl = "~/" & imgPath
        '    Image_preview.ImageUrl = "~/Registro/imagen/" & FileUpload1.FileName

        'End If

    End Sub


    Private Sub obtener_estadocivil()
        Dim ds_estadocivil As DataSet = DAusuario.Estado_civil_obtener
        If ds_estadocivil.Tables(0).Rows.Count <> 0 Then
            DropDownList_estadocivil.DataSource = ds_estadocivil.Tables(0)
            DropDownList_estadocivil.DataTextField = "estadocivil_desc"
            DropDownList_estadocivil.DataValueField = "estadocivil_id"
            DropDownList_estadocivil.DataBind()
        End If



    End Sub
    Private Sub Obtener_graduaciones()
        Dim ds_graduaciones As DataSet = DAusuario.Usuario_ObtenerGraduaciones()
        If ds_graduaciones.Tables(0).Rows.Count <> 0 Then
            DropDownList_graduacion.DataSource = ds_graduaciones.Tables(0)
            DropDownList_graduacion.DataTextField = "graduacion_desc"
            DropDownList_graduacion.DataValueField = "graduacion_id"
            DropDownList_graduacion.DataBind()
        End If



    End Sub
    Public Sub Obtener_provincias()
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            DropDownList_provincia.DataSource = ds_provincias.Tables(0)
            DropDownList_provincia.DataTextField = "provincia_desc"
            DropDownList_provincia.DataValueField = "provincia_id"
            DropDownList_provincia.DataBind()
        End If
    End Sub
    Private Sub Obtener_ciudad()
        'filtrar
        DropDownList_ciudad.DataSource = ""
        DropDownList_ciudad.DataBind()

        Dim ds_ciudades As DataSet = DAusuario.Usuario_filtrarciudades_x_Provincias(CInt(DropDownList_provincia.SelectedValue))
        If ds_ciudades.Tables(0).Rows.Count <> 0 Then
            DropDownList_ciudad.DataSource = ds_ciudades.Tables(0)

            DropDownList_ciudad.DataTextField = "ciudad_desc"
            DropDownList_ciudad.DataValueField = "ciudad_id"
            DropDownList_ciudad.DataBind()
        End If
    End Sub
    Private Sub DropDownList_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.Init
        Obtener_provincias()
        Obtener_ciudad()
    End Sub
    Private Sub DropDownList_provincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.SelectedIndexChanged
        Obtener_ciudad()


    End Sub

    Private Sub FileUpload1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileUpload1.Init
        FileUpload1.Attributes.Add("onchange", "fileUpload1()")

    End Sub

    'Private Sub Btn_adjuntar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_adjuntar.Click
    'choco()
    'Dim tamanio As Integer = FileUpload1.PostedFile.ContentLength
    'Dim ImagenOriginal As Byte() = New Byte(tamanio - 1) {}
    'FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
    'Dim ImagenOriginalBinaria As Bitmap = New Bitmap(FileUpload1.PostedFile.InputStream)
    'Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
    'Image_preview.ImageUrl = ImagenDataURL64


    'Dim tamanio As Integer = AsyncFileUpload1.PostedFile.ContentLength
    'Dim ImagenOriginal As Byte() = New Byte(tamanio - 1) {}
    'AsyncFileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
    'Dim ImagenOriginalBinaria As Bitmap = New Bitmap(AsyncFileUpload1.PostedFile.InputStream)
    'Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
    'Image_preview.ImageUrl = ImagenDataURL64

    'End Sub

    Private Sub DropDownList_graduacion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_graduacion.Init
        Obtener_graduaciones()
    End Sub

    Private Sub DropDown_prov_con_institucion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_prov_con_institucion.Init
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            DropDown_prov_con_institucion.DataSource = ds_provincias.Tables(0)
            DropDown_prov_con_institucion.DataTextField = "provincia_desc"
            DropDown_prov_con_institucion.DataValueField = "provincia_id"
            DropDown_prov_con_institucion.DataBind()
            'aqui recupero las instituciones de la primer prov seleccionada
            obtener_instituciones_x_provincia()
            obtener_instructores_x_institucion()
        End If
    End Sub

    Private Sub obtener_instituciones_x_provincia()
        'filtrar
        DropDownList_instituciones.DataSource = ""
        DropDownList_instituciones.DataBind()
        Dim ds_instituiones As DataSet = DAusuario.Usuario_ObtenerInstituciones_x_provincia(DropDown_prov_con_institucion.SelectedValue)
        If ds_instituiones.Tables(0).Rows.Count <> 0 Then
            DropDownList_instituciones.DataSource = ds_instituiones.Tables(0)
            DropDownList_instituciones.DataTextField = "institucion_abreviacion"
            DropDownList_instituciones.DataValueField = "institucion_id"
            DropDownList_instituciones.DataBind()
        End If

    End Sub

    Private Sub obtener_instructores_x_institucion()

        If DropDownList_instituciones.Items.Count <> 0 Then


            'filtrar
            DropDownList_instructor.DataSource = ""
            DropDownList_instructor.DataBind()

            Dim ds_instructor As DataSet = DAusuario.Usuario_ObtenerInstructor(DropDownList_instituciones.SelectedValue)
            If ds_instructor.Tables(0).Rows.Count <> 0 Then
                DropDownList_instructor.DataSource = ds_instructor.Tables(0)
                DropDownList_instructor.DataTextField = "Nombre"
                DropDownList_instructor.DataValueField = "instructor_id"
                DropDownList_instructor.DataBind()
            End If
        End If
    End Sub


    Private Sub DropDown_prov_con_institucion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_prov_con_institucion.SelectedIndexChanged
        obtener_instituciones_x_provincia()
        obtener_instructores_x_institucion()
    End Sub

    Private Sub DropDownList_instituciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_instituciones.SelectedIndexChanged
        obtener_instructores_x_institucion()
    End Sub

    Private Sub backcolor_textbox_limpiar()
        txt_apellido.BackColor = Color.White 'ok
        txt_nombre.BackColor = Color.White 'ok
        txt_dni.BackColor = Color.White 'ok
        txt_nacionalidad.BackColor = Color.White
        txt_profesion.BackColor = Color.White
        Txt_fechanac_2.BackColor = Color.White 'ok
        txt_domilicio.BackColor = Color.White 'ok
        txt_codigopostal.BackColor = Color.White
        txt_telefono.BackColor = Color.White 'ok
        txt_email.BackColor = Color.White 'ok
        txt_nrolibreta.BackColor = Color.White
        txt_usuario.BackColor = Color.White 'ok
        txt_contraseña1.BackColor = Color.White 'ok
        txt_contraseña2.BackColor = Color.White 'ok

    End Sub


    Private Sub Btn_registrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_registrate.Click
        backcolor_textbox_limpiar()


        'If foto_cargada = "no" Or foto_cargada Is Nothing Then
        If Session("foto_subido_registro") = "no" Then
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen_registro") = imagebytes
        End If
        


        'Dim info_foto As FileInfo = New FileInfo(MapPath("~/Registro/Imagen/usuario-registrado.jpg"))
        'Dim tamanio As Integer = "~/Registro/Imagen/usuario-registrado.jpg"
        'Dim ImagenOriginal As Byte() = File.ReadAllBytes(Image1.ImageUrl)
        'ImagenOriginal = New Byte(tamanio - 1) {}

        'Dim arreglo1 As Byte() = Image1.ImageUrl
        'Image1.ImageUrl = "~/Registro/imagen/usuario-registrado.jpg"
        'Dim info_foto As FileInfo = New FileInfo(MapPath("~/Registro/Imagen/usuario-registrado.jpg"))
        'Dim tamanio As Integer = info_foto.Length
        'Dim ImagenOriginal As Byte()
        'ImagenOriginal = New Byte(tamanio - 1) {}
        'FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
        'Dim ImagenOriginalBinaria As Bitmap = New Bitmap(FileUpload1.PostedFile.InputStream)
        'Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
        ocultar_div_errores()
        ' Using reader As System.IO.BinaryReader = New System.IO.BinaryReader(FileUpload1.PostedFile.InputStream)
        'Dim foto As Byte() = reader.ReadBytes(FileUpload1.PostedFile.ContentLength)
        Dim valido As String = "si"

        If txt_apellido.Text = "" Then
            valido = "no"
            'txt_apellido.BorderColor = Color.Red
            div_apellido_error.Visible = True
            txt_apellido.Focus()
            txt_apellido.BackColor = Color.Yellow
        Else
            If txt_nombre.Text = "" Then
                valido = "no"
                'txt_nombre.BorderColor = Color.Red
                txt_nombre.BackColor = Color.Yellow
                div_nombre_error.Visible = True
                txt_nombre.Focus()

            Else

                Dim tipodoc As Integer = CInt(DropDownList_tipodoc.SelectedIndex)
                If tipodoc = 0 Then
                    valido = "no"
                    'DropDownList_tipodoc.BackColor = Color.Red
                    label_error_tipodoc.Visible = True
                    DropDownList_tipodoc.Focus()

                Else
                    'aqui sigue dni
                    If txt_dni.Text = "" Then
                        valido = "no"
                        txt_dni.BackColor = Color.Yellow
                        div_dni_error.Visible = True
                        txt_dni.Focus()
                    Else
                        'aqui valido que no exista ya
                        If txt_usuario.Text = "" Then
                            valido = "no"
                            txt_usuario.BackColor = Color.Yellow
                            div_usuario_error.Visible = True
                            txt_usuario.Focus()
                            'seccion_dni
                            'div_usuario_error.Focus()
                            'ClientScript.RegisterStartupScript()
                            'ClientScript.RegisterStartupScript(GetType(),"ScrollScript", "document.getElementById('seccion_dni').scrollIntoVie‌​w(true)", True)
                        Else
                            'valido formato de fecha
                            Dim valido_fecha As String = "si"
                            Try
                                Dim fecha_nacimiento As Date = CDate(Txt_fechanac_2.Text)
                            Catch ex As Exception
                                valido_fecha = "no"
                                Txt_fechanac_2.BackColor = Color.Yellow
                                label_error_fechanacimiento.Visible = True
                                label_error_fechanacimiento.Text = "Error, ingrese fecha de nac. válido."
                                Txt_fechanac_2.Focus()
                                valido = "no"
                            End Try

                            If valido_fecha = "si" Then
                                If txt_dni.Text <> "" Then
                                    If CInt(txt_dni.Text) <> 0 And txt_usuario.Text <> "" Then
                                        Dim ds_validar As DataSet = DAusuario.Usuario_validar_registro(txt_usuario.Text, txt_dni.Text)
                                        If ds_validar.Tables(0).Rows.Count <> 0 Then
                                            valido = "no"
                                            txt_usuario.BackColor = Color.Yellow
                                            div_usuario_error.Visible = True
                                            label_usuario_error.Text = "error! el usuario ya se encuentra registrado!"
                                            txt_usuario.Focus()
                                        Else
                                            'si no hay un usuario con ese nombre de usuario 'validos el dni
                                            If ds_validar.Tables(1).Rows.Count <> 0 Then
                                                valido = "no"
                                                txt_dni.BackColor = Color.Yellow
                                                div_dni_error.Visible = True
                                                label_dni_error.Text = "error! el documento ya se encuentra registrado!"
                                                txt_dni.Focus()
                                            Else
                                                'aqui continuoo
                                                Dim fecha_nacimiento As String = Txt_fechanac_2.Text
                                                'valido la fecha de nacimiento que al menos tenga 3 años
                                                'Dim fecha_actual As Date = Today

                                                'Dim fecha_actual = CDate(Today.Date.Year - 1 & "/" & Today.Date.Month & "/" & Today.Day)
                                                Dim fecha_actual = CDate(Today.Day & "/" & Today.Date.Month & "/" & Today.Date.Year - 3)
                                                'If CDate(fecha_nacimiento) < fecha_actual Or CDate(fecha_nacimiento) = fecha_actual Then
                                                If CDate(fecha_nacimiento) < fecha_actual Or CDate(fecha_nacimiento) = fecha_actual Then
                                                    If txt_domilicio.Text = "" Then
                                                        valido = "no"
                                                        txt_domilicio.BackColor = Color.Yellow
                                                        div_domicilio_error.Visible = True
                                                        txt_domilicio.Focus()
                                                    Else
                                                        If txt_telefono.Text = "" Then
                                                            valido = "no"
                                                            txt_telefono.BackColor = Color.Yellow
                                                            div_telefono_error.Visible = True
                                                            txt_telefono.Focus()
                                                        Else
                                                            If txt_email.Text = "" Then
                                                                valido = "no"
                                                                txt_email.BackColor = Color.Yellow
                                                                div_email_error.Visible = True
                                                                txt_email.Focus()
                                                            Else
                                                                Dim graduacion As Integer = CInt(DropDownList_graduacion.SelectedValue)
                                                                If graduacion = 1 Then
                                                                    valido = "no"
                                                                    'DropDownList_graduacion.BackColor = Color.Red
                                                                    label_error_graduacion.Visible = True
                                                                End If
                                                                If DropDownList_instituciones.SelectedValue = "" Then
                                                                    valido = "no"
                                                                    label_error_instituciones.Visible = True
                                                                    DropDownList_instituciones.Focus()
                                                                Else
                                                                    Dim instructor As String = CStr(DropDownList_instructor.SelectedValue)
                                                                    If instructor = "" Then
                                                                        valido = "no"
                                                                        'DropDownList_instructor.BackColor = Color.Red
                                                                        label_error_instructor.Visible = True
                                                                        DropDownList_instructor.Focus()
                                                                    Else
                                                                        If txt_usuario.Text = "" Then
                                                                            'ademas valido que el usuario no exista
                                                                            valido = "no"
                                                                            txt_usuario.BackColor = Color.Yellow
                                                                            div_usuario_error.Visible = True
                                                                            txt_usuario.Focus()
                                                                        Else
                                                                            If txt_contraseña1.Text = "" Then
                                                                                valido = "no"
                                                                                txt_contraseña1.BackColor = Color.Yellow
                                                                                div_contraseña1_error.Visible = True
                                                                                txt_contraseña1.Focus()
                                                                            End If

                                                                            If txt_contraseña2.Text = "" Then
                                                                                valido = "no"
                                                                                txt_contraseña2.BackColor = Color.Yellow
                                                                                div_contraseña2_error.Visible = True
                                                                                txt_contraseña1.Focus()
                                                                            End If

                                                                            If txt_contraseña1.Text <> txt_contraseña2.Text Then
                                                                                valido = "no"
                                                                                txt_contraseña1.BackColor = Color.Yellow
                                                                                txt_contraseña2.BackColor = Color.Yellow
                                                                                div_contraseña1_error.Visible = True
                                                                                div_contraseña2_error.Visible = True
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Else
                                                    label_error_fechanacimiento.Visible = True
                                                    label_error_fechanacimiento.Text = "Error, ingrese fecha de nac. válido."
                                                    Txt_fechanac_2.Focus()
                                                    Txt_fechanac_2.BackColor = Color.Yellow
                                                    valido = "no"
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    valido = "no"
                                    div_dni_error.Visible = True
                                    txt_dni.Focus()
                                    txt_dni.BackColor = Color.Yellow
                                End If 'end if del txt_dni
                            End If


                        End If

                        
                    End If
                End If
            End If
        End If
        'Dim sexo As Integer = CInt(DropDownList_sexo.SelectedIndex)
        'If sexo = 0 Then
        '    valido = "no"
        '    'DropDownList_sexo.BackColor = Color.Red
        '    label_error_sexo.Visible = True
        'End If
        'Dim estadocivil As Integer = CInt(DropDownList_estadocivil.SelectedIndex)
        'If estadocivil = 0 Then
        '    valido = "no"
        '    'DropDownList_estadocivil.BackColor = Color.Red
        '    label_error_estadocivil.Visible = True
        'End If
        Dim provincias As Integer = CInt(DropDownList_provincia.SelectedValue)
        Dim ciudad As Integer = CInt(DropDownList_ciudad.SelectedValue)
        'Dim fecha_nacimiento As String = txt_fechanacimiento.Text
        'If fecha_nacimiento = Today Then
        '    valido = "no"
        '    label_error_fechanacimiento.Visible = True
        'End If
        If CheckBox_posee_alumnos.Checked = True Then
            usuario_tipo = "instructor"
        Else
            usuario_tipo = "alumno"
        End If

        If valido = "si" Then
            Dim codpost As Integer = 0
            Try
                codpost = CInt(txt_codigopostal.Text)
            Catch ex As Exception
                codpost = 0
            End Try
            DAusuario.Usuario_alta(Session("imagen_registro"), txt_apellido.Text, txt_nombre.Text, CInt(DropDownList_tipodoc.SelectedIndex),
                      txt_dni.Text,
                      CStr(DropDownList_sexo.SelectedValue),
                      txt_nacionalidad.Text,
                      CInt(DropDownList_estadocivil.SelectedValue),
                      txt_profesion.Text,
                      CDate(Txt_fechanac_2.Text),
                      txt_domilicio.Text,
                       codpost,
                      CInt(DropDownList_provincia.SelectedValue),
                      CInt(DropDownList_ciudad.SelectedValue),
                      txt_telefono.Text,
                      txt_email.Text,
                      DropDownList_graduacion.SelectedValue, txt_contraseña1.Text, Today, DropDownList_instructor.SelectedValue, usuario_tipo, txt_usuario.Text, DropDownList_instituciones.SelectedValue,
                      txt_nrolibreta.Text
)
            ' End Using
            'div_registroexitoso.Visible = True
            'ModalPopupExtender2.Show() 'CARTEL DE REGISTRO EXITOSO
            limpiar_boxes()

            ModalPopupExtender2.Show()
            'Response.Redirect("../index.html")
        Else
            ModalPopupExtender3.Show() 'muestra el msj: Error, complete la info solicitada!
        End If
    End Sub


    Private Sub DropDownList_estadocivil_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_estadocivil.Init
        obtener_estadocivil()
    End Sub

    Dim usuario_tipo As String = "alumno"
    Private Sub DropDownList_graduacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_graduacion.SelectedIndexChanged
        CheckBox_posee_alumnos.Checked = False
        Dim graduacion As Integer = CInt(DropDownList_graduacion.SelectedValue)

        If graduacion > 11 Then
            div_posee_alumnos.Visible = True
        Else
            div_posee_alumnos.Visible = False
        End If


    End Sub

    Private Sub CheckBox_posee_alumnos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_posee_alumnos.CheckedChanged
        If CheckBox_posee_alumnos.Checked = True Then
            usuario_tipo = "instructor"
        Else
            usuario_tipo = "alumno"
        End If
    End Sub


    Private Sub ocultar_div_errores()
        'aqui ocultamos todo y lo llamo antes de guardar, es util cuando reiteradas veces se estan dando errores en la carga
        div_apellido_error.Visible = False
        div_nombre_error.Visible = False
        div_dni_error.Visible = False
        'falta fecha de nacimiento
        div_domicilio_error.Visible = False
        div_telefono_error.Visible = False
        div_email_error.Visible = False

        label_error_instituciones.Visible = False
        label_error_instructor.Visible = False
        div_usuario_error.Visible = False
        div_contraseña1_error.Visible = False
        div_contraseña2_error.Visible = False
        label_usuario_error.Text = "error!"
        label_dni_error.Text = "error!"
        div_registroexitoso.Visible = False
        label_error_fechanacimiento.Visible = False
    End Sub

    Private Sub limpiar_boxes()
        txt_apellido.Text = ""
        txt_nombre.Text = ""
        txt_dni.Text = ""
        txt_nacionalidad.Text = ""
        txt_profesion.Text = ""
        txt_domilicio.Text = ""
        txt_codigopostal.Text = ""
        txt_telefono.Text = ""
        txt_email.Text = ""
        txt_usuario.Text = ""
        txt_contraseña1.Text = ""
        txt_contraseña2.Text = ""
        txt_nrolibreta.Text = ""
        'div_registroexitoso.Visible=false
        Image1.ImageUrl = "~/Registro/imagen/usuario-registrado.jpg"
        Session("imagen") = ""
        foto_cargada = "no"

    End Sub




   
    

    



    


    

    Private Sub btn_Volver_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Volver.ServerClick
        Response.Redirect("../index.html")
    End Sub

    Private Sub btn_login_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_login.ServerClick
        Response.Redirect("../Login2/login2.aspx")
    End Sub

#Region "Gestion Foto"

    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String


    Private Sub Button_adjuntar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_adjuntar.Click

        If FileUpload1.HasFile Then
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".png" Or fileExt = ".jpg" Then



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
                'lbl_errImg.Visible = False
                'btn_Examinar.Visible = False
                'btn_quitar.Visible = True
            Else
                'lbl_errImg.Visible = True
                'lbl_errImg.InnerText = "Solo Archivos de Tipo Imagen"
            End If

        End If

    End Sub

    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

    Dim foto_cargada As String
    Private Sub Btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_aceptar.Click
        Try
            foto_cargada = "no"
            If FileUpload1.HasFile Then
                Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
                If fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".png" Or fileExt = ".jpg" Then

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
                    'Image1.Visible = True
                    'lbl_errImg.Visible = False
                    'btn_Examinar.Visible = False
                    'btn_quitar.Visible = True
                    foto_cargada = "si"

                    Session("foto_subido_registro") = "si" 'choco: 23-07-2019
                    Session("imagen_registro") = ImagenOriginal 'choco: 23-07-2019
                Else


                End If

            End If
        Catch ex As Exception

        End Try
        

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        'boton quitar foto
        Image1.ImageUrl = "~/Registro/imagen/usuario-registrado.jpg"
        Session("imagen") = ""
        Session("foto_subido_registro") = "no"
        Session("foto_subido") = "no"
        FileUpload1.Attributes.Clear()
    End Sub
#End Region

End Class