Imports System.Drawing
Imports System.IO
Public Class Institucion_alta
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String
    Dim DAinstitucion As New Capa_de_datos.Instituciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("imagen") = ""
            Session("foto_subido") = "no"
            HiddenField_instructor_id.Value = Session("instructor_id") 'esta lo traigo desde el form de instructor_institucion_B

            div_modalOK.Visible = False
            div_modal_errorexiste.Visible = False
            div_modal_errorcomplete.Visible = False
        End If


    End Sub

    Private Sub combo_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_provincia.Init
        Obtener_provincias()
    End Sub
    Private Sub Obtener_provincias()
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            combo_provincia.DataSource = ds_provincias.Tables(0)
            combo_provincia.DataTextField = "provincia_desc"
            combo_provincia.DataValueField = "provincia_id"
            combo_provincia.DataBind()
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
                'lbl_errImg.Visible = False
                btn_Examinar.Visible = True
                btn_quitar.Visible = True
            Else

                'lbl_errImg.Visible = True
                'lbl_errImg.InnerText = "Solo Archivos de Tipo Imagen"
            End If

        End If
    End Sub

    Private Sub btn_quitar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar.ServerClick
        Image1.ImageUrl = "~/Instituciones/imagen/logo_institucion.jpg"
        Session("imagen") = ""
        Session("foto_subido") = "no"
    End Sub

    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick
        Dim valido As String = "si"
        'valido que no exista esa institucion
        If tb_nombre.Value <> "" And tb_abreviatura.Value <> "" Then
            'valido que solo el nombre no se repita
            Dim ds_inst As DataSet = DAinstitucion.Institucion_obtenertodo
            Dim i As Integer = 0
            While i < ds_inst.Tables(0).Rows.Count
                If tb_nombre.Value.ToUpper = ds_inst.Tables(0).Rows(i).Item("institucion_descripcion").ToString.ToUpper Then
                    valido = "no"
                    i = ds_inst.Tables(0).Rows.Count
                End If
                i = i + 1
            End While
            If valido = "si" Then
                If Session("foto_subido") = "no" Then
                    Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
                    Session("imagen") = imagebytes
                End If
                'validacion 
                If Session("procedencia") = "solo_institucion" Then
                    'aqui va lo mismo pero sin el parametro de instructor, podria usar  el if de mariano
                    If tb_nombre.Value <> "" And tb_abreviatura.Value <> "" Then
                        DAinstitucion.Instituciones_alta(combo_provincia.SelectedValue, tb_nombre.Value, tb_abreviatura.Value, Session("imagen"), 0)
                        div_modalOK.Visible = True
                        Modal_OK.Show()
                        limpiarbox()
                        Response.Redirect("~/Instituciones/Institucion_modificar.aspx")
                    End If
                Else
                    If Session("procedencia") = "con_instructor" Then
                        If tb_nombre.Value <> "" And tb_abreviatura.Value <> "" Then
                            DAinstitucion.Instituciones_alta(combo_provincia.SelectedValue, tb_nombre.Value, tb_abreviatura.Value, Session("imagen"), HiddenField_instructor_id.Value)
                            div_modalOK.Visible = True
                            Modal_OK.Show()
                            limpiarbox()
                            Response.Redirect("~/Instituciones/Instructor_institucion_b.aspx")
                        End If
                    End If

                End If
            Else
                'aqui va el msg de que existe una institucion con ese nombre
                div_modal_errorexiste.Visible = True
                modal_errorexiste.Show()
            End If
        Else
            'aqui val el msg de que complete los datos para guardar.
            div_modal_errorcomplete.Visible = True
            modal_errorcomplete.Show()
        End If
    End Sub

    Private Sub limpiarbox()
        Image1.ImageUrl = "~/Instituciones/imagen/logo_institucion.jpg"
        Session("imagen") = ""
        Session("foto_subido") = "no"
        tb_nombre.Value = ""
        tb_abreviatura.Value = ""
        tb_nombre.Focus()
    End Sub

End Class