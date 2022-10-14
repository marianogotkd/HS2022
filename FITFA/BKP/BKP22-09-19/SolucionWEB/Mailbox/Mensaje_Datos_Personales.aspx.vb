Public Class Mensaje_Datos_Personales
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario
    Dim busqueda As New Data.DataSet
    Dim Guardado = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim varses = Session("usuario_id")
        If varses <> 0 Then
            MsjeOK.Visible = False
            Dim varsesion = Session("usuario_id")
            busqueda = DAusuario.Mensaje_Nuevo_Registro(varsesion)
            lbl_Tipo.Text = "El Usuario se Registro Como" + " " + busqueda.Tables(0).Rows(0).Item(6)
            Lbl_nombre.Text = busqueda.Tables(0).Rows(0).Item(0)
            lbl_doc.Text = busqueda.Tables(0).Rows(0).Item(4)
            lbl_Direccion.Text = busqueda.Tables(0).Rows(0).Item(1)
            ' Lbl_inst.Text = busqueda.Tables(0).Rows(0).Item(5)
            lbl_Institucion.Text = busqueda.Tables(0).Rows(0).Item(5)
            lbl_fecha.Text = busqueda.Tables(0).Rows(0).Item(9)
            lbl_NomCuerpo.Text = busqueda.Tables(0).Rows(0).Item(0)
            lbl_Provincia.Text = busqueda.Tables(0).Rows(0).Item(2)
            lbl_Sexo.Text = busqueda.Tables(0).Rows(0).Item(3)

            Dim ImagenBD As Byte() = busqueda.Tables(0).Rows(0).Item(8)
            Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)
            'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
            'choco
            'image1.ImageUrl = ImagenDataURL64
            Image1.ImageUrl = ImagenDataURL64



        End If

    End Sub
    Public Sub Guardar()
        If Session("usuario_id") <> 0 Then
            DAusuario.Activar_Usuario(Session("usuario_id"), Session("Us_id"), busqueda.Tables(0).Rows(0).Item(6), busqueda.Tables(0).Rows(0).Item(7))
            MsjeOK.Visible = True
            Session("usuario_id") = 0
        End If
    End Sub

    Private Sub btn_Aceptar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Aceptar.ServerClick

        Guardar()
    End Sub

    Private Sub btn_aceptarAb_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptarAb.ServerClick

        Guardar()
       
    End Sub
End Class