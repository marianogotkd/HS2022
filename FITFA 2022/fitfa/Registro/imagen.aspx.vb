Imports System.Drawing

Public Class imagen
    Inherits System.Web.UI.Page


    Dim DAusuario As New Capa_de_datos.usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim tamanio As Integer = FileUpload1.PostedFile.ContentLength
        'int Tamanio = fuploadImagen.PostedFile.ContentLength;
        'choco
        Dim ImagenOriginal As Byte() = New Byte(tamanio - 1) {}
        'byte[] ImagenOriginal = new byte[Tamanio];
        'choco
        FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
        'fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
        'choco
        Dim ImagenOriginalBinaria As Bitmap = New Bitmap(FileUpload1.PostedFile.InputStream)
        'Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
        'choco
        Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
        'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
        'choco
        'image1.ImageUrl = ImagenDataURL64
        Image1.ImageUrl = ImagenDataURL64
        'imgPreview.ImageUrl = ImagenDataURL64;
        'Image1.ImageUrl = "~/Registro/imagen/" & FileUpload1.FileName

        DAusuario.Usuario_imagen_actualizar("45", ImagenOriginal)
        'el usuario 3 es mariano
        Label1.Text = "foto guardada en usuario Mariano"
        Label1.ForeColor = Color.Green
    End Sub

    Private Sub FileUpload1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileUpload1.Init
        'FileUpload1.Attributes.Add("onchange", "fileUpload1()")
    End Sub
End Class