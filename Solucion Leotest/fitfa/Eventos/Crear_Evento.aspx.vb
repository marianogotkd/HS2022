Imports System.Drawing
Imports System.IO
Public Class Crear_Evento
    Inherits System.Web.UI.Page
    Dim DAevento As New Capa_de_datos.Eventos
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("imagen") = ""
            Session("foto_subido") = "no"
            lbl_errFecCier.Visible = False
            lbl_errNom.Visible = False
            lbl_costo.Visible = False
            lbl_errfechaini.Visible = False
            lbl_horaCierre.Visible = False
            lbl_errImg.Visible = False
            Page.Form.Attributes.Add("enctype", "multipart/form-data")
            div_modalOK.Visible = False
        End If

        


    End Sub
    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick
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

        If Session("foto_subido") = "no" Then
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen") = imagebytes
        End If



        'If Image1.Visible = False Then
        '    lbl_errImg.Visible = True
        '    lbl_errImg.InnerText = "Debe Seleccionar una Foto"
        '    Vacio = True
        'End If

        'If tb_fechaCierre.Value > tb_fechainicio Then
        '    lbl_errFecCier.InnerText = "La fecha de cierre no puede ser anterior a la del evento"
        '    lbl_errFecCier.Visible = True
        '    Vacio = True
        'End If


        Dim FechaHoraCierre = tb_fechaCierre.Value + " " + tb_horaCierre.Value



        If Vacio = False Then
            'If costo = "" Then
            '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(0), "")
            'Else
            '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, CDec(costo), "")
            'End If
            'div_modalOK.Visible = True
            'Modal_OK.Show()

            ''lbl_ok.Visible = True
            'tb_nombre.Value = ""
            'tb_fechainicio.Value = ""
            'tb_fechaCierre.Value = ""
            'tb_horaCierre.Value = ""
            'textbox_Costo.Text = ""
            'FileUpload1.Attributes.Clear()
            'Image1.Visible = False
            'btn_quitar.Visible = False
            'btn_Examinar.Visible = True

        End If

    End Sub

    Private Sub Subir_Foto_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Subir_Foto.ServerClick
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
            Else
                lbl_errImg.Visible = True
                lbl_errImg.InnerText = "Solo Archivos de Tipo Imagen"
            End If

        End If

    End Sub
    Private Sub btn_quitar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar.ServerClick
        Image1.ImageUrl = "~/Eventos/imagen/logo_evento.jpg"
        Session("imagen") = ""
        Session("foto_subido") = "no"

        FileUpload1.Attributes.Clear()
        'Image1.Visible = False
        'btn_quitar.Visible = False
        'btn_Examinar.Visible = True

    End Sub
    'Private Sub btn_cerrar_poup_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cerrar_poup.ServerClick
    '    'ModalPopupExtender1.Hide()

    'End Sub

    Protected Sub btn_save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_save.Click
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

        If Session("foto_subido") = "no" Then
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen") = imagebytes
        End If



        'If Image1.Visible = False Then
        '    lbl_errImg.Visible = True
        '    lbl_errImg.InnerText = "Debe Seleccionar una Foto"
        '    Vacio = True
        'End If

        'If tb_fechaCierre.Value > tb_fechainicio Then
        '    lbl_errFecCier.InnerText = "La fecha de cierre no puede ser anterior a la del evento"
        '    lbl_errFecCier.Visible = True
        '    Vacio = True
        'End If


        Dim FechaHoraCierre = tb_fechaCierre.Value + " " + tb_horaCierre.Value



        If Vacio = False Then
            'If costo = "" Then
            '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, IsDBNull(costo), "")
            'Else
            '    DAevento.Eventos_Alta(tb_nombre.Value, Session("imagen"), tb_fechainicio.Value, FechaHoraCierre, combo_TipoEvento.SelectedValue, costo, "")
            'End If
            'div_modalOK.Visible = True
            'Modal_OK.Show()

            ''lbl_ok.Visible = True
            'tb_nombre.Value = ""
            'tb_fechainicio.Value = ""
            'tb_fechaCierre.Value = ""
            'tb_horaCierre.Value = ""
            'textbox_Costo.Text = ""
            'FileUpload1.Attributes.Clear()
            'Image1.Visible = False
            'btn_quitar.Visible = False
            'btn_Examinar.Visible = True

        End If
    End Sub
End Class